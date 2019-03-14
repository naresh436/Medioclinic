using MedioClinicBusiness.Repository.Company;
using MedioClinicBusiness.Repository.Culture;
using MedioClinicBusiness.Repository.Menu;
using MedioClinicBusiness.Repository.Social;
using MedioClinicBusiness.Services.Context;

namespace MedioClinicBusiness.DependencyInjection
{
    public class BusinessDependencies : IBusinessDependencies
    {
        public ISiteContextService SiteContextService { get; }

        public ICompanyRepository CompanyRepository { get; }

        public ICultureRepository CultureRepository { get; }

        public ISocialLinkRepository SocialLinkRepository { get; }
        public IMenuRepository MenuRepository { get; }
        


        public BusinessDependencies(ISiteContextService siteContextService,
            ICompanyRepository companyRepository,
            ICultureRepository cultureRepository,
            ISocialLinkRepository socialLinkRepository,
            IMenuRepository menuRepository)
        {
            SiteContextService = siteContextService;
            CompanyRepository = companyRepository;
            CultureRepository = cultureRepository;
            SocialLinkRepository = socialLinkRepository;
            MenuRepository = menuRepository;
        }
        
    }
}
