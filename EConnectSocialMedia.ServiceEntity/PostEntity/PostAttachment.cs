
namespace EConnectSocialMedia.ServiceEntity.PostEntity
{
    public class PostAttachmentCreateModel
    {
        [DisplayName("Post")]
        public int Fk_Post { get; set; }

        [DisplayName("Files")]
        public List<IFormFile> PostAttachments { get; set; }
    }
    public class PostAttachmentRemoveModel
    {
        [DisplayName("Post")]
        public int Fk_Post { get; set; }

        [DisplayName("Files Ids")]
        public List<int> AttachmentIds { get; set; }
    }

    public class PostAttachmentModel : AttachmentEntityModel
    {
        [ForeignKey("Post")]
        [DisplayName(nameof(Post))]
        public int Fk_Post { get; set; }

        [DisplayName("Post")]
        public PostModel Post { get; set; }
    }
}
