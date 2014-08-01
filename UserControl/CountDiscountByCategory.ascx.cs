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

public partial class UserControl_CountDiscountByCategory : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.Load_RightPanelPopularCouponAndDealCategoriesCount();
        }
    }

    private string _Category;

    public string Category
    {
        get { return _Category; }
        set { _Category = value; }
    }


    private string _Discount;

    public string Discount
    {
        get { return _Discount; }
        set { _Discount = value; }
    }

    private void Load_RightPanelPopularCouponAndDealCategoriesCount()
    {

        try
        {
            DiscountManegar manager = new DiscountManegar();
            DataTable dt = new DataTable();
            dt = manager.Load_RightPanelPopularCouponAndDealCategoriesCount();
            if (dt.Rows.Count > 0)
            {
                dlist.DataSource = dt;
                dlist.DataBind();
            }
            else
            {
                dlist.DataSource = null;
                dlist.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblSystemMessage.Text = ex.Message;
        }
    }

    protected void dlstCountCategory_OnItemDataBound(object sender, DataListItemEventArgs e)
    {
        //if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        //{
        //    System.Data.DataRowView drv = (System.Data.DataRowView)(e.Item.DataItem);
        //    string CategoryID = drv.Row["CategoryID"].ToString();
        //    string Category = drv.Row["Category"].ToString();
        //    Category = drv.Row["Category"].ToString();
        //    Discount = drv.Row["NoOfDiscountWithSubcategory"].ToString();
        //    PlaceHolder ph = (PlaceHolder)e.Item.FindControl("phPrice");
        //    Literal lit = new Literal();
        //    lit.Text += "<div style=\"height:15px;\"><span style=\"font-size: 7pt; font-family: Verdana\"><img src=\"../images/Bullet-home.png\" width=\"6px\" height=\"6px\" alt=\"\" />&nbsp;<a style='' href='DiscountList.aspx?mode=" + 1 + "&CI=" + CategoryID + "&CA=Category' class=\"onHoverBlue\">" + Category + "(" + Discount + ")</a></div></span>";
        //    ph.Controls.Add(lit);
        //}
    }
}
