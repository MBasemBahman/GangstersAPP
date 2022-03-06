namespace GangstersAPP.ServiceEntity.PostEntity
{
    public class PostEditModel
    {
        [DisplayName("Post Title")]
        [DataType(DataType.MultilineText)]
        public string PostTitle { get; set; }

        [DisplayName("Post Text")]
        [DataType(DataType.MultilineText)]
        public string PostText { get; set; }
    }

    public class PostCreateModel : PostEditModel
    {
        [DisplayName("Post Type")]
        public int Fk_PostType { get; set; }

        [DisplayName("Group")]
        public int? Fk_Group { get; set; }

        [DisplayName("OldPost")]
        public int? Fk_OldPost { get; set; }

        [DisplayName("Post Attachments")]
        public ICollection<IFormFile> PostAttachments { get; set; }
    }

    public class PostModel : FullBaseEntityModel
    {
        [ForeignKey("Account")]
        [DisplayName(nameof(Account))]
        public int? Fk_Account { get; set; }

        [DisplayName("Account")]
        public AccountModel Account { get; set; }

        [ForeignKey("PostType")]
        [DisplayName("Post Type")]
        public int Fk_PostType { get; set; }

        [DisplayName("Post Type")]
        public PostTypeModel PostType { get; set; }

        [ForeignKey("Group")]
        [DisplayName("Group")]
        public int? Fk_Group { get; set; }

        [DisplayName("Group")]
        public GroupModel Group { get; set; }

        [DisplayName("Post Title")]
        [DataType(DataType.MultilineText)]
        public string PostTitle { get; set; }

        [DisplayName("Post Text")]
        [DataType(DataType.MultilineText)]
        public string PostText { get; set; }

        [ForeignKey("OldPost")]
        [DisplayName(nameof(OldPost))]
        public int? Fk_OldPost { get; set; }

        [DisplayName("Old Post")]
        public PostModel OldPost { get; set; }

        [DisplayName("Comment Count")]
        public int CommentCount { get; set; }

        [DisplayName("Reaction Count")]
        public int ReactionCount { get; set; }

        [DisplayName("Share Count")]
        public int ShareCount { get; set; }

        [DisplayName("Attachments Count")]
        public int AttachmentsCount { get; set; }

        public bool IsOwner { get; set; }

        public ReactionTypeModel MyReaction { get; set; }

        [DisplayName("Post Attachments")]
        public ICollection<PostAttachmentModel> PostAttachments { get; set; }
    }
}
