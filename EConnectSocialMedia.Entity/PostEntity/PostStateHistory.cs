namespace GangstersAPP.Entity.PostEntity
{
    public class PostStateHistory : BaseEntity
    {
        [ForeignKey("Post")]
        [DisplayName(nameof(Post))]
        public int Fk_Post { get; set; }

        [DisplayName("Post")]
        public Post Post { get; set; }

        [ForeignKey("PostState")]
        [DisplayName("Post State")]
        public int Fk_PostState { get; set; }

        [DisplayName("Post State")]
        public PostState PostState { get; set; }

        [DisplayName("Note")]
        [DataType(DataType.MultilineText)]
        public string Note { get; set; }
    }
}
