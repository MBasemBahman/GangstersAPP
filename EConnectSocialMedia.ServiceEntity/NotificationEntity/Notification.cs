namespace GangstersAPP.ServiceEntity.NotificationEntity
{
    public class NotificationModel : FullImageEntityModel
    {
        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("Description")]
        public string Description { get; set; }

        public int OpenType { get; set; }

        public string OpenValue { get; set; }
    }
}
