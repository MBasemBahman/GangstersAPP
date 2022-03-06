namespace GangstersAPP.API.Models.Accounts
{
    public class RefreshTokenRequest
    {
        [Required]
        public string Token { get; set; }
    }
}
