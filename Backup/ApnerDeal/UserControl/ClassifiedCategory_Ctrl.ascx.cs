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

public partial class UserControl_ClassifiedCategory_Ctrl : System.Web.UI.UserControl
{
    #region PROPERTY

    private string _NoOfItems;

    public string NoOfItems
    {
        get { return _NoOfItems; }
        set { _NoOfItems = value; }
    }

    private string _ImageClassName;

    public string ImageClassName
    {
        get { return _ImageClassName; }
        set { _ImageClassName = value; }
    }


    private string _Country;

    public string Country
    {
        get { return _Country; }
        set { _Country = value; }
    }

    private string _CategoryID;

    public string CategoryID
    {
        get { return _CategoryID; }
        set { _CategoryID = value; }
    }



    #endregion PROPERTY


    /// <summary>
    /// Loads all Classified Category with Number of items posted in that Category.
    /// USP: USP_Classified_LeftMenu_LoadAllCategory_WithNoOf_Items
    /// </summary>
    private void LoadList_ClassifiedCategory_WithNoOf_Items()
    {
        
        try
        {
            using (BC_Classifieds_Item bcClassifiedItems = new BC_Classifieds_Item())
            {
                DataTable dtClassified = bcClassifiedItems.LoadList_ClassifiedCategory_WithNoOf_Items("bangladesh");
                if (dtClassified.Rows.Count > 0)
                {
                    grvCategory.DataSource = dtClassified;
                    grvCategory.DataBind();
                }
            }
        }
        catch (Exception Exp)
        {
            lblSystemMessage.Text = Exp.Message.ToString();
        }

    }


    private void LoadList_Classified_Housing_WithNoOf_Items(string _Country, int _SubcategoryID)
    {

        try
        {
            using (BC_Classifieds_Item bcClassifiedItems = new BC_Classifieds_Item())
            {
                DataTable dtClassified = bcClassifiedItems.LoadList_Classified_Housing_WithNoOf_Items(_Country, _SubcategoryID);
                if (dtClassified.Rows.Count > 0)
                {
                    NoOfItems = dtClassified.Rows[0]["NoOfItems"].ToString();
                    ImageClassName = dtClassified.Rows[0]["ImageClassName"].ToString();
                    Country = dtClassified.Rows[0]["Country"].ToString();
                }
            }
        }
        catch (Exception Exp)
        {
            lblSystemMessage.Text = Exp.Message.ToString();
        }

    }


    protected void Page_Load(object sender, EventArgs e)
    {
        this.LoadList_ClassifiedCategory_WithNoOf_Items();
        this.LoadList_Classified_Housing_WithNoOf_Items("Bangladesh", 54);
    }


    protected void grvCategory_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            CategoryID = ((DataRowView)e.Row.DataItem)["CategoryID"].ToString();
        }
    }
}