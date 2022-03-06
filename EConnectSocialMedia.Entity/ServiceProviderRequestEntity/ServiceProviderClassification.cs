namespace GangstersAPP.Entity.ServiceProviderRequestEntity
{
    public class ServiceProviderClassification : FullLookUpEntity
    {
        [DisplayName("ServiceProviderRequests")]
        public ICollection<ServiceProviderRequest> ServiceProviderRequests { get; set; }

        public ServiceProviderClassificationLang ServiceProviderClassificationLang { get; set; }
    }

    public class ServiceProviderClassificationLang : FullLangEntity<ServiceProviderClassification>
    {
        [Required(ErrorMessage = "Required")]
        [DisplayName("English Name")]
        public string Name { get; set; }
    }
}
