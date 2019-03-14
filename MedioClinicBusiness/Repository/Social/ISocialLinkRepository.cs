using MedioClinicBusiness.DTO.Social;
using MedioClinicBusiness.Services;
using System.Collections.Generic;

namespace MedioClinicBusiness.Repository.Social
{
    public interface ISocialLinkRepository : IService
    {
        IEnumerable<SocialLinkDto> GetSocialLinks();
        SocialLinkDto GetSocialLinkDto();
    }
}
