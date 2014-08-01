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

public partial class ClassifiedListing : System.Web.UI.MasterPage
{
    private void CheckUserSession()
    {
        if (Session["COUNTRY"] != null)
        {
            //lblLocation.Text = "<a href= \"../Default.aspx\" style=\"font-family:Verdana; font-size:14px; font-weight:bold;\">";
            lblLocation.Text = Session["COUNTRY"].ToString();
        }
        else
        {
            //Response.Redirect("~/Default.aspx");
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.CheckUserSession();

        string currentLocation = Request.AppRelativeCurrentExecutionFilePath;

        if (currentLocation == "~/ItemList_Classifieds.aspx")
        {
            rotCommonClassified.AdvertisementFile = "App_Data/ClassifiedListing.config";
        }
        else if (currentLocation == "~/ItemDetail_Classifieds.aspx")
        {
            rotCommonClassified.AdvertisementFile = "App_Data/ClassifiedDetail.config";
        }
        else
        {

        }
    }
    protected void btnSearchProduct_Click(object sender, ImageClickEventArgs e)
    {
        //if (!Page.IsPostBack)
        //{
        //    site_search.Value = "";
        //}
        //if (site_search.Value != "")
        //{
        //    Response.Redirect("Common/SearchResult.aspx?Key=" + UTLUtilities.Encrypt(site_search.Value)
        //        + "&Loc=" + UTLUtilities.Encrypt(lblLocation.Text), true);
        //}
    }
}
