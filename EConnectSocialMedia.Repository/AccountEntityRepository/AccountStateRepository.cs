namespace GangstersAPP.Repository.AccountEntityRepository
{
    public class AccountStateRepository : AppBaseRepository<AccountState>
    {
        private readonly DatabaseContext _DBContext;
        private readonly IMapper _Mapper;

        public AccountStateRepository(DatabaseContext DBContext, IMapper Mapper) : base(DBContext)
        {
            _DBContext = DBContext;
            _Mapper = Mapper;
        }

        public AccountState GetLang(AccountState entity)
        {
            entity.AccountStateLang = _DBContext.AccountStateLang.Where(a => a.Fk_Source == entity.Id).FirstOrDefault();

            if (entity.AccountStateLang != null)
            {
                _Mapper.Map(entity.AccountStateLang, entity);
            }
            return entity;
        }

        public PagedList<AccountState> GetLang(PagedList<AccountState> entities)
        {
            if (entities.Any())
            {
                entities.ForEach(entity => entity = GetLang(entity));
            }

            return entities;
        }

    }
}
