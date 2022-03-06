namespace GangstersAPP.ServiceEntity.CommonEntity
{
    public interface IImageEntityModel
    {
        public string ImageURL { get; set; }
    }

    public class ImageEntityModel : BaseEntityModel, IImageEntityModel
    {
        [DisplayName("Image URL")]
        [DataType(DataType.ImageUrl, ErrorMessage = "{0} not valid")]
        [Url]
        public string ImageURL { get; set; }
    }

    public class FullImageEntityModel : FullBaseEntityModel, IImageEntityModel
    {
        [DisplayName("Image URL")]
        [DataType(DataType.ImageUrl, ErrorMessage = "{0} not valid")]
        [Url]
        public string ImageURL { get; set; }
    }
}
