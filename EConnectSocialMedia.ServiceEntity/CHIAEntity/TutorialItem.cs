namespace EConnectSocialMedia.ServiceEntity.CHIAEntity
{
    public class TutorialItemModel : FullImageEntityModel
    {
        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("Name")]
        public string Name { get; set; }

        [DisplayName("URL")]
        [DataType(DataType.Url, ErrorMessage = "{0} not valid")]
        [Url]
        public string URL { get; set; }

        [DisplayName(nameof(TutorialCategory))]
        [ForeignKey(nameof(TutorialCategory))]
        public int Fk_TutorialCategory { get; set; }

        [DisplayName("TutorialCategory")]
        public TutorialCategoryModel TutorialCategory { get; set; }
    }
}
