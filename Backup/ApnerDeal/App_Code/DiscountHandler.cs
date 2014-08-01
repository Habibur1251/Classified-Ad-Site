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
/// Summary description for DiscountHandler
/// </summary>
public class DiscountHandler
{
    int _ProductCookiePersistDay = 1;
	public DiscountHandler()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    /// <summary>
    /// Increments a productsReview HitCounterField.
    /// </summary>
    /// <param name="objProduct"></param>
    /// <returns></returns>
    public bool IncrementDiscountCounter(int _ProfileID, int _CouponID)
    {
        int _ActionResult = -1;

        if (!this.IsAlreadyUpdated(_ProfileID, _CouponID))
        {
            try
            {
                using (BC_DiscountZone bc = new BC_DiscountZone())
                {
                    _ActionResult = bc.IncrementDiscountCounter(_ProfileID, _CouponID);
                    if (_ActionResult > 0)
                    {
                        this.KeepTrackOfHitCounter(_ProfileID, _CouponID);
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
    /// Checks if the products Review hitcounter field is already updated by checking the cookies.
    /// Returns true if already Updated, false otherwise
    /// </summary>
    /// <returns></returns>
    private bool IsAlreadyUpdated(int _ProfileID, int _CouponID)
    {
        bool _Result = false;
        HttpContext context = HttpContext.Current;

        string key = _ProfileID.ToString() + "." + _CouponID.ToString();
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
    /// Generates a Cookie to keep information abuout a Discount.
    /// </summary>
    /// <param name="objProduct"></param>
    private void KeepTrackOfHitCounter(int _ProfileID, int _CouponID)
    {
        HttpContext context = HttpContext.Current;
        string key = _ProfileID.ToString() + "." + _CouponID.ToString();


        context.Response.Cookies[key][key] = key;

        context.Response.Cookies[key].Expires = DateTime.Now.AddDays(_ProductCookiePersistDay);
    }

}
