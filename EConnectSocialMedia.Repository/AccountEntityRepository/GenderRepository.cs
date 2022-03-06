namespace EConnectSocialMedia.Repository.AccountEntityRepository
{
    public class GenderRepository : AppBaseRepository<Gender>
    {
        private readonly DatabaseContext _DBContext;
        private readonly IMapper _Mapper;

        public GenderRepository(DatabaseContext DBContext, IMapper Mapper) : base(DBContext)
        {
            _DBContext = DBContext;
            _Mapper = Mapper;
        }

        public Gender GetLang(Gender entity)
        {
            entity.GenderLang = _DBContext.GenderLang.Where(a => a.Fk_Source == entity.Id).FirstOrDefault();

            if (entity.GenderLang != null)
            {
                _Mapper.Map(entity.GenderLang, entity);
            }
            return entity;
        }

        public PagedList<Gender> GetLang(PagedList<Gender> entities)
        {
            if (entities.Any())
            {
                entities.ForEach(entity => entity = GetLang(entity));
            }

            return entities;
        }
    }
}
