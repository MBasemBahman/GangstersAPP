namespace EConnectSocialMedia.ServiceEntity.MainDataEntity
{
    public class QuestionsAndAnswersModel : FullBaseEntityModel
    {
        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("Question")]
        public string Question { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("Answer")]
        [DataType(DataType.MultilineText)]
        public string Answer { get; set; }
    }
}
