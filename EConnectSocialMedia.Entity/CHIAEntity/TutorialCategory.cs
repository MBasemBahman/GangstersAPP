namespace GangstersAPP.Entity.CHIAEntity
{
    public class TutorialCategory : FullLookUpEntity
    {
        [DisplayName("TutorialItems")]
        public ICollection<TutorialItem> TutorialItems { get; set; }

        public TutorialCategoryLang TutorialCategoryLang { get; set; }
    }

    public class TutorialCategoryLang : FullLangEntity<TutorialCategory>
    {
        [Required(ErrorMessage = "Required")]
        [DisplayName("English Name")]
        public string Name { get; set; }

    }
}
