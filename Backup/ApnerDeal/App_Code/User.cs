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
/// Summary description for User
/// </summary>
public class User
{
    private int _ProfileID;

    public int ProfileID
    {
        get { return _ProfileID; }
        set { _ProfileID = value; }
    }

    private string _SellerInfo;
    /// <summary>
    /// Keeps UserName for Classified User and Company Name for Corporate User.
    /// </summary>
    public string SellerInfo
    {
        get { return _SellerInfo; }
        set { _SellerInfo = value; }
    }

    private string _Address;

    public string Address
    {
        get { return _Address; }
        set { _Address = value; }
    }

    private string _CellNo;

    public string CellNo
    {
        get { return _CellNo; }
        set { _CellNo = value; }
    }

    private string _LoginEmail;

    public string LoginEmail
    {
        get { return _LoginEmail; }
        set { _LoginEmail = value; }
    }

    private string _Password;

    public string Password
    {
        get { return _Password; }
        set { _Password = value; }
    }


	public User()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}
