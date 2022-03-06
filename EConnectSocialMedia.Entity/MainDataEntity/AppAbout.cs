namespace EConnectSocialMedia.Entity.MainDataEntity
{
    public class AppAbout : FullBaseEntity
    {
        [DisplayName("Phone")]
        [DataType(DataType.PhoneNumber)]
        [Phone]
        public string Phone { get; set; }

        [DisplayName("Email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [DisplayName("WhatsApp")]
        [DataType(DataType.PhoneNumber)]
        [Phone]
        public string WhatsApp { get; set; }

        [DisplayName("FaceBook")]
        [DataType(DataType.Url)]
        [Url]
        public string FaceBook { get; set; }

        [DisplayName("Instagram")]
        [DataType(DataType.Url)]
        [Url]
        public string Instagram { get; set; }

        [DisplayName("Website")]
        [DataType(DataType.Url)]
        [Url]
        public string WebSite { get; set; }

        [DisplayName("Support Url")]
        [DataType(DataType.Url)]
        [Url]
        public string SupportUrl { get; set; }

        [DisplayName("Android Min Version")]
        public double AndroidMinVersion { get; set; } = default;

        [DisplayName("IOS Min Version")]
        public double IOSMinVersion { get; set; } = default;
    }
}
