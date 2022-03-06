using static GangstersAPP.Entity.EntityEnum;

namespace GangstersAPP.Repository.ChatEntity
{
    public class ChatRepository : AppBaseRepository<Chat>
    {
        private readonly DatabaseContext _DBContext;
        private readonly IMapper _Mapper;

        public ChatRepository(DatabaseContext DBContext, IMapper Mapper) : base(DBContext)
        {
            _DBContext = DBContext;
            _Mapper = Mapper;
        }

        public IQueryable<ChatModel> GetChats(
            Expression<Func<Chat, bool>> expression = null,
            int Fk_Account = 0)
        {
            expression ??= (a => true);

            return _DBContext.Chat
                             .Where(expression)
                             .OrderByDescending(a => a.LastActionAt)
                             .Select(a => new ChatModel
                             {
                                 Id = a.Id,
                                 Name = a.Name,
                                 Fk_ChatType = a.Fk_ChatType,
                                 MessagesCount = a.Messages.Count,
                                 MembersCount = a.ChatMembers.Count,
                                 ImageURL = a.ImageURL,
                                 IsAdmin = a.ChatMembers.Any(b => b.Fk_Account == Fk_Account && b.IsAdmin),
                                 UnReadCount = a.Messages.Count(b => b.Fk_MessageState != (int)MessageStateEnum.Readed),
                                 CreatedAt = a.CreatedAt.AddHours(2).ToString(DataManipulate.DateTimeFormat, CultureInfo.InvariantCulture),
                                 LastModifiedAt = a.LastModifiedAt.AddHours(2).ToString(DataManipulate.DateTimeFormat, CultureInfo.InvariantCulture)
                             });
        }

        public ChatModel GetChatExtraData(ChatModel chat, int Fk_Account = 0)
        {
            if (chat.MembersCount > 1 && chat.Fk_ChatType == (int)ChatTypeEnum.Private)
            {
                var otherAccount = _DBContext.ChatMember
                                             .Where(a => a.Fk_Chat == chat.Id &&
                                                         a.Fk_Account != Fk_Account)
                                             .Select(a => new
                                             {
                                                 a.Account.ImageURL,
                                                 a.Account.NickName
                                             })
                                             .FirstOrDefault();

                chat.Name = otherAccount.NickName;
                chat.ImageURL = otherAccount.ImageURL;
            }
            return chat;
        }

        public async Task UpdateLastActionAt(int id)
        {
            Chat chat = await GetByID(id);
            chat.LastModifiedAt = DateTime.Now;
            UpdateEntity(chat);
            Save();
        }
    }
}
