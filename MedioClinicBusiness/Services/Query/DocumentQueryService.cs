using System;
using CMS.DocumentEngine;
using MedioClinicBusiness.Services.Context;
using MedioClinicBusiness.Services.Query;

namespace MedioClinicBusiness.Services.Query
{
    public class DocumentQueryService : IDocumentQueryService
    {
        private ISiteContextService SiteContext { get; }

        public DocumentQueryService(ISiteContextService siteContext)
        {
            SiteContext = siteContext;
        }

        public DocumentQuery<TDocument> GetDocument<TDocument>(Guid nodeGuid) where TDocument : TreeNode, new()
        {
            return GetDocuments<TDocument>()
                .WhereEquals("NodeGUID", nodeGuid)
                .TopN(1);
        }

        public DocumentQuery<TDocument> GetDocuments<TDocument>() where TDocument : TreeNode, new()
        {
            var query = DocumentHelper.GetDocuments<TDocument>();

            // Evaluates whether preview mode is enabled
            if (SiteContext.IsPreviewEnabled)
            {
                // Loads the latest version of pages as preview mode is enabled
                query = query
                    .AddColumns("NodeSiteID") // Column required for preview mode in the admin UI
                    .OnSite(SiteContext.SiteName) // There could be more sites with matching page
                    .LatestVersion()
                    .Culture(SiteContext.PreviewCulture);
            }
            else
            {
                // Loads the published version of pages
                query = query
                    .OnSite(SiteContext.SiteName)
                    .Published()
                    .PublishedVersion()
                    .Culture(SiteContext.CurrentSiteCulture);
            }

            return query;
        }
    }
}
