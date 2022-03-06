namespace EConnectSocialMedia.API.Controllers.ChatEntity
{
    [Authorize]
    [ApiController]
    [Produces("application/json")]
    [ApiExplorerSettings(GroupName = "Chat")]
    [Route("api/v{version:apiVersion}/ChatEntity/[controller]")]
    [ApiVersion("1.0")]
    public class ChatController : Controller
    {
        private readonly DatabaseContext _DBContext;
        private readonly UnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;
        private readonly EntityLocalizationService _Localizer;
        private readonly IAccountService _AccountService;
        private readonly StatusHandler _StatusHandler;
        private readonly IWebHostEnvironment _Environment;
        private readonly AppSettings _appSettings;
        private readonly IHubContext<ChatHub> _hub;

        public ChatController(
            DatabaseContext dataContext,
            UnitOfWork unitOfWork,
            IMapper mapper,
            EntityLocalizationService Localizer,
            IAccountService AccountService,
            IWebHostEnvironment environment,
            IOptions<AppSettings> appSettings,
            IHubContext<ChatHub> hub)
        {
            _DBContext = dataContext;
            _UnitOfWork = unitOfWork;
            _Mapper = mapper;
            _Localizer = Localizer;
            _AccountService = AccountService;
            _Environment = environment;
            _appSettings = appSettings.Value;
            _StatusHandler = new StatusHandler(Localizer);
            _hub = hub;
        }

        #region Get
        /// <summary>
        /// Get: Get All Chats
        /// </summary>
        [HttpGet]
        [Route(nameof(GetChats))]
        public List<ChatModel> GetChats(
            [FromQuery] string Culture,
            [FromQuery] string Search,
            [FromQuery] Paging paging,
            [FromQuery] int Fk_ChatType = 0)
        {
            string ActionName = nameof(GetChats);
            List<ChatModel> returnData = new();
            Status Status = new();

            try
            {
                AuthorizedAccount account = (AuthorizedAccount)Request.HttpContext.Items["Account"];

                IQueryable<ChatModel> Data = _UnitOfWork.Chat.GetChats(a =>
                                                             a.ChatMembers.Any(b => b.Fk_Account == account.Id)
                                                          && a.Messages.Any()
                                                          && (Fk_ChatType == 0 || a.Fk_ChatType == Fk_ChatType)
                                                          && (string.IsNullOrEmpty(Search) || a.Name.ToLower().Contains(Search.ToLower())),
                                                          account.Id);

                Data = OrderBy<ChatModel>.OrderData(Data, paging.OrderBy);

                PagedList<ChatModel> PagedData = PagedList<ChatModel>.Create(Data, paging.PageNumber, paging.PageSize);

                PagedData.ForEach(chat =>
                {
                    chat = _UnitOfWork.Chat.GetChatExtraData(chat, account.Id);
                    chat.LastMessage = chat.MessagesCount > 0 ? _UnitOfWork.Message.GetMessages(a => a.Fk_Chat == chat.Id, account.Id).First() : null;
                });

                returnData = PagedData;

                Response.Headers.Add("X-Pagination", StatusHandler<ChatModel>.GetPagination(PagedData, paging, ActionName));

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
        /// Get: Get Chat Members
        /// </summary>
        [HttpGet]
        [Route(nameof(GetChatMembers))]
        public List<ChatMemberModel> GetChatMembers(
            [FromQuery] string Culture,
            [FromQuery] string Search,
            [FromQuery] int Fk_Chat,
            [FromQuery] Paging paging)
        {
            string ActionName = nameof(GetChatMembers);
            List<ChatMemberModel> returnData = new();
            Status Status = new();

            try
            {
                AuthorizedAccount account = (AuthorizedAccount)Request.HttpContext.Items["Account"];

                IQueryable<ChatMemberModel> Data = _UnitOfWork.ChatMember.GetMembers(a => a.Fk_Chat == Fk_Chat && a.Chat.ChatMembers.Any(b => b.Fk_Account == account.Id));

                Data = OrderBy<ChatMemberModel>.OrderData(Data, paging.OrderBy);

                PagedList<ChatMemberModel> PagedData = PagedList<ChatMemberModel>.Create(Data, paging.PageNumber, paging.PageSize);

                returnData = PagedData;

                Response.Headers.Add("X-Pagination", StatusHandler<ChatMemberModel>.GetPagination(PagedData, paging, ActionName));

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
        /// Get: Get Messages
        /// </summary>
        [HttpGet]
        [Route(nameof(GetMessages))]
        public List<MessageModel> GetMessages(
            [FromQuery] string Culture,
            [FromQuery] string Search,
            [FromQuery] Paging paging,
            [FromQuery] int Fk_Chat = 0,
            [FromQuery] int Fk_Account = 0)
        {
            string ActionName = nameof(GetMessages);
            List<MessageModel> returnData = new();
            Status Status = new();

            try
            {
                if (Fk_Account == 0 && Fk_Chat == 0)
                {
                    throw new Exception("Invalid request");
                }

                AuthorizedAccount account = (AuthorizedAccount)Request.HttpContext.Items["Account"];

                IQueryable<MessageModel> Data = _UnitOfWork.Message.GetMessages(a => (Fk_Chat == 0 || a.Fk_Chat == Fk_Chat) &&
                                                                                     (Fk_Account == 0 || a.Fk_Account == Fk_Account) &&
                                                                                     a.Chat.ChatMembers.Any(b => b.Fk_Account == account.Id)
                                                                                     && (string.IsNullOrEmpty(Search) || a.MessageText.ToLower().Contains(Search.ToLower())),
                                                                                     account.Id);

                Data = OrderBy<MessageModel>.OrderData(Data, paging.OrderBy);

                PagedList<MessageModel> PagedData = PagedList<MessageModel>.Create(Data, paging.PageNumber, paging.PageSize);

                returnData = PagedData;

                Response.Headers.Add("X-Pagination", StatusHandler<MessageModel>.GetPagination(PagedData, paging, ActionName));

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
        /// Get: Get UnRead Count
        /// </summary>
        [HttpGet]
        [Route(nameof(GetUnReadCount))]
        public int GetUnReadCount(
            [FromQuery] string Culture)
        {
            int returnData = 0;
            Status Status = new();

            try
            {
                AuthorizedAccount account = (AuthorizedAccount)Request.HttpContext.Items["Account"];

                returnData = _UnitOfWork.Chat.Count(a => a.ChatMembers.Any(b => b.Fk_Account == account.Id) &&
                                                         a.Messages.Any(b => b.Fk_MessageState != (int)MessageStateEnum.Readed));

                Status = new Status(true);
            }
            catch (Exception ex)
            {
                Status = _StatusHandler.SetException(Status, ex);
            }

            Response.Headers.Add("X-Status", _StatusHandler.GetStatus(Status));

            return returnData;
        }
        #endregion

        #region Create/Edit

        /// <summary>
        /// Post: Create Chat
        /// </summary>
        [HttpPost]
        [Route(nameof(CreateChat))]
        public async Task<ChatModel> CreateChat(
            [FromQuery] string Culture,
            [FromForm] ChatCreateModel model)
        {
            ChatModel returnData = new();
            Status Status = new();

            try
            {
                if (!ModelState.IsValid)
                {
                    throw new AppException("Complete your info!");
                }

                AuthorizedAccount account = (AuthorizedAccount)Request.HttpContext.Items["Account"];

                int id = 0;
                bool sendNotification = false;

                if (model.Fk_ChatType == (int)ChatTypeEnum.Private &&
                    _UnitOfWork.Chat.Any(a => a.Fk_ChatType == (int)ChatTypeEnum.Private &&
                                              a.ChatMembers.Any(b => b.Fk_Account == model.ChatMembers.First()) &&
                                              a.ChatMembers.Any(b => b.Fk_Account == account.Id)))
                {
                    id = _UnitOfWork.Chat.GetQuery(a => a.Fk_ChatType == (int)ChatTypeEnum.Private &&
                                                   a.ChatMembers.Any(b => b.Fk_Account == model.ChatMembers.First()) &&
                                                   a.ChatMembers.Any(b => b.Fk_Account == account.Id))
                                         .Select(a => a.Id)
                                         .First();
                }
                else
                {

                    Chat DBData = new();

                    _Mapper.Map(model, DBData);

                    #region Chat Members
                    DBData.ChatMembers = new List<ChatMember>
                    {
                        new ChatMember
                        {
                            Fk_Account = account.Id,
                            IsAdmin = true,
                            CreatedBy = account.FullName
                        }
                    };

                    if (model.ChatMembers != null && model.ChatMembers.Any())
                    {
                        foreach (int member in model.ChatMembers)
                        {
                            DBData.ChatMembers.Add(new ChatMember
                            {
                                Fk_Account = member,
                                CreatedBy = account.FullName
                            });
                        }
                    }
                    #endregion

                    DBData.CreatedBy = account.FullName;

                    if (model.ImageFile != null)
                    {
                        ImgManager ImgManager = new(_Environment.WebRootPath);

                        string FileURL = await ImgManager.UploudImage(_appSettings.DomainName, account.Id.ToString(), model.ImageFile, "Uploud/Chat");

                        if (!string.IsNullOrEmpty(FileURL))
                        {
                            DBData.ImageURL = FileURL;
                        }
                    }

                    _UnitOfWork.Chat.CreateEntity(DBData);

                    await _UnitOfWork.Save();

                    id = DBData.Id;
                    sendNotification = true;
                }

                returnData = _UnitOfWork.Chat.GetChats(a => a.Id == id, account.Id).First();

                returnData = _UnitOfWork.Chat.GetChatExtraData(returnData, account.Id);
                returnData.LastMessage = returnData.MessagesCount > 0 ? _UnitOfWork.Message.GetMessages(a => a.Fk_Chat == returnData.Id, account.Id).First() : null;

                Status = new Status(true);

                if (sendNotification)
                {
                    await SendChatNotification(account, id, model.ChatMembers.ToList());
                }
            }
            catch (Exception ex)
            {
                Status = _StatusHandler.SetException(Status, ex);
            }

            Response.Headers.Add("X-Status", _StatusHandler.GetStatus(Status));

            return returnData;
        }

        /// <summary>
        /// Put: Edit Chat
        /// </summary>
        [HttpPut]
        [Route(nameof(EditChat))]
        public async Task<ChatModel> EditChat(
            [FromQuery] string Culture,
            [FromQuery] int Id,
            [FromForm] ChatEditModel model)
        {
            ChatModel returnData = new();
            Status Status = new();

            try
            {
                if (!ModelState.IsValid)
                {
                    throw new AppException("Complete your info!");
                }

                AuthorizedAccount account = (AuthorizedAccount)Request.HttpContext.Items["Account"];

                Chat DBData = await _UnitOfWork.Chat.GetByID(Id);

                if (DBData != null)
                {
                    _Mapper.Map(model, DBData);

                    DBData.LastModifiedBy = account.FullName;

                    if (model.ImageFile != null)
                    {
                        ImgManager ImgManager = new(_Environment.WebRootPath);

                        string FileURL = await ImgManager.UploudImage(_appSettings.DomainName, account.Id.ToString(), model.ImageFile, "Uploud/Chat");

                        if (!string.IsNullOrEmpty(FileURL))
                        {
                            DBData.ImageURL = FileURL;
                        }
                    }

                    _UnitOfWork.Chat.UpdateEntity(DBData);

                    await _UnitOfWork.Save();

                    returnData = _UnitOfWork.Chat.GetChats(a => a.Id == DBData.Id, account.Id).First();
                    returnData = _UnitOfWork.Chat.GetChatExtraData(returnData, account.Id);
                    returnData.LastMessage = returnData.MessagesCount > 0 ? _UnitOfWork.Message.GetMessages(a => a.Fk_Chat == returnData.Id, account.Id).First() : null;

                    Status = new Status(true);
                }
            }
            catch (Exception ex)
            {
                Status = _StatusHandler.SetException(Status, ex);
            }

            Response.Headers.Add("X-Status", _StatusHandler.GetStatus(Status));

            return returnData;
        }

        /// <summary>
        /// Post: Add Chat Members
        /// </summary>
        [HttpPost]
        [Route(nameof(AddChatMembers))]
        public async Task<bool> AddChatMembers(
            [FromQuery] string Culture,
            [FromQuery] int Fk_Chat,
            [FromBody] List<ChatMemberCreateModel> model)
        {
            bool returnData = false;
            Status Status = new();

            try
            {
                AuthorizedAccount account = (AuthorizedAccount)Request.HttpContext.Items["Account"];

                if (!_UnitOfWork.Chat.Any(a => a.Id == Fk_Chat && a.ChatMembers.Any(a => a.Fk_Account == account.Id && a.IsAdmin)))
                {
                    throw new AppException("Not Auth!");
                }

                foreach (ChatMemberCreateModel member in model)
                {
                    _UnitOfWork.ChatMember.CreateEntity(new ChatMember
                    {
                        Fk_Account = member.Fk_Account,
                        IsAdmin = member.IsAdmin,
                        Fk_Chat = Fk_Chat,
                        CreatedBy = account.FullName
                    });
                }

                await _UnitOfWork.Save();

                foreach (ChatMemberCreateModel ChatMember in model)
                {
                    await _hub.Groups.AddToGroupAsync(ChatMember.ConnectionId, Fk_Chat.ToString());

                    string Message = $"{ChatMember.ConnectionId} Join Room {Fk_Chat}";

                    await _hub.Clients.Group(Fk_Chat.ToString()).SendAsync("RoomState", ChatMember.ConnectionId, Message);
                }

                returnData = true;

                Status = new Status(true);

                await SendChatNotification(account, Fk_Chat, model.Select(a => a.Fk_Account).ToList());
            }
            catch (Exception ex)
            {
                Status = _StatusHandler.SetException(Status, ex);
            }

            Response.Headers.Add("X-Status", _StatusHandler.GetStatus(Status));

            return returnData;
        }

        /// <summary>
        /// Post: Create Message
        /// </summary>
        [HttpPost]
        [Route(nameof(CreateMessage))]
        public async Task<MessageModel> CreateMessage(
            [FromQuery] string Culture,
            [FromForm] MessageCreateModel model)
        {
            MessageModel returnData = new();
            Status Status = new();

            try
            {
                if (!ModelState.IsValid)
                {
                    throw new AppException("Complete your info!");
                }

                AuthorizedAccount account = (AuthorizedAccount)Request.HttpContext.Items["Account"];

                if (!_UnitOfWork.ChatMember.Any(a => a.Fk_Chat == model.Fk_Chat && a.Fk_Account == account.Id))
                {
                    throw new AppException("Not Auth!");
                }

                Message DBData = new();

                _Mapper.Map(model, DBData);

                DBData.CreatedBy = account.FullName;
                DBData.Fk_Account = account.Id;

                #region Message Attachment

                if (model.FileURL != null)
                {
                    ImgManager ImgManager = new(_Environment.WebRootPath);

                    string FileURL = await ImgManager.UploudImage(_appSettings.DomainName, RandomGenerator.RandomKey(), model.FileURL, "Uploud/Message");

                    if (!string.IsNullOrEmpty(FileURL))
                    {
                        DBData.FileURL = FileURL;
                        DBData.FileLength = model.FileURL.Length;
                        DBData.FileType = model.FileURL.ContentType;
                        DBData.FileName = model.FileURL.FileName;
                    }
                }
                #endregion

                _UnitOfWork.Message.CreateEntity(DBData);

                await _UnitOfWork.Save();

                await _UnitOfWork.Chat.UpdateLastActionAt(DBData.Fk_Chat);

                returnData = _UnitOfWork.Message.GetMessages(a => a.Id == DBData.Id, account.Id).First();

                await _hub.Clients.Group(DBData.Fk_Chat.ToString()).SendAsync("ReceiveMessage", returnData);

                Status = new Status(true);

                List<int> members = _UnitOfWork.ChatMember.GetQuery(a => a.Fk_Chat == model.Fk_Chat &&
                                                                         a.Fk_Account != account.Id)
                                               .Select(a => a.Fk_Account)
                                               .ToList();

                await SendMessageNotification(account, model.Fk_Chat, members);
            }
            catch (Exception ex)
            {
                Status = _StatusHandler.SetException(Status, ex);
            }

            Response.Headers.Add("X-Status", _StatusHandler.GetStatus(Status));

            return returnData;
        }

        /// <summary>
        /// Put: Edit Message
        /// </summary>
        [HttpPut]
        [Route(nameof(EditMessage))]
        public async Task<MessageModel> EditMessage(
            [FromQuery] string Culture,
            [FromQuery] int Id,
            [FromBody] MessageEditModel model)
        {
            MessageModel returnData = new();
            Status Status = new();

            try
            {
                if (!ModelState.IsValid)
                {
                    throw new AppException("Complete your info!");
                }

                AuthorizedAccount account = (AuthorizedAccount)Request.HttpContext.Items["Account"];

                Message DBData = await _UnitOfWork.Message.GetByID(Id);

                if (DBData != null)
                {
                    DBData.Fk_MessageState = model.Fk_MessageState;

                    DBData.LastModifiedBy = account.FullName;

                    _UnitOfWork.Message.UpdateEntity(DBData);

                    await _UnitOfWork.Save();

                    returnData = _UnitOfWork.Message.GetMessages(a => a.Id == DBData.Id, account.Id).First();

                    await _hub.Clients.Group(DBData.Fk_Chat.ToString()).SendAsync("ChangeMessageState", returnData);

                    Status = new Status(true);
                }
            }
            catch (Exception ex)
            {
                Status = _StatusHandler.SetException(Status, ex);
            }

            Response.Headers.Add("X-Status", _StatusHandler.GetStatus(Status));

            return returnData;
        }
        #endregion

        #region Delete

        /// <summary>
        /// Delete: Remove Chat Members
        /// </summary>
        [HttpDelete]
        [Route(nameof(RemoveChatMembers))]
        public async Task<bool> RemoveChatMembers(
            [FromQuery] string Culture,
            [FromQuery] int Fk_Chat,
            [FromBody] List<ChatMemberRemoveModel> model)
        {
            bool returnData = false;
            Status Status = new();

            try
            {
                AuthorizedAccount account = (AuthorizedAccount)Request.HttpContext.Items["Account"];

                if (!_UnitOfWork.Chat.Any(a => a.Id == Fk_Chat && a.ChatMembers.Any(a => a.Fk_Account == account.Id && a.IsAdmin)))
                {
                    throw new AppException("Not Auth!");
                }

                _UnitOfWork.ChatMember
                               .DeleteEntity(await _UnitOfWork.ChatMember
                                                              .GetAll(a => a.Fk_Chat == Fk_Chat && model.Select(b => b.Fk_Account).Contains(a.Fk_Account)));

                await _UnitOfWork.Save();

                foreach (ChatMemberRemoveModel ChatMember in model)
                {
                    await _hub.Groups.RemoveFromGroupAsync(ChatMember.ConnectionId, Fk_Chat.ToString());

                    string Message = $"{ChatMember.ConnectionId} Exit Room {Fk_Chat.ToString()}";

                    await _hub.Clients.Group(Fk_Chat.ToString()).SendAsync("RoomState", ChatMember.ConnectionId, Message);
                }

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


        /// <summary>
        /// Delete: Remove Message
        /// </summary>
        [HttpDelete]
        [Route(nameof(RemoveMessage))]
        public async Task<bool> RemoveMessage(
            [FromQuery] string Culture,
            [FromQuery] int Id)
        {
            bool returnData = false;
            Status Status = new();

            try
            {
                AuthorizedAccount account = (AuthorizedAccount)Request.HttpContext.Items["Account"];

                if (!_UnitOfWork.Message.Any(a => a.Id == Id && a.Fk_Account == account.Id))
                {
                    throw new AppException("Not Auth!");
                }

                Message Data = await _UnitOfWork.Message.GetFirst(a => a.Id == Id);

                if (!string.IsNullOrEmpty(Data.FileURL))
                {
                    ImgManager ImgManager = new(_Environment.WebRootPath);

                    ImgManager.DeleteImage(Data.FileURL, _appSettings.DomainName);

                }

                _UnitOfWork.Message.DeleteEntity(Data);

                await _UnitOfWork.Save();

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

        /// <summary>
        /// Delete: Remove Chat
        /// </summary>
        [HttpDelete]
        [Route(nameof(RemoveChat))]
        public async Task<bool> RemoveChat(
            [FromQuery] string Culture,
            [FromQuery] int Id)
        {
            bool returnData = false;
            Status Status = new();

            try
            {
                AuthorizedAccount account = (AuthorizedAccount)Request.HttpContext.Items["Account"];

                if (!_UnitOfWork.Chat.Any(a => a.Id == Id && a.ChatMembers.Any(a => a.Fk_Account == account.Id && a.IsAdmin)))
                {
                    throw new AppException("Not Auth!");
                }

                _UnitOfWork.Chat.DeleteEntity(await _UnitOfWork.Chat.GetByID(Id));

                await _UnitOfWork.Save();

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
        #endregion

        // helper methods
        private async Task SendChatNotification(AuthorizedAccount account, int id, List<int> members)
        {
            Notification notification = new()
            {
                Title = _Localizer.Get("New chat!"),
                Description = account.FullName + _Localizer.Get(" added you in chat!"),
                IsPublic = false,
                IsActive = true,
                OpenType = OpenTypeEnum.Chat,
                OpenValue = id.ToString(),
                ImageURL = account.ImageURL,
                NotificationAccounts = new List<NotificationAccount>()
            };

            foreach (int fk_Account in members.Where(a => a != account.Id))
            {
                notification.NotificationAccounts.Add(new NotificationAccount()
                {
                    Fk_Account = fk_Account,
                });
            }

            _UnitOfWork.Notification.CreateEntity(notification);
            await _UnitOfWork.Save();

            await _UnitOfWork.Notification.SendNotification(notification);
        }

        private async Task SendMessageNotification(AuthorizedAccount account, int id, List<int> members)
        {
            Notification notification = new()
            {
                Title = _Localizer.Get("New message!"),
                Description = _Localizer.Get("You have unread message from !") + account.FullName,
                IsPublic = false,
                IsActive = true,
                OpenType = OpenTypeEnum.Message,
                OpenValue = id.ToString(),
                ImageURL = account.ImageURL,
                NotificationAccounts = new List<NotificationAccount>()
            };

            foreach (int fk_Account in members.Where(a => a != account.Id))
            {
                notification.NotificationAccounts.Add(new NotificationAccount()
                {
                    Fk_Account = fk_Account,
                });
            }

            _UnitOfWork.Notification.CreateEntity(notification);
            await _UnitOfWork.Save();

            await _UnitOfWork.Notification.SendNotification(notification);
        }
    }
}