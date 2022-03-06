namespace GangstersAPP.ServiceEntity.PostEntity
{
    public class PostReactionCreateModel
    {
        [DisplayName("Post")]
        public int Fk_Post { get; set; }

        [DisplayName("Reaction Type")]
        public int Fk_ReactionType { get; set; }
    }

    public class PostReactionModel : BaseEntityModel
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

        [ForeignKey("ReactionType")]
        [DisplayName(nameof(ReactionType))]
        public int Fk_ReactionType { get; set; }

        [DisplayName("Reaction Type")]
        public ReactionTypeModel ReactionType { get; set; }
    }
}
