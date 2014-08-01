using System;
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

public partial class _Default : System.Web.UI.Page 
{

    private string UserName
    {
        get
        {
            object obj = ViewState["UserName"];
            if (obj != null)
            {
                return obj.ToString();
            }
            return "";
        }

        set { ViewState["UserName"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!Page.IsPostBack)
        {
            this.LoadLeftPannelDiscountList();
            
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
            
        }
    }

    private void LoadLeftPannelDiscountList()
    {
        try
        {
            DiscountManegar manager = new DiscountManegar();
            DataTable dt = new DataTable();
            dt = manager.LoadDiscountListLeftPannel();
            if (dt.Rows.Count > 0)
            {
                grvListDiscountLeftpannel.DataSource = dt;
                grvListDiscountLeftpannel.DataBind();
            }
            else
            {
                grvListDiscountLeftpannel.DataSource = null;
                grvListDiscountLeftpannel.DataBind();
            }
        }
        catch (Exception ex)
        {
            
        }
    }

    protected void grvListDiscountLeftpannel_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{

        //    DataRowView _RowView = (DataRowView)e.Row.DataItem;

        //    string _ProfileID = _RowView.Row["ProfileID"].ToString();
        //    string _CouponID = _RowView.Row["CouponID"].ToString();
        //    string _UseBoromelaCoupon = _RowView.Row["1UseBoromelaCoupon"].ToString();
        //    string _CouponTitle = _RowView.Row["CouponTitle"].ToString();
        //    string _DiscountCouponURL = _RowView.Row["DiscountCouponURL"].ToString();

        //    PlaceHolder ph = (PlaceHolder)e.Row.FindControl("phCouponLink");
        //    Label lblCouponLink = new Label();

        //    if (_UseBoromelaCoupon == "1")
        //    {
        //        lblCouponLink.Text += "<div style=\"height:auto;\"><span class=\"title\" style=\"font-size:11px;font-family: Verdana\"><img src=\"images/Bullet-home.png\" width=\"8px\" height=\"8px\" alt=\"\" />&nbsp;<a style='' href='PrintedCoupons.aspx?PI=" + _ProfileID + "&CI=" + _CouponID + "' class=\"onHoverRedLink\">" + _CouponTitle + "</a></div></span>";
        //    }
        //    else if (_UseBoromelaCoupon == "2")
        //    {
        //        lblCouponLink.Text += "<div style=\"height:auto;\"><span class=\"title\" style=\"font-size:11px;font-family: Verdana\"><a style='' href='PrintedCouponsw.aspx?PI=" + _ProfileID + "&CI=" + _CouponID + "' class=\"onHoverRedLink\">" + _CouponTitle + "</a></div></span>";
        //    }
        //    else if (_UseBoromelaCoupon == "3")
        //    {
        //        lblCouponLink.Text += "<div style=\"height:auto;\"><span class=\"title\" style=\"font-size:11px;font-family: Verdana\"><a style='' href='DiscountLinkCounter.aspx?PI=" + _ProfileID + "&CI=" + _CouponID + "&URL=" + Server.UrlEncode(_DiscountCouponURL) + "' target=\"blank\" + class=\"onHoverRedLink\">" + _CouponTitle + "</a></div></span>";
        //    }

        //    ph.Controls.Add(lblCouponLink);
        //}

    }


    private int AddEmailAdress()
    {
        int intActionResult = 0;
        try
        {
            DiscountZone discountZone = new DiscountZone();
            DiscountManegar manager = new DiscountManegar();
            
            intActionResult = manager.AdSubcriptionEmailAddress(discountZone);

        }
        catch (Exception ex)
        {
           
        }
        return intActionResult;

    }

    /// <summary>
    /// Display jquery based message
    /// </summary>
    /// <param name="pstrMsg">Message to be displayed</param>
    protected void DisplayMessage(string pstrMsg)
    {
        string prompt = "<script>$(document).ready(function(){{$.prompt('{0}',{{prefix:'cleanblue'}});}});</script>";
        string message = string.Format(prompt, pstrMsg);
        ClientScript.RegisterStartupScript(typeof(Page), "message", message);
    }



    private int IsLoginValid(string _LoginEmail, string _LoginPassword)
    {
        int _ActionResult = 0;
        string _Message = "";
        Authentication auth = new Authentication();
        EOC_PropertyBean bean = new EOC_PropertyBean();
        bean.LoginEmail = _LoginEmail;
        bean.Password = _LoginPassword;

        EOC_PropertyBean userCredentials = auth.GetUserLoginCredential(bean);

        _Message = userCredentials.Message;
        //lblSystemMessage.Text = _Message;
        if (_Message == "Success")
        {
            
        }
        else
        {
            DisplayMessage(auth.IsUserValid(bean));
        }

        return _ActionResult;
    }

    public string ImagePathCorporate
    {
        get
        {
            object obj = ViewState["ImagePathCorporate"];
            if (obj != null)
            {
                return obj.ToString();
            }
            return "";
        }
        set
        {
            ViewState["ImagePathCorporate"] = value;
        }
    }

}
