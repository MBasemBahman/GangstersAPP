namespace EConnectSocialMedia.ServiceEntity.MainDataEntity
{
    public class AppIntroModel : FullImageEntityModel
    {
        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [DisplayName(nameof(AccountType))]
        [ForeignKey("AccountType")]
        public int Fk_AccountType { get; set; }

        [DisplayName("Account Type")]
        public AccountTypeModel AccountType { get; set; }
    }
}
