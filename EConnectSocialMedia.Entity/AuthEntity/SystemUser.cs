namespace GangstersAPP.Entity.AuthEntity
{
    [Index(nameof(Email), IsUnique = true)]
    public class SystemUser : FullBaseEntity
    {
        [DisplayName("Full Name")]
        [Required(ErrorMessage = "{0} is required")]
        public string FullName { get; set; }

        [DisplayName("Job Title")]
        [Required(ErrorMessage = "{0} is required")]
        public string JobTitle { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "{0} is required")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [DisplayName("Phone")]
        [DataType(DataType.PhoneNumber)]
        [Phone]
        public string Phone { get; set; }

        [DisplayName("Password")]
        [Required(ErrorMessage = "{0} is required")]
        [DataType(DataType.Password)]
        [PasswordPropertyText]
        public string PasswordHash { get; set; }

        [ForeignKey("SystemRole")]
        [DisplayName(nameof(SystemRole))]
        public int Fk_SystemRole { get; set; }

        [DisplayName("System Role")]
        public SystemRole SystemRole { get; set; }

        [DisplayName("Token")]
        public string Token { get; set; }

        [DisplayName("Expires")]
        [DataType(DataType.DateTime)]
        public DateTime Expires { get; set; }

        [DisplayName("IsExpired")]
        public bool IsExpired => DateTime.UtcNow >= Expires;
    }
}
