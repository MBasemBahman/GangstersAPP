namespace GangstersAPP.Repository.ChatEntity
{
    public class MessageTypeRepository : AppBaseRepository<MessageType>
    {
        private readonly DatabaseContext _DBContext;
        private readonly IMapper _Mapper;

        public MessageTypeRepository(DatabaseContext DBContext, IMapper Mapper) : base(DBContext)
        {
            _DBContext = DBContext;
            _Mapper = Mapper;
        }

        public MessageType GetLang(MessageType entity)
        {
            entity.MessageTypeLang = _DBContext.MessageTypeLang.Where(a => a.Fk_Source == entity.Id).FirstOrDefault();

            if (entity.MessageTypeLang != null)
            {
                _Mapper.Map(entity.MessageTypeLang, entity);
            }
            return entity;
        }

        public PagedList<MessageType> GetLang(PagedList<MessageType> entities)
        {
            if (entities.Any())
            {
                entities.ForEach(entity => entity = GetLang(entity));
            }

            return entities;
        }
    }
}
