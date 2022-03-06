namespace EConnectSocialMedia.Repository.ChatEntity
{
    public class ChatMemberRepository : AppBaseRepository<ChatMember>
    {
        private readonly DatabaseContext _DBContext;
        private readonly IMapper _Mapper;

        public ChatMemberRepository(DatabaseContext DBContext, IMapper Mapper) : base(DBContext)
        {
            _DBContext = DBContext;
            _Mapper = Mapper;
        }

        public IQueryable<ChatMemberModel> GetMembers(Expression<Func<ChatMember, bool>> expression = null)
        {
            expression ??= (a => true);

            return _DBContext.ChatMember
                             .Where(expression)
                             .OrderByDescending(a => a.Id)
                             .Select(a => new ChatMemberModel
                             {
                                 Id = a.Id,
                                 Fk_Account = a.Fk_Account,
                                 Fk_Chat = a.Fk_Chat,
                                 IsAdmin = a.IsAdmin,
                                 Account = new AccountModel
                                 {
                                     Id = a.Account.Id,
                                     FirstName = a.Account.FirstName,
                                     LastName = a.Account.LastName,
                                     NickName = a.Account.NickName,
                                     IsOnline = a.Account.IsOnline,
                                     ImageURL = a.Account.ImageURL,
                                 }
                             });
        }
    }
}
