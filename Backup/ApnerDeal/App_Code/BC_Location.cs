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
/// Summary description for BC_Location
/// </summary>
public class BC_Location:DbBaseClass
{
	public BC_Location():base(StaticSettings.Database.DbConnectionString)
	{
		//
		// TODO: Add constructor logic here
		//
    }



    #region FOR LEFT MENU LOCATION FILTER


    /// <summary>
    /// Loads Lists of Province For Corporate Items.
    /// USP: USP_BS_Load_Province
    /// </summary>
    /// <param name="categoryID"></param>
    /// <param name="subcategoryID"></param>
    /// <returns></returns>
    public DataTable LoadList_Province(int categoryID, int subcategoryID)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@CategoryID", categoryID);
        ht.Add("@SubcategoryID", subcategoryID);
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_BS_Load_Province", ht);
        }
        catch
        {
            throw;
        }
    }

    #endregion FOR LEFT MENU LOCATION FILTER
}
