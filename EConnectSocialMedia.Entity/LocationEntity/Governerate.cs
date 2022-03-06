using EConnectSocialMedia.Entity.BeneficiaryRequestEntity;
using EConnectSocialMedia.Entity.ServiceProviderRequestEntity;

namespace EConnectSocialMedia.Entity.LocationEntity
{
    public class Governerate : FullLookUpEntity
    {
        [DisplayName("ServiceProviderRequests")]
        public ICollection<ServiceProviderRequest> ServiceProviderRequests { get; set; }

        public ICollection<BeneficiaryRequest> BeneficiaryRequests { get; set; }

        public GovernerateLang GovernerateLang { get; set; }
    }

    public class GovernerateLang : FullLangEntity<Governerate>
    {
        [Required(ErrorMessage = "Required")]
        [DisplayName("English Name")]
        public string Name { get; set; }
    }
}
