namespace GangstersAPP.Entity.PostEntity
{
    public class Post : FullBaseEntity
    {
        [ForeignKey("Account")]
        [DisplayName(nameof(Account))]
        public int? Fk_Account { get; set; }

        [DisplayName("Account")]
        public Account Account { get; set; }

        [ForeignKey("PostType")]
        [DisplayName("Post Type")]
        public int Fk_PostType { get; set; }

        [DisplayName("Post Type")]
        public PostType PostType { get; set; }

        [ForeignKey("PostState")]
        [DisplayName("Post State")]
        public int Fk_PostState { get; set; }

        [DisplayName("Post State")]
        public PostState PostState { get; set; }

        [ForeignKey("Group")]
        [DisplayName("Group")]
        public int? Fk_Group { get; set; }

        [DisplayName("Group")]
        public Group Group { get; set; }

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
        public Post OldPost { get; set; }

        [DisplayName("Shared Posts")]
        public ICollection<Post> SharedPosts { get; set; }

        [DisplayName("Post Attachments")]
        public ICollection<PostAttachment> PostAttachments { get; set; }

        [DisplayName("Post Comments")]
        public ICollection<PostComment> PostComments { get; set; }

        [DisplayName("Post Reactions")]
        public ICollection<PostReaction> PostReactions { get; set; }

        [DisplayName("Post State Histories")]
        public ICollection<PostStateHistory> PostStateHistories { get; set; }
    }
}
