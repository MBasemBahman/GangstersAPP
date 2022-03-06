namespace EConnectSocialMedia.ServiceEntity.CommonEntity
{
    public interface IStateEntityModel
    {
        public string Name { get; set; }

        public string ColorCode { get; set; }
    }

    public class StateEntityModel : BaseEntityModel, IStateEntityModel
    {
        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("Color Code")]
        public string ColorCode { get; set; } = "#fff";
    }

    public class FullStateEntityModel : FullBaseEntityModel, IStateEntityModel
    {
        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("Color Code")]
        public string ColorCode { get; set; } = "#fff";
    }
}
