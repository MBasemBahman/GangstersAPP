namespace EConnectSocialMedia.Entity.CHIAEntity
{
    public class ServiceProvider : FullImageEntity
    {
        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("Arabic Name")]
        public string Name { get; set; }

        [DisplayName("Arabic Address")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [DisplayName("Phone")]
        [DataType(DataType.PhoneNumber)]
        [Phone]
        public string Phone { get; set; }

        [DisplayName("Latitude")]
        public decimal Latitude { get; set; }

        [DisplayName("Longitude")]
        public decimal Longitude { get; set; }

        [DisplayName(nameof(ServiceProviderCategory))]
        [ForeignKey(nameof(ServiceProviderCategory))]
        public int Fk_ServiceProviderCategory { get; set; }

        [DisplayName("ServiceProviderCategory")]
        public ServiceProviderCategory ServiceProviderCategory { get; set; }

        [DisplayName(nameof(ServiceProviderAuthority))]
        [ForeignKey(nameof(ServiceProviderAuthority))]
        public int? Fk_ServiceProviderAuthority { get; set; }

        [DisplayName("ServiceProviderAuthority")]
        public ServiceProviderAuthority ServiceProviderAuthority { get; set; }

        public ServiceProviderLang ServiceProviderLang { get; set; }
    }


    public class ServiceProviderLang : FullLangEntity<ServiceProvider>
    {
        [Required(ErrorMessage = "Required")]
        [DisplayName("English Name")]
        public string Name { get; set; }

        [DisplayName("English Address")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

    }
}
