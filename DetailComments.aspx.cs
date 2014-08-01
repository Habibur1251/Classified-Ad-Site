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

public partial class DetailComments : System.Web.UI.Page
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
            this.Load_DiscountInformation(ProfileID, CouponID);
        }
    }

    private void Load_DiscountInformation(int ProfileID, int CouponID)
    {
        try
        {
            DiscountManegar manager = new DiscountManegar();
            DataTable dt = new DataTable();
            DiscountZone objDiscountZone = new DiscountZone();
            objDiscountZone.ProfileID = ProfileID;
            objDiscountZone.CouponID = CouponID;
            dt = manager.Load_DiscountInformation(objDiscountZone);
            if (dt.Rows.Count > 0)
            {
                grvListDiscountLeftpannel.DataSource = dt;
                grvListDiscountLeftpannel.DataBind();
                this.LoadListComments(CouponID);
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

    private void LoadListComments(int _CouponID)
    {
        DiscountManegar manager = new DiscountManegar();
        DataTable dt = new DataTable();
        DiscountZone objDiscountZone = new DiscountZone();
        objDiscountZone.CouponID = CouponID;
        dt = manager.Load_ListComments(objDiscountZone);
        if (dt.Rows.Count > 0)
        {
            grvComments.DataSource = dt;
            grvComments.DataBind();
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
            string _PrintedCouponNeed = _RowView.Row["PrintedCouponNeed"].ToString();
            string _CouponType = _RowView.Row["CouponType"].ToString();
            string _DiscountCouponURL = _RowView.Row["DiscountCouponURL"].ToString();
            string _CouponTitle = _RowView.Row["CouponTitle"].ToString();
            string _CompanyName = _RowView.Row["CompanyName"].ToString();
            string _StartDate = _RowView.Row["CouponEffectiveDate"].ToString();
            string _EndDate = _RowView.Row["CouponExpirydate"].ToString();
            string _CouponDescription = _RowView.Row["CouponDescription"].ToString();

            PlaceHolder ph = (PlaceHolder)e.Row.FindControl("phCouponLink");
            Label lblCouponLink = new Label();
            if (_PrintedCouponNeed == "True")
            {
                if (_UseBoromelaCoupon == "1")
                {
                    lblCouponLink.Text = "<span class=\"mediumfont\" style=\"font-family:Verdana; font-size:11px;\">" + _CompanyName + "</span>";
                    lblCouponLink.Text += "<br/><br/>";
                    lblCouponLink.Text += "<div style=\"height:auto;\"><span class=\"title\" style=\"font-size:11px;font-family: Verdana\"><a style='' href='PrintedCoupons.aspx?PI=" + _ProfileID + "&CI=" + _CouponID + "' class=\"onHoverRedLink\">" + _CouponTitle + "</a></div></span>";
                    lblCouponLink.Text += "<br/><br/>";
                    lblCouponLink.Text += "<span class=\"mediumfont\" style=\"font-family:Verdana; font-size:11px;color:#990066 \">" + "*This Coupon Starts On: " + _StartDate + "</span>";
                    lblCouponLink.Text += "<br/><br/>";
                    lblCouponLink.Text += "<span class=\"mediumfont\" style=\"font-family:Verdana; font-size:11px;color:#cc0066\">" + "*This Coupon Expires: " + _EndDate + "</span>";
                    lblCouponLink.Text += "<br/><br/>";

                    lblCouponLink.Text += "<div align=\"justify\" style=\"height:auto;\"><span class=\"\" style=\"font-family:Verdana; font-size:11px;\">" + _CouponDescription + "</div></span>";
                    lblCouponLink.Text += "<br/><br/>";
                    lblCouponLink.Text += "<span style=\"font-family:Verdana; font-size:11px; font-weight:bold; color:#000000\">" + " To use this coupon " + _CouponType + " " + "you will need to" + " " + "</span>";
                    lblCouponLink.Text += "<br/><br/>";
                    lblCouponLink.Text += "<div style=\"height:15px;\"><span style=\"font-size: 8pt;font-weight:bold; font-family: Verdana\"><img src=\"../images/Bullet-home.png\" width=\"6px\" height=\"6px\" alt=\"\" />&nbsp;<a style='' href='PrintedCoupons.aspx?PI=" + _ProfileID + "&CI=" + _CouponID + "' class=\"onHoverRedLink colortitle\">" + "Print this coupon" + "</a></div></span>";
                }
                else if (_UseBoromelaCoupon == "2")
                {
                    lblCouponLink.Text = "<span class=\"mediumfont\" style=\"font-family:Verdana; font-size:11px;\">" + _CompanyName + "</span>";
                    lblCouponLink.Text += "<br/><br/>";
                    lblCouponLink.Text += "<div style=\"height:auto;\"><span class=\"title\" style=\"font-size:11px;font-family: Verdana\"><a style='' href='PrintedCouponsw.aspx?PI=" + _ProfileID + "&CI=" + _CouponID + "' class=\"onHoverRedLink\">" + _CouponTitle + "</a></div></span>";
                    lblCouponLink.Text += "<br/><br/>";
                    lblCouponLink.Text += "<span class=\"mediumfont\" style=\"font-family:Verdana; font-size:11px;color:#990066 \">" + "*This Coupon Starts On: " + _StartDate + "</span>";
                    lblCouponLink.Text += "<br/><br/>";
                    lblCouponLink.Text += "<span class=\"mediumfont\" style=\"font-family:Verdana; font-size:11px;color:#cc0066\">" + "*This Coupon Expires: " + _EndDate + "</span>";
                    lblCouponLink.Text += "<br/><br/>";

                    lblCouponLink.Text += "<div align=\"justify\" style=\"height:auto;\"><span class=\"\" style=\"font-family:Verdana; font-size:11px;\">" + _CouponDescription + "</div></span>";
                    lblCouponLink.Text += "<br/>";
                    lblCouponLink.Text += "<span style=\"font-family:Verdana; font-size:11px; font-weight:bold; color:#000000\">" + " To use this coupon " + _CouponType + " " + "you will need to" + " " + "</span>";
                    lblCouponLink.Text += "<br/>";
                    lblCouponLink.Text += "<div style=\"height:15px;\"><span style=\"font-size: 8pt;font-weight:bold;  font-family: Verdana\"><img src=\"../images/Bullet-home.png\" width=\"6px\" height=\"6px\" alt=\"\" />&nbsp;<a style='' href='PrintedCouponsw.aspx?PI=" + _ProfileID + "&CI=" + _CouponID + "' class=\"onHoverRedLink colortitle\">" + "Print this coupon" + "</a></div></span>";
                }
                else if (_UseBoromelaCoupon == "3")
                {
                    lblCouponLink.Text = "<span class=\"mediumfont\" style=\"font-family:Verdana; font-size:11px;\">" + _CompanyName + "</span>";
                    lblCouponLink.Text += "<br/><br/>";
                    lblCouponLink.Text += "<div style=\"height:auto;\"><span class=\"title\" style=\"font-size:11px;font-family: Verdana\"><a style='' href='" + _DiscountCouponURL + "' target=\"blank\" + class=\"onHoverRedLink\">" + _CouponTitle + "</a></div></span>";
                    lblCouponLink.Text += "<br/><br/>";
                    lblCouponLink.Text += "<span class=\"mediumfont\" style=\"font-family:Verdana; font-size:11px;color:#990066 \">" + "*This Coupon Starts On: " + _StartDate + "</span>";
                    lblCouponLink.Text += "<br/><br/>";
                    lblCouponLink.Text += "<span class=\"mediumfont\" style=\"font-family:Verdana; font-size:11px;color:#cc0066\">" + "*This Coupon Expires: " + _EndDate + "</span>";
                    lblCouponLink.Text += "<br/><br/>";

                    lblCouponLink.Text += "<div align=\"justify\" style=\"height:auto;\"><span class=\"\" style=\"font-family:Verdana; font-size:11px;\">" + _CouponDescription + "</div></span>";
                    lblCouponLink.Text += "<br/><br/>";
                    lblCouponLink.Text += "<span style=\"font-family:Verdana; font-size:11px; font-weight:bold; color:#000000\">" + " To use this coupon " + _CouponType + " " + "you will need to" + " " + "</span>";
                    lblCouponLink.Text += "<br/><br/>";
                    lblCouponLink.Text += "<div style=\"height:15px;\"><span style=\"font-size: 8pt;font-weight:bold;  font-family: Verdana\"><img src=\"../images/Bullet-home.png\" width=\"6px\" height=\"6px\" alt=\"\" />&nbsp;<a style='' href='" + _DiscountCouponURL + "'target=\"blank\" + class=\"onHoverRedLink colortitle\">" + "Print this coupon" + "</a></div></span>";
                }
                else
                {
                }
            }
            else if (_PrintedCouponNeed == "False")
            {
                if (_UseBoromelaCoupon == "1")
                {
                    lblCouponLink.Text = "<span class=\"mediumfont\" style=\"font-family:Verdana; font-size:11px;\">" + _CompanyName + "</span>";
                    lblCouponLink.Text += "<br/><br/>";
                    lblCouponLink.Text += "<div style=\"height:auto;\"><span class=\"title\" style=\"font-size:11px;font-family: Verdana\"><a style='' href='PrintedCoupons.aspx?PI=" + _ProfileID + "&CI=" + _CouponID + "' class=\"onHoverRedLink\">" + _CouponTitle + "</a></div></span>";
                    lblCouponLink.Text += "<br/><br/>";
                    lblCouponLink.Text += "<span class=\"mediumfont\" style=\"font-family:Verdana; font-size:11px;color:#990066 \">" + "*This Coupon Starts On: " + _StartDate + "</span>";
                    lblCouponLink.Text += "<br/><br/>";
                    lblCouponLink.Text += "<span class=\"mediumfont\" style=\"font-family:Verdana; font-size:11px;color:#cc0066\">" + "*This Coupon Expires: " + _EndDate + "</span>";
                    lblCouponLink.Text += "<br/><br/>";

                    lblCouponLink.Text += "<div align=\"justify\" style=\"height:auto;\"><span class=\"\" style=\"font-family:Verdana; font-size:11px;\">" + _CouponDescription + "</div></span>";
                    lblCouponLink.Text += "<br/><br/>";
                    lblCouponLink.Text += "<span style=\"font-family:Verdana; font-size:11px; font-weight:bold; color:#000000\">" + "Printing of coupon not required for this offer  " + " " + "</span>";
                    lblCouponLink.Text += "<br/><br/>";
                    lblCouponLink.Text += "<div style=\"height:15px;\"><span style=\"font-size: 8pt; font-weight:bold; font-family: Verdana\"><img src=\"../images/Bullet-home.png\" width=\"6px\" height=\"6px\" alt=\"\" />&nbsp;<a style='' href='PrintedCoupons.aspx?PI=" + _ProfileID + "&CI=" + _CouponID + "' class=\"onHoverRedLink colortitle\">" + "View Detail" + "</a></div></span>";
                }
                else if (_UseBoromelaCoupon == "2")
                {
                    lblCouponLink.Text = "<span class=\"mediumfont\" style=\"font-family:Verdana; font-size:11px;\">" + _CompanyName + "</span>";
                    lblCouponLink.Text += "<br/><br/>";
                    lblCouponLink.Text += "<div style=\"height:auto;\"><span class=\"title\" style=\"font-size:11px;font-family: Verdana\"><a style='' href='PrintedCouponsw.aspx?PI=" + _ProfileID + "&CI=" + _CouponID + "' class=\"onHoverRedLink\">" + _CouponTitle + "</a></div></span>";
                    lblCouponLink.Text += "<br/><br/>";
                    lblCouponLink.Text += "<span class=\"mediumfont\" style=\"font-family:Verdana; font-size:11px;color:#990066 \">" + "*This Coupon Starts On: " + _StartDate + "</span>";
                    lblCouponLink.Text += "<br/><br/>";
                    lblCouponLink.Text += "<span class=\"mediumfont\" style=\"font-family:Verdana; font-size:11px;color:#cc0066\">" + "*This Coupon Expires: " + _EndDate + "</span>";
                    lblCouponLink.Text += "<br/><br/>";

                    lblCouponLink.Text += "<div align=\"justify\" style=\"height:auto;\"><span class=\"\" style=\"font-family:Verdana; font-size:11px;\">" + _CouponDescription + "</div></span>";
                    lblCouponLink.Text += "<br/><br/>";
                    lblCouponLink.Text += "<span style=\"font-family:Verdana; font-size:11px; font-weight:bold; color:#000000\">" + "Printing of coupon not required for this offer  " + " " + "</span>";
                    lblCouponLink.Text += "<br/><br/>";
                    lblCouponLink.Text += "<div style=\"height:15px;\"><span style=\"font-size: 8pt; font-weight:bold; font-family: Verdana\"><img src=\"../images/Bullet-home.png\" width=\"6px\" height=\"6px\" alt=\"\" />&nbsp;<a style='' href='PrintedCouponsw.aspx?PI=" + _ProfileID + "&CI=" + _CouponID + "' class=\"onHoverRedLink colortitle\">" + "View Detail" + "</a></div></span>";
                }
                else if (_UseBoromelaCoupon == "3")
                {
                    lblCouponLink.Text = "<span class=\"mediumfont\" style=\"font-family:Verdana; font-size:11px;\">" + _CompanyName + "</span>";
                    lblCouponLink.Text += "<br/><br/>";
                    lblCouponLink.Text += "<div style=\"height:auto;\"><span class=\"title\" style=\"font-size:11px;font-family: Verdana\"><a style='' href='" + _DiscountCouponURL + "' target=\"blank\" + class=\"onHoverRedLink\">" + _CouponTitle + "</a></div></span>";
                    lblCouponLink.Text += "<br/><br/>";
                    lblCouponLink.Text += "<span class=\"mediumfont\" style=\"font-family:Verdana; font-size:11px;color:#990066 \">" + "*This Coupon Starts On: " + _StartDate + "</span>";
                    lblCouponLink.Text += "<br/><br/>";
                    lblCouponLink.Text += "<span class=\"mediumfont\" style=\"font-family:Verdana; font-size:11px;color:#cc0066\">" + "*This Coupon Expires: " + _EndDate + "</span>";
                    lblCouponLink.Text += "<br/><br/>";

                    lblCouponLink.Text += "<div align=\"justify\" style=\"height:auto;\"><span class=\"\" style=\"font-family:Verdana; font-size:11px;\">" + _CouponDescription + "</div></span>";
                    lblCouponLink.Text += "<br/><br/>";
                    lblCouponLink.Text += "<span style=\"font-family:Verdana; font-size:11px; font-weight:bold; color:#000000\">" + "Printing of coupon not required for this offer  " + " " + "</span>";
                    lblCouponLink.Text += "<br/><br/>";
                    lblCouponLink.Text += "<div style=\"height:15px;\"><span style=\"font-size: 8pt; font-weight:bold; font-family: Verdana\"><img src=\"../images/Bullet-home.png\" width=\"6px\" height=\"6px\" alt=\"\" />&nbsp;<a style='' href='" + _DiscountCouponURL + "'target=\"blank\" + class=\"onHoverRedLink colortitle\">" + "View Detail" + "</a></div></span>";
                }
            }
            else
            {

            }
            ph.Controls.Add(lblCouponLink);
        }
    }

    protected void grvListDiscountLeftpannel_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void Display_RecordNotFound_ErrorPage()
    {
        string strErrorMessage = UTLUtilities.Encrypt("Your requested item has not found. It may have been blocked by the user or by the administrator.");
        Response.Redirect("Error.aspx?data=" + strErrorMessage);
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
}
