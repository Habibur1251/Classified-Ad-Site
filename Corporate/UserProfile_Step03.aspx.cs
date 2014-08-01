using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Corporate_UserProfile_Step03 : System.Web.UI.Page
{
    private string strLinkID = string.Empty;
    private string strProfileID = string.Empty;
    public int intActionResult = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            strLinkID = Request.QueryString["LinkCode"];
            strProfileID = Request.QueryString["ProfileCode"];

            if (!string.IsNullOrEmpty(strLinkID) && !string.IsNullOrEmpty(strProfileID))
            {
                strLinkID = UTLUtilities.Decrypt(strLinkID);
                strProfileID = UTLUtilities.Decrypt(strProfileID);

                using (BOC_Corporate_UserProfile bocUserProfile = new BOC_Corporate_UserProfile())
                {
                    EOC_PropertyBean eocPropertyBean = new EOC_PropertyBean();
                    eocPropertyBean.Business_ActivationLinks_LinkID = Convert.ToInt32(strLinkID);
                    eocPropertyBean.Business_UserProfile_ProfileID = Convert.ToInt32(strProfileID);
                    eocPropertyBean.Business_ActivationLinks_IsChecked = true;

                    intActionResult = bocUserProfile.UpdateRecord_ActivationLinks(eocPropertyBean);

                    if (intActionResult > 0)
                    {
                        Response.Redirect("Default.aspx");
                    }
                    else
                    {
                        lblSystemMessage.Text = "This link has been expired...";
                    }
                }
            }
        }
    }
}
