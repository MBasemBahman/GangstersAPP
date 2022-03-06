
namespace GangstersAPP.Entity.PostEntity
{
    public class PostAttachment : AttachmentEntity
    {
        [ForeignKey("Post")]
        [DisplayName(nameof(Post))]
        public int Fk_Post { get; set; }

        [DisplayName("Post")]
        public Post Post { get; set; }
    }
}
