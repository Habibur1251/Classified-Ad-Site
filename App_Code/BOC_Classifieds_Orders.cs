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

public class BOC_Classifieds_Orders : UTLDBHandler
{
    public BOC_Classifieds_Orders() : base(UTLUtilities.Database.DbConnectionString)
	{
	}

    public DataTable LoadRecord_Subcategory(EOC_PropertyBean eocPropertyBean)
    {
        try
        {
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@CategoryID", eocPropertyBean.Category_CategoryID.ToString()));
            return this.ExecuteQuery("USP_CL_Public_LoadSubcategory", arlSQLParameters);
        }
        catch
        {
            throw;
        }
    }
    
    /// <summary>
    /// Filters by only By Subcategory
    /// </summary>
    /// <param name="eocPropertyBean"></param>
    /// <returns></returns>
    public DataTable LoadRecord_ProductList_Classifieds(EOC_PropertyBean eocPropertyBean)
    {
        try
        {
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@SubcategoryID", eocPropertyBean.Subcategory_SubcategoryID.ToString()));
            arlSQLParameters.Add(new SqlParameter("@Country", eocPropertyBean.Country_CountryName));
            //arlSQLParameters.Add(new SqlParameter("@AdvertisementType", eocPropertyBean.Classifieds_ProductProfile_AdvertisementType));

            return this.ExecuteQuery("USP_CL_Public_ProductList_Classifieds", arlSQLParameters);
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Loads all Classified Items Based on Category. Filters only by CategoryID
    /// USP: USP_CL_Public_ProductList_Classifieds_Categorywise
    /// </summary>
    /// <param name="eocPropertyBean"></param>
    /// <returns></returns>
    public DataTable LoadRecord_ProductList_Classifieds_By_Category(EOC_PropertyBean eocPropertyBean)
    {
        try
        {
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@CategoryID", eocPropertyBean.Subcategory_CategoryID.ToString()));

            return this.ExecuteQuery("USP_CL_Public_ProductList_Classifieds_Categorywise", arlSQLParameters);
        }
        catch
        {
            throw;
        }
    }

    public DataTable SelectRecord_ProductProfile_Classifieds(EOC_PropertyBean eocPropertyBean)
    {
        try
        {
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@ProductID", eocPropertyBean.Classifieds_ProductProfile_ProductID.ToString()));
            arlSQLParameters.Add(new SqlParameter("@ProfileID", eocPropertyBean.Classifieds_UserProfile_ProfileID.ToString()));

            return this.ExecuteQuery("USP_CL_Public_SelectProduct_Classifieds", arlSQLParameters);
        }
        catch
        {
            throw;
        }
    }

    public int AddRecord_ProductReview(EOC_PropertyBean eocPropertyBean)
    {
        int intActionResult = 0;

        try
        {
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@ProductID", eocPropertyBean.Classifieds_ProductProfile_ProductID.ToString()));
            arlSQLParameters.Add(new SqlParameter("@CriticsName", eocPropertyBean.ProductReview_Classified_CriticsName));
            arlSQLParameters.Add(new SqlParameter("@Review", eocPropertyBean.ProductReview_Classified_Review));


            intActionResult = this.ExecuteActionQuery("USP_CL_ProdReview_InsertRecord", arlSQLParameters);
        }
        catch
        {
            throw;
        }

        return intActionResult;
    }

    public DataTable LoadRecord_ProductReview(EOC_PropertyBean eocPropertyBean)
    {
        try
        {
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@ProductID", eocPropertyBean.Classifieds_ProductProfile_ProductID.ToString()));
            return this.ExecuteQuery("USP_CL_ProdReview_Classified_LoadRecord", arlSQLParameters);
        }
        catch
        {
            throw;
        }
    }

    public int AddRecord_ProductOrder(EOC_PropertyBean eocPropertyBean)
    {
        int intActionResult = 0;
        string a = "";
        try
        {
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@ProductID", eocPropertyBean.Classifieds_ProductProfile_ProductID.ToString()));
            arlSQLParameters.Add(new SqlParameter("@CustomerEmail", eocPropertyBean.Classifieds_OrderDetail_CustomerEmail));
            arlSQLParameters.Add(new SqlParameter("@CustomerName", eocPropertyBean.Classifieds_OrderDetail_CustomerName));
            arlSQLParameters.Add(new SqlParameter("@CustomerMessage", eocPropertyBean.Classifieds_OrderDetail_CustomerMessage));
            //arlSQLParameters.Add(new SqlParameter("@UpdatedOn", eocPropertyBean.UpdatedOn.ToString()));

            intActionResult = this.ExecuteActionQuery("USP_CL_OrderDetails_Classifieds_InsertRecord", arlSQLParameters);
        }
        catch
        {
            throw;
        }

        return intActionResult;
    }

    
    public DataTable LoadList_ProductInformation_ClassifiedUser(EOC_PropertyBean eocPropertyBean)
    {
        try
        {
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Add(new SqlParameter("@ProductSellerDetailID", eocPropertyBean.Classified_ProductSellerDetailID));
            arlSQLParameters.Add(new SqlParameter("@CategoryID", eocPropertyBean.Category_CategoryID));
            return this.ExecuteQuery("USP_LoadList_ProductInformation_ClassifiedUser", arlSQLParameters);
        }
        catch
        {
            throw;
        }
    }

    public DataTable LoadList_Information_ClassifiedProducts(EOC_PropertyBean eocPropertyBean)
    {

        try
        {
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@ProductID", eocPropertyBean.Classifieds_ProductProfile_ProductID.ToString()));

            return this.ExecuteQuery("USP_CL_ProductDetails_Classifieds_ProducrProfiles", arlSQLParameters);
        }
        catch
        {
            throw;
        }
    }
}
