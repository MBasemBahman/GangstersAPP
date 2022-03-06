namespace GangstersAPP.ServiceEntity.ServiceProviderRequestEntity
{
    public class ServiceProviderRequestAttachmentCreateModel
    {
        [Required(ErrorMessage = "{0} is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public IFormFile File { get; set; }
    }

    public class ServiceProviderRequestAttachmentModel : AttachmentEntityModel
    {
        [Required(ErrorMessage = "{0} is required")]
        public string Description { get; set; }
    }
}
