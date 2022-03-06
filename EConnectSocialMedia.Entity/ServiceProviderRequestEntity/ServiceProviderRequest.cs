using EConnectSocialMedia.Entity.LocationEntity;

namespace EConnectSocialMedia.Entity.ServiceProviderRequestEntity
{
    public class ServiceProviderRequest : FullBaseEntity
    {
        [DisplayName(nameof(Account))]
        [ForeignKey(nameof(Account))]
        public int Fk_Account { get; set; }

        [DisplayName("Account")]
        public Account Account { get; set; }

        [DisplayName(nameof(ServiceProviderClassification))]
        [ForeignKey(nameof(ServiceProviderClassification))]
        public int Fk_ServiceProviderClassification { get; set; }

        [DisplayName("ServiceProviderClassification")]
        public ServiceProviderClassification ServiceProviderClassification { get; set; }

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
        [DisplayName("Entity Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("Specialization")]
        public string Specialization { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DataType(DataType.MultilineText)]
        [DisplayName("Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("CommercialRecord")]
        public string CommercialRecord { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("TaxCardNum")]
        public string TaxCardNum { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DataType(DataType.PhoneNumber)]
        [Phone]
        [DisplayName("Phone Num")]
        public string Phone { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Phone]
        [DisplayName("Fax")]
        public string Fax { get; set; }

        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("ApplicantName")]
        public string ApplicantName { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("ApplicantJob")]
        public string ApplicantJob { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("ApplicantNationalNumber")]
        public string ApplicantNationalNumber { get; set; }

        [DisplayName("ContactPersonName")]
        public string ContactPersonName { get; set; }

        [DisplayName("ContactPersonPhone")]
        public string ContactPersonPhone { get; set; }

        [DisplayName("ServiceProviderRequestAttachments")]
        public ICollection<ServiceProviderRequestAttachment> ServiceProviderRequestAttachments { get; set; }

        [NotMapped]
        public string DateString => Date.AddHours(2).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
    }
}
