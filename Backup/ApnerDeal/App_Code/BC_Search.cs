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
/// Summary description for BC_Search
/// </summary>
public class BC_Search : DbBaseClass
{
	public BC_Search() : base(StaticSettings.Database.DbConnectionString)
	{
		//
		// TODO: Add constructor logic here
		//
	}

    /// <summary>
    /// Searches all Items by a keyword. Uses CountryID for filtering.
    /// </summary>
    /// <param name="intCountryID"></param>
    /// <param name="strTextToSearch"></param>
    /// <returns></returns>
    public DataTable Search_AllItems(string strCountry, string strKeyword)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@Country", strCountry);
        ht.Add("@Keyword", strKeyword);
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_Common_Search_AllItems", ht);
        }
        catch
        {
            throw;
        }
    }

    public DataTable Search_AllReviews(string strKeyword)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@Keyword", strKeyword);
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_Common_Search_AllReview", ht);
        }
        catch
        {
            throw;
        }
    }

    public DataTable Search_AllDiscount(string strKeyword)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@Keyword", strKeyword);
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_DRP_Common_Search_AllDiscount", ht);
        }
        catch
        {
            throw;
        }
    }
}
