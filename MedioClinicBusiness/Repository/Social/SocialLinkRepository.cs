using MedioClinicBusiness.DTO.Social;
using MedioClinicBusiness.Services.Query;
using System.Collections.Generic;
using System.Linq;

namespace MedioClinicBusiness.Repository.Social
{
    public class SocialLinkRepository : BaseRepository,ISocialLinkRepository
    {
        public SocialLinkRepository(IDocumentQueryService documentQueryService) :base(documentQueryService)
        {

        }


        public SocialLinkDto GetSocialLinkDto()
        {
            return DocumentQueryService.GetDocuments<CMS.DocumentEngine.Types.MedioClinic.SocialLink>()
                .AddColumns("Title", "Url", "Icon", "DocumentID")
                .TopN(1)
                .ToList()
                .Select(m =>
                {          
                    return new SocialLinkDto()
                    {
                        Title=m.Title,
                        Url=m.Url,
                        Icon =m.Fields.Icon
                    };
                })
                .FirstOrDefault();
        }

        public IEnumerable<SocialLinkDto> GetSocialLinks()
        {
            return DocumentQueryService.GetDocuments<CMS.DocumentEngine.Types.MedioClinic.SocialLink>()
                .AddColumns("Title", "Url", "Icon", "DocumentID")
                .ToList()
                .Select(m =>
                {
                    return new SocialLinkDto()
                    {
                        Title = m.Title,
                        Url = m.Url,
                        Icon = m.Fields.Icon
                    };
                });                
        }
    }
}
