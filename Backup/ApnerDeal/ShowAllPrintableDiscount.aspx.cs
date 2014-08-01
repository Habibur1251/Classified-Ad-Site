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

public partial class ShowAllPrintableDiscount : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.LoadAllPrintableDiscount();
        }
    }
    protected int Total_Record
    {
        get
        {
            object obj = ViewState["Total_Record"];
            if (obj != null)
            {
                return (int)obj;
            }
            return 0;
        }
        set { ViewState["Total_Record"] = value; }
    }

    private void LoadAllPrintableDiscount()
    {
        try
        {
            DiscountManegar manager = new DiscountManegar();
            DataTable dt = new DataTable();
            dt = manager.LoadAllPrintableDiscount();
            if (dt.Rows.Count > 0)
            {
                grvListDiscountLeftpannel.DataSource = dt;
                grvListDiscountLeftpannel.DataBind();
                Total_Record = dt.Rows.Count;
            }
            else
            {
                grvListDiscountLeftpannel.DataSource = null;
                grvListDiscountLeftpannel.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblSystemMessage.Text = ex.Message;
        }
    }
    protected void grvListDiscountLeftpannel_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grvListDiscountLeftpannel.PageIndex = e.NewPageIndex;
            this.LoadAllPrintableDiscount();
        }
        catch (Exception Exp)
        {
            lblSystemMessage.Text = Exp.Message.ToString();
        }

    }

    protected void grvListDiscountLeftpannel_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            DataRowView _RowView = (DataRowView)e.Row.DataItem;

            string _ProfileID = _RowView.Row["ProfileID"].ToString();
            string _CouponID = _RowView.Row["CouponID"].ToString();
            string _UseBoromelaCoupon = _RowView.Row["UseBoromelaCoupon"].ToString();
            string _CouponTitle = _RowView.Row["CouponTitle"].ToString();
            string _DiscountCouponURL = _RowView.Row["DiscountCouponURL"].ToString();

            PlaceHolder ph = (PlaceHolder)e.Row.FindControl("phCouponLink");
            Label lblCouponLink = new Label();

            if (_UseBoromelaCoupon == "1")
            {
                lblCouponLink.Text += "<div style=\"height:auto;\"><span class=\"title\" style=\"font-size:11px;font-family: Verdana\"><img src=\"../images/Bullet-home.png\" width=\"8px\" height=\"8px\" alt=\"\" />&nbsp;<a style='' href='PrintedCoupons.aspx?PI=" + _ProfileID + "&CI=" + _CouponID + "' class=\"onHoverRedLink\">" + _CouponTitle + "</a></div></span>";
            }
            else if (_UseBoromelaCoupon == "2")
            {
                lblCouponLink.Text += "<div style=\"height:auto;\"><span class=\"title\" style=\"font-size:11px;font-family: Verdana\"><img src=\"../images/Bullet-home.png\" width=\"8px\" height=\"8px\" alt=\"\" />&nbsp;<a style='' href='PrintedCouponsw.aspx?PI=" + _ProfileID + "&CI=" + _CouponID + "' class=\"onHoverRedLink\">" + _CouponTitle + "</a></div></span>";
            }
            else if (_UseBoromelaCoupon == "3")
            {
                lblCouponLink.Text += "<div style=\"height:auto;\"><span class=\"title\" style=\"font-size:11px;font-family: Verdana\"><img src=\"../images/Bullet-home.png\" width=\"8px\" height=\"8px\" alt=\"\" />&nbsp;<a style='' href='PrintedCoupons.aspx?PI=" + _ProfileID + "&CI=" + _CouponID + "' target=\"blank\" + class=\"onHoverRedLink\">" + _CouponTitle + "</a></div></span>";
            }

            ph.Controls.Add(lblCouponLink);
        }
    }
}
