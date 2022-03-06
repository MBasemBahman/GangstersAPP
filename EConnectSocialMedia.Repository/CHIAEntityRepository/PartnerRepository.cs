namespace GangstersAPP.Repository.CHIAEntityRepository
{
    public class PartnerRepository : AppBaseRepository<Partner>
    {
        private readonly DatabaseContext _DBContext;
        private readonly IMapper _Mapper;

        public PartnerRepository(DatabaseContext DBContext, IMapper Mapper) : base(DBContext)
        {
            _DBContext = DBContext;
            _Mapper = Mapper;
        }

        public Partner GetLang(Partner entity)
        {
            entity.PartnerLang = _DBContext.PartnerLang.Where(a => a.Fk_Source == entity.Id).FirstOrDefault();

            if (entity.PartnerLang != null)
            {
                _Mapper.Map(entity.PartnerLang, entity);

            }
            return entity;
        }

        public PagedList<Partner> GetLang(PagedList<Partner> entities)
        {
            if (entities.Any())
            {
                entities.ForEach(entity => entity = GetLang(entity));
            }

            return entities;
        }
    }
}
