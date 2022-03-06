namespace GangstersAPP.Repository.PostEntity
{
    public class PostTypeRepository : AppBaseRepository<PostType>
    {
        private readonly DatabaseContext _DBContext;
        private readonly IMapper _Mapper;

        public PostTypeRepository(DatabaseContext DBContext, IMapper Mapper) : base(DBContext)
        {
            _DBContext = DBContext;
            _Mapper = Mapper;
        }

        public PostType GetLang(PostType entity)
        {
            entity.PostTypeLang = _DBContext.PostTypeLang.Where(a => a.Fk_Source == entity.Id).FirstOrDefault();

            if (entity.PostTypeLang != null)
            {
                _Mapper.Map(entity.PostTypeLang, entity);
            }
            return entity;
        }

        public PagedList<PostType> GetLang(PagedList<PostType> entities)
        {
            if (entities.Any())
            {
                entities.ForEach(entity => entity = GetLang(entity));
            }

            return entities;
        }
    }
}
