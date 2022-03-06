namespace GangstersAPP.Entity.GroupEntity
{
    public class GroupMember : BaseEntity
    {
        [ForeignKey("Group")]
        [DisplayName(nameof(Group))]
        public int Fk_Group { get; set; }

        [DisplayName("Group")]
        public Group Group { get; set; }

        [ForeignKey("Account")]
        [DisplayName(nameof(Account))]
        public int Fk_Account { get; set; }

        [DisplayName("Account")]
        public Account Account { get; set; }

        [DisplayName("IsAdmin")]
        public bool IsAdmin { get; set; } = false;
    }
}
