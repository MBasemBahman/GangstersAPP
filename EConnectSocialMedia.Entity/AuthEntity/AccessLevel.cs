namespace GangstersAPP.Entity.AuthEntity
{
    public class AccessLevel : LookUpEntity
    {
        [DisplayName("System Role Premissions")]
        public ICollection<SystemRolePremission> SystemRolePremissions { get; set; }
    }
}
