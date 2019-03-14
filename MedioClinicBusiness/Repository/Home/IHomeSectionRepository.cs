using MedioClinicBusiness.DTO.Home;

namespace MedioClinicBusiness.Repository.Home
{
    public interface IHomeSectionRepository : IRepository
    {
        HomeSectionDto GetHomeSection();
    }
}
