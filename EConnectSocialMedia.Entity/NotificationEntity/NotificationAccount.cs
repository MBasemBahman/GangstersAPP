namespace GangstersAPP.Entity.NotificationEntity
{
    public class NotificationAccount : BaseEntity
    {
        [ForeignKey("Account")]
        [DisplayName(nameof(Account))]
        public int Fk_Account { get; set; }

        [DisplayName("Account")]
        public Account Account { get; set; }

        [ForeignKey("Notification")]
        [DisplayName(nameof(Notification))]
        public int Fk_Notification { get; set; }

        [DisplayName("Notification")]
        public Notification Notification { get; set; }
    }
}
