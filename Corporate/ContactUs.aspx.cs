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

public partial class Corporate_ContactUs : System.Web.UI.Page
{
    private int intProfileID = -1;
    private int intCountryID = -1;

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

    protected void Page_Load(object sender, EventArgs e)
    {
        this.CheckUserSession();
        UTLUtilities.CP_ActiveModule = 7;
    }
    protected void btnSendMail_Click(object sender, EventArgs e)
    {
        try
        {
            MailMaster.SendMail("info@apnerdeal.com", txtEmail.Text, txtSubject.Text, txtMessage.Text);
            txtEmail.Text = "";
            txtSubject.Text = "";
            txtMessage.Text = "";

            lblSystemMessage.Text = "Your email has been sent successfully.";
        }
        catch (Exception exp)
        {
            lblSystemMessage.Text = exp.ToString();
        }
    }
}
