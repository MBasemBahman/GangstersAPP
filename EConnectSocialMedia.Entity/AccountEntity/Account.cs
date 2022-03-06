using GangstersAPP.Entity.BeneficiaryRequestEntity;
using GangstersAPP.Entity.ServiceProviderRequestEntity;

namespace GangstersAPP.Entity.AccountEntity
{
    [Index(nameof(Phone), IsUnique = true)]
    public class Account : FullImageEntity
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
        public string PasswordHash { get; set; }

        [DisplayName("IsTesting")]
        public bool IsTesting { get; set; }

        [DisplayName("Birth Date")]
        public DateTime? BirthDate { get; set; }

        [DisplayName(nameof(Gender))]
        [ForeignKey("Gender")]
        public int? Fk_Gender { get; set; }

        [DisplayName("Gender")]
        public Gender Gender { get; set; }

        [DisplayName("National ID")]
        public string NationalID { get; set; }

        [DisplayName(nameof(AccountType))]
        [ForeignKey("AccountType")]
        public int Fk_AccountType { get; set; }

        [DisplayName("Account Type")]
        public AccountType AccountType { get; set; }

        [DisplayName(nameof(AccountState))]
        [ForeignKey("AccountState")]
        public int Fk_AccountState { get; set; }

        [DisplayName("Account State")]
        public AccountState AccountState { get; set; }

        [DisplayName("BIO")]
        [DataType(DataType.MultilineText)]
        public string BIO { get; set; }

        [DisplayName("About Account")]
        [DataType(DataType.MultilineText)]
        public string About { get; set; }

        [DisplayName("IsOnline")]
        public bool IsOnline { get; set; } = default;

        [DisplayName("SignalR ConnectionId")]
        public string ConnectionId { get; set; }

        [DisplayName("Verification Code")]
        public string VerificationCodeHash { get; set; }

        [DisplayName("Verification At")]
        public DateTime VerificationAt { get; set; }

        [DisplayName("Verification At")]
        [NotMapped]
        public string VerificationAtString => VerificationAt.AddHours(2).ToString("dd/MM/yyyy h:mm tt", CultureInfo.InvariantCulture);

        [DisplayName("IsVerified")]
        public bool IsVerified { get; set; } = default;

        [DisplayName("Posts")]
        public ICollection<Post> Posts { get; set; }

        [DisplayName("Posts Reactions")]
        public ICollection<PostReaction> PostReactions { get; set; }

        [DisplayName("Posts Comments")]
        public ICollection<PostComment> PostComments { get; set; }

        [DisplayName("Posts Comments Reactions")]
        public ICollection<PostCommentReaction> PostCommentReactions { get; set; }

        [DisplayName("Groups")]
        public ICollection<GroupMember> GroupMembers { get; set; }

        [DisplayName("Chats")]
        public ICollection<ChatMember> ChatMembers { get; set; }

        [DisplayName("Messages")]
        public ICollection<Message> Messages { get; set; }

        [DisplayName("Refresh Tokens")]
        public List<RefreshToken> RefreshTokens { get; set; }

        [DisplayName("Account Devices")]
        public ICollection<AccountDevice> AccountDevices { get; set; }

        public ICollection<NotificationAccount> NotificationAccounts { get; set; }

        public ICollection<ServiceProviderRequest> ServiceProviderRequests { get; set; }

        public ICollection<BeneficiaryRequest> BeneficiaryRequests { get; set; }
    }
}
