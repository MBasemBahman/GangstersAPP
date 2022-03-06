namespace GangstersAPP.ServiceEntity.CHIAEntity
{
    public class ServiceProviderModel : FullImageEntityModel
    {
        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("Name")]
        public string Name { get; set; }

        [DisplayName("Address")]
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
        public ServiceProviderCategoryModel ServiceProviderCategory { get; set; }

        [DisplayName(nameof(ServiceProviderAuthority))]
        [ForeignKey(nameof(ServiceProviderAuthority))]
        public int? Fk_ServiceProviderAuthority { get; set; }

        [DisplayName("ServiceProviderAuthority")]
        public ServiceProviderAuthorityModel ServiceProviderAuthority { get; set; }
    }
}
