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
/// Summary description for BC_Price_Range
/// </summary>
public class BC_Price_Range: DbBaseClass
{
	public BC_Price_Range():base(StaticSettings.Database.DbConnectionString)
	{
		//
		// TODO: Add constructor logic here
		//
	}



    /// <summary>
    /// Loads Price Range From PriceRange Table. Using CategoryID and SubcategoryID
    /// USP: USP_Common_Load_PriceRange
    /// </summary>
    /// <param name="intCategoryID"></param>
    /// <param name="intSubcategoryID"></param>
    /// <returns></returns>
    public DataTable LoadPriceRange(int intCategoryID, int intSubcategoryID)
    {
        Hashtable ht = new Hashtable();
        ht.Add("CategoryID", intCategoryID);
        ht.Add("SubcategoryID", intSubcategoryID);
        return this.ExecuteStoredProcedureDataTable("USP_Common_Load_PriceRange", ht);
    }


    /// <summary>
    /// Loads all Classified Items By Price Range.
    /// USP: USP_CL_Public_ProductList_Classifieds_ByPrice
    /// </summary>
    /// <param name="intCategoryID"></param>
    /// <param name="intSubcategoryID"></param>
    /// <param name="intPriceRaangeID"></param>
    /// <returns></returns>
    public DataTable LoadClassifiedItems_ByPriceRange(int intCategoryID, int intSubcategoryID, int intPriceRangeID)
    {
        Hashtable ht = new Hashtable();
        ht.Add("CategoryID", intCategoryID);
        ht.Add("SubcategoryID", intSubcategoryID);
        ht.Add("PriceRangeID", intPriceRangeID);
        return this.ExecuteStoredProcedureDataTable("USP_CL_Public_ProductList_Classifieds_ByPrice", ht);
 
    }

}
