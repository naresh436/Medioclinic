using MedioClinicBusiness.DTO.Doctors;
using System;
using System.Collections.Generic;

namespace MedioClinicBusiness.Repository.Doctor
{
    public interface IDoctorRepository : IRepository
    {
        IEnumerable<DoctorDto> GetDoctors();

        DoctorDto GetDoctor(Guid nodeGuid);
    }
}
