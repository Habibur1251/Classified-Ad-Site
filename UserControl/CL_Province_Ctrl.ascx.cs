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

public partial class UserControl_CL_Province_Ctrl : System.Web.UI.UserControl
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


    public delegate void ProvinceClicked(object sender, MenuEventArgs args);
    public event ProvinceClicked LinkClicked; 

    /// <summary>
    /// Loads all Province with Number of Posted Classified items Posted For Specific Classified Category.
    /// </summary>
    private void LoadList_CL_Items_ByProvince(int intCategoryID)
    {
        try
        {
            using (BC_Classifieds_Item bcClassifiedItems = new BC_Classifieds_Item())
            {
                DataTable dtClassified = bcClassifiedItems.LoadList_CL_Items_ByProvince(intCategoryID);
                if (dtClassified.Rows.Count > 0)
                {
                    dlstProvince.DataSource = dtClassified;
                    dlstProvince.DataBind();
                }
                else
                {
                    dlstProvince.DataSource = null;
                    dlstProvince.DataBind();
                    this.Visible = false;
                }
            }
        }
        catch (Exception Exp)
        {

            Response.Write(Exp.Message.ToString());
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        this.LoadList_CL_Items_ByProvince(CategoryID);
    }
    protected void dlstProvince_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (LinkClicked != null)
        {
            MenuEventArgs mnuEvent = new MenuEventArgs();
            mnuEvent.CategoryID = CategoryID.ToString();
            mnuEvent.ProvinceID = e.CommandArgument.ToString();
            this.LinkClicked(this, mnuEvent);
        }
    }
}
