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

public partial class Classifieds_MPClassifieds2 : System.Web.UI.MasterPage
{
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

    protected string AdvertiserName
    {
        get
        {
            object obj = ViewState["AdvertiserName"];
            if (obj != null)
            {
                return (string)obj;
            }
            return "";
        }

        set { ViewState["AdvertiserName"] = value; }
    }



    private void CheckUserSession()
    {
        if (Session["LOGINEMAIL"] != null)
        {
            LoginEmail = Session["LOGINEMAIL"].ToString();
        }
        if (Session["ADVERTISERNAME"] != null)
        {
            AdvertiserName = Session["ADVERTISERNAME"].ToString();
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
        intActiveModule = UTLUtilities.CL_ActiveModule;
    }
    protected void btnSearchProduct_Click(object sender, ImageClickEventArgs e)
    {
        //if (!Page.IsPostBack)
        //{
        //    site_search.Value = "";
        //}
        //if (site_search.Value != "")
        //{
        //    Response.Redirect("../Common/SearchResult.aspx?Key=" + UTLUtilities.Encrypt(site_search.Value)
        //        + "&Loc=" + UTLUtilities.Encrypt(lblLocation.Text), true);
        //}
    }
}
