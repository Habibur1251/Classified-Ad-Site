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
/// Summary description for ProductHandler
/// </summary>
public class ProductHandler
{
    int _ProductCookiePersistDay = 1;

   
	public ProductHandler()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    /// <summary>
    /// Increments a products HitCounterField.
    /// </summary>
    /// <param name="objProduct"></param>
    /// <returns></returns>
    public bool IncrementProductCounter(CommonProduct objProduct)
    {
        int _ActionResult = -1;

        if (!this.IsAlreadyUpdated(objProduct))
        {
            try
            {
                using (BC_Product product = new BC_Product())
                {
                    _ActionResult = product.IncrementProductCounter(objProduct);
                    if (_ActionResult > 0)
                    {
                        this.KeepTrackOfHitCounter(objProduct);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        return _ActionResult > 0 ? true : false;
    }


    /// <summary>
    /// Checks if the products hitcounter field is already updated by checking the cookies.
    /// Returns true if already Updated, false otherwise
    /// </summary>
    /// <returns></returns>
    private bool IsAlreadyUpdated(CommonProduct objProduct)
    {
        bool _Result = false;
        HttpContext context = HttpContext.Current;

        string key = objProduct.CategoryID.ToString() + "." + objProduct.ProductSellerDetailID.ToString();
        string cookieKey = "";
        //object o = context.Request.Cookies["PRODUCT_COUNTER"];

        //object ob = context.Request.Cookies["PRODUCT_COUNTER"][key];

        if (context.Request.Cookies[key] != null && context.Request.Cookies[key][key] != null)
        {
            cookieKey = context.Request.Cookies[key][key].ToString();
            if (key == cookieKey)
            {
                _Result = true;
            }
        }
        
        return _Result;
 
    }


    /// <summary>
    /// Generates a Cookie to keep information abuout a Product.
    /// </summary>
    /// <param name="objProduct"></param>
    private void KeepTrackOfHitCounter(CommonProduct objProduct)
    {
        HttpContext context = HttpContext.Current;
        string key = objProduct.CategoryID.ToString() + "." + objProduct.ProductSellerDetailID.ToString();


        context.Response.Cookies[key][key] = key;
        
        context.Response.Cookies[key].Expires = DateTime.Now.AddDays(_ProductCookiePersistDay);
    }
}
