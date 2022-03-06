

namespace EConnectSocialMedia.Entity.CommonEntity
{
    [Index(nameof(Name), IsUnique = true)]
    public class LookUpImageEntity : FullBaseEntity, ILookUpEntity, IImageEntity
    {
        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("Arabic Name")]
        public string Name { get; set; }

        [DisplayName("Image URL")]
        [DataType(DataType.ImageUrl, ErrorMessage = "{0} not valid")]
        [Url]
        public string ImageURL { get; set; }
    }
}
