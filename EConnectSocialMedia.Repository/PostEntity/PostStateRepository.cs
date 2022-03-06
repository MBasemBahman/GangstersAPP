namespace EConnectSocialMedia.Repository.PostEntity
{
    public class PostStateRepository : AppBaseRepository<PostState>
    {
        private readonly DatabaseContext _DBContext;
        private readonly IMapper _Mapper;

        public PostStateRepository(DatabaseContext DBContext, IMapper Mapper) : base(DBContext)
        {
            _DBContext = DBContext;
            _Mapper = Mapper;
        }

        public PostState GetLang(PostState entity)
        {
            entity.PostStateLang = _DBContext.PostStateLang.Where(a => a.Fk_Source == entity.Id).FirstOrDefault();

            if (entity.PostStateLang != null)
            {
                _Mapper.Map(entity.PostStateLang, entity);
            }
            return entity;
        }

        public PagedList<PostState> GetLang(PagedList<PostState> entities)
        {
            if (entities.Any())
            {
                entities.ForEach(entity => entity = GetLang(entity));
            }

            return entities;
        }
    }
}
