namespace GangstersAPP.Repository.CHIAEntityRepository
{
    public class ServiceProviderCategoryRepository : AppBaseRepository<ServiceProviderCategory>
    {
        private readonly DatabaseContext _DBContext;
        private readonly IMapper _Mapper;

        public ServiceProviderCategoryRepository(DatabaseContext DBContext, IMapper Mapper) : base(DBContext)
        {
            _DBContext = DBContext;
            _Mapper = Mapper;
        }

        public ServiceProviderCategory GetLang(ServiceProviderCategory entity)
        {
            entity.ServiceProviderCategoryLang = _DBContext.ServiceProviderCategoryLang.Where(a => a.Fk_Source == entity.Id).FirstOrDefault();

            if (entity.ServiceProviderCategoryLang != null)
            {
                _Mapper.Map(entity.ServiceProviderCategoryLang, entity);
            }
            return entity;
        }

        public PagedList<ServiceProviderCategory> GetLang(PagedList<ServiceProviderCategory> entities)
        {
            if (entities.Any())
            {
                entities.ForEach(entity => entity = GetLang(entity));
            }

            return entities;
        }
    }
}
