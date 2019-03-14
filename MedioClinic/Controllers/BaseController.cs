using MedioClinic.Models;
using MedioClinicBusiness.DependencyInjection;
using MedioClinicBusiness.DTO;
using MedioClinicBusiness.DTO.Menu;
using MedioClinicBusiness.DTO.Social;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MedioClinic.Controllers
{
    public class BaseController : Controller
    {
        // Gets related business dependencies
        protected IBusinessDependencies Dependencies { get; }
        protected BaseController(IBusinessDependencies dependencies)
        {
            Dependencies = dependencies;
        }

        public PageViewModel GetPageViewModel(string title)
        {
            return new PageViewModel()
            {
                MenuItems = Dependencies.MenuRepository.GetMenuItems() ?? new List<MenuItemDto>(),
                //Metadata = GetPageMetadata(title),
                Company = GetCompany(),
                Cultures = Dependencies.CultureRepository.GetSiteCultures(),
                SocialLinks = GetSocialLinks(),
            };
        }

        public PageViewModel<TViewModel> GetPageViewModel<TViewModel>(TViewModel data, string title) where TViewModel : IViewModel
        {
            return new PageViewModel<TViewModel>()
            {
                MenuItems = Dependencies.MenuRepository.GetMenuItems() ?? new List<MenuItemDto>(),
                //Metadata = GetPageMetadata(title),
                Company = GetCompany(),
                Cultures = Dependencies.CultureRepository.GetSiteCultures(),
                SocialLinks = GetSocialLinks(),
                Data = data
            };
        }


        private IEnumerable<SocialLinkDto> GetSocialLinks()
        {
            return Dependencies.SocialLinkRepository.GetSocialLinks();
        }
        private CompanyDto GetCompany()
        {
            return Dependencies.CompanyRepository.GetCompany();
        }
    }
}