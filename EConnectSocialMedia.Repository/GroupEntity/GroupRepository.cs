
namespace GangstersAPP.Repository.GroupEntity
{
    public class GroupRepository : AppBaseRepository<Group>
    {
        private readonly DatabaseContext _DBContext;
        private readonly IMapper _Mapper;

        public GroupRepository(DatabaseContext DBContext, IMapper Mapper) : base(DBContext)
        {
            _DBContext = DBContext;
            _Mapper = Mapper;
        }

        public IQueryable<GroupModel> GetGroups(Expression<Func<Group, bool>> expression = null)
        {
            expression ??= (a => true);

            return _DBContext.Group
                             .Where(expression)
                             .OrderByDescending(a => a.Id)
                             .Select(a => new GroupModel
                             {
                                 Id = a.Id,
                                 Name = a.Name,
                                 Fk_GroupType = a.Fk_GroupType,
                                 ImageURL = a.ImageURL,
                                 PostsCount = a.Posts.Count,
                                 MembersCount = a.GroupMembers.Count,
                                 CreatedAt = a.CreatedAt.AddHours(2).ToString(DataManipulate.DateTimeFormat, CultureInfo.InvariantCulture),
                                 LastModifiedAt = a.LastModifiedAt.AddHours(2).ToString(DataManipulate.DateTimeFormat, CultureInfo.InvariantCulture)
                             });
        }
    }
}
