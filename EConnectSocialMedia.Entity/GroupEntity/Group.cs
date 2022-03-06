namespace GangstersAPP.Entity.GroupEntity
{
    public class Group : FullImageEntity
    {
        [DisplayName("Name")]
        public string Name { get; set; }

        [ForeignKey("GroupType")]
        [DisplayName("Group Type")]
        public int Fk_GroupType { get; set; }

        [DisplayName("Group Type")]
        public GroupType GroupType { get; set; }

        [DisplayName("Group Members")]
        public ICollection<GroupMember> GroupMembers { get; set; }

        [DisplayName("Posts")]
        public ICollection<Post> Posts { get; set; }

    }
}
