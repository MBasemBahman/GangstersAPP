namespace EConnectSocialMedia.Entity.CHIAEntity
{
    public class ServiceProviderAuthority : FullLookUpEntity
    {
        [DisplayName("ServiceProviders")]
        public ICollection<ServiceProvider> ServiceProviders { get; set; }

        public ServiceProviderAuthorityLang ServiceProviderAuthorityLang { get; set; }
    }

    public class ServiceProviderAuthorityLang : FullLangEntity<ServiceProviderAuthority>
    {
        [Required(ErrorMessage = "Required")]
        [DisplayName("English Name")]
        public string Name { get; set; }
    }
}
