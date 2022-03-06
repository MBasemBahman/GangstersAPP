namespace EConnectSocialMedia.Repository.AccountEntityRepository
{
    public class AccountTypeRepository : AppBaseRepository<AccountType>
    {
        private readonly DatabaseContext _DBContext;
        private readonly IMapper _Mapper;

        public AccountTypeRepository(DatabaseContext DBContext, IMapper Mapper) : base(DBContext)
        {
            _DBContext = DBContext;
            _Mapper = Mapper;
        }

        public AccountType GetLang(AccountType entity)
        {
            entity.AccountTypeLang = _DBContext.AccountTypeLang.Where(a => a.Fk_Source == entity.Id).FirstOrDefault();

            if (entity.AccountTypeLang != null)
            {
                _Mapper.Map(entity.AccountTypeLang, entity);
            }
            return entity;
        }

        public PagedList<AccountType> GetLang(PagedList<AccountType> entities)
        {
            if (entities.Any())
            {
                entities.ForEach(entity => entity = GetLang(entity));
            }

            return entities;
        }
    }
}
