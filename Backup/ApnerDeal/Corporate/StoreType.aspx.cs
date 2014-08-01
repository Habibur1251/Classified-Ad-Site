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

public partial class Corporate_StoreType : System.Web.UI.Page
{
    private int intProfileID = -1;
    private int intCountryID = -1;
     private bool _IsAdmin;

    public string GetDiscountType
    {
        get { return DiscountType.SelectedValue; }
    }

    private int ProfileID
    {
        get
        {
            object obj = ViewState["ProfileID"];
            if (obj != null)
            {
                return (int)obj;
            }
            return 0;
        }

        set { ViewState["ProfileID"] = value; }
    }

    public bool IsAdmin
    {
        get { return _IsAdmin; }
        set { _IsAdmin = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        UTLUtilities.CP_ActiveModule = 30;
        this.CheckUserSession();
        if (!Page.IsPostBack)
        {
           this.DiscountStoreType();
        }
    }

    private void CheckUserSession()
    {
        if (this.Session["CORP_PROFILE_CODE"] != null && this.Session["CORP_COUNTRY_CODE"] != null)
        {
            intCountryID = Convert.ToInt32(this.Session["CORP_COUNTRY_CODE"].ToString());
            IsAdmin = Convert.ToBoolean(this.Session["ISADMIN"]);

            if (IsAdmin.ToString() == "True")
            {
                ProfileID = Convert.ToInt32(this.Session["AdminCompanyProfileID"].ToString());
            }
            else
            {
                ProfileID = Convert.ToInt32(this.Session["CORP_PROFILE_CODE"].ToString());
            }
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
    }


    private void DiscountStoreType()
    {
        int inAction = -1;
        try
        {
            DiscountManegar manager = new DiscountManegar();
            DataTable dt = new DataTable();
            DiscountZone objDiscountZone = new DiscountZone();
            objDiscountZone.ProfileID = ProfileID;
            dt = manager.LoadDiscuntSoreType(objDiscountZone);
            if (dt.Rows.Count > 0)
            {
                Response.Redirect("SelectDiscountType.aspx");
            }
            else
            {
              
            }
        }
        catch (Exception ex)
        {
            lblSystemMessage.Text = ex.Message;
        }
    }


    private int AddRecord_DiscountStore()
    {
       int intActionResult = 0;
       DiscountZone discountZone = new DiscountZone();
       DateTimeValidation dateTimeValidation = new DateTimeValidation();
       DiscountManegar manager = new DiscountManegar();
       discountZone.ProfileID = Convert.ToInt16(ProfileID);
       discountZone.DiscountUserType = Convert.ToInt16(GetDiscountType);
       discountZone.IsActive = true;
       discountZone.CheckAdminForListing = false;
       discountZone.CheckAdminForListingFeatureStore = false;
       discountZone.IsAdminAuthentication = true;
       discountZone.UserType = Convert.ToBoolean(IsAdmin);

       try
       {
           if (ProfileID != 0 && policyRadioButtonList.SelectedValue.ToString()=="1")
           {
               intActionResult = manager.Ad_Store(discountZone);
           }
           else
           {
               intActionResult = -1;
           }

       }
       catch (Exception ex)
       {
           lblSystemMessage.Text = ex.Message;
       }

       return intActionResult;

    }


    protected void btnNextPage_Click(object sender, EventArgs e)
    {
        int intActionStatus = 0;
        if (Page.IsValid)
        {
            intActionStatus = this.AddRecord_DiscountStore();
        }
        else
        {
            //
        }
        if (intActionStatus == 0)
        {

            lblSystemMessage.Text = "Your Discount member type could not be saved.";
        }
        else if (intActionStatus > 0)
        {
            Response.Redirect("SelectDiscountType.aspx");
        }
        else if (intActionStatus == -1)
        {

            string javaScript =
           "<script language=JavaScript>\n" +
           "alert('To post your discount in ApnerDeal.com DiscountZone you are requierd to agree with out pricing policy.');\n" +
           "</script>";
            RegisterStartupScript("btnNextPage_Click", javaScript);
        }
    }
}
