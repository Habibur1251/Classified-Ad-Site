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

public partial class UserControl_ClassifiedSearchModule : System.Web.UI.UserControl
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


    private int intCountryID = 18;
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



    
    /// <summary>
    /// Loads Number of Negotiable Classified Items.
    /// </summary>
    private void LoadNumberOf_NegotiableItems()
    {
        try
        {
            using (BC_Classifieds_Item bcClassifiedItems = new BC_Classifieds_Item())
            {
                dtClassified = bcClassifiedItems.LoadNumberOf_NegotiableItems(Convert.ToInt32(CategoryID));
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
        catch (Exception Exp)
        {
            lblSystemMessage.Text = Exp.Message.ToString();
        }

    }




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
                dtClassified = bcClassifiedItems.LoadList_ClassifiedCategory_WithNoOf_Items("bangladesh");
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
   
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.QueryString["CID"] != null)
        {
            this.LoadList_Classified_Housing_WithNoOf_Items("Bangladesh", 54);

            CategoryID = Request.QueryString["CID"].ToString();
            //dlst.Caption = "<div style=\"height:20px;padding-top:7px;margin:3px 0px 3px 0px;font-size:12px;\"><span class=\"price\">";
            //dlst.Caption += ddlCategory.SelectedItem.Text + "</span></div>";
            if (!Page.IsPostBack)
            {
                //this.LoadRecord_ClassifiedCategory();
                //if (ddlCategory.SelectedValue == "-1")
                //{
                    //this.LoadList_CL_Items_AllProvince("Bangladesh");
                //}
                //else
                //{ 
                this.LoadNumberOf_NegotiableItems();
                
                this.LoadList_ClassifiedCategory_WithNoOf_Items();
                //}
            }
        }
        else
        {
            Response.Redirect("../Default.aspx");
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

            //PlaceHolder ph = (PlaceHolder)e.Row.FindControl("ph");
            //Label lit = (Label)e.Row.FindControl("lit");
            //HyperLink link = new HyperLink();
            //lit.Text = "<li class=\"" + ImageClassName + "\">";
            //lit.Text += "<a class=\"onHoverRedLink onHoverBlue\" style=\"font-size: 11px\""; 
            //lit.Text += "href=\"../ItemList_Classifieds.aspx?PageMode=0&CID=" + CategoryID + "&Location=";
            //lit.Text += Country + ">" + Category +"("+ NoOfItems + ")" + "</a></li>";

            //link.CssClass = "onHoverBlue";
            //ph.Controls.Add(lit);
            
            //<%if(CategoryID != "16"){%><li class="<%#Eval("ImageClassName") %>"><a class="onHoverRedLink onHoverBlue" style="font-size: 11px" href="../ItemList_Classifieds.aspx?PageMode=0&CID=<%# Eval("CategoryID")%>&Location=<%#Eval("Country")%>"> <%#Eval("Category") %>(<%#Eval("NoOfItems") %>) </a></li><%} %>

        }
    }
}
