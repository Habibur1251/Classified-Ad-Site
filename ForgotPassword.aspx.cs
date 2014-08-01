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

public partial class ForgotPassword : System.Web.UI.Page
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
            using (BC_CommonUser userProfile = new BC_CommonUser())
            {

                DataTable dtLoginInfo = userProfile.SelectRecord_ActivationLinks(txtLoginEmail.Text);
                if (dtLoginInfo.Rows.Count > 0)
                {
                    string mailFrom = "info@apnerdeal.com";
                    string mailTo = txtLoginEmail.Text;
                    string mailSubject = "Your Login details for www.ApnerDeal.com";
                    string mailMessage = string.Empty;

                    mailMessage = "Dear " + dtLoginInfo.Rows[0]["BillingPersonOrAdvertiserName"].ToString() + "," + Environment.NewLine;
                    mailMessage += "<br/><br/>";
                    mailMessage += "As you requested Your Login details are as below: " + Environment.NewLine;
                    mailMessage += "<br/><br/>";
                    mailMessage += "<strong>Login Email :</strong>" + dtLoginInfo.Rows[0]["LoginEmail"].ToString() + Environment.NewLine;
                    mailMessage += "<br/><br/>";
                    mailMessage += "<strong>Password :</strong>" + dtLoginInfo.Rows[0]["LoginPassword"].ToString() + Environment.NewLine;
                    mailMessage += Environment.NewLine + Environment.NewLine;
                    mailMessage += "<br/><br/>";
                    mailMessage += "Thanks," + Environment.NewLine;
                    mailMessage += "<br/><br/>";
                    mailMessage += "ApnerDeal.com Team.";

                    MailMaster.SendMail(mailTo, mailFrom, mailSubject, mailMessage);
                    Response.Redirect("ForgotPassword.aspx?mailSend=Yes");
                }
                else
                {
                    lblSystemMessage.Text = "Your entered email address is not associated with any of our user account!";
                }
            }
        }
        catch (Exception exp)
        {
            lblSystemMessage.Text = exp.Message.ToString();
        }
    }
}
