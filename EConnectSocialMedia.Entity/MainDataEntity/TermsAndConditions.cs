namespace GangstersAPP.Entity.MainDataEntity
{
    public class TermsAndConditions : FullBaseEntity
    {
        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("Arabic Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("Arabic Content")]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        public TermsAndConditionsLang TermsAndConditionsLang { get; set; }
    }

    public class TermsAndConditionsLang : FullLangEntity<TermsAndConditions>
    {
        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("English Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("English Content")]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
    }
}
