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

public partial class ItemList_Classifieds : System.Web.UI.Page
{
    


    #region PROPERTY

    private string strHtml = string.Empty;

    private int intSubcategoryID = 0;
    private string categoryID = string.Empty;
    private string category = string.Empty;
    //private string subcategoryID = string.Empty;
    private string subcategory = string.Empty;
    private string location = string.Empty;
    public string TitleLocation = string.Empty; //Moinur
    public DataTable dtProductList = null;
    //public string strCurrency = "";
    //public string strSalePrice = "";
    //private int intCategoryID = -1;
    private string strPageMode = string.Empty;
    //private int intPageMode = -1;
    private string strProvinceID = string.Empty;
    private int intProvinceID = -1;

    //private int PriceRangeID = -1;


    public enum Filter
    {
        ByCategory,
        BySubcategory,
        ByPrice,
        ByLocationCategory,
        ByLocationSubcategory,
        ByArea,
        ByNegotiableSubcategory,
        ByNegotiableCategory,
    }

    public Filter FilterType
    {
        get
        {
            object obj = ViewState["FilterType"];
            if (obj != null)
            {
                return (Filter)obj;
            }
            return Filter.ByCategory;

        }
        set
        {
            ViewState["FilterType"] = value;
        }
    }


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
        set
        {
            ViewState["SubcategoryID"] = value;
        }
    }

    public int PriceRangeID
    {
        get
        {
            object obj = ViewState["PriceRangeID"];
            if (obj != null)
            {
                return (int)obj;
            }
            return 0;

        }
        set
        {
            ViewState["PriceRangeID"] = value;
        }
    }

    public int ProvinceID
    {
        get
        {
            object obj = ViewState["ProvinceID"];
            if (obj != null)
            {
                return (int)obj;
            }
            return -1;

        }
        set
        {
            ViewState["ProvinceID"] = value;
        }
    }

    public int AreaID
    {
        get
        {
            object obj = ViewState["AreaID"];
            if (obj != null)
            {
                return (int)obj;
            }
            return -1;

        }
        set
        {
            ViewState["AreaID"] = value;
        }
    }

    public int CategoryID
    {
        get
        {
            object obj = ViewState["CategoryID"];
            if (obj != null)
            {
                return (int)obj;
            }
            return -1;

        }
        set
        {
            ViewState["CategoryID"] = value;
        }
    }

    private string advertisementType = string.Empty;
    private string customMessage = string.Empty;



    public string Category
    {
        get
        {
            object obj = ViewState["Category"];
            if (obj != null)
            {
                return obj.ToString();
            }
            return "";

        }
        set
        {
            ViewState["Category"] = value;
        }
    }



    public string Subcategory
    {
        get { return this.subcategory; }
        set { this.subcategory = value; }
    }

    public string Location
    {
        get { return this.location; }
        set { this.location = value; }
    }

    public string AdvertisementType
    {
        get { return this.advertisementType; }
        set { this.advertisementType = value; }
    }

    public string CustomMessage
    {
        get { return this.customMessage; }
        set { this.customMessage = value; }
    }

    private int _Total_Record;

    public int Total_Record
    {
        get { return _Total_Record; }
        set { _Total_Record = value; }
    }
    #endregion PROPERTY

    #region CHECKQUERYSTRING METHOD

    /// <summary>
    /// Checks the Query Strings And Retrieves Value.
    /// </summary>
    private void CheckQueryString()
    {
        bool blnFlag = true;



        strPageMode = Request.QueryString["PageMode"];
        categoryID = Request.QueryString["CID"];
        strProvinceID = Request.QueryString["ProvKey"];
        location = Request.QueryString["Location"];
        
        string strPriceRangeID = Request.QueryString["PriceKey"];

        if (strPageMode != null)
        {
            //strPageMode = Request.QueryString["PageMode"].ToString();

            if (strPageMode == "0" || strPageMode == "1" || strPageMode == "2" || strPageMode == "3" && categoryID != null)
            {
                if (UTLUtilities.IsNumeric(categoryID))
                {
                    CategoryID = Convert.ToInt32(categoryID);

                    if (strPageMode == "0" && location != null)
                    {
                        if (!(CategoryID > 0))
                        {
                            blnFlag = false;
                        }
                        location = Request.QueryString["Location"].ToString();
                    }
                    else if (strPageMode == "1" && strProvinceID != null && strProvinceID != "-1")
                    {
                        intProvinceID = Convert.ToInt32(strProvinceID);
                    }
                    else if (strPageMode == "2")
                    {
                        blnFlag = true;
                    }

                    else
                    {
                        blnFlag = false;
                    }
                }
                else
                {
                    blnFlag = false;
                }


            }
            else
            {
                blnFlag = false;
            }
        }
        else
        {
            blnFlag = false;
        }

        if (!blnFlag)
        {
            Response.Redirect("Default.aspx");
        }
    }

    #endregion CHECKQUERYSTRING METHOD

    #region PAGE LOAD EVENTS



    protected void Page_Load(object sender, EventArgs e)
    {
        insideDhakaCtrl.LinkClicked += new UserControl_CL_Area_Ctrl.AreaClicked(insideDhakaCtrl_LinkClicked);
        outsideDhakaCtrl.LinkClicked += new UserControl_CL_Province_Ctrl.ProvinceClicked(outsideDhakaCtrl_LinkClicked);
        rangeCtrl.LinkClicked += new UserControl_PriceRangeCtrl.PriceClicked(rangeCtrl_LinkClicked);


        //outsideDhakaCtrl.l

        this.TitleLocation = "Bangladesh";
        this.Location = "Bangladesh";


        if (!Page.IsPostBack)
        {
            this.CustomMessage = Request.QueryString["CMSG"];

            this.CheckQueryString();


            switch (strPageMode)
            {
                case "0":
                    {
                        this.LoadRecord_ProductList_By_Category(CategoryID);
                        break;
                    }
                case "1":
                    {
                        this.LoadList_ClassifiedItems_ByProvince_Category(intProvinceID, CategoryID);
                        break;
                    }
                case "2":
                    {
                        this.LoadList_Negotiable_ClassifiedItems();
                        break;
                    }
                //case "3":
                //    {
                //        this.LoadRecord_ProductList_By_PriceRange(CategoryID, SubcategoryID, PriceRangeID);
                //        break;
                //    }
            }

            this.LoadRecord_Subcategory(CategoryID);
            this.Subcategory = "All Item(s)";

            InitializeControls();


            //ddlSubcategory.SelectedValue = this.SubcategoryID;

            //lblLocation.Text = this.Location;

            if (!string.IsNullOrEmpty(this.CustomMessage))
            {
                if (this.CustomMessage == "1")
                {
                    this.strHtml = "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" style=\"width:100%; background-color:#FFA500;\">";
                    this.strHtml += "<tr>";
                    this.strHtml += "<td align=\"center\" style=\"height:45px; color:#FFFFFF; font-size:14px; font-weight:bold;\" valign=\"middle\">";
                    this.strHtml += "Your have placed your order successfully.";
                    this.strHtml += "</td>";
                    this.strHtml += "</tr>";
                    this.strHtml += "</table>";

                    lblSystemMessage.Text = this.strHtml;
                }

                if (this.CustomMessage == "0")
                {
                    this.strHtml = "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" style=\"width:100%; background-color:#E62D29;\">";
                    this.strHtml += "<tr>";
                    this.strHtml += "<td align=\"center\" style=\"height:45px; color:#FFFFFF; font-size:14px; font-weight:bold;\" valign=\"middle\">";
                    this.strHtml += "System cannot process Your order ! Please try after sometime.";
                    this.strHtml += "</td>";
                    this.strHtml += "</tr>";
                    this.strHtml += "</table>";

                    lblSystemMessage.Text = this.strHtml;
                }
            }
        }
    }

    
    #endregion PAGE LOAD EVENTS

    #region CONTROL LOAD METHODS


    /// <summary>
    /// Loads List of Subcategory For Dropdownlist
    /// </summary>
    /// <param name="intCategoryID"></param>
    private void LoadRecord_Subcategory(int intCategoryID)
    {
        try
        {
            using (BOC_Classifieds_Orders bocProductProfile = new BOC_Classifieds_Orders())
            {
                EOC_PropertyBean eocPropertyBean = new EOC_PropertyBean();

                eocPropertyBean.Category_CategoryID = intCategoryID;

                DataTable dtSubcategory = bocProductProfile.LoadRecord_Subcategory(eocPropertyBean);

                if (dtSubcategory.Rows.Count > 0)
                {
                    //DropDownList ddlSubcategory = new DropDownList();



                    if (dtSubcategory.Rows.Count == 1)
                    {
                        ddlSubcategory.DataSource = dtSubcategory;
                        ddlSubcategory.DataValueField = "SubcategoryID";
                        ddlSubcategory.DataTextField = "Subcategory";
                        ddlSubcategory.DataBind();
                        pnlSubcategory.Visible = false;
                    }
                    else
                    {
                        ddlSubcategory.Items.Clear();
                        ddlSubcategory.Items.Add(new ListItem("All", "-1"));
                        ddlSubcategory.DataSource = dtSubcategory;
                        ddlSubcategory.DataValueField = "SubcategoryID";
                        ddlSubcategory.DataTextField = "Subcategory";
                        ddlSubcategory.DataBind();
                        pnlSubcategory.Visible = true;
                    }

                }


            }
        }
        catch (Exception Exp)
        {
            lblSystemMessage.Text = Exp.Message.ToString();
        }
    }


    /// <summary>
    /// Loads All Classified Item List, After initiating from left menu or Home page.
    /// </summary>
    /// <param name="intCategoryID"></param>
    private void LoadRecord_ProductList_By_Category(int intCategoryID)
    {
        try
        {
            using (BOC_Classifieds_Orders bocProductProfile = new BOC_Classifieds_Orders())
            {
                EOC_PropertyBean eocPropertyBean = new EOC_PropertyBean();

                eocPropertyBean.Subcategory_CategoryID = intCategoryID;
                dtProductList = new DataTable();
                dtProductList = bocProductProfile.LoadRecord_ProductList_Classifieds_By_Category(eocPropertyBean);

                //FilterNo = Filter.ByCategory.ToString();
                FilterType = Filter.ByCategory;

                if (dtProductList.Rows.Count > 0)
                {
                    this.InitializeGridView(dtProductList);
                }
                else
                {
                    this.EmptyGridView();
                }
            }
        }
        catch (Exception Exp)
        {
            lblSystemMessage.Text = Exp.Message.ToString();
        }
    }


    private void LoadRecord_ProductList(int intSubcategoryID, string strCountry, string strAdvertisementType)
    {
        try
        {
            using (BOC_Classifieds_Orders bocProductProfile = new BOC_Classifieds_Orders())
            {
                EOC_PropertyBean eocPropertyBean = new EOC_PropertyBean();

                eocPropertyBean.Subcategory_SubcategoryID = intSubcategoryID;
                eocPropertyBean.Country_CountryName = strCountry;

                dtProductList = new DataTable();
                dtProductList = bocProductProfile.LoadRecord_ProductList_Classifieds(eocPropertyBean);
                FilterType = Filter.BySubcategory;

                if (dtProductList.Rows.Count > 0)
                {
                    this.InitializeGridView(dtProductList);
                }
                else
                {
                    this.EmptyGridView();
                }
            }
        }
        catch (Exception Exp)
        {
            lblSystemMessage.Text = Exp.Message.ToString();
        }
    }


    /// <summary>
    /// Loads All items of specific Category Under Specific Province.
    /// </summary>
    /// <param name="intProvinceID"></param>
    /// <param name="intCategoryID"></param>
    private void LoadList_ClassifiedItems_ByProvince_Category(int intProvinceID, int intCategoryID)
    {
        try
        {
            using (BC_Classifieds_Item bcClassified = new BC_Classifieds_Item())
            {
                dtProductList = bcClassified.LoadList_Classified_Items_By_Province_Category(intProvinceID, intCategoryID);

                //FilterNo = Filter.ByLocationCategory.ToString();
                FilterType = Filter.ByLocationCategory;

                if (dtProductList.Rows.Count > 0)
                {
                    this.InitializeGridView(dtProductList);
                }
                else
                {
                    this.EmptyGridView();
                }
            }
        }
        catch (Exception exp)
        {
            lblSystemMessage.Text = exp.Message;
        }
    }


    /// <summary>
    /// Loads All items of specific Category Under Specific Province And Specific Area.
    /// </summary>
    /// <param name="intAreaID"></param>
    /// <param name="intCategoryID"></param>

    private void LoadList_ClassifiedItems_ByProvince_Category_Area(int intAreaID, int intCategoryID)
    {
        try
        {
            using (BC_Classifieds_Item bcClassified = new BC_Classifieds_Item())
            {
                dtProductList = bcClassified.LoadList_Classified_Items_By_Province_Area_Category(intAreaID, intCategoryID);

                //FilterNo = Filter.ByArea.ToString();
                FilterType = Filter.ByArea;


                if (dtProductList.Rows.Count > 0)
                {
                    this.InitializeGridView(dtProductList);
                }
                else
                {
                    this.EmptyGridView();
                }
            }
        }
        catch (Exception exp)
        {
            lblSystemMessage.Text = exp.Message;
        }
    }

    /// <summary>
    /// Loads Items By Price range.
    /// </summary>
    /// <param name="intCategoryID"></param>
    private void LoadRecord_ProductList_By_PriceRange(int intCategoryID, int intSubcategoryID, int intPriceRangeID)
    {
        try
        {
            using (BC_Price_Range bcPrice = new BC_Price_Range())
            {
                dtProductList = new DataTable();
                dtProductList = bcPrice.LoadClassifiedItems_ByPriceRange(intCategoryID, intSubcategoryID, intPriceRangeID);

                //FilterNo = Filter.ByPrice.ToString();
                FilterType = Filter.ByPrice;

                if (dtProductList.Rows.Count > 0)
                {
                    this.InitializeGridView(dtProductList);
                }
                else
                {
                    this.EmptyGridView();
                }
            }
        }
        catch (Exception Exp)
        {
            lblSystemMessage.Text = Exp.Message.ToString();
        }
    }

    /// <summary>
    /// Loads Negotiable Classified Items By their Subcategory.
    /// </summary>
    /// <param name="intProvinceID"></param>
    /// <param name="intCategoryID"></param>
    private void LoadList_Negotiable_ClassifiedItems_BySubcategory()
    {
        try
        {
            using (BC_Classifieds_Item bcClassified = new BC_Classifieds_Item())
            {
                SubcategoryID = Convert.ToInt32(SubcategoryID);
                dtProductList = bcClassified.LoadList_Negotiable_ClassifiedItems_BySubcategory(CategoryID, SubcategoryID);

                //FilterNo = Filter.ByNegotiableSubcategory.ToString();
                FilterType = Filter.ByNegotiableSubcategory;

                if (dtProductList.Rows.Count > 0)
                {
                    this.InitializeGridView(dtProductList);
                }
                else
                {
                    //grvItemList.DataSource = null;
                    //grvItemList.DataBind();
                    this.EmptyGridView();
                }
            }
        }
        catch (Exception exp)
        {
            lblSystemMessage.Text = exp.Message;
        }
    }



    /// <summary>
    /// Loads Only Negotiable Classified Items By Category.
    /// </summary>
    private void LoadList_Negotiable_ClassifiedItems()
    {
        try
        {
            using (BC_Classifieds_Item bcClassified = new BC_Classifieds_Item())
            {
                dtProductList = bcClassified.LoadList_Negotiable_ClassifiedItems(CategoryID);

                //FilterNo = Filter.ByNegotiableCategory.ToString();
                FilterType = Filter.ByNegotiableCategory;

                if (dtProductList.Rows.Count > 0)
                {
                    this.InitializeGridView(dtProductList);
                }
                else
                {
                    this.EmptyGridView();
                }
            }
        }
        catch (Exception exp)
        {
            lblSystemMessage.Text = exp.Message;
        }
    }

    /// <summary>
    /// Loads Specific Category and SubcategoryItems of a selected Province.
    /// </summary>
    private void LoadList_ProvinceItems_BySubcategory()
    {
        try
        {
            using (BC_Classifieds_Item bcClassified = new BC_Classifieds_Item())
            {
                dtProductList = bcClassified.LoadList_Province_ClassifiedItems_BySubcategory(CategoryID, SubcategoryID, intProvinceID);

                //FilterNo = Filter.ByLocationSubcategory.ToString();
                FilterType = Filter.ByLocationCategory;

                if (dtProductList.Rows.Count > 0)
                {
                    this.InitializeGridView(dtProductList);
                }
                else
                {
                    this.EmptyGridView();
                }
            }
        }
        catch (Exception exp)
        {
            lblSystemMessage.Text = exp.Message;
        }

    }

    #endregion CONTROL LOAD METHODS

    #region RICH DATA CONTROLS EVENTS

    protected void grvItemList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            this.CheckQueryString();
            grvItemList.PageIndex = e.NewPageIndex;
            if (FilterType == Filter.ByCategory)
            {
                this.LoadRecord_ProductList_By_Category(Convert.ToInt32(this.CategoryID));
            }
            else if (FilterType == Filter.ByLocationCategory)
            {
                this.LoadList_ClassifiedItems_ByProvince_Category(intProvinceID, Convert.ToInt32(this.CategoryID));
            }
            else if (FilterType == Filter.ByArea)
            {
                this.LoadList_ClassifiedItems_ByProvince_Category_Area(AreaID, CategoryID);
            }
            else if (FilterType == Filter.ByNegotiableCategory)
            {
                this.LoadList_Negotiable_ClassifiedItems();
            }
            else if (FilterType == Filter.ByNegotiableSubcategory)
            {
                this.LoadList_Negotiable_ClassifiedItems_BySubcategory();
            }
            else if (FilterType == Filter.ByPrice)
            {
                this.LoadRecord_ProductList_By_PriceRange(CategoryID, SubcategoryID, PriceRangeID);
            }
            else if (FilterType == Filter.BySubcategory)
            {
                this.LoadRecord_ProductList(SubcategoryID, Location, AdvertisementType);
            }
            else
            {
                this.LoadRecord_ProductList(SubcategoryID, Location, AdvertisementType);
            }
        }
        catch (Exception Exp)
        {
            lblSystemMessage.Text = Exp.Message.ToString();
        }
    }

    protected void grvItemList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            try
            {
                GridViewRow grvRow = e.Row;
                string strAlternatePrice = DataBinder.Eval(e.Row.DataItem, "AlternatePriceOffer").ToString();
                double strSalePrice = Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "SalePrice"));
                string strCurrency = DataBinder.Eval(e.Row.DataItem, "Currency").ToString();

                Label lblPricingOffer = new Label();

                lblPricingOffer.CssClass = "price";

                
                if (strAlternatePrice == "-1")
                {
                    lblPricingOffer.Text = "Price (Not Available)";
                }
                else if (strAlternatePrice == "1")
                {
                    lblPricingOffer.Text = "Best Offer (" + strCurrency + " " + String.Format("{0:#,###}", strSalePrice) + ")";
                }
                else if (strAlternatePrice == "2")
                {
                    lblPricingOffer.Text = "Please Contact";
                }
                else if (strAlternatePrice == "3")
                {
                    lblPricingOffer.Text = "Exchange";
                }
                else if (strAlternatePrice == "4")
                {
                    lblPricingOffer.Text = "Free";
                }
                else if (strAlternatePrice == "5")
                {
                    lblPricingOffer.Text = "Fixed (" + strCurrency + " " + String.Format("{0:#,###}", strSalePrice) + ")";
                }
                else if (strAlternatePrice == "6")
                {
                    lblPricingOffer.Text = "Negotiable (" + strCurrency + " " + String.Format("{0:#,###}", strSalePrice) + ")";
                }
                else
                {
                    lblPricingOffer.Text = "Price (" + strCurrency + " " + String.Format("{0:#,###}", strSalePrice) + ")";
                }

                PlaceHolder ph = (PlaceHolder)grvRow.FindControl("phPrice");
                ph.Controls.Add(lblPricingOffer);
                this.CategoryID = Convert.ToInt32(grvItemList.DataKeys[e.Row.RowIndex]["CategoryID"]);
                if (this.CategoryID != 9)     //Checks if its Matrimonial Category
                {
                    ph.Visible = true;
                }
                else
                {
                    ph.Visible = false;
                }

            }
            catch (Exception exp)
            {
                lblSystemMessage.Text = "Error: " + exp.Message;
            }

        }

    }

    #endregion RICH DATA CONTROLS EVENTS
    
    #region DROPDOWNLIST SELECTED INDEX CHANGE EVENTS


    protected void ddlSubcategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        grvItemList.PageIndex = 0;
        this.CheckQueryString();
        FilterType = Filter.BySubcategory;

        Int32.TryParse(hfProvinceID.Value, out intProvinceID);
        SubcategoryID = Convert.ToInt32(ddlSubcategory.SelectedValue);
        InitializeControls();
        //this.SubcategoryID = ddlSubcategory.SelectedItem.Value;
        if (strPageMode == "2" && ddlSubcategory.SelectedItem.Text != "All")
        {
            this.LoadList_Negotiable_ClassifiedItems_BySubcategory();
        }
        else if (strPageMode == "2" && ddlSubcategory.SelectedItem.Text == "All")
        {
            this.LoadList_Negotiable_ClassifiedItems();
        }
        else if (strPageMode == "1" && ddlSubcategory.SelectedItem.Text != "All")
        {
            this.LoadList_ProvinceItems_BySubcategory();
        }
        else if (strPageMode == "1" && ddlSubcategory.SelectedItem.Text == "All")
        {
            this.LoadList_ClassifiedItems_ByProvince_Category(intProvinceID, CategoryID);
        }
        else
        {
            if (ddlSubcategory.SelectedItem.Text == "All")
            {
                this.Subcategory = "All Item(s)";
                this.LoadRecord_ProductList_By_Category(CategoryID);
            }
            else
            {
                this.Location = "Bangladesh";
                this.LoadRecord_ProductList(Convert.ToInt32(this.SubcategoryID), this.Location, this.AdvertisementType);
            }
        }
        InitializeControls();
    }

    #endregion DROPDOWNLIST SELECTED INDEX CHANGE EVENTS

    #region GENERAL METHODS


    /// <summary>
    /// Initializes the gridview with the parameter datatable.
    /// </summary>
    /// <param name="dt"></param>
    private void InitializeGridView(DataTable dt)
    {
        this.Category = dt.Rows[0]["Category"].ToString();
        this.Subcategory = dt.Rows[0]["Subcategory"].ToString();
        this.SubcategoryID = Convert.ToInt32(dt.Rows[0]["SubcategoryID"].ToString());
        this.Location = dt.Rows[0]["Item_Location"].ToString();
        if (dt.Rows.Count == 1)
        {
            ddlSubcategory.SelectedValue = dt.Rows[0]["SubcategoryID"].ToString();
        }

        hfProvinceID.Value = dt.Rows[0]["Items_ProvinceID"].ToString();
        hfSubcategoryID.Value = dt.Rows[0]["SubcategoryID"].ToString();

        //this.subcategoryID = hfSubcategoryID.Value;
        this.strProvinceID = hfProvinceID.Value;



        grvItemList.DataSource = dt;
        grvItemList.DataBind();
        Total_Record = dt.Rows.Count;
    }


    /// <summary>
    /// Initializes Null value in Gridview's Datasource.
    /// </summary>
    private void EmptyGridView()
    {
        grvItemList.DataSource = null;
        grvItemList.DataBind();
    }


    private void InitializeControls()
    {
        insideDhakaCtrl.CategoryID = CategoryID;
        outsideDhakaCtrl.CategoryID = CategoryID;
        rangeCtrl.CategoryID = CategoryID.ToString();
        rangeCtrl.SubcategoryID = ddlSubcategory.SelectedValue;
    }


    #endregion GENERAL METHODS

    #region USER CONTROL EVENTS

    void insideDhakaCtrl_LinkClicked(object sender, MenuEventArgs args)
    {
        grvItemList.PageIndex = 0;
        CategoryID = Convert.ToInt32(args.CategoryID);
        //int intSubcategoryID = Convert.ToInt32(args.SubcategoryID);
        AreaID = Convert.ToInt32(args.AreaID);
        this.LoadList_ClassifiedItems_ByProvince_Category_Area(AreaID, CategoryID);
        //this.InitializeControls();
        DisplayFilter.Filter_Name = "Items From Inside Dhaka";
        FilterType = Filter.ByArea;
    }



    protected void rangeCtrl_LinkClicked(object sender, MenuEventArgs args)
    {
        grvItemList.PageIndex = 0;
        int intCategoryID = Convert.ToInt32(args.CategoryID);
        int intSubcategoryID = Convert.ToInt32(args.SubcategoryID);
        int intPriceRangeID = Convert.ToInt32(args.PriceRangeID);

        this.LoadRecord_ProductList_By_PriceRange(intCategoryID, intSubcategoryID, intPriceRangeID);
        ddlSubcategory.SelectedValue = args.SubcategoryID;
        DisplayFilter.Filter_Name = "Price Range";
        FilterType = Filter.ByPrice;

    }

    protected void outsideDhakaCtrl_LinkClicked(object sender, MenuEventArgs args)
    {
        grvItemList.PageIndex = 0;
        CategoryID = Convert.ToInt32(args.CategoryID);
        //int intSubcategoryID = Convert.ToInt32(args.SubcategoryID);
        ProvinceID = Convert.ToInt32(args.ProvinceID);
        this.LoadList_ClassifiedItems_ByProvince_Category(ProvinceID, CategoryID);
        DisplayFilter.Filter_Name = "Items From Outside Dhaka";
        FilterType = Filter.ByLocationCategory;
    }
    #endregion USER CONTROL EVENTS
}
