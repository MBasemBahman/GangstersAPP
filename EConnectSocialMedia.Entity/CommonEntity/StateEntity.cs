namespace GangstersAPP.Entity.CommonEntity
{
    public interface IStateEntity
    {
        public string Name { get; set; }

        public string ColorCode { get; set; }
    }

    [Index(nameof(Name), IsUnique = true)]
    public class StateEntity : BaseEntity, IStateEntity
    {
        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("Arabic Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("Color Code")]
        public string ColorCode { get; set; } = "#fff";
    }

    [Index(nameof(Name), IsUnique = true)]
    public class FullStateEntity : FullBaseEntity, IStateEntity
    {
        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("Arabic Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("Color Code")]
        public string ColorCode { get; set; } = "#fff";
    }
}
