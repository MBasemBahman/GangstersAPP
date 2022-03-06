
namespace GangstersAPP.ServiceEntity.PostEntity
{
    public class PostCommentCreateModel
    {
        [DisplayName("Post")]
        public int Fk_Post { get; set; }

        [DisplayName("OldPostComment")]
        public int? Fk_OldPostComment { get; set; }

        [DisplayName("Comment")]
        [DataType(DataType.MultilineText)]
        public string CommentText { get; set; }

        [DisplayName("File URL")]
        public IFormFile FileURL { get; set; }

    }

    public class PostCommentEditModel
    {
        [DisplayName("Comment")]
        [DataType(DataType.MultilineText)]
        public string CommentText { get; set; }

        [DisplayName("File URL")]
        public IFormFile FileURL { get; set; }

        public bool RemoveImage { get; set; }
    }

    public class PostCommentModel : FullAttachmentEntityModel
    {
        [ForeignKey("Post")]
        [DisplayName(nameof(Post))]
        public int Fk_Post { get; set; }

        [DisplayName("Post")]
        public PostModel Post { get; set; }

        [ForeignKey("Account")]
        [DisplayName(nameof(Account))]
        public int Fk_Account { get; set; }

        [DisplayName("Account")]
        public AccountModel Account { get; set; }

        [DisplayName("Comment")]
        [DataType(DataType.MultilineText)]
        public string CommentText { get; set; }

        [DisplayName("Reaction Count")]
        public int ReactionCount { get; set; }

        [DisplayName("Replay Count")]
        public int ReplayCount { get; set; }

        [ForeignKey("OldPostComment")]
        [DisplayName(nameof(OldPostComment))]
        public int? Fk_OldPostComment { get; set; }

        [DisplayName("Old Post Comment")]
        public PostCommentModel OldPostComment { get; set; }

        public bool IsOwner { get; set; }

        public ReactionTypeModel MyReaction { get; set; }
    }
}
