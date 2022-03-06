namespace GangstersAPP.ServiceEntity.PostEntity
{
    public class ReactionTypeModel : FullLookUpEntityModel, IImageEntityModel
    {
        [DisplayName("Image URL")]
        [DataType(DataType.ImageUrl, ErrorMessage = "{0} not valid")]
        [Url]
        public string ImageURL { get; set; }
    }
}
