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

public partial class Common_EmailAFriend : System.Web.UI.Page
{
    private string strUrl = "";
    private void SendEmail()
    {
        if (Page.IsValid)
        {

            try
            {
                BC_EmailFormat_Handler bcEmail = new BC_EmailFormat_Handler();
                string strMailBody = bcEmail.Send_Email_ToA_Friend("ApnerDeal.com Mail a Friend Service", txtFriendName.Text, txtSenderName.Text, strUrl);
                //Label1.Text = strMailBody;
                string mailTo = txtFriendEmailAddress.Text;
                string mailFrom = "info@apnerdeal.com";
                string mailSubject = "ApnerDeal.com SELLING PRODUCT INFORMATION";
                MailMaster.SendMail(mailTo, mailFrom, mailSubject, strMailBody);
            }
            catch (Exception ex)
            {
                multiview.ActiveViewIndex = 2;
                MailMaster.SendMail("moinur@gmail.com", "info@apnerdeal.com", "Error at Mail a friend service", ex.Message);
            }
            multiview.ActiveViewIndex = 1;
        }
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        if (ViewState["strUrl"] != null)
        {
            strUrl = ViewState["strUrl"].ToString();
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["data"] != null)
        {
            strUrl = Request.QueryString["data"].ToString();
            strUrl = Server.UrlDecode(strUrl);
        }
    }
    protected void btnSendEmail_Click(object sender, EventArgs e)
    {
        this.SendEmail();
           
    }
    protected void btnPrev_Click(object sender, EventArgs e)
    {
        multiview.ActiveViewIndex = 0;
    }
    protected void csvReq_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (txtFriendEmailAddress.Text == "" || txtFriendName.Text == "" || txtSenderName.Text == "")
        {
            args.IsValid = false;
        }
        else
        {
            args.IsValid = true;
        }

    }
    protected void Page_PreRender(object sender, EventArgs e)
    {
        ViewState["strUrl"] = strUrl;
    }

}
