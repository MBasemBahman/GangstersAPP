namespace GangstersAPP.Entity.AuthEntity
{
    public class SystemRole : FullLookUpEntity
    {
        [DisplayName("System Users")]
        public ICollection<SystemUser> SystemUsers { get; set; }

        [DisplayName("System Role Premissions")]
        public ICollection<SystemRolePremission> SystemRolePremissions { get; set; }
    }
}
