using MedioClinicBusiness.DTO;

namespace MedioClinicBusiness.Repository.Company
{
    public interface ICompanyRepository : IRepository
    {
        CompanyDto GetCompany();
    }
}
