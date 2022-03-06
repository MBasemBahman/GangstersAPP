namespace EConnectSocialMedia.Repository.PostEntity
{
    public class PostCommentRepository : AppBaseRepository<PostComment>
    {
        private readonly DatabaseContext _DBContext;
        private readonly IMapper _Mapper;

        public PostCommentRepository(DatabaseContext DBContext, IMapper Mapper) : base(DBContext)
        {
            _DBContext = DBContext;
            _Mapper = Mapper;
        }

        public IQueryable<PostCommentModel> GetPostComments(
            Expression<Func<PostComment, bool>> expression = null,
            int? Fk_Account = null)
        {
            expression ??= (a => true);

            return _DBContext.PostComment
                             .Where(expression)
                             .OrderByDescending(a => a.Id)
                             .Select(a => new PostCommentModel
                             {
                                 Id = a.Id,
                                 CreatedAt = a.CreatedAt.AddHours(2).ToString(DataManipulate.DateTimeFormat, CultureInfo.InvariantCulture),
                                 LastModifiedAt = a.LastModifiedAt.AddHours(2).ToString(DataManipulate.DateTimeFormat, CultureInfo.InvariantCulture),
                                 Fk_Account = a.Fk_Account,
                                 Account = new AccountModel
                                 {
                                     Id = a.Account.Id,
                                     FirstName = a.Account.FirstName,
                                     LastName = a.Account.LastName,
                                     NickName = a.Account.NickName,
                                     IsOnline = a.Account.IsOnline,
                                     ImageURL = a.Account.ImageURL,
                                 },
                                 Fk_OldPostComment = a.Fk_OldPostComment,
                                 Fk_Post = a.Fk_Post,
                                 CommentText = a.CommentText,
                                 ReactionCount = a.PostCommentReactions.Count,
                                 ReplayCount = a.SharedPostComments.Count,
                                 IsOwner = (Fk_Account != null && a.Fk_Account == Fk_Account),
                                 MyReaction = (Fk_Account == null || !a.PostCommentReactions.Any(b => b.Fk_Account == Fk_Account)) ? null :
                                              a.PostCommentReactions
                                               .Where(b => b.Fk_Account == Fk_Account)
                                               .Select(c => new ReactionTypeModel
                                               {
                                                   Id = c.ReactionType.Id,
                                                   ImageURL = c.ReactionType.ImageURL,
                                                   Name = c.ReactionType.Name,
                                               }).First()
                             });
        }
    }
}
