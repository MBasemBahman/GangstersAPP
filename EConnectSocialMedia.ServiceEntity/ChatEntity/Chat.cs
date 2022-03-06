namespace EConnectSocialMedia.ServiceEntity.ChatEntity
{
    public class ChatModel : FullImageEntityModel
    {
        [DisplayName("Name")]
        public string Name { get; set; }

        [ForeignKey("ChatType")]
        [DisplayName(nameof(ChatType))]
        public int Fk_ChatType { get; set; }

        [DisplayName("Chat Type")]
        public ChatTypeModel ChatType { get; set; }

        [DisplayName("Last Action At")]
        [DataType(DataType.DateTime)]
        public string LastActionAt { get; set; }

        [DisplayName("Chat Members")]
        public ICollection<ChatMemberModel> ChatMembers { get; set; }

        [DisplayName("Messages")]
        public ICollection<MessageModel> Messages { get; set; }

        [DisplayName("Members Count")]
        public int MembersCount { get; set; }

        [DisplayName("Messages Count")]
        public int MessagesCount { get; set; }

        [DisplayName("Messages Count")]
        public int UnReadCount { get; set; }

        [DisplayName("IsAdmin")]
        public bool IsAdmin { get; set; }

        public MessageModel LastMessage { get; set; }
    }

    public class ChatCreateModel : ChatEditModel
    {
        [DisplayName("Chat Members")]
        public ICollection<int> ChatMembers { get; set; }
    }

    public class ChatEditModel
    {
        [DisplayName("Name")]
        public string Name { get; set; }

        [DisplayName("Chat Type")]
        public int Fk_ChatType { get; set; }

        public IFormFile ImageFile { get; set; }
    }
}
