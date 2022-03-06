namespace GangstersAPP.Repository.MainDataEntityRepository
{
    public class TermsAndConditionsRepository : AppBaseRepository<TermsAndConditions>
    {
        private readonly DatabaseContext _DBContext;
        private readonly IMapper _Mapper;

        public TermsAndConditionsRepository(DatabaseContext DBContext, IMapper Mapper) : base(DBContext)
        {
            _DBContext = DBContext;
            _Mapper = Mapper;
        }

        public TermsAndConditions GetLang(TermsAndConditions entity)
        {
            entity.TermsAndConditionsLang = _DBContext.TermsAndConditionsLang.Where(a => a.Fk_Source == entity.Id).FirstOrDefault();

            if (entity.TermsAndConditionsLang != null)
            {
                _Mapper.Map(entity.TermsAndConditionsLang, entity);
            }
            return entity;
        }

        public PagedList<TermsAndConditions> GetLang(PagedList<TermsAndConditions> entities)
        {
            if (entities.Any())
            {
                entities.ForEach(entity => entity = GetLang(entity));
            }

            return entities;
        }
    }
}
