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

public partial class Common_MPCommonListing : System.Web.UI.MasterPage
{
    // Website pages considered to be "catalog pages" that the visitor
    // can "Continue Shopping" to
    private static string[] catalogPages = { "~/Common/Default.aspx", 
        "~/Common/ItemList_Books.aspx", "~/Common/ItemDetail_Books.aspx", "~/Common/UsedAndNew_Books.aspx",
        "~/Common/ItemList_Mobile.aspx", "~/Common/ItemDetail_Computer.aspx", "~/Common/UsedAndNew_Mobile.aspx",
        "~/Common/ItemList_Computer.aspx", "~/Common/ItemDetail_Automobile.aspx", "~/Common/UsedAndNew_Computer.aspx",
        "~/Common/ItemList_Automobile.aspx", "~/Common/ItemDetail_Mobile.aspx", "~/Common/UsedAndNew_Automobile.aspx",
        "~/Common/ItemList_Electronics.aspx", "~/Common/ItemDetail_Electronics.aspx", "~/Common/UsedAndNew_Electronics.aspx",   
         "~/Common/ItemList_MovieDvdGame.aspx", "~/Common/ItemDetail_MovieDvdGame.aspx", "~/Common/UsedAndNew_MovieDvdGame.aspx",  
    
    };
    private static string[] reviewPage = { "~/Common/ProductReviews.aspx", };

    private string Book = "1";
    private string Automobile = "3";
    private string Computer = "4";
    private string Mobile = "2";
    private string RealEstate = "7";
    private string Electronics = "6";
    
    // Executes when any page based on this master page loads
    protected void Page_Load(object sender, EventArgs e)
    {
        string categoryId ="";

        //search_Ctrl.Country = lblLocation.Text;
        //search_Ctrl.Keyword = 
        lblLocation.Text = "Bangladesh";

        if (Request.QueryString["CID"] != null)
        {
            categoryId = Request.QueryString["CID"].ToString();
        }
        if (Request.QueryString["Location"] != null)
        {
            lblLocation.Text = Request.QueryString["Location"].ToString();
        }
        
        // Don't perform any actions on postback events
        string currentLocation = Request.AppRelativeCurrentExecutionFilePath;
        if (!IsPostBack)
        {
            /* Save the latest visited catalog page into the session
            to support "Continue Shopping" functionality */
            // Get the currently loaded page
            
            // If the page is one we want the visitor to "continue shopping"
            // to, then save it to visitor's Session
            for (int i = 0; i < catalogPages.GetLength(0); i++)
                if (String.Compare(catalogPages[i], currentLocation, true) == 0)
                {
                    // save the current location
                    Session["LastVisitedCatalogPage"] = Request.Url.ToString();
                    // stop the for loop from continuing
                    break;
                }
            for (int i = 0; i < reviewPage.GetLength(0); i++)
                if (String.Compare(reviewPage[i], currentLocation, true) == 0)
                {
                    // save the current location
                    Session["LastVisitedReviewPage"] = Request.Url.ToString();
                    // stop the for loop from continuing
                    break;
                }
        }
        //string _Current_Page = Request.Ap
        //foreach (string page in catalogPages)
        //{
        //    if (currentLocation != page)
        //    {
 
        //    }
        //}

        //*if (currentLocation == "~/Common/ReviewLogin.aspx")
        // {
        //    pnlMenu.Visible = false;
        //}

        if (currentLocation == "~/Common/ShoppingCart.aspx"
            || currentLocation == "~/Common/PlaceOrder.aspx" || currentLocation == "~/Common/OrderConfirmation.aspx")
        {
            
            //ViewCart_Ctrl1.Visible = false;
        }



        //Top banner datasource 
        //file has been defined here.
        #region FOR TOP BANNER SELECTION BASED ON PAGE


        if (currentLocation == "~/Common/ItemList_Books.aspx")
        {
            rotCommonPage.AdvertisementFile = "../App_Data/Book_Listing.config";
        }
        else if (currentLocation == "~/Common/ItemList_Automobile.aspx")
        {
            rotCommonPage.AdvertisementFile = "../App_Data/Automobile_Listing.config";
        }
        else if (currentLocation == "~/Common/ItemList_Mobile.aspx")
        {
            rotCommonPage.AdvertisementFile = "../App_Data/Mobile_Listing.config";
        }
        else if (currentLocation == "~/Common/ItemList_Computer.aspx")
        {
            rotCommonPage.AdvertisementFile = "../App_Data/Computer_Listing.config";
        }
        else if (currentLocation == "~/Common/ItemList_Electronics.aspx")
        {
            rotCommonPage.AdvertisementFile = "../App_Data/Electronics_Listing.config";
        }
        else if (currentLocation == "~/Common/ItemList_MovieDvdGame.aspx")
        {
            rotCommonPage.AdvertisementFile = "../App_Data/Electronics_Listing.config";
        }


        else if (currentLocation == "~/Common/ItemDetail_Books.aspx")
        {
            rotCommonPage.AdvertisementFile = "../App_Data/Book_Detail.config";
        }
        else if (currentLocation == "~/Common/ItemDetail_Automobile.aspx")
        {
            rotCommonPage.AdvertisementFile = "../App_Data/Automobile_Detail.config";
        }
        else if (currentLocation == "~/Common/ItemDetail_Mobile.aspx")
        {
            rotCommonPage.AdvertisementFile = "../App_Data/Mobile_Detail.config";
        }
        else if (currentLocation == "~/Common/ItemDetail_Computer.aspx")
        {
            rotCommonPage.AdvertisementFile = "../App_Data/Computer_Detail.config";
        }
        else if (currentLocation == "~/Common/ItemDetail_Electronics.aspx")
        {
            rotCommonPage.AdvertisementFile = "../App_Data/Electronics_Detail.config";
        }
        else if (currentLocation == "~/Common/ItemDetail_MovieDvdGame.aspx")
        {
            rotCommonPage.AdvertisementFile = "../App_Data/Electronics_Detail.config";
        }



        else if (currentLocation == "~/Common/UsedAndNew_Books.aspx")
        {
            rotCommonPage.AdvertisementFile = "../App_Data/Book_MultipleSeller.config";
        }
        else if (currentLocation == "~/Common/UsedAndNew_Automobile.aspx")
        {
            rotCommonPage.AdvertisementFile = "../App_Data/Automobile_MultipleSeller.config";
        }
        else if (currentLocation == "~/Common/UsedAndNew_Mobile.aspx")
        {
            rotCommonPage.AdvertisementFile = "../App_Data/Mobile_MultipleSeller.config";
        }
        else if (currentLocation == "~/Common/UsedAndNew_Computer.aspx")
        {
            rotCommonPage.AdvertisementFile = "../App_Data/Computer_MultipleSeller.config";
        }
        else if (currentLocation == "~/Common/UsedAndNew_Electronics.aspx")
        {
            rotCommonPage.AdvertisementFile = "../App_Data/Electronics_MultipleSeller.config";
        }
        else if (currentLocation == "~/Common/UsedAndNew_MovieDvdGame.aspx")
        {
            rotCommonPage.AdvertisementFile = "../App_Data/Electronics_MultipleSeller.config";
        }


        else if (currentLocation == "~/Common/ShoppingCart.aspx")
        {
            rotCommonPage.AdvertisementFile = "../App_Data/ShoppingCart.config";
        }
        else if (currentLocation == "~/Common/PlaceOrder.aspx")
        {
            rotCommonPage.AdvertisementFile = "../App_Data/PlaceOrder.config";
        }
        else if (currentLocation == "~/Common/OrderConfirmation.aspx")
        {
            rotCommonPage.AdvertisementFile = "../App_Data/OrderConfirmation.config";
        }


        else if (currentLocation == "~/Common/ProductReviews.aspx"
           || currentLocation == "~/Common/Review.aspx"
           || currentLocation == "~/Common/CreateReview.aspx")
        {
            if (categoryId == Automobile)
            {
                rotCommonPage.AdvertisementFile = "../App_Data/Automobile_Review.config";
            }
            else if (categoryId == Computer)
            {
                rotCommonPage.AdvertisementFile = "../App_Data/Computer_Review.config";
            }
            else if (categoryId == Book)
            {
                rotCommonPage.AdvertisementFile = "../App_Data/Book_Review.config";
            }
            else if (categoryId == Mobile)
            {
                rotCommonPage.AdvertisementFile = "../App_Data/Mobile_Review.config";
            }
            else if (categoryId == Electronics)
            {
                rotCommonPage.AdvertisementFile = "../App_Data/Electronics_Review.config";
            }
            else
            {
                rotCommonPage.AdvertisementFile = "../App_Data/HomePage.config";
            }

        }
        

        else
        {
            rotCommonPage.AdvertisementFile = "../App_Data/HomePage.config";
        }
        #endregion FOR TOP BANNER SELECTION BASED ON PAGE

    }
    //protected void btnSearchProduct_Click(object sender, ImageClickEventArgs e)
    //{
    //    if (!Page.IsPostBack)
    //    {
    //        site_search.Value = "";
    //    }
    //    if (site_search.Value != "")
    //    {
    //        Response.Redirect("../Common/SearchResult.aspx?Key=" + UTLUtilities.Encrypt(site_search.Value)
    //            + "&Loc=" + UTLUtilities.Encrypt(lblLocation.Text), true);
    //    }
    //}
}
