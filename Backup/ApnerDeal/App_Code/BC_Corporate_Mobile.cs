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
/// Summary description for BC_Corporate_Mobile
/// </summary>
public class BC_Corporate_Mobile: DbBaseClass
{
	public BC_Corporate_Mobile():base(StaticSettings.Database.DbConnectionString)
	{
		//
		// TODO: Add constructor logic here
		//
	}


    /// <summary>
    /// Loads Specific Mobile Record.
    /// USP: USP_CP_BS_SelectSpecific_Mobile
    /// </summary>
    /// <param name="intProductID"></param>
    /// <param name="intProfileID"></param>
    /// <param name="intCategoryID"></param>
    /// <param name="intSubcategoryID"></param>
    /// <param name="intSecondSubcatID"></param>
    /// <returns></returns>
    public DataTable LoadRecord_BS_SpecificMobile(int intProductID, int intProfileID, int intCategoryID, int intSubcategoryID,
        int intSecondSubcatID)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@ProductID", intProductID);
        ht.Add("@ProfileID", intProfileID);
        ht.Add("@CategoryID", intCategoryID);
        ht.Add("@SubcategoryID", intSubcategoryID);
        ht.Add("@SecondSubcatID", intSecondSubcatID);
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_CP_BS_SelectSpecific_Mobile", ht);
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Selects Selects Category, SUbcategory, SecondSubcat, Model ID From Latest_Posted_Mobile
    /// For Tag users.
    /// USP: USP_CP_Public_Select_Master_MobileRecord
    /// </summary>
    /// <param name="categoryID"></param>
    /// <param name="subcategoryID"></param>
    /// <param name="secondSubcatIDstring"></param>
    /// <param name="?"></param>
    /// <param name="productID"></param>
    /// <returns></returns>
    public DataTable SelectSpecific_Master_MobileRecord(int categoryID, int subcategoryID, int secondSubcatID, int productID)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@CategoryID", categoryID);
        ht.Add("@SubcategoryID", subcategoryID);
        ht.Add("@SecondSubcatID", secondSubcatID);
        ht.Add("@ProductID", productID);
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_CP_Public_Select_Master_MobileRecord", ht);
        }
        catch
        {
            throw;
        }
    }
}
