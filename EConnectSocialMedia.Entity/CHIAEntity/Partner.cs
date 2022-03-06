namespace EConnectSocialMedia.Entity.CHIAEntity
{
    public class Partner : FullImageEntity
    {
        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("Arabic Name")]
        public string Name { get; set; }

        [DisplayName("Arabic URL")]
        [DataType(DataType.Url, ErrorMessage = "{0} not valid")]
        [Url]
        public string URL { get; set; }

        public PartnerLang PartnerLang { get; set; }
    }

    public class PartnerLang : FullLangEntity<Partner>
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
