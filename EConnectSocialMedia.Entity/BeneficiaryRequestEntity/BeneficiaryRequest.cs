using EConnectSocialMedia.Entity.LocationEntity;

namespace EConnectSocialMedia.Entity.BeneficiaryRequestEntity
{
    public class BeneficiaryRequest : FullBaseEntity
    {
        [DisplayName(nameof(Account))]
        [ForeignKey(nameof(Account))]
        public int Fk_Account { get; set; }

        [DisplayName("Account")]
        public Account Account { get; set; }

        [DisplayName(nameof(BeneficiaryType))]
        [ForeignKey(nameof(BeneficiaryType))]
        public int Fk_BeneficiaryType { get; set; }

        [DisplayName("BeneficiaryType")]
        public BeneficiaryType BeneficiaryType { get; set; }

        [DisplayName(nameof(Governerate))]
        [ForeignKey(nameof(Governerate))]
        public int Fk_Governerate { get; set; }

        [DisplayName("Governerate")]
        public Governerate Governerate { get; set; }

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
        public ICollection<BeneficiaryRequestAttachment> BeneficiaryRequestAttachments { get; set; }

        [NotMapped]
        public string DateString => Date.AddHours(2).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
    }
}
