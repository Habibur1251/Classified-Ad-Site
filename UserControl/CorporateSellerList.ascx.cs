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

public partial class UserControl_CorporateSellerList : System.Web.UI.UserControl
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

    public delegate void BS_SellerClicked(object sender, MenuEventArgs e);
    public event BS_SellerClicked LinkClicked;


    #region CONTROL LOAD METHODS


    /// <summary>
    /// Loads all the Seller List for Specific Category and SubcategoryID.
    /// </summary>
    /// <param name="intCategoryID"></param>
    /// <param name="intSubcategoryID"></param>
    private void LoadList_CorporateSeller(int intCategoryID, int intSubcategoryID)
    {
        try
        {
            using (BC_CorporateSeller bocCorporate = new BC_CorporateSeller())
            {

                DataTable dt = bocCorporate.LoadList_CorporateSeller(intCategoryID, intSubcategoryID);
                if (dt.Rows.Count > 0)
                {
                    repCorporateSeller.DataSource = dt;
                    repCorporateSeller.DataBind();
                }
                else
                {

                    repCorporateSeller.DataSource = null;
                    repCorporateSeller.DataBind();
                    this.Visible = false;
                }

            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    #endregion CONTROL LOAD METHODS


    #region PAGE LOAD EVENTS

    protected void Page_Load(object sender, EventArgs e)
    {
        //this.LoadList_CorporateSeller(CategoryID, SubcategoryID);
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        this.LoadList_CorporateSeller(CategoryID, SubcategoryID);
    }

    #endregion PAGE LOAD EVENTS

    #region REPEATER EVENTS

    protected void repCorporateSeller_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        LinkButton btn = (LinkButton)e.Item.FindControl("lbtnCorporateSeller");
        if (LinkClicked != null)
        {
            MenuEventArgs mnuEventArgs = new MenuEventArgs();
            mnuEventArgs.ProfileID = e.CommandArgument.ToString();
            mnuEventArgs.CategoryID = CategoryID.ToString();
            mnuEventArgs.SubcategoryID = SubcategoryID.ToString();
            this.LinkClicked(this, mnuEventArgs);
        }
    }
    #endregion REPEATER EVENTS

}
