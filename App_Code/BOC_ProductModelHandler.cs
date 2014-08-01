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

/// <summary>
/// Summary description for BOC_ProductModelHandler
/// </summary>
public class BOC_ProductModelHandler : UTLDBHandler
{
	public BOC_ProductModelHandler()

        : base(UTLUtilities.Database.DbConnectionString.ToString())
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public bool BeforeInsert_IsProductModel_Duplicate(EOC_PropertyBean eocPropertyBean)
    {
        DataTable dt = null;
        try
        {
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Add(new SqlParameter("@ProductModel", eocPropertyBean.ProductModel));
            arlSQLParameters.Add(new SqlParameter("@CategoryID", eocPropertyBean.Category_CategoryID));
            arlSQLParameters.Add(new SqlParameter("@SubcategoryID", eocPropertyBean.Subcategory_SubcategoryID));
            arlSQLParameters.Add(new SqlParameter("@SecondSubcatID", eocPropertyBean.SecondSubcatID));
            dt = this.ExecuteQuery("USP_CP_Admin_BeforeInsert_IsProductModelDuplicate", arlSQLParameters);
        }
        catch
        {
            throw;
        }
        return (dt.Rows.Count > 0 ? true : false);
    }

    public int InsertRecord_ProductModel(EOC_PropertyBean eocPropertyBean)
    {
        try
        {
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Add(new SqlParameter("@ProductModel", eocPropertyBean.ProductModel));
            arlSQLParameters.Add(new SqlParameter("@CategoryID", eocPropertyBean.Category_CategoryID));
            arlSQLParameters.Add(new SqlParameter("@SubcategoryID", eocPropertyBean.Subcategory_SubcategoryID));
            arlSQLParameters.Add(new SqlParameter("@SecondSubcatID", eocPropertyBean.SecondSubcatID));
            return this.ExecuteActionQuery("USP_CP_Admin_InsertProductModel", arlSQLParameters);
        }
        catch
        {
            throw;
        }
    }


    public DataTable LoadRecord_ProductModel(EOC_PropertyBean eocPropertyBean)
    {
        try
        {
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Add(new SqlParameter("@CategoryID", eocPropertyBean.Category_CategoryID));
            arlSQLParameters.Add(new SqlParameter("@SubcategoryID", eocPropertyBean.Subcategory_SubcategoryID));
            arlSQLParameters.Add(new SqlParameter("@SecondSubcatID", eocPropertyBean.SecondSubcatID));
            return this.ExecuteQuery("USP_Admin_LoadProductModel", arlSQLParameters);
        }
        catch
        {
            throw;
        }
    }

    public DataTable SelectRecord_ProductModel(EOC_PropertyBean eocPropertyBean)
    {
        try
        {
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Add(new SqlParameter("@ProductModelID", eocPropertyBean.ProductModelID));
            return this.ExecuteQuery("USP_Admin_SelectRecord_ProductModel", arlSQLParameters);
        }
        catch
        {
            throw;
        }
    }



}
