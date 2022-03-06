namespace EConnectSocialMedia.ServiceEntity.CHIAEntity
{
    public class PartnerModel : FullImageEntityModel
    {
        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("Name")]
        public string Name { get; set; }

        [DisplayName("URL")]
        [DataType(DataType.Url, ErrorMessage = "{0} not valid")]
        [Url]
        public string URL { get; set; }
    }
}
