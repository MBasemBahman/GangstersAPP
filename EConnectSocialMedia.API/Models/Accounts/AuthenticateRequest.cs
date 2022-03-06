namespace EConnectSocialMedia.API.Models.Accounts
{
    public class AuthenticateRequest
    {
        [Required(ErrorMessage = "The {0} field is required")]
        [DisplayName("Phone")]
        [DataType(DataType.PhoneNumber)]
        [Phone]
        public string Phone { get; set; }

        [Required(ErrorMessage = "The {0} field is required")]
        [DisplayName("Password")]
        [DataType(DataType.Password)]
        [PasswordPropertyText]
        public string Password { get; set; }
    }
}