
namespace GangstersAPP.ServiceEntity.ChatEntity
{
    public class MessageModel : AttachmentEntityModel
    {
        [DisplayName(nameof(Chat))]
        [ForeignKey(nameof(Chat))]
        public int Fk_Chat { get; set; }

        [DisplayName("Chat")]
        public ChatModel Chat { get; set; }

        [DisplayName(nameof(Account))]
        [ForeignKey(nameof(Account))]
        public int Fk_Account { get; set; }

        [DisplayName("Account")]
        public AccountModel Account { get; set; }

        [DisplayName("Message Text")]
        [DataType(DataType.MultilineText)]
        public string MessageText { get; set; }

        [DisplayName(nameof(MessageState))]
        [ForeignKey(nameof(MessageState))]
        public int Fk_MessageState { get; set; }

        [DisplayName("Message State")]
        public MessageStateModel MessageState { get; set; }

        [DisplayName(nameof(MessageType))]
        [ForeignKey(nameof(MessageType))]
        public int Fk_MessageType { get; set; }

        [DisplayName("Message Type")]
        public MessageTypeModel MessageType { get; set; }

        public bool MyMessage { get; set; }
    }


    public class MessageCreateModel
    {
        [Required]
        [DisplayName("Connection Id")]
        public string ConnectionId { get; set; }

        [DisplayName("Chat")]
        public int Fk_Chat { get; set; }

        [DisplayName("Message Text")]
        [DataType(DataType.MultilineText)]
        public string MessageText { get; set; }

        [DisplayName("Message State")]
        public int Fk_MessageState { get; set; }

        [DisplayName("Message Type")]
        public int Fk_MessageType { get; set; }

        [DisplayName("File URL")]
        public IFormFile FileURL { get; set; }
    }


    public class MessageEditModel
    {
        [DisplayName("Message State")]
        public int Fk_MessageState { get; set; }
    }
}
