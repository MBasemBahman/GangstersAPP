namespace EConnectSocialMedia.API.Controllers.GroupEntity
{
    [Authorize]
    [ApiController]
    [Produces("application/json")]
    [ApiExplorerSettings(GroupName = "Group")]
    [Route("api/v{version:apiVersion}/GroupEntity/[controller]")]
    [ApiVersion("1.0")]
    public class GroupController : Controller
    {
        private readonly DatabaseContext _DBContext;
        private readonly UnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;
        private readonly EntityLocalizationService _Localizer;
        private readonly IAccountService _AccountService;
        private readonly StatusHandler _StatusHandler;
        private readonly IWebHostEnvironment _Environment;
        private readonly AppSettings _appSettings;

        public GroupController(
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

        #region Get
        /// <summary>
        /// Get: Get All Groups
        /// </summary>
        [HttpGet]
        [Route(nameof(GetGroups))]
        public List<GroupModel> GetGroups(
            [FromQuery] string Culture,
            [FromQuery] string Search,
            [FromQuery] Paging paging,
            [FromQuery] int Fk_GroupType = 0)
        {
            string ActionName = nameof(GetGroups);
            List<GroupModel> returnData = new();
            Status Status = new();

            try
            {
                AuthorizedAccount account = (AuthorizedAccount)Request.HttpContext.Items["Account"];

                IQueryable<GroupModel> Data = _UnitOfWork.Group.GetGroups(a => a.GroupMembers.Any(b => b.Fk_Account == account.Id)
                                                           && (Fk_GroupType == 0 || a.Fk_GroupType == Fk_GroupType)
                                                           && (string.IsNullOrEmpty(Search) || a.Name.ToLower().Contains(Search.ToLower())));

                Data = OrderBy<GroupModel>.OrderData(Data, paging.OrderBy);

                PagedList<GroupModel> PagedData = PagedList<GroupModel>.Create(Data, paging.PageNumber, paging.PageSize);

                returnData = PagedData;

                Response.Headers.Add("X-Pagination", StatusHandler<GroupModel>.GetPagination(PagedData, paging, ActionName));

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
        /// Get: Get Group
        /// </summary>
        [HttpGet]
        [Route(nameof(GetGroup))]
        public GroupModel GetGroup(
            [FromQuery] string Culture,
            [FromQuery] int id)
        {
            GroupModel returnData = new();
            Status Status = new();

            try
            {
                AuthorizedAccount account = (AuthorizedAccount)Request.HttpContext.Items["Account"];

                GroupModel Data = _UnitOfWork.Group.GetGroups(a => a.Id == id).First();

                returnData = Data;

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
        /// Get: Get Group Members
        /// </summary>
        [HttpGet]
        [Route(nameof(GetGroupMembers))]
        public List<GroupMemberModel> GetGroupMembers(
            [FromQuery] string Culture,
            [FromQuery] string Search,
            [FromQuery] int Fk_Group,
            [FromQuery] Paging paging)
        {
            string ActionName = nameof(GetGroupMembers);
            List<GroupMemberModel> returnData = new();
            Status Status = new();

            try
            {
                AuthorizedAccount account = (AuthorizedAccount)Request.HttpContext.Items["Account"];

                IQueryable<GroupMemberModel> Data = _UnitOfWork.GroupMember.GetMembers(a => a.Fk_Group == Fk_Group && a.Group.GroupMembers.Any(b => b.Fk_Account == account.Id));

                Data = OrderBy<GroupMemberModel>.OrderData(Data, paging.OrderBy);

                PagedList<GroupMemberModel> PagedData = PagedList<GroupMemberModel>.Create(Data, paging.PageNumber, paging.PageSize);

                returnData = PagedData;

                Response.Headers.Add("X-Pagination", StatusHandler<GroupMemberModel>.GetPagination(PagedData, paging, ActionName));

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
        /// Post: Create Group
        /// </summary>
        [HttpPost]
        [Route(nameof(CreateGroup))]
        public async Task<GroupModel> CreateGroup(
            [FromQuery] string Culture,
            [FromForm] GroupCreateModel model)
        {
            GroupModel returnData = new();
            Status Status = new();

            try
            {
                if (!ModelState.IsValid)
                {
                    throw new AppException("Complete your info!");
                }

                AuthorizedAccount account = (AuthorizedAccount)Request.HttpContext.Items["Account"];

                Group DBData = new();

                _Mapper.Map(model, DBData);

                #region Group Image

                if (model.ImageURL != null)
                {
                    ImgManager ImgManager = new(_Environment.WebRootPath);

                    string FileURL = await ImgManager.UploudImage(_appSettings.DomainName, RandomGenerator.RandomKey(), model.ImageURL, "Uploud/Group");

                    if (!string.IsNullOrEmpty(FileURL))
                    {
                        DBData.ImageURL = FileURL;
                    }
                }
                #endregion

                #region Group Members
                DBData.GroupMembers = new List<GroupMember>
                {
                    new GroupMember
                    {
                        Fk_Account = account.Id,
                        IsAdmin = true,
                        CreatedBy = account.FullName
                    }
                };

                if (model.GroupMembers != null && model.GroupMembers.Any())
                {
                    foreach (int member in model.GroupMembers)
                    {
                        DBData.GroupMembers.Add(new GroupMember
                        {
                            Fk_Account = member,
                            CreatedBy = account.FullName
                        });
                    }
                }
                #endregion

                DBData.CreatedBy = account.FullName;

                _UnitOfWork.Group.CreateEntity(DBData);

                await _UnitOfWork.Save();

                returnData = _UnitOfWork.Group.GetGroups(a => a.Id == DBData.Id).First();

                Status = new Status(true);

                await SendGroupNotification(account, DBData.Id, model.GroupMembers);
            }
            catch (Exception ex)
            {
                Status = _StatusHandler.SetException(Status, ex);
            }

            Response.Headers.Add("X-Status", _StatusHandler.GetStatus(Status));

            return returnData;
        }

        /// <summary>
        /// Put: Edit Group
        /// </summary>
        [HttpPut]
        [Route(nameof(EditGroup))]
        public async Task<GroupModel> EditGroup(
            [FromQuery] string Culture,
            [FromQuery] int Id,
            [FromForm] GroupEditModel model)
        {
            GroupModel returnData = new();
            Status Status = new();

            try
            {
                if (!ModelState.IsValid)
                {
                    throw new AppException("Complete your info!");
                }

                AuthorizedAccount account = (AuthorizedAccount)Request.HttpContext.Items["Account"];

                if (!_UnitOfWork.Group.Any(a => a.Id == Id && a.GroupMembers.Any(a => a.Fk_Account == account.Id && a.IsAdmin)))
                {
                    throw new AppException("Not Auth!");
                }

                Group DBData = await _UnitOfWork.Group.GetByID(Id);

                _Mapper.Map(model, DBData);

                #region Group Image

                if (model.ImageURL != null)
                {
                    ImgManager ImgManager = new(_Environment.WebRootPath);

                    string FileURL = await ImgManager.UploudImage(_appSettings.DomainName, RandomGenerator.RandomKey(), model.ImageURL, "Uploud/Group");

                    if (!string.IsNullOrEmpty(FileURL))
                    {
                        DBData.ImageURL = FileURL;
                    }

                }
                #endregion

                DBData.LastModifiedBy = account.FullName;

                _UnitOfWork.Group.UpdateEntity(DBData);

                await _UnitOfWork.Save();

                returnData = _UnitOfWork.Group.GetGroups(a => a.Id == Id).First();

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
        /// Post: Add Group Members
        /// </summary>
        [HttpPost]
        [Route(nameof(AddGroupMembers))]
        public async Task<bool> AddGroupMembers(
            [FromQuery] string Culture,
            [FromQuery] int Fk_Group,
            [FromBody] List<GroupMemberCreateModel> model)
        {
            bool returnData = false;
            Status Status = new();

            try
            {
                AuthorizedAccount account = (AuthorizedAccount)Request.HttpContext.Items["Account"];

                if (!_UnitOfWork.Group.Any(a => a.Id == Fk_Group && a.GroupMembers.Any(a => a.Fk_Account == account.Id && a.IsAdmin)))
                {
                    throw new AppException("Not Auth!");
                }

                foreach (GroupMemberCreateModel member in model)
                {
                    _UnitOfWork.GroupMember.CreateEntity(new GroupMember
                    {
                        Fk_Account = member.Fk_Account,
                        IsAdmin = member.IsAdmin,
                        Fk_Group = Fk_Group,
                        CreatedBy = account.FullName
                    });
                }

                await _UnitOfWork.Save();

                returnData = true;

                Status = new Status(true);

                await SendGroupNotification(account, Fk_Group, model.Select(a => a.Fk_Account).ToList());

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
        /// Delete: Remove Group Members
        /// </summary>
        [HttpDelete]
        [Route(nameof(RemoveGroupMembers))]
        public async Task<bool> RemoveGroupMembers(
            [FromQuery] string Culture,
            [FromQuery] int Fk_Group,
            [FromBody] List<GroupMemberRemoveModel> Fk_Accounts)
        {
            bool returnData = false;
            Status Status = new();

            try
            {
                AuthorizedAccount account = (AuthorizedAccount)Request.HttpContext.Items["Account"];

                if (!_UnitOfWork.Group.Any(a => a.Id == Fk_Group && a.GroupMembers.Any(a => a.Fk_Account == account.Id && a.IsAdmin)))
                {
                    throw new AppException("Not Auth!");
                }

                _UnitOfWork.GroupMember
                           .DeleteEntity(await _UnitOfWork.GroupMember
                                                          .GetAll(a => a.Fk_Group == Fk_Group &&
                                                                       Fk_Accounts.Select(b => b.Fk_Account)
                                                                                  .Contains(a.Fk_Account)));

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
        /// Delete: Remove Group
        /// </summary>
        [HttpDelete]
        [Route(nameof(RemoveGroup))]
        public async Task<bool> RemoveGroup(
            [FromQuery] string Culture,
            [FromQuery] int Id)
        {
            bool returnData = false;
            Status Status = new();

            try
            {
                AuthorizedAccount account = (AuthorizedAccount)Request.HttpContext.Items["Account"];

                if (!_UnitOfWork.Group.Any(a => a.Id == Id && a.GroupMembers.Any(a => a.Fk_Account == account.Id && a.IsAdmin)))
                {
                    throw new AppException("Not Auth!");
                }

                if (_UnitOfWork.Group.Any(a => a.Id == Id && a.Posts.Any()))
                {
                    throw new AppException("Have Posts, Can't Remove!");
                }

                Group Data = await _UnitOfWork.Group.GetByID(Id);

                if (!string.IsNullOrEmpty(Data.ImageURL))
                {
                    ImgManager ImgManager = new(_Environment.WebRootPath);

                    ImgManager.DeleteImage(Data.ImageURL, _appSettings.DomainName);

                }

                _UnitOfWork.Group.DeleteEntity(Data);

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

        // helper method
        private async Task SendGroupNotification(AuthorizedAccount account, int id, List<int> members)
        {
            Notification notification = new()
            {
                Title = _Localizer.Get("New group!"),
                Description = account.FullName + _Localizer.Get(" added you in group!"),
                IsPublic = false,
                IsActive = true,
                OpenType = OpenTypeEnum.Group,
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
