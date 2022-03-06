namespace EConnectSocialMedia.ServiceEntity.CommonEntity
{
    public interface ILookUpEntityModel
    {
        public string Name { get; set; }
    }

    public class LookUpEntityModel : BaseEntityModel, ILookUpEntityModel
    {
        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("Name")]
        public string Name { get; set; }
    }

    public class FullLookUpEntityModel : FullBaseEntityModel, ILookUpEntityModel
    {
        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("Name")]
        public string Name { get; set; }
    }
}
