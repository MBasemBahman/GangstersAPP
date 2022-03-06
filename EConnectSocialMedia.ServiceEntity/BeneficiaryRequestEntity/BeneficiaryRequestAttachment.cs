namespace EConnectSocialMedia.ServiceEntity.BeneficiaryRequestEntity
{
    public class BeneficiaryRequestAttachmentCreateModel
    {
        [Required(ErrorMessage = "{0} is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public IFormFile File { get; set; }
    }
    public class BeneficiaryRequestAttachmentModel : AttachmentEntityModel
    {
        [Required(ErrorMessage = "{0} is required")]
        public string Description { get; set; }
    }
}
