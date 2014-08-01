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

public partial class UserControl_DZ_TOPFive_ViewedDiscount : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.LoadTopFive_Discount();
        if (!Page.IsPostBack)
        {
            this.LoadTopFive_Discount();
        }
    }
    private void LoadTopFive_Discount()
    {
        try
        {
            DiscountManegar manager = new DiscountManegar();
            DataTable dt = new DataTable();

            dt = manager.LoadList_DZ_Top5_Discount();
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

            PlaceHolder ph = (PlaceHolder)e.Row.FindControl("phCouponLink");
            Label lblCouponLink = new Label();

            if (_UseBoromelaCoupon == "1")
            {
                lblCouponLink.Text += "<div style=\"height:auto;\"><span style=\"font-size:10px;font-family: Verdana\"><a style='' href='PrintedCoupons.aspx?PI=" + _ProfileID + "&CI=" + _CouponID + "'target=\"blank\" + class=\"onHoverRedLink onHoverBlue\">" + _CouponTitle + "</a></div></span>";
            }
            else if (_UseBoromelaCoupon == "2")
            {
                lblCouponLink.Text += "<div style=\"height:auto;\"><span style=\"font-size:10px;font-family: Verdana\"><a style='' href='PrintedCouponsw.aspx?PI=" + _ProfileID + "&CI=" + _CouponID + "'target=\"blank\" + class=\"onHoverRedLink onHoverBlue\">" + _CouponTitle + "</a></div></span>";
            }
            else if (_UseBoromelaCoupon == "3")
            {
                lblCouponLink.Text += "<div style=\"height:auto;\"><span style=\"font-size:10px;font-family: Verdana\"><a style='' href='DiscountLinkCounter.aspx?PI=" + _ProfileID + "&CI=" + _CouponID + "&URL=" + _DiscountCouponURL + "'target=\"blank\" + class=\"onHoverRedLink onHoverBlue\">" + _CouponTitle + "</a></div></span>";
            }

            ph.Controls.Add(lblCouponLink);
        }


    }
}
