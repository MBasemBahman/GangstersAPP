namespace GangstersAPP.Entity.AuthEntity
{
    public class SystemView : FullLookUpEntity
    {
        [DisplayName("Display Name")]
        [Required(ErrorMessage = "{0} is required")]
        public string DisplayName { get; set; }

        [DisplayName("System Role Premissions")]
        public ICollection<SystemRolePremission> SystemRolePremissions { get; set; }
    }
}
