

using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace GangstersAPP.Entity.CommonEntity
{
    public interface ILookUpEntity
    {
        public string Name { get; set; }
    }

    [Index(nameof(Name), IsUnique = true)]
    public class LookUpEntity : BaseEntity, ILookUpEntity
    {
        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("Arabic Name")]
        public string Name { get; set; }
    }

    [Index(nameof(Name), IsUnique = true)]
    public class FullLookUpEntity : FullBaseEntity, ILookUpEntity
    {
        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("Arabic Name")]
        public string Name { get; set; }
    }
}
