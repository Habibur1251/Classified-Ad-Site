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

public partial class UserControl_RealEstate_SecondSubcategory_List_Ctrl : System.Web.UI.UserControl
{
    #region PROPERTY

    private int intCategoryID;
    private int intSubcategoryID;

    public int SubcategoryID
    {
        get
        {
            object obj = ViewState["SubcategoryID"];
            if (obj != null)
            {
                return (int)obj;
            }
            return 0;
        }

        set { ViewState["SubcategoryID"] = value; }
    }

    public int CategoryID
    {
        get { return intCategoryID; }
        set { intCategoryID = value; }
    }


    #endregion PROPERTY


    public delegate void SecondSubcategory_Clicked(object sender, MenuEventArgs e);
    public event SecondSubcategory_Clicked LinkClicked;



    /// <summary>
    /// Loads all the Model Names for Specific Category and SubcategoryID.
    /// </summary>
    /// <param name="intCategoryID"></param>
    /// <param name="intSubcategoryID"></param>
    private void LoadList_SecondSubcategory(int intSubcategoryID)
    {
        try
        {

            RealEstate objRealEstate = new RealEstate();
            RealEstateManager manager = new RealEstateManager();

            objRealEstate.SubcategoryID = intSubcategoryID;
            DataTable dt = manager.Load_LeftMenu_SecondSubcategory(objRealEstate);
            if (dt.Rows.Count > 0)
            {
                repList.DataSource = dt;
                repList.DataBind();
            }
            else
            {
                repList.DataSource = null;
                repList.DataBind();
                this.Visible = false;
            }

            
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        this.LoadList_SecondSubcategory(SubcategoryID);
    }


    protected void repList_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (LinkClicked != null)
        {
            MenuEventArgs mnuEventArgs = new MenuEventArgs();
            mnuEventArgs.SecondSubcatID = e.CommandArgument.ToString();
            mnuEventArgs.CategoryID = CategoryID.ToString();
            mnuEventArgs.SubcategoryID = SubcategoryID.ToString();
            this.LinkClicked(this, mnuEventArgs);
        }
    }
}
