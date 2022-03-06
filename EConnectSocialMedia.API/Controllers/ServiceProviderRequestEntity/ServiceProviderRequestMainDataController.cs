using GangstersAPP.Entity.ServiceProviderRequestEntity;
using GangstersAPP.ServiceEntity.ServiceProviderRequestEntity;

namespace GangstersAPP.API.Controllers.ServiceProviderRequestEntity
{
    [Authorize]
    [ApiController]
    [Produces("application/json")]
    [ApiExplorerSettings(GroupName = "ServiceProviderRequestMainData")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class ServiceProviderRequestMainDataController : Controller
    {
        private readonly DatabaseContext _DBContext;
        private readonly UnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;
        private readonly EntityLocalizationService _Localizer;
        private readonly IAccountService _AccountService;
        private readonly StatusHandler _StatusHandler;
        private readonly IWebHostEnvironment _Environment;
        private readonly AppSettings _appSettings;

        public ServiceProviderRequestMainDataController(
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
        /// Get: Get ServiceProviderClassifications
        /// </summary>
        [HttpGet]
        [Route(nameof(GetServiceProviderClassifications))]
        public List<ServiceProviderClassificationModel> GetServiceProviderClassifications(
            [FromQuery] string Culture,
            [FromQuery] string Search,
            [FromQuery] Paging paging)
        {
            string ActionName = nameof(GetServiceProviderClassifications);
            List<ServiceProviderClassificationModel> returnData = new();
            Status Status = new();

            try
            {
                IQueryable<ServiceProviderClassification> Data = _UnitOfWork.ServiceProviderClassification.GetQuery(a => (string.IsNullOrEmpty(Search) ||
                                                                            a.Name.ToLower().Contains(Search.ToLower())));

                Data = OrderBy<ServiceProviderClassification>.OrderData(Data, paging.OrderBy);

                PagedList<ServiceProviderClassification> PagedData = PagedList<ServiceProviderClassification>.Create(Data, paging.PageNumber, paging.PageSize);

                if (Culture.ToLower() == "en")
                {
                    PagedData = _UnitOfWork.ServiceProviderClassification.GetLang(PagedData);

                }

                _Mapper.Map(PagedData, returnData);

                Response.Headers.Add("X-Pagination", StatusHandler<ServiceProviderClassification>.GetPagination(PagedData, paging, ActionName));

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
