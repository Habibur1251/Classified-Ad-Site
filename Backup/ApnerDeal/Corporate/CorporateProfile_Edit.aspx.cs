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

public partial class Corporate_CorporateProfile_Edit : System.Web.UI.Page
{
    private int intProfileID = -1;
    private int intCountryID = -1;
    private string strSystemMessage = string.Empty;

    private void CheckUserSession()
    {
        if (this.Session["CORP_PROFILE_CODE"] != null && this.Session["CORP_COUNTRY_CODE"] != null)
        {
            intProfileID = Convert.ToInt32(this.Session["CORP_PROFILE_CODE"].ToString());
            intCountryID = Convert.ToInt32(this.Session["CORP_COUNTRY_CODE"].ToString());
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
    }
    private void LoadRecord_Country()
    {
        try
        {
        //    using (BOC_Corporate_BusinessProfile bocBusinessProfile = new BOC_Corporate_BusinessProfile())
        //    {
        //        ddlCountry.DataSource = bocBusinessProfile.LoadRecord_Country();
        //        ddlCountry.DataValueField = "CountryID";
        //        ddlCountry.DataTextField = "Country";
        //        ddlCountry.DataBind();
        //    }
        }
        catch (Exception Exp)
        {
            lblSystemMessage.Text = Exp.Message.ToString();
        }
    }
    private void LoadRecord_BusinessCategory()
    {
        try
        {
        //    using (BOC_Corporate_BusinessProfile bocBusinessProfile = new BOC_Corporate_BusinessProfile())
        //    {
        //        ddlBusinessType.DataSource = bocBusinessProfile.LoadRecord_BusinessCategory();
        //        ddlBusinessType.DataValueField = "BusinessID";
        //        ddlBusinessType.DataTextField = "BusinessCategory";
        //        ddlBusinessType.DataBind();
        //    }
        }
        catch (Exception Exp)
        {
            lblSystemMessage.Text = Exp.Message.ToString();
        }
    }
    private void SelectRecord_BusinessProfile(int intProfileID)
    {
        try
        {
            ////using (BOC_Corporate_BusinessProfile bocBusinessProfile = new BOC_Corporate_BusinessProfile())
            ////{
            ////    EOC_PropertyBean eocPropertyBean = new EOC_PropertyBean();
            ////    eocPropertyBean.BusinessProfile_ProfileID = intProfileID;

            ////    if (bocBusinessProfile.SelectRecord_BusinessProfile(eocPropertyBean))
            //    {
            //    //    txtLoginEmail1.Text = eocPropertyBean.BusinessProfile_LoginEmail;
            //    //    txtLoginEmail2.Text = eocPropertyBean.BusinessProfile_LoginEmail;
            //    //    txtCompanyName.Text = eocPropertyBean.BusinessProfile_CompanyName;
            //    //    ddlBusinessType.SelectedValue = eocPropertyBean.BusinessCategory_BusinessID.ToString();
            //    //    ddlCountry.SelectedValue = eocPropertyBean.Country_CountryID.ToString();
            //    //    txtBusinessAddress.Text = eocPropertyBean.BusinessProfile_BusinessAddress;
            //    //    txtContactPhone.Text = eocPropertyBean.BusinessProfile_ContactPhone;
            //    //    txtCompanyURL.Text = eocPropertyBean.BusinessProfile_CompanyURL;
            //    //    txtBillingPerson.Text = eocPropertyBean.BusinessProfile_BillingPerson;
            //    //    txtWebInventoryManager.Text = eocPropertyBean.BusinessProfile_WebInventoryManager;
            //    //    txtCompanyProfile.Text = eocPropertyBean.BusinessProfile_CompanyProfile;
            //    }
            //    else
            //    {
            //        strSystemMessage = "Corporate Profile not found! ";
            //        strSystemMessage += "<br/><br/>";
            //        strSystemMessage += "<strong>How did this happen? </strong>";
            //        strSystemMessage += "<ul>";
            //        strSystemMessage += "<li>You login session may be expired.</li>";
            //        strSystemMessage += "<li>Your Corporate Account may be deleted by bdhit authority for some reason. </li>";
            //        strSystemMessage += "</ul>";

            //        lblSystemMessage.Text = strSystemMessage;
            //    }
            //}
        }
        catch (Exception Exp)
        {
            lblSystemMessage.Text = Exp.Message.ToString();
        }
    }
    private int UpdateRecord_BusinessProfile()
    {
        int intActionResult = 0;

        try
        {
            //using (BOC_Corporate_BusinessProfile bocBusinessProfile = new BOC_Corporate_BusinessProfile())
            //{
            //    EOC_PropertyBean eocPropertyBean = new EOC_PropertyBean();

                //eocPropertyBean.BusinessProfile_ProfileID = intProfileID;
                //eocPropertyBean.BusinessProfile_LoginEmail = txtLoginEmail1.Text;
                //eocPropertyBean.BusinessProfile_CompanyName = txtCompanyName.Text;
                //eocPropertyBean.BusinessCategory_BusinessID = Convert.ToInt32(ddlBusinessType.SelectedItem.Value);
                //eocPropertyBean.Country_CountryID = Convert.ToInt32(ddlCountry.SelectedItem.Value);
                //eocPropertyBean.BusinessProfile_BusinessAddress = txtBusinessAddress.Text;
                //eocPropertyBean.BusinessProfile_ContactPhone = txtContactPhone.Text;
                //eocPropertyBean.BusinessProfile_CompanyURL = txtCompanyURL.Text;
                //eocPropertyBean.BusinessProfile_BillingPerson = txtBillingPerson.Text;
                //eocPropertyBean.BusinessProfile_WebInventoryManager = txtWebInventoryManager.Text;
                //eocPropertyBean.BusinessProfile_CompanyProfile = txtCompanyProfile.Text;
                //eocPropertyBean.UpdatedOn = DateTime.Now;

                //intActionResult = bocBusinessProfile.UpdateRecord_BusinessProfile(eocPropertyBean);
          //  }
        }
        catch (Exception Exp)
        {
            lblSystemMessage.Text = Exp.Message.ToString();
        }

        return intActionResult;
    }    
    protected void Page_Load(object sender, EventArgs e)
    {
        this.CheckUserSession();

        if (!Page.IsPostBack)
        {
            this.LoadRecord_BusinessCategory();
            this.LoadRecord_Country();

            if (!string.IsNullOrEmpty(intProfileID.ToString()))
            {
                this.SelectRecord_BusinessProfile(intProfileID);
            }
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int intActionResult = 0;
        string strSystemMessage = string.Empty;

        intActionResult = this.UpdateRecord_BusinessProfile();

        if (intActionResult > 0)
        {
            Response.Redirect("ControlPanel.aspx");
        }
        if (intActionResult == -1)
        {
            strSystemMessage = "This email address already used in another company profile.";
            strSystemMessage += "<br/><br/>";
            strSystemMessage += "<strong>How did this happen? </strong>";
            strSystemMessage += "<ul>";
            strSystemMessage += "<li>You may have already registered with www.apnerdeal.com earlier but forgot about it.</li>";
            strSystemMessage += "<li>If you share your email address with someone else, they may have signed up for a ApnerDeal corporate account with this address.</li>";
            strSystemMessage += "</ul>";

            lblSystemMessage.Text = strSystemMessage.ToString();
        }
        if (intActionResult == -2)
        {
            strSystemMessage = "This Company Name already registered with ApnerDeal.com";
            strSystemMessage += "<br/><br/>";
            strSystemMessage += "<strong>How did this happen? </strong>";
            strSystemMessage += "<ul>";
            strSystemMessage += "<li>You may have already registered with www.apnerdeal.com earlier but forgot about it.</li>";
            strSystemMessage += "<li>Someone else, may have signed up for a ApnerDeal corporate account with this Company Name.</li>";
            strSystemMessage += "</ul>";

            lblSystemMessage.Text = strSystemMessage.ToString();
        }
    }
}
