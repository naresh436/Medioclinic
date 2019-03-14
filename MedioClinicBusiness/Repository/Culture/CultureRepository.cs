using System.Collections.Generic;
using System.Linq;
using CMS.SiteProvider;
using MedioClinicBusiness.DTO.Culture;
using MedioClinicBusiness.Services.Context;

namespace MedioClinicBusiness.Repository.Culture
{
    public class CultureRepository : ICultureRepository
    {
        ISiteContextService SiteContextService;

        public CultureRepository(ISiteContextService siteContextService)
        {
            SiteContextService = siteContextService;
        }

        public IEnumerable<CultureDto> GetSiteCultures()
        {
           return CultureSiteInfoProvider.GetSiteCultures(SiteContextService.SiteName)
                .ToList()
                .Select(m => 
                {
                    return new CultureDto()
                    {
                        CultureCode = m.CultureCode,
                        CultureName = m.CultureName,
                        CultureShortName = m.CultureShortName
                    };
                });
        }
    }
}
