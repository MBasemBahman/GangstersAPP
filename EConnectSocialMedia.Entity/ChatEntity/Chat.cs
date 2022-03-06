namespace EConnectSocialMedia.Entity.ChatEntity
{
    public class Chat : FullImageEntity
    {
        [DisplayName("Name")]
        public string Name { get; set; }

        [ForeignKey("ChatType")]
        [DisplayName(nameof(ChatType))]
        public int Fk_ChatType { get; set; }

        [DisplayName("Chat Type")]
        public ChatType ChatType { get; set; }

        [DisplayName("Last Action At")]
        [DataType(DataType.DateTime)]
        public DateTime LastActionAt { get; set; }

        [DisplayName("Last Action At")]
        [NotMapped]
        public string LastActionAtString => LastActionAt.AddHours(2).ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

        [DisplayName("Chat Members")]
        public ICollection<ChatMember> ChatMembers { get; set; }

        [DisplayName("Messages")]
        public ICollection<Message> Messages { get; set; }
    }
}
