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

public partial class UserControl_BS_Province_Ctrl : System.Web.UI.UserControl
{
    private int intCategoryID;
    private int intSubcategoryID;

    //public int SubcategoryID
    //{
    //    get { return intSubcategoryID; }
    //    set { intSubcategoryID = value; }
    //}

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


    public delegate void ProvinceClicked(object sender, MenuEventArgs args);
    public event ProvinceClicked LinkClicked;



    /// <summary>
    /// Loads List of Province.
    /// </summary>
    /// <param name="intCategoryID"></param>
    /// <param name="intSubcategoryID"></param>
    private void LoadList_ProvinvceWithItems(int intCategoryID, int intSubcategoryID)
    {
        try
        {
            using (BC_Location location = new BC_Location())
            {

                DataTable dt = location.LoadList_Province(intCategoryID, intSubcategoryID);
                if (dt.Rows.Count > 0)
                {
                    repProvince.DataSource = dt;
                    repProvince.DataBind();
                }
                else
                {
                    repProvince.DataSource = null;
                    repProvince.DataBind();
                }

            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
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

    protected void Page_Load(object sender, EventArgs e)
    {
        //this.LoadList_ProvinvceWithItems(CategoryID, SubcategoryID);
    }


    protected void Page_PreRender(object sender, EventArgs e)
    {
        this.LoadList_ProvinvceWithItems(CategoryID, SubcategoryID);

        //if (!Page.IsPostBack)
        //{
        //    this.LoadList_ProvinvceWithItems(CategoryID, SubcategoryID);
        //}
    }

    
}
