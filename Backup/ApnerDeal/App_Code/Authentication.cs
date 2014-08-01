using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for Authentication
/// </summary>
public class Authentication
{
	public Authentication()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public string IsUserValid(EOC_PropertyBean eocPropertyBean)
    {
        
        try
        {
            using (BC_CommonUser user = new BC_CommonUser())
            {
                DataTable dt = user.IsLoginValid(eocPropertyBean.LoginEmail, eocPropertyBean.Password);
                if (!(dt.Rows.Count > 0))
                {
                    return "Access denied! Invalid Login Email or Password.";
                    
                }

                else
                {
                    bool isActive = Convert.ToBoolean(dt.Rows[0]["IsActive"]);
                    if (!isActive)
                    {
                        return "Your classified account is not active.Please check your login mail address and active your account";
                    }
                    else
                    {
                        bool userType = Convert.ToBoolean(dt.Rows[0]["UserType"]);
                        if (userType)
                        {
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
                            //this.Session["CLSF_PROFILE_CODE"] = dt.Rows[0]["ProfileID"];
                            //this.Session["CLSF_COUNTRY_CODE"] = dt.Rows[0]["CountryID"];

                            //this.Session["IS_ADMIN"] = dt.Rows[0]["IsAdmin"];
                            //this.Session["COUNTRY"] = dt.Rows[0]["Country"];
                            //this.Session["LOGINEMAIL"] = dt.Rows[0]["LoginEmail"];
                            //this.Session["ADVERTISERNAME"] = dt.Rows[0]["UserOrCompanyName"];

                            //Response.Redirect(Classified_CP_VirtualPath + @"/ControlPanel.aspx", false);
                        }
                        return "Success";

                    }
                }
            }
        }
        catch (Exception Exp)
        {
            throw;
        }
    }



    public EOC_PropertyBean GetUserLoginCredential(EOC_PropertyBean eocPropertyBean)
    {

        try
        {
            using (BC_CommonUser user = new BC_CommonUser())
            {
                DataTable dt = user.IsLoginValid(eocPropertyBean.LoginEmail, eocPropertyBean.Password);
                if (!(dt.Rows.Count > 0))
                {
                    eocPropertyBean.Message = "Access denied! Invalid Login Email or Password.";

                }

                else
                {
                    bool isActive = Convert.ToBoolean(dt.Rows[0]["IsActive"]);
                    if (!isActive)
                    {
                        eocPropertyBean.Message = "Your classified account is not active.";
                    }
                    else
                    {
                        bool userType = Convert.ToBoolean(dt.Rows[0]["UserType"]);
                        eocPropertyBean.UserType = userType.ToString();
                        eocPropertyBean.Message = "Success";
                        if (userType)
                        {
                            eocPropertyBean.User_ProfileID = Convert.ToInt32(dt.Rows[0]["ProfileID"]);
                            eocPropertyBean.Country_CountryID = Convert.ToInt32(dt.Rows[0]["CountryID"]);

                            eocPropertyBean.IsAdmin = Convert.ToBoolean(dt.Rows[0]["IsAdmin"]);
                            eocPropertyBean.Country_CountryName = dt.Rows[0]["Country"].ToString();

                            eocPropertyBean.User_LoginEmail = dt.Rows[0]["LoginEmail"].ToString();
                            eocPropertyBean.UserInfo = dt.Rows[0]["UserOrCompanyName"].ToString();

                            
                        }
                        else
                        {
                            eocPropertyBean.User_ProfileID = Convert.ToInt32(dt.Rows[0]["ProfileID"]);
                            eocPropertyBean.Country_CountryID = Convert.ToInt32(dt.Rows[0]["CountryID"]);

                            eocPropertyBean.IsAdmin = Convert.ToBoolean(dt.Rows[0]["IsAdmin"]);
                            eocPropertyBean.Country_CountryName = dt.Rows[0]["Country"].ToString();

                            eocPropertyBean.User_LoginEmail = dt.Rows[0]["LoginEmail"].ToString();
                            eocPropertyBean.UserInfo = dt.Rows[0]["UserOrCompanyName"].ToString();
                            
                        }
                        

                    }
                }
                return eocPropertyBean;
            }
        }
        catch (Exception Exp)
        {
            throw;
        }
    }


    /// <summary>
    /// Implemented for future
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public string IsUserAuthenticated(User usr)
    {
        HttpContext context = HttpContext.Current;
        string _Message = "";
        try
        {
            using (BC_CommonUser user = new BC_CommonUser())
            {
                DataTable dt = user.IsLoginValid(usr.LoginEmail, usr.Password);
                if (!(dt.Rows.Count > 0))
                {
                    _Message = "Access denied! Invalid Login Email or Password.";

                }

                else
                {
                    bool isActive = Convert.ToBoolean(dt.Rows[0]["IsActive"]);
                    if (!isActive)
                    {
                        _Message = "Your classified account is not active.";
                    }
                    else
                    {
                        
                        context.Session["PROFILE_CODE"] = Convert.ToInt32(dt.Rows[0]["ProfileID"]);
                        context.Session["COUNTRY_CODE"] = Convert.ToInt32(dt.Rows[0]["CountryID"]);
                        context.Session["COUNTRY"] = dt.Rows[0]["Country"].ToString();
                        context.Session["LOGINEMAIL"] = dt.Rows[0]["LoginEmail"].ToString();
                        context.Session["USER_INFO"] = dt.Rows[0]["UserOrCompanyName"].ToString();
                        context.Session["IS_ADMIN"] = Convert.ToBoolean(dt.Rows[0]["IsAdmin"]);
                        _Message = "Success";
                    }
                }
                return _Message;
            }
        }
        catch (Exception Exp)
        {
            throw;
        }
    }


   
}
