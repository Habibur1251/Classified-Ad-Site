using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class Corporate_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //this.Session.Clear();

        if (!Page.IsPostBack)
        {
            rfvLoginEmail.Enabled = false;
            revLoginEmail.Enabled = false;
            rfvPassword.Enabled = false;

        }
        else
        {
            rfvLoginEmail.Enabled = false;
            revLoginEmail.Enabled = false;
            rfvPassword.Enabled = false;
        }

    }

    /// <summary>
    /// Description      : Check Business User login authentication.
    /// Stored Procedure : USP_CP_UsrPro_GetLoginInfo
    /// Associate Control: Executes in Page_Load event.
    /// </summary>
    private void IsLoginValid()
    {
        rfvLoginEmail.Enabled = true;
        revLoginEmail.Enabled = true;
        rfvPassword.Enabled = true;

        try
        {
            using (BOC_Corporate_UserProfile bocUserProfile = new BOC_Corporate_UserProfile())
            {
                EOC_PropertyBean eocPropertyBean = new EOC_PropertyBean();

                eocPropertyBean.Business_UserProfile_LoginEmail = txtLoginEmail.Text;
                eocPropertyBean.Business_UserProfile_LoginPassword = txtPassword.Text;

                if (!bocUserProfile.IsLoginValid(eocPropertyBean))
                {
                    lblSystemMessage.Text = "Access denied! Invalid Login Email or Password.";
                }
                else
                {
                    if (!eocPropertyBean.Business_UserProfile_IsActive)
                    {
                        lblSystemMessage.Text = "Your corporate account is not active.";
                    }
                    else
                    {
                        this.Session.Clear();
                        this.Session["CORP_PROFILE_CODE"] = eocPropertyBean.Business_UserProfile_ProfileID.ToString();
                        this.Session["CORP_COUNTRY_CODE"] = "18";//eocPropertyBean.Country_CountryID.ToString();
                        this.Session["COUNTRY"] = "Bangladesh";//eocPropertyBean.Country_CountryName;

                        this.Session["LOGINEMAIL"] = eocPropertyBean.Business_UserProfile_LoginEmail;
                        this.Session["COMPANYNAME"] = eocPropertyBean.Business_UserProfile_CompanyName;
                        this.Session["ISADMIN"] = eocPropertyBean.IsAdmin;

                        Response.Redirect("ControlPanel.aspx");
                    }
                }
            }
        }
        catch (Exception Exp)
        {
            lblSystemMessage.Text = Exp.Message.ToString();
        }
    }

    /// <summary>
    /// Description      : Saves sellers suggestion in table Seller_Landing_Suggestion
    /// Stored Procedure : USP_Admin_InsertSellersLandingPageSuggestion
    /// Associate Control: None
    /// </summary>
    private void AddRecord_SellerComments()
    {
        rfvLoginEmail.Enabled = true;
        revLoginEmail.Enabled = true;
        rfvPassword.Enabled = true;
        using (BC_LandingPageComments bc_LandingPageComments = new BC_LandingPageComments())
        {
            int intActionResult = 0;
            try
            {
                intActionResult = bc_LandingPageComments.SaveRecord_LandingPageComments(txtName.Text, txtCompany.Text, txtEmail.Text, txtPhone.Text, txtSubject.Text, txtComments.Text);
                if (intActionResult > 0)
                {
                    lblSystemMessageComments.Text = "Thank you for your suggestion.";
                }
            }
            catch (Exception ex)
            {
                lblSystemMessageComments.Text = "Error: " + ex.Message;
            }
        }

    }

    protected void btSubmit_Click(object sender, EventArgs e)
    {

        if (string.IsNullOrEmpty(txtName.Text) && string.IsNullOrEmpty(txtEmail.Text))
        {
            lblSystemMessageComments.Text = "Please enter name and email address.";
        }
        else if (string.IsNullOrEmpty(txtName.Text))
        {
            lblSystemMessageComments.Text = "Please enter name.";
        }
        else if (string.IsNullOrEmpty(txtEmail.Text))
        {
            lblSystemMessageComments.Text = "Please enter email address.";
        }
        else
        {
            this.AddRecord_SellerComments();
            txtName.Text = "";
            txtEmail.Text = "";
            txtComments.Text = "";
            txtCompany.Text = "";
            txtPhone.Text = "";
            txtSubject.Text = "";
            txtName.Text = "";


        }
    }

    protected void ImgbtnLogin_Click(object sender, ImageClickEventArgs e)
    {
        rfvLoginEmail.Enabled = true;
        revLoginEmail.Enabled = true;
        rfvPassword.Enabled = true;
        this.IsLoginValid();

    }

}
