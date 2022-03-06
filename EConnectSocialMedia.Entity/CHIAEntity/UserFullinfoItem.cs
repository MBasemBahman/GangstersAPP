namespace EConnectSocialMedia.Entity.CHIAEntity
{
    public class UserFullinfoItem : FullBaseEntity
    {
        [DisplayName("Icon")]
        [DataType(DataType.ImageUrl, ErrorMessage = "{0} not valid")]
        [Url]
        public string Icon { get; set; }


        [DisplayName("Arabic URL")]
        [DataType(DataType.Url, ErrorMessage = "{0} not valid")]
        [Url]
        public string URL { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("Arabic Title")]
        public string Title { get; set; }

        public UserFullinfoItemLang UserFullinfoItemLang { get; set; }
    }

    public class UserFullinfoItemLang : FullLangEntity<UserFullinfoItem>
    {
        [Required(ErrorMessage = "Required")]
        [DisplayName("English Title")]
        public string Title { get; set; }

        [DisplayName("English URL")]
        [DataType(DataType.Url, ErrorMessage = "{0} not valid")]
        [Url]
        public string URL { get; set; }

    }

}
