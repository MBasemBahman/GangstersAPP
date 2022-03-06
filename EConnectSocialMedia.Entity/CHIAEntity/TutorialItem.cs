namespace EConnectSocialMedia.Entity.CHIAEntity
{
    public class TutorialItem : FullImageEntity
    {
        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("Arabic Name")]
        public string Name { get; set; }

        [DisplayName("Arabic URL")]
        [DataType(DataType.Url, ErrorMessage = "{0} not valid")]
        [Url]
        public string URL { get; set; }

        [DisplayName(nameof(TutorialCategory))]
        [ForeignKey(nameof(TutorialCategory))]
        public int Fk_TutorialCategory { get; set; }

        [DisplayName("TutorialCategory")]
        public TutorialCategory TutorialCategory { get; set; }

        public TutorialItemLang TutorialItemLang { get; set; }
    }

    public class TutorialItemLang : FullLangEntity<TutorialItem>
    {
        [Required(ErrorMessage = "Required")]
        [DisplayName("English Name")]
        public string Name { get; set; }

        [DisplayName("English URL")]
        [DataType(DataType.Url, ErrorMessage = "{0} not valid")]
        [Url]
        public string URL { get; set; }

    }
}
