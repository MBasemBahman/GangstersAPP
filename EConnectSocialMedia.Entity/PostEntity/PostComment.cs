
namespace EConnectSocialMedia.Entity.PostEntity
{
    public class PostComment : FullAttachmentEntity
    {
        [ForeignKey("Post")]
        [DisplayName(nameof(Post))]
        public int Fk_Post { get; set; }

        [DisplayName("Post")]
        public Post Post { get; set; }

        [ForeignKey("Account")]
        [DisplayName(nameof(Account))]
        public int Fk_Account { get; set; }

        [DisplayName("Account")]
        public Account Account { get; set; }

        [DisplayName("Comment")]
        [DataType(DataType.MultilineText)]
        public string CommentText { get; set; }

        [ForeignKey("OldPostComment")]
        [DisplayName(nameof(OldPostComment))]
        public int? Fk_OldPostComment { get; set; }

        [DisplayName("Old Post Comment")]
        public PostComment OldPostComment { get; set; }

        [DisplayName("Shared Post Comments")]
        public ICollection<PostComment> SharedPostComments { get; set; }

        [DisplayName("Post Comment Reactions")]
        public ICollection<PostCommentReaction> PostCommentReactions { get; set; }

        [DisplayName("File URL")]
        [DataType(DataType.Url, ErrorMessage = "{0} not valid")]
        [Url]
        public new string FileURL { get; set; }

        [DisplayName("File Name")]
        public new string FileName { get; set; }

        [DisplayName("File Type")]
        public new string FileType { get; set; }

    }
}
