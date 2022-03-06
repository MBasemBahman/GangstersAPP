namespace EConnectSocialMedia.Repository.ChatEntity
{
    public class MessageStateRepository : AppBaseRepository<MessageState>
    {
        private readonly DatabaseContext _DBContext;
        private readonly IMapper _Mapper;

        public MessageStateRepository(DatabaseContext DBContext, IMapper Mapper) : base(DBContext)
        {
            _DBContext = DBContext;
            _Mapper = Mapper;
        }

        public MessageState GetLang(MessageState entity)
        {
            entity.MessageStateLang = _DBContext.MessageStateLang.Where(a => a.Fk_Source == entity.Id).FirstOrDefault();

            if (entity.MessageStateLang != null)
            {
                _Mapper.Map(entity.MessageStateLang, entity);
            }
            return entity;
        }

        public PagedList<MessageState> GetLang(PagedList<MessageState> entities)
        {
            if (entities.Any())
            {
                entities.ForEach(entity => entity = GetLang(entity));
            }

            return entities;
        }
    }
}
