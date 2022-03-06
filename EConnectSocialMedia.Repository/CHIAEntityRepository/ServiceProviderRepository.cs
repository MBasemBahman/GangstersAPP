namespace GangstersAPP.Repository.CHIAEntityRepository
{
    public class ServiceProviderRepository : AppBaseRepository<ServiceProvider>
    {
        private readonly DatabaseContext _DBContext;
        private readonly IMapper _Mapper;

        public ServiceProviderRepository(DatabaseContext DBContext, IMapper Mapper) : base(DBContext)
        {
            _DBContext = DBContext;
            _Mapper = Mapper;
        }

        public ServiceProvider GetLang(ServiceProvider entity)
        {
            entity.ServiceProviderLang = _DBContext.ServiceProviderLang.Where(a => a.Fk_Source == entity.Id).FirstOrDefault();

            if (entity.ServiceProviderLang != null)
            {
                _Mapper.Map(entity.ServiceProviderLang, entity);
            }
            return entity;
        }

        public PagedList<ServiceProvider> GetLang(PagedList<ServiceProvider> entities)
        {
            if (entities.Any())
            {
                entities.ForEach(entity => entity = GetLang(entity));
            }

            return entities;
        }
    }
}
