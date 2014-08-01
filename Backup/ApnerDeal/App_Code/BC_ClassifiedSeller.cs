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
/// Summary description for BC_ClassifiedSeller
/// </summary>
public class BC_ClassifiedSeller : DbBaseClass
{
    public BC_ClassifiedSeller()
        : base(StaticSettings.Database.DbConnectionString)
	{
		//
		// TODO: Add constructor logic here
		//
	}

    /// <summary>
    /// Loads List of seller for specific Category and Subcateogry
    /// USP: USP_Common_LoadCount_ClassifiedSeller  
    /// </summary>
    /// <param name="intCategoryID"></param>
    /// <param name="intSubcategoryID"></param>
    /// <returns></returns>
    public DataTable LoadList_ClassifiedSeller(int intCategoryID, int intSubcategoryID)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@CategoryID", intCategoryID);
        ht.Add("@SubcategoryID", intSubcategoryID);
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_Common_LoadCount_ClassifiedSeller", ht);
        }
        catch
        {
            throw;
        }
    }
}
