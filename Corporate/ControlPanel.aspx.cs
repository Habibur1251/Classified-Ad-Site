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
using TinyMceEditor;
using System.Net.Mail;
using System.ComponentModel;
using System.Net;
using System.Text.RegularExpressions;
using System.Text;
using System.IO;
using System.Collections.Generic;

public partial class Corporate_ControlPanel : System.Web.UI.Page
{
    private int intProfileID = -1;
    private int intCountryID = -1;
    private bool _BusinessUser = true;
    private int intProductID = -1;
    private int intCategoryID = -1;
    private string strProductID = string.Empty;
    private string strCategoryID = string.Empty;
    private string strProfileID = string.Empty;
    private bool success = true;
    private int intCouponID = -1;
    private int intEmailTemplateID = -1;
    private int intProfileIDDiscount = -1;
    private string strCouponID = string.Empty;
    private string strCouponCode = string.Empty;
    private string strProfileIDDiscount = string.Empty;
 
   
    private bool _IsAdmin;
    public bool IsAdmin
    {
        get { return _IsAdmin; }
        set { _IsAdmin = value; }
    }

    protected int Total_RecordDiscount
    {
        get
        {
            object obj = ViewState["Total_RecordDiscount"];
            if (obj != null)
            {
                return (int)obj;
            }
            return 0;
        }
        set { ViewState["Total_RecordDiscount"] = value; }
    }

    protected int Total_RecordBoroMelaDiscountSpecialDiscount
    {
        get
        {
            object obj = ViewState["Total_RecordBoroMelaDiscountSpecialDiscount"];
            if (obj != null)
            {
                return (int)obj;
            }
            return 0;
        }
        set { ViewState["Total_RecordBoroMelaDiscountSpecialDiscount"] = value; }
    }



    private void CheckUserSession()
    {
        if (this.Session["CORP_PROFILE_CODE"] != null && this.Session["CORP_COUNTRY_CODE"] != null)
        {
            intProfileID = Convert.ToInt32(this.Session["CORP_PROFILE_CODE"].ToString());
            intCountryID = Convert.ToInt32(this.Session["CORP_COUNTRY_CODE"].ToString());
            IsAdmin = Convert.ToBoolean(this.Session["ISADMIN"]);
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
    }

    
    protected void Page_Load(object sender, EventArgs e)
    {
        this.CheckUserSession();
        if (!Page.IsPostBack)
        {
            this.LoadRecord_DiscountedCompany();
            ddlCompanyName.SelectedValue = intProfileID.ToString();
            //ddlCompanyNameBoroMelaDiscountSpecial.SelectedValue = intProfileID.ToString();
            this.LoadList_PostedAllDiscount();
            
        }
       
    }

    private void LoadRecord_DiscountedCompany()
    {
        try
        {
            DiscountManegar manager = new DiscountManegar();
            DataTable dt = new DataTable();
            DiscountZone discountZone = new DiscountZone();
            discountZone.ProfileID = intProfileID;
            dt = manager.LoadDiscuntCompany(discountZone);
            if (dt.Rows.Count > 0)
            {

                ddlCompanyName.DataSource = dt;
                ddlCompanyName.DataValueField = "ProfileID";
                ddlCompanyName.DataTextField = "CompanyName";
                ddlCompanyName.DataBind();
            }
            else
            {
                lblSystemMessage.Text = "No Company available";
            }
        }
        catch (Exception Exp)
        {
            lblSystemMessage.Text = Exp.Message.ToString();
        }
    }

    protected void btnChangeCategory_Click(object sender, EventArgs e)
    {


    }

    private void LoadList_PostedAllDiscount()
    {
        try
        {
            using (BC_Product bc = new BC_Product())
            {
                DataTable dt = new DataTable();
                dt = bc.GetList_BS_PostedAllUserDiscount(intProfileID);

                if (dt.Rows.Count > 0)
                {

                    GridView2.DataSource = dt;
                    GridView2.DataBind();
                    Total_RecordDiscount = dt.Rows.Count;
                }
                else
                {
                    GridView2.DataSource = null;
                    GridView2.DataBind();

                    lblSystemMessageDiscount.Text = "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" align=\"center\" style=\"width:606px; background-color:#3B5998;\">";
                    lblSystemMessageDiscount.Text += "<tr>";
                    lblSystemMessageDiscount.Text += "<td align=\"center\" style=\"height:45px; color:#FFFFFF; font-size:14px; font-weight:bold;\" valign=\"middle\">";
                    lblSystemMessageDiscount.Text += "<span class=\"title\" style=\"font-size:14px;\">";
                    lblSystemMessageDiscount.Text += "</span> You have not posted any Corporate Ads yet.";
                    lblSystemMessageDiscount.Text += "</td>";
                    lblSystemMessageDiscount.Text += "</tr>";
                    lblSystemMessageDiscount.Text += "</table>";
                    lblSystemMessageDiscount.Text = UTLUtilities.ShowGeneralMessageCP("No Discount posted");
                }

            }
        }
        catch (Exception ex)
        {
            lblSystemMessageDiscount.Text = ex.Message.ToString();
        }
    }

    protected void GridView11_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Change")
        {


        }
        else if (e.CommandName == "Update")
        {

        }

    }


    protected void ddlCompanyName_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            using (BC_Product bc = new BC_Product())
            {
                DataTable dt = new DataTable();
                dt = bc.GetList_BS_PostedAllUserDiscount(Convert.ToInt16(ddlCompanyName.SelectedValue.ToString()));

                if (dt.Rows.Count > 0)
                {

                    GridView2.DataSource = dt;
                    GridView2.DataBind();
                    Total_RecordDiscount = dt.Rows.Count;
                }
                else
                {
                    GridView2.DataSource = null;
                    GridView2.DataBind();

                    lblSystemMessageDiscount.Text = "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" align=\"center\" style=\"width:606px; background-color:#3B5998;\">";
                    lblSystemMessageDiscount.Text += "<tr>";
                    lblSystemMessageDiscount.Text += "<td align=\"center\" style=\"height:45px; color:#FFFFFF; font-size:14px; font-weight:bold;\" valign=\"middle\">";
                    lblSystemMessageDiscount.Text += "<span class=\"title\" style=\"font-size:14px;\">";
                    lblSystemMessageDiscount.Text += "</span> You have not posted any Corporate Ads yet.";
                    lblSystemMessageDiscount.Text += "</td>";
                    lblSystemMessageDiscount.Text += "</tr>";
                    lblSystemMessageDiscount.Text += "</table>";
                    lblSystemMessageDiscount.Text = UTLUtilities.ShowGeneralMessageCP("No Discount posted");
                }

            }
        }
        catch (Exception ex)
        {
            lblSystemMessageDiscount.Text = ex.Message.ToString();
        }
    }

    protected void saveChangeInnerDiscount(object sender, EventArgs e)
    {
        int rowsCount = GridView2.Rows.Count;
        GridViewRow gridRow;
        TextBox effectiveDateTextBox;
        TextBox expirydateTextBox;
        DateTime effectiveDate;
        DateTime expirydate;
        DateTimeValidation.Date_Validation dateValidation = new DateTimeValidation.Date_Validation();
        for (int i = 0; i <= rowsCount; i++)
        {
            gridRow = GridView2.Rows[i];
            strCouponID = GridView2.DataKeys[i]["CouponID"].ToString();
            strCouponCode = GridView2.DataKeys[i]["CouponCode"].ToString();
            strProfileIDDiscount = GridView2.DataKeys[i]["ProfileID"].ToString();
            effectiveDateTextBox = (TextBox)gridRow.FindControl("effectiveDateTextBox");
            expirydateTextBox = (TextBox)gridRow.FindControl("expirydateTextBox");
            if (Int32.TryParse(strCouponID, out intCouponID) && Int32.TryParse(strProfileIDDiscount, out intProfileIDDiscount) && DateTime.TryParse(dateValidation.date_Format_Back_End(effectiveDateTextBox.Text.Trim()), out effectiveDate) && DateTime.TryParse(dateValidation.date_Format_Back_End(expirydateTextBox.Text.Trim()), out expirydate))
            {
                try
                {
                    using (BC_Product bcProduct = new BC_Product())
                    {
                        DateTime EffDate = Convert.ToDateTime(effectiveDate);
                        success = success && bcProduct.Update_DiscounteffectiveDate(intCouponID, intProfileIDDiscount, effectiveDate, expirydate);
                    }

                }
                catch (Exception ex)
                {
                    success = false;
                    lblSystemMessageDiscount.Text = UTLUtilities.ShowErrorMessage("Error:" + ex.Message);
                }

            }
            else
            {
                success = false;
            }
            lblSystemMessageDiscount.Text = success ?
                 UTLUtilities.ShowSuccessMessage("<br />Your discount date range were successfully updated!<br />") :
                 UTLUtilities.ShowGeneralMessage("<br />Some Effective Date or Expiry Date updates failed! Please verify your Ads List!<br />");
        }

        this.LoadList_PostedAllDiscount();

    }

    protected void ActiveInactiveDiscount_Click(object sender, EventArgs e)
    {

        LinkButton lbtnChangeDiscount = (LinkButton)sender;

        string info = lbtnChangeDiscount.CommandArgument;

        string[] arg = new string[3];

        char[] splitter = { ';' };

        arg = info.Split(splitter);

        string CouponID = arg[0];

        string ProfileID = arg[1];

        string CouponCode = arg[2];

        this.UpdateActivationStatusDiscount(Convert.ToInt32(CouponID), Convert.ToInt32(ProfileID), CouponCode);
    }

    private void UpdateActivationStatusDiscount(int CouponID, int ProfileID, string CouponCode)
    {
        try
        {
            using (BC_Product bcProduct = new BC_Product())
            {
                int efectedRow = bcProduct.Update_ActivationStatusDiscount(CouponID, ProfileID, CouponCode);
                if (efectedRow > 0)
                {
                    this.LoadList_PostedAllDiscount();
                }
            }

        }
        catch (Exception Exp)
        {
            lblSystemMessageDiscount.Text = "Error: " + Exp.Message;
        }
    }

    protected void resetvaluesButtonDiscount_Click(object sender, EventArgs e)
    {
        this.LoadList_PostedAllDiscount();
    }




    

    protected void ActiveInactiveBoroMelaDiscountSpecial_Click(object sender, EventArgs e)
    {

        LinkButton lbtnChangeDiscount = (LinkButton)sender;

        string info = lbtnChangeDiscount.CommandArgument;

        string[] arg = new string[3];

        char[] splitter = { ';' };

        arg = info.Split(splitter);

        string BoroMelaDiscountSpecialID = arg[0];

        string ProfileID = arg[1];

        string DealTitle = arg[2];

       
    }
    
}
