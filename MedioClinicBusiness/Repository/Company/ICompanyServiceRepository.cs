using MedioClinicBusiness.DTO.Company;
using MedioClinicBusiness.Services;
using System.Collections.Generic;

namespace MedioClinicBusiness.Repository.Company
{
    public interface ICompanyServiceRepository : IRepository
    {
        IEnumerable<CompanyServiceDto> GetCompanyServices();
    }
}
