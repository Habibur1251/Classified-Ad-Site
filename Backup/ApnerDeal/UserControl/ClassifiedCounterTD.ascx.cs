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

public partial class UserControl_ClassifiedCounterTD : System.Web.UI.UserControl
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

    #endregion PROPERTY

    private int intCountryID = -1;
    private string strCategoryID;
    private int intNumberOfNegotiableItems;

    public int NumberOfNegotiableItems
    {
        get { return intNumberOfNegotiableItems; }
        set { intNumberOfNegotiableItems = value; }
    }

    public string CategoryID
    {
        get { return strCategoryID; }
        set { strCategoryID = value; }
    }

    private DataTable dtClassified = null;

    private void LoadListClassifiedHousingWithNoOfItems(string _Country, int _SubcategoryID)
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

    /// <summary>
    /// Loads Number of Negotiable Classified Items with Counter Sabbir Ahmed.
    /// </summary>
    private void LoadNumberOfNegotiableItems()
    {
        try
        {
            using (BC_Classifieds_Item bcClassifiedItems = new BC_Classifieds_Item())
            {
                dtClassified = bcClassifiedItems.LoadNumberOf_NegotiableItems(Convert.ToInt32(10));
                if (dtClassified.Rows.Count > 0)
                {
                    repNegotiable.DataSource = dtClassified;
                    repNegotiable.DataBind();
                }
                else
                {
                    repNegotiable.DataSource = null;
                    repNegotiable.DataBind();
                }
            }
        }
        catch (Exception exception)
        {
            lblSystemMessage.Text = exception.Message.ToString();
        }

    }

    private void LoadListClassifiedCategoryWithNoOfItems()
    {
        try
        {
            using (BC_Classifieds_Item bcClassifiedItems = new BC_Classifieds_Item())
            {
                dtClassified = bcClassifiedItems.LoadList_ClassifiedCategory_WithNoOf_Items("bangladesh");
                if (dtClassified.Rows.Count > 0)
                {
                    grvCategory.DataSource = dtClassified;
                    grvCategory.DataBind();
                }
            }
        }
        catch (Exception exception)
        {
            lblSystemMessage.Text = exception.Message.ToString();
        }
    }
   
    protected void Page_Load(object sender, EventArgs e)
    {
            this.LoadListClassifiedHousingWithNoOfItems("Bangladesh", 54);
            if (!Page.IsPostBack)
            {
                this.LoadNumberOfNegotiableItems();
                
                this.LoadListClassifiedCategoryWithNoOfItems();
            }
    }

    protected void dlst_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        
    }

    protected void dlst_ItemCreated(object sender, DataListItemEventArgs e)
    {

    }

    protected void grvCategory_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            CategoryID = ((DataRowView)e.Row.DataItem)["CategoryID"].ToString();

            string ImageClassName = ((DataRowView)e.Row.DataItem)["ImageClassName"].ToString();
            string NoOfItems = ((DataRowView)e.Row.DataItem)["NoOfItems"].ToString();
            string Category = ((DataRowView)e.Row.DataItem)["Category"].ToString();
            string Country = ((DataRowView)e.Row.DataItem)["Country"].ToString();
        }
    }
}
