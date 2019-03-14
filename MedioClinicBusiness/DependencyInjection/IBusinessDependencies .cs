using MedioClinicBusiness.Repository.Company;
using MedioClinicBusiness.Repository.Culture;
using MedioClinicBusiness.Repository.Menu;
using MedioClinicBusiness.Repository.Social;
using MedioClinicBusiness.Services.Context;

namespace MedioClinicBusiness.DependencyInjection
{
    public interface IBusinessDependencies
    {
        ISiteContextService SiteContextService { get; }
        ICompanyRepository CompanyRepository { get; }
        ICultureRepository CultureRepository { get; }
        ISocialLinkRepository SocialLinkRepository { get; }
        IMenuRepository MenuRepository { get; }
    }
}
