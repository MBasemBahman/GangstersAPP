namespace GangstersAPP.Repository.ChatEntity
{
    public class MessageRepository : AppBaseRepository<Message>
    {
        private readonly DatabaseContext _DBContext;
        private readonly IMapper _Mapper;

        public MessageRepository(DatabaseContext DBContext, IMapper Mapper) : base(DBContext)
        {
            _DBContext = DBContext;
            _Mapper = Mapper;
        }

        public IQueryable<MessageModel> GetMessages(Expression<Func<Message, bool>> expression = null, int fk_Account = 0)
        {
            expression ??= (a => true);

            return _DBContext.Message
                             .Where(expression)
                             .OrderByDescending(a => a.Id)
                             .Select(a => new MessageModel
                             {
                                 Id = a.Id,
                                 Fk_Account = a.Fk_Account,
                                 Fk_Chat = a.Fk_Chat,
                                 MessageText = a.MessageText,
                                 Fk_MessageState = a.Fk_MessageState,
                                 Fk_MessageType = a.Fk_MessageType,
                                 FileURL = a.FileURL,
                                 FileName = a.FileName,
                                 FileType = a.FileType,
                                 FileLength = a.FileLength,
                                 MyMessage = a.Fk_Account == fk_Account,
                                 Account = new AccountModel
                                 {
                                     Id = a.Id,
                                     FirstName = a.Account.FirstName,
                                     LastName = a.Account.LastName,
                                     NickName = a.Account.NickName,
                                     IsOnline = a.Account.IsOnline,
                                     ImageURL = a.Account.ImageURL,
                                 },
                                 CreatedAt = a.CreatedAt.AddHours(2).ToString(DataManipulate.DateTimeFormat, CultureInfo.InvariantCulture),
                             });
        }

    }
}
