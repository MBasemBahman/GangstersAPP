namespace EConnectSocialMedia.Entity.AccountEntity
{
    public class Gender : StateEntity
    {
        [DisplayName("Accounts")]
        public ICollection<Account> Accounts { get; set; }

        public GenderLang GenderLang { get; set; }
    }

    public class GenderLang : LangEntity<Gender>
    {
        [Required(ErrorMessage = "Required")]
        [DisplayName("English Name")]
        public string Name { get; set; }
    }
}
