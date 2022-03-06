namespace EConnectSocialMedia.ServiceEntity.CHIAEntity
{
    public class UserFullinfoItemModel : FullBaseEntityModel
    {
        [DisplayName("Icon")]
        [DataType(DataType.ImageUrl, ErrorMessage = "{0} not valid")]
        [Url]
        public string Icon { get; set; }


        [DisplayName("URL")]
        [DataType(DataType.Url, ErrorMessage = "{0} not valid")]
        [Url]
        public string URL { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("Title")]
        public string Title { get; set; }
    }


}
