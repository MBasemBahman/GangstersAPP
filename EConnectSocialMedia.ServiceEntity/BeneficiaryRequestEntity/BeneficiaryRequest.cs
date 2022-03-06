namespace EConnectSocialMedia.ServiceEntity.BeneficiaryRequestEntity
{
    public class BeneficiaryRequestCreateModel
    {
        public int Fk_BeneficiaryType { get; set; }
        public int Fk_Governerate { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public string RefNum { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DataType(DataType.PhoneNumber)]
        [Phone]
        public string Phone { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string ApplicantName { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string ApplicantNationalNumber { get; set; }

    }
    public class BeneficiaryRequestModel : FullBaseEntityModel
    {
        [DisplayName(nameof(BeneficiaryType))]
        [ForeignKey(nameof(BeneficiaryType))]
        public int Fk_BeneficiaryType { get; set; }

        [DisplayName("BeneficiaryType")]
        public BeneficiaryTypeModel BeneficiaryType { get; set; }

        [DisplayName(nameof(Governerate))]
        [ForeignKey(nameof(Governerate))]
        public int Fk_Governerate { get; set; }

        [DisplayName("Governerate")]
        public GovernerateModel Governerate { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Request Date")]
        public DateTime Date { get; set; }

        [DisplayName("Request Num")]
        public string RefNum { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DataType(DataType.MultilineText)]
        [DisplayName("Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DataType(DataType.PhoneNumber)]
        [Phone]
        [DisplayName("Phone Num")]
        public string Phone { get; set; }

        [DataType(DataType.MultilineText)]
        [DisplayName("Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("ApplicantName")]
        public string ApplicantName { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("ApplicantNationalNumber")]
        public string ApplicantNationalNumber { get; set; }

        [DisplayName("BeneficiaryRequestAttachments")]
        public ICollection<BeneficiaryRequestAttachmentModel> BeneficiaryRequestAttachments { get; set; }
    }
}
