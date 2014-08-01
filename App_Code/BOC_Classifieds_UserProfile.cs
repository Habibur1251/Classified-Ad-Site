using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Collections;
using System.Data.SqlClient;

public class BOC_Classifieds_UserProfile : UTLDBHandler
{
    public BOC_Classifieds_UserProfile() : base(UTLUtilities.Database.DbConnectionString)
	{
	}

    /// <summary>
    ///  Bring login information of a classified user.
    /// </summary>
    /// <param name="eocPropertyBean"></param>
    /// <returns></returns>
    public bool IsLoginValid(EOC_PropertyBean eocPropertyBean)
    {
        bool blnFlag = false;

        try
        {
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@LoginEmail", eocPropertyBean.Classifieds_UserProfile_LoginEmail));
            arlSQLParameters.Add(new SqlParameter("@LoginPassword", eocPropertyBean.Classifieds_UserProfile_LoginPassword));

            DataTable objDataTable = this.ExecuteQuery("USP_CL_UsrPro_GetLoginInfo", arlSQLParameters);

            if (objDataTable.Rows.Count > 0)
            {
                eocPropertyBean.Classifieds_UserProfile_ProfileID = Convert.ToInt32(objDataTable.Rows[0]["ProfileID"].ToString());
                eocPropertyBean.Country_CountryID = Convert.ToInt32(objDataTable.Rows[0]["CountryID"].ToString());
                eocPropertyBean.Classifieds_UserProfile_IsActive = Convert.ToBoolean(objDataTable.Rows[0]["IsActive"].ToString());
                eocPropertyBean.IsAdmin = Convert.ToBoolean(objDataTable.Rows[0]["IsAdmin"].ToString());
                eocPropertyBean.Country_CountryName = objDataTable.Rows[0]["Country"].ToString();
                eocPropertyBean.Classifieds_UserProfile_LoginEmail = objDataTable.Rows[0]["LoginEmail"].ToString();
                eocPropertyBean.Classifieds_UserProfile_AdvertiserName= objDataTable.Rows[0]["AdvertiserName"].ToString();

                blnFlag = true;
            }
            else
            {
                blnFlag = false;
            }
        }
        catch
        {
            throw;
        }

        return blnFlag;
    }

    /// <summary>
    /// Load country list from the table Country.
    /// </summary>
    /// <returns>DataTable</returns>
    public DataTable LoadRecord_Country()
    {
        try
        {
            ArrayList arlSQLParameters = new ArrayList();
            return this.ExecuteQuery("USP_CL_EM_UsrPro_LoadCountry", arlSQLParameters);
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Load country wise state list from the table State.
    /// </summary>
    /// <param name="eocPropertyBean">EOC_PropertyBean</param>
    /// <returns>DataTable</returns>
    public DataTable LoadRecord_State(EOC_PropertyBean eocPropertyBean)
    {
        try
        {
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Add(new SqlParameter("@CountryID", eocPropertyBean.Country_CountryID.ToString()));
            return this.ExecuteQuery("USP_CL_EM_UsrPro_LoadState", arlSQLParameters);
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Load state list from the table Country.
    /// </summary>
    /// <returns></returns>
    public DataTable LoadRecord_Province(EOC_PropertyBean eocPropertyBean)
    {
        try
        {
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Add(new SqlParameter("@StateID", eocPropertyBean.State_StateID.ToString()));
            return this.ExecuteQuery("USP_CL_UsrPro_LoadProvince", arlSQLParameters);
        }
        catch
        {
            throw;
        }
    }
    /// <summary>
    /// Select specific user profile from the table Classifieds_UserProfile.
    /// </summary>
    /// <param name="eocPropertyBean"></param>
    /// <returns></returns>
    public bool SelectRecord_UserProfile(EOC_PropertyBean eocPropertyBean)
    {
        bool blnFlag = false;

        try
        {
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@ProfileID", eocPropertyBean.Classifieds_UserProfile_ProfileID.ToString()));
            DataTable objDataTable = this.ExecuteQuery("USP_CL_UsrPro_SelectSpecificRecord", arlSQLParameters);

            if (objDataTable.Rows.Count > 0)
            {
                blnFlag = true;

                eocPropertyBean.Classifieds_UserProfile_LoginEmail = objDataTable.Rows[0]["LoginEmail"].ToString();
                eocPropertyBean.Classifieds_UserProfile_LoginPassword = objDataTable.Rows[0]["LoginPassword"].ToString();
                eocPropertyBean.Classifieds_UserProfile_AdvertiserName = objDataTable.Rows[0]["AdvertiserName"].ToString();
                eocPropertyBean.Classifieds_UserProfile_ContactAddress = objDataTable.Rows[0]["ContactAddress"].ToString();
                eocPropertyBean.Country_CountryID = Convert.ToInt32(objDataTable.Rows[0]["CountryID"].ToString());
                eocPropertyBean.State_StateID = Convert.ToInt32(objDataTable.Rows[0]["StateID"].ToString());
                eocPropertyBean.Province_ProvinceID = Convert.ToInt32(objDataTable.Rows[0]["ProvinceID"].ToString());
                eocPropertyBean.Classifieds_UserProfile_Mobile = objDataTable.Rows[0]["ContactPhone"].ToString();
                eocPropertyBean.Classifieds_UserProfile_IsActive = Convert.ToBoolean(objDataTable.Rows[0]["IsActive"].ToString());
                eocPropertyBean.Classified_ImagePath = objDataTable.Rows[0]["ImagePath"].ToString();
            }
            else
            {
                blnFlag = false;
            }
        }
        catch
        {
            throw;
        }

        return blnFlag;
    }

    /// <summary>
    /// Insert new row in the table Classifieds_UserProfile.
    /// </summary>
    /// <param name="eocPropertyBean"></param>
    /// <returns></returns>
    public int AddRecord_UserProfile(EOC_PropertyBean eocPropertyBean)
    {
        int intActionResult = 0;

        try
        {
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@LoginEmail", eocPropertyBean.Classifieds_UserProfile_LoginEmail));

            if (this.ExecuteQuery("USP_Common_UsrPro_BeforeInsert_IsLoginEmailDuplicate", arlSQLParameters).Rows.Count == 0)
            {
                arlSQLParameters.Clear();
                arlSQLParameters.Add(new SqlParameter("@LoginEmail", eocPropertyBean.Classifieds_UserProfile_LoginEmail));
                arlSQLParameters.Add(new SqlParameter("@LoginPassword", eocPropertyBean.Classifieds_UserProfile_LoginPassword));
                arlSQLParameters.Add(new SqlParameter("@AdvertiserName", eocPropertyBean.Classifieds_UserProfile_AdvertiserName));
                arlSQLParameters.Add(new SqlParameter("@ContactAddress", eocPropertyBean.Classifieds_UserProfile_ContactAddress));
                //arlSQLParameters.Add(new SqlParameter("@CountryID", eocPropertyBean.Country_CountryID.ToString()));
                arlSQLParameters.Add(new SqlParameter("@ProvinceID", eocPropertyBean.Province_ProvinceID.ToString()));
                arlSQLParameters.Add(new SqlParameter("@Mobile", eocPropertyBean.Classifieds_UserProfile_Mobile));
                arlSQLParameters.Add(new SqlParameter("@UpdatedOn", eocPropertyBean.UpdatedOn.ToString()));
                arlSQLParameters.Add(new SqlParameter("@Source", eocPropertyBean.Source.ToString()));
                arlSQLParameters.Add(new SqlParameter("@ReferalName", eocPropertyBean.ReferalName.ToString()));
                arlSQLParameters.Add(new SqlParameter("@ImagePath", eocPropertyBean.ImagePath.ToString()));

                intActionResult = this.ExecuteActionQuery("USP_CL_UsrPro_InsertRecord", arlSQLParameters);
            }
            else
            {
                intActionResult = -1;
            }
        }
        catch
        {
            throw;
        }

        return intActionResult;
    }
    /// <summary>
    /// Update specific row in the table Classifieds_UserProfile.
    /// </summary>
    /// <param name="eocPropertyBean"></param>
    /// <returns></returns>
    public int UpdateRecord_UserProfile(EOC_PropertyBean eocPropertyBean)
    {
        int intActionResult = 0;

        try
        {
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@ProfileID", eocPropertyBean.Classifieds_UserProfile_ProfileID.ToString()));
            arlSQLParameters.Add(new SqlParameter("@LoginEmail", eocPropertyBean.Classifieds_UserProfile_LoginEmail));

            if (this.ExecuteQuery("USP_CL_UsrPro_BeforeUpdate_IsLoginEmailDuplicate", arlSQLParameters).Rows.Count == 0)
            {
                arlSQLParameters.Clear();
                arlSQLParameters.Add(new SqlParameter("@ProfileID", eocPropertyBean.Classifieds_UserProfile_ProfileID.ToString()));
                arlSQLParameters.Add(new SqlParameter("@LoginEmail", eocPropertyBean.Classifieds_UserProfile_LoginEmail));
                arlSQLParameters.Add(new SqlParameter("@AdvertiserName", eocPropertyBean.Classifieds_UserProfile_AdvertiserName));
                arlSQLParameters.Add(new SqlParameter("@ContactAddress", eocPropertyBean.Classifieds_UserProfile_ContactAddress));
                //arlSQLParameters.Add(new SqlParameter("@ProvinceID", eocPropertyBean.Province_ProvinceID.ToString()));
                arlSQLParameters.Add(new SqlParameter("@ContactPhone", eocPropertyBean.Classifieds_UserProfile_Mobile));
                //arlSQLParameters.Add(new SqlParameter("@UpdatedOn", eocPropertyBean.UpdatedOn.ToString()));
                arlSQLParameters.Add(new SqlParameter("@ImagePath", eocPropertyBean.ClassifiedImagePathEdit.ToString()));

                intActionResult = this.ExecuteActionQuery("USP_CL_UsrPro_UpdateRecord", arlSQLParameters);
            }
            else
            {
                intActionResult = -1;
            }
        }
        catch
        {
            throw;
        }

        return intActionResult;
    }
    /// <summary>
    /// Update password field of  a selected row of the table Classifieds_UserProfile.
    /// </summary>
    /// <param name="eocPropertyBean"></param>
    /// <returns></returns>
    public int UpdateRecord_ChangePassword(EOC_PropertyBean eocPropertyBean)
    {
        int intActionResult = 0;

        try
        {
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Add(new SqlParameter("@ProfileID", eocPropertyBean.Classifieds_UserProfile_ProfileID.ToString()));
            arlSQLParameters.Add(new SqlParameter("@LoginPassword", eocPropertyBean.Classifieds_UserProfile_OldPassword));

            if (this.ExecuteQuery("USP_CL_UsrPro_IsOldPasswordValid", arlSQLParameters).Rows.Count > 0)
            {
                arlSQLParameters.Clear();
                arlSQLParameters.Add(new SqlParameter("@ProfileID", eocPropertyBean.Classifieds_UserProfile_ProfileID.ToString()));
                arlSQLParameters.Add(new SqlParameter("@LoginPassword", eocPropertyBean.Classifieds_UserProfile_LoginPassword));
                arlSQLParameters.Add(new SqlParameter("@UpdatedOn", eocPropertyBean.UpdatedOn.ToString()));

                intActionResult = this.ExecuteActionQuery("USP_CL_UsrPro_UpdatePassword", arlSQLParameters);
            }
            else
            {
                intActionResult = -1;
            }
        }
        catch
        {
            throw;
        }

        return intActionResult;
    }
    /// <summary>
    /// Insert new row in the table Classifieds_ActivationLinks
    /// </summary>
    /// <param name="eocPropertyBean">EOC_PropertyBean</param>
    /// <returns>Integer</returns>
    public int AddRecord_ActivationLinks(EOC_PropertyBean eocPropertyBean)
    {        
        int intActionResult = 0;
        int intProfileID = 0;
        
        try
        {
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Add(new SqlParameter("@LoginEmail", eocPropertyBean.Classifieds_UserProfile_LoginEmail));

            DataTable dtUserProfile = this.ExecuteQuery("USP_CL_ActLink_ReadProfileID", arlSQLParameters);

            if (dtUserProfile.Rows.Count == 0)
            {
                intActionResult = -1;
            }
            else
            {
                intProfileID = Convert.ToInt32(dtUserProfile.Rows[0]["ProfileID"].ToString());

                arlSQLParameters.Clear();
                arlSQLParameters.Add(new SqlParameter("@ProfileID", intProfileID.ToString()));
                arlSQLParameters.Add(new SqlParameter("@UpdatedOn", DateTime.Now.ToString()));

                intActionResult = this.ExecuteActionQuery("USP_CL_ActLink_InsertRecord", arlSQLParameters);
            }
        }
        catch
        {
            throw;
        }

        return intActionResult;
    }
    /// <summary>
    /// Select specific row from the table Classifieds_ActivationLinks
    /// </summary>
    /// <param name="eocPropertyBean">EOC_PropertyBean</param>
    /// <returns>DataTable</returns>
    public DataTable SelectRecord_ActivationLinks(EOC_PropertyBean eocPropertyBean)
    {
        DataTable dtActivationLink = null;

        try
        {
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Add(new SqlParameter("@LoginEmail", eocPropertyBean.Classifieds_UserProfile_LoginEmail));

            dtActivationLink = this.ExecuteQuery("USP_CL_ActLink_01_SelectActLink", arlSQLParameters);            
        }
        catch
        {
            throw;
        }

        return dtActivationLink;
    }
    public int UpdateRecord_ActivationLinks(EOC_PropertyBean eocPropertyBean)
    {
        int intActionResult = 0;

        try
        {
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@LinkID", eocPropertyBean.Classifieds_ActivationLinks_LinkID.ToString()));
            arlSQLParameters.Add(new SqlParameter("@ProfileID", eocPropertyBean.Classifieds_UserProfile_ProfileID.ToString()));

            DataTable dtActivationLink = this.ExecuteQuery("USP_CL_ActLink_02_SelectActLink", arlSQLParameters);

            if (dtActivationLink.Rows.Count == 0)
            {
                intActionResult = -1;
            }
            else
            {
                arlSQLParameters.Clear();
                arlSQLParameters.Add(new SqlParameter("@LinkID", eocPropertyBean.Classifieds_ActivationLinks_LinkID.ToString()));
                arlSQLParameters.Add(new SqlParameter("@ProfileID", eocPropertyBean.Classifieds_UserProfile_ProfileID.ToString()));
                arlSQLParameters.Add(new SqlParameter("@IsChecked", eocPropertyBean.Classifieds_ActivationLinks_IsChecked.ToString()));

                intActionResult = this.ExecuteActionQuery("USP_CL_ActLink_UpdateRecord", arlSQLParameters);
            }
        }
        catch
        {
            throw;
        }

        return intActionResult;
    }
}
