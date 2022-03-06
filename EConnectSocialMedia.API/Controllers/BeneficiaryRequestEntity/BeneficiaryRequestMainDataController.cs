namespace EConnectSocialMedia.API.Controllers.BeneficiaryRequestEntity
{
    [Authorize]
    [ApiController]
    [Produces("application/json")]
    [ApiExplorerSettings(GroupName = "BeneficiaryRequestMainData")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class BeneficiaryRequestMainDataController : Controller
    {
        private readonly DatabaseContext _DBContext;
        private readonly UnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;
        private readonly EntityLocalizationService _Localizer;
        private readonly IAccountService _AccountService;
        private readonly StatusHandler _StatusHandler;
        private readonly IWebHostEnvironment _Environment;
        private readonly AppSettings _appSettings;

        public BeneficiaryRequestMainDataController(
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
        /// Get: Get Beneficiary Types
        /// </summary>
        [HttpGet]
        [Route(nameof(GetBeneficiaryTypes))]
        public List<BeneficiaryTypeModel> GetBeneficiaryTypes(
            [FromQuery] string Culture,
            [FromQuery] string Search,
            [FromQuery] Paging paging)
        {
            string ActionName = nameof(GetBeneficiaryTypes);
            List<BeneficiaryTypeModel> returnData = new();
            Status Status = new();

            try
            {
                IQueryable<BeneficiaryType> Data = _UnitOfWork.BeneficiaryType.GetQuery(a => (string.IsNullOrEmpty(Search) ||
                                                                            a.Name.ToLower().Contains(Search.ToLower())));

                Data = OrderBy<BeneficiaryType>.OrderData(Data, paging.OrderBy);

                PagedList<BeneficiaryType> PagedData = PagedList<BeneficiaryType>.Create(Data, paging.PageNumber, paging.PageSize);

                if (Culture.ToLower() == "en")
                {
                    PagedData = _UnitOfWork.BeneficiaryType.GetLang(PagedData);

                }

                _Mapper.Map(PagedData, returnData);

                Response.Headers.Add("X-Pagination", StatusHandler<BeneficiaryType>.GetPagination(PagedData, paging, ActionName));

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
