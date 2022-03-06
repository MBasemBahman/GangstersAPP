namespace GangstersAPP.Entity.CommonEntity
{
    public class LangEntity<T> : BaseEntity
    {

        [DisplayName(nameof(Source))]
        [ForeignKey(nameof(Source))]
        public int Fk_Source { get; set; }

        [DisplayName("Source")]
        public T Source { get; set; }
    }

    public class FullLangEntity<T> : FullBaseEntity
    {

        [DisplayName(nameof(Source))]
        [ForeignKey(nameof(Source))]
        public int Fk_Source { get; set; }

        [DisplayName("Source")]
        public T Source { get; set; }
    }
}
