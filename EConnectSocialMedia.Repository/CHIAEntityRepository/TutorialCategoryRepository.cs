namespace EConnectSocialMedia.Repository.CHIAEntityRepository
{
    public class TutorialCategoryRepository : AppBaseRepository<TutorialCategory>
    {
        private readonly DatabaseContext _DBContext;
        private readonly IMapper _Mapper;

        public TutorialCategoryRepository(DatabaseContext DBContext, IMapper Mapper) : base(DBContext)
        {
            _DBContext = DBContext;
            _Mapper = Mapper;
        }

        public TutorialCategory GetLang(TutorialCategory entity)
        {
            entity.TutorialCategoryLang = _DBContext.TutorialCategoryLang.Where(a => a.Fk_Source == entity.Id).FirstOrDefault();

            if (entity.TutorialCategoryLang != null)
            {
                _Mapper.Map(entity.TutorialCategoryLang, entity);
            }
            return entity;
        }

        public PagedList<TutorialCategory> GetLang(PagedList<TutorialCategory> entities)
        {
            if (entities.Any())
            {
                entities.ForEach(entity => entity = GetLang(entity));
            }

            return entities;
        }
    }
}
