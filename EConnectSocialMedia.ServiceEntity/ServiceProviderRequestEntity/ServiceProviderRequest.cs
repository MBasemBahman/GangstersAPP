namespace EConnectSocialMedia.ServiceEntity.ServiceProviderRequestEntity
{
    public class ServiceProviderRequestCreateModel
    {
        public int Fk_ServiceProviderClassification { get; set; }

        public int Fk_Governerate { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public string RefNum { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string Specialization { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string CommercialRecord { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string TaxCardNum { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DataType(DataType.PhoneNumber)]
        [Phone]
        public string Phone { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Phone]
        public string Fax { get; set; }

        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string ApplicantName { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string ApplicantJob { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string ApplicantNationalNumber { get; set; }

        [DisplayName("ContactPersonName")]
        public string ContactPersonName { get; set; }

        [DisplayName("ContactPersonPhone")]
        public string ContactPersonPhone { get; set; }
    }
    public class ServiceProviderRequestModel : FullBaseEntityModel
    {
        [DisplayName(nameof(ServiceProviderClassification))]
        [ForeignKey(nameof(ServiceProviderClassification))]
        public int Fk_ServiceProviderClassification { get; set; }

        public ServiceProviderClassificationModel ServiceProviderClassification { get; set; }

        [DisplayName(nameof(Governerate))]
        [ForeignKey(nameof(Governerate))]
        public int Fk_Governerate { get; set; }

        public GovernerateModel Governerate { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public string RefNum { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string Specialization { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string CommercialRecord { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string TaxCardNum { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DataType(DataType.PhoneNumber)]
        [Phone]
        public string Phone { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Phone]
        public string Fax { get; set; }

        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string ApplicantName { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string ApplicantJob { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string ApplicantNationalNumber { get; set; }

        [DisplayName("ContactPersonName")]
        public string ContactPersonName { get; set; }

        [DisplayName("ContactPersonPhone")]
        public string ContactPersonPhone { get; set; }

        public ICollection<ServiceProviderRequestAttachmentModel> ServiceProviderRequestAttachments { get; set; }
    }
}
