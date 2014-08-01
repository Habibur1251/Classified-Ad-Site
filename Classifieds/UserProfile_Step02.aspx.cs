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

public partial class Classifieds_UserProfile_Step02 : System.Web.UI.Page
{
    private void CheckUserSession()
    {
        if (this.Session["CLSF_PROFILE_EMAIL"] != null)
        {
            lblEmailAddress.Text = this.Session["CLSF_PROFILE_EMAIL"].ToString();
            this.Session["CLSF_PROFILE_EMAIL"] = null;
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
    }

    private void SendActivationLink()
    {        
        try
        {
            using (BOC_Classifieds_UserProfile bocUserProfile = new BOC_Classifieds_UserProfile())
            {
                EOC_PropertyBean eocPropertyBean = new EOC_PropertyBean();
                eocPropertyBean.Classifieds_UserProfile_LoginEmail = lblEmailAddress.Text;

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
                            string strAdvertiserName = string.Empty;
                            string strLinkID = string.Empty;
                            string strProfileID = string.Empty;
                            string strMailBody = string.Empty;

                            MailMaster mailMaster = new MailMaster();
                            HttpServerUtility httpObject = HttpContext.Current.Server;

                            strAdvertiserName = dtActivationLink.Rows[0]["AdvertiserName"].ToString();
                            strLinkID = UTLUtilities.Encrypt(dtActivationLink.Rows[0]["LinkID"].ToString());
                            strProfileID = UTLUtilities.Encrypt(dtActivationLink.Rows[0]["ProfileID"].ToString());

                            strMailBody = "<div style=\"font-family:Verdana; font-size:11px; padding-left:10px;\">";
                            strMailBody += "Dear <strong>" + strAdvertiserName + "</strong>,";
                            strMailBody += "<br/><br/>";
                            strMailBody += "Thank you for registration at <a href=\"http://www.apnerdeal.com\" target=\"_blank\">www.apnerdeal.com</a> ! We are pleased to welcome you to our service and we hope that you will find it very valuable and useful.";
                            strMailBody += "<br/><br/>";
                            strMailBody += "<strong>Completing the registration :</strong>";
                            strMailBody += "<br/><br/>";
                            strMailBody += "Your new account has been created, and only one more step is needed to complete the registration process.";
                            strMailBody += "<br/>";
                            strMailBody += "Please click <a href=\"http://www.apnerdeal.com/classifieds/UserProfile_Step03.aspx?LinkCode=" + httpObject.UrlEncode(strLinkID) + "&ProfileCode=" + httpObject.UrlEncode(strProfileID) + "\" target=\"_blank\">here</a> to complete the verification.";
                            strMailBody += "<br/><br/>";                            
                            strMailBody += "If you are unable to click the link above, please copy and paste the following link into your browser window.";
                            strMailBody += "<br/><br/>";
                            strMailBody += "http://www.apnerdeal.com/classifieds/UserProfile_Step03.aspx?LinkCode=" + httpObject.UrlEncode(strLinkID) + "&ProfileCode=" + httpObject.UrlEncode(strProfileID);
                            strMailBody += "<br/><br/>";
                            strMailBody += "Best regards,";
                            strMailBody += "<br/><br/>";
                            strMailBody += "ApnerDeal.com Team";
                            strMailBody += "<br/><br/>";
                            strMailBody += "<p style=\"font-weight:bold; font-size:12px;\">This is a System Generated email, please do not reply</p>";
                            strMailBody += "</div>";

                            //lblEmailAddress.Text = strMailBody;
                            mailMaster.MailTo = lblEmailAddress.Text;
                            mailMaster.MailFrom = "info@ApnerDeal.com";
                            mailMaster.MailSubject = "Activate your www.apnerdeal.com Account";
                            mailMaster.MailBody = strMailBody;
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
        catch (Exception Exp)
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
