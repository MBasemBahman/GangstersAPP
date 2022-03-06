namespace GangstersAPP.Entity.ServiceProviderRequestEntity
{
    public class ServiceProviderRequestAttachment : AttachmentEntity
    {
        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("Description")]
        public string Description { get; set; }

        [DisplayName(nameof(ServiceProviderRequest))]
        [ForeignKey(nameof(ServiceProviderRequest))]
        public int Fk_ServiceProviderRequest { get; set; }

        public ServiceProviderRequest ServiceProviderRequest { get; set; }
    }
}
