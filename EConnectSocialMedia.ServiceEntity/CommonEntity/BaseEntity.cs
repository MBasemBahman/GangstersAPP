namespace GangstersAPP.ServiceEntity.CommonEntity
{
    public class BaseEntityModel
    {
        [Key]
        [DisplayName("Id")]
        public int Id { get; set; }

        [DisplayName("Created At")]
        [DataType(DataType.DateTime)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string CreatedAt { get; set; }

        [DisplayName("Created By")]
        public string CreatedBy { get; set; }
    }

    public class FullBaseEntityModel : BaseEntityModel
    {
        [DisplayName("IsActive")]
        public bool IsActive { get; set; } = default;

        [DisplayName("Sort")]
        public int Sort { get; set; } = default;

        [DisplayName("Last Modified At")]
        [DataType(DataType.DateTime)]
        public string LastModifiedAt { get; set; }

        [DisplayName("Last Modified By")]
        public string LastModifiedBy { get; set; }
    }
}
