
namespace EConnectSocialMedia.ServiceEntity.PostEntity
{
    public class PostCommentReactionCreateModel
    {
        [DisplayName("Post Comment")]
        public int Fk_PostComment { get; set; }

        [DisplayName("Reaction Type")]
        public int Fk_ReactionType { get; set; }
    }

    public class PostCommentReactionModel : BaseEntityModel
    {
        [ForeignKey("PostComment")]
        [DisplayName(nameof(PostComment))]
        public int Fk_PostComment { get; set; }

        [DisplayName("Post Comment")]
        public PostCommentModel PostComment { get; set; }

        [ForeignKey("Account")]
        [DisplayName(nameof(Account))]
        public int Fk_Account { get; set; }

        [DisplayName("Account")]
        public AccountModel Account { get; set; }

        [ForeignKey("ReactionType")]
        [DisplayName(nameof(ReactionType))]
        public int Fk_ReactionType { get; set; }

        [DisplayName("Reaction Type")]
        public ReactionTypeModel ReactionType { get; set; }
    }
}
