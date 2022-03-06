namespace EConnectSocialMedia.API.Controllers.GroupEntity
{
    [Authorize]
    [ApiController]
    [Produces("application/json")]
    [ApiExplorerSettings(GroupName = "GroupMainData")]
    [Route("api/v{version:apiVersion}/GroupEntity/[controller]")]
    [ApiVersion("1.0")]
    public class GroupMainDataController : Controller
    {
        private readonly DatabaseContext _DBContext;
        private readonly UnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;
        private readonly EntityLocalizationService _Localizer;
        private readonly IAccountService _AccountService;
        private readonly StatusHandler _StatusHandler;
        private readonly IWebHostEnvironment _Environment;
        private readonly AppSettings _appSettings;

        public GroupMainDataController(
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
        /// Get: Get Group Types
        /// </summary>
        [HttpGet]
        [Route(nameof(GetGroupTypes))]
        public List<GroupTypeModel> GetGroupTypes(
            [FromQuery] string Culture,
            [FromQuery] string Search,
            [FromQuery] Paging paging)
        {
            string ActionName = nameof(GetGroupTypes);
            List<GroupTypeModel> returnData = new();
            Status Status = new();

            try
            {
                IQueryable<GroupType> Data = _UnitOfWork.GroupType.GetQuery(a => (string.IsNullOrEmpty(Search) ||
                                                                                        a.Name.ToLower().Contains(Search.ToLower())));

                Data = OrderBy<GroupType>.OrderData(Data, paging.OrderBy);

                PagedList<GroupType> PagedData = PagedList<GroupType>.Create(Data, paging.PageNumber, paging.PageSize);

                if (Culture.ToLower() == "en")
                {
                    PagedData = _UnitOfWork.GroupType.GetLang(PagedData);

                }
                _Mapper.Map(PagedData, returnData);

                Response.Headers.Add("X-Pagination", StatusHandler<GroupType>.GetPagination(PagedData, paging, ActionName));

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
