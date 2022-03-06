namespace GangstersAPP.Entity.BeneficiaryRequestEntity
{
    public class BeneficiaryType : FullLookUpEntity
    {
        [DisplayName(nameof(BeneficiaryRequests))]
        public ICollection<BeneficiaryRequest> BeneficiaryRequests { get; set; }

        public BeneficiaryTypeLang BeneficiaryTypeLang { get; set; }
    }

    public class BeneficiaryTypeLang : FullLangEntity<BeneficiaryType>
    {
        [Required(ErrorMessage = "Required")]
        [DisplayName("English Name")]
        public string Name { get; set; }
    }
}
