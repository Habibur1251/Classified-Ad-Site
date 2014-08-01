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

public partial class Corporate_UserProfile_LoginInfo : System.Web.UI.Page
{
    public string actionStatus = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        this.actionStatus = Request.QueryString["mailSend"];
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            using (BOC_Corporate_UserProfile bocUserProfile = new BOC_Corporate_UserProfile())
            {
                EOC_PropertyBean eocPropertyBean = new EOC_PropertyBean();
                eocPropertyBean.Business_UserProfile_LoginEmail = txtLoginEmail.Text;

                DataTable dtLoginInfo = bocUserProfile.SelectRecord_ActivationLinks(eocPropertyBean);

                
                if (dtLoginInfo.Rows.Count > 0)
                {
                    string mailFrom = "info@apnerdeal.com";
                    string mailTo = txtLoginEmail.Text;
                    string mailSubject = "Your Login details";
                    string mailMessage = string.Empty;

                    mailMessage = "Dear " + dtLoginInfo.Rows[0]["BillingPerson"].ToString() + "," + Environment.NewLine;
                    mailMessage += "Your Login details: " + Environment.NewLine;
                    mailMessage += "<strong>Login Email :</strong>" + dtLoginInfo.Rows[0]["LoginEmail"].ToString() + Environment.NewLine;
                    mailMessage += "<strong>Password :</strong>" + dtLoginInfo.Rows[0]["LoginPassword"].ToString() + Environment.NewLine;
                    mailMessage += Environment.NewLine + Environment.NewLine;
                    mailMessage += "Thanks," + Environment.NewLine;
                    mailMessage += "ApnerDeal.com Team.";

                    MailMaster.SendMail(mailTo, mailFrom, mailSubject, mailMessage);
                    Response.Redirect("UserProfile_LoginInfo.aspx?mailSend=Yes");
                }
                else
                {
                    lblSystemMessage.Text = "Your entered email address is not associated with any of our corporate user account!";
                }
            }
        }
        catch (Exception exp)
        {
            lblSystemMessage.Text = exp.Message.ToString();
        }
    }
}
