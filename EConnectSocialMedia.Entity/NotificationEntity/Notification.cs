using static GangstersAPP.Entity.EntityEnum;

namespace GangstersAPP.Entity.NotificationEntity
{
    public class Notification : FullImageEntity
    {
        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("Arabic Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("Arabic Description")]
        public string Description { get; set; }

        public OpenTypeEnum OpenType { get; set; }

        public string OpenValue { get; set; }

        public bool IsPublic { get; set; }

        public ICollection<NotificationAccount> NotificationAccounts { get; set; }
    }

}
