using System.Collections.Generic;
using MedioClinicBusiness.DTO.Doctors;
using MedioClinicBusiness.Services.Query;
using System.Linq;
using System;
using MedioClinicBusiness.Services.Context;

namespace MedioClinicBusiness.Repository.Doctor
{
    public class DoctorRepository : BaseRepository, IDoctorRepository
    {
        ISiteContextService SiteContextService { get; }
        public DoctorRepository(IDocumentQueryService documentQueryService, ISiteContextService siteContextService) : base(documentQueryService)
        {
            SiteContextService = siteContextService;
        }

        private readonly string[] _doctorColumns =
        {
            // Defines database columns for retrieving data
            // NodeGuid is retrieved automatically
            "NodeID", "NodeAlias", "Bio", "Degree", "EmergencyShift", "FirstName",
            "LastName", "Photo", "Specialty", "DocumentID"
        };

        private Func<CMS.DocumentEngine.Types.MedioClinic.Doctor, DoctorDto> DoctorDtoSelect => doctor => new DoctorDto()
        {
            NodeAlias = doctor.NodeAlias,
            NodeGuid = doctor.NodeGUID,
            NodeId = doctor.NodeID,
            Bio = doctor.Bio,
            Degree = doctor.Degree,
            EmergencyShift = doctor.EmergencyShift,
            FirstName = doctor.FirstName,
            LastName = doctor.LastName,
            Photo = doctor.Fields.Photo,
            Specialty = doctor.Specialty
        };



        public DoctorDto GetDoctor(Guid nodeGuid)
        {
            return DocumentQueryService.GetDocument<CMS.DocumentEngine.Types.MedioClinic.Doctor>(nodeGuid)
                .AddColumns(_doctorColumns)
                .Select(DoctorDtoSelect)
                .FirstOrDefault();
        }

        

        public IEnumerable<DoctorDto> GetDoctors()
        {
            return DocumentQueryService.GetDocuments<CMS.DocumentEngine.Types.MedioClinic.Doctor>()
                .AddColumns(_doctorColumns)
                .ToList()
                .Select(DoctorDtoSelect);
        }
    }
}
