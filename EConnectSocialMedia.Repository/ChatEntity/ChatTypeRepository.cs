namespace EConnectSocialMedia.Repository.ChatEntity
{
    public class ChatTypeRepository : AppBaseRepository<ChatType>
    {
        private readonly DatabaseContext _DBContext;
        private readonly IMapper _Mapper;

        public ChatTypeRepository(DatabaseContext DBContext, IMapper Mapper) : base(DBContext)
        {
            _DBContext = DBContext;
            _Mapper = Mapper;
        }

        public ChatType GetLang(ChatType entity)
        {
            entity.ChatTypeLang = _DBContext.ChatTypeLang.Where(a => a.Fk_Source == entity.Id).FirstOrDefault();

            if (entity.ChatTypeLang != null)
            {
                _Mapper.Map(entity.ChatTypeLang, entity);
            }
            return entity;
        }

        public PagedList<ChatType> GetLang(PagedList<ChatType> entities)
        {
            if (entities.Any())
            {
                entities.ForEach(entity => entity = GetLang(entity));
            }

            return entities;
        }
    }
}
