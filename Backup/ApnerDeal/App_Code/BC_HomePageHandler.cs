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

/// <summary>
/// Summary description for BC_HomePageHandler
/// </summary>
public class BC_HomePageHandler: DbBaseClass
{
	public BC_HomePageHandler():base(StaticSettings.Database.DbConnectionString)
	{
		//
		// TODO: Add constructor logic here
		//
	}



    /// <summary>
    /// Loads Latest Three Product Information For Displaying in HomePage.
    /// USP: USP_Admin_LatestProducts
    /// </summary>
    /// <param name="intCategoryID"></param>
    /// <param name="_Country"></param>
    /// <returns></returns>
    public DataTable Load_LatestProducts(int intCategoryID, string _Country)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@CategoryID", intCategoryID);
        ht.Add("@Country", _Country);
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_HP_Common_SecondColumn_ProductList", ht);
        }
        catch
        {
            throw;
        }
    }

    public DataTable Load_LatestAllSellerProducts(int ProfileID)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@ProductSellerDetailID", ProfileID);
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_Admin_SellerAllProducts", ht);
        }
        catch
        {
            throw;
        }
    }

    public DataTable Load_SellerInformation(int ProfileID)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@ProductSellerDetailID", ProfileID);
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_Admin_SellerInformation", ht);
        }
        catch
        {
            throw;
        }
    }
}
