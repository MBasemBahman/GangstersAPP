namespace EConnectSocialMedia.Repository.BeneficiaryRequestEntityRepository
{
    public class BeneficiaryTypeRepository : AppBaseRepository<BeneficiaryType>
    {
        private readonly DatabaseContext _DBContext;
        private readonly IMapper _Mapper;

        public BeneficiaryTypeRepository(DatabaseContext DBContext, IMapper Mapper) : base(DBContext)
        {
            _DBContext = DBContext;
            _Mapper = Mapper;
        }

        public BeneficiaryType GetLang(BeneficiaryType entity)
        {
            entity.BeneficiaryTypeLang = _DBContext.BeneficiaryTypeLang.Where(a => a.Fk_Source == entity.Id).FirstOrDefault();

            if (entity.BeneficiaryTypeLang != null)
            {
                _Mapper.Map(entity.BeneficiaryTypeLang, entity);
            }
            return entity;
        }

        public PagedList<BeneficiaryType> GetLang(PagedList<BeneficiaryType> entities)
        {
            if (entities.Any())
            {
                entities.ForEach(entity => entity = GetLang(entity));
            }

            return entities;
        }
    }
}
