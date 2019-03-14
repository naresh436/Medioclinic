namespace MedioClinicBusiness.Services.Context
{
    public interface ISiteContextService
    {
        // Holds the code name of the current site
        string SiteName { get; }

        // Holds the active site culture
        string CurrentSiteCulture { get; }

        // Indicates which preview culture should be used in the preview mode
        string PreviewCulture { get; }

        // Indicates if preview is enabled
        bool IsPreviewEnabled { get; }
    }
}
