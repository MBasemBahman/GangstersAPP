namespace EConnectSocialMedia.Repository.PostEntity
{
    public class ReactionTypeRepository : AppBaseRepository<ReactionType>
    {
        private readonly DatabaseContext _DBContext;
        private readonly IMapper _Mapper;

        public ReactionTypeRepository(DatabaseContext DBContext, IMapper Mapper) : base(DBContext)
        {
            _DBContext = DBContext;
            _Mapper = Mapper;
        }

        public ReactionType GetLang(ReactionType entity)
        {
            entity.ReactionTypeLang = _DBContext.ReactionTypeLang.Where(a => a.Fk_Source == entity.Id).FirstOrDefault();

            if (entity.ReactionTypeLang != null)
            {
                _Mapper.Map(entity.ReactionTypeLang, entity);
            }
            return entity;
        }

        public PagedList<ReactionType> GetLang(PagedList<ReactionType> entities)
        {
            if (entities.Any())
            {
                entities.ForEach(entity => entity = GetLang(entity));
            }

            return entities;
        }
    }
}
