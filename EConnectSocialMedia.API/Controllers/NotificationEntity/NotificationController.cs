namespace GangstersAPP.API.Controllers.NotificationEntity
{
    [Authorize]
    [ApiController]
    [Produces("application/json")]
    [ApiExplorerSettings(GroupName = "Notification")]
    [Route("api/v{version:apiVersion}/NotificationEntity/[controller]")]
    [ApiVersion("1.0")]
    public class NotificationController : ControllerBase
    {
        private readonly DatabaseContext _DBContext;
        private readonly UnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;
        private readonly EntityLocalizationService _Localizer;
        private readonly IAccountService _AccountService;
        private readonly StatusHandler _StatusHandler;
        private readonly IWebHostEnvironment _Environment;
        private readonly AppSettings _appSettings;

        public NotificationController(
            DatabaseContext dataContext,
            UnitOfWork unitOfWork,
            IMapper mapper,
            EntityLocalizationService Localizer,
            IAccountService AccountService,
            IWebHostEnvironment environment,
            IOptions<AppSettings> appSettings)
        {
            _DBContext = dataContext;
            _UnitOfWork = unitOfWork;
            _Mapper = mapper;
            _Localizer = Localizer;
            _AccountService = AccountService;
            _Environment = environment;
            _appSettings = appSettings.Value;
            _StatusHandler = new StatusHandler(Localizer);
        }

        /// <summary>
        /// Get: Get Notifications
        /// </summary>
        [HttpGet]
        [Route(nameof(GetNotifications))]
        public List<NotificationModel> GetNotifications(
            [FromQuery] string Culture,
            [FromQuery] Paging paging)
        {
            string ActionName = nameof(GetNotifications);
            List<NotificationModel> returnData = new();
            Status Status = new();

            try
            {
                AuthorizedAccount account = (AuthorizedAccount)Request.HttpContext.Items["Account"];

                IQueryable<Notification> Data = _UnitOfWork.Notification.GetQuery(a => a.IsActive &&
                                                                                       (a.IsPublic ||
                                                                                        a.NotificationAccounts.Any(b => b.Fk_Account == account.Id)))
                                                                        .OrderByDescending(a => a.Id);

                //Data = OrderBy<Notification>.OrderData(Data, paging.OrderBy);

                PagedList<Notification> PagedData = PagedList<Notification>.Create(Data, paging.PageNumber, paging.PageSize);


                _Mapper.Map(PagedData, returnData);

                Response.Headers.Add("X-Pagination", StatusHandler<Notification>.GetPagination(PagedData, paging, ActionName));

                Status = new Status(true);
            }
            catch (Exception ex)
            {
                Status = _StatusHandler.SetException(Status, ex);
            }

            Response.Headers.Add("X-Status", _StatusHandler.GetStatus(Status));

            return returnData;
        }

        /// <summary>
        /// Get: GetNotificationProfile
        /// </summary>
        [HttpGet]
        [Route(nameof(GetNotificationProfile))]
        public NotificationModel GetNotificationProfile(
            [FromQuery] string Culture,
            [FromQuery] int id)
        {
            NotificationModel returnData = new();
            Status Status = new();

            try
            {
                AuthorizedAccount account = (AuthorizedAccount)Request.HttpContext.Items["Account"];

                IQueryable<Notification> Data = _UnitOfWork.Notification.GetQuery(a => a.Id == id && a.IsActive &&
                                                                                       (a.IsPublic ||
                                                                                        a.NotificationAccounts.Any(b => b.Fk_Account == account.Id)));



                _Mapper.Map(Data, returnData);

                Status = new Status(true);
            }
            catch (Exception ex)
            {
                Status = _StatusHandler.SetException(Status, ex);
            }

            Response.Headers.Add("X-Status", _StatusHandler.GetStatus(Status));

            return returnData;
        }
    }
}
