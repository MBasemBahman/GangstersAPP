namespace GangstersAPP.Entity.AccountEntity
{
    public class AccountState : FullStateEntity
    {
        [DisplayName("Accounts")]
        public ICollection<Account> Accounts { get; set; }

        public AccountStateLang AccountStateLang { get; set; }
    }

    public class AccountStateLang : FullLangEntity<AccountState>
    {
        [Required(ErrorMessage = "Required")]
        [DisplayName("English Name")]
        public string Name { get; set; }
    }
}