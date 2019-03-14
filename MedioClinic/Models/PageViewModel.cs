using MedioClinicBusiness.DTO;
using MedioClinicBusiness.DTO.Culture;
using MedioClinicBusiness.DTO.Menu;
using MedioClinicBusiness.DTO.Page;
using MedioClinicBusiness.DTO.Social;
using System.Collections.Generic;

namespace MedioClinic.Models
{
    public class PageViewModel : IViewModel
    {
        public IEnumerable<MenuItemDto> MenuItems { get; set; }
        public PageMetadataDto Metadata { get; set; }
        public CompanyDto Company { get; set; }
        public IEnumerable<CultureDto> Cultures { get; set; }
        public IEnumerable<SocialLinkDto> SocialLinks { get; set; }
    }


    // Inherits page view model 
    // Accepts generic view model which represents data for other pages on the website
    public class PageViewModel<TViewModel> : PageViewModel where TViewModel : IViewModel
    {
        public TViewModel Data { get; set; }
    }
}