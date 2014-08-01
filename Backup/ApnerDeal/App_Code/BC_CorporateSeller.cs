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
/// Summary description for BC_CorporateSeller
/// </summary>
public class BC_CorporateSeller : DbBaseClass
{
	public BC_CorporateSeller(): base(StaticSettings.Database.DbConnectionString)
	{
		//
		// TODO: Add constructor logic here
		//
	}

    /// <summary>
    /// Loads List of seller for specific Category and Subcateogry
    /// USP: USP_Common_LoadList_CorporateSeller
    /// </summary>
    /// <param name="intCategoryID"></param>
    /// <param name="intSubcategoryID"></param>
    /// <returns></returns>
    public DataTable LoadList_CorporateSeller(int intCategoryID, int intSubcategoryID)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@CategoryID", intCategoryID);
        ht.Add("@SubcategoryID", intSubcategoryID);
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_Common_LoadList_CorporateSeller", ht);
        }
        catch
        {
            throw;
        }
    }


    /// <summary>
    /// Loads All Items of a Specific BS Seller. Based on CategoryID and SubcategoryID
    /// USP: USP_Common_ItemList_Load_BS_Seller_Product
    /// </summary>
    /// <param name="intProfileID"></param>
    /// <param name="sellerType"></param>
    /// <returns></returns>
    public DataTable LoadSpecific_BS_SellerProduct(int intCategoryID, int intSubcategoryID, int intProfileID, string strCountry)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@CategoryID", intCategoryID);
        ht.Add("@SubcategoryID", intSubcategoryID);
        ht.Add("@ProfileID", intProfileID);
        ht.Add("@Country", strCountry);
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_Common_ItemList_Load_BS_Seller_Product", ht);
        }
        catch
        {
            throw;
        }
    }
}
