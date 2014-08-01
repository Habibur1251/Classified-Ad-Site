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
/// Summary description for BC_CommonUser
/// </summary>
public class BC_CommonUser:DbBaseClass
{
	public BC_CommonUser():base(StaticSettings.Database.DbConnectionString)
	{
		//
		// TODO: Add constructor logic here
		//
	}


    /// <summary>
    /// Common Login Control Used in Each page uses this Method.
    /// USP: USP_Common_UsrPro_GetLoginInfo
    /// </summary>
    /// <param name="_LoginEmail"></param>
    /// <param name="_LoginPassword"></param>
    /// <returns></returns>
    public DataTable IsLoginValid(string _LoginEmail, string _LoginPassword)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@LoginEmail", _LoginEmail);
        ht.Add("@LoginPassword", _LoginPassword);
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_Common_UsrPro_GetLoginInfo", ht);
        }
        catch
        {
            throw;
        }
    }


    /// <summary>
    /// Forgot password link uses this Method to find logininfo.
    /// USP: USP_Common_ActLink_01_SelectActLink
    /// </summary>
    /// <param name="_LoginEmail"></param>
    /// <returns></returns>
    public DataTable SelectRecord_ActivationLinks(string _LoginEmail)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@LoginEmail", _LoginEmail);
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_Common_ActLink_01_SelectActLink", ht);
        }
        catch
        {
            throw;
        }
    }


    /// <summary>
    /// Loads User information based on ProfileID
    /// USP: USP_Review_LoadReviewerInfo
    /// </summary>
    /// <param name="objUser"></param>
    /// <returns></returns>
    public DataTable LoadReviewerInfo(User objUser)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@ProfileID", objUser.ProfileID);
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_Review_LoadReviewerInfo", ht);
        }
        catch
        {
            throw;
        }
    }

    public DataTable LoadNoOfUserReview(User objUser)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@ProfileID", objUser.ProfileID);
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_Review_LoadNoOfUserReview", ht);
        }
        catch
        {
            throw;
        }
    }


    #region COMMON LOGIN VALIDATION

    

    #endregion COMMON LOGIN VALIDATION

    #region METHODS FOR USER CONTROL PANEL

    /// <summary>
    /// Loads List of Pending Orders For a Specific Seller.
    /// Uses Seller's ProfileID as Parameter.
    /// </summary>
    /// <param name="objUser"></param>
    /// <returns></returns>
    public DataTable LoadList_PendingOrders(User objUser)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@ProfileID", objUser.ProfileID);
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_CP_SellLead_LoadPendingOrders", ht);
        }
        catch
        {
            throw;
        }
    }

    public DataTable Load_BuyerSpesificInformation(int intOrderID)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@OrderID", intOrderID);
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_CP_SellLead_LoadBuyerSpesificInformation", ht);
        }
        catch
        {
            throw;
        }
    }
    

    #endregion METHODS FOR USER CONTROL PANEL



}
