namespace GangstersAPP.ServiceEntity.MainDataEntity
{
    public class TermsAndConditionsModel : FullBaseEntityModel
    {
        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("Content")]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
    }
}
