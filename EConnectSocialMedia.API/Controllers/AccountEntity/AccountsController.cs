namespace EConnectSocialMedia.API.Controllers.AccountEntity
{
    [Authorize]
    [ApiController]
    [Produces("application/json")]
    [ApiExplorerSettings(GroupName = "Accounts")]
    [Route("api/v{version:apiVersion}/AccountEntity/[controller]")]
    [ApiVersion("1.0")]
    public class AccountsController : ControllerBase
    {
        private readonly DatabaseContext _DBContext;
        private readonly UnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;
        private readonly EntityLocalizationService _Localizer;
        private readonly IAccountService _AccountService;
        private readonly StatusHandler _StatusHandler;
        private readonly IWebHostEnvironment _Environment;
        private readonly AppSettings _appSettings;

        public AccountsController(
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
        /// Get: Get Accounts
        /// </summary>
        [HttpGet]
        [Route(nameof(GetAccounts))]
        public List<AccountModel> GetAccounts(
            [FromQuery] string Culture,
            [FromQuery] string Search,
            [FromQuery] Paging paging,
            [FromQuery] int Fk_Chat = 0,
            [FromQuery] int Fk_Group = 0)
        {
            string ActionName = nameof(GetAccounts);
            List<AccountModel> returnData = new();
            Status Status = new();

            try
            {
                AuthorizedAccount account = (AuthorizedAccount)Request.HttpContext.Items["Account"];

                IQueryable<Account> Data = _UnitOfWork.Account.GetQuery(a => (string.IsNullOrEmpty(Search) ||
                                                                              a.FirstName.ToLower().Contains(Search.ToLower()) ||
                                                                              a.LastName.ToLower().Contains(Search.ToLower()) ||
                                                                              a.NickName.ToLower().Contains(Search.ToLower()) ||
                                                                              a.UniqueName.ToLower().Contains(Search.ToLower()) ||
                                                                              a.Phone.ToLower().Contains(Search.ToLower()) ||
                                                                              a.Email.ToLower().Contains(Search.ToLower())) &&
                                                                              (Fk_Chat == 0 || !a.ChatMembers.Any(b => b.Fk_Chat == Fk_Chat)) &&
                                                                              (Fk_Group == 0 || !a.GroupMembers.Any(b => b.Fk_Group == Fk_Group)) &&
                                                                              (a.Id != account.Id));

                Data = OrderBy<Account>.OrderData(Data, paging.OrderBy);

                PagedList<Account> PagedData = PagedList<Account>.Create(Data, paging.PageNumber, paging.PageSize);

                _Mapper.Map(PagedData, returnData);

                Response.Headers.Add("X-Pagination", StatusHandler<Account>.GetPagination(PagedData, paging, ActionName));

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
        /// Post: Change Account State
        /// </summary>
        [HttpPost]
        [Route(nameof(ChangeAccountState))]
        public async Task<bool> ChangeAccountState(
            [FromQuery] string Culture,
            [FromBody] AccountEditStateModel model)
        {
            bool returnData = false;

            Status Status = new();

            try
            {
                if (!ModelState.IsValid)
                {
                    throw new AppException("Complete your info!");
                }

                Account data = await _UnitOfWork.Account.GetFirst(a => a.Id == model.Fk_Account);

                data.Fk_AccountState = model.Fk_AccountState;

                _UnitOfWork.Account.UpdateEntity(data);

                _UnitOfWork.Account.Save();

                returnData = true;
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
