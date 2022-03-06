using System.Text.Json.Serialization;

namespace EConnectSocialMedia.API.Models.Accounts
{
    public class AuthenticateResponse
    {
        [JsonIgnore]
        [DisplayName("Id")]
        public int Id { get; set; }

        [DisplayName("Image URL")]
        [DataType(DataType.ImageUrl, ErrorMessage = "{0} not valid")]
        [Url]
        public string ImageURL { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Full Name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "{0} is required")]
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

        [DisplayName("IsTesting")]
        public bool IsTesting { get; set; }

        [DisplayName("Gender")]
        public int? Fk_Gender { get; set; }

        [DisplayName("Account Type")]
        public int Fk_AccountType { get; set; }

        [DisplayName("Account State")]
        public int Fk_AccountState { get; set; }

        [DisplayName("IsOnline")]
        public bool IsOnline { get; set; }

        [DisplayName("IsVerified")]
        public bool IsVerified { get; set; }

        [JsonIgnore]
        public string JwtToken { get; set; }

        [JsonIgnore]
        public string RefreshToken { get; set; }

        public AuthenticateResponse()
        {

        }

        public AuthenticateResponse(Account account, string jwtToken, string refreshToken)
        {
            Id = account.Id;
            ImageURL = account.ImageURL;
            FirstName = account.FirstName;
            LastName = account.LastName;
            FullName = account.FullName;
            NickName = account.NickName;
            Phone = account.Phone;
            Email = account.Email;
            IsTesting = account.IsTesting;
            Fk_Gender = account.Fk_Gender;
            IsOnline = account.IsOnline;
            IsVerified = account.IsVerified;
            Fk_AccountState = account.Fk_AccountState;
            Fk_AccountType = account.Fk_AccountType;
            JwtToken = jwtToken;
            RefreshToken = refreshToken;
        }
    }
}