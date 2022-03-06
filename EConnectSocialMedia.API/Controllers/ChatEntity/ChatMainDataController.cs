namespace EConnectSocialMedia.API.Controllers.ChatEntity
{
    [Authorize]
    [ApiController]
    [Produces("application/json")]
    [ApiExplorerSettings(GroupName = "ChatMainData")]
    [Route("api/v{version:apiVersion}/ChatEntity/[controller]")]
    [ApiVersion("1.0")]
    public class ChatMainDataController : ControllerBase
    {
        private readonly DatabaseContext _DBContext;
        private readonly UnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;
        private readonly EntityLocalizationService _Localizer;
        private readonly IAccountService _AccountService;
        private readonly StatusHandler _StatusHandler;
        private readonly IWebHostEnvironment _Environment;
        private readonly AppSettings _appSettings;

        public ChatMainDataController(
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
        /// Get: Get Chat Types
        /// </summary>
        [HttpGet]
        [Route(nameof(GetChatTypes))]
        public List<ChatTypeModel> GetChatTypes(
            [FromQuery] string Culture,
            [FromQuery] string Search,
            [FromQuery] Paging paging)
        {
            string ActionName = nameof(GetChatTypes);
            List<ChatTypeModel> returnData = new();
            Status Status = new();

            try
            {
                IQueryable<ChatType> Data = _UnitOfWork.ChatType.GetQuery(a => (string.IsNullOrEmpty(Search) ||
                                                                                        a.Name.ToLower().Contains(Search.ToLower())));

                Data = OrderBy<ChatType>.OrderData(Data, paging.OrderBy);

                PagedList<ChatType> PagedData = PagedList<ChatType>.Create(Data, paging.PageNumber, paging.PageSize);

                if (Culture.ToLower() == "en")
                {
                    PagedData = _UnitOfWork.ChatType.GetLang(PagedData);
                }

                _Mapper.Map(PagedData, returnData);

                Response.Headers.Add("X-Pagination", StatusHandler<ChatType>.GetPagination(PagedData, paging, ActionName));

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
        /// Get: Get Message Types
        /// </summary>
        [HttpGet]
        [Route(nameof(GetMessageTypes))]
        public List<MessageTypeModel> GetMessageTypes(
            [FromQuery] string Culture,
            [FromQuery] string Search,
            [FromQuery] Paging paging)
        {
            string ActionName = nameof(GetMessageTypes);
            List<MessageTypeModel> returnData = new();
            Status Status = new();

            try
            {
                IQueryable<MessageType> Data = _UnitOfWork.MessageType.GetQuery(a => (string.IsNullOrEmpty(Search) ||
                                                                                      a.Name.ToLower().Contains(Search.ToLower())));

                Data = OrderBy<MessageType>.OrderData(Data, paging.OrderBy);

                PagedList<MessageType> PagedData = PagedList<MessageType>.Create(Data, paging.PageNumber, paging.PageSize);

                if (Culture.ToLower() == "en")
                {
                    PagedData = _UnitOfWork.MessageType.GetLang(PagedData);
                }

                _Mapper.Map(PagedData, returnData);

                Response.Headers.Add("X-Pagination", StatusHandler<MessageType>.GetPagination(PagedData, paging, ActionName));

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
        /// Get: Get Message States
        /// </summary>
        [HttpGet]
        [Route(nameof(GetMessageStates))]
        public List<MessageStateModel> GetMessageStates(
            [FromQuery] string Culture,
            [FromQuery] string Search,
            [FromQuery] Paging paging)
        {
            string ActionName = nameof(GetMessageStates);
            List<MessageStateModel> returnData = new();
            Status Status = new();

            try
            {
                IQueryable<MessageState> Data = _UnitOfWork.MessageState.GetQuery(a => (string.IsNullOrEmpty(Search) ||
                                                                            a.Name.ToLower().Contains(Search.ToLower())));

                Data = OrderBy<MessageState>.OrderData(Data, paging.OrderBy);

                PagedList<MessageState> PagedData = PagedList<MessageState>.Create(Data, paging.PageNumber, paging.PageSize);

                if (Culture.ToLower() == "en")
                {
                    PagedData = _UnitOfWork.MessageState.GetLang(PagedData);
                }

                _Mapper.Map(PagedData, returnData);

                Response.Headers.Add("X-Pagination", StatusHandler<MessageState>.GetPagination(PagedData, paging, ActionName));

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
