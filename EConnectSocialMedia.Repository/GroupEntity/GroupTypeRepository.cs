namespace EConnectSocialMedia.Repository.GroupEntity
{
    public class GroupTypeRepository : AppBaseRepository<GroupType>
    {
        private readonly DatabaseContext _DBContext;
        private readonly IMapper _Mapper;

        public GroupTypeRepository(DatabaseContext DBContext, IMapper Mapper) : base(DBContext)
        {
            _DBContext = DBContext;
            _Mapper = Mapper;
        }

        public GroupType GetLang(GroupType entity)
        {
            entity.GroupTypeLang = _DBContext.GroupTypeLang.Where(a => a.Fk_Source == entity.Id).FirstOrDefault();

            if (entity.GroupTypeLang != null)
            {
                _Mapper.Map(entity.GroupTypeLang, entity);
            }
            return entity;
        }

        public PagedList<GroupType> GetLang(PagedList<GroupType> entities)
        {
            if (entities.Any())
            {
                entities.ForEach(entity => entity = GetLang(entity));
            }

            return entities;
        }
    }
}
