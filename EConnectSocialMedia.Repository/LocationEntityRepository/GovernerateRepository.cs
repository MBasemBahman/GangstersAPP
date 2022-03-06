namespace EConnectSocialMedia.Repository.LocationEntityRepository
{
    public class GovernerateRepository : AppBaseRepository<Governerate>
    {
        private readonly DatabaseContext _DBContext;
        private readonly IMapper _Mapper;

        public GovernerateRepository(DatabaseContext DBContext, IMapper Mapper) : base(DBContext)
        {
            _DBContext = DBContext;
            _Mapper = Mapper;
        }

        public Governerate GetLang(Governerate entity)
        {
            entity.GovernerateLang = _DBContext.GovernerateLang.Where(a => a.Fk_Source == entity.Id).FirstOrDefault();

            if (entity.GovernerateLang != null)
            {
                _Mapper.Map(entity.GovernerateLang, entity);
            }
            return entity;
        }

        public PagedList<Governerate> GetLang(PagedList<Governerate> entities)
        {
            if (entities.Any())
            {
                entities.ForEach(entity => entity = GetLang(entity));
            }

            return entities;
        }
    }
}
