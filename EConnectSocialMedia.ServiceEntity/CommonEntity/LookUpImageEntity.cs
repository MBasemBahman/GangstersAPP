namespace EConnectSocialMedia.ServiceEntity.CommonEntity
{
    public class LookUpImageEntityModel : FullBaseEntityModel, ILookUpEntityModel, IImageEntityModel
    {
        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("Name")]
        public string Name { get; set; }

        [DisplayName("Image URL")]
        [DataType(DataType.ImageUrl, ErrorMessage = "{0} not valid")]
        [Url]
        public string ImageURL { get; set; }
    }
}
