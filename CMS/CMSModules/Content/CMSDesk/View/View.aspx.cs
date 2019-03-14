﻿using System;

using CMS.Base;
using CMS.Base.Web.UI;
using CMS.Helpers;
using CMS.Membership;
using CMS.PortalEngine;
using CMS.UIControls;


public partial class CMSModules_Content_CMSDesk_View_View : CMSContentPage
{
    #region "Variables & Properties"

    private string viewPage;

    /// <summary>
    /// Overridden messages placeholder for correct positioning
    /// </summary>
    public override MessagesPlaceHolder MessagesPlaceHolder
    {
        get
        {
            return plcMess;
        }
        set
        {
            plcMess = value;
        }
    }

    #endregion


    #region "Page events"

    /// <summary>
    /// OnPreInit
    /// </summary>
    protected override void OnPreInit(EventArgs e)
    {
        PortalContext.ViewMode = ViewModeEnum.Preview;
        DocumentManager.RedirectForNonExistingDocument = false;

        base.OnPreInit(e);
    }


    /// <summary>
    /// Handles the Load event of the Page control.
    /// </summary>
    protected void Page_Load(object sender, EventArgs e)
    {
        ScriptHelper.RegisterJQuery(Page);
        ScriptHelper.RegisterModule(Page, "CMS/HeaderShadow");

        // Setup Edit menu
        bool preview = PortalContext.ViewMode.IsPreview();

        editMenu.ShowProperties = false;
        editMenu.ShowSpellCheck = true;
        editMenu.ShowSave = !preview;
        editMenu.ShowCheckOut = !preview;
        editMenu.ShowCheckIn = !preview;
        editMenu.ShowUndoCheckOut = !preview;
        editMenu.ShowApplyWorkflow = !preview;
        editMenu.NodeID = NodeID;
        editMenu.CultureCode = CultureCode;
        editMenu.UseSmallIcons = true;
        editMenu.IsLiveSite = false;

        viewPage = DocumentUIHelper.GetViewPageUrl();
        ucView.ViewPage = string.Empty;
        ucView.RotateDevice = ValidationHelper.GetBoolean(CookieHelper.GetValue(CookieName.CurrentDeviceProfileRotate), false);

        const string deviceRotateScript = @"
$cmsj(document).ready(function () {
    if (window.CMSDeviceProfile) {
        CMSDeviceProfile.OnRotationFunction = (function() {
            CMSView.InitializeFrame(CMSView.PreviewWidth, CMSView.PreviewHeight, !CMSView.Rotated);
            CMSView.DeviceWindowResize();
        });
    }
});";

        ScriptHelper.RegisterStartupScript(this, typeof(string), "deviceRotateScript", deviceRotateScript, true);

        // Bind external buttons (i.e. Persona selector)
        var extensionTarget = editMenu as IExtensibleEditMenu;
        extensionTarget.InitializeExtenders("Content");

        if (Node?.NodeIsContentOnly == true)
        {
            // Preview link is not valid after going through workflow because DocumentWorkflowCycleGUID has changed
            DocumentManager.OnAfterAction += (obj, args) => viewPage = Node.GetPreviewLink(MembershipContext.AuthenticatedUser.UserName, embededInAdministration: true);
        }
    }


    /// <summary>
    /// Handles the PreRender event of the Page control.
    /// </summary>
    protected void Page_PreRender(object sender, EventArgs e)
    {
        if (Node?.NodeIsContentOnly == true)
        {
            ucView.ViewPage = "about:blank";

            // Modify frame 'src' attribute and add administration domain into it
            ScriptHelper.RegisterModule(this, "CMS.Builder/FrameSrcAttributeModifier", new
            {
                frameId = ucView.FrameID,
                frameSrc = viewPage,
            });
        }
        else
        {
            ucView.ViewPage = viewPage;
        }
    }

    #endregion
}
