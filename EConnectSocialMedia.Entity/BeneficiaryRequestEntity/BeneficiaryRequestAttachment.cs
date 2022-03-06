namespace GangstersAPP.Entity.BeneficiaryRequestEntity
{
    public class BeneficiaryRequestAttachment : AttachmentEntity
    {
        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("Description")]
        public string Description { get; set; }

        [DisplayName(nameof(BeneficiaryRequest))]
        [ForeignKey(nameof(BeneficiaryRequest))]
        public int Fk_BeneficiaryRequest { get; set; }

        public BeneficiaryRequest BeneficiaryRequest { get; set; }
    }
}
