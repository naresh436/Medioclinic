using MedioClinic.Models.Doctor;
using MedioClinicBusiness.DependencyInjection;
using MedioClinicBusiness.Repository.Doctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MedioClinic.Controllers
{
    public class DoctorsController : BaseController
    {

        private IDoctorRepository DoctorRepository { get; }
        private IDoctorSectionRepository DoctorSectionRepository { get; }

        public DoctorsController(
            IBusinessDependencies dependecies,
            IDoctorRepository doctorRepository,
            IDoctorSectionRepository doctorSectionRepository
            ) : base(dependecies)
        {
            DoctorRepository = doctorRepository;
            DoctorSectionRepository = doctorSectionRepository;
        }

        // GET: Doctors
        public ActionResult Index()
        {
            var doctorSection = DoctorSectionRepository.GetDoctorSection();

            if (doctorSection == null)
            {
                return HttpNotFound();
            }

            var model = GetPageViewModel(new DoctorsViewModel()
            {
                Doctors = DoctorRepository.GetDoctors(),
                DoctorSection = doctorSection
            }, doctorSection.Header);

            return View(model);
        }

        [Route("Detail/{nodeId}/{nodeAlias}")]
        public ActionResult Detail(Guid nodeGuid, string nodeAlias)
        {
            var doctor = DoctorRepository.GetDoctor(nodeGuid);

            if (doctor == null)
            {
                return HttpNotFound();
            }

            var model = GetPageViewModel(new DoctorDetailViewModel()
            {
                Doctor = doctor
            }, doctor.FullName);

            return View(model);
        }

    }
}