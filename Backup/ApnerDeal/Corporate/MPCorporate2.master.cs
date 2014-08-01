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

public partial class Corporate_MPCorporate2 : System.Web.UI.MasterPage
{
    #region PROPERTY

    public int intActiveModule = -1;

    protected string LoginEmail
    {
        get
        {
            object obj = ViewState["LoginEmail"];
            if (obj != null)
            {
                return (string)obj;
            }
            return "";
        }

        set { ViewState["LoginEmail"] = value; }
    }

    protected string CompanyName
    {
        get
        {
            object obj = ViewState["CompanyName"];
            if (obj != null)
            {
                return (string)obj;
            }
            return "";
        }

        set { ViewState["CompanyName"] = value; }
    }
    #endregion PROPERTY


    private void CheckUserSession()
    {
        if (Session["LOGINEMAIL"] != null)
        {
            LoginEmail = Session["LOGINEMAIL"].ToString();
        }
        if (Session["COMPANYNAME"] != null)
        {
            CompanyName = Session["COMPANYNAME"].ToString();
        }

        if (Session["COUNTRY"] != null)
        {
            //lblLocation.Text = "<a href= \"../Default.aspx\" style=\"font-family:Verdana; font-size:14px; font-weight:bold;\">";
            lblLocation.Text = Session["COUNTRY"].ToString();
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
    }



    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.CheckUserSession();
        }
        intActiveModule = UTLUtilities.CP_ActiveModule;
    }
    
}
