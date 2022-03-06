namespace GangstersAPP.Entity.ChatEntity
{
    public class MessageType : FullStateEntity
    {
        [DisplayName("Messages")]
        public ICollection<Message> Messages { get; set; }

        public MessageTypeLang MessageTypeLang { get; set; }
    }

    public class MessageTypeLang : FullLangEntity<MessageType>
    {
        [Required(ErrorMessage = "Required")]
        [DisplayName("English Name")]
        public string Name { get; set; }
    }
}
