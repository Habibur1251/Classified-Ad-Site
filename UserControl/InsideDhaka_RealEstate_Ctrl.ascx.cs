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

public partial class UserControl_InsideDhaka_RealEstate_Ctrl : System.Web.UI.UserControl
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


    public delegate void AreaClicked(object sender, MenuEventArgs args);
    public event AreaClicked LinkClicked;


    /// <summary>
    /// Loads all Area with Number of Posted Classified items Posted For Specific Classified Category.
    /// </summary>
    /// <param name="intCategoryID"></param>
    private void LoadList_CL_Items_ByArea(int intCategoryID, int intSubCategoryID)
    {
        try
        {
            using (BC_RealEstate bcRealEstate = new BC_RealEstate())
            {
                DataTable dtClassified = bcRealEstate.LoadList_CL_Items_ByArea(intCategoryID, intSubCategoryID);
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



    protected void Page_PreRender(object sender, EventArgs args)
    {
        this.LoadList_CL_Items_ByArea(CategoryID, SubcategoryID);
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void repProvince_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (LinkClicked != null)
        {
            MenuEventArgs mnuEvent = new MenuEventArgs();
            mnuEvent.CategoryID = CategoryID.ToString();
            mnuEvent.SubcategoryID = SubcategoryID.ToString();
            mnuEvent.AreaID = e.CommandArgument.ToString();
            this.LinkClicked(this, mnuEvent);
        }
    }

}
