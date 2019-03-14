using MedioClinic.Models.Home;
using MedioClinicBusiness.DependencyInjection;
using MedioClinicBusiness.Repository.Company;
using MedioClinicBusiness.Repository.Home;
using System.Web.Mvc;

namespace MedioClinic.Controllers
{
    public class HomeController : BaseController
    {
        private ICompanyServiceRepository CompanyServiceRepository { get; }
        private IHomeSectionRepository HomeSectionRepository { get; }

        //public HomeController() { }

        public HomeController(
            IBusinessDependencies dependencies,
            ICompanyServiceRepository companyServiceRepository,
            IHomeSectionRepository homeSectionRepository) : base(dependencies)
        {
            CompanyServiceRepository = companyServiceRepository;
            HomeSectionRepository = homeSectionRepository;
        }

        
        public ActionResult Index()
        {
            var homeSection = HomeSectionRepository.GetHomeSection();

            if (homeSection == null)
            {
                return HttpNotFound();
            }

            var model = GetPageViewModel(new HomeViewModel()
            {
                CompanyServices = CompanyServiceRepository.GetCompanyServices(),
                HomeSection = homeSection
            }, homeSection.Title);

            return View(model);
        }
    }
}