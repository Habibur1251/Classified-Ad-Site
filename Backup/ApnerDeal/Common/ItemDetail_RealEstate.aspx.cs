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

public partial class Common_ItemDetail_RealEstate : System.Web.UI.Page
{

    #region PROPERTY
    private DataTable dtRealEstateRecord;     
    private string strPID = string.Empty;
    private string selectedLocation = string.Empty;
    public string Currency = "";
    private string ProjectName
    {
        get
        {
            object obj = ViewState["ProjectName"];
            if (obj != null)
            {
                return obj.ToString();
            }
            return "";
        }
        set
        {
            ViewState["ProjectName"] = value;
        }
    }
    private int _ProductID;

    public int ProductID
    {
        get { return _ProductID; }
        set { _ProductID = value; }
    }

    //private int ProductID
    //{
    //    get
    //    {
    //        object obj = ViewState["ProductID"];
    //        if (obj != null)
    //        {
    //            return Convert.ToInt32(obj);
    //        }
    //        return -1;
    //    }
    //    set
    //    {
    //        ViewState["ProductID"] = value;
    //    }
    //}

    //public int SubcategoryID
    //{
    //    get { return intSubcategoryID; }
    //}
    //public int SecondSubcatID
    //{
    //    get { return intSecondSubcatID; }
    //}
    public string Location
    {
        get { return selectedLocation; }
        set { selectedLocation = value; }
    }

    //public string DeliveryOption
    //{
    //    get
    //    {
    //        object obj = ViewState["DeliveryOption"];
    //        if (obj != null)
    //        {
    //            return obj.ToString();
    //        }
    //        return "";
    //    }
    //    set
    //    {
    //        ViewState["DeliveryOption"] = value;

    //    }
    //}
    //private UserControl_ContactSeller_Link_Ctrl ClOrderCtrl = null;


    #endregion PROPERTY

    #region CHECKQUERYSTRING METHOD

    /// <summary>
    /// Checks the query string.
    /// </summary>
    /// <returns></returns>
    private void CheckQueryString()
    {

        bool blnFlag = false;       
           
            object objPID = Request.QueryString["PID"];
            object objLocation = Request.QueryString["Location"];
            //strCID = Request.QueryString["CID"];
            //strSCID = Request.QueryString["SCID"];
            //strSSCID = Request.QueryString["SSCID"];
            //strProductSellerDetailID = Request.QueryString["PSID"];
            
        
            if (objPID != null)
            {
                if (UTLUtilities.IsNumeric(objPID))
                {
                    ProductID = Convert.ToInt32(objPID);
                    blnFlag = true;
                }
                else
                {
                    blnFlag = false;
                }
            }
            else
            {
                blnFlag = false;
            }
        
        if(!blnFlag)
        {
            Response.Redirect("../Default.aspx", false);
        }
    }




    #endregion CHECKQUERYSTRING METHOD

    protected void lbtnEmailFriend_Click(object sender, EventArgs args)
    {
        string strUrl = Request.Url.ToString();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        int CategoryID = 7;
        this.CheckQueryString();
        if (!Page.IsPostBack)
        {
            this.IncrementProductCounter(CategoryID, ProductID);
            this.LoadDetailRealEstate(ProductID);
        }
    }

    #region LoadMethods

    private void LoadDetailRealEstate(int _ProductID)
    {
        RealEstate objRealEstate = new RealEstate();
        RealEstateManager objrealEstatemanager = new RealEstateManager();
        objRealEstate.ProductID = _ProductID;
        
        DataTable dt = objrealEstatemanager.LoadRecord_Detail_RealEstate(objRealEstate);
        if (dt.Rows.Count > 0)
        {
            fvRealEstateDetail.DataSource = dt;
            fvRealEstateDetail.DataBind();
        }
    }

    #endregion LoadMethods

    protected void fvRealEstateDetail_ItemCreated(object sender, EventArgs e)
    {


        if (fvRealEstateDetail.Row.RowType == DataControlRowType.DataRow)
        {
            int CATEGORYID = 7;
            string strUrlContactSeller = Request.Url.ToString();
            strUrlContactSeller = Server.UrlEncode(strUrlContactSeller);
            //ClOrderCtrl = (UserControl_ContactSeller_Link_Ctrl)LoadControl("~/UserControl/ContactSeller_Link_Ctrl.ascx");
            //ClOrderCtrl.strUrlContactSeller = strUrlContactSeller.ToString();
            //ClOrderCtrl.CategoryID = CATEGORYID.ToString();
            //ClOrderCtrl.ProductSellerDetailID = fvRealEstateDetail.DataKey["ProductID"].ToString();

            PlaceHolder ph = (PlaceHolder)fvRealEstateDetail.Row.FindControl("phAddToCart");
            //ph.Controls.Add(ClOrderCtrl);

            LinkButton btn = (LinkButton)fvRealEstateDetail.Row.FindControl("lbtnEmailFriend");
            string strUrl = Request.Url.ToString();
            strUrl = Server.UrlEncode(strUrl);
            btn.Attributes.Add("onclick", "window.open('EmailAFriend.aspx?data=" + strUrl + "', 'EmailAFriend','width=600,height=500,scrollbars=no,resizable=no,top=170,left=280'); return false;");

            
        }


    }


    #region GENERAL METHODS
    
    /// <summary>
    /// Increments a product HitCounter once for a specific day.
    /// </summary>
    /// <param name="_CategoryID"></param>
    /// <param name="_ProductSellerDetailID"></param>
    private void IncrementProductCounter(int _CategoryID, int _ProductSellerDetailID)
    {
        try
        {
            CommonProduct objProduct = new CommonProduct();
            objProduct.CategoryID = _CategoryID;
            objProduct.ProductSellerDetailID = _ProductSellerDetailID;

            ProductHandler handler = new ProductHandler();
            handler.IncrementProductCounter(objProduct);

        }
        catch (Exception ex)
        {
            lblSystemMessage.Text = ex.Message;
        }
    }

    #endregion GENERAL METHODS

}
