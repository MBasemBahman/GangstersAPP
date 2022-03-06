namespace GangstersAPP.Repository.CHIAEntityRepository
{
    public class ServiceProviderAuthorityRepository : AppBaseRepository<ServiceProviderAuthority>
    {
        private readonly DatabaseContext _DBContext;
        private readonly IMapper _Mapper;

        public ServiceProviderAuthorityRepository(DatabaseContext DBContext, IMapper Mapper) : base(DBContext)
        {
            _DBContext = DBContext;
            _Mapper = Mapper;
        }

        public ServiceProviderAuthority GetLang(ServiceProviderAuthority entity)
        {
            entity.ServiceProviderAuthorityLang = _DBContext.ServiceProviderAuthorityLang.Where(a => a.Fk_Source == entity.Id).FirstOrDefault();

            if (entity.ServiceProviderAuthorityLang != null)
            {
                _Mapper.Map(entity.ServiceProviderAuthorityLang, entity);
            }
            return entity;
        }

        public PagedList<ServiceProviderAuthority> GetLang(PagedList<ServiceProviderAuthority> entities)
        {
            if (entities.Any())
            {
                entities.ForEach(entity => entity = GetLang(entity));
            }

            return entities;
        }
    }
}
