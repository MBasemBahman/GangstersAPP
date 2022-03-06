namespace EConnectSocialMedia.API.Controllers.PostEntity
{
    [Authorize]
    [ApiController]
    [Produces("application/json")]
    [ApiExplorerSettings(GroupName = "Post")]
    [Route("api/v{version:apiVersion}/PostEntity/[controller]")]
    [ApiVersion("1.0")]
    public class PostController : ControllerBase
    {
        private readonly DatabaseContext _DBContext;
        private readonly UnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;
        private readonly EntityLocalizationService _Localizer;
        private readonly IAccountService _AccountService;
        private readonly StatusHandler _StatusHandler;
        private readonly IWebHostEnvironment _Environment;
        private readonly AppSettings _appSettings;

        public PostController(
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
        /// Get: Get All Posts
        /// </summary>
        [HttpGet]
        [Route(nameof(GetPosts))]
        public List<PostModel> GetPosts(
            [FromQuery] string Culture,
            [FromQuery] string Search,
            [FromQuery] Paging paging,
            [FromQuery] int Fk_Account = 0,
            [FromQuery] int Fk_PostType = 0,
            [FromQuery] int Fk_Group = 0,
            [FromQuery] int Fk_OldPost = 0)
        {
            string ActionName = nameof(GetPosts);
            List<PostModel> returnData = new();
            Status Status = new();

            try
            {
                AuthorizedAccount account = (AuthorizedAccount)Request.HttpContext.Items["Account"];

                IQueryable<PostModel> Data = _UnitOfWork.Post.GetPosts(a => (string.IsNullOrEmpty(Search) ||
                                                                             a.PostTitle.ToLower().Contains(Search.ToLower()) ||
                                                                             a.PostText.ToLower().Contains(Search.ToLower())) &&
                                                                            (Fk_Account == 0 || a.Fk_Account == Fk_Account) &&
                                                                            (Fk_PostType == 0 || a.Fk_PostType == Fk_PostType) &&
                                                                            (Fk_OldPost == 0 || a.Fk_OldPost == Fk_OldPost) &&
                                                                            (Fk_Group == 0 ? a.Fk_Group == null : (a.Fk_Group == Fk_Group && a.Group.GroupMembers.Any(b => b.Fk_Account == account.Id))),
                                                                            account.Id, Culture);

                Data = OrderBy<PostModel>.OrderData(Data, paging.OrderBy);

                PagedList<PostModel> PagedData = PagedList<PostModel>.Create(Data, paging.PageNumber, paging.PageSize);

                returnData = PagedData;

                Response.Headers.Add("X-Pagination", StatusHandler<PostModel>.GetPagination(PagedData, paging, ActionName));

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
        /// Get: Get Post
        /// </summary>
        [HttpGet]
        [Route(nameof(GetPost))]
        public PostModel GetPost(
            [FromQuery] string Culture,
            [FromQuery] int id)
        {
            PostModel returnData = new();
            Status Status = new();

            try
            {
                AuthorizedAccount account = (AuthorizedAccount)Request.HttpContext.Items["Account"];

                IQueryable<PostModel> Data = _UnitOfWork.Post.GetPosts(a => a.Id == id, account.Id, Culture);

                returnData = Data.FirstOrDefault();

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
        /// Get: Get Post Attachments
        /// </summary>
        [HttpGet]
        [Route(nameof(GetPostAttachments))]
        public List<PostAttachmentModel> GetPostAttachments(
            [FromQuery] string Culture,
            [FromQuery] Paging paging,
            [FromQuery] int Fk_Post)
        {
            string ActionName = nameof(GetPostAttachments);
            List<PostAttachmentModel> returnData = new();
            Status Status = new();

            try
            {
                IQueryable<PostAttachment> Data = _UnitOfWork.PostAttachment.GetQuery(a => a.Fk_Post == Fk_Post);

                Data = OrderBy<PostAttachment>.OrderData(Data, paging.OrderBy);

                PagedList<PostAttachment> PagedData = PagedList<PostAttachment>.Create(Data, paging.PageNumber, paging.PageSize);

                _Mapper.Map(PagedData, returnData);

                Response.Headers.Add("X-Pagination", StatusHandler<PostAttachment>.GetPagination(PagedData, paging, ActionName));

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
        /// Get: Get Post Comments
        /// </summary>
        [HttpGet]
        [Route(nameof(GetPostComments))]
        public List<PostCommentModel> GetPostComments(
            [FromQuery] string Culture,
            [FromQuery] string Search,
            [FromQuery] Paging paging,
            [FromQuery] int Fk_Post,
            [FromQuery] int Fk_Account = 0,
            [FromQuery] int Fk_OldPostComment = 0)
        {
            string ActionName = nameof(GetPosts);
            List<PostCommentModel> returnData = new();
            Status Status = new();

            try
            {
                AuthorizedAccount account = (AuthorizedAccount)Request.HttpContext.Items["Account"];

                IQueryable<PostCommentModel> Data = _UnitOfWork.PostComment.GetPostComments(a => (string.IsNullOrEmpty(Search) ||
                                                                                                  a.CommentText.ToLower().Contains(Search.ToLower())) &&
                                                                                                 (Fk_Post == 0 || a.Fk_Post == Fk_Post) &&
                                                                                                 (Fk_Account == 0 || a.Fk_Account == Fk_Account) &&
                                                                                                 (Fk_OldPostComment == 0 ? a.Fk_OldPostComment == null : a.Fk_OldPostComment == Fk_OldPostComment),
                                                                                                 account.Id);

                Data = OrderBy<PostCommentModel>.OrderData(Data, paging.OrderBy);

                PagedList<PostCommentModel> PagedData = PagedList<PostCommentModel>.Create(Data, paging.PageNumber, paging.PageSize);

                returnData = PagedData;

                Response.Headers.Add("X-Pagination", StatusHandler<PostCommentModel>.GetPagination(PagedData, paging, ActionName));

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
        /// Get: Get Post Reactions
        /// </summary>
        [HttpGet]
        [Route(nameof(GetPostReactions))]
        public List<PostReactionModel> GetPostReactions(
            [FromQuery] string Culture,
            [FromQuery] Paging paging,
            [FromQuery] int Fk_Post,
            [FromQuery] int Fk_ReactionType = 0)
        {
            string ActionName = nameof(GetPostReactions);
            List<PostReactionModel> returnData = new();
            Status Status = new();

            try
            {
                IQueryable<PostReaction> Data = _UnitOfWork.PostReaction.GetQuery(a => a.Fk_Post == Fk_Post &&
                                                                                       (Fk_ReactionType == 0 || a.Fk_ReactionType == Fk_ReactionType),
                                                                                       new List<string>
                                                                                       {
                                                                                           "Account"
                                                                                       });

                Data = OrderBy<PostReaction>.OrderData(Data, paging.OrderBy);

                PagedList<PostReaction> PagedData = PagedList<PostReaction>.Create(Data, paging.PageNumber, paging.PageSize);

                foreach (PostReaction PostReaction in PagedData)
                {
                    PostReactionModel postReactionModel = new();

                    _Mapper.Map(PostReaction, postReactionModel);

                    postReactionModel.Account = new AccountModel();
                    _Mapper.Map(PostReaction.Account, postReactionModel.Account);

                    returnData.Add(postReactionModel);
                }

                Response.Headers.Add("X-Pagination", StatusHandler<PostReaction>.GetPagination(PagedData, paging, ActionName));

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
        /// Get: Get Post Comment Reactions
        /// </summary>
        [HttpGet]
        [Route(nameof(GetPostCommentReactions))]
        public List<PostCommentReactionModel> GetPostCommentReactions(
            [FromQuery] string Culture,
            [FromQuery] Paging paging,
            [FromQuery] int Fk_PostComment,
            [FromQuery] int Fk_ReactionType = 0)
        {
            string ActionName = nameof(GetPostCommentReactions);
            List<PostCommentReactionModel> returnData = new();
            Status Status = new();

            try
            {
                IQueryable<PostCommentReaction> Data = _UnitOfWork.PostCommentReaction.GetQuery(a => a.Fk_PostComment == Fk_PostComment &&
                                                                                       (Fk_ReactionType == 0 || a.Fk_ReactionType == Fk_ReactionType),
                                                                                       new List<string>
                                                                                       {
                                                                                           "Account"
                                                                                       });

                Data = OrderBy<PostCommentReaction>.OrderData(Data, paging.OrderBy);

                PagedList<PostCommentReaction> PagedData = PagedList<PostCommentReaction>.Create(Data, paging.PageNumber, paging.PageSize);

                foreach (PostCommentReaction PostReaction in PagedData)
                {
                    PostCommentReactionModel postCommentReactionModel = new();

                    _Mapper.Map(PostReaction, postCommentReactionModel);

                    postCommentReactionModel.Account = new AccountModel();
                    _Mapper.Map(PostReaction.Account, postCommentReactionModel.Account);

                    returnData.Add(postCommentReactionModel);
                }

                Response.Headers.Add("X-Pagination", StatusHandler<PostCommentReaction>.GetPagination(PagedData, paging, ActionName));

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
        /// Post: Create Post
        /// </summary>
        [HttpPost]
        [Route(nameof(CreatePost))]
        public async Task<PostModel> CreatePost(
            [FromQuery] string Culture,
            [FromForm] PostCreateModel model)
        {
            PostModel returnData = new();
            Status Status = new();

            try
            {
                if (!ModelState.IsValid)
                {
                    throw new AppException("Complete your info!");
                }

                AuthorizedAccount account = (AuthorizedAccount)Request.HttpContext.Items["Account"];

                if (model.Fk_Group > 0 && !_UnitOfWork.GroupMember.Any(a => a.Fk_Group == model.Fk_Group && a.Fk_Account == account.Id))
                {
                    throw new AppException("Not Auth");
                }

                Post DBData = new()
                {
                    Fk_Account = account.Id,
                    CreatedBy = account.FullName,
                    Fk_PostState = (int)PostStateEnum.Active
                };

                _Mapper.Map(model, DBData);

                #region Post Attachments

                if (model.PostAttachments != null && model.PostAttachments.Any())
                {
                    DBData.PostAttachments = new List<PostAttachment>();

                    ImgManager ImgManager = new(_Environment.WebRootPath);

                    foreach (IFormFile attachment in model.PostAttachments)
                    {
                        string FileURL = await ImgManager.UploudImage(_appSettings.DomainName, RandomGenerator.RandomKey(), attachment, "Uploud/PostAttachment");
                        if (!string.IsNullOrEmpty(FileURL))
                        {
                            DBData.PostAttachments.Add(new PostAttachment
                            {
                                FileURL = FileURL,
                                FileLength = attachment.Length,
                                FileType = attachment.ContentType,
                                FileName = attachment.FileName,
                                CreatedBy = account.FullName
                            });
                        }
                    }

                }
                #endregion

                DBData = _UnitOfWork.Post.UpdateStateHistory(DBData);

                _UnitOfWork.Post.CreateEntity(DBData);

                await _UnitOfWork.Save();

                returnData = _UnitOfWork.Post.GetPosts(a => a.Id == DBData.Id, null, Culture).First();

                Status = new Status(true);

                await SendPostNotification(account, DBData);
            }
            catch (Exception ex)
            {
                Status = _StatusHandler.SetException(Status, ex);
            }

            Response.Headers.Add("X-Status", _StatusHandler.GetStatus(Status));

            return returnData;
        }

        /// <summary>
        /// Put: Edit Post
        /// </summary>
        [HttpPut]
        [Route(nameof(EditPost))]
        public async Task<PostModel> EditPost(
            [FromQuery] string Culture,
            [FromQuery] int Id,
            [FromBody] PostEditModel model)
        {
            PostModel returnData = new();
            Status Status = new();

            try
            {
                if (!ModelState.IsValid)
                {
                    throw new AppException("Complete your info!");
                }

                AuthorizedAccount account = (AuthorizedAccount)Request.HttpContext.Items["Account"];

                if (!_UnitOfWork.Post.Any(a => a.Id == Id && a.Fk_Account == account.Id))
                {
                    throw new AppException("Not Auth!");
                }

                Post DBData = await _UnitOfWork.Post.GetByID(Id);

                _Mapper.Map(model, DBData);

                DBData.LastModifiedBy = account.FullName;

                _UnitOfWork.Post.UpdateEntity(DBData);

                await _UnitOfWork.Save();

                returnData = _UnitOfWork.Post.GetPosts(a => a.Id == Id, account.Id, Culture).First();

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
        /// Post: Add Post Attachments
        /// </summary>
        [HttpPost]
        [Route(nameof(AddPostAttachments))]
        public async Task<bool> AddPostAttachments(
            [FromQuery] string Culture,
            [FromForm] PostAttachmentCreateModel model)
        {
            bool returnData = false;
            Status Status = new();

            try
            {
                AuthorizedAccount account = (AuthorizedAccount)Request.HttpContext.Items["Account"];

                if (!_UnitOfWork.Post.Any(a => a.Id == model.Fk_Post && a.Fk_Account == account.Id))
                {
                    throw new AppException("Not Auth!");
                }

                ImgManager ImgManager = new(_Environment.WebRootPath);

                foreach (IFormFile attachment in model.PostAttachments)
                {
                    string FileURL = await ImgManager.UploudImage(_appSettings.DomainName, RandomGenerator.RandomKey(), attachment, "Uploud/PostAttachment");
                    if (!string.IsNullOrEmpty(FileURL))
                    {
                        _UnitOfWork.PostAttachment.CreateEntity(new PostAttachment
                        {
                            Fk_Post = model.Fk_Post,
                            FileURL = FileURL,
                            FileLength = attachment.Length,
                            FileType = attachment.ContentType,
                            FileName = attachment.FileName,
                            CreatedBy = account.FullName
                        });
                    }

                }

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
        /// Post: Create Post Comment
        /// </summary>
        [HttpPost]
        [Route(nameof(CreatePostComment))]
        public async Task<PostCommentModel> CreatePostComment(
            [FromQuery] string Culture,
            [FromForm] PostCommentCreateModel model)
        {
            PostCommentModel returnData = new();
            Status Status = new();

            try
            {
                if (!ModelState.IsValid)
                {
                    throw new AppException("Complete your info!");
                }

                AuthorizedAccount account = (AuthorizedAccount)Request.HttpContext.Items["Account"];

                if (_UnitOfWork.Post.Any(a => a.Id == model.Fk_Post &&
                                              a.Fk_Group > 0 &&
                                              !a.Group.GroupMembers.Any(a => a.Fk_Account == account.Id)))
                {
                    throw new AppException("Not Auth");
                }

                PostComment DBData = new()
                {
                    Fk_Account = account.Id,
                    CreatedBy = account.FullName
                };

                _Mapper.Map(model, DBData);

                #region Comment Attachment

                if (model.FileURL != null)
                {
                    ImgManager ImgManager = new(_Environment.WebRootPath);

                    string FileURL = await ImgManager.UploudImage(_appSettings.DomainName, RandomGenerator.RandomKey(), model.FileURL, "Uploud/PostComment");

                    if (!string.IsNullOrEmpty(FileURL))
                    {
                        DBData.FileURL = FileURL;
                        DBData.FileLength = model.FileURL.Length;
                        DBData.FileType = model.FileURL.ContentType;
                        DBData.FileName = model.FileURL.FileName;
                    }
                }
                #endregion

                _UnitOfWork.PostComment.CreateEntity(DBData);

                await _UnitOfWork.Save();

                returnData = _UnitOfWork.PostComment.GetPostComments(a => a.Id == DBData.Id, account.Id).First();

                Status = new Status(true);

                if (model.Fk_OldPostComment == null)
                {
                    List<int> owner = _UnitOfWork.Post.GetQuery(a => a.Id == model.Fk_Post)
                                               .Select(a => a.Fk_Account ?? 0)
                                               .ToList();

                    await SendPostCommentNotification(account, DBData.Id, owner);
                }
                else
                {
                    List<int> owner = _UnitOfWork.PostComment.GetQuery(a => a.Id == model.Fk_OldPostComment)
                                               .Select(a => a.Fk_Account)
                                               .ToList();

                    await SendCommentReplayNotification(account, DBData.Id, owner);
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
        /// Put: Edit Post Comment
        /// </summary>
        [HttpPut]
        [Route(nameof(EditPostComment))]
        public async Task<PostCommentModel> EditPostComment(
            [FromQuery] string Culture,
            [FromQuery] int id,
            [FromForm] PostCommentEditModel model)
        {
            PostCommentModel returnData = new();
            Status Status = new();

            try
            {
                if (!ModelState.IsValid)
                {
                    throw new AppException("Complete your info!");
                }

                AuthorizedAccount account = (AuthorizedAccount)Request.HttpContext.Items["Account"];

                if (!_UnitOfWork.PostComment.Any(a => a.Id == id &&
                                                      a.Fk_Account == account.Id))
                {
                    throw new AppException("Not Auth");
                }


                PostComment DBData = await _UnitOfWork.PostComment.GetByID(id);

                _Mapper.Map(model, DBData);

                if (model.RemoveImage)
                {
                    DBData.FileURL = "";
                }

                #region Comment Attachment

                if (model.FileURL != null)
                {
                    ImgManager ImgManager = new(_Environment.WebRootPath);

                    string FileURL = await ImgManager.UploudImage(_appSettings.DomainName, RandomGenerator.RandomKey(), model.FileURL, "Uploud/PostComment");

                    if (!string.IsNullOrEmpty(FileURL))
                    {
                        DBData.FileURL = FileURL;
                        DBData.FileLength = model.FileURL.Length;
                        DBData.FileType = model.FileURL.ContentType;
                        DBData.FileName = model.FileURL.FileName;
                    }
                }
                #endregion

                _UnitOfWork.PostComment.UpdateEntity(DBData);

                await _UnitOfWork.Save();

                returnData = _UnitOfWork.PostComment.GetPostComments(a => a.Id == DBData.Id, account.Id).First();

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
        /// Post: Create Post Reaction
        /// </summary>
        [HttpPost]
        [Route(nameof(CreatePostReaction))]
        public async Task<bool> CreatePostReaction(
            [FromQuery] string Culture,
            [FromBody] PostReactionCreateModel model)
        {
            bool returnData = false;
            Status Status = new();

            try
            {
                if (!ModelState.IsValid)
                {
                    throw new AppException("Complete your info!");
                }

                AuthorizedAccount account = (AuthorizedAccount)Request.HttpContext.Items["Account"];

                if (_UnitOfWork.Post.Any(a => a.Id == model.Fk_Post &&
                                            a.Fk_Group > 0 &&
                                            !a.Group.GroupMembers.Any(a => a.Fk_Account == account.Id)))
                {
                    throw new AppException("Not Auth");
                }

                PostReaction DBData = new();

                if (_UnitOfWork.PostReaction.Any(a => a.Fk_Post == model.Fk_Post && a.Fk_Account == account.Id))
                {
                    DBData = await _UnitOfWork.PostReaction.GetFirst(a => a.Fk_Post == model.Fk_Post && a.Fk_Account == account.Id);
                    DBData.Fk_ReactionType = model.Fk_ReactionType;

                    _UnitOfWork.PostReaction.UpdateEntity(DBData);
                }
                else
                {
                    _Mapper.Map(model, DBData);

                    DBData.Fk_Account = account.Id;

                    _UnitOfWork.PostReaction.CreateEntity(DBData);
                }

                await _UnitOfWork.Save();

                returnData = true;

                Status = new Status(true);

                List<int> postOwner = _UnitOfWork.Post.GetQuery(a => a.Id == model.Fk_Post)
                                                .Select(a => a.Fk_Account ?? 0)
                                                .ToList();

                await SendPostReactNotification(account, DBData.Id, postOwner);

            }
            catch (Exception ex)
            {
                Status = _StatusHandler.SetException(Status, ex);
            }

            Response.Headers.Add("X-Status", _StatusHandler.GetStatus(Status));

            return returnData;
        }

        /// <summary>
        /// Post: Create Post Comment Reaction
        /// </summary>
        [HttpPost]
        [Route(nameof(CreatePostCommentReaction))]
        public async Task<bool> CreatePostCommentReaction(
            [FromQuery] string Culture,
            [FromBody] PostCommentReactionCreateModel model)
        {
            bool returnData = false;
            Status Status = new();

            try
            {
                if (!ModelState.IsValid)
                {
                    throw new AppException("Complete your info!");
                }

                AuthorizedAccount account = (AuthorizedAccount)Request.HttpContext.Items["Account"];

                PostCommentReaction DBData = new();

                if (_UnitOfWork.PostCommentReaction.Any(a => a.Fk_PostComment == model.Fk_PostComment && a.Fk_Account == account.Id))
                {
                    DBData = await _UnitOfWork.PostCommentReaction.GetFirst(a => a.Fk_PostComment == model.Fk_PostComment && a.Fk_Account == account.Id);
                    DBData.Fk_ReactionType = model.Fk_ReactionType;

                    _UnitOfWork.PostCommentReaction.UpdateEntity(DBData);
                }
                else
                {
                    _Mapper.Map(model, DBData);

                    DBData.Fk_Account = account.Id;

                    _UnitOfWork.PostCommentReaction.CreateEntity(DBData);
                }

                await _UnitOfWork.Save();

                returnData = true;

                Status = new Status(true);

                List<int> owner = _UnitOfWork.PostComment.GetQuery(a => a.Id == model.Fk_PostComment)
                                               .Select(a => a.Fk_Account)
                                               .ToList();

                await SendCommentReactNotification(account, DBData.Id, owner);
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
        /// Delete: Remove Post
        /// </summary>
        [HttpDelete]
        [Route(nameof(RemovePost))]
        public async Task<bool> RemovePost(
            [FromQuery] string Culture,
            [FromQuery] int Id)
        {
            bool returnData = false;
            Status Status = new();

            try
            {
                AuthorizedAccount account = (AuthorizedAccount)Request.HttpContext.Items["Account"];

                if (!_UnitOfWork.Post.Any(a => a.Id == Id && a.Fk_Account == account.Id))
                {
                    throw new AppException("Not Auth!");
                }

                List<PostAttachment> Attachments = await _UnitOfWork.PostAttachment.GetAll(a => a.Fk_Post == Id);

                if (Attachments != null && Attachments.Any())
                {
                    ImgManager ImgManager = new(_Environment.WebRootPath);

                    foreach (PostAttachment attachment in Attachments)
                    {
                        if (!string.IsNullOrEmpty(attachment.FileURL))
                        {
                            ImgManager.DeleteImage(attachment.FileURL, _appSettings.DomainName);
                        }

                    }
                }
                _UnitOfWork.Post.DeleteEntity(await _UnitOfWork.Post.GetByID(Id));

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
        /// Delete: Remove Post Attachments
        /// </summary>
        [HttpDelete]
        [Route(nameof(RemovePostAttachments))]
        public async Task<bool> RemovePostAttachments(
            [FromQuery] string Culture,
            [FromBody] PostAttachmentRemoveModel model)
        {
            bool returnData = false;
            Status Status = new();

            try
            {
                AuthorizedAccount account = (AuthorizedAccount)Request.HttpContext.Items["Account"];

                if (!_UnitOfWork.Post.Any(a => a.Id == model.Fk_Post && a.Fk_Account == account.Id))
                {
                    throw new AppException("Not Auth!");
                }

                List<PostAttachment> Data = await _UnitOfWork.PostAttachment
                                                          .GetAll(a => a.Fk_Post == model.Fk_Post &&
                                                                       model.AttachmentIds
                                                                            .Contains(a.Id));

                ImgManager ImgManager = new(_Environment.WebRootPath);

                foreach (PostAttachment attachment in Data)
                {
                    if (!string.IsNullOrEmpty(attachment.FileURL))
                    {
                        ImgManager.DeleteImage(attachment.FileURL, _appSettings.DomainName);
                    }
                }

                _UnitOfWork.PostAttachment
                           .DeleteEntity(Data);

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
        /// Delete: Remove Post Comment
        /// </summary>
        [HttpDelete]
        [Route(nameof(RemovePostComment))]
        public async Task<bool> RemovePostComment(
            [FromQuery] string Culture,
            [FromQuery] int Id)
        {
            bool returnData = false;
            Status Status = new();

            try
            {
                AuthorizedAccount account = (AuthorizedAccount)Request.HttpContext.Items["Account"];

                if (!_UnitOfWork.PostComment.Any(a => a.Id == Id && a.Fk_Account == account.Id))
                {
                    throw new AppException("Not Auth!");
                }

                PostComment Data = await _UnitOfWork.PostComment.GetByID(Id);

                if (!string.IsNullOrEmpty(Data.FileURL))
                {
                    ImgManager ImgManager = new(_Environment.WebRootPath);

                    ImgManager.DeleteImage(Data.FileURL, _appSettings.DomainName);

                }
                _UnitOfWork.PostComment.DeleteEntity(Data);

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
        /// Delete: Remove Post Reaction
        /// </summary>
        [HttpDelete]
        [Route(nameof(RemovePostReaction))]
        public async Task<bool> RemovePostReaction(
            [FromQuery] string Culture,
            [FromQuery] int Fk_Post)
        {
            bool returnData = false;
            Status Status = new();

            try
            {
                AuthorizedAccount account = (AuthorizedAccount)Request.HttpContext.Items["Account"];

                if (_UnitOfWork.PostReaction.Any(a => a.Fk_Post == Fk_Post && a.Fk_Account == account.Id))
                {
                    _UnitOfWork.PostReaction.DeleteEntity(await _UnitOfWork.PostReaction.GetFirst(a => a.Fk_Post == Fk_Post && a.Fk_Account == account.Id));

                    await _UnitOfWork.Save();

                    returnData = true;

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
        /// Delete: Remove Post Comment Reaction
        /// </summary>
        [HttpDelete]
        [Route(nameof(RemovePostCommentReaction))]
        public async Task<bool> RemovePostCommentReaction(
            [FromQuery] string Culture,
            [FromQuery] int Fk_PostComment)
        {
            bool returnData = false;
            Status Status = new();

            try
            {
                AuthorizedAccount account = (AuthorizedAccount)Request.HttpContext.Items["Account"];

                if (_UnitOfWork.PostCommentReaction.Any(a => a.Fk_PostComment == Fk_PostComment && a.Fk_Account == account.Id))
                {
                    _UnitOfWork.PostCommentReaction.DeleteEntity(await _UnitOfWork.PostCommentReaction.GetFirst(a => a.Fk_PostComment == Fk_PostComment && a.Fk_Account == account.Id));

                    await _UnitOfWork.Save();

                    returnData = true;

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

        // helper method

        private async Task SendPostNotification(AuthorizedAccount account, Post post)
        {
            List<int> members = new();

            Notification notification = new()
            {
                Title = _Localizer.Get("New post!"),
                Description = account.FullName + _Localizer.Get(" add new post!"),
                IsPublic = true,
                IsActive = true,
                OpenType = OpenTypeEnum.Post,
                OpenValue = post.Id.ToString(),
                ImageURL = account.ImageURL,
                NotificationAccounts = new List<NotificationAccount>()
            };

            if (post.Fk_Group > 0)
            {
                notification.IsPublic = false;

                members = _UnitOfWork.GroupMember
                                     .GetQuery(a => a.Fk_Group == post.Fk_Group)
                                     .Select(a => a.Fk_Account)
                                     .ToList();
            }
            if (post.Fk_OldPost > 0)
            {
                notification.IsPublic = false;
                notification.Title = _Localizer.Get("Post share!");
                notification.Description = account.FullName + _Localizer.Get(" share your post!");
                members = _UnitOfWork.Post
                                     .GetQuery(a => a.Id == post.Fk_OldPost)
                                     .Select(a => a.Fk_Account ?? 0)
                                     .ToList();
            }

            foreach (int fk_Account in members)
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

        private async Task SendPostCommentNotification(AuthorizedAccount account, int id, List<int> members)
        {
            Notification notification = new()
            {
                Title = _Localizer.Get("New comment!"),
                Description = account.FullName + _Localizer.Get(" add new comment on your post!"),
                IsPublic = false,
                IsActive = true,
                OpenType = OpenTypeEnum.Commnet,
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

        private async Task SendCommentReplayNotification(AuthorizedAccount account, int id, List<int> members)
        {
            Notification notification = new()
            {
                Title = _Localizer.Get("New replay!"),
                Description = account.FullName + _Localizer.Get(" add replay on your comment!"),
                IsPublic = false,
                IsActive = true,
                OpenType = OpenTypeEnum.Commnet,
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

        private async Task SendPostReactNotification(AuthorizedAccount account, int id, List<int> members)
        {
            Notification notification = new()
            {
                Title = _Localizer.Get("New react!"),
                Description = account.FullName + _Localizer.Get(" add new react on your post!"),
                IsPublic = false,
                IsActive = true,
                OpenType = OpenTypeEnum.Post,
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

        private async Task SendCommentReactNotification(AuthorizedAccount account, int id, List<int> members)
        {
            Notification notification = new()
            {
                Title = _Localizer.Get("New react!"),
                Description = account.FullName + _Localizer.Get(" add new react on your comment!"),
                IsPublic = false,
                IsActive = true,
                OpenType = OpenTypeEnum.Commnet,
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
