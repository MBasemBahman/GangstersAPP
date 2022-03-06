namespace EConnectSocialMedia.Entity.ChatEntity
{
    public class ChatType : FullStateEntity
    {
        [DisplayName("Chats")]
        public ICollection<Chat> Chats { get; set; }

        public ChatTypeLang ChatTypeLang { get; set; }
    }

    public class ChatTypeLang : FullLangEntity<ChatType>
    {
        [Required(ErrorMessage = "Required")]
        [DisplayName("English Name")]
        public string Name { get; set; }
    }
}
