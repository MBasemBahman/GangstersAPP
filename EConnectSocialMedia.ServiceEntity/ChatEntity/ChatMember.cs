namespace EConnectSocialMedia.ServiceEntity.ChatEntity
{
    public class ChatMemberModel : BaseEntityModel
    {
        [ForeignKey("Chat")]
        [DisplayName(nameof(Chat))]
        public int Fk_Chat { get; set; }

        [DisplayName("Chat")]
        public ChatModel Chat { get; set; }

        [ForeignKey("Account")]
        [DisplayName(nameof(Account))]
        public int Fk_Account { get; set; }

        [DisplayName("Account")]
        public AccountModel Account { get; set; }

        [DisplayName("IsAdmin")]
        public bool IsAdmin { get; set; } = false;
    }

    public class ChatMemberRemoveModel
    {
        [DisplayName("Connection Id")]
        public string ConnectionId { get; set; }

        public int Fk_Account { get; set; }
    }

    public class ChatMemberCreateModel : ChatMemberRemoveModel
    {
        [DisplayName("IsAdmin")]
        public bool IsAdmin { get; set; } = false;
    }
}
