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


public partial class Classifieds_Default : System.Web.UI.Page
{
    private void IsLoginValid()
    {
        try
        {
            using (BOC_Classifieds_UserProfile bocUserProfile = new BOC_Classifieds_UserProfile())
            {
                EOC_PropertyBean eocPropertyBean = new EOC_PropertyBean();

                eocPropertyBean.Classifieds_UserProfile_LoginEmail = txtLoginEmail.Text;
                eocPropertyBean.Classifieds_UserProfile_LoginPassword = txtPassword.Text;

                if (!bocUserProfile.IsLoginValid(eocPropertyBean))
                {
                    lblSystemMessage.Text = "Access denied! Invalid Login Email or Password.";
                }
                else
                {
                    if (!eocPropertyBean.Classifieds_UserProfile_IsActive)
                    {
                        lblSystemMessage.Text = "Your classified account is not active.";
                    }
                    else
                    {
                        this.Session.Clear();
                        this.Session["CLSF_PROFILE_CODE"] = eocPropertyBean.Classifieds_UserProfile_ProfileID.ToString();
                        this.Session["CLSF_COUNTRY_CODE"] = eocPropertyBean.Country_CountryID.ToString();
                        this.Session["IS_ADMIN"] = eocPropertyBean.IsAdmin;
                        this.Session["COUNTRY"] = eocPropertyBean.Country_CountryName;
                        this.Session["LOGINEMAIL"] = eocPropertyBean.Classifieds_UserProfile_LoginEmail;
                        this.Session["ADVERTISERNAME"] = eocPropertyBean.Classifieds_UserProfile_AdvertiserName;
                        

                        //this.Session["CLSF_PROVINCE_CODE"] = eocPropertyBean.Province_ProvinceID.ToString();

                        Response.Redirect("ControlPanel.aspx", false);
                    }
                }
            }
        }
        catch (Exception Exp)
        {
            lblSystemMessage.Text = Exp.Message.ToString();
        }
    }            

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Session.Clear();

        if (Page.IsPostBack)
        {
            //this.IsLoginValid();
        }
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        this.IsLoginValid();
    }
}
