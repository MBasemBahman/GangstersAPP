namespace EConnectSocialMedia.Entity.AccountEntity
{
    public class AccountType : FullStateEntity
    {
        [DisplayName("Accounts")]
        public ICollection<Account> Accounts { get; set; }

        [DisplayName("AppIntros")]
        public ICollection<AppIntro> AppIntros { get; set; }

        public AccountTypeLang AccountTypeLang { get; set; }
    }

    public class AccountTypeLang : FullLangEntity<AccountType>
    {
        [Required(ErrorMessage = "Required")]
        [DisplayName("English Name")]
        public string Name { get; set; }
    }
}