namespace EConnectSocialMedia.Entity.MainDataEntity
{
    public class AppIntro : FullImageEntity
    {
        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("Arabic Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("Arabic Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [DisplayName(nameof(AccountType))]
        [ForeignKey("AccountType")]
        public int Fk_AccountType { get; set; }

        [DisplayName("Account Type")]
        public AccountType AccountType { get; set; }

        public AppIntroLang AppIntroLang { get; set; }
    }

    public class AppIntroLang : FullLangEntity<AppIntro>
    {
        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("English Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("English Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }
}
