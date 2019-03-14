using System.Collections.Generic;
using System.Linq;
using CMS.DocumentEngine.Types.MedioClinic;
using MedioClinicBusiness.DTO.Company;
using MedioClinicBusiness.DTO.Company;
using MedioClinicBusiness.Services.Query;

namespace MedioClinicBusiness.Repository.Company
{
    public class CompanyServiceRepository : BaseRepository, ICompanyServiceRepository
    {
        public CompanyServiceRepository(IDocumentQueryService documentQueryService) : base(documentQueryService)
        {

        }

        public IEnumerable<CompanyServiceDto> GetCompanyServices()
        {
            return DocumentQueryService.GetDocuments<CompanyService>()
                .AddColumns("Header", "Text", "Icon", "DocumentID")
                .OrderByAscending("NodeOrder")
                .ToList()
                .Select(m => {
                    return new CompanyServiceDto()
                    {
                        Header = m.Header,
                        Text = m.Text,
                        Icon = m.Fields.Icon
                    };
                });
        }
    }
}
