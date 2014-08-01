using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for UserManager
/// </summary>
public class UserManager
{
	public UserManager()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    /// <summary>
    /// Loads User Information.
    /// </summary>
    /// <param name="objUser"></param>
    /// <returns></returns>
    public DataTable LoadReviewerInfo(User objUser)
    {
        try
        {
            using (BC_CommonUser handler = new BC_CommonUser())
            {
                return handler.LoadReviewerInfo(objUser);
            }
        }
        catch
        {
            throw;
        }
    }

    public DataTable LoadNoOfUserReview(User objUser)
    {
        try
        {
            using (BC_CommonUser handler = new BC_CommonUser())
            {
                return handler.LoadNoOfUserReview(objUser);
            }
        }
        catch
        {
            throw;
        }
    }
}
