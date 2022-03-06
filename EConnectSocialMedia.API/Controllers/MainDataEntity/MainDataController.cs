namespace EConnectSocialMedia.API.Controllers.MainDataEntity
{
    [Authorize]
    [ApiController]
    [Produces("application/json")]
    [ApiExplorerSettings(GroupName = "MainData")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class MainDataController : Controller
    {
        private readonly DatabaseContext _DBContext;
        private readonly UnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;
        private readonly EntityLocalizationService _Localizer;
        private readonly IAccountService _AccountService;
        private readonly StatusHandler _StatusHandler;
        private readonly IWebHostEnvironment _Environment;
        private readonly AppSettings _appSettings;

        public MainDataController(
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
        /// Get: Get App About
        /// </summary>
        [HttpGet]
        [Route(nameof(GetAppAbout))]
        public async Task<AppAboutModel> GetAppAbout(
            [FromQuery] string Culture)
        {
            AppAboutModel returnData = new();
            Status Status = new();

            try
            {
                AppAbout Data = await _UnitOfWork.AppAbout.GetFirst();

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


        /// <summary>
        /// Get: Get App Intros
        /// </summary>
        [HttpGet]
        [Route(nameof(GetAppIntros))]
        public List<AppIntroModel> GetAppIntros(
            [FromQuery] string Culture,
            [FromQuery] string Search,
            [FromQuery] int Fk_AccountType,
            [FromQuery] Paging paging)
        {
            string ActionName = nameof(GetAppIntros);
            List<AppIntroModel> returnData = new();
            Status Status = new();

            try
            {
                IQueryable<AppIntro> Data = _UnitOfWork.AppIntro.GetQuery(a => (string.IsNullOrEmpty(Search) ||
                                                                                        a.Title.ToLower().Contains(Search.ToLower()))
                                                                                       && (Fk_AccountType == 0 || a.Fk_AccountType == Fk_AccountType));

                Data = OrderBy<AppIntro>.OrderData(Data, paging.OrderBy);

                PagedList<AppIntro> PagedData = PagedList<AppIntro>.Create(Data, paging.PageNumber, paging.PageSize);

                if (Culture.ToLower() == "en")
                {
                    PagedData = _UnitOfWork.AppIntro.GetLang(PagedData);
                }

                _Mapper.Map(PagedData, returnData);

                Response.Headers.Add("X-Pagination", StatusHandler<AppIntro>.GetPagination(PagedData, paging, ActionName));

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
        /// Get: Get Questions And Answers
        /// </summary>
        [HttpGet]
        [Route(nameof(GetQuestionsAndAnswers))]
        public List<QuestionsAndAnswersModel> GetQuestionsAndAnswers(
            [FromQuery] string Culture,
            [FromQuery] string Question,
            [FromQuery] string Answer,
            [FromQuery] Paging paging)
        {
            string ActionName = nameof(GetQuestionsAndAnswers);
            List<QuestionsAndAnswersModel> returnData = new();
            Status Status = new();

            try
            {
                IQueryable<QuestionsAndAnswers> Data = _UnitOfWork.QuestionsAndAnswers.GetQuery(a => (string.IsNullOrEmpty(Question) ||
                                                                                        a.Question.ToLower().Contains(Question.ToLower()))
                                                                                       && (string.IsNullOrEmpty(Answer) || a.Answer.ToLower().Contains(Answer.ToLower())));

                Data = OrderBy<QuestionsAndAnswers>.OrderData(Data, paging.OrderBy);

                PagedList<QuestionsAndAnswers> PagedData = PagedList<QuestionsAndAnswers>.Create(Data, paging.PageNumber, paging.PageSize);

                if (Culture.ToLower() == "en")
                {
                    PagedData = _UnitOfWork.QuestionsAndAnswers.GetLang(PagedData);

                }
                _Mapper.Map(PagedData, returnData);

                Response.Headers.Add("X-Pagination", StatusHandler<QuestionsAndAnswers>.GetPagination(PagedData, paging, ActionName));

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
        /// Get: Get Terms And Conditions
        /// </summary>
        [HttpGet]
        [Route(nameof(GetTermsAndConditions))]
        public List<TermsAndConditionsModel> GetTermsAndConditions(
            [FromQuery] string Culture,
            [FromQuery] string Search,
            [FromQuery] Paging paging)
        {
            string ActionName = nameof(GetTermsAndConditions);
            List<TermsAndConditionsModel> returnData = new();
            Status Status = new();

            try
            {
                IQueryable<TermsAndConditions> Data = _UnitOfWork.TermsAndConditions.GetQuery(a => (string.IsNullOrEmpty(Search) ||
                                                                                        a.Title.ToLower().Contains(Search.ToLower())));

                Data = OrderBy<TermsAndConditions>.OrderData(Data, paging.OrderBy);

                PagedList<TermsAndConditions> PagedData = PagedList<TermsAndConditions>.Create(Data, paging.PageNumber, paging.PageSize);

                if (Culture.ToLower() == "en")
                {
                    PagedData = _UnitOfWork.TermsAndConditions.GetLang(PagedData);
                }

                _Mapper.Map(PagedData, returnData);

                Response.Headers.Add("X-Pagination", StatusHandler<TermsAndConditions>.GetPagination(PagedData, paging, ActionName));

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
