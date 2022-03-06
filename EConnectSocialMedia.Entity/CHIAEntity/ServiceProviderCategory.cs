namespace GangstersAPP.Entity.CHIAEntity
{
    public class ServiceProviderCategory : FullLookUpEntity
    {
        [DisplayName("ServiceProviders")]
        public ICollection<ServiceProvider> ServiceProviders { get; set; }

        public ServiceProviderCategoryLang ServiceProviderCategoryLang { get; set; }
    }

    public class ServiceProviderCategoryLang : FullLangEntity<ServiceProviderCategory>
    {
        [Required(ErrorMessage = "Required")]
        [DisplayName("English Name")]
        public string Name { get; set; }

    }
}
