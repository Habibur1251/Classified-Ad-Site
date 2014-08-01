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

public class HomePageHandler : UTLDBHandler
{
    public HomePageHandler() : base(UTLUtilities.Database.DbConnectionString)
	{
	}

    public DataTable LoadRecord_Country()
    {
        try
        {
            ArrayList arlSQLParameters = new ArrayList();
            return this.ExecuteQuery("USP_Common_LoadCountry", arlSQLParameters);
        }
        catch
        {
            throw;
        }
    }

    public DataTable LoadRecord_Category(EOC_PropertyBean eocPropertyBean)
    {
        try
        {
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Add(new SqlParameter("@CountryID", eocPropertyBean.Country_CountryID.ToString()));

            return this.ExecuteQuery("USP_Common_LoadCategory", arlSQLParameters);
        }
        catch
        {
            throw;
        }
    }

    public DataTable LoadRecord_LeftMenuItems(EOC_PropertyBean eocPropertyBean)
    {
        try
        {
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Add(new SqlParameter("@CountryID", eocPropertyBean.Country_CountryID.ToString()));

            return this.ExecuteQuery("USP_Admin_LeftMenuItems", arlSQLParameters);
        }
        catch
        {
            throw;
        }
    }

    public DataTable LoadRecord_LatestProduct(EOC_PropertyBean eocPropertyBean)
    {
        try
        {
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Add(new SqlParameter("@CategoryID", eocPropertyBean.Category_CategoryID.ToString()));
            arlSQLParameters.Add(new SqlParameter("@CountryID", eocPropertyBean.Country_CountryID.ToString()));

            return this.ExecuteQuery("USP_Admin_LatestProduct", arlSQLParameters);
        }
        catch
        {
            throw;
        }
    }

    public DataTable LoadRecord_LatestBooks(EOC_PropertyBean eocPropertyBean)
    {
        try
        {
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Add(new SqlParameter("@CategoryID", eocPropertyBean.Category_CategoryID.ToString()));
            arlSQLParameters.Add(new SqlParameter("@CountryID", eocPropertyBean.Country_CountryID.ToString()));

            return this.ExecuteQuery("USP_Admin_LatestBooks", arlSQLParameters);
        }
        catch
        {
            throw;
        }
    }

    public DataTable LoadRecord_LatestCarMotorCycles(EOC_PropertyBean eocPropertyBean)
    {
        try
        {
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Add(new SqlParameter("@CategoryID", eocPropertyBean.Category_CategoryID.ToString()));
            arlSQLParameters.Add(new SqlParameter("@CountryID", eocPropertyBean.Country_CountryID.ToString()));

            return this.ExecuteQuery("USP_Admin_LatestCAR_MC", arlSQLParameters);
        }
        catch
        {
            throw;
        }
    }

    public DataTable LoadRecord_LatestMobile(EOC_PropertyBean eocPropertyBean)
    {
        try
        {
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Add(new SqlParameter("@CategoryID", eocPropertyBean.Category_CategoryID.ToString()));
            arlSQLParameters.Add(new SqlParameter("@CountryID", eocPropertyBean.Country_CountryID.ToString()));

            return this.ExecuteQuery("USP_Admin_LatestMobile", arlSQLParameters);
        }
        catch
        {
            throw;
        }
    }

    public DataTable LoadRecord_LatestCOM_LAP_PARTS(EOC_PropertyBean eocPropertyBean)
    {
        try
        {
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Add(new SqlParameter("@CategoryID", eocPropertyBean.Category_CategoryID.ToString()));
            arlSQLParameters.Add(new SqlParameter("@CountryID", eocPropertyBean.Country_CountryID.ToString()));

            return this.ExecuteQuery("USP_Admin_LatestCOM_LAP_ACC", arlSQLParameters);
        }
        catch
        {
            throw;
        }
    }
    public DataTable LoadRecord_LatestElectronics(EOC_PropertyBean eocPropertyBean)
    {
        try
        {
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Add(new SqlParameter("@CategoryID", eocPropertyBean.Category_CategoryID.ToString()));
            arlSQLParameters.Add(new SqlParameter("@CountryID", eocPropertyBean.Country_CountryID.ToString()));

            return this.ExecuteQuery("USP_Admin_LatestElectronics", arlSQLParameters);
        }
        catch
        {
            throw;
        }
    }

    public DataTable LoadRecord_LatestHome_OffAppliances(EOC_PropertyBean eocPropertyBean)
    {
        try
        {
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Add(new SqlParameter("@CategoryID", eocPropertyBean.Category_CategoryID.ToString()));
            arlSQLParameters.Add(new SqlParameter("@CountryID", eocPropertyBean.Country_CountryID.ToString()));

            return this.ExecuteQuery("USP_Admin_LatestHomeOffAppliances", arlSQLParameters);
        }
        catch
        {
            throw;
        }
    }

    public DataTable LoadRecord_LatestHome_RealEstate(EOC_PropertyBean eocPropertyBean)
    {
        try
        {
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Add(new SqlParameter("@CategoryID", eocPropertyBean.Category_CategoryID.ToString()));
            arlSQLParameters.Add(new SqlParameter("@CountryID", eocPropertyBean.Country_CountryID.ToString()));

            return this.ExecuteQuery("USP_Admin_LatestRealEstate", arlSQLParameters);
        }
        catch
        {
            throw;
        }
    }

    public DataTable LoadRecord_01_LatestClassifieds(EOC_PropertyBean eocPropertyBean)
    {
        try
        {
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Add(new SqlParameter("@CountryID", eocPropertyBean.Country_CountryID.ToString()));

            return this.ExecuteQuery("USP_Admin_01_LatestClassifieds", arlSQLParameters);
        }
        catch
        {
            throw;
        }
    }

    public DataTable LoadRecord_02_LatestClassifieds(EOC_PropertyBean eocPropertyBean)
    {
        try
        {
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Add(new SqlParameter("@CountryID", eocPropertyBean.Country_CountryID.ToString()));
            //arlSQLParameters.Add(new SqlParameter("@AdvertisementType", eocPropertyBean.AdvertisementType.ToString()));
            return this.ExecuteQuery("USP_Admin_02_LatestClassifieds", arlSQLParameters);
        }
        catch
        {
            throw;
        }
    }

   
    public DataTable LoadRecord_LatestReviews(EOC_PropertyBean eocPropertyBean)
    {
        try
        {
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Add(new SqlParameter("@CountryID", eocPropertyBean.Country_CountryID.ToString()));

            return this.ExecuteQuery("USP_Admin_LatestReviews", arlSQLParameters);
        }
        catch
        {
            throw;
        }
    }
    public DataTable LoadRecord_ShopALLDepertment(EOC_PropertyBean eocPropertyBean)
    {
        try
        {
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Add(new SqlParameter("@Country", eocPropertyBean.Country_CountryName.ToString()));
            return this.ExecuteQuery("USP_CP_ShoppingAll_Dept", arlSQLParameters);
        }
        catch
        {
            throw;
        }
    }
    public DataTable LoadlistCategory(EOC_PropertyBean eocPropertyBean)
    {
        try
        {
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Add(new SqlParameter("@Country", eocPropertyBean.Country_CountryName.ToString()));
            return this.ExecuteQuery("USP_Common_LoadList_ClassifiedsCategory", arlSQLParameters);
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="eocPropertyBean"></param>
    /// <returns></returns>
    public DataTable LoadListAdvertisement(EOC_PropertyBean eocPropertyBean)
    {
        try
        {
            ArrayList arSQLParameters = new ArrayList();
            return this.ExecuteQuery("USP_Common_LoadList_Advertisementdetail", arSQLParameters);
        }
        catch
        {
            throw;
        }
    }

    public int AddRequest(EOC_PropertyBean eocPropertyBean)
    {
        int intActionResult = 0;
        try
        {
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Add(new SqlParameter("@Ad_RequestName", eocPropertyBean.AdRequest_User_Name));
            arlSQLParameters.Add(new SqlParameter("@Ad_RequestAddress", eocPropertyBean.AdRequest_User_Address));
            arlSQLParameters.Add(new SqlParameter("@Ad_RequestPhoneNo", eocPropertyBean.AdRequest_User_PhoneNo.ToString()));
            arlSQLParameters.Add(new SqlParameter("@Ad_RequestEmail", eocPropertyBean.AdRequest_User_Mail.ToString()));
            arlSQLParameters.Add(new SqlParameter("@Ad_RequestMessage", eocPropertyBean.AdRequest_User_Message));
            intActionResult = this.ExecuteActionQuery("USP_Common_InsertRequest", arlSQLParameters);
        }
        catch
        {
            throw;
        }
        return intActionResult;
    }
    
}
