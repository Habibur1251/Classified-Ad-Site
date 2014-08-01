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

public partial class UserControl_HP_LatestDiscount : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.LoadTopTen_Discount();
    }
    private void LoadTopTen_Discount()
    {
        try
        {
            DiscountManegar manager = new DiscountManegar();
            DataTable dt = new DataTable();

            dt = manager.LoadListRecentDiscountHomePage();
            if (dt.Rows.Count > 0)
            {
                grvTopFiveDiscount.DataSource = dt;
                grvTopFiveDiscount.DataBind();
            }
            else
            {
                grvTopFiveDiscount.DataSource = null;
                grvTopFiveDiscount.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblSystemMessage.Text = ex.Message;
        }
    }

    protected void grvTopFiveDiscount_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            DataRowView _RowView = (DataRowView)e.Row.DataItem;

            string _ProfileID = _RowView.Row["ProfileID"].ToString();
            string _CouponID = _RowView.Row["CouponID"].ToString();
            string _UseBoromelaCoupon = _RowView.Row["UseBoromelaCoupon"].ToString();
            string _CouponTitle = _RowView.Row["CouponTitle"].ToString();
            string _DiscountCouponURL = _RowView.Row["DiscountCouponURL"].ToString();
            string _CompanyName = _RowView.Row["CompanyName"].ToString();

            PlaceHolder ph = (PlaceHolder)e.Row.FindControl("phCouponLink");
            Label lblCouponLink = new Label();

            if (_UseBoromelaCoupon == "1")
            {
                lblCouponLink.Text += "<div style=\"height:auto;\"><span style=\"font-size:10px;font-family: Verdana\"><img src=\"images/Bullet-home.png\" width=\"5px\" height=\"5px\" alt=\"\" />&nbsp;<a style='' href='PrintedCoupons.aspx?PI=" + _ProfileID + "&CI=" + _CouponID + "'target=\"blank\" + class=\"onHoverRedLink onHoverBlue\">" + _CouponTitle + "</a></div></span>";
                lblCouponLink.Text += "<span class=\"colortitle\" style=\"font-family:Verdana; font-size:10px;\">" + _CompanyName + " " + "</span>";
            }
            else if (_UseBoromelaCoupon == "2")
            {
                lblCouponLink.Text += "<div style=\"height:auto;\"><span style=\"font-size:10px;font-family: Verdana\"><img src=\"images/Bullet-home.png\" width=\"5px\" height=\"5px\" alt=\"\" />&nbsp;<a style='' href='PrintedCouponsw.aspx?PI=" + _ProfileID + "&CI=" + _CouponID + "' target=\"blank\" + class=\"onHoverRedLink onHoverBlue\">" + _CouponTitle + "</a></div></span>";
                lblCouponLink.Text += "<span class=\"colortitle\" style=\"font-family:Verdana; font-size:10px;\">" + _CompanyName + " " + "</span>";
            }
            else if (_UseBoromelaCoupon == "3")
            {
                lblCouponLink.Text += "<div style=\"height:auto;\"><span style=\"font-size:10px;font-family: Verdana\"><img src=\"images/Bullet-home.png\" width=\"5px\" height=\"5px\" alt=\"\" />&nbsp;<a style='' href='DiscountLinkCounter.aspx?PI=" + _ProfileID + "&CI=" + _CouponID + "&URL=" + Server.UrlEncode(_DiscountCouponURL) + "'target=\"blank\" + class=\"onHoverRedLink onHoverBlue\">" + _CouponTitle + "</a></div></span>";
                lblCouponLink.Text += "<span class=\"colortitle\" style=\"font-family:Verdana; font-size:10px;\">" + _CompanyName + " " + "</span>";

            }

            ph.Controls.Add(lblCouponLink);
        }

    }

}
