namespace EConnectSocialMedia.Entity.PostEntity
{
    public class PostState : FullStateEntity
    {
        [DisplayName("Posts")]
        public ICollection<Post> Posts { get; set; }

        [DisplayName("Post State Histories")]
        public ICollection<PostStateHistory> PostStateHistories { get; set; }

        public PostStateLang PostStateLang { get; set; }
    }

    public class PostStateLang : FullLangEntity<PostState>
    {
        [Required(ErrorMessage = "Required")]
        [DisplayName("English Name")]
        public string Name { get; set; }
    }
}
