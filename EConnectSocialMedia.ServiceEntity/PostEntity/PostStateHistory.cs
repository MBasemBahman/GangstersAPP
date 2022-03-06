namespace EConnectSocialMedia.ServiceEntity.PostEntity
{
    public class PostStateHistoryModel : BaseEntityModel
    {
        [ForeignKey("Post")]
        [DisplayName(nameof(Post))]
        public int Fk_Post { get; set; }

        [DisplayName("Post")]
        public PostModel Post { get; set; }

        [ForeignKey("PostState")]
        [DisplayName("Post State")]
        public int Fk_PostState { get; set; }

        [DisplayName("PostState")]
        public PostStateModel PostState { get; set; }

        [DisplayName("Note")]
        [DataType(DataType.MultilineText)]
        public string Note { get; set; }
    }
}
