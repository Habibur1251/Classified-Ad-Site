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

public partial class Classifieds_OrderViewer : System.Web.UI.Page
{
    private int intProductID = -1;
    private int intProfileID = -1;
    private int intCountryID = -1;

    private void CheckUserSession()
    {
        if (this.Session["CLSF_PROFILE_CODE"] != null && this.Session["CLSF_COUNTRY_CODE"] != null)
        {
            intProfileID = Convert.ToInt32(this.Session["CLSF_PROFILE_CODE"].ToString());
            intCountryID = Convert.ToInt32(this.Session["CLSF_COUNTRY_CODE"].ToString());
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
    }
    private void CheckQueryString()
    {
        bool blnFlag = false;

        string strPID = Request.QueryString["PID"];

        if (string.IsNullOrEmpty(strPID))
        {
            blnFlag = false;
        }
        else
        {
           if (UTLUtilities.IsNumeric(strPID))
           {
              blnFlag = true;
           }
           else
           {
              blnFlag = false;
           }
        }
        if (blnFlag == true)
        {
            intProductID = Convert.ToInt32(Request.QueryString["PID"]);
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
    }
    private void LoadRecord_OrderDetails()
    {
        try
        {
            using (BOC_Classifieds_ProductProfile bocProductProfile = new BOC_Classifieds_ProductProfile())
            {
                EOC_PropertyBean eocPropertyBean = new EOC_PropertyBean();
                eocPropertyBean.Classifieds_ProductProfile_ProductID = intProductID;
                eocPropertyBean.Classifieds_UserProfile_ProfileID = intProfileID;

                Repeater1.DataSource = bocProductProfile.LoadRecord_OrderDetails(eocPropertyBean);
                Repeater1.DataBind();
            }
        }
        catch (Exception Exp)
        {
            Response.Write(Exp.Message.ToString());
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        this.CheckUserSession();
        this.CheckQueryString();

        if (!Page.IsPostBack)
        {
            this.LoadRecord_OrderDetails();
        }
    }
}
