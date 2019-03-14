using MedioClinicBusiness.DTO.Company;
using MedioClinicBusiness.DTO.Home;
using System.Collections.Generic;

namespace MedioClinic.Models.Home
{
    public class HomeViewModel : IViewModel
    {
        public HomeSectionDto HomeSection { get; set; }
        public IEnumerable<CompanyServiceDto> CompanyServices { get; set; }
    }
}