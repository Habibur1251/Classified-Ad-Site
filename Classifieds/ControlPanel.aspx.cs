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

public partial class Classifieds_ControlPanel : System.Web.UI.Page
{
    private int intProfileID = -1;
    private int intCountryID = -1;
    private bool _ClassifiedUser = false;
    private bool isAdmin = false;
    private int intProductID = -1;
    private int intCategoryID = -1;
    private string strProductID = string.Empty;
    private string strCategoryID = string.Empty;
    private string strProfileID = string.Empty;
    private bool success = true;

    protected string TotalActiveProductAds
    {
        get
        {
            object obj = ViewState["TotalActiveProductAds"];
            if (obj != null)
            {
                return obj.ToString();
            }
            return "";
        }
        set
        {
            ViewState["TotalActiveProductAds"] = value;
        }
    }

    protected string TotalInActiveProductAds
    {
        get
        {
            object obj = ViewState["TotalInActiveProductAds"];
            if (obj != null)
            {
                return obj.ToString();
            }
            return "";
        }
        set
        {
            ViewState["TotalInActiveProductAds"] = value;
        }
    }

    public enum FilterType
    {
        ByCategory,
        ByDateRange,
        All,
        ActiveProduct,
        InactiveProduct
    }

    public enum FilterTypeClassified
    {
        ClassifiedByCategory,
        ClassifiedByDateRange,
        ClassifiedAll
    }



    public FilterType Filter
    {
        get
        {
            object obj = ViewState["Filter"];
            if (obj != null)
            {
                return (FilterType)obj;
            }
            return FilterType.ByCategory;

        }
        set
        {
            ViewState["Filter"] = value;
        }
    }

    public FilterTypeClassified FilterClassified
    {
        get
        {
            object obj = ViewState["Filter"];
            if (obj != null)
            {
                return (FilterTypeClassified)obj;
            }
            return FilterTypeClassified.ClassifiedAll;

        }
        set
        {
            ViewState["Filter"] = value;
        }
    }



    protected int Total_Record
    {
        get
        {
            object obj = ViewState["Total_Record"];
            if (obj != null)
            {
                return (int)obj;
            }
            return 0;
        }
        set { ViewState["Total_Record"] = value; }
    }

    protected int ProductModelID
    {
        get
        {
            object obj = ViewState["ProductModelID"];
            if (obj != null)
            {
                return (int)obj;
            }
            return 0;
        }

        set { ViewState["ProductModelID"] = value; }
    }



    protected string ProductModel
    {
        get
        {
            object obj = ViewState["ProductModel"];
            if (obj != null)
            {
                return (string)obj;
            }
            return "";
        }

        set { ViewState["ProductModel"] = value; }
    }


    private void CheckUserSession()
    {
        if (this.Session["CLSF_PROFILE_CODE"] != null && this.Session["CLSF_COUNTRY_CODE"] != null && this.Session["IS_ADMIN"] != null)
        {
            intProfileID = Convert.ToInt32(this.Session["CLSF_PROFILE_CODE"].ToString());
            intCountryID = Convert.ToInt32(this.Session["CLSF_COUNTRY_CODE"].ToString());
            isAdmin = Convert.ToBoolean(this.Session["IS_ADMIN"].ToString());
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
    }

    private string DisplayEmptyMessage(string strMessage)
    {
        string strHtml = "";
        strHtml = "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" align=\"center\" style=\"width:606px; background-color:#3B5998;\">";
        strHtml += "<tr>";
        strHtml += "<td align=\"center\" style=\"height:45px; color:#FFFFFF; font-size:14px; font-weight:bold;\" valign=\"middle\">";
        strHtml += "<span class=\"title\" style=\"font-size:14px;\">";
        strHtml += "</span>" + strMessage;
        strHtml += "</td>";
        strHtml += "</tr>";
        strHtml += "</table>";
        return strHtml;
    }

    /// <summary>
    /// Loads Corporate Category.
    /// </summary>
    /// <param name="intCountryID"></param>
    private void LoadList_Category(int intCountryID)
    {
        //try
        //{
        //    using (BC_Corporate_ProductProfile bcProductProfile = new BC_Corporate_ProductProfile())
        //    {

        //        DataTable dtCategory = bcProductProfile.LoadRecord_Category(intCountryID);
        //        if (dtCategory.Rows.Count > 0)
        //        {

        //            ddlCategory.DataSource = dtCategory;
        //            ddlCategory.DataValueField = "CategoryID";
        //            ddlCategory.DataTextField = "Category";
        //            ddlCategory.DataBind();
        //        }
        //        else
        //        {
        //            lblCorporateMessage.Text = "No Category available";
        //        }

        //    }
        //}
        //catch (Exception Exp)
        //{
        //    lblCorporateMessage.Text = Exp.Message.ToString();
        //}
    }

    /// <summary>
    /// Loads all Corporate posted products.
    /// </summary>



    private void Load_CL_Categories()
    {
        try
        {
            using (BC_Product bcProductProfile = new BC_Product())
            {

                DataTable dt = bcProductProfile.Load_CL_Categories();
                if (dt.Rows.Count > 0)
                {

                    ddlClassifiedCategory.DataSource = dt;
                    ddlClassifiedCategory.DataValueField = "CategoryID";
                    ddlClassifiedCategory.DataTextField = "Category";
                    ddlClassifiedCategory.DataBind();
                }
                else
                {
                    //lblCorporateMessage.Text = "No Category available";
                }

            }
        }
        catch (Exception Exp)
        {
            //lblCorporateMessage.Text = Exp.Message.ToString();
        }
    }

    private void LoadList_PostedClassifiedProductByCategory(int intCategoryID)
    {
        try
        {
            using (BC_Product bc = new BC_Product())
            {
                DataTable dt = new DataTable();
                dt = bc.GetList_CL_PostedProductByCategory(intProfileID, intCategoryID);
                if (dt.Rows.Count > 0)
                {
                    grvClassifiedProduct.DataSource = dt;
                    grvClassifiedProduct.DataBind();
                }
                else
                {
                    grvClassifiedProduct.DataSource = null;
                    grvClassifiedProduct.DataBind();

                    lblClassifiedMessage.Text = "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" align=\"center\" style=\"width:606px; background-color:#3B5998;\">";
                    lblClassifiedMessage.Text += "<tr>";
                    lblClassifiedMessage.Text += "<td align=\"center\" style=\"height:45px; color:#FFFFFF; font-size:14px; font-weight:bold;\" valign=\"middle\">";
                    lblClassifiedMessage.Text += "<span class=\"title\" style=\"font-size:14px;\">";
                    lblClassifiedMessage.Text += "</span> You have not posted any Classified Ads yet.";
                    lblClassifiedMessage.Text += "</td>";
                    lblClassifiedMessage.Text += "</tr>";
                    lblClassifiedMessage.Text += "</table>";
                    //lblClassifiedMessage.Text = "You have not posted any Classified Ads yet.";
                }

            }
        }
        catch (Exception ex)
        {
            //lblCorporateMessage.Text = ex.Message.ToString();
        }
    }


    private void LoadList_PostedAllProduct()
    {
        //try
        //{
        //    using (BC_Product bc = new BC_Product())
        //    {
        //        DataTable dt = new DataTable();
        //        dt = bc.GetList_BS_PostedAllUserProduct(intProfileID);

        //        if (dt.Rows.Count > 0)
        //        {

        //            AllAdsGridView.DataSource = dt;
        //            AllAdsGridView.DataBind();
        //            Total_Record = dt.Rows.Count;
        //        }
        //        else
        //        {
        //            AllAdsGridView.DataSource = null;
        //            AllAdsGridView.DataBind();

        //            lblClassifiedMessage.Text = "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" align=\"center\" style=\"width:606px; background-color:#3B5998;\">";
        //            lblClassifiedMessage.Text += "<tr>";
        //            lblClassifiedMessage.Text += "<td align=\"center\" style=\"height:45px; color:#FFFFFF; font-size:14px; font-weight:bold;\" valign=\"middle\">";
        //            lblClassifiedMessage.Text += "<span class=\"title\" style=\"font-size:14px;\">";
        //            lblClassifiedMessage.Text += "</span> You have not posted any Product Ads yet.";
        //            lblClassifiedMessage.Text += "</td>";
        //            lblClassifiedMessage.Text += "</tr>";
        //            lblClassifiedMessage.Text += "</table>";
        //            lblClassifiedMessage.Text = UTLUtilities.ShowGeneralMessageCP("No Ad posted");
        //        }

        //    }
        //}
        //catch (Exception ex)
        //{
        //    lblCorporateMessage.Text = ex.Message.ToString();
        //}
    }


    private void LoadList_PostedProductByDateRange(DateTime startDate, DateTime endTime)
    {
        //try
        //{
        //    using (BC_Product bc = new BC_Product())
        //    {
        //        DataTable dt = new DataTable();
        //        dt = bc.GetList_BS_PostedProductByDateRange(intProfileID, startDate, endTime);
        //        if (dt.Rows.Count > 0)
        //        {

        //            AllAdsGridView.DataSource = dt;
        //            AllAdsGridView.DataBind();
        //            Total_Record = dt.Rows.Count;
        //        }
        //        else
        //        {
        //            AllAdsGridView.DataSource = null;
        //            AllAdsGridView.DataBind();

        //            lblCorporateMessage.Text = "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" align=\"center\" style=\"width:606px; background-color:#3B5998;\">";
        //            lblCorporateMessage.Text += "<tr>";
        //            lblCorporateMessage.Text += "<td align=\"center\" style=\"height:45px; color:#FFFFFF; font-size:14px; font-weight:bold;\" valign=\"middle\">";
        //            lblCorporateMessage.Text += "<span class=\"title\" style=\"font-size:14px;\">";
        //            lblCorporateMessage.Text += "</span> You have not posted any Product Ads yet.";
        //            lblCorporateMessage.Text += "</td>";
        //            lblCorporateMessage.Text += "</tr>";
        //            lblCorporateMessage.Text += "</table>";
        //            lblCorporateMessage.Text = UTLUtilities.ShowGeneralMessageCP("No Ad posted on this Date Range.");
        //        }

        //    }
        //}
        //catch (Exception ex)
        //{
        //    lblCorporateMessage.Text = ex.Message.ToString();
        //}
    }



    private void LoadList_PostedProductByCategory(int intCategoryID)
    {
        //try
        //{
        //    using (BC_Product bc = new BC_Product())
        //    {
        //        DataTable dt = new DataTable();
        //        dt = bc.GetList_BS_PostedProductByCategory(intProfileID, intCategoryID);
        //        if (dt.Rows.Count > 0)
        //        {

        //            AllAdsGridView.DataSource = dt;
        //            AllAdsGridView.DataBind();
        //            Total_Record = dt.Rows.Count;
        //        }
        //        else
        //        {
        //            AllAdsGridView.DataSource = null;
        //            AllAdsGridView.DataBind();

        //            lblCorporateMessage.Text = "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" align=\"center\" style=\"width:606px; background-color:#3B5998;\">";
        //            lblCorporateMessage.Text += "<tr>";
        //            lblCorporateMessage.Text += "<td align=\"center\" style=\"height:45px; color:#FFFFFF; font-size:14px; font-weight:bold;\" valign=\"middle\">";
        //            lblCorporateMessage.Text += "<span class=\"title\" style=\"font-size:14px;\">";
        //            lblCorporateMessage.Text += "</span> No Ad posted on this category.";
        //            lblCorporateMessage.Text += "</td>";
        //            lblCorporateMessage.Text += "</tr>";
        //            lblCorporateMessage.Text += "</table>";
        //            lblCorporateMessage.Text = UTLUtilities.ShowGeneralMessageCP("No Ad posted on this category.");
        //        }

        //    }
        //}
        //catch (Exception ex)
        //{
        //    lblCorporateMessage.Text = ex.Message.ToString();
        //}
    }


    private void LoadList_PostedAllActiveProductCounter()
    {
        try
        {
            using (BC_Product bc = new BC_Product())
            {
                DataTable dt = new DataTable();
                dt = bc.GetList_BS_PostedAllUserActiveProductCount(intProfileID);

                if (dt.Rows.Count > 0)
                {
                    TotalActiveProductAds = dt.Rows[0]["AllActiveAdd"].ToString();
                }
                else
                {
                    TotalActiveProductAds = "0";
                }

            }
        }
        catch (Exception ex)
        {
            //lblCorporateMessage.Text = ex.Message.ToString();
        }
    }

    private void LoadList_PostedAllInActiveProductCounter()
    {
        try
        {
            using (BC_Product bc = new BC_Product())
            {
                DataTable dt = new DataTable();
                dt = bc.GetList_BS_PostedAllUserInActiveProductCount(intProfileID);

                if (dt.Rows.Count > 0)
                {
                    TotalInActiveProductAds = dt.Rows[0]["AllActiveAdd"].ToString();
                }
                else
                {
                    TotalInActiveProductAds = "0";
                }

            }
        }
        catch (Exception ex)
        {
            //lblCorporateMessage.Text = ex.Message.ToString();
        }
    }

    private void LoadList_PostedAllActiveProduct()
    {
        //try
        //{
        //    using (BC_Product bc = new BC_Product())
        //    {
        //        DataTable dt = new DataTable();
        //        dt = bc.GetList_BS_PostedAllUserActiveProductList(intProfileID);

        //        if (dt.Rows.Count > 0)
        //        {

        //            AllAdsGridView.DataSource = dt;
        //            AllAdsGridView.DataBind();
        //            Total_Record = dt.Rows.Count;
        //        }
        //        else
        //        {
        //            AllAdsGridView.DataSource = null;
        //            AllAdsGridView.DataBind();

        //            lblCorporateMessage.Text = "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" align=\"center\" style=\"width:606px; background-color:#3B5998;\">";
        //            lblCorporateMessage.Text += "<tr>";
        //            lblCorporateMessage.Text += "<td align=\"center\" style=\"height:45px; color:#FFFFFF; font-size:14px; font-weight:bold;\" valign=\"middle\">";
        //            lblCorporateMessage.Text += "<span class=\"title\" style=\"font-size:14px;\">";
        //            lblCorporateMessage.Text += "</span> You have not posted any Corporate Ads yet.";
        //            lblCorporateMessage.Text += "</td>";
        //            lblCorporateMessage.Text += "</tr>";
        //            lblCorporateMessage.Text += "</table>";
        //            lblCorporateMessage.Text = UTLUtilities.ShowGeneralMessageCP("No Of Active Ad Zero");
        //        }

        //    }
        //}
        //catch (Exception ex)
        //{
        //    lblCorporateMessage.Text = ex.Message.ToString();
        //}
    }

    private void LoadList_PostedAllInActiveProduct()
    {
        //try
        //{
        //    using (BC_Product bc = new BC_Product())
        //    {
        //        DataTable dt = new DataTable();
        //        dt = bc.GetList_BS_PostedAllUserInActiveProductList(intProfileID);

        //        if (dt.Rows.Count > 0)
        //        {

        //            AllAdsGridView.DataSource = dt;
        //            AllAdsGridView.DataBind();
        //            Total_Record = dt.Rows.Count;
        //        }
        //        else
        //        {
        //            AllAdsGridView.DataSource = null;
        //            AllAdsGridView.DataBind();

        //            lblCorporateMessage.Text = "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" align=\"center\" style=\"width:606px; background-color:#3B5998;\">";
        //            lblCorporateMessage.Text += "<tr>";
        //            lblCorporateMessage.Text += "<td align=\"center\" style=\"height:45px; color:#FFFFFF; font-size:14px; font-weight:bold;\" valign=\"middle\">";
        //            lblCorporateMessage.Text += "<span class=\"title\" style=\"font-size:14px;\">";
        //            lblCorporateMessage.Text += "</span> You have not posted any Corporate Ads yet.";
        //            lblCorporateMessage.Text += "</td>";
        //            lblCorporateMessage.Text += "</tr>";
        //            lblCorporateMessage.Text += "</table>";
        //            lblCorporateMessage.Text = UTLUtilities.ShowGeneralMessageCP("No Of Inactive Ad Zero");
        //        }

        //    }
        //}
        //catch (Exception ex)
        //{
        //    lblCorporateMessage.Text = ex.Message.ToString();
        //}
    }

    protected void ToatlActiveProduct_Click(object sender, EventArgs e)
    {
        this.LoadList_PostedAllActiveProduct();
        this.LoadList_PostedAllActiveProductCounter();
        this.LoadList_PlacedOrder_Corporate_Product();
        Filter = FilterType.ActiveProduct;
        this.SetGridView_PageIndex();
    }

    protected void ToatlInActiveProduct_Click(object sender, EventArgs e)
    {
        this.LoadList_PostedAllInActiveProduct();
        this.LoadList_PostedAllInActiveProductCounter();
        this.LoadList_PlacedOrder_Corporate_Product();
        Filter = FilterType.InactiveProduct;
        this.SetGridView_PageIndex();
    }


    private void UpdateActivationStatus(int ProductID, int CategoryID, int ProfileID)
    {
        //try
        //{
        //    using (BC_Product bcProduct = new BC_Product())
        //    {
        //        int efectedRow = bcProduct.Update_ActivationStatus(CategoryID, ProductID, ProfileID);

        //        if (efectedRow > 0)
        //        {
        //            if (Filter == FilterType.ByDateRange)
        //            {
        //                this.LoadList_PostedProductByDateRange(Convert.ToDateTime(txtStartDate.Text), Convert.ToDateTime(txtEndDate.Text));
        //                this.LoadList_PostedAllActiveProductCounter();
        //                this.LoadList_PostedAllInActiveProductCounter();

        //            }
        //            else if (ddlCategory.SelectedValue != "-1" && Filter == FilterType.All)
        //            {
        //                this.LoadList_PostedAllProduct();
        //                this.LoadList_PostedAllActiveProductCounter();
        //                this.LoadList_PostedAllInActiveProductCounter();
        //            }
        //            else if (Filter == FilterType.ByCategory && ddlCategory.SelectedValue != "-1")
        //            {
        //                this.LoadList_PostedProductByCategory(Convert.ToInt32(ddlCategory.SelectedValue.ToString()));
        //                this.LoadList_PostedAllActiveProductCounter();
        //                this.LoadList_PostedAllInActiveProductCounter();
        //            }
        //            else if (Filter == FilterType.ActiveProduct)
        //            {
        //                this.LoadList_PostedAllActiveProduct();
        //                this.LoadList_PostedAllActiveProductCounter();
        //                this.LoadList_PostedAllInActiveProductCounter();
        //            }
        //            else if (Filter == FilterType.InactiveProduct)
        //            {
        //                this.LoadList_PostedAllInActiveProduct();
        //                this.LoadList_PostedAllActiveProductCounter();
        //                this.LoadList_PostedAllInActiveProductCounter();
        //            }
        //            else
        //            {
        //                this.LoadList_PostedAllProduct();
        //                this.LoadList_PostedAllActiveProductCounter();
        //                this.LoadList_PostedAllInActiveProductCounter();
        //            }
        //        }

        //    }

        //}
        //catch (Exception Exp)
        //{
        //    lblCorporateMessage.Text = "Error: " + Exp.Message;
        //}
    }


    private void UpdateActivationStatusClassified(int ProductID)
    {
        try
        {
            using (BC_Product bcProduct = new BC_Product())
            {
                int efectedRow = bcProduct.Update_ActivationStatusClassified(ProductID);

                if (efectedRow > 0)
                {
                    if (FilterClassified == FilterTypeClassified.ClassifiedByDateRange)
                    {
                        this.LoadList_Posted_ClassifiedProduct(Convert.ToDateTime(txtFromDate.Text), Convert.ToDateTime(txtToDate.Text));

                    }
                    else if (FilterClassified == FilterTypeClassified.ClassifiedAll && ddlClassifiedCategory.SelectedValue != "-1")
                    {
                        this.LoadList_Posted_AllClassifiedProduct();
                    }
                    else if (FilterClassified == FilterTypeClassified.ClassifiedByCategory && ddlClassifiedCategory.SelectedValue != "-1")
                    {
                        this.LoadList_PostedClassifiedProductByCategory(Convert.ToInt32(ddlClassifiedCategory.SelectedValue.ToString()));
                    }

                    else
                    {
                        this.LoadList_Posted_AllClassifiedProduct();
                    }
                }

            }

        }
        catch (Exception Exp)
        {
            //lblCorporateMessage.Text = "Error: " + Exp.Message;
        }
    }

    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (ddlCategory.SelectedValue != "-1" && ddlCategory.SelectedValue == "189")
        //{
        //    this.LoadList_PostedAllProduct();
        //    Filter = FilterType.All;
        //    this.SetGridView_PageIndex();
        //}
        //else if (ddlCategory.SelectedValue != "-1")
        //{
        //    this.LoadList_PostedProductByCategory(Convert.ToInt32(ddlCategory.SelectedValue.ToString()));
        //    Filter = FilterType.ByCategory;
        //    this.SetGridView_PageIndex();
        //}
        //else
        //{
        //    this.LoadList_PostedAllProduct();
        //}
    }


    protected void ddlClassifiedCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlClassifiedCategory.SelectedValue != "-1" && ddlClassifiedCategory.SelectedValue == "190")
        {
            this.LoadList_Posted_AllClassifiedProduct();
            FilterClassified = FilterTypeClassified.ClassifiedAll;
            this.SetGridView_PageIndex();
        }
        else if (ddlClassifiedCategory.SelectedValue != "-1")
        {
            this.LoadList_PostedClassifiedProductByCategory(Convert.ToInt32(ddlClassifiedCategory.SelectedValue.ToString()));
            FilterClassified = FilterTypeClassified.ClassifiedByCategory;
            this.SetGridView_PageIndex();
        }
        else
        {
            this.LoadList_Posted_AllClassifiedProduct();
        }
    }

    protected void ActiveInactive_Click(object sender, EventArgs e)
    {

        LinkButton lbtnChange = (LinkButton)sender;

        string info = lbtnChange.CommandArgument;

        string[] arg = new string[3];

        char[] splitter = { ';' };

        arg = info.Split(splitter);

        //string SKU = e.CommandArgument.ToString();

        string SKU = arg[0];

        string ProductID = arg[1];

        string CategoryID = arg[2];

        string ProfileID = arg[3];

        this.UpdateActivationStatus(Convert.ToInt32(ProductID), Convert.ToInt32(CategoryID), Convert.ToInt32(ProfileID));
    }

    protected void ActiveInactiveClasiified_Click(object sender, EventArgs e)
    {

        LinkButton lbtnChangeClassifeid = (LinkButton)sender;

        string info = lbtnChangeClassifeid.CommandArgument;

        string[] arg = new string[3];

        char[] splitter = { ';' };

        arg = info.Split(splitter);

        //string SKU = e.CommandArgument.ToString();

        string ProductID = arg[0];

        string ProductTile = arg[1];

        string CategoryID = arg[2];

        this.UpdateActivationStatusClassified(Convert.ToInt32(ProductID));
    }


    protected void saveChangeInner(object sender, EventArgs e)
    {
        //int rowsCount = AllAdsGridView.Rows.Count;
        //GridViewRow gridRow;
        //TextBox priceTextBox;
        //TextBox qtyTextBox;
        //int Qty;
        //int yourPrice;

        //for (int i = 0; i < rowsCount; i++)
        //{
        //    gridRow = AllAdsGridView.Rows[i];
        //    strProductID = AllAdsGridView.DataKeys[i]["ProductID"].ToString();
        //    strCategoryID = AllAdsGridView.DataKeys[i]["CategoryID"].ToString();
        //    strProfileID = AllAdsGridView.DataKeys[i]["ProfileID"].ToString();
        //    priceTextBox = (TextBox)gridRow.FindControl("priceTextBox");
        //    qtyTextBox = (TextBox)gridRow.FindControl("qtyTextBox");

        //    if (Int32.TryParse(strProductID, out intProductID) && Int32.TryParse(strProfileID, out intProfileID) && Int32.TryParse(strCategoryID, out intCategoryID) && Int32.TryParse(priceTextBox.Text, out yourPrice) && Int32.TryParse(qtyTextBox.Text, out Qty))
        //    {
        //        try
        //        {
        //            using (BC_Product bcProduct = new BC_Product())
        //            {
        //                success = success && bcProduct.Update_ProductPriceStatus(intCategoryID, intProductID, intProfileID, yourPrice);
        //                success = success && bcProduct.Update_ProductQtyStatus(intCategoryID, intProductID, intProfileID, Qty);

        //            }

        //        }
        //        catch (Exception ex)
        //        {
        //            success = false;
        //            lblCorporateMessage.Text = UTLUtilities.ShowErrorMessage("Error:" + ex.Message);
        //        }

        //    }
        //    else
        //    {
        //        success = false;
        //    }


        //    lblCorporateMessage.Text = success ?
        //         UTLUtilities.ShowSuccessMessage("<br />Your Products Ads were successfully updated!<br />") :
        //         UTLUtilities.ShowGeneralMessageCP("<br />Some Price or quantity updates failed! Please verify your Ads List!<br />");
        //}

        //if (Filter == FilterType.ByDateRange)
        //{
        //    this.LoadList_PostedProductByDateRange(Convert.ToDateTime(txtStartDate.Text), Convert.ToDateTime(txtEndDate.Text));

        //}
        //else if (ddlCategory.SelectedValue != "-1" && Filter == FilterType.All)
        //{
        //    this.LoadList_PostedAllProduct();
        //}
        //else if (Filter == FilterType.ByCategory && ddlCategory.SelectedValue != "-1")
        //{
        //    this.LoadList_PostedProductByCategory(Convert.ToInt32(ddlCategory.SelectedValue.ToString()));
        //}
        //else if (Filter == FilterType.ActiveProduct)
        //{
        //    this.LoadList_PostedAllActiveProduct();
        //}
        //else if (Filter == FilterType.InactiveProduct)
        //{
        //    this.LoadList_PostedAllInActiveProduct();
        //}
        //else if (Filter == FilterType.ActiveProduct)
        //{
        //    this.LoadList_PostedAllActiveProduct();
        //}
        //else if (Filter == FilterType.InactiveProduct)
        //{
        //    this.LoadList_PostedAllInActiveProduct();
        //}
        //else
        //{
        //    this.LoadList_PostedAllProduct();
        //}
       
    }

    protected void resetvaluesButton_Click(object sender, EventArgs e)
    {

        //if (Filter == FilterType.ByDateRange)
        //{
        //    this.LoadList_PostedProductByDateRange(Convert.ToDateTime(txtStartDate.Text), Convert.ToDateTime(txtEndDate.Text));

        //}
        //else if (ddlCategory.SelectedValue != "-1" && Filter == FilterType.All)
        //{
        //    this.LoadList_PostedAllProduct();
        //}

        //else if (Filter == FilterType.ByCategory && ddlCategory.SelectedValue != "-1")
        //{
        //    this.LoadList_PostedProductByCategory(Convert.ToInt32(ddlCategory.SelectedValue.ToString()));
        //}
        //else if (Filter == FilterType.ActiveProduct)
        //{
        //    this.LoadList_PostedAllActiveProduct();
        //}
        //else if (Filter == FilterType.InactiveProduct)
        //{
        //    this.LoadList_PostedAllInActiveProduct();
        //}
        //else
        //{
        //    this.LoadList_PostedAllProduct();
        //}


    }
    protected void allAdsGridViewOnPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //try
        //{
        //    AllAdsGridView.PageIndex = e.NewPageIndex;

        //    if (Filter == FilterType.ByDateRange)
        //    {
        //        this.LoadList_PostedProductByDateRange(Convert.ToDateTime(txtStartDate.Text), Convert.ToDateTime(txtEndDate.Text));

        //    }
        //    else if (ddlCategory.SelectedValue != "-1" && Filter == FilterType.All)
        //    {
        //        this.LoadList_PostedAllProduct();
        //    }
        //    else if (Filter == FilterType.ByCategory && ddlCategory.SelectedValue != "-1")
        //    {
        //        this.LoadList_PostedProductByCategory(Convert.ToInt32(ddlCategory.SelectedValue.ToString()));
        //    }
        //    else if (Filter == FilterType.ActiveProduct)
        //    {
        //        this.LoadList_PostedAllActiveProduct();
        //    }
        //    else if (Filter == FilterType.InactiveProduct)
        //    {
        //        this.LoadList_PostedAllInActiveProduct();
        //    }
        //    else
        //    {
        //        this.LoadList_PostedAllProduct();
        //    }
          
        //}
        //catch (Exception Exp)
        //{
        //    Response.Write(Exp.Message.ToString());
        //}
    }



    /// <summary>
    /// Loads Classified Posted Product.
    /// </summary>
    private void LoadList_Posted_ClassifiedProduct(DateTime _StartDate, DateTime _EndDate)
    {
        try
        {
            using (BOC_Classifieds_ProductProfile bocProductProfile = new BOC_Classifieds_ProductProfile())
            {
                EOC_PropertyBean eocPropertyBean = new EOC_PropertyBean();
                eocPropertyBean.Classifieds_UserProfile_ProfileID = intProfileID;
                eocPropertyBean.FromDate = _StartDate;
                eocPropertyBean.ToDate = _EndDate;

                DataTable dt = bocProductProfile.LoadRecord_ProductProfile(eocPropertyBean);

                if (dt.Rows.Count > 0)
                {
                    grvClassifiedProduct.DataSource = dt;
                    grvClassifiedProduct.DataBind();
                }
                else
                {
                    grvClassifiedProduct.DataSource = null;
                    grvClassifiedProduct.DataBind();

                    lblClassifiedMessage.Text = "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" align=\"center\" style=\"width:606px; background-color:#3B5998;\">";
                    lblClassifiedMessage.Text += "<tr>";
                    lblClassifiedMessage.Text += "<td align=\"center\" style=\"height:45px; color:#FFFFFF; font-size:14px; font-weight:bold;\" valign=\"middle\">";
                    lblClassifiedMessage.Text += "<span class=\"title\" style=\"font-size:14px;\">";
                    lblClassifiedMessage.Text += "</span> You have not posted any Classified Ads yet.";
                    lblClassifiedMessage.Text += "</td>";
                    lblClassifiedMessage.Text += "</tr>";
                    lblClassifiedMessage.Text += "</table>";
                    //lblClassifiedMessage.Text = "You have not posted any Classified Ads yet.";
                }
            }
        }
        catch (Exception Exp)
        {
            //lblCorporateMessage.Text = "Error: " + Exp.Message;
        }
    }


    private void LoadList_Posted_AllClassifiedProduct()
    {
        try
        {
            using (BOC_Classifieds_ProductProfile bocProductProfile = new BOC_Classifieds_ProductProfile())
            {
                EOC_PropertyBean eocPropertyBean = new EOC_PropertyBean();
                eocPropertyBean.Classifieds_UserProfile_ProfileID = intProfileID;
                DataTable dt = bocProductProfile.LoadRecord_AllProductProfile(eocPropertyBean);

                if (dt.Rows.Count > 0)
                {
                    grvClassifiedProduct.DataSource = dt;
                    grvClassifiedProduct.DataBind();
                }
                else
                {
                    grvClassifiedProduct.DataSource = null;
                    grvClassifiedProduct.DataBind();

                    lblClassifiedMessage.Text = "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" align=\"center\" style=\"width:606px; background-color:#3B5998;\">";
                    lblClassifiedMessage.Text += "<tr>";
                    lblClassifiedMessage.Text += "<td align=\"center\" style=\"height:45px; color:#FFFFFF; font-size:14px; font-weight:bold;\" valign=\"middle\">";
                    lblClassifiedMessage.Text += "<span class=\"title\" style=\"font-size:14px;\">";
                    lblClassifiedMessage.Text += "</span> You have not posted any Classified Ads yet.";
                    lblClassifiedMessage.Text += "</td>";
                    lblClassifiedMessage.Text += "</tr>";
                    lblClassifiedMessage.Text += "</table>";
                    //lblClassifiedMessage.Text = "You have not posted any Classified Ads yet.";
                }
            }
        }
        catch (Exception Exp)
        {
            //lblCorporateMessage.Text = "Error: " + Exp.Message;
        }
    }

    /// <summary>
    /// Loads all  Corporate Product Order detail that this specific user has placed.
    /// </summary>
    /// <param name="intProfileID"></param>
    /// <param name="userType"></param>
    private void LoadList_PlacedOrder_Corporate_Product()
     {
        try
        {
            using (BC_Product bcProduct= new BC_Product())
            {

                DataTable dt = bcProduct.LoadList_PlacedOrder_CorporateProduct(intProfileID);

                if (dt.Rows.Count > 0)
                {
                    grvCorporateOrderList.DataSource = dt;
                    grvCorporateOrderList.DataBind();
                }
                else
                {
                    lblCorporateOrderMessage.Text = "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" align=\"center\" style=\"width:606px; background-color:#3B5998;\">";
                    lblCorporateOrderMessage.Text += "<tr>";
                    lblCorporateOrderMessage.Text += "<td align=\"center\" style=\"height:45px; color:#FFFFFF; font-size:14px; font-weight:bold;\" valign=\"middle\">";
                    lblCorporateOrderMessage.Text += "<span class=\"title\" style=\"font-size:14px;\">";
                    lblCorporateOrderMessage.Text += "</span> You have not placed any Corporate Product order yet.";
                    lblCorporateOrderMessage.Text += "</td>";
                    lblCorporateOrderMessage.Text += "</tr>";
                    lblCorporateOrderMessage.Text += "</table>";
                    //lblCorporateOrderMessage.Text = "You have not placed any Corporate Product order yet.";
                }
            }
        }
        catch (Exception Exp)
        {
            //lblCorporateMessage.Text = "Error: " + Exp.Message;
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        this.CheckUserSession();
        CurrentTab.Text = Tabs.ActiveTab.HeaderText;
        this.LoadReviewCount(intProfileID);

        UTLUtilities.CL_ActiveModule = 1;
        if (!Page.IsPostBack)
        {
            this.LoadList_PostedAllProduct();
            this.LoadList_Category(intCountryID);
            this.Load_CL_Categories();
            this.LoadList_PlacedOrder_Corporate_Product();
            this.LoadList_Posted_AllClassifiedProduct();
            this.LoadList_PostedAllActiveProductCounter();
            this.LoadList_PostedAllInActiveProductCounter();
        }
    }

    protected void grvClassifiedProduct_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grvClassifiedProduct.PageIndex = e.NewPageIndex;
            if (FilterClassified == FilterTypeClassified.ClassifiedByDateRange)
            {
                this.LoadList_Posted_ClassifiedProduct(Convert.ToDateTime(txtFromDate.Text), Convert.ToDateTime(txtToDate.Text));

            }
            else if (FilterClassified == FilterTypeClassified.ClassifiedAll && ddlClassifiedCategory.SelectedValue != "-1")
            {
                this.LoadList_Posted_AllClassifiedProduct();
            }
            else if (FilterClassified == FilterTypeClassified.ClassifiedByCategory && ddlClassifiedCategory.SelectedValue != "-1")
            {
                this.LoadList_PostedClassifiedProductByCategory(Convert.ToInt32(ddlClassifiedCategory.SelectedValue.ToString()));
            }

            else
            {
                this.LoadList_Posted_AllClassifiedProduct();
            }
        }
        catch (Exception Exp)
        {
            lblClassifiedMessage.Text = "Error: " + Exp.Message;
        }
    }

    protected void grvCorporateOrderList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //try
        //{
        //    grvCorporateOrderList.PageIndex = e.NewPageIndex;

        //    if (Filter == FilterType.ByDateRange)
        //    {
        //        this.LoadList_PostedProductByDateRange(Convert.ToDateTime(txtStartDate.Text), Convert.ToDateTime(txtEndDate.Text));

        //    }
        //    else if (ddlCategory.SelectedValue != "-1" && Filter == FilterType.All)
        //    {
        //        this.LoadList_PostedAllProduct();
        //    }
        //    else if (Filter == FilterType.ByCategory && ddlCategory.SelectedValue != "-1")
        //    {
        //        this.LoadList_PostedProductByCategory(Convert.ToInt32(ddlCategory.SelectedValue.ToString()));
        //    }
        //    else
        //    {
        //        this.LoadList_PostedAllProduct();
        //    }
        //}
        //catch (Exception Exp)
        //{
        //    lblCorporateOrderMessage.Text = "Error: " + Exp.Message;
        //}
    }

    protected void grvCorporateOrderList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      
    }

    private void LoadReviewCount(int _ProfileID)
    {
        try
        {
            using (BC_Review obj = new BC_Review())
            {
                DataTable dt = obj.Load_ReviewCOunt(_ProfileID);
                if (dt.Rows.Count > 0)
                {
                    rep.DataSource = dt;
                    rep.DataBind();
                }
                else
                {
                    rep.DataSource = null;
                    rep.DataBind();
                }

            }
        }
        catch (Exception ex)
        {
            //lblCorporateMessage.Text = ex.Message;
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
      this.LoadList_Posted_ClassifiedProduct(Convert.ToDateTime(txtFromDate.Text), Convert.ToDateTime(txtToDate.Text));
      FilterClassified = FilterTypeClassified.ClassifiedByDateRange;
      this.SetGridView_PageIndex();
    }
    protected void btnBSProdSearch_Click(object sender, EventArgs e)
    {

        //this.LoadList_PostedProductByDateRange(Convert.ToDateTime(txtStartDate.Text), Convert.ToDateTime(txtEndDate.Text));
        //Filter = FilterType.ByDateRange;
        //this.SetGridView_PageIndex();
       
    }
    private void SetGridView_PageIndex()
    {
        //AllAdsGridView.PageIndex = 0;
    }

}
