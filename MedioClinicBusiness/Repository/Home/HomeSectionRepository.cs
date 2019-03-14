using CMS.DocumentEngine.Types.MedioClinic;
using MedioClinicBusiness.DTO.Home;
using MedioClinicBusiness.Services.Query;
using System.Linq;

namespace MedioClinicBusiness.Repository.Home
{
    public class HomeSectionRepository : BaseRepository, IHomeSectionRepository
    {
        public HomeSectionRepository(IDocumentQueryService documentQueryService) : base(documentQueryService)
        {

        }
        public HomeSectionDto GetHomeSection()
        {
            return DocumentQueryService.GetDocuments<HomeSection>()
                .AddColumns("Title", "Text", "Button")
                .TopN(1)
                .ToList()
                .Select(m=> {
                    return new HomeSectionDto()
                    {
                        Title=m.Title,
                        Text=m.Text,
                        LinkText=m.Button
                    };
                }).FirstOrDefault();
        }
    }
}
