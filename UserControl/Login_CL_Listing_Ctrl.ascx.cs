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

public partial class UserControl_Login_CL_Listing_Ctrl : System.Web.UI.UserControl
{
    /// <summary>
    /// Full Path Upto /ControlPanel.aspx
    /// </summary>
    private string _Corporate_CP_VirtualPath;

    public string Corporate_CP_VirtualPath
    {
        get { return _Corporate_CP_VirtualPath; }
        set { _Corporate_CP_VirtualPath = value; }
    }

    private string _Classified_CP_VirtualPath;

    public string Classified_CP_VirtualPath
    {
        get { return _Classified_CP_VirtualPath; }
        set { _Classified_CP_VirtualPath = value; }
    }

    private string _ForgotPassWordLink;

    public string ForgotPassWordLink
    {
        get { return _ForgotPassWordLink; }
        set { _ForgotPassWordLink = value; }
    }


    private void IsUserValid()
    {
        try
        {
            using (BC_CommonUser user = new BC_CommonUser())
            {
                DataTable dt = user.IsLoginValid(txtLoginEmail.Text, txtPassword.Text);
                if (!(dt.Rows.Count > 0))
                {
                    lblSystemMessage.Text = "Access denied! Invalid Login Email or Password.";
                }

                else
                {
                    bool isActive = Convert.ToBoolean(dt.Rows[0]["IsActive"]);
                    if (!isActive)
                    {
                        lblSystemMessage.Text = "Your classified account is not active.";
                    }
                    else
                    {
                        bool userType = Convert.ToBoolean(dt.Rows[0]["UserType"]);
                        if (userType)
                        {

                            this.Session["CLSF_PROFILE_CODE"] = dt.Rows[0]["ProfileID"];
                            this.Session["CLSF_COUNTRY_CODE"] = dt.Rows[0]["CountryID"];

                            this.Session["IS_ADMIN"] = dt.Rows[0]["IsAdmin"];
                            this.Session["COUNTRY"] = dt.Rows[0]["Country"];
                            this.Session["LOGINEMAIL"] = dt.Rows[0]["LoginEmail"];
                            this.Session["ADVERTISERNAME"] = dt.Rows[0]["UserOrCompanyName"];

                            Response.Redirect(Classified_CP_VirtualPath + @"/ControlPanel.aspx", false);

                            // Modified by Moinur 13 Sep 2012 to forcely login to classify control panel

                            //this.Session["CORP_PROFILE_CODE"] = dt.Rows[0]["ProfileID"];
                            //this.Session["CORP_COUNTRY_CODE"] = dt.Rows[0]["CountryID"];

                            //this.Session["IS_ADMIN"] = dt.Rows[0]["IsAdmin"];
                            //this.Session["COUNTRY"] = dt.Rows[0]["Country"];

                            //this.Session["LOGINEMAIL"] = dt.Rows[0]["LoginEmail"];
                            //this.Session["COMPANYNAME"] = dt.Rows[0]["UserOrCompanyName"];

                            //Response.Redirect(Corporate_CP_VirtualPath + @"/ControlPanel.aspx", false);
                        }
                        else
                        {
                            this.Session["CLSF_PROFILE_CODE"] = dt.Rows[0]["ProfileID"];
                            this.Session["CLSF_COUNTRY_CODE"] = dt.Rows[0]["CountryID"];

                            this.Session["IS_ADMIN"] = dt.Rows[0]["IsAdmin"];
                            this.Session["COUNTRY"] = dt.Rows[0]["Country"];
                            this.Session["LOGINEMAIL"] = dt.Rows[0]["LoginEmail"];
                            this.Session["ADVERTISERNAME"] = dt.Rows[0]["UserOrCompanyName"];

                            Response.Redirect(Classified_CP_VirtualPath + @"/ControlPanel.aspx", false);
                        }

                    }
                }
            }
        }
        catch (Exception Exp)
        {
            lblSystemMessage.Text = Exp.Message.ToString();
        }
    }



    protected void btnLogin_Click(object sender, EventArgs e)
    {
        this.IsUserValid();
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}
