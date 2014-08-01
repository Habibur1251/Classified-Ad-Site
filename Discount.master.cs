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

public partial class Discount : System.Web.UI.MasterPage
{
    public int intActiveModule = -1;
    protected void Page_Load(object sender, EventArgs e)
    {
        intActiveModule = UTLUtilities.CL_ActiveModule;
        if(Session["COUNTRY"] != null)
        {
            lblLocation.Text = Session["COUNTRY"].ToString();
        }
        else
        {
            //Response.Redirect("~/Default.aspx");
        }

        //string currentLocation = Request.AppRelativeCurrentExecutionFilePath;

        //if (currentLocation == "ItemList_Classifieds.aspx")
        //{
        //    rotCommonClassified.AdvertisementFile = "App_Data/ClassifiedListing.config";
        //}
        //else if (currentLocation == "ItemDetail_Classifieds.aspx")
        //{
        //    rotCommonClassified.AdvertisementFile = "App_Data/ClassifiedDetail.config";
        //}
        //else
        //{
 
        //}
    }
}
