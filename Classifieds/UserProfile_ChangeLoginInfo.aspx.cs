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

public partial class Classifieds_UserProfile_ChangeLoginInfo : System.Web.UI.Page
{
    private int intProfileID = -1;
    private int intCountryID = -1;
    private string strSystemMessage = string.Empty;

    private void CheckUserSession()
    {
        if (this.Session["CLSF_PROFILE_CODE"] != null && this.Session["CLSF_COUNTRY_CODE"] != null)
        {
            intProfileID = Convert.ToInt32(this.Session["CLSF_PROFILE_CODE"].ToString());
            intCountryID = Convert.ToInt32(this.Session["CLSF_COUNTRY_CODE"].ToString());
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
    }
    private int UpdateRecord_ChangePassword()
    {
        int intActionResult = 0;

        try
        {
            using (BOC_Classifieds_UserProfile bocUserProfile = new BOC_Classifieds_UserProfile())
            {
                EOC_PropertyBean eocPropertyBean = new EOC_PropertyBean();

                eocPropertyBean.Classifieds_UserProfile_ProfileID = intProfileID;
                eocPropertyBean.Classifieds_UserProfile_OldPassword = txtOldPassword.Text;
                eocPropertyBean.Classifieds_UserProfile_LoginPassword = txtNewPassword1.Text;
                eocPropertyBean.UpdatedOn = DateTime.Now;

                intActionResult = bocUserProfile.UpdateRecord_ChangePassword(eocPropertyBean);
            }
        }
        catch (Exception Exp)
        {
            lblSystemMessage.Text = Exp.Message.ToString();
        }

        return intActionResult;
    }   
    protected void Page_Load(object sender, EventArgs e)
    {
        this.CheckUserSession();

        UTLUtilities.CL_ActiveModule = 4;
    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int intActionResult = 0;
        string strSystemMessage = string.Empty;

        intActionResult = this.UpdateRecord_ChangePassword();

        if (intActionResult > 0)

        {
            messageLabel.Text = "Your Password Successfully Changed";
            //Response.Redirect("ControlPanel.aspx");
        }
        if (intActionResult == -1)
        {
            strSystemMessage = "<table style='width:500px; border:1px dashed #666666;'>";
            strSystemMessage += "<tr>";
            strSystemMessage += "<td align='center' style='width:10%;'><img src='../images/icon_error.gif' width='42' height='40' alt='' /></td>";
            strSystemMessage += "<td valign='middle' style='width:90%;font-weight:bold; text-decoration:underline'>Following error occured :</td>";
            strSystemMessage += "</tr>";

            strSystemMessage += "<tr>";
            strSystemMessage += "<td colspan='2' style='width:100%; color:#000000; padding-top:7px; padding-left:10px;'>";
            strSystemMessage += "Your old password does not match !";
            strSystemMessage += "<br/><br/>";
            strSystemMessage += "<strong>How did this happen? </strong>";
            strSystemMessage += "<ul>";
            strSystemMessage += "<li>You may forget your old login password.</li>";
            strSystemMessage += "<li>You probable mistakenly type your old password.</li>";
            strSystemMessage += "</ul>";
            strSystemMessage += "</td>";
            strSystemMessage += "</tr>";
            strSystemMessage += "</table>";

            lblSystemMessage.Text = strSystemMessage;
        }
    }
}
