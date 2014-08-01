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
/// Summary description for BC_Corporate_Computer
/// </summary>
public class BC_Corporate_Computer: DbBaseClass
{
	public BC_Corporate_Computer():base(StaticSettings.Database.DbConnectionString)
	{
		//
		// TODO: Add constructor logic here
		//
	}

    /// <summary>
    /// Loads Specific Computer Record.
    /// USP: USP_CP_BS_SelectSpecific_Computer
    /// </summary>
    /// <param name="intProductID"></param>
    /// <param name="intProfileID"></param>
    /// <param name="intCategoryID"></param>
    /// <param name="intSubcategoryID"></param>
    /// <param name="intSecondSubcatID"></param>
    /// <returns></returns>
    public DataTable LoadRecord_BS_SpecificComputer(int intProductID, int intProfileID, int intCategoryID, int intSubcategoryID,
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
            return this.ExecuteStoredProcedureDataTable("USP_CP_BS_SelectSpecific_Computer", ht);
        }
        catch
        {
            throw;
        }
    }
}
