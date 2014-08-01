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

public partial class UserControl_SearchCtrlDiscountInner : System.Web.UI.UserControl
{
    private string _Country;
    private string _Keyword;
    public string Keyword
    {
        get { return _Keyword; }
        set { _Keyword = value; }
    }
    public string Country
    {
        get { return _Country; }
        set { _Country = value; }
    }
    protected void btnSearchProduct_Click(object sender, EventArgs e)
    {
        if (site_search.Text.ToString() != "")
        {
            if (Page.IsPostBack)
            {
                Response.Redirect("../SearchResultDiscount.aspx?Key=" + UTLUtilities.Encrypt(site_search.Text.ToString())
                    + "&Loc=" + UTLUtilities.Encrypt("Bangladesh"), true);
            }
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
}
