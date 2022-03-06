namespace GangstersAPP.Repository.MainDataEntityRepository
{
    public class AppIntroRepository : AppBaseRepository<AppIntro>
    {
        private readonly DatabaseContext _DBContext;
        private readonly IMapper _Mapper;

        public AppIntroRepository(DatabaseContext DBContext, IMapper Mapper) : base(DBContext)
        {
            _DBContext = DBContext;
            _Mapper = Mapper;
        }

        public AppIntro GetLang(AppIntro entity)
        {
            entity.AppIntroLang = _DBContext.AppIntroLang.Where(a => a.Fk_Source == entity.Id).FirstOrDefault();

            if (entity.AppIntroLang != null)
            {
                _Mapper.Map(entity.AppIntroLang, entity);
            }
            return entity;
        }

        public PagedList<AppIntro> GetLang(PagedList<AppIntro> entities)
        {
            if (entities.Any())
            {
                entities.ForEach(entity => entity = GetLang(entity));
            }

            return entities;
        }
    }
}
