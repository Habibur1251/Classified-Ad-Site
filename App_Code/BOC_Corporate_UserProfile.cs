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

public class BOC_Corporate_UserProfile : UTLDBHandler
{
    public BOC_Corporate_UserProfile() : base(UTLUtilities.Database.DbConnectionString)
	{
	}

    /// <summary>
    ///  Check Business User login authentication.
    /// </summary>
    /// <param name="eocPropertyBean">EOC_PropertyBean</param>
    /// <returns>Boolean</returns>
    public bool IsLoginValid(EOC_PropertyBean eocPropertyBean)
    {
        bool blnFlag = false;
        
        try
        {
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@LoginEmail", eocPropertyBean.Business_UserProfile_LoginEmail));
            arlSQLParameters.Add(new SqlParameter("@LoginPassword", eocPropertyBean.Business_UserProfile_LoginPassword));

            DataTable objDataTable = this.ExecuteQuery("USP_CP_UsrPro_GetLoginInfo", arlSQLParameters);

            if (objDataTable.Rows.Count > 0)
            {
                eocPropertyBean.Business_UserProfile_ProfileID = Convert.ToInt32(objDataTable.Rows[0]["ProfileID"].ToString());
                //eocPropertyBean.Country_CountryID = Convert.ToInt32(objDataTable.Rows[0]["Country"].ToString());
                eocPropertyBean.Business_UserProfile_IsActive = Convert.ToBoolean(objDataTable.Rows[0]["IsActive"].ToString());
                //eocPropertyBean.Country_CountryName = objDataTable.Rows[0]["Country"].ToString();
                eocPropertyBean.Business_UserProfile_CompanyName = objDataTable.Rows[0]["CompanyName"].ToString();
                eocPropertyBean.Business_UserProfile_LoginEmail = objDataTable.Rows[0]["LoginEmail"].ToString();
                eocPropertyBean.IsAdmin = Convert.ToBoolean(objDataTable.Rows[0]["IsAdmin"]);

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
    /// Load state wise province list from the table Province.
    /// </summary>
    /// <param name="eocPropertyBean">EOC_PropertyBean</param>
    /// <returns>DataTable</returns>
    public DataTable LoadRecord_Province(EOC_PropertyBean eocPropertyBean)
    {
        try
        {
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Add(new SqlParameter("@StateID", eocPropertyBean.State_StateID.ToString()));
            return this.ExecuteQuery("USP_CP_UsrPro_LoadProvince", arlSQLParameters);
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Load business category list from the table BusinessCategory.
    /// </summary>
    /// <returns>DataTable</returns>
    public DataTable LoadRecord_BusinessCategoey()
    {
        try
        {
            ArrayList arlSQLParameters = new ArrayList();
            return this.ExecuteQuery("USP_CP_UsrPro_LoadBusinessCategory", arlSQLParameters);
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Select specific user profile from the table Business_UserProfile.
    /// </summary>
    /// <param name="eocPropertyBean">EOC_PropertyBean</param>
    /// <returns>Boolean</returns>
    public bool SelectRecord_UserProfile(EOC_PropertyBean eocPropertyBean)
    {
        bool blnFlag = false;

        try
        {
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@ProfileID", eocPropertyBean.Business_UserProfile_ProfileID.ToString()));
            DataTable objDataTable = this.ExecuteQuery("USP_CP_UsrPro_SelectSpecificRecord", arlSQLParameters);

            if (objDataTable.Rows.Count > 0)
            {
                blnFlag = true;
                eocPropertyBean.BusinessCategory_BusinessID = Convert.ToInt32(objDataTable.Rows[0]["BusinessID"].ToString());
                eocPropertyBean.Business_UserProfile_LoginEmail = objDataTable.Rows[0]["LoginEmail"].ToString();
                eocPropertyBean.Business_UserProfile_LoginPassword = objDataTable.Rows[0]["LoginPassword"].ToString();
                eocPropertyBean.Business_UserProfile_CompanyName = objDataTable.Rows[0]["CompanyName"].ToString();
                eocPropertyBean.Business_UserProfile_BusinessAddress = objDataTable.Rows[0]["BusinessAddress"].ToString();
                eocPropertyBean.Country_CountryID = Convert.ToInt32(objDataTable.Rows[0]["CountryID"].ToString());
                eocPropertyBean.State_StateID = Convert.ToInt32(objDataTable.Rows[0]["StateID"].ToString());
                eocPropertyBean.Province_ProvinceID = Convert.ToInt32(objDataTable.Rows[0]["ProvinceID"].ToString());
                eocPropertyBean.Business_UserProfile_ContactPhone = objDataTable.Rows[0]["ContactPhone"].ToString();
                eocPropertyBean.Business_UserProfile_CompanyURL = objDataTable.Rows[0]["CompanyURL"].ToString();
                eocPropertyBean.Business_UserProfile_BillingPerson = objDataTable.Rows[0]["BillingPerson"].ToString();
                eocPropertyBean.Business_UserProfile_WebInventoryManager = objDataTable.Rows[0]["WebInventoryManager"].ToString();
                eocPropertyBean.Business_UserProfile_CompanyProfile = objDataTable.Rows[0]["CompanyProfile"].ToString();
                eocPropertyBean.CorporateImagePath = objDataTable.Rows[0]["ImagePath"].ToString();
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
    /// Insert new record in the table Business_UserProfile.
    /// </summary>
    /// <param name="eocPropertyBean">EOC_PropertyBean</param>
    /// <returns>Integer</returns>
    public int AddRecord_UserProfile(EOC_PropertyBean eocPropertyBean)
    {
        int intActionResult = 0;

        try
        {
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@LoginEmail", eocPropertyBean.Business_UserProfile_LoginEmail));

            //Case 01: Looking for duplicate login email before inserting record.
            if (this.ExecuteQuery("USP_Common_UsrPro_BeforeInsert_IsLoginEmailDuplicate", arlSQLParameters).Rows.Count == 0)
            {
                arlSQLParameters.Clear();
                
                arlSQLParameters.Add(new SqlParameter("@CompanyName", eocPropertyBean.Business_UserProfile_CompanyName));

                //Case 02: Looking for duplicate company name before inserting record.
                if (this.ExecuteQuery("USP_CP_UsrPro_BeforeInsert_IsCompanyNameDuplicate", arlSQLParameters).Rows.Count == 0)
                {
                    arlSQLParameters.Clear();
                    arlSQLParameters.Add(new SqlParameter("@BusinessID", eocPropertyBean.BusinessCategory_BusinessID.ToString()));
                    arlSQLParameters.Add(new SqlParameter("@LoginEmail", eocPropertyBean.Business_UserProfile_LoginEmail));
                    arlSQLParameters.Add(new SqlParameter("@LoginPassword", eocPropertyBean.Business_UserProfile_LoginPassword));
                    arlSQLParameters.Add(new SqlParameter("@CompanyName", eocPropertyBean.Business_UserProfile_CompanyName));
                    arlSQLParameters.Add(new SqlParameter("@BusinessAddress", eocPropertyBean.Business_UserProfile_BusinessAddress));
                    
                    arlSQLParameters.Add(new SqlParameter("@ContactPhone", eocPropertyBean.Business_UserProfile_ContactPhone));
                    arlSQLParameters.Add(new SqlParameter("@CompanyURL", eocPropertyBean.Business_UserProfile_CompanyURL));
                    arlSQLParameters.Add(new SqlParameter("@BillingPerson", eocPropertyBean.Business_UserProfile_BillingPerson));
                    arlSQLParameters.Add(new SqlParameter("@WebInventoryManager", eocPropertyBean.Business_UserProfile_WebInventoryManager));
                    arlSQLParameters.Add(new SqlParameter("@CompanyProfile", eocPropertyBean.Business_UserProfile_CompanyProfile));
                    arlSQLParameters.Add(new SqlParameter("@CompanyLogo", eocPropertyBean.Business_UserProfile_CompanyLogo));
                    
                    arlSQLParameters.Add(new SqlParameter("@ImagePath", eocPropertyBean.CorporateImagePathE.ToString()));

                    intActionResult = this.ExecuteActionQuery("USP_CP_UsrPro_InsertRecord", arlSQLParameters);
                }
                else
                {
                    intActionResult = -2;
                }
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
    /// Insert new record in the table Business_UserProfileForDiscount.
    /// </summary>
    /// <param name="eocPropertyBean">EOC_PropertyBean</param>
    /// <returns>Integer</returns>
    public int AddRecord_UserProfileDiscountAdmin(EOC_PropertyBean eocPropertyBean)
    {
        int intActionResult = 0;
        try
        {
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@LoginEmail", eocPropertyBean.Business_UserProfile_LoginEmail));

            //Case 01: Looking for duplicate login email before inserting record.
            if (this.ExecuteQuery("USP_Common_UsrPro_BeforeInsert_IsLoginEmailDuplicate", arlSQLParameters).Rows.Count == 0)
            {
            arlSQLParameters.Clear();
             arlSQLParameters.Add(new SqlParameter("@CompanyName", eocPropertyBean.Business_UserProfile_CompanyName));

            //Case 02: Looking for duplicate company name before inserting record.
            if (this.ExecuteQuery("USP_CP_UsrPro_BeforeInsert_IsCompanyNameDuplicate", arlSQLParameters).Rows.Count == 0)
            {
                arlSQLParameters.Clear();
                arlSQLParameters.Add(new SqlParameter("@ProvinceID", eocPropertyBean.Province_ProvinceID));
                arlSQLParameters.Add(new SqlParameter("@BusinessID", eocPropertyBean.BusinessCategory_BusinessID));
                arlSQLParameters.Add(new SqlParameter("@LoginEmail", eocPropertyBean.Business_UserProfile_LoginEmail));
                arlSQLParameters.Add(new SqlParameter("@CompanyName", eocPropertyBean.Business_UserProfile_CompanyName));
                arlSQLParameters.Add(new SqlParameter("@ContactPhone", eocPropertyBean.Business_UserProfile_ContactPhone));
                arlSQLParameters.Add(new SqlParameter("@BusinessAddress", eocPropertyBean.Business_UserProfile_BusinessAddress));
                arlSQLParameters.Add(new SqlParameter("@CompanyURL", eocPropertyBean.Business_UserProfile_CompanyURL));
                arlSQLParameters.Add(new SqlParameter("@UpdatedOn", eocPropertyBean.UpdatedOn));
                arlSQLParameters.Add(new SqlParameter("@ImagePath", eocPropertyBean.CorporateImagePathE));
                arlSQLParameters.Add(new SqlParameter("@DiscountAdminReferance", eocPropertyBean.ReferanceID));

                intActionResult = this.ExecuteActionQuery("USP_CP_UsrPro_InsertRecordDiscountAdmin", arlSQLParameters);
            }
            else
            {
                intActionResult = -2;
            }
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
    /// Update specific row in the table Business_UserProfile.
    /// </summary>
    /// <param name="eocPropertyBean">EOC_PropertyBean</param>
    /// <returns>Integer</returns>
    public int UpdateRecord_UserProfile(EOC_PropertyBean eocPropertyBean)
    {
        int intActionResult = 0;

        try
        {
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@ProfileID", eocPropertyBean.Business_UserProfile_ProfileID.ToString()));
            arlSQLParameters.Add(new SqlParameter("@LoginEmail", eocPropertyBean.Business_UserProfile_LoginEmail));

            //Case 01: Looking for duplicate login email before updating record.
            if (this.ExecuteQuery("USP_CP_UsrPro_BeforeUpdate_IsLoginEmailDuplicate", arlSQLParameters).Rows.Count == 0)
            {
                arlSQLParameters.Clear();
                arlSQLParameters.Add(new SqlParameter("@ProfileID", eocPropertyBean.Business_UserProfile_ProfileID.ToString()));
                arlSQLParameters.Add(new SqlParameter("@CompanyName", eocPropertyBean.Business_UserProfile_CompanyName));
                //arlSQLParameters.Add(new SqlParameter("@CountryID", eocPropertyBean.Country_CountryID.ToString()));

                //Case 02: Looking for duplicate company name before updating record.
                if (this.ExecuteQuery("USP_CP_UsrPro_BeforeUpdate_IsCompanyNameDuplicate", arlSQLParameters).Rows.Count == 0)
                {                    
                    arlSQLParameters.Clear();
                    arlSQLParameters.Add(new SqlParameter("@ProfileID", eocPropertyBean.Business_UserProfile_ProfileID.ToString()));
                    arlSQLParameters.Add(new SqlParameter("@BusinessID", eocPropertyBean.BusinessCategory_BusinessID.ToString()));
                    arlSQLParameters.Add(new SqlParameter("@LoginEmail", eocPropertyBean.Business_UserProfile_LoginEmail));
                    arlSQLParameters.Add(new SqlParameter("@CompanyName", eocPropertyBean.Business_UserProfile_CompanyName));
                    arlSQLParameters.Add(new SqlParameter("@BusinessAddress", eocPropertyBean.Business_UserProfile_BusinessAddress));
                    arlSQLParameters.Add(new SqlParameter("@ProvinceID", eocPropertyBean.Province_ProvinceID.ToString()));
                    arlSQLParameters.Add(new SqlParameter("@ContactPhone", eocPropertyBean.Business_UserProfile_ContactPhone));
                    arlSQLParameters.Add(new SqlParameter("@CompanyURL", eocPropertyBean.Business_UserProfile_CompanyURL));
                    arlSQLParameters.Add(new SqlParameter("@BillingPerson", eocPropertyBean.Business_UserProfile_BillingPerson));
                    arlSQLParameters.Add(new SqlParameter("@WebInventoryManager", eocPropertyBean.Business_UserProfile_WebInventoryManager));
                    arlSQLParameters.Add(new SqlParameter("@CompanyProfile", eocPropertyBean.Business_UserProfile_CompanyProfile));
                   // arlSQLParameters.Add(new SqlParameter("@UpdatedOn", eocPropertyBean.UpdatedOn.ToString()));
                    arlSQLParameters.Add(new SqlParameter("@ImagePath",eocPropertyBean.CorporateImagePathEdit.ToString()));
     
                    intActionResult = this.ExecuteActionQuery("USP_CP_UsrPro_UpdateRecord", arlSQLParameters);
                }
                else
                {
                    intActionResult = -2;
                }
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
    /// Update specific row in the table Business_UserProfile.
    /// </summary>
    /// <param name="eocPropertyBean">EOC_PropertyBean</param>
    /// <returns>Integer</returns>
    public int UpdateRecord_UserProfileByAdmin(EOC_PropertyBean eocPropertyBean)
    {
        int intActionResult = 0;

        try
        {
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@ProfileID", eocPropertyBean.Business_UserProfile_ProfileID.ToString()));
            arlSQLParameters.Add(new SqlParameter("@LoginEmail", eocPropertyBean.Business_UserProfile_LoginEmail));

            //Case 01: Looking for duplicate login email before updating record.
            if (this.ExecuteQuery("USP_CP_UsrPro_BeforeUpdate_IsLoginEmailDuplicate", arlSQLParameters).Rows.Count == 0)
            {
                arlSQLParameters.Clear();
                arlSQLParameters.Add(new SqlParameter("@ProfileID", eocPropertyBean.Business_UserProfile_ProfileID.ToString()));
                arlSQLParameters.Add(new SqlParameter("@CompanyName", eocPropertyBean.Business_UserProfile_CompanyName));
                //arlSQLParameters.Add(new SqlParameter("@CountryID", eocPropertyBean.Country_CountryID.ToString()));

                //Case 02: Looking for duplicate company name before updating record.
                if (this.ExecuteQuery("USP_CP_UsrPro_BeforeUpdate_IsCompanyNameDuplicate", arlSQLParameters).Rows.Count == 0)
                {
                    arlSQLParameters.Clear();
                    arlSQLParameters.Add(new SqlParameter("@ProfileID", eocPropertyBean.Business_UserProfile_ProfileID.ToString()));
                    arlSQLParameters.Add(new SqlParameter("@BusinessID", eocPropertyBean.BusinessCategory_BusinessID.ToString()));
                    arlSQLParameters.Add(new SqlParameter("@LoginEmail", eocPropertyBean.Business_UserProfile_LoginEmail));
                    arlSQLParameters.Add(new SqlParameter("@CompanyName", eocPropertyBean.Business_UserProfile_CompanyName));
                    arlSQLParameters.Add(new SqlParameter("@BusinessAddress", eocPropertyBean.Business_UserProfile_BusinessAddress));
                    arlSQLParameters.Add(new SqlParameter("@ProvinceID", eocPropertyBean.Province_ProvinceID.ToString()));
                    arlSQLParameters.Add(new SqlParameter("@ContactPhone", eocPropertyBean.Business_UserProfile_ContactPhone));
                    arlSQLParameters.Add(new SqlParameter("@CompanyURL", eocPropertyBean.Business_UserProfile_CompanyURL));
                    arlSQLParameters.Add(new SqlParameter("@UpdatedOn", eocPropertyBean.UpdatedOn.ToString()));
                    arlSQLParameters.Add(new SqlParameter("@ImagePath", eocPropertyBean.CorporateImagePathEdit.ToString()));
                    intActionResult = this.ExecuteActionQuery("USP_CP_UsrPro_UpdateRecordByAdmin", arlSQLParameters);
                }
                else
                {
                    intActionResult = -2;
                }
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

    public int UpdateRecord_ChangePassword(EOC_PropertyBean eocPropertyBean)
    {
        int intActionResult = 0;

        try
        {
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Add(new SqlParameter("@ProfileID", eocPropertyBean.Business_UserProfile_ProfileID.ToString()));
            arlSQLParameters.Add(new SqlParameter("@LoginPassword", eocPropertyBean.Business_UserProfile_OldPassword));

            if (this.ExecuteQuery("USP_CP_UsrPro_IsOldPasswordValid", arlSQLParameters).Rows.Count > 0)
            {
                arlSQLParameters.Clear();
                arlSQLParameters.Add(new SqlParameter("@ProfileID", eocPropertyBean.Business_UserProfile_ProfileID.ToString()));
                arlSQLParameters.Add(new SqlParameter("@LoginPassword", eocPropertyBean.Business_UserProfile_LoginPassword));
                arlSQLParameters.Add(new SqlParameter("@UpdatedOn", eocPropertyBean.UpdatedOn.ToString()));

                intActionResult = this.ExecuteActionQuery("USP_CP_UsrPro_UpdatePassword", arlSQLParameters);
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
    /// Select specific row from the table Business_ActivationLinks
    /// </summary>
    /// <param name="eocPropertyBean">EOC_PropertyBean</param>
    /// <returns>DataTable</returns>
    public DataTable SelectRecord_ActivationLinks(EOC_PropertyBean eocPropertyBean)
    {
        DataTable dtActivationLink = null;

        try
        {
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Add(new SqlParameter("@LoginEmail", eocPropertyBean.Business_UserProfile_LoginEmail));

            dtActivationLink = this.ExecuteQuery("USP_CP_ActLink_01_SelectActLink", arlSQLParameters);
        }
        catch
        {
            throw;
        }

        return dtActivationLink;
    }

    /// <summary>
    /// Insert new row in the table Business_ActivationLinks.
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
            arlSQLParameters.Add(new SqlParameter("@LoginEmail", eocPropertyBean.Business_UserProfile_LoginEmail));

            DataTable dtUserProfile = this.ExecuteQuery("USP_CP_ActLink_ReadProfileID", arlSQLParameters);

            if (dtUserProfile.Rows.Count == 0)
            {
                intActionResult = -1;
            }
            else
            {
                intProfileID = Convert.ToInt32(dtUserProfile.Rows[0]["ProfileID"].ToString());

                arlSQLParameters.Clear();
                arlSQLParameters.Add(new SqlParameter("@ProfileID", intProfileID.ToString()));
                //arlSQLParameters.Add(new SqlParameter("@UpdatedOn", DateTime.Now.ToString()));

                intActionResult = this.ExecuteActionQuery("USP_CP_ActLink_InsertRecord", arlSQLParameters);
            }
        }
        catch
        {
            throw;
        }

        return intActionResult;
    }

    /// <summary>
    /// Update specific row in the table Business_ActivationLinks.
    /// </summary>
    /// <param name="eocPropertyBean">EOC_PropertyBean</param>
    /// <returns>Integer</returns>
    public int UpdateRecord_ActivationLinks(EOC_PropertyBean eocPropertyBean)
    {
        int intActionResult = 0;

        try
        {
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@LinkID", eocPropertyBean.Business_ActivationLinks_LinkID.ToString()));
            arlSQLParameters.Add(new SqlParameter("@ProfileID", eocPropertyBean.Business_UserProfile_ProfileID.ToString()));

            DataTable dtActivationLink = this.ExecuteQuery("USP_CP_ActLink_02_SelectActLink", arlSQLParameters);

            if (dtActivationLink.Rows.Count == 0)
            {
                intActionResult = -1;
            }
            else
            {
                arlSQLParameters.Clear();
                arlSQLParameters.Add(new SqlParameter("@LinkID", eocPropertyBean.Business_ActivationLinks_LinkID.ToString()));
                arlSQLParameters.Add(new SqlParameter("@ProfileID", eocPropertyBean.Business_UserProfile_ProfileID.ToString()));
                arlSQLParameters.Add(new SqlParameter("@IsChecked", eocPropertyBean.Business_ActivationLinks_IsChecked.ToString()));

                intActionResult = this.ExecuteActionQuery("USP_CP_ActLink_UpdateRecord", arlSQLParameters);
            }
        }
        catch
        {
            throw;
        }

        return intActionResult;
    }


    public DataTable GetSellerDetail(EOC_PropertyBean bean)
    {
        DataTable dt = null;
        try
        {
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@ProfileID", bean.Business_UserProfile_ProfileID.ToString()));

            dt = this.ExecuteQuery("USP_CP_LoadSpecificSellerInfo", arlSQLParameters);
        }
        catch
        {
            throw;
        }
        return dt;
    }
}
