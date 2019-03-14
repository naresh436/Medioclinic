using MedioClinicBusiness.DTO.Doctors;

namespace MedioClinicBusiness.Repository.Doctor
{
    public interface IDoctorSectionRepository : IRepository
    {
        DoctorSectionDto GetDoctorSection();
    }
}
