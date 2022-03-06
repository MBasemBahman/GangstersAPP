namespace EConnectSocialMedia.Entity.CommonEntity
{
    public class BaseEntity
    {
        [Key]
        [DisplayName("Id")]
        public int Id { get; set; }

        [DisplayName("Created At")]
        [DataType(DataType.DateTime)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; set; }

        [DisplayName("Created At")]
        [NotMapped]
        public string CreatedAtString => CreatedAt.AddHours(2).ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

        [DisplayName("Created By")]
        public string CreatedBy { get; set; }
    }

    public class FullBaseEntity : BaseEntity
    {
        [DisplayName("IsActive")]
        public bool IsActive { get; set; } = default;

        [DisplayName("Sort")]
        public int Sort { get; set; } = default;

        [DisplayName("Last Modified At")]
        [DataType(DataType.DateTime)]
        public DateTime LastModifiedAt { get; set; }

        [DisplayName("Last Modified At")]
        [NotMapped]
        public string LastModifiedAtString => LastModifiedAt.AddHours(2).ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

        [DisplayName("Last Modified By")]
        public string LastModifiedBy { get; set; }
    }
}
