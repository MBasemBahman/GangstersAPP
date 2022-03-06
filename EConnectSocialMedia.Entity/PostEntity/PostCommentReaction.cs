
namespace EConnectSocialMedia.Entity.PostEntity
{
    public class PostCommentReaction : BaseEntity
    {
        [ForeignKey("PostComment")]
        [DisplayName(nameof(PostComment))]
        public int Fk_PostComment { get; set; }

        [DisplayName("Post Comment")]
        public PostComment PostComment { get; set; }

        [ForeignKey("Account")]
        [DisplayName(nameof(Account))]
        public int Fk_Account { get; set; }

        [DisplayName("Account")]
        public Account Account { get; set; }

        [ForeignKey("ReactionType")]
        [DisplayName(nameof(ReactionType))]
        public int Fk_ReactionType { get; set; }

        [DisplayName("Reaction Type")]
        public ReactionType ReactionType { get; set; }
    }
}
