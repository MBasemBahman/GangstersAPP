namespace GangstersAPP.API.Controllers.PostEntity
{
    [Authorize]
    [ApiController]
    [Produces("application/json")]
    [ApiExplorerSettings(GroupName = "PostMainData")]
    [Route("api/v{version:apiVersion}/PostEntity/[controller]")]
    [ApiVersion("1.0")]
    public class PostMainDataController : ControllerBase
    {
        private readonly DatabaseContext _DBContext;
        private readonly UnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;
        private readonly EntityLocalizationService _Localizer;
        private readonly IAccountService _AccountService;
        private readonly StatusHandler _StatusHandler;
        private readonly IWebHostEnvironment _Environment;
        private readonly AppSettings _appSettings;

        public PostMainDataController(
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
        /// Get: Get Post Types
        /// </summary>
        [HttpGet]
        [Route(nameof(GetPostTypes))]
        public List<PostTypeModel> GetPostTypes(
            [FromQuery] string Culture,
            [FromQuery] string Search,
            [FromQuery] Paging paging)
        {
            string ActionName = nameof(GetPostTypes);
            List<PostTypeModel> returnData = new();
            Status Status = new();

            try
            {
                IQueryable<PostType> Data = _UnitOfWork.PostType.GetQuery(a => (string.IsNullOrEmpty(Search) ||
                                                                                        a.Name.ToLower().Contains(Search.ToLower())));

                Data = OrderBy<PostType>.OrderData(Data, paging.OrderBy);

                PagedList<PostType> PagedData = PagedList<PostType>.Create(Data, paging.PageNumber, paging.PageSize);

                if (Culture.ToLower() == "en")
                {
                    PagedData = _UnitOfWork.PostType.GetLang(PagedData);

                }
                _Mapper.Map(PagedData, returnData);

                Response.Headers.Add("X-Pagination", StatusHandler<PostType>.GetPagination(PagedData, paging, ActionName));

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
        /// Get: Get Post States
        /// </summary>
        [HttpGet]
        [Route(nameof(GetPostStates))]
        public List<PostStateModel> GetPostStates(
            [FromQuery] string Culture,
            [FromQuery] string Search,
            [FromQuery] Paging paging)
        {
            string ActionName = nameof(GetPostStates);
            List<PostStateModel> returnData = new();
            Status Status = new();

            try
            {
                IQueryable<PostState> Data = _UnitOfWork.PostState.GetQuery(a => (string.IsNullOrEmpty(Search) ||
                                                                            a.Name.ToLower().Contains(Search.ToLower())));

                Data = OrderBy<PostState>.OrderData(Data, paging.OrderBy);

                PagedList<PostState> PagedData = PagedList<PostState>.Create(Data, paging.PageNumber, paging.PageSize);

                if (Culture.ToLower() == "en")
                {
                    PagedData = _UnitOfWork.PostState.GetLang(PagedData);
                }
                _Mapper.Map(PagedData, returnData);

                Response.Headers.Add("X-Pagination", StatusHandler<PostState>.GetPagination(PagedData, paging, ActionName));

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
        /// Get: Get Reaction Types
        /// </summary>
        [HttpGet]
        [Route(nameof(GetReactionTypes))]
        public List<ReactionTypeModel> GetReactionTypes(
            [FromQuery] string Culture,
            [FromQuery] string Search,
            [FromQuery] Paging paging)
        {
            string ActionName = nameof(GetReactionTypes);
            List<ReactionTypeModel> returnData = new();
            Status Status = new();

            try
            {
                IQueryable<ReactionType> Data = _UnitOfWork.ReactionType.GetQuery(a => (string.IsNullOrEmpty(Search) ||
                                                                                      a.Name.ToLower().Contains(Search.ToLower())));

                Data = OrderBy<ReactionType>.OrderData(Data, paging.OrderBy);

                PagedList<ReactionType> PagedData = PagedList<ReactionType>.Create(Data, paging.PageNumber, paging.PageSize);

                if (Culture.ToLower() == "en")
                {
                    PagedData = _UnitOfWork.ReactionType.GetLang(PagedData);
                }

                _Mapper.Map(PagedData, returnData);

                Response.Headers.Add("X-Pagination", StatusHandler<ReactionType>.GetPagination(PagedData, paging, ActionName));

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
