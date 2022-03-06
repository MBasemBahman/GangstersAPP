namespace GangstersAPP.Repository.PostEntity
{
    public class PostCommentReactionRepository : AppBaseRepository<PostCommentReaction>
    {
        private readonly DatabaseContext _DBContext;
        private readonly IMapper _Mapper;

        public PostCommentReactionRepository(DatabaseContext DBContext, IMapper Mapper) : base(DBContext)
        {
            _DBContext = DBContext;
            _Mapper = Mapper;
        }

        public IQueryable<PostCommentReaction> GetAllInclude(Expression<Func<PostCommentReaction, bool>> expression)
        {
            return _DBContext.PostCommentReaction.Where(expression)
                                                 .Include(a => a.PostComment)
                                                 .ThenInclude(a => a.Post)
                                                 .Include(a => a.Account)
                                                 .Include(a => a.ReactionType);
        }

    }
}
