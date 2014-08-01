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
/// Summary description for BC_LandingPageComments
/// </summary>
public class BC_LandingPageComments : DbBaseClass
{
	public BC_LandingPageComments() : base(StaticSettings.Database.DbConnectionString)
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int SaveRecord_LandingPageComments(string name, string companyName, string email, string phone, string commentsSubject, string comments)
    {
        Hashtable htParams = new Hashtable();
        htParams.Add("@SellerName", name);
        htParams.Add("@CompanyName", companyName);
        htParams.Add("@EmailAddress", email);
        htParams.Add("@Phone", phone);
        htParams.Add("@CommentsSubject", commentsSubject);
        htParams.Add("@Comments", comments);

        try
        {
            int intActionResult = this.ExecuteNonQueryStoredProcedure("USP_Admin_InsertSellersLandingPageSuggestion", htParams);
            return intActionResult;
        }
        catch 
        {
            throw;
        }
        
    }
}
