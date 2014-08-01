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
/// Summary description for CommonProduct
/// </summary>
public class CommonProduct
{

    private int _ProductID;

    public int ProductID
    {
        get { return _ProductID; }
        set { _ProductID = value; }
    }

    private int _ProductSellerDetailID;

    public int ProductSellerDetailID
    {
        get { return _ProductSellerDetailID; }
        set { _ProductSellerDetailID = value; }
    }

    private int _CategoryID;

    public int CategoryID
    {
        get { return _CategoryID; }
        set { _CategoryID = value; }
    }

	public CommonProduct()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}
