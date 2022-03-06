namespace GangstersAPP.API.Controllers.AccountEntity
{
    [Authorize]
    [ApiController]
    [Produces("application/json")]
    [ApiExplorerSettings(GroupName = "AccountMainData")]
    [Route("api/v{version:apiVersion}/AccountEntity/[controller]")]
    [ApiVersion("1.0")]
    [AllowAnonymous]
    public class AccountMainDataController : ControllerBase
    {
        private readonly DatabaseContext _DBContext;
        private readonly UnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;
        private readonly EntityLocalizationService _Localizer;
        private readonly IAccountService _AccountService;
        private readonly StatusHandler _StatusHandler;
        private readonly IWebHostEnvironment _Environment;
        private readonly AppSettings _appSettings;

        public AccountMainDataController(
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
        /// Get: Get Account States
        /// </summary>
        [HttpGet]
        [Route(nameof(GetAccountStates))]
        public List<AccountStateModel> GetAccountStates(
            [FromQuery] string Culture,
            [FromQuery] string Search,
            [FromQuery] Paging paging)
        {
            string ActionName = nameof(GetAccountStates);
            List<AccountStateModel> returnData = new();
            Status Status = new();

            try
            {
                IQueryable<AccountState> Data = _UnitOfWork.AccountState.GetQuery(a => (string.IsNullOrEmpty(Search) ||
                                                                                        a.Name.ToLower().Contains(Search.ToLower())));

                Data = OrderBy<AccountState>.OrderData(Data, paging.OrderBy);

                PagedList<AccountState> PagedData = PagedList<AccountState>.Create(Data, paging.PageNumber, paging.PageSize);

                if (Culture.ToLower() == "en")
                {
                    PagedData = _UnitOfWork.AccountState.GetLang(PagedData);
                }

                _Mapper.Map(PagedData, returnData);

                Response.Headers.Add("X-Pagination", StatusHandler<AccountState>.GetPagination(PagedData, paging, ActionName));

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
        /// Get: Get Account Types
        /// </summary>
        [HttpGet]
        [Route(nameof(GetAccountTypes))]
        public List<AccountTypeModel> GetAccountTypes(
            [FromQuery] string Culture,
            [FromQuery] string Search,
            [FromQuery] Paging paging)
        {
            string ActionName = nameof(GetAccountTypes);
            List<AccountTypeModel> returnData = new();
            Status Status = new();

            try
            {
                IQueryable<AccountType> Data = _UnitOfWork.AccountType.GetQuery(a => (string.IsNullOrEmpty(Search) ||
                                                                                      a.Name.ToLower().Contains(Search.ToLower())));

                Data = OrderBy<AccountType>.OrderData(Data, paging.OrderBy);

                PagedList<AccountType> PagedData = PagedList<AccountType>.Create(Data, paging.PageNumber, paging.PageSize);

                if (Culture.ToLower() == "en")
                {
                    PagedData = _UnitOfWork.AccountType.GetLang(PagedData);

                }
                _Mapper.Map(PagedData, returnData);

                Response.Headers.Add("X-Pagination", StatusHandler<AccountType>.GetPagination(PagedData, paging, ActionName));

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
        /// Get: Get Genders
        /// </summary>
        [HttpGet]
        [Route(nameof(GetGenders))]
        public List<GenderModel> GetGenders(
            [FromQuery] string Culture,
            [FromQuery] string Search,
            [FromQuery] Paging paging)
        {
            string ActionName = nameof(GetGenders);
            List<GenderModel> returnData = new();
            Status Status = new();

            try
            {
                IQueryable<Gender> Data = _UnitOfWork.Gender.GetQuery(a => (string.IsNullOrEmpty(Search) ||
                                                                            a.Name.ToLower().Contains(Search.ToLower())));

                Data = OrderBy<Gender>.OrderData(Data, paging.OrderBy);

                PagedList<Gender> PagedData = PagedList<Gender>.Create(Data, paging.PageNumber, paging.PageSize);

                if (Culture.ToLower() == "en")
                {
                    PagedData = _UnitOfWork.Gender.GetLang(PagedData);

                }
                _Mapper.Map(PagedData, returnData);

                Response.Headers.Add("X-Pagination", StatusHandler<Gender>.GetPagination(PagedData, paging, ActionName));

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
