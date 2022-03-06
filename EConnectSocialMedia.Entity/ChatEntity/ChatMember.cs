namespace GangstersAPP.Entity.ChatEntity
{
    public class ChatMember : BaseEntity
    {
        [ForeignKey("Chat")]
        [DisplayName(nameof(Chat))]
        public int Fk_Chat { get; set; }

        [DisplayName("Chat")]
        public Chat Chat { get; set; }

        [ForeignKey("Account")]
        [DisplayName(nameof(Account))]
        public int Fk_Account { get; set; }

        [DisplayName("Account")]
        public Account Account { get; set; }

        [DisplayName("IsAdmin")]
        public bool IsAdmin { get; set; } = false;
    }
}
