namespace EConnectSocialMedia.Repository.CHIAEntityRepository
{
    public class UserFullinfoItemRepository : AppBaseRepository<UserFullinfoItem>
    {
        private readonly DatabaseContext _DBContext;
        private readonly IMapper _Mapper;

        public UserFullinfoItemRepository(DatabaseContext DBContext, IMapper Mapper) : base(DBContext)
        {
            _DBContext = DBContext;
            _Mapper = Mapper;
        }

        public UserFullinfoItem GetLang(UserFullinfoItem entity)
        {
            entity.UserFullinfoItemLang = _DBContext.UserFullinfoItemLang.Where(a => a.Fk_Source == entity.Id).FirstOrDefault();

            if (entity.UserFullinfoItemLang != null)
            {
                _Mapper.Map(entity.UserFullinfoItemLang, entity);
            }
            return entity;
        }

        public PagedList<UserFullinfoItem> GetLang(PagedList<UserFullinfoItem> entities)
        {
            if (entities.Any())
            {
                entities.ForEach(entity => entity = GetLang(entity));
            }

            return entities;
        }
    }
}
