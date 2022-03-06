namespace EConnectSocialMedia.ServiceEntity.CommonEntity
{
    public interface IAttachmentEntityModel
    {
        public string FileName { get; set; }

        public string FileType { get; set; }

        public double FileLength { get; set; }

        public string FileURL { get; set; }
    }

    public class AttachmentEntityModel : BaseEntityModel, IAttachmentEntityModel
    {
        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("File Name")]
        public string FileName { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("File Type")]
        public string FileType { get; set; }

        [DisplayName("File Size")]
        public double FileLength { get; set; } = default;

        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("File URL")]
        [DataType(DataType.Url, ErrorMessage = "{0} not valid")]
        [Url]
        public string FileURL { get; set; }
    }

    public class FullAttachmentEntityModel : FullBaseEntityModel, IAttachmentEntityModel
    {
        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("File Name")]
        public string FileName { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("File Type")]
        public string FileType { get; set; }

        [DisplayName("File Size")]
        public double FileLength { get; set; } = default;

        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("File URL")]
        [DataType(DataType.Url, ErrorMessage = "{0} not valid")]
        [Url]
        public string FileURL { get; set; }
    }
}
