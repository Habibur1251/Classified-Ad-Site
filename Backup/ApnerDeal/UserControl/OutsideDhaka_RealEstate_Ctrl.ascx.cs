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

public partial class UserControl_OutsideDhaka_RealEstate_Ctrl : System.Web.UI.UserControl
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
    private int _SubcategoryID;

    public int SubcategoryID
    {
        get { return _SubcategoryID; }
        set { _SubcategoryID = value; }
    }



    public delegate void ProvinceClicked(object sender, MenuEventArgs args);
    public event ProvinceClicked LinkClicked;

    /// <summary>
    /// Loads all Province with Number of Posted Classified items Posted For Specific Classified Category.
    /// </summary>
    private void LoadList_CL_Items_ByProvince(int intCategoryID, int intSubcategoryID)
    {
        try
        {
            using (BC_RealEstate bcItems = new BC_RealEstate())
            {
                DataTable dtClassified = bcItems.LoadList_CL_Items_ByProvince(intCategoryID, intSubcategoryID);
                if (dtClassified.Rows.Count > 0)
                {
                    repProvince.DataSource = dtClassified;
                    repProvince.DataBind();
                }
                else
                {
                    repProvince.DataSource = null;
                    repProvince.DataBind();
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
        this.LoadList_CL_Items_ByProvince(CategoryID,SubcategoryID);
    }

    protected void repProvince_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (LinkClicked != null)
        {
            MenuEventArgs mnuEvent = new MenuEventArgs();
            mnuEvent.CategoryID = CategoryID.ToString();
            mnuEvent.SubcategoryID = SubcategoryID.ToString();
            mnuEvent.ProvinceID = e.CommandArgument.ToString();
            this.LinkClicked(this, mnuEvent);
        }
    }
}
