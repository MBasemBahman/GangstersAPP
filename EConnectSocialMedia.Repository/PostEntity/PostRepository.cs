namespace EConnectSocialMedia.Repository.PostEntity
{
    public class PostRepository : AppBaseRepository<Post>
    {
        private readonly DatabaseContext _DBContext;
        private readonly IMapper _Mapper;

        public PostRepository(DatabaseContext DBContext, IMapper Mapper) : base(DBContext)
        {
            _DBContext = DBContext;
            _Mapper = Mapper;
        }


        public IQueryable<PostModel> GetPosts(
            Expression<Func<Post, bool>> expression = null,
            int? Fk_Account = null, string cultue = "ar")
        {
            expression ??= (a => true);

            return _DBContext.Post
                             .Where(expression)
                             .OrderByDescending(a => a.Id)
                             .Select(a => new PostModel
                             {
                                 Id = a.Id,
                                 CreatedAt = a.CreatedAt.AddHours(2).ToString(DataManipulate.DateTimeFormat, CultureInfo.InvariantCulture),
                                 LastModifiedAt = a.LastModifiedAt.AddHours(2).ToString(DataManipulate.DateTimeFormat, CultureInfo.InvariantCulture),
                                 Fk_Account = a.Fk_Account,
                                 Account = a.Account == null ? null : new AccountModel
                                 {
                                     Id = a.Account.Id,
                                     FirstName = a.Account.FirstName,
                                     LastName = a.Account.LastName,
                                     NickName = a.Account.NickName,
                                     IsOnline = a.Account.IsOnline,
                                     ImageURL = a.Account.ImageURL,
                                 },
                                 Fk_PostType = a.Fk_PostType,
                                 PostType = new PostTypeModel
                                 {
                                     Name = cultue.ToLower() == "en" ? a.PostType.PostTypeLang.Name : a.PostType.Name,
                                 },
                                 PostTitle = a.PostTitle,
                                 PostText = a.PostText,
                                 Fk_Group = a.Fk_Group,
                                 Fk_OldPost = a.Fk_OldPost,
                                 CommentCount = a.PostComments.Count,
                                 ReactionCount = a.PostReactions.Count,
                                 AttachmentsCount = a.PostAttachments.Count,
                                 IsOwner = (Fk_Account != null && a.Fk_Account == Fk_Account),
                                 MyReaction = (Fk_Account == null || !a.PostReactions.Any(b => b.Fk_Account == Fk_Account)) ? null :
                                              a.PostReactions
                                               .Where(b => b.Fk_Account == Fk_Account)
                                               .Select(c => new ReactionTypeModel
                                               {
                                                   Id = c.ReactionType.Id,
                                                   ImageURL = c.ReactionType.ImageURL,
                                                   Name = c.ReactionType.Name,
                                               }).First()
                             });
        }

        public Post UpdateStateHistory(Post Post, int Fk_OldState = 0, string Notes = "")
        {
            if (Fk_OldState != Post.Fk_PostState)
            {
                Post.PostStateHistories = _DBContext.PostStateHistory.Where(a => a.Fk_Post == Post.Id).ToList();

                if (Post.PostStateHistories == null)
                {
                    Post.PostStateHistories = new List<PostStateHistory>();
                }

                Post.PostStateHistories.Add(new PostStateHistory
                {
                    Fk_PostState = Post.Fk_PostState,
                    Note = Notes,
                    CreatedBy = !string.IsNullOrEmpty(Post.LastModifiedBy) ? Post.LastModifiedBy : Post.CreatedBy
                });
            }
            return Post;
        }
    }
}
