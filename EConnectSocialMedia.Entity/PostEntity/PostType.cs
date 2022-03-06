namespace EConnectSocialMedia.Entity.PostEntity
{
    public class PostType : FullStateEntity
    {
        [DisplayName("Posts")]
        public ICollection<Post> Posts { get; set; }

        public PostTypeLang PostTypeLang { get; set; }
    }

    public class PostTypeLang : FullLangEntity<PostType>
    {
        [Required(ErrorMessage = "Required")]
        [DisplayName("English Name")]
        public string Name { get; set; }
    }
}
