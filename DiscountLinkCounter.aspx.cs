using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class DiscountLinkCounter : System.Web.UI.Page
{
    public int ProfileID
    {
        get
        {
            object obj = ViewState["ProfileID"];
            if (obj != null)
            {
                return (int)obj;
            }
            return 0;
        }
        set { ViewState["ProfileID"] = value; }

    }

    public string URL
    {
        get
        {
            object obj = ViewState["URL"];
            if (obj != null)
            {
                return obj.ToString();
            }
            return "";
        }
        set { ViewState["URL"] = value; }

    }


    public int CouponID
    {
        get
        {
            object obj = ViewState["CouponID"];
            if (obj != null)
            {
                return (int)obj;
            }
            return 0;
        }
        set { ViewState["CouponID"] = value; }

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        this.CheckQueryString();
        if (!Page.IsPostBack)
        {
            this.IncrementDiscountCounter(ProfileID, CouponID);
            Response.Redirect(URL);
        }
    }
    private void CheckQueryString()
    {
        try
        {
            object objPFI = Request.QueryString["PI"];
            object objCI = Request.QueryString["CI"];
            object objURL = Request.QueryString["URL"];
            if (objPFI != null && objCI != null && objURL != null)
            {
                CouponID = Convert.ToInt32(objCI);
                ProfileID = Convert.ToInt32(objPFI);
                URL = Server.UrlDecode(objURL.ToString());
            }
            else
            {
                string data = UTLUtilities.Encrypt("Parameter missing");
                Server.Transfer("Error.aspx?data=" + data, false);
            }
        }
        catch (Exception ex)
        {
            lblSystemMessage.Text = ex.Message;
        }

    }

    private void IncrementDiscountCounter(int _ProfileID, int _CouponID)
    {
        try
        {
            DiscountHandler handler = new DiscountHandler();
            handler.IncrementDiscountCounter(_ProfileID, _CouponID);

        }
        catch (Exception ex)
        {
            lblSystemMessage.Text = ex.Message;
        }
    }

}
