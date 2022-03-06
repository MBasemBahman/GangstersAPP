namespace EConnectSocialMedia.ServiceEntity.AccountEntity
{
    public class AccountModel : FullImageEntityModel
    {
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Full Name")]
        [NotMapped]
        public string FullName => FirstName + LastName;

        [DisplayName("Nick Name")]
        public string NickName { get; set; }

        [DisplayName("Unique Name")]
        public string UniqueName { get; set; }

        [DisplayName("Phone")]
        [DataType(DataType.PhoneNumber)]
        [Phone]
        public string Phone { get; set; }

        [DisplayName("Email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [DisplayName("Culture")]
        public string Culture { get; set; } = "en";

        [DisplayName("IsTesting")]
        public bool IsTesting { get; set; }

        [DisplayName("Birth Date")]
        public DateTime? BirthDate { get; set; }

        [DisplayName(nameof(Gender))]
        [ForeignKey("Gender")]
        public int? Fk_Gender { get; set; }

        [DisplayName("Gender")]
        public GenderModel Gender { get; set; }

        [DisplayName("National ID")]
        public string NationalID { get; set; }

        [DisplayName(nameof(AccountType))]
        [ForeignKey("AccountType")]
        public int Fk_AccountType { get; set; }

        [DisplayName("Account Type")]
        public AccountTypeModel AccountType { get; set; }

        [DisplayName(nameof(AccountState))]
        [ForeignKey("AccountState")]
        public int Fk_AccountState { get; set; }

        [DisplayName("Account State")]
        public AccountStateModel AccountState { get; set; }

        [DisplayName("BIO")]
        [DataType(DataType.MultilineText)]
        public string BIO { get; set; }

        [DisplayName("About")]
        [DataType(DataType.MultilineText)]
        public string About { get; set; }

        [DisplayName("IsOnline")]
        public bool IsOnline { get; set; } = default;

        [DisplayName("IsVerified")]
        public bool IsVerified { get; set; } = default;

        public int? Fk_Chat { get; set; }

        public bool IsOwner { get; set; }
    }

    public class RegisterModel
    {
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Nick Name")]
        public string NickName { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("Phone")]
        [DataType(DataType.PhoneNumber)]
        [Phone]
        public string Phone { get; set; }

        [DisplayName("Email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [DisplayName("Culture")]
        public string Culture { get; set; } = "en";

        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("Password")]
        [DataType(DataType.Password)]
        [PasswordPropertyText]
        public string Password { get; set; }

        [DisplayName("IsTesting")]
        public bool IsTesting { get; set; }

        [DisplayName("Birth Date")]
        public DateTime? BirthDate { get; set; }

        [DisplayName("Gender")]
        public int? Fk_Gender { get; set; }

        [DisplayName("National ID")]
        public string NationalID { get; set; }

        [DisplayName("Account Type")]
        public int Fk_AccountType { get; set; }

        [DisplayName("BIO")]
        [DataType(DataType.MultilineText)]
        public string BIO { get; set; }

        [DisplayName("About")]
        [DataType(DataType.MultilineText)]
        public string About { get; set; }
    }

    public class AccountEditStateModel
    {
        public int Fk_Account { get; set; }

        public int Fk_AccountState { get; set; }
    }

    public class AccountEditModel
    {
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Nick Name")]
        public string NickName { get; set; }

        [DisplayName("Unique Name")]
        public string UniqueName { get; set; }

        [DisplayName("Email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [DisplayName("Culture")]
        public string Culture { get; set; } = "en";

        [DisplayName("Birth Date")]
        public DateTime? BirthDate { get; set; }

        [DisplayName("Gender")]
        public int? Fk_Gender { get; set; }

        [DisplayName("National ID")]
        public string NationalID { get; set; }

        [DisplayName("BIO")]
        [DataType(DataType.MultilineText)]
        public string BIO { get; set; }

        [DisplayName("About")]
        [DataType(DataType.MultilineText)]
        public string About { get; set; }
    }

    public class EditPhoneModel
    {
        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("Phone")]
        [DataType(DataType.PhoneNumber)]
        [Phone]
        public string Phone { get; set; }
    }

    public class SetVerificationCodeModel
    {
        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("Verification Code")]
        public string VerificationCode { get; set; }
    }

    public class VerifyPhoneModel : EditPhoneModel
    {
        [DisplayName("Code")]
        [Required(ErrorMessage = "{0} is required")]
        public string Code { get; set; }
    }

    public class ProfileImageModel
    {
        [Required(ErrorMessage = "The {0} field is required")]
        [DisplayName("Profile Image")]
        public IFormFile ProfileImage { get; set; }
    }

    public class ChangePasswordModel
    {
        [DisplayName("Old Password")]
        [Required(ErrorMessage = "{0} is required")]
        [DataType(DataType.Password)]
        [PasswordPropertyText]
        public string OldPassword { get; set; }

        [DisplayName("New Password")]
        [Required(ErrorMessage = "{0} is required")]
        [DataType(DataType.Password)]
        [PasswordPropertyText]
        public string NewPassword { get; set; }
    }

    public class ForgetPasswordModel
    {
        [Required(ErrorMessage = "The {0} field is required")]
        [DisplayName("Phone")]
        [DataType(DataType.PhoneNumber)]
        [Phone]
        public string Phone { get; set; }

        [Required(ErrorMessage = "The {0} field is required")]
        [DisplayName("Code")]
        public string Code { get; set; }
    }

    public class ResetPasswordModel
    {
        [Required(ErrorMessage = "The {0} field is required")]
        [DisplayName("Phone")]
        [DataType(DataType.PhoneNumber)]
        [Phone]
        public string Phone { get; set; }

        [DisplayName("Code")]
        [Required(ErrorMessage = "{0} is required")]
        public string Code { get; set; }

        [DisplayName("New Password")]
        [Required(ErrorMessage = "{0} is required")]
        [DataType(DataType.Password)]
        [PasswordPropertyText]
        public string NewPassword { get; set; }
    }
}
