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

public partial class Error : System.Web.UI.Page
{
    string strErrorMessage = string.Empty;
    string strEncryptedUrl = string.Empty;
    string strDecryptedUrl = string.Empty;
    string strHtml = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["data"] != null)
            {
                strEncryptedUrl = Request.QueryString["data"].ToString();
                strDecryptedUrl = UTLUtilities.Decrypt(strEncryptedUrl);
                string[] strSplitUrl = strDecryptedUrl.Split('&', '=');

                strErrorMessage = strSplitUrl[0];

                strHtml += "<div align=\"center\" style=\"margin-top:80px;margin-bottom:10px\">";
                strHtml += "<img src='../images/icon_error.gif' width='42' height='40' alt='' />";
                strHtml += "</div>";
                strHtml += "<table style=\"width:600px;background-color:#EFEFE2;color:#990000;margin-bottom:80px;text-align:center;font-size:16px;font-weight:bold\"  align=\"center\">";
                strHtml += "<tr>";
                strHtml += "<td>";
                strHtml += strErrorMessage;
                strHtml += "</td>";
                strHtml += "</tr>";
                strHtml += "</table>";
                lblDisplayError.Text = strHtml;

            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }
        catch (Exception ex)
        {
            Response.Redirect("Default.aspx");
        }

    }

  
}

