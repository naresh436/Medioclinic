using MedioClinicBusiness.DTO.Doctors;
using System.Collections.Generic;

namespace MedioClinic.Models.Doctor
{
    public class DoctorsViewModel : IViewModel
    {
        public IEnumerable<DoctorDto> Doctors;
        public DoctorSectionDto DoctorSection;
    }
}