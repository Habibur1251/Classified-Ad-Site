using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class UserControl_Display_Filter_Ctrl : System.Web.UI.UserControl
{
    //private string _Filter_Name;

    //public string Filter_Name
    //{
    //    get { return _Filter_Name; }
    //    set { _Filter_Name = value; }
    //}


    public string Filter_Name
    {
        get {
            if (ViewState["Filter_Name"] != null)
            {
                return ViewState["Filter_Name"].ToString();
            }
            return "";
            }
        set 
        {
            ViewState["Filter_Name"] = value;
        }
    }
	


    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        if (Filter_Name != "")
        {
            lblDisplayFilter.Text = "<strong>Search by:</strong><span class=\"price\"> " + Filter_Name + "</span><br/>";
        }
    }
}
