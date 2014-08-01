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

public partial class PrintedCoupons : System.Web.UI.Page
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


    public string Address
    {
        get
        {
            object obj = ViewState["Address"];
            if (obj != null)
            {
                return obj.ToString();
            }
            return "";
        }
        set
        {
            ViewState["Address"] = value;
        }
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


    private void CheckQueryString()
    {
        try
        {
            object objPFI = Request.QueryString["PI"];
            object objCI = Request.QueryString["CI"];
            if (objPFI != null && objCI != null)
            {
                CouponID = Convert.ToInt32(objCI);
                ProfileID = Convert.ToInt32(objPFI);
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

    protected void Page_Load(object sender, EventArgs e)
    {
        this.CheckQueryString();
        if (!Page.IsPostBack)
        {
            this.Load_CouponPrintingInformation(ProfileID, CouponID);
            this.IncrementDiscountCounter(ProfileID, CouponID);
        }
    }

    private void Display_RecordNotFound_ErrorPage()
    {
        string strErrorMessage = UTLUtilities.Encrypt("Your requested item has not found. It may have been blocked by the user or by the administrator.");
        Response.Redirect("Error.aspx?data=" + strErrorMessage);
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

    private void Load_CouponPrintingInformation(int profileID, int CouponID)
    {
        try
        {
            DiscountManegar manager = new DiscountManegar();
            DataTable dt = new DataTable();
            DiscountZone objDiscountZone = new DiscountZone();
            objDiscountZone.ProfileID = ProfileID;
            objDiscountZone.CouponID = CouponID;
            dt = manager.Load_CouponPrintingInformation(objDiscountZone);
            if (dt.Rows.Count > 0)
            {
                fvPrientCoupon.DataSource = dt;
                fvPrientCoupon.DataBind();
                Address = dt.Rows[0]["BusinessAddress"].ToString();
            }
            else
            {
                this.Display_RecordNotFound_ErrorPage();
            }
        }
        catch (Exception ex)
        {
            lblSystemMessage.Text = ex.Message;
        }
    }
}
