namespace EConnectSocialMedia.Repository.CHIAEntityRepository
{
    public class TutorialItemRepository : AppBaseRepository<TutorialItem>
    {
        private readonly DatabaseContext _DBContext;
        private readonly IMapper _Mapper;

        public TutorialItemRepository(DatabaseContext DBContext, IMapper Mapper) : base(DBContext)
        {
            _DBContext = DBContext;
            _Mapper = Mapper;
        }

        public TutorialItem GetLang(TutorialItem entity)
        {
            entity.TutorialItemLang = _DBContext.TutorialItemLang.Where(a => a.Fk_Source == entity.Id).FirstOrDefault();

            if (entity.TutorialItemLang != null)
            {
                _Mapper.Map(entity.TutorialItemLang, entity);
            }
            return entity;
        }

        public PagedList<TutorialItem> GetLang(PagedList<TutorialItem> entities)
        {
            if (entities.Any())
            {
                entities.ForEach(entity => entity = GetLang(entity));
            }

            return entities;
        }
    }
}
