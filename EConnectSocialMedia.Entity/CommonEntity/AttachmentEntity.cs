namespace EConnectSocialMedia.Entity.CommonEntity
{
    public interface IAttachmentEntity
    {
        public string FileName { get; set; }

        public string FileType { get; set; }

        public double FileLength { get; set; }

        public string FileURL { get; set; }
    }

    public class AttachmentEntity : BaseEntity, IAttachmentEntity
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

    public class FullAttachmentEntity : FullBaseEntity, IAttachmentEntity
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
