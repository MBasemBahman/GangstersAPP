namespace GangstersAPP.Repository.GroupEntity
{
    public class GroupMemberRepository : AppBaseRepository<GroupMember>
    {
        private readonly DatabaseContext _DBContext;
        private readonly IMapper _Mapper;

        public GroupMemberRepository(DatabaseContext DBContext, IMapper Mapper) : base(DBContext)
        {
            _DBContext = DBContext;
            _Mapper = Mapper;
        }

        public IQueryable<GroupMemberModel> GetMembers(Expression<Func<GroupMember, bool>> expression = null)
        {
            expression ??= (a => true);

            return _DBContext.GroupMember
                             .Where(expression)
                             .OrderByDescending(a => a.Id)
                             .Select(a => new GroupMemberModel
                             {
                                 Id = a.Id,
                                 Fk_Account = a.Fk_Account,
                                 Fk_Group = a.Fk_Group,
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


        public Group CreateEntity(Group Group, Dictionary<int, bool> Members)
        {

            if (Members != null && Members.Any())
            {
                foreach (KeyValuePair<int, bool> member in Members)
                {
                    Group.GroupMembers.Add(new GroupMember
                    {
                        Fk_Account = member.Key,
                        IsAdmin = member.Value
                    });
                }
            }
            return Group;
        }

        public Group DeleteEntity(Group Group, List<int> Fk_Accounts)
        {
            if (Fk_Accounts != null && Fk_Accounts.Any())
            {
                foreach (int Fk_Account in Fk_Accounts)
                {
                    _DBContext.GroupMember.RemoveRange(_DBContext.GroupMember.Where(a => a.Fk_Group == Group.Id && a.Fk_Account == Fk_Account).ToList());
                }
            }

            return Group;
        }

        public Group UpdateEntity(Group Group, Dictionary<int, bool> NewMembers)
        {
            if (!_DBContext.GroupMember.Any(a => a.Fk_Group == Group.Id))
            {
                Group.GroupMembers = new List<GroupMember>();
            }
            else
            {
                Group.GroupMembers = _DBContext.GroupMember.Where(a => a.Fk_Group == Group.Id).ToList();
            }


            List<int> AddData = NewMembers.Select(a => a.Key).ToList().Except(Group.GroupMembers.Select(a => a.Fk_Account).ToList()).ToList();

            List<int> RmvData = Group.GroupMembers.Select(a => a.Fk_Account).ToList().Except(NewMembers.Select(a => a.Key).ToList()).ToList();

            Dictionary<int, bool> DataToUpdate = NewMembers.Where(a => Group.GroupMembers.Select(a => a.Fk_Account).ToList().Contains(a.Key)).ToDictionary(a => a.Key, a => a.Value);

            Group = CreateEntity(Group, NewMembers.Where(a => AddData.Contains(a.Key)).ToDictionary(a => a.Key, a => a.Value));

            Group = DeleteEntity(Group, RmvData);

            if (DataToUpdate != null && DataToUpdate.Any())
            {
                foreach (KeyValuePair<int, bool> member in DataToUpdate)
                {
                    Group.GroupMembers.FirstOrDefault(a => a.Fk_Account == member.Key).IsAdmin = member.Value;
                }
            }

            return Group;
        }
    }
}
