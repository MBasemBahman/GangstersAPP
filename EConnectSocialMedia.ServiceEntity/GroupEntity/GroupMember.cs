namespace GangstersAPP.ServiceEntity.GroupEntity
{
    public class GroupMemberModel : BaseEntityModel
    {
        [ForeignKey("Group")]
        [DisplayName(nameof(Group))]
        public int Fk_Group { get; set; }

        [DisplayName("Group")]
        public GroupModel Group { get; set; }

        [ForeignKey("Account")]
        [DisplayName(nameof(Account))]
        public int Fk_Account { get; set; }

        [DisplayName("Account")]
        public AccountModel Account { get; set; }

        [DisplayName("IsAdmin")]
        public bool IsAdmin { get; set; } = false;
    }

    public class GroupMemberRemoveModel
    {
        [DisplayName("Account")]
        public int Fk_Account { get; set; }
    }

    public class GroupMemberCreateModel : GroupMemberRemoveModel
    {
        [DisplayName("IsAdmin")]
        public bool IsAdmin { get; set; } = false;
    }
}
