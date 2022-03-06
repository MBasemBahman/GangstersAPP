namespace GangstersAPP.Repository.ServiceProviderRequestEntityRepository
{
    public class ServiceProviderClassificationRepository : AppBaseRepository<ServiceProviderClassification>
    {
        private readonly DatabaseContext _DBContext;
        private readonly IMapper _Mapper;

        public ServiceProviderClassificationRepository(DatabaseContext DBContext, IMapper Mapper) : base(DBContext)
        {
            _DBContext = DBContext;
            _Mapper = Mapper;
        }

        public ServiceProviderClassification GetLang(ServiceProviderClassification entity)
        {
            entity.ServiceProviderClassificationLang = _DBContext.ServiceProviderClassificationLang.Where(a => a.Fk_Source == entity.Id).FirstOrDefault();

            if (entity.ServiceProviderClassificationLang != null)
            {
                _Mapper.Map(entity.ServiceProviderClassificationLang, entity);
            }
            return entity;
        }

        public PagedList<ServiceProviderClassification> GetLang(PagedList<ServiceProviderClassification> entities)
        {
            if (entities.Any())
            {
                entities.ForEach(entity => entity = GetLang(entity));
            }

            return entities;
        }
    }
}
