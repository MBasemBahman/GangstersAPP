namespace EConnectSocialMedia.Entity.GroupEntity
{
    public class GroupType : FullStateEntity
    {
        [DisplayName("Groups")]
        public ICollection<Group> Groups { get; set; }

        public GroupTypeLang GroupTypeLang { get; set; }
    }

    public class GroupTypeLang : FullLangEntity<GroupType>
    {

        [Required(ErrorMessage = "Required")]
        [DisplayName("English Name")]
        public string Name { get; set; }
    }
}
