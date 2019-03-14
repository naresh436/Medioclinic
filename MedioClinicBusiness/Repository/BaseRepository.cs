using MedioClinicBusiness.Services.Query;

namespace MedioClinicBusiness.Repository
{
    public abstract class BaseRepository
    {
        protected IDocumentQueryService DocumentQueryService { get; }

        protected BaseRepository(IDocumentQueryService documentQueryService)
        {
            DocumentQueryService = documentQueryService;
        }
    }
}
