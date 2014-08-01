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
/// Summary description for ShopConfiguration
/// </summary>
public static class ShopConfiguration
{
    private readonly static int cartPersistDays;
    public static int CartPersistDays
    {
        get
        {
            return cartPersistDays;
        }
    }

    private readonly static int productCounterPersistDay;
    public static int ProductCounterPersistDay
    {
        get
        {
            return productCounterPersistDay;
        }
    }



	static ShopConfiguration()
	{
		//
		// TODO: Add constructor logic here
		//
        cartPersistDays = Int32.Parse(ConfigurationManager.AppSettings["CartPersistDays"]);
        productCounterPersistDay = Int32.Parse(ConfigurationManager.AppSettings["ProductCounterPersistDay"]);
	}
}
