using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;

/// <summary>
/// Summary description for BC_EmailFormat_Handler
/// </summary>
public class BC_EmailFormat_Handler
{
	public BC_EmailFormat_Handler()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public string Send_Email_ToA_Friend(string strServiceName, string strRecieverName,  string strSender,string strItemLink)
    {
        string strHtml = string.Empty;
        strHtml = "<table width=\"800px\" border=1px solid #C3C1C1 align=\"center\" style=\"text-align:left\" cellpadding=\"5px\" cellspacing=\"0px\">";
        strHtml += "<tr><td>";
        //strHtml += "<a color=\"white\" href=\"http://www.apnerdeal.com\">";
        strHtml += "<img src=\"http://www.apnerdeal.com/images/logo.gif\" width=\"260px\" height=\"91\" alt=\"\" />";
        //strHtml += "</a>";
        strHtml += "</td></tr><tr><td style=\"background-color:#3B5998;border:none;font-weight:bold; color: white\">";
        strHtml += strServiceName + "</td></tr><tr><td>";

        strHtml += "<div style=\"color:#000000; text-align:left; line-height:18px\">Dear <strong>Mr./Ms. " + strRecieverName + "</strong>,<br/>";
        strHtml += "<br/><br/>";
        strHtml += "One of your friend <strong style=\"font-family:Verdana;font-size:12px\">Mr./Ms. ";
        strHtml += strSender + "</strong> wants you to view a deal/discount from ";
        strHtml += "<a style=\"font-weight:bold\" href=\"http://www.apnerdeal.com\">apnerdeal.com.</a>";
        strHtml += "</br></br> Please click on the link below to view a deal/discount.";
        strHtml += "</br><a href=\""+ strItemLink +"\" target=\"blank\">" + strItemLink + "</a>";
        
        strHtml += "<br/><br/> Regards,<br/>";
        strHtml += "<br/><br/>";

        strHtml += "<strong style=\"font-size:13px;color:#004B91\">ApnerDeal.com Team</strong>";

        strHtml += "<div style=\"text-align:left;font-weight:bold;\">";
        strHtml += "For more information please contact: </br>";
        strHtml += "<a href=\"mailto:info@apnerdeal.com\">info@apnerdeal.com</a>";

        strHtml += "<div style=\"text-align:left;font-weight:bold;\">";
        strHtml += "<span style=\"color:#FF9900\">";
        strHtml += "ApnerDeal.com";
        strHtml += "</span>";
        strHtml += " is not responsible for any ";
        strHtml += " message other than any particular product information.";
        strHtml += "</div>";
        strHtml += "<span style=\"color:red\">";
        strHtml +=  "This is an Automatically Generated Message. Please do not reply.";
        strHtml += "</span>";

        return strHtml;
        //MailMaster.SendMail(strReciever, strSender, "ApnerDeal.com SELLING PRODUCT INFORMATION", strHtml);
    }
}
