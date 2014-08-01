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

public partial class UserControl_FeaturedStoresInDiscountZone : System.Web.UI.UserControl
{
    private bool _IsInRoot;

    public bool IsInRoot
    {
        get { return _IsInRoot; }
        set { _IsInRoot = value; }
    }
    public string RootURL
    {
        get
        {
            return IsInRoot ? "" : "../";
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Load_RightPanelFeaturedStores();
    }
    private void Load_RightPanelFeaturedStores()
    {

        try
        {
            DiscountManegar manager = new DiscountManegar();
            DataTable dt = new DataTable();
            dt = manager.Load_RightPanelFeaturedStores();
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
}
