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

public partial class UserControl_CL_Area_Ctrl : System.Web.UI.UserControl
{

    public int CategoryID
    {
        get
        {
            object obj = ViewState["CategoryID"];
            if (obj != null)
            {
                return (int)obj;
            }
            return 0;
        }
        set
        {
            ViewState["CategoryID"] = value;
        }
    }

    public delegate void AreaClicked(object sender, MenuEventArgs args);
    public event AreaClicked LinkClicked;


    /// <summary>
    /// Loads all Area with Number of Posted Classified items Posted For Specific Classified Category.
    /// </summary>
    /// <param name="intCategoryID"></param>
    private void LoadList_CL_Items_ByArea(int intCategoryID)
    {
        try
        {
            using (BC_Classifieds_Item bcClassifiedItems = new BC_Classifieds_Item())
            {
                DataTable dtClassified = bcClassifiedItems.LoadList_CL_Items_ByArea(intCategoryID);
                if (dtClassified.Rows.Count > 0)
                {
                    dlstArea.DataSource = dtClassified;
                    dlstArea.DataBind();
                }
                else
                {
                    dlstArea.DataSource = null;
                    dlstArea.DataBind();
                    this.Visible = false;
                }
            }
        }
        catch (Exception Exp)
        {

            Response.Write(Exp.Message.ToString());
        }
    }



    protected void Page_PreRender(object sender, EventArgs args)
    {
        if (!Page.IsPostBack)
        {
            this.LoadList_CL_Items_ByArea(CategoryID);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void dlstArea_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (LinkClicked != null)
        {
            MenuEventArgs mnuEvent = new MenuEventArgs();
            mnuEvent.CategoryID = CategoryID.ToString();
            mnuEvent.AreaID = e.CommandArgument.ToString();
            this.LinkClicked(this, mnuEvent);
            
        }
    }
}
