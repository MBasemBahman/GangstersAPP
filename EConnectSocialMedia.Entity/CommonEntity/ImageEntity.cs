namespace EConnectSocialMedia.Entity.CommonEntity
{
    public interface IImageEntity
    {
        public string ImageURL { get; set; }
    }

    public class ImageEntity : BaseEntity, IImageEntity
    {
        [DisplayName("Image URL")]
        [DataType(DataType.ImageUrl, ErrorMessage = "{0} not valid")]
        [Url]
        public string ImageURL { get; set; }
    }

    public class FullImageEntity : FullBaseEntity, IImageEntity
    {
        [DisplayName("Image URL")]
        [DataType(DataType.ImageUrl, ErrorMessage = "{0} not valid")]
        [Url]
        public string ImageURL { get; set; }
    }
}
