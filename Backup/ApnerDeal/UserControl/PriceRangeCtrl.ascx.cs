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

public partial class UserControl_PriceRangeCtrl : System.Web.UI.UserControl
{

    #region PROPERTY
    
    public string CategoryID
    {
        get 
        {
            object obj = ViewState["CategoryID"];
            if (obj != null)
            {
                return (string)obj;
            }
            return "";
        }
        set 
        {
            ViewState["CategoryID"] = value;
        }
    }



    public string SubcategoryID
    {
        get
        {
            object obj = ViewState["SubcategoryID"];
            if (obj != null)
            {
                return (string)obj;
            }
            return "";
        }
        set
        {
            ViewState["SubcategoryID"] = value;
        }
    }

    #endregion PROPERTY


    public delegate void PriceClicked(object sender, MenuEventArgs args);
    public event PriceClicked LinkClicked;

    private void LoadPriceRange(int intCategoryID, int intSubcategoryID)
    {
        try
        {
            using (BC_Price_Range priceRange = new BC_Price_Range())
            {
                DataTable dt = priceRange.LoadPriceRange(intCategoryID, intSubcategoryID);
                if (dt.Rows.Count > 0)
                {
                    repPriceRange.DataSource = dt;
                    repPriceRange.DataBind();
                    phPriceRange.Visible = true;
                }
                else
                {
                    this.Visible = false;
                }
            }
        }
        catch (Exception ex)
        {
            lblSystemMessage.Text = ex.Message;
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        int intCategoryID;
        int intSubcategoryID;
        if (SubcategoryID != "-1" && SubcategoryID != "")
        {
            if (Int32.TryParse(CategoryID, out intCategoryID) && Int32.TryParse(SubcategoryID, out intSubcategoryID))
            {
                if (intCategoryID != 9)
                {
                    this.LoadPriceRange(intCategoryID, intSubcategoryID);
                    //phPriceRange.Visible = true;
                }
                else
                {
                    this.Visible = false;
                }
            }
        }
        else
        {
            phPriceRange.Visible = false;
        }
    }

    protected void repPriceRange_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (LinkClicked != null)
        {
            MenuEventArgs mnuEventArgs = new MenuEventArgs();
            mnuEventArgs.CategoryID = CategoryID;
            mnuEventArgs.SubcategoryID = SubcategoryID;
            mnuEventArgs.PriceRangeID = e.CommandArgument.ToString();
            this.LinkClicked(this, mnuEventArgs);
        }
    }
}
