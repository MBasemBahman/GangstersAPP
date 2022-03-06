namespace EConnectSocialMedia.Entity.PostEntity
{
    public class ReactionType : FullLookUpEntity, IImageEntity
    {
        [DisplayName("Image URL")]
        [DataType(DataType.ImageUrl, ErrorMessage = "{0} not valid")]
        [Url]
        public string ImageURL { get; set; }

        [DisplayName("Post Reactions")]
        public ICollection<PostReaction> PostReactions { get; set; }

        [DisplayName("Post Comment Reactions")]
        public ICollection<PostCommentReaction> PostCommentReactions { get; set; }

        public ReactionTypeLang ReactionTypeLang { get; set; }
    }

    public class ReactionTypeLang : FullLangEntity<ReactionType>
    {
        [Required(ErrorMessage = "Required")]
        [DisplayName("English Name")]
        public string Name { get; set; }
    }
}
