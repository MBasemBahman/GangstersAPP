namespace EConnectSocialMedia.Entity.PostEntity
{
    public class PostReaction : BaseEntity
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

        [ForeignKey("ReactionType")]
        [DisplayName(nameof(ReactionType))]
        public int Fk_ReactionType { get; set; }

        [DisplayName("Reaction Type")]
        public ReactionType ReactionType { get; set; }
    }
}
