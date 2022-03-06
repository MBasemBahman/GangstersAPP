
namespace EConnectSocialMedia.Entity.ChatEntity
{
    public class Message : FullAttachmentEntity
    {
        [DisplayName(nameof(Chat))]
        [ForeignKey(nameof(Chat))]
        public int Fk_Chat { get; set; }

        [DisplayName("Chat")]
        public Chat Chat { get; set; }

        [DisplayName(nameof(Account))]
        [ForeignKey(nameof(Account))]
        public int Fk_Account { get; set; }

        [DisplayName("Account")]
        public Account Account { get; set; }

        [DisplayName("Message Text")]
        [DataType(DataType.MultilineText)]
        public string MessageText { get; set; }

        [DisplayName(nameof(MessageState))]
        [ForeignKey(nameof(MessageState))]
        public int Fk_MessageState { get; set; }

        [DisplayName("Message State")]
        public MessageState MessageState { get; set; }

        [DisplayName(nameof(MessageType))]
        [ForeignKey(nameof(MessageType))]
        public int Fk_MessageType { get; set; }

        [DisplayName("Message Type")]
        public MessageType MessageType { get; set; }

        [DisplayName("File URL")]
        [DataType(DataType.Url, ErrorMessage = "{0} not valid")]
        [Url]
        public new string FileURL { get; set; }

        [DisplayName("File Name")]
        public new string FileName { get; set; }

        [DisplayName("File Type")]
        public new string FileType { get; set; }
    }
}
