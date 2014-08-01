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

public partial class Classifieds_Product_Management : System.Web.UI.Page
{
    #region PROPERTY


    private bool _ClassifiedSeller = false;
    private int intProfileID = -1;
    private int intCountryID = -1;
    private int intProductID = -1;
    private int intCategoryID = -1;
    private int intSubcategoryID = -1;
    private int intSecondSubcatID = -1;
    private DataTable dtProduct = null;
    private string strProductTitle = string.Empty;

    private int _CategoryID;

    public int CategoryID
    {
        get { return _CategoryID; }
        set { _CategoryID = value; }
    }

    private int _SubcategoryID;

    public int SubcategoryID
    {
        get { return _SubcategoryID; }
        set { _SubcategoryID = value; }
    }

    private int SecondSubcatID
    {
        get
        {
            object obj = ViewState["SecondSubcatID"];
            if (obj != null)
            {
                return (int)obj;
            }
            return 0;
        }

        set { ViewState["SecondSubcatID"] = value; }
    }

    private void Enable_Panel(Panel pnl, bool isEnable)
    {
        pnl.Visible = isEnable;
        pnl.Enabled = isEnable;
    }

    private enum PageMode
    {

        InsertMode
    }
    private PageMode Mode;



    public string GetSku
    {
        get { return lblSku.Text; }
    }
    public string GetCategory
    {
        get { return ddlCategory.SelectedItem.Text; }
    }
    public string GetSubcategory
    {
        get { return ddlSubcategory.SelectedItem.Text; }
    }
    public string GetSecondSubcategory
    {
        get { return ddl2ndSubCategory.SelectedItem.Text; }
    }
    public string GetProductModel
    {
        get { return ddlModel.SelectedItem.Text; }
    }
    public string GetProfileID
    {
        get { return intProfileID.ToString(); }
    }
    public string GetProductID
    {
        get { return intProductID.ToString(); }
    }
    public string GetCategoryID
    {
        get { return ddlCategory.SelectedValue; }
    }
    public string GetSubCategoryID
    {
        get { return ddlSubcategory.SelectedValue; }
    }
    public string GetSecondSubcatID
    {
        get { return ddl2ndSubCategory.SelectedValue; }
    }

    public int SearchResult
    {
        get
        {
            if (dtProduct != null)
            {
                if (dtProduct.Rows.Count > 0)
                {
                    return dtProduct.Rows.Count;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }
    }

    #endregion PROPERTY

    #region CHECKQUERYSTRING

    private void CheckQueryString()
    {
        object objCID = Request.QueryString["CID"];
        object objSCID = Request.QueryString["SCID"];
        if (objCID != null)
        {
            CategoryID = Convert.ToInt32(objCID);
            SubcategoryID = Convert.ToInt32(objSCID);
        }
    }

    #endregion CHECKQUERYSTRING


    #region AUTHENTICATION

    private void CheckUserSession()
    {
        if (this.Session["CLSF_PROFILE_CODE"] != null && this.Session["CLSF_COUNTRY_CODE"] != null)
        {
            intProfileID = Convert.ToInt32(this.Session["CLSF_PROFILE_CODE"].ToString());
            intCountryID = Convert.ToInt32(this.Session["CLSF_COUNTRY_CODE"].ToString());
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
    }


    #endregion AUTHENTICATION

    #region LOAD METHODS
    /// <summary>
    /// Loads the all Business Categories from category table.
    /// </summary>
    private void LoadRecord_Category()
    {
        try
        {
            using (BC_Corporate_ProductProfile bcProductProfile = new BC_Corporate_ProductProfile())
            {

                DataTable dtCategory = bcProductProfile.LoadRecord_Category(intCountryID);
                ddlCategory.Items.Clear();
                ddlCategory.Items.Add(new ListItem("Select Category", "-1"));
                if (dtCategory.Rows.Count > 0)
                {
                    ddlCategory.DataSource = dtCategory;
                    ddlCategory.DataValueField = "CategoryID";
                    ddlCategory.DataTextField = "Category";
                    ddlCategory.DataBind();
                }
                else
                {
                    lblSystemMessage.Text = UTLUtilities.ShowGeneralMessage("No Category available");
                }

            }
        }
        catch (Exception Exp)
        {
            lblSystemMessage.Text = Exp.Message.ToString();
        }
    }

    /// <summary>
    /// Loads Subacategory list based on CategoryID.
    /// </summary>
    private void LoadRecord_Subcategory(int _CategoryID)
    {
        try
        {
            using (BC_Corporate_ProductProfile bcProductProfile = new BC_Corporate_ProductProfile())
            {
                //System.Threading.Thread.Sleep(10000);
                ddlSubcategory.Items.Clear();
                ddlSubcategory.Items.Add(new ListItem("Select Subcategory", "-1"));
                DataTable dtSubcategory = bcProductProfile.LoadRecord_Subcategory(_CategoryID);
                if (dtSubcategory.Rows.Count > 0)
                {
                    ddlSubcategory.DataSource = dtSubcategory;
                    ddlSubcategory.DataValueField = "SubcategoryID";
                    ddlSubcategory.DataTextField = "Subcategory";
                    ddlSubcategory.DataBind();
                }
                else
                {
                    lblSystemMessage.Text = UTLUtilities.ShowGeneralMessage("No Subcategory available");
                }
            }
        }
        catch (Exception Exp)
        {
            lblSystemMessage.Text = Exp.Message.ToString();
        }
    }

    /// <summary>
    /// Loads SecondSubcategory List Based On SubcategoryID.
    /// </summary>
    private void LoadRecord_2ndSubcategory(int _CategoryID, int _SubcategoryID)
    {
        try
        {
            using (BC_Corporate_ProductProfile bcProductProfile = new BC_Corporate_ProductProfile())
            {
                ddl2ndSubCategory.Items.Clear();
                ddl2ndSubCategory.Items.Add(new ListItem("Select Second Subcategory", "-1"));

                DataTable dt2ndSubcategory = bcProductProfile.LoadRecord_2ndSubcategory(_CategoryID, _SubcategoryID);
                if (dt2ndSubcategory.Rows.Count > 0)
                {
                    ddl2ndSubCategory.DataSource = dt2ndSubcategory;
                    ddl2ndSubCategory.DataValueField = "SecondSubcatID";
                    ddl2ndSubCategory.DataTextField = "SecondSubCategory";
                    ddl2ndSubCategory.DataBind();
                }
                else
                {
                    lblSystemMessage.Text = UTLUtilities.ShowGeneralMessage("No Secondary sub category available");
                }
            }
        }
        catch (Exception Exp)
        {
            lblSystemMessage.Text = Exp.Message.ToString();
        }
    }



    /// <summary>
    /// Loads grvProduct with all the product title from the database, 
    /// that matches with the user provided product title. Returns true if any matches occur.
    /// </summary>
    private bool LoadList_Product()
    {
        bool blnFlag = false;
        intCategoryID = Convert.ToInt32(ddlCategory.SelectedValue);
        intSubcategoryID = Convert.ToInt32(ddlSubcategory.SelectedValue);
        intSecondSubcatID = Convert.ToInt32(ddl2ndSubCategory.SelectedValue);
        try
        {
            using (BC_Product bcProduct = new BC_Product())
            {
                dtProduct = new DataTable();

                if (intCategoryID == 1)
                {
                    dtProduct = bcProduct.GetList_BookTitle(intCategoryID, intSubcategoryID, txtTitle.Text);
                }
                else
                {
                    int _ProductModelID = Convert.ToInt32(ddlModel.SelectedValue);
                    dtProduct = bcProduct.GetList_MobileTitle(intCategoryID,
                        intSubcategoryID, intSecondSubcatID, _ProductModelID, txtTitle.Text);
                }
                if (dtProduct.Rows.Count > 0)
                {
                    grvProduct.DataSource = dtProduct;
                    grvProduct.DataBind();
                    blnFlag = true;

                }
                else
                {
                    grvProduct.DataSource = null;
                    grvProduct.DataBind();
                    blnFlag = false;
                }
            }
        }
        catch (Exception ex)
        {
            lblSystemMessage.Text = ex.Message;
        }
        return blnFlag;
    }


    /// <summary>
    /// Loads all the Product Model Depending on SecondSuubcatID.
    /// </summary>
    private void LoadList_Model()
    {

        try
        {
            int categoryID = Convert.ToInt32(ddlCategory.SelectedValue);
            int subCategoryID = Convert.ToInt32(ddlSubcategory.SelectedValue);
            int secondSubcatID = Convert.ToInt32(ddl2ndSubCategory.SelectedValue);

            using (BC_Corporate_ProductProfile bcProductProfile = new BC_Corporate_ProductProfile())
            {

                DataTable dtModel = bcProductProfile.LoadList_Model(categoryID, subCategoryID, secondSubcatID);
                if (dtModel.Rows.Count > 0)
                {
                    ddlModel.Items.Clear();
                    ddlModel.Items.Add(new ListItem("Select Model", "-1"));
                    ddlModel.DataSource = dtModel;
                    ddlModel.DataValueField = "ProductModelID";
                    ddlModel.DataTextField = "ProductModel";
                    ddlModel.DataBind();
                }
                else
                {
                    ddlModel.Items.Clear();
                    ddlModel.Items.Add(new ListItem("Select Model", "-1"));
                    ddlModel.DataSource = null;
                    ddlModel.DataBind();
                    lblSystemMessage.Text = UTLUtilities.ShowGeneralMessage("No Model available");
                }

            }
        }
        catch (Exception Exp)
        {
            lblSystemMessage.Text = Exp.Message.ToString();
        }
    }




    #endregion LOAD METHODS

    #region SKU RELATED METHODS
    /// <summary>
    /// Gets the last SKU(Profile specific) from Product_Seller_Detail table.
    /// USP: USP_CP_Public_GetLastSKU
    /// </summary>
    /// <param name="intProfileID"></param>
    /// <returns></returns>
    private string Get_Last_ProfileSpecificSKU(int intProfileID, bool sellerType)
    {
        string strLastSku = null;
        DataTable dt = new DataTable();
        try
        {
            using (BC_Book bc_Book = new BC_Book())
            {
                dt = bc_Book.Get_Last_ProfileSpecificSKU(intProfileID, _ClassifiedSeller);
                if (dt.Rows.Count > 0)
                {
                    strLastSku = dt.Rows[0]["SKU"].ToString();
                    strLastSku = (string.IsNullOrEmpty(strLastSku)) ? "0" : strLastSku;
                }
            }
        }
        catch (Exception ex)
        {
            lblSystemMessage.Text = ex.Message;
        }
        return strLastSku;
    }






    /// <summary>
    /// Takes last SKU as parameter and generates new SKU for current product.
    /// USP: USP_CP_Public_GetNew_SKU.
    /// </summary>
    /// <param name="strSku"></param>
    private void Generate_ProfileSpecific_UniqueSKU(string strSku)
    {
        DataTable dt = new DataTable();
        try
        {
            using (BC_Book bc_Book = new BC_Book())
            {
                dt = bc_Book.Generate_ProfileSpecific_UniqueSKU(strSku);
                if (dt.Rows.Count > 0)
                {
                    lblSku.Text = dt.Rows[0]["SKU"].ToString();
                }
                else
                {
                    lblSystemMessage.Text = "Error in SKU generation.";
                }
            }
        }
        catch (Exception ex)
        {
            lblSystemMessage.Text = ex.Message;
        }

    }

    #endregion SKU RELATED METHODS



    #region DROPDOWNLIST EVENTS


    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCategory.SelectedValue == "7")
        {
            Response.Redirect("RealEstateAE.aspx?PageMode=0&PID=-1", true);
        }
        hfCategoryID.Value = ddlCategory.SelectedItem.Value;
        if (ddlCategory.SelectedValue == "1" || ddlCategory.SelectedValue == "8")
        {

            pnlModel.Visible = false;
            pnlModel.Enabled = false;
        }
        else
        {

            pnlModel.Visible = true;
            pnlModel.Enabled = true;
        }

        hfCategoryID.Value = ddlCategory.SelectedValue;
        intCategoryID = Convert.ToInt32(hfCategoryID.Value);
        if (hfCategoryID.Value != "-1" || ddlCategory.SelectedValue == "8")
        {
            this.LoadRecord_Subcategory(intCategoryID);
        }
        
    }

    protected void ddlSubcategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Int32.TryParse(ddlCategory.SelectedItem.Value, out intCategoryID) &&
            Int32.TryParse(ddlSubcategory.SelectedValue, out intSubcategoryID))
        {
            this.LoadRecord_2ndSubcategory(intCategoryID, intSubcategoryID);
        }
    }


    protected void ddl2ndSubCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCategory.SelectedValue != "-1" && ddlCategory.SelectedValue != "1" && ddlCategory.SelectedValue != "8" && ddlSubcategory.SelectedValue != "-1" && ddl2ndSubCategory.SelectedValue != "-1")
        {
            this.LoadList_Model();
        }
    }

    protected void ddlModel_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl2ndSubCategory.SelectedValue != "-1" && ddlModel.SelectedValue != "-1")
        {
            txtTitle.Text = ddl2ndSubCategory.SelectedItem.Text + " " + ddlModel.SelectedItem.Text;
        }
    }

    #endregion DROPDOWNLIST EVENTS


    #region BUTTON CLICK EVENTS

    protected void btnChangeCategory_Click(object sender, EventArgs e)
    {
        grvProduct.Dispose();
        grvProduct.Visible = false;

        //btnSearch.Visible = true;
        btnCheckDuplicacy.Visible = false;
        this.Enable_Search_Criteria(true);
        btnChangeCategory.Visible = false;
        btnSearch.Enabled = true;
        btnNext.Visible = false;
    }


    protected void btnSearch_Click(object sender, EventArgs e)
    {
        txtTemp.Text = hfProductID.Value;
        if (LoadList_Product())
        {
            grvProduct.Visible = true;
            btnChangeCategory.Visible = true;
        }
        else
        {

            string strDisplayMessage = "<span class=\"title\" style=\"font-size:12px\">";
            strDisplayMessage += "No results found in the Database for your search ";
            strDisplayMessage += "<strong style=\"color:Red\">\"" + txtTitle.Text + "\"</strong>";
            strDisplayMessage += ". However you can refine your search options to find a match or you can click Next to create your own";
            strDisplayMessage += " product detail.</span>";
            lblTitleMessage.Text = strDisplayMessage;
            btnNext.Visible = true;


        }
        Enable_Search_Criteria(false);

        this.Page.Header.Title += ddlCategory.SelectedItem.Text + ": " + txtTitle.Text;
    }

    protected void btnReject_Click(object sender, EventArgs e)
    {
        this.grvProduct.Dispose();
        this.grvProduct.DataSource = null;
        this.grvProduct.Visible = false;
        this.Enable_Search_Criteria(false);
        txtTitle.ReadOnly = false;
        btnCheckDuplicacy.Visible = true;
        btnSearch.Enabled = false;
        btnSearch.Visible = false;
    }

    /// <summary>
    /// Checks for Duplicate ProductTitle. It is used when the user tries to 
    /// Create his own product detail.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCheckDuplicacy_Click(object sender, EventArgs e)
    {
        string strDisplayMessage = "<span class=\"title\" style=\"font-size:12px\">";

        if (Check_IsMasterProductDuplicate())
        {
            strDisplayMessage += "Duplicate Product title exists in the database. Please change the Product title.</span> ";
            btnNext.Visible = false;

        }
        else
        {
            Enable_Search_Criteria(false);
            btnNext.Visible = true;
            btnCheckDuplicacy.Visible = false;
            strDisplayMessage += "This Product title is available. Please click Next to continue.</span> ";

        }
        lblTitleMessage.Text = strDisplayMessage;
    }


    protected void btnNext_Click(object sender, EventArgs e)
    {
        string strQueryString = "&mode=0&ci=" + GetCategoryID;
        strQueryString += "&sci=" + GetSubCategoryID;
        strQueryString += "&ssci=" + GetSecondSubcatID;
        strQueryString += "&pi=" + GetProductID;
        strQueryString += "&pfi=" + GetProfileID;
        strQueryString += "&sku=" + GetSku;
        strQueryString += "&inserttype=master";
        strQueryString += "&title=" + Server.UrlEncode(txtTitle.Text);

        strQueryString += "&c=" + Server.UrlEncode(GetCategory);
        strQueryString += "&sc=" + Server.UrlEncode(GetSubcategory);
        strQueryString += "&ssc=" + Server.UrlEncode(GetSecondSubcategory);

        if (ddlCategory.SelectedValue != "1")
        {
            strQueryString += "&modelkey=" + ddlModel.SelectedValue;
            strQueryString += "&model=" + Server.UrlEncode(GetProductModel);
        }


        Response.Redirect("ProductProfileAE.aspx?" + strQueryString, false);
    }



    #endregion BUTTON CLICK EVENTS


    

    #region GRID EVENTS
    protected void grvProduct_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grvProduct.PageIndex = e.NewPageIndex;
            this.LoadList_Product();
        }
        catch (Exception Exp)
        {
            Response.Write(Exp.Message.ToString());
        }
    }


    protected void grvProduct_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "SelectProduct")
        {
            string strProductID = grvProduct.DataKeys[int.Parse(e.CommandArgument.ToString())].Values[0].ToString();
            //string strTagSellerProfileID = grvProduct.DataKeys[int.Parse(e.CommandArgument.ToString())].Values[0].ToString();
            strProductTitle = grvProduct.DataKeys[int.Parse(e.CommandArgument.ToString())].Values[1].ToString();
            string strSecondSubcatID = grvProduct.DataKeys[int.Parse(e.CommandArgument.ToString())].Values[2].ToString();
            SecondSubcatID = Convert.ToInt32(strSecondSubcatID);
            intCategoryID = Convert.ToInt32(ddlCategory.SelectedValue);

            hfProductID.Value = strProductID;
            hfProductTitle.Value = strProductTitle;
            Int32.TryParse(strProductID, out intProductID);

            if (!Is_Seller_Tagged_Once(intProductID, intProfileID, _ClassifiedSeller, intCategoryID))
            {
                this.Enable_Search_Criteria(false);
                lblSystemMessage.Text = "";
                string strQueryString = "&mode=0&ci=" + GetCategoryID;
                strQueryString += "&sci=" + GetSubCategoryID;
                strQueryString += "&ssci=" + SecondSubcatID;
                strQueryString += "&pi=" + GetProductID;
                strQueryString += "&pfi=" + GetProfileID;
                strQueryString += "&sku=" + GetSku;
                //strQueryString += "&st=" + _ClassifiedSeller.ToString();
                strQueryString += "&inserttype=tag";
                strQueryString += "&title=" + strProductTitle;

                strQueryString += "&c=" + GetCategory;
                strQueryString += "&sc=" + GetSubcategory;
                strQueryString += "&ssc=" + GetSecondSubcategory;

                if (ddlCategory.SelectedValue != "1")
                {
                    strQueryString += "&modelkey=" + ddlModel.SelectedValue;
                    strQueryString += "&model=" + Server.UrlEncode(GetProductModel);

                }

                Response.Redirect("ProductProfileAE.aspx?" + strQueryString);

            }
            else
            {
                string strDisplayMessage = "<span class=\"title\" style=\"font-size:12px\">";
                strDisplayMessage += "You already tagged this <strong style=\"color:Red\">\"" + txtTitle.Text + "\"</strong> once. ";
                strDisplayMessage += "Please select another " + ddlCategory.SelectedItem.Text + ".";
                lblTitleMessage.Text = strDisplayMessage;

                //lblTitleMessage.Text = "You already tagged this product once. Please select another product or refine your search criteria.";
                lblTitleMessage.Focus();
            }
        }
    }


    #endregion GRID EVENTS

    #region MISC METHODS

    /// <summary>
    /// Disables three category ddl and title textbox.
    /// </summary>
    /// <param name="isEnable">if false disables the Categories.</param>
    private void Enable_Search_Criteria(bool isEnable)
    {
        ddlCategory.Enabled = isEnable;
        ddlSubcategory.Enabled = isEnable;
        ddl2ndSubCategory.Enabled = isEnable;
        ddlModel.Enabled = isEnable;

        btnSearch.Visible = isEnable;
        txtTitle.ReadOnly = !isEnable;
        btnChangeCategory.Visible = !isEnable;
    }


    /// <summary>
    /// Returns true if Master seller's given product title already exists.
    /// </summary>
    private bool Check_IsMasterProductDuplicate()
    {
        bool blnFlag = true;
        if (Int32.TryParse(ddlCategory.SelectedValue, out intCategoryID) && Int32.TryParse(ddlSubcategory.SelectedValue, out intSubcategoryID)
            && Int32.TryParse(ddl2ndSubCategory.SelectedValue, out intSecondSubcatID))
        {
            try
            {
                using (BC_Product bcProduct = new BC_Product())
                {
                    if (ddlCategory.SelectedValue != "1")
                    {
                        int _ProductModelID = Convert.ToInt32(ddlModel.SelectedValue);
                        blnFlag = bcProduct.IsMaster_OtherTitle_Dupllicate(intCategoryID, intSubcategoryID, intSecondSubcatID, _ProductModelID, txtTitle.Text);
                    }
                    else
                    {
                        blnFlag = bcProduct.IsMaster_ProductTitle_Dupllicate(intCategoryID, intSubcategoryID, intSecondSubcatID, txtTitle.Text);
                    }

                }
            }
            catch (Exception ex)
            {
                lblSystemMessage.Text = ex.Message;
            }
        }
        return blnFlag;
    }

    /// <summary>
    /// Returns true if Tag seller already tagged this product.
    /// </summary>
    /// <returns></returns>
    private bool Is_Seller_Tagged_Once(int intProductID, int intProfileID, bool sellerType, int intCategoryID)
    {
        bool blnFlag = false;
        try
        {
            using (BC_Product bcProduct = new BC_Product())
            {
                blnFlag = bcProduct.Is_Seller_Tagged_Once(intProfileID, intProductID, sellerType, intCategoryID);
            }
        }
        catch (Exception ex)
        {
            lblSystemMessage.Text = ex.Message;
        }
        return blnFlag;
    }

    #endregion MISC METHODS


    #region PAGE LOAD EVENTS

    protected void Page_Load(object sender, EventArgs e)
    {
        UTLUtilities.CL_ActiveModule = 7;
        this.CheckUserSession();
        this.Page.Header.Title = "www.apnerdeal.com ";
        this.CheckQueryString();
        if (!Page.IsPostBack)
        {
            
            string strSku = this.Get_Last_ProfileSpecificSKU(intProfileID, _ClassifiedSeller);
            this.Generate_ProfileSpecific_UniqueSKU(strSku);
            this.LoadRecord_Category();
            if (CategoryID > 0 && SubcategoryID > 0)
            {
                ddlCategory.SelectedValue = CategoryID.ToString();
                this.LoadRecord_Subcategory(CategoryID);
                ddlSubcategory.SelectedValue = SubcategoryID.ToString();
                this.LoadRecord_2ndSubcategory(CategoryID, SubcategoryID);

                if (CategoryID == 1 || CategoryID == 8)
                {
                    pnlModel.Visible = false;
                    pnlModel.Enabled = false;
                }
                else
                {

                    pnlModel.Visible = true;
                    pnlModel.Enabled = true;
                } 

            }
        }
    }

    #endregion PAGE LOAD EVENTS

    #region  INSERT METHODS


    /// <summary>
    /// Insert Product Model
    /// </summary>
    /// <param name="_ProductModel"></param>
    /// <param name="_ProductModelID"></param>
    /// <param name="_CategoryID"></param>
    /// <param name="_SubcategoryID"></param>
    /// <param name="_SecondSubcatID"></param>
    /// <returns></returns>

    private bool InsertProductModel(string _ProductModel, int _CategoryID, int _SubcategoryID, int _SecondSubcatID)
    {
        int _ActionResult = -1;

        try
        {
            using (BOC_ProductModelHandler handler = new BOC_ProductModelHandler())
            {
                EOC_PropertyBean eocpropertyBean = new EOC_PropertyBean();
                eocpropertyBean.ProductModel = _ProductModel;

                eocpropertyBean.Category_CategoryID = _CategoryID;
                eocpropertyBean.Subcategory_SubcategoryID = _SubcategoryID;
                eocpropertyBean.SecondSubcatID = _SecondSubcatID;

                if (!handler.BeforeInsert_IsProductModel_Duplicate(eocpropertyBean))
                {
                    _ActionResult = handler.InsertRecord_ProductModel(eocpropertyBean);
                    lblSystemMessage.Text = _ActionResult > 0 ? "Successfully inserted." : "Error occured while inserting";

                }
                else
                {
                    lblSystemMessage.Text = "Duplication occured,please select properly.";
                }

            }
        }
        catch (Exception ex)
        {
            lblSystemMessage.Text = ex.Message;
        }

        return _ActionResult > 0 ? true : false;
    }

    #endregion  INSERT METHODS


    private bool IsAuthenticated()
    {
        return true;
    }
    protected void addModel1_Click(object sender, EventArgs e)
    {

        if (ddlCategory.SelectedValue != "-1" && ddlSubcategory.SelectedValue != "-1" && ddl2ndSubCategory.SelectedValue != "-1")
        {
            this.LoadList_Model();
            Enable_Panel(modelPanel, true);
            lblMessage.Text = " ";

        }
        else if (ddlCategory.SelectedValue != "-1" && ddlSubcategory.SelectedValue != "-1")
        {

            lblMessage.Text = "Please select second subcategory ";

            Enable_Panel(modelPanel, false);

        }
        else if (ddlSubcategory.SelectedValue != "-1" && ddl2ndSubCategory.SelectedValue != "-1")
        {
            lblMessage.Text = "Please select category ";

            Enable_Panel(modelPanel, false);
        }
        else if (ddl2ndSubCategory.SelectedValue != "-1" && ddlCategory.SelectedValue != "-1")
        {
            lblMessage.Text = "Please select subcategory ";

            Enable_Panel(modelPanel, false);
        }
        else
        {
            lblMessage.Text = "Please select all category ";
        }


    }
    protected void submitButton_Click(object sender, EventArgs e)
    {

        bool isSuccess = false;
        if (IsAuthenticated())
        {

            if (Mode == PageMode.InsertMode)
            {
                isSuccess = this.InsertProductModel(txtProductModel.Text, Convert.ToInt32(ddlCategory.SelectedValue),
                    Convert.ToInt32(ddlSubcategory.SelectedValue), Convert.ToInt32(ddl2ndSubCategory.SelectedValue));
                Enable_Panel(modelPanel, false);
                ddlModel.Items.Clear();
                this.LoadList_Model();
                ddlModel.DataBind();

            }
            else
            {
                lblSystemMessage.Text = "Mode not selected";
            }



        }
        else
        {
            lblSystemMessage.Text = "Session expired. Please login to make any change";
        }


    }
    protected void close_Click(object sender, EventArgs e)
    {
        
        Enable_Panel(modelPanel, false);
    }
}
