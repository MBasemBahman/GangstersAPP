namespace EConnectSocialMedia.Entity.ChatEntity
{
    public class MessageState : FullStateEntity
    {
        [DisplayName("Messages")]
        public ICollection<Message> Messages { get; set; }

        public MessageStateLang MessageStateLang { get; set; }
    }

    public class MessageStateLang : FullLangEntity<MessageState>
    {
        [Required(ErrorMessage = "Required")]
        [DisplayName("English Name")]
        public string Name { get; set; }
    }
}
