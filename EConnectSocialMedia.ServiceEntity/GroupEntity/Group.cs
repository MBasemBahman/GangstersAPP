namespace GangstersAPP.ServiceEntity.GroupEntity
{
    public class GroupModel : FullImageEntityModel
    {
        [DisplayName("Name")]
        public string Name { get; set; }

        [ForeignKey("GroupType")]
        [DisplayName("Group Type")]
        public int Fk_GroupType { get; set; }

        [DisplayName("Group Type")]
        public GroupTypeModel GroupType { get; set; }

        [DisplayName("Group Members")]
        public ICollection<GroupMemberModel> GroupMembers { get; set; }

        [DisplayName("Posts")]
        public ICollection<PostModel> Posts { get; set; }

        [DisplayName("Members Count")]
        public int MembersCount { get; set; }

        [DisplayName("Posts Counts")]
        public int PostsCount { get; set; }
    }

    public class GroupCreateModel : GroupEditModel
    {
        [DisplayName("Group Members")]
        public List<int> GroupMembers { get; set; }
    }

    public class GroupEditModel
    {
        [DisplayName("Name")]
        public string Name { get; set; }

        [DisplayName("Image")]
        public IFormFile ImageURL { get; set; }

        [DisplayName("Group Type")]
        public int Fk_GroupType { get; set; }
    }
}
