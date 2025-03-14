﻿namespace GangstersAPP.ServiceEntity.AccountEntity
{
    public class AccountDeviceCreateModel
    {
        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("Notification Token")]
        public string NotificationToken { get; set; }

        [DisplayName("Device Type")]
        public string DeviceType { get; set; }

        [DisplayName("App Version")]
        public string AppVersion { get; set; }

        [DisplayName("Device Version")]
        public string DeviceVersion { get; set; }

        [DisplayName("Device Model")]
        public string DeviceModel { get; set; }
    }

    public class AccountDeviceModel : BaseEntityModel
    {
        [ForeignKey("Account")]
        [DisplayName(nameof(Account))]
        public int Fk_Account { get; set; }

        [DisplayName("Account")]
        public AccountModel Account { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("Notification Token")]
        public string NotificationToken { get; set; }

        [DisplayName("Device Type")]
        public string DeviceType { get; set; }

        [DisplayName("App Version")]
        public string AppVersion { get; set; }

        [DisplayName("Device Version")]
        public string DeviceVersion { get; set; }

        [DisplayName("Device Model")]
        public string DeviceModel { get; set; }
    }
}
