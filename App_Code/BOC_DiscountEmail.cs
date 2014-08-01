using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Collections;

/// <summary>
/// Summary description for BOC_DiscountEmail
/// </summary>
public class BOC_DiscountEmail : UTLDBHandler
{
    public BOC_DiscountEmail(): base(UTLUtilities.Database.DbConnectionString)
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int AddEmailAdress(EOC_PropertyBean eocPropertyBean)
    {
        int intActionResult = 0;
        try
        {
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Add(new SqlParameter("@emailAddress", eocPropertyBean.DiscountEmail));
            intActionResult = this.ExecuteActionQuery("USP_SaveDiscountEmail", arlSQLParameters);
        }
        catch
        {
            throw;
        }
        return intActionResult;
    }
}
