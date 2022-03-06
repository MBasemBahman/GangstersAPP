namespace GangstersAPP.Entity.MainDataEntity
{
    public class QuestionsAndAnswers : FullBaseEntity
    {
        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("Arabic Question")]
        public string Question { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("Arabic Answer")]
        [DataType(DataType.MultilineText)]
        public string Answer { get; set; }

        public QuestionsAndAnswersLang QuestionsAndAnswersLang { get; set; }
    }

    public class QuestionsAndAnswersLang : FullLangEntity<QuestionsAndAnswers>
    {
        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("English Question")]
        public string Question { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("English Answer")]
        [DataType(DataType.MultilineText)]
        public string Answer { get; set; }
    }
}
