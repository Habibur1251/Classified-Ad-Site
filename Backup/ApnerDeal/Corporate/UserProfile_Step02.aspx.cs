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

public partial class Corporate_UserProfile_Step02 : System.Web.UI.Page
{
    /// <summary>
    /// Description      : Checkinh the existence of user session.
    /// Stored Procedure : -
    /// Associate Control: Executes in Page_Load event.
    /// </summary>
    private void CheckUserSession()
    {
        if (this.Session["CORP_PROFILE_EMAIL"] != null)
        {
            lblEmailAddress.Text = this.Session["CORP_PROFILE_EMAIL"].ToString();
            this.Session["CORP_PROFILE_EMAIL"] = null;
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
    }

    /// <summary>
    /// Description      : Send activation link through email to newly registered user.
    /// Stored Procedure : -
    /// Associate Control: Executes in Page_Load event.
    /// </summary>
    private void SendActivationLink()
    {
        try
        {
            using (BOC_Corporate_UserProfile bocUserProfile = new BOC_Corporate_UserProfile())
            {
                EOC_PropertyBean eocPropertyBean = new EOC_PropertyBean();
                eocPropertyBean.Business_UserProfile_LoginEmail = lblEmailAddress.Text;

                int intActionResult = bocUserProfile.AddRecord_ActivationLinks(eocPropertyBean);

                if (intActionResult == -1)
                {
                    lblSystemMessage.Text = "User Profile not found. Please try after sometimes.";
                }
                else
                {
                    if (intActionResult > 0)
                    {
                        DataTable dtActivationLink = bocUserProfile.SelectRecord_ActivationLinks(eocPropertyBean);

                        if (dtActivationLink.Rows.Count > 0)
                        {
                            string companyName = string.Empty;
                            string linkID = string.Empty;
                            string profileID = string.Empty;
                            string mailBody = string.Empty;

                            MailMaster mailMaster = new MailMaster();
                            HttpServerUtility httpObject = HttpContext.Current.Server;

                            companyName = dtActivationLink.Rows[0]["CompanyName"].ToString();
                            linkID = UTLUtilities.Encrypt(dtActivationLink.Rows[0]["LinkID"].ToString());
                            profileID = UTLUtilities.Encrypt(dtActivationLink.Rows[0]["ProfileID"].ToString());

                            mailBody = "<div style=\"font-family:Verdana; font-size:11px; padding-left:10px;\">";
                            mailBody += "Dear " + companyName + ",";
                            mailBody += "<br/><br/>";

                            mailBody += "Thank you for registration at <a href=\"http://www.apnerdeal.com\"> www.apnerdeal.com</a> ! We are pleased to welcome you to our service and we hope that you will find it very valuable and useful.";
                            mailBody += "<br/><br/>";
                            mailBody += "Your new account has been created, and only one more step is needed to login.";
                            mailBody += "<br/>";
                            mailBody += "<br/>";
                            
                            mailBody += "Please click <a href=\"http://www.apnerdeal.com/Corporate/Default.aspx" + "\">here</a> to post discounts or deals.";
                            mailBody += "<br/><br/>";

                            mailBody += "Please click <a href=\"http://www.apnerdeal.com/Classifieds/Default.aspx" + "\">here</a> to post Classified Ad.";
                            mailBody += "<br/><br/>";

                            mailBody += "If you are unable to click the link above, please copy and paste the following link into your browser window:";
                            mailBody += "<br/><br/>";
                            mailBody += "http://www.apnerdeal.com/corporate/UserProfile_Step03.aspx?LinkCode=" + httpObject.UrlEncode(linkID) + "&ProfileCode=" + httpObject.UrlEncode(profileID);
                            mailBody += "<br/><br/>";
                            mailBody += "Best regards,";
                            mailBody += "<br/><br/>";
                            mailBody += "ApnerDeal.com Team";
                            mailBody += "<br/><br/>";
                            mailBody += "<p style=\"font-weight:bold; font-size:12px;\">This is a System Generated email, please do not reply.</p>";
                            mailBody += "</div>";

                            mailMaster.MailTo = lblEmailAddress.Text;
                            mailMaster.MailFrom = "info@apnerdeal.com";
                            mailMaster.MailSubject = "Welcome to your www.ApnerDeal.com account";
                            mailMaster.MailBody = mailBody;
                            mailMaster.IsHTMLBody = true;
                            
                            mailMaster.SendMail();                            
                        }
                    }
                    else
                    {
                        lblSystemMessage.Text = "System failed to register your profile. Please try after sometimes.";
                    }
                }            
            }
        }
        catch(Exception Exp)
        {
            lblSystemMessage.Text = Exp.Message.ToString();
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.CheckUserSession();
        this.SendActivationLink();
    }
}
