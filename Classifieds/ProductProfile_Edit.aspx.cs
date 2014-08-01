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


public partial class Classifieds_ProductProfile_Edit : System.Web.UI.Page
{
    #region PROPERTY

    private int intPageMode = -1;
    private int intProductID = -1;
    private int intProfileID = -1;
    private int intCountryID = -1;
    private string strSystemMessage = string.Empty;
    public int intCategoryID = -1;
    private bool isAdmin = false;
    private DateTime advertisementDeadline = DateTime.Now;

   

    public bool IsDisplaySubcategory
    {
        get 
        {
            object obj = ViewState["IsDisplaySubcategory"];
            if (obj != null)
            {
                return Convert.ToBoolean(obj);
            }
            return false; 
        }
        set { ViewState["IsDisplaySubcategory"] = value; }
    }


    #endregion PROPERTY

    #region AUTHENTICATION METHODS

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
    private void CheckQueryString()
    {
        bool blnFlag = false;

        string strPageMode = Request.QueryString["PageMode"];
        string strPID = Request.QueryString["PID"];

        string strCID = Request.QueryString["CID"];


        if (string.IsNullOrEmpty(strPageMode) || string.IsNullOrEmpty(strPID))
        {
            blnFlag = false;
        }
        else
        {
            if (strPageMode == "0" || strPageMode == "1")
            {
                if (strPageMode == "0")
                {
                    if (strPID != "-1")
                    {
                        blnFlag = false;
                    }
                    else
                    {
                        blnFlag = true;
                    }
                }
                else
                {
                    if (UTLUtilities.IsNumeric(strPID))
                    {
                        blnFlag = true;
                    }
                    else
                    {
                        blnFlag = false;
                    }
                }
            }
            else
            {
                blnFlag = false;
            }
        }

        if (blnFlag == true)
        {
            intPageMode = Convert.ToInt32(Request.QueryString["PageMode"]);
            intProductID = Convert.ToInt32(Request.QueryString["PID"]);
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
    }

    #endregion AUTHENTICATION METHODS

    #region LOAD METHODS



    private void LoadRecord_ClassifiedCategory()
    {
        try
        {
            using (BOC_Classifieds_ProductProfile bocProductProfile = new BOC_Classifieds_ProductProfile())
            {
                EOC_PropertyBean eocPropertyBean = new EOC_PropertyBean();
                eocPropertyBean.Country_CountryID = intCountryID;
                ddlCategory.Items.Clear();
                ddlCategory.Items.Add(new ListItem("Select", "-1"));
                DataTable dtCategory = bocProductProfile.LoadRecord_ClassifiedCategory(eocPropertyBean);
                if (dtCategory.Rows.Count > 0)
                {
                    ddlCategory.DataSource = dtCategory;
                    ddlCategory.DataValueField = "CategoryID";
                    ddlCategory.DataTextField = "Category";
                    ddlCategory.DataBind();
                }
                else
                {
                    lblSystemMessage.Text = "No category found.";
                }
            }
        }
        catch (Exception Exp)
        {
            lblSystemMessage.Text = Exp.Message.ToString();
        }
    }

    /// <summary>
    /// Loads Subcategory depending on Classified CategoryID
    /// </summary>
    /// <param name="intCategoryID"></param>
    private void Load_Subcategory(int intCategoryID)
    {
        try
        {
            using (BOC_Classifieds_ProductProfile bocClassifiedProduct = new BOC_Classifieds_ProductProfile())
            {
                EOC_PropertyBean eocPropertyBean = new EOC_PropertyBean();
                eocPropertyBean.Category_CategoryID = intCategoryID;
                DataTable dtSubcategory = bocClassifiedProduct.LoadRecord_ClassifiedSubCategory(eocPropertyBean);
                if (dtSubcategory.Rows.Count > 0)
                {
                    if (dtSubcategory.Rows.Count > 1)
                    {
                        IsDisplaySubcategory = true;
                    }
                    else
                    {
                        IsDisplaySubcategory = false;
                    }
                    ddlSubcategory.DataSource = dtSubcategory;
                    ddlSubcategory.DataValueField = "SubcategoryID";
                    ddlSubcategory.DataTextField = "Subcategory";
                    ddlSubcategory.DataBind();
                }
                else
                {
                    lblSystemMessage.Text = "No Subcategory found.";
                }
            }
        }
        catch (Exception ex)
        {
            lblSystemMessage.Text = "Error: " + ex.Message;
        }
    }



    
    /// <summary>
    /// Loads all Provice
    /// </summary>
    private void LoadRecord_Province()
    {
        try
        {
            using (BOC_Classifieds_ProductProfile bocProductProfile = new BOC_Classifieds_ProductProfile())
            {
                EOC_PropertyBean eocPropertyBean = new EOC_PropertyBean();
                eocPropertyBean.Country_CountryID = intCountryID;
                DataTable dt = bocProductProfile.LoadRecord_Province(eocPropertyBean);
                if(dt.Rows.Count > 0)
                {

                    ddlLocation.Items.Clear();
                    ddlLocation.Items.Add(new ListItem("Select", "-1"));

                    ddlLocation.DataSource = dt;
                    ddlLocation.DataValueField = "ProvinceID";
                    ddlLocation.DataTextField = "Province";
                    ddlLocation.DataBind();
                    
                    
                }
                
            }
        }
        catch (Exception Exp)
        {
            lblSystemMessage.Text = Exp.Message.ToString();
        }
    }


    /// <summary>
    /// Loads all the Area name inside Dhaka.
    /// </summary>
    private void LoadList_DhakaArea()
    {
        int DhakaProvinceID = 18;
        try
        {
            using (BC_Classifieds_Item bcClassified = new BC_Classifieds_Item())
            {
                DataTable dt = bcClassified.LoadList_CL_Dhaka_Area(DhakaProvinceID);
                if (dt.Rows.Count > 0)
                {
                    ddlLocation.Items.Clear();
                    ddlLocation.Items.Add(new ListItem("Select", "-1"));
                    ddlLocation.DataSource = dt;
                    ddlLocation.DataValueField = "AreaID";
                    ddlLocation.DataTextField = "Area";
                    ddlLocation.DataBind();
                }
            }
        }
        catch (Exception Exp)
        {
            lblSystemMessage.Text = Exp.Message.ToString();
        }
    }


    /// <summary>
    /// Loads State for address input.
    /// </summary>
    /// <param name="CountryID"></param>
    private void LoadRecord_State(string CountryID)
    {
        try
        {
            using (BOC_Classifieds_UserProfile bocUserProfile = new BOC_Classifieds_UserProfile())
            {
                EOC_PropertyBean eocPropertyBean = new EOC_PropertyBean();
                eocPropertyBean.Country_CountryID = Convert.ToInt32(CountryID);

                DataTable dtState = bocUserProfile.LoadRecord_State(eocPropertyBean);

                ddlState.Items.Clear();
                ddlState.Items.Add(new ListItem("Select", "-1"));

                if (dtState.Rows.Count > 0)
                {
                    ddlState.DataSource = dtState;
                    ddlState.DataValueField = "StateID";
                    ddlState.DataTextField = "StateName";
                    ddlState.DataBind();
                }
            }
        }
        catch (Exception Exp)
        {
            lblSystemMessage.Text = Exp.Message.ToString();
        }
    }

    /// <summary>
    /// Loads Province for address input.
    /// </summary>
    /// <param name="StateID"></param>
    private void LoadRecord_Province_ForAddress(string StateID)
    {
        try
        {
            if (!string.IsNullOrEmpty(StateID) && StateID != "-1")
            {
                using (BOC_Classifieds_UserProfile bocUserProfile = new BOC_Classifieds_UserProfile())
                {
                    EOC_PropertyBean eocPropertyBean = new EOC_PropertyBean();
                    eocPropertyBean.State_StateID = Convert.ToInt32(StateID);

                    DataTable dtPovince = bocUserProfile.LoadRecord_Province(eocPropertyBean);

                    ddlProvince.Items.Clear();
                    ddlProvince.Items.Add(new ListItem("Select", "-1"));

                    if (dtPovince.Rows.Count > 0)
                    {
                        ddlProvince.DataSource = dtPovince;
                        ddlProvince.DataValueField = "ProvinceID";
                        ddlProvince.DataTextField = "Province";
                        ddlProvince.DataBind();
                    }
                }
            }
        }
        catch (Exception Exp)
        {
            lblSystemMessage.Text = Exp.Message.ToString();
        }
    }


    #endregion LOAD METHODS

    #region SELECT METHODS
    /// <summary>
    /// Loads Specific Classified Product Record.
    /// </summary>
    /// 

    

    private void SelectRecord_ProductProfile()
    {
        try
        {
            using (BOC_Classifieds_ProductProfile bocProductProfile = new BOC_Classifieds_ProductProfile())
            {
                EOC_PropertyBean eocPropertyBean = new EOC_PropertyBean();
                eocPropertyBean.Classifieds_ProductProfile_ProductID = intProductID;

                if (bocProductProfile.SelectRecord_ProductProfile(eocPropertyBean))
                {
                    rblAdvType.SelectedValue = eocPropertyBean.Classifieds_ProductProfile_AdvertisementType;
                    if (eocPropertyBean.Classifieds_ProductProfile_IsInsideDhaka)
                    {
                        
                        ddlLocation.SelectedValue = eocPropertyBean.Area_AreaID.ToString();
                        rblLocation.SelectedValue = "InDhaka";
                    }
                    else
                    {
                        this.LoadRecord_Province();
                        ddlLocation.SelectedValue = eocPropertyBean.Province_ProvinceID.ToString();
                        rblLocation.SelectedValue = "OutDhaka";
                    }

                    ddlCategory.SelectedValue = eocPropertyBean.Category_CategoryID.ToString();
                    txtTitle.Text = eocPropertyBean.Classifieds_ProductProfile_ProductTitle;
                    txtDescription.Text = eocPropertyBean.Classifieds_ProductProfile_ProductDescription;
                    
                    if (eocPropertyBean.Classifieds_ProductProfile_SalePrice != 0.00)
                    {
                        txtPrice.Text = eocPropertyBean.Classifieds_ProductProfile_SalePrice.ToString();
                        ddlCurrency.SelectedValue = eocPropertyBean.Classifieds_ProductProfile_Currency;
                    }
                    
                    if (eocPropertyBean.Classifieds_ProductProfile_AlternatePriceOffer != 0)
                    {
                        if(eocPropertyBean.Classifieds_ProductProfile_AlternatePriceOffer == 1 ||
                            eocPropertyBean.Classifieds_ProductProfile_AlternatePriceOffer == 5 ||
                            eocPropertyBean.Classifieds_ProductProfile_AlternatePriceOffer == 6)
                        {
                            pnlPrice.Visible = true;
                            pnlPrice.Enabled = true;
                        }
                        ddlAlternatePrice.SelectedValue = eocPropertyBean.Classifieds_ProductProfile_AlternatePriceOffer.ToString();
                    }

                    if (eocPropertyBean.Classifieds_ProductProfile_Source == "ApnerDeal.com")
                    {
                        rblBoromela.Checked = true;

                    }
                    else
                    {
                        rblNewspaper.Checked = true;
                        rblBoromela.Checked = false;
                        txtNewspaper.Text = eocPropertyBean.Classifieds_ProductProfile_Source;
                    }
                    
                    DateTime dt;

                    dt = DateTime.Parse(eocPropertyBean.Classifieds_ProductProfile_Deadline);

                    txtToDate.Text = dt.ToString("dd-MMM-yyyy");


                    if (eocPropertyBean.Subcategory_SubcategoryID > 0)
                    {
                        this.Load_Subcategory(eocPropertyBean.Category_CategoryID);
                        ddlSubcategory.SelectedValue = eocPropertyBean.Subcategory_SubcategoryID.ToString();
                        pnlSubcategory.Visible = true;
                        if (ddlCategory.SelectedValue == "9") // Checks if it is Matrimonial Category
                        {
                            pnlPricing.Enabled = false;
                            pnlPricing.Visible = false;
                            rblAdvType.SelectedItem.Value = "Select";
                        }
                    }
                    else
                    {
                        pnlSubcategory.Visible = false;
                    }

                }
                else
                {
                    strSystemMessage = "<table style='width:500px; border:1px dashed #666666;'>";
                    strSystemMessage += "<tr>";
                    strSystemMessage += "<td align='center' style='width:10%;'><img src='../images/icon_error.gif' width='42' height='40' alt='' /></td>";
                    strSystemMessage += "<td valign='middle' style='width:90%;font-weight:bold; text-decoration:underline'>Following error occured :</td>";
                    strSystemMessage += "</tr>";

                    strSystemMessage += "<tr>";
                    strSystemMessage += "<td colspan='2' style='width:100%; color:#000000; padding-top:7px; padding-left:10px;'>";
                    strSystemMessage += "Product Profile not found!";
                    strSystemMessage += "<br/><br/>";
                    strSystemMessage += "<strong>How did this happen? </strong>";
                    strSystemMessage += "<ul>";
                    strSystemMessage += "<li>You login session may be expired.</li>";
                    strSystemMessage += "<li>Your Classified Ad may be deleted by ApnerDeal authority for some reason.</li>";
                    strSystemMessage += "</ul>";
                    strSystemMessage += "</td>";
                    strSystemMessage += "</tr>";
                    strSystemMessage += "</table>";

                    lblSystemMessage.Text = strSystemMessage;
                }
            }
        }
        catch (Exception Exp)
        {
            lblSystemMessage.Text = Exp.Message.ToString();
        }
    }


    private void SelectRecord_ProductProfile_For_Admin()
    {
        try
        {
            using (BOC_Classifieds_ProductProfile bocProductProfile = new BOC_Classifieds_ProductProfile())
            {
                EOC_PropertyBean eocPropertyBean = new EOC_PropertyBean();
                eocPropertyBean.Classifieds_ProductProfile_ProductID = intProductID;

                if (bocProductProfile.SelectRecord_ProductProfile_For_Admin(eocPropertyBean))
                {
                    rblAdvType.SelectedValue = eocPropertyBean.Classifieds_ProductProfile_AdvertisementType;
                    if (eocPropertyBean.Classifieds_ProductProfile_IsInsideDhaka)
                    {

                        ddlLocation.SelectedValue = eocPropertyBean.Area_AreaID.ToString();
                        rblLocation.SelectedValue = "InDhaka";
                    }
                    else
                    {
                        this.LoadRecord_Province();
                        ddlLocation.SelectedValue = eocPropertyBean.Province_ProvinceID.ToString();
                        rblLocation.SelectedValue = "OutDhaka";
                    }

                    ddlCategory.SelectedValue = eocPropertyBean.Category_CategoryID.ToString();
                    txtTitle.Text = eocPropertyBean.Classifieds_ProductProfile_ProductTitle;
                    txtDescription.Text = eocPropertyBean.Classifieds_ProductProfile_ProductDescription;

                    if (eocPropertyBean.Classifieds_ProductProfile_AlternatePriceOffer == 1 || 
                        eocPropertyBean.Classifieds_ProductProfile_AlternatePriceOffer == 5 || 
                        eocPropertyBean.Classifieds_ProductProfile_AlternatePriceOffer == 6)
                    {
                        txtPrice.Text = eocPropertyBean.Classifieds_ProductProfile_SalePrice.ToString();
                        ddlCurrency.SelectedValue = eocPropertyBean.Classifieds_ProductProfile_Currency;
                    }

                    if (eocPropertyBean.Classifieds_ProductProfile_AlternatePriceOffer != 0)
                    {
                        if (eocPropertyBean.Classifieds_ProductProfile_AlternatePriceOffer == 1 ||
                            eocPropertyBean.Classifieds_ProductProfile_AlternatePriceOffer == 5 ||
                            eocPropertyBean.Classifieds_ProductProfile_AlternatePriceOffer == 6)
                        {
                            pnlPrice.Visible = true;
                            pnlPrice.Enabled = true;
                        }
                        ddlAlternatePrice.SelectedValue = eocPropertyBean.Classifieds_ProductProfile_AlternatePriceOffer.ToString();
                    }

                    if (eocPropertyBean.Classifieds_ProductProfile_Source == "ApnerDeal.com")
                    {
                        rblBoromela.Checked = true;

                    }
                    else
                    {
                        rblNewspaper.Checked = true;
                        rblBoromela.Checked = false;
                        txtNewspaper.Text = eocPropertyBean.Classifieds_ProductProfile_Source;
                    }


                    //ddlDay.SelectedValue = eocPropertyBean.Classifieds_ProductProfile_Deadline.Day.ToString();
                    //ddlMonth.SelectedValue = eocPropertyBean.Classifieds_ProductProfile_Deadline.Month.ToString();
                    //ddlYear.SelectedValue = eocPropertyBean.Classifieds_ProductProfile_Deadline.Year.ToString();

                    if (eocPropertyBean.Subcategory_SubcategoryID > 0)
                    {
                        this.Load_Subcategory(eocPropertyBean.Category_CategoryID);
                        ddlSubcategory.SelectedValue = eocPropertyBean.Subcategory_SubcategoryID.ToString();
                        pnlSubcategory.Visible = true;
                        if (ddlCategory.SelectedValue == "9") // Checks if it is Matrimonial Category
                        {
                            pnlPricing.Enabled = false;
                            pnlPricing.Visible = false;
                            rblAdvType.SelectedItem.Value = "Select";
                        }
                    }
                    else
                    {
                        pnlSubcategory.Visible = false;
                    }

                    chkALternativeAddress.Checked = eocPropertyBean.Is_Alternative_Address;

                    if (eocPropertyBean.Is_Alternative_Address)
                    {
                        pnlAlternativeAddress.Enabled = eocPropertyBean.Is_Alternative_Address;
                        pnlAlternativeAddress.Visible = eocPropertyBean.Is_Alternative_Address;

                        this.LoadRecord_State("18");
                        ddlState.SelectedValue = eocPropertyBean.Classifieds_Seller_StateID.ToString();
                        this.LoadRecord_Province_ForAddress(eocPropertyBean.Classifieds_Seller_StateID.ToString());
                        ddlProvince.SelectedValue = eocPropertyBean.Classifieds_Seller_ProvinceID.ToString();

                        txtAddress.Text = eocPropertyBean.Classifieds_Seller_Address;
                        txtSellerName.Text = eocPropertyBean.Classifieds_Seller_Name;
                        txtMobile.Text = eocPropertyBean.Classifieds_Seller_Mobile;
                    }

                }
                else
                {
                    strSystemMessage = "<table style='width:500px; border:1px dashed #666666;'>";
                    strSystemMessage += "<tr>";
                    strSystemMessage += "<td align='center' style='width:10%;'><img src='../images/icon_error.gif' width='42' height='40' alt='' /></td>";
                    strSystemMessage += "<td valign='middle' style='width:90%;font-weight:bold; text-decoration:underline'>Following error occured :</td>";
                    strSystemMessage += "</tr>";

                    strSystemMessage += "<tr>";
                    strSystemMessage += "<td colspan='2' style='width:100%; color:#000000; padding-top:7px; padding-left:10px;'>";
                    strSystemMessage += "Product Profile not found!";
                    strSystemMessage += "<br/><br/>";
                    strSystemMessage += "<strong>How did this happen? </strong>";
                    strSystemMessage += "<ul>";
                    strSystemMessage += "<li>You login session may be expired.</li>";
                    strSystemMessage += "<li>Your Classified Ad may be deleted by ApnerDeal authority for some reason.</li>";
                    strSystemMessage += "</ul>";
                    strSystemMessage += "</td>";
                    strSystemMessage += "</tr>";
                    strSystemMessage += "</table>";

                    lblSystemMessage.Text = strSystemMessage;
                }
            }
        }
        catch (Exception Exp)
        {
            lblSystemMessage.Text = Exp.Message.ToString();
        }
    }

    #endregion SELECT METHODS

    #region INSERT METHODS

    /// <summary>
    /// Adds Classified Products.
    /// </summary>
    /// <returns></returns>

    private void AddRecord_Classified()
    {

        int intProvinceID = 0;
        int intSubCategory = 0;
        string strAdvertisementType = "";
        string strProductImage = @"Classifieds_ProductImage/default.png";
        string strCurrency = "";
        double dblSalePrice = 0;
        int intAlternatePriceOffer = 0;
        DateTime dtUpdatedon = DateTime.Now;
        int intCategoryID = 0;
        string strSource = "ApnerDeal.com";
        int intAreaID = 0;
        int intInsideDhaka = 1;

        string errmsg;
        int intActionResult = 0;

        

        using (BOC_Classifieds_ProductProfile BOC_Classifieds_ProductProfile = new BOC_Classifieds_ProductProfile())
        {

            if (rblLocation.SelectedValue == "InDhaka")
            {
                intInsideDhaka = 1;
                intAreaID = Convert.ToInt32(ddlLocation.SelectedValue);
                intProvinceID = 18;
            }
            else
            {
                intInsideDhaka = 0;
                intAreaID = -1;
                intProvinceID = Convert.ToInt32(ddlLocation.SelectedValue);
            }

            if (ddlCategory.SelectedValue != "999")
            {
                if (ddlAlternatePrice.SelectedValue == "2"
                    || ddlAlternatePrice.SelectedValue == "3"
                    || ddlAlternatePrice.SelectedValue == "4"
                    
                    )

                {
                    dblSalePrice = 0;
                }
                else
                {
                    dblSalePrice = Convert.ToDouble(txtPrice.Text);
                }

                try
                {
                    intActionResult = BOC_Classifieds_ProductProfile.SaveRecord_Classified(
                        intProfileID,
                        intProvinceID,
                        intSubCategory = Convert.ToInt32(ddlSubcategory.SelectedItem.Value),
                        strAdvertisementType = rblAdvType.SelectedItem.Value,
                        txtTitle.Text,
                        txtDescription.Text,
                        strProductImage,
                        strCurrency = ddlCurrency.SelectedItem.Value,
                        dblSalePrice,
                        intAlternatePriceOffer = Convert.ToInt32(ddlAlternatePrice.SelectedValue),
                        txtToDate.Text,
                        dtUpdatedon,
                        intCategoryID = Convert.ToInt32(ddlCategory.SelectedItem.Value),
                        strSource,
                        intAreaID,
                        intInsideDhaka

                        );

                    if (intActionResult > 0)
                    {
                        Response.Redirect("ControlPanel.aspx");
                        
                    }
                }
                catch (Exception ex)
                {
                    errmsg = "Error: " + ex.Message;
                }
            }

        }
    }


    private void UpdateRecord_Classified()
    {

        int intProvinceID = 0;
        int intSubCategory = 0;
        string strAdvertisementType = "";
        string strCurrency = "";
        double dblSalePrice = 0;
        int intAlternatePriceOffer = 0;
        DateTime dtUpdatedon = DateTime.Now;
        int intCategoryID = 0;
        string strSource = "ApnerDeal.com";
        int intAreaID = 0;
        int intInsideDhaka = 1;

        string errmsg;
        int intActionResult = 0;

        using (BOC_Classifieds_ProductProfile BOC_Classifieds_ProductProfile = new BOC_Classifieds_ProductProfile())
        {

            if (rblLocation.SelectedValue == "InDhaka")
            {
                intInsideDhaka = 1;
                intAreaID = Convert.ToInt32(ddlLocation.SelectedValue);
                intProvinceID = 18;
            }
            else
            {
                intInsideDhaka = 0;
                intAreaID = -1;
                intProvinceID = Convert.ToInt32(ddlLocation.SelectedValue);
            }

            if (ddlCategory.SelectedValue != "999")
            {
                if (ddlAlternatePrice.SelectedValue == "2"
                    || ddlAlternatePrice.SelectedValue == "3"
                    || ddlAlternatePrice.SelectedValue == "4")
                {
                    dblSalePrice = 0;
                }
                else
                {
                    dblSalePrice = Convert.ToDouble(txtPrice.Text);
                }

                try
                {
                    intActionResult = BOC_Classifieds_ProductProfile.UpdateRecord_Classified(
                        intProductID,
                        intProfileID,
                        intProvinceID,
                        intSubCategory = Convert.ToInt32(ddlSubcategory.SelectedItem.Value),
                        strAdvertisementType = rblAdvType.SelectedItem.Value,
                        txtTitle.Text,
                        txtDescription.Text,
                        strCurrency = ddlCurrency.SelectedItem.Value,
                        dblSalePrice,
                        intAlternatePriceOffer = Convert.ToInt32(ddlAlternatePrice.SelectedValue),
                        txtToDate.Text,
                        dtUpdatedon,
                        intCategoryID = Convert.ToInt32(ddlCategory.SelectedItem.Value),
                        strSource,
                        intAreaID,
                        intInsideDhaka

                        );

                    if (intActionResult > 0)
                    {
                        Response.Redirect("ControlPanel.aspx");
                    }
                }
                catch (Exception ex)
                {
                    errmsg = "Error: " + ex.Message;
                }
            }

        }
    }

    
    private int AddRecord_ProductProfile()
    {
        int intActionResult = 0;
        int DhakaProvinceID = 18;
        
        
        try
        {
            using (BOC_Classifieds_ProductProfile bocProductProfile = new BOC_Classifieds_ProductProfile())
            {
                EOC_PropertyBean eocPropertyBean = new EOC_PropertyBean();

                eocPropertyBean.Classifieds_UserProfile_ProfileID = intProfileID;

                if (rblLocation.SelectedValue == "InDhaka")
                {
                    eocPropertyBean.Classifieds_ProductProfile_IsInsideDhaka = true;
                    eocPropertyBean.Province_ProvinceID = DhakaProvinceID;
                    eocPropertyBean.Area_AreaID = Convert.ToInt32(ddlLocation.SelectedValue);
                }
                else
                {
                    eocPropertyBean.Classifieds_ProductProfile_IsInsideDhaka = false;
                    eocPropertyBean.Area_AreaID = -1;
                    eocPropertyBean.Province_ProvinceID = Convert.ToInt32(ddlLocation.SelectedValue);
                }

                eocPropertyBean.Subcategory_SubcategoryID = Convert.ToInt32(ddlSubcategory.SelectedItem.Value);
                eocPropertyBean.Classifieds_ProductProfile_AdvertisementType = rblAdvType.SelectedItem.Value;
                eocPropertyBean.Classifieds_ProductProfile_ProductTitle = txtTitle.Text;
                eocPropertyBean.Classifieds_ProductProfile_ProductDescription = txtDescription.Text;
                eocPropertyBean.Classifieds_ProductProfile_ProductImage = @"Classifieds_ProductImage/default.png";
                eocPropertyBean.Classifieds_ProductProfile_Currency = ddlCurrency.SelectedItem.Value;
                
                if (ddlCategory.SelectedValue != "9")
                {
                    if (ddlAlternatePrice.SelectedValue == "2"
                        || ddlAlternatePrice.SelectedValue == "3"
                        || ddlAlternatePrice.SelectedValue == "4")
                    {
                        eocPropertyBean.Classifieds_ProductProfile_SalePrice = 0;
                    }
                    else
                    {
                        eocPropertyBean.Classifieds_ProductProfile_SalePrice = Convert.ToDouble(txtPrice.Text);
                    }

                    eocPropertyBean.Classifieds_ProductProfile_AlternatePriceOffer = Convert.ToInt32(ddlAlternatePrice.SelectedValue);
                }
                else
                {
                    eocPropertyBean.Classifieds_ProductProfile_SalePrice = 0;
                    eocPropertyBean.Classifieds_ProductProfile_Currency = ddlCurrency.SelectedItem.Value;
                    eocPropertyBean.Classifieds_ProductProfile_AlternatePriceOffer = Convert.ToInt32(ddlAlternatePrice.SelectedValue);
                }

                eocPropertyBean.Classifieds_ProductProfile_Deadline = txtToDate.Text;
                eocPropertyBean.UpdatedOn = DateTime.Now;
                eocPropertyBean.Category_CategoryID = Convert.ToInt32(ddlCategory.SelectedItem.Value);
                if (rblBoromela.Checked)
                {
                    eocPropertyBean.Classifieds_ProductProfile_Source = "ApnerDeal.com";
                }
                else
                {
                    eocPropertyBean.Classifieds_ProductProfile_Source = txtNewspaper.Text;
                }


                

                if(Int32.TryParse(ddlCategory.SelectedValue, out intCategoryID))
                {
                    eocPropertyBean.Subcategory_CategoryID = intCategoryID;
                }
                

                intActionResult = bocProductProfile.AddRecord_ProductProfile(eocPropertyBean);
            }
        }
        catch (Exception Exp)
        {
            lblSystemMessage.Text = Exp.Message.ToString();
        }

        return intActionResult;
    }




    #region NOT IN USE
    
    private int AddRecord_ProductProfile_ForAdmin()
    {
        int intActionResult = 0;
        int DhakaProvinceID = 18;

        try
        {
            using (BOC_Classifieds_ProductProfile bocProductProfile = new BOC_Classifieds_ProductProfile())
            {
                EOC_PropertyBean eocPropertyBean = new EOC_PropertyBean();

                eocPropertyBean.Classifieds_UserProfile_ProfileID = intProfileID;

                eocPropertyBean.Category_CategoryID = Convert.ToInt32(ddlCategory.SelectedItem.Value);
                eocPropertyBean.Subcategory_SubcategoryID = Convert.ToInt32(ddlSubcategory.SelectedItem.Value);


                if (rblLocation.SelectedValue == "InDhaka")
                {
                    eocPropertyBean.Classifieds_ProductProfile_IsInsideDhaka = true;
                    eocPropertyBean.Province_ProvinceID = DhakaProvinceID;
                    eocPropertyBean.Area_AreaID = Convert.ToInt32(ddlLocation.SelectedValue);
                }
                else
                {
                    eocPropertyBean.Classifieds_ProductProfile_IsInsideDhaka = false;
                    eocPropertyBean.Area_AreaID = -1;
                    eocPropertyBean.Province_ProvinceID = Convert.ToInt32(ddlLocation.SelectedValue);
                }


                if (Int32.TryParse(ddlCategory.SelectedValue, out intCategoryID))
                {
                    eocPropertyBean.Subcategory_CategoryID = intCategoryID;
                }

                eocPropertyBean.Classifieds_ProductProfile_AdvertisementType = rblAdvType.SelectedItem.Value;
                eocPropertyBean.Classifieds_ProductProfile_ProductTitle = txtTitle.Text;
                eocPropertyBean.Classifieds_ProductProfile_ProductDescription = txtDescription.Text;
                eocPropertyBean.Classifieds_ProductProfile_ProductImage = @"Classifieds_ProductImage/default.png";

                if (ddlCategory.SelectedValue != "9")
                {
                    if (ddlAlternatePrice.SelectedValue == "2"
                        || ddlAlternatePrice.SelectedValue == "3"
                        || ddlAlternatePrice.SelectedValue == "4")
                    {
                        eocPropertyBean.Classifieds_ProductProfile_SalePrice = 0;
                    }
                    else
                    {
                        eocPropertyBean.Classifieds_ProductProfile_SalePrice = Convert.ToDouble(txtPrice.Text);
                    }
                    eocPropertyBean.Classifieds_ProductProfile_Currency = ddlCurrency.SelectedItem.Value;
                    eocPropertyBean.Classifieds_ProductProfile_AlternatePriceOffer = Convert.ToInt32(ddlAlternatePrice.SelectedValue);
                }
                else
                {
                    eocPropertyBean.Classifieds_ProductProfile_SalePrice = 0;
                    eocPropertyBean.Classifieds_ProductProfile_Currency = ddlCurrency.SelectedItem.Value;
                    eocPropertyBean.Classifieds_ProductProfile_AlternatePriceOffer = Convert.ToInt32(ddlAlternatePrice.SelectedValue);
                }

                //if (txtPrice.Text != "")
                //{
                //    if (ddlAlternatePrice.SelectedItem.Value == "-1")
                //    {
                //        eocPropertyBean.Classifieds_ProductProfile_Currency = ddlCurrency.SelectedItem.Value;
                //        eocPropertyBean.Classifieds_ProductProfile_SalePrice = Convert.ToDouble(txtPrice.Text);
                //        eocPropertyBean.Classifieds_ProductProfile_AlternatePriceOffer = -1;
                //    }

                //    if (ddlAlternatePrice.SelectedItem.Value == "5" || ddlAlternatePrice.SelectedItem.Value == "6" || ddlAlternatePrice.SelectedItem.Value == "1")
                //    {
                //        eocPropertyBean.Classifieds_ProductProfile_Currency = ddlCurrency.SelectedItem.Value;
                //        eocPropertyBean.Classifieds_ProductProfile_SalePrice = Convert.ToDouble(txtPrice.Text);
                //        eocPropertyBean.Classifieds_ProductProfile_AlternatePriceOffer = Convert.ToInt32(ddlAlternatePrice.SelectedItem.Value);
                //    }
                //}

                //if (txtPrice.Text == "" && ddlAlternatePrice.SelectedItem.Value != "-1")
                //{
                //    eocPropertyBean.Classifieds_ProductProfile_Currency = "-1";
                //    eocPropertyBean.Classifieds_ProductProfile_SalePrice = 0.00;
                //    eocPropertyBean.Classifieds_ProductProfile_AlternatePriceOffer = Convert.ToInt32(ddlAlternatePrice.SelectedItem.Value);
                //}

                //if (txtPrice.Text == "" && ddlAlternatePrice.SelectedItem.Value == "-1")
                //{
                //    eocPropertyBean.Classifieds_ProductProfile_Currency = "-1";
                //    eocPropertyBean.Classifieds_ProductProfile_SalePrice = 0.00;
                //    eocPropertyBean.Classifieds_ProductProfile_AlternatePriceOffer = Convert.ToInt32(ddlAlternatePrice.SelectedItem.Value);
                //}

                if (rblBoromela.Checked)
                {
                    eocPropertyBean.Classifieds_ProductProfile_Source = "ApnerDeal.com";
                }
                else
                {
                    eocPropertyBean.Classifieds_ProductProfile_Source = txtNewspaper.Text;
                }

                //if (ddlDay.SelectedItem.Value == "-1" && ddlMonth.SelectedItem.Value == "-1" && ddlYear.SelectedItem.Value == "-1")
                //{
                //    eocPropertyBean.Classifieds_ProductProfile_Deadline = DateTime.Now.AddDays(90);
                //}
                //else
                //{

                //    eocPropertyBean.Classifieds_ProductProfile_Deadline = Convert.ToDateTime(ddlMonth.SelectedItem.Value + "/" + ddlDay.SelectedItem.Value + "/" + ddlYear.SelectedItem.Value);
                //}
                eocPropertyBean.UpdatedOn = DateTime.Now;

                if (chkALternativeAddress.Checked)
                {
                    eocPropertyBean.Classifieds_Seller_Address = Server.HtmlEncode(txtAddress.Text);
                    eocPropertyBean.Classifieds_Seller_Name= Server.HtmlEncode(txtSellerName.Text);
                    eocPropertyBean.Classifieds_Seller_Mobile = Server.HtmlEncode(txtMobile.Text);
                    eocPropertyBean.Classifieds_Seller_StateID = Convert.ToInt32(ddlState.SelectedValue);
                    eocPropertyBean.Classifieds_Seller_ProvinceID = Convert.ToInt32(ddlProvince.SelectedValue);
                    eocPropertyBean.Is_Alternative_Address = chkALternativeAddress.Checked;
                }
                else
                {
                    eocPropertyBean.Classifieds_Seller_Address = "";
                    eocPropertyBean.Classifieds_Seller_Name = "";
                    eocPropertyBean.Classifieds_Seller_Mobile = "";
                    eocPropertyBean.Classifieds_Seller_StateID = 0;
                    eocPropertyBean.Classifieds_Seller_ProvinceID = 0;
                    eocPropertyBean.Is_Alternative_Address = chkALternativeAddress.Checked;
                }


                intActionResult = bocProductProfile.AddRecord_ProductProfile_For_Admin(eocPropertyBean);
            }
        }
        catch (Exception Exp)
        {
            lblSystemMessage.Text = Exp.Message.ToString();
        }

        return intActionResult;
    }

    #endregion NOT IN USE

    #endregion INSERT METHODS

    #region UPDATE METHODS
    /// <summary>
    /// Updates Classified Product.
    /// </summary>
    /// <returns></returns>
    private int UpdateRecord_ProductProfile()
    {
        int intActionResult = 0;
        int DhakaProvinceID = 18;
        try
        {
            using (BOC_Classifieds_ProductProfile bocProductProfile = new BOC_Classifieds_ProductProfile())
            {
                EOC_PropertyBean eocPropertyBean = new EOC_PropertyBean();

                eocPropertyBean.Classifieds_ProductProfile_ProductID = intProductID;
                eocPropertyBean.Classifieds_UserProfile_ProfileID = intProfileID;
                
                eocPropertyBean.Category_CategoryID = Convert.ToInt32(ddlCategory.SelectedItem.Value);
                eocPropertyBean.Subcategory_SubcategoryID = Convert.ToInt32(ddlSubcategory.SelectedItem.Value);

                if (rblLocation.SelectedValue == "InDhaka")
                {
                    eocPropertyBean.Province_ProvinceID = DhakaProvinceID;
                    eocPropertyBean.Area_AreaID = Convert.ToInt32(ddlLocation.SelectedItem.Value);
                    eocPropertyBean.Classifieds_ProductProfile_IsInsideDhaka = true;
                }
                else
                {
                    eocPropertyBean.Area_AreaID = -1;
                    eocPropertyBean.Province_ProvinceID = Convert.ToInt32(ddlLocation.SelectedItem.Value);
                    eocPropertyBean.Classifieds_ProductProfile_IsInsideDhaka = false;
                }

                eocPropertyBean.Classifieds_ProductProfile_AdvertisementType = rblAdvType.SelectedItem.Value;
                eocPropertyBean.Classifieds_ProductProfile_ProductTitle = txtTitle.Text;
                eocPropertyBean.Classifieds_ProductProfile_ProductDescription = txtDescription.Text;


                if (ddlCategory.SelectedValue != "9")
                {
                    if (ddlAlternatePrice.SelectedValue == "2"
                        || ddlAlternatePrice.SelectedValue == "3"
                        || ddlAlternatePrice.SelectedValue == "4")
                    {
                        eocPropertyBean.Classifieds_ProductProfile_SalePrice = 0;
                    }
                    else
                    {
                        eocPropertyBean.Classifieds_ProductProfile_SalePrice = Convert.ToDouble(txtPrice.Text);
                    }
                    eocPropertyBean.Classifieds_ProductProfile_Currency = ddlCurrency.SelectedItem.Value;
                    eocPropertyBean.Classifieds_ProductProfile_AlternatePriceOffer = Convert.ToInt32(ddlAlternatePrice.SelectedValue);
                }
                else
                {
                    eocPropertyBean.Classifieds_ProductProfile_SalePrice = 0;
                    eocPropertyBean.Classifieds_ProductProfile_Currency = ddlCurrency.SelectedItem.Value;
                    eocPropertyBean.Classifieds_ProductProfile_AlternatePriceOffer = Convert.ToInt32(ddlAlternatePrice.SelectedValue);
                }


                if (rblBoromela.Checked)
                {
                    eocPropertyBean.Classifieds_ProductProfile_Source = "ApnerDeal.com";
                }
                else
                {
                    eocPropertyBean.Classifieds_ProductProfile_Source = txtNewspaper.Text;
                }
                
                eocPropertyBean.Classifieds_ProductProfile_Currency = ddlCurrency.SelectedValue;

                

                //System.Globalization.CultureInfo cultureinfo = new System.Globalization.CultureInfo("en-US");
                
                //DateTime dt = new DateTime();

                //if (txtToDate.Text.Length > 0)
                //{
                //    dt = DateTime.Parse(txtToDate.Text.Trim(), cultureinfo);

                //    eocPropertyBean.Classifieds_ProductProfile_Deadline = dt;
                //}

                eocPropertyBean.Classifieds_ProductProfile_Deadline = txtToDate.Text;

                eocPropertyBean.UpdatedOn = DateTime.Now;

              //  eocPropertyBean.Is_Alternative_Address = chkALternativeAddress.Checked;

                intActionResult = bocProductProfile.UpdateRecord_ProductProfile(eocPropertyBean);
            }
        }
        catch (Exception Exp)
        {
            lblSystemMessage.Text = Exp.Message.ToString();
        }

        return intActionResult;
    }



    /// <summary>
    /// Updates Classifieds Entry for Boromela User.
    /// </summary>
    /// <returns></returns>
    private int UpdateRecord_ProductProfile_For_Admin()
    {
        int intActionResult = 0;
        int DhakaProvinceID = 18;
        try
        {
            using (BOC_Classifieds_ProductProfile bocProductProfile = new BOC_Classifieds_ProductProfile())
            {
                EOC_PropertyBean eocPropertyBean = new EOC_PropertyBean();

                eocPropertyBean.Classifieds_ProductProfile_ProductID = intProductID;
                eocPropertyBean.Classifieds_UserProfile_ProfileID = intProfileID;

                eocPropertyBean.Category_CategoryID = Convert.ToInt32(ddlCategory.SelectedItem.Value);
                eocPropertyBean.Subcategory_SubcategoryID = Convert.ToInt32(ddlSubcategory.SelectedItem.Value);

                if (rblLocation.SelectedValue == "InDhaka")
                {
                    eocPropertyBean.Province_ProvinceID = DhakaProvinceID;
                    eocPropertyBean.Area_AreaID = Convert.ToInt32(ddlLocation.SelectedItem.Value);
                    eocPropertyBean.Classifieds_ProductProfile_IsInsideDhaka = true;
                }
                else
                {
                    eocPropertyBean.Area_AreaID = -1;
                    eocPropertyBean.Province_ProvinceID = Convert.ToInt32(ddlLocation.SelectedItem.Value);
                    eocPropertyBean.Classifieds_ProductProfile_IsInsideDhaka = false;
                }

                eocPropertyBean.Classifieds_ProductProfile_AdvertisementType = rblAdvType.SelectedItem.Value;
                eocPropertyBean.Classifieds_ProductProfile_ProductTitle = txtTitle.Text;
                eocPropertyBean.Classifieds_ProductProfile_ProductDescription = txtDescription.Text;


                if (ddlCategory.SelectedValue != "9")
                {
                    if (ddlAlternatePrice.SelectedValue == "2"
                        || ddlAlternatePrice.SelectedValue == "3"
                        || ddlAlternatePrice.SelectedValue == "4")
                    {
                        eocPropertyBean.Classifieds_ProductProfile_SalePrice = 0;
                    }
                    else
                    {
                        eocPropertyBean.Classifieds_ProductProfile_SalePrice = Convert.ToDouble(txtPrice.Text);
                    }
                    eocPropertyBean.Classifieds_ProductProfile_Currency = ddlCurrency.SelectedItem.Value;
                    eocPropertyBean.Classifieds_ProductProfile_AlternatePriceOffer = Convert.ToInt32(ddlAlternatePrice.SelectedValue);
                }
                else
                {
                    eocPropertyBean.Classifieds_ProductProfile_SalePrice = 0;
                    eocPropertyBean.Classifieds_ProductProfile_Currency = ddlCurrency.SelectedItem.Value;
                    eocPropertyBean.Classifieds_ProductProfile_AlternatePriceOffer = Convert.ToInt32(ddlAlternatePrice.SelectedValue);
                }

                //if (txtPrice.Text != "")
                //{
                //    if (ddlAlternatePrice.SelectedItem.Value == "-1")
                //    {
                //        eocPropertyBean.Classifieds_ProductProfile_SalePrice = Convert.ToDouble(txtPrice.Text);
                //        eocPropertyBean.Classifieds_ProductProfile_AlternatePriceOffer = -1;
                //    }

                //    if (ddlAlternatePrice.SelectedItem.Value == "5" || ddlAlternatePrice.SelectedItem.Value == "6" || ddlAlternatePrice.SelectedItem.Value == "1")
                //    {
                //        eocPropertyBean.Classifieds_ProductProfile_SalePrice = Convert.ToDouble(txtPrice.Text);
                //        eocPropertyBean.Classifieds_ProductProfile_AlternatePriceOffer = Convert.ToInt32(ddlAlternatePrice.SelectedItem.Value);
                //    }
                //    if (ddlAlternatePrice.SelectedItem.Value == "2" || ddlAlternatePrice.SelectedItem.Value == "3" || ddlAlternatePrice.SelectedItem.Value == "4")
                //    {
                //        eocPropertyBean.Classifieds_ProductProfile_SalePrice = 0.00;
                //        eocPropertyBean.Classifieds_ProductProfile_AlternatePriceOffer = Convert.ToInt32(ddlAlternatePrice.SelectedItem.Value);
                //    }

                //}
                //if (txtPrice.Text == "" && ddlAlternatePrice.SelectedItem.Value != "-1")
                //{
                //    eocPropertyBean.Classifieds_ProductProfile_SalePrice = 0.00;
                //    eocPropertyBean.Classifieds_ProductProfile_AlternatePriceOffer = Convert.ToInt32(ddlAlternatePrice.SelectedItem.Value);
                //}

                ////Moinur
                //if (txtPrice.Text == "" && ddlAlternatePrice.SelectedItem.Value == "-1")
                //{
                //    eocPropertyBean.Classifieds_ProductProfile_SalePrice = 0.00;
                //    eocPropertyBean.Classifieds_ProductProfile_AlternatePriceOffer = Convert.ToInt32(ddlAlternatePrice.SelectedItem.Value);
                //}

                if (rblBoromela.Checked)
                {
                    eocPropertyBean.Classifieds_ProductProfile_Source = "ApnerDeal.com";
                }
                else
                {
                    eocPropertyBean.Classifieds_ProductProfile_Source = txtNewspaper.Text;
                }
                eocPropertyBean.Classifieds_ProductProfile_Currency = ddlCurrency.SelectedValue;

                //if (ddlDay.SelectedItem.Value == "-1" && ddlMonth.SelectedItem.Value == "-1" && ddlYear.SelectedItem.Value == "-1")
                //{
                //    eocPropertyBean.Classifieds_ProductProfile_Deadline = DateTime.Now.AddDays(90);
                //}
                //else
                //{

                //    eocPropertyBean.Classifieds_ProductProfile_Deadline = Convert.ToDateTime(ddlMonth.SelectedItem.Value + "/" + ddlDay.SelectedItem.Value + "/" + ddlYear.SelectedItem.Value);
                //}

                //eocPropertyBean.Classifieds_ProductProfile_Deadline = Convert.ToDateTime(ddlMonth.SelectedItem.Value + "/" + ddlDay.SelectedItem.Value + "/" + ddlYear.SelectedItem.Value);
                eocPropertyBean.UpdatedOn = DateTime.Now;

                if (chkALternativeAddress.Checked)
                {
                    eocPropertyBean.Classifieds_Seller_Address = Server.HtmlEncode(txtAddress.Text);
                    eocPropertyBean.Classifieds_Seller_Name = Server.HtmlEncode(txtSellerName.Text);
                    eocPropertyBean.Classifieds_Seller_Mobile = Server.HtmlEncode(txtMobile.Text);
                    eocPropertyBean.Classifieds_Seller_StateID = Convert.ToInt32(ddlState.SelectedValue);
                    eocPropertyBean.Classifieds_Seller_ProvinceID = Convert.ToInt32(ddlProvince.SelectedValue);
                    eocPropertyBean.Is_Alternative_Address = chkALternativeAddress.Checked;
                }
                else
                {
                    eocPropertyBean.Classifieds_Seller_Address = "";
                    eocPropertyBean.Classifieds_Seller_Name = "";
                    eocPropertyBean.Classifieds_Seller_Mobile = "";
                    eocPropertyBean.Classifieds_Seller_StateID = 0;
                    eocPropertyBean.Classifieds_Seller_ProvinceID = 0;
                    eocPropertyBean.Is_Alternative_Address = chkALternativeAddress.Checked;
                }



                intActionResult = bocProductProfile.UpdateRecord_ProductProfile_For_Admin(eocPropertyBean);
            }
        }
        catch (Exception Exp)
        {
            lblSystemMessage.Text = Exp.Message.ToString();
        }

        return intActionResult;
    }


    #endregion UPDATE METHODS

    #region SIMPLE METHODS


    /// <summary>
    /// Checks Category items and makes Price and Subcategory panel visible or invisible.
    /// </summary>
    private void CheckPanel()
    {
        //if (ddlCategory.SelectedItem.Value == "16" || ddlCategory.SelectedItem.Text == "10")
        //{
        //    pnlSubcategory.Enabled = true;
        //    pnlSubcategory.Visible = true;
        //}
        if (IsDisplaySubcategory)
        {
            pnlSubcategory.Enabled = true;
            pnlSubcategory.Visible = true;
        }
        else
        {
            pnlSubcategory.Enabled = false;
            pnlSubcategory.Visible = false;
        }

        if (ddlCategory.SelectedValue == "9")
        {
            pnlPricing.Visible = false;
            pnlPricing.Enabled = false;
        }
        else
        {
            pnlPricing.Visible = true;
            pnlPricing.Enabled = true;
        }
    }




    

    private void DisplayErrorMessage(string strErrorMessage)
    {
        strSystemMessage = "<table style='width:500px; border:1px dashed #666666;'>";
        strSystemMessage += "<tr>";
        strSystemMessage += "<td align='center' style='width:10%;'><img src='../images/icon_error.gif' width='42' height='40' alt='' /></td>";
        strSystemMessage += "<td valign='middle' style='width:90%;font-weight:bold; text-decoration:underline'>Following error occured :</td>";
        strSystemMessage += "</tr>";

        strSystemMessage += "<tr>";
        strSystemMessage += "<td colspan='2' style='width:100%; color:#000000; padding-top:7px; padding-left:10px;'>";
        strSystemMessage += strErrorMessage;
        strSystemMessage += "</td>";
        strSystemMessage += "</tr>";
        strSystemMessage += "</table>";
        strSystemMessage += "<br/><br/>";
        lblSystemMessage.Text = strSystemMessage;
    }

    #endregion SIMPLE METHODS

    #region VALIDATION EVENTS

    protected void csvPricingOptions_ServerValidate(object source, ServerValidateEventArgs args)
    {

    }



    protected void ddlAlternatePrice_SelectedIndexChaged(object sender, EventArgs args)
    {
        if (ddlAlternatePrice.SelectedValue == "1" || ddlAlternatePrice.SelectedValue == "5" || ddlAlternatePrice.SelectedValue == "6")
        {
            pnlPrice.Visible = true;
            pnlPrice.Enabled = true;
        }
        else
        {
            pnlPrice.Visible = false;
            pnlPrice.Enabled = false;
        }
    }


    /// <summary>
    /// Validates Source.
    /// </summary>
    /// <param name="source"></param>
    /// <param name="args"></param>
    protected void csvSourceValidator_ServerValidate(object source, ServerValidateEventArgs args)
    {
        args.IsValid = true;
        if (rblNewspaper.Checked && txtNewspaper.Text == "")
        {
            args.IsValid = false;
            csvSourceValidator.ErrorMessage = "Please enter newspaper name.";
        }
        else
        {
            args.IsValid = true;
        }
    }


    protected void csvPrice_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (txtPrice.Text == "")
        {
            args.IsValid = false;
        }
        else
        {
            args.IsValid = true;
        }
    }

    protected void csvDeadline_ServerValidate(object source, ServerValidateEventArgs args)
    {
        //args.IsValid = true;

        //if (ddlDay.SelectedItem.Value == "-1" && ddlMonth.SelectedItem.Value == "-1" && ddlYear.SelectedItem.Value == "-1")
        //{
        //    args.IsValid = true;
        //}
        //else
        //{
        //    if (ddlDay.SelectedItem.Value != "-1")
        //    {
        //        if (ddlMonth.SelectedItem.Value == "-1" || ddlYear.SelectedItem.Value == "-1")
        //        {
        //            args.IsValid = false;
        //            csvDeadline.ErrorMessage = "Deadline is invalid ! Please set a valid deadline for this advertisement.";
        //        }
        //    }
        //    else
        //    {
        //        args.IsValid = false;
        //        csvDeadline.ErrorMessage = "Deadline is invalid ! Please set a valid deadline for this advertisement.";
        //    }

        //    if (ddlDay.SelectedItem.Value != "-1" && ddlMonth.SelectedItem.Value != "-1" && ddlYear.SelectedItem.Value != "-1")
        //    {
        //        DateTime dtmToDate = DateTime.Now;
        //        //DateTime dtmGivenDate = Convert.ToDateTime(ddlMonth.SelectedItem.Value + "/" + ddlDay.SelectedItem.Value + "/" + ddlYear.SelectedItem.Value);

        //        DateTime dtmGivenDate = Convert.ToDateTime(ddlDay.SelectedItem.Value + "/" + ddlMonth.SelectedItem.Value + "/" + ddlYear.SelectedItem.Value);

        //        TimeSpan tmsDateDifference = dtmGivenDate.Subtract(dtmToDate);

        //        if (tmsDateDifference.Days < 0)
        //        {
        //            args.IsValid = false;
        //            csvDeadline.ErrorMessage = "Invalid Deadline selected ! you cannot set previous date as your advertisement deadline.";
        //        }
        //        if (tmsDateDifference.Days > 180)
        //        {
        //            args.IsValid = false;
        //            csvDeadline.ErrorMessage = "Invalid Deadline selected ! Deadline must not exceeds 180 days boundary from the posting date.";
        //        }
        //    }
        //}

    }


    protected void rblLocation_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblLocation.SelectedValue == "InDhaka")
        { 
            LoadList_DhakaArea();
        }
        else if(rblLocation.SelectedValue == "OutDhaka")
        {
            LoadRecord_Province();
        }
        else
        {
            lblSystemMessage.Text = "Error: Could not load data.";
        }
    }


    #endregion VALIDATION EVENTS

    #region GENERAL EVENTS

    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        Int32.TryParse(ddlCategory.SelectedValue, out intCategoryID);
        if (intCategoryID != -1)
        {
            if (intCategoryID == 16)
            {
                Response.Redirect("RealEstateAE.aspx?mode=0&pi=-1", true);
            }
            else
            {
                this.Load_Subcategory(intCategoryID);
            }
        }
        this.CheckPanel();
    }


    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int intActionStatus = 0;
        string strSystemMessage = string.Empty;
        //string s = rblSource.SelectedValue;

        if (Page.IsValid)
        {
            if (intPageMode == 0 && intProductID == -1)
            {
                if (isAdmin)
                {
                    intActionStatus = this.AddRecord_ProductProfile_ForAdmin();
                }
                else
                {
                    //intActionStatus = this.AddRecord_ProductProfile();
                    intActionStatus = Duplicate_ProductProfile();
                    if (intActionStatus == 0)
                    {
                        AddRecord_Classified();
                    }
                }

            }
            if (intPageMode == 1 && intProductID > 0)
            {
                if (isAdmin)
                {
                    intActionStatus = this.UpdateRecord_ProductProfile_For_Admin();
                }
                else
                {
                    UpdateRecord_Classified();
                
                    //intActionStatus = this.UpdateRecord_ProductProfile();
                }
            }


            if (intActionStatus > 0)
            {
                Response.Redirect("ControlPanel.aspx");
                

            }
            if (intActionStatus == 0)
            {
                DisplayErrorMessage(lblSystemMessage.Text);

                //DisplayErrorMessage("System failed to save product/service advertisement information.");
            }
            if (intActionStatus == -1)
            {
                DisplayErrorMessage("Duplication occurred ! This  product/service advertisement already posted once and the deadline is not expired.");
            }
        }
        else
        {
            //
        }
    }

    private int Duplicate_ProductProfile()
    {
        int intActionResult = 0;

        try
        {
            using (BOC_Classifieds_ProductProfile bocProductProfile = new BOC_Classifieds_ProductProfile())
            {
                EOC_PropertyBean eocPropertyBean = new EOC_PropertyBean();

                eocPropertyBean.Classifieds_UserProfile_ProfileID = intProfileID;
                eocPropertyBean.Subcategory_SubcategoryID = Convert.ToInt32(ddlSubcategory.SelectedItem.Value);
                eocPropertyBean.Classifieds_ProductProfile_ProductTitle = txtTitle.Text;
                
                intActionResult = bocProductProfile.Check_Duplicate(eocPropertyBean);
            }
        }
        catch (Exception Exp)
        {
            lblSystemMessage.Text = Exp.Message.ToString();
        }

        return intActionResult;
    }


    protected void chkALternativeAddress_CheckedChanged(object sender, EventArgs e)
    {
        
        pnlAlternativeAddress.Visible = chkALternativeAddress.Checked;
        pnlAlternativeAddress.Enabled = chkALternativeAddress.Checked;

        if (chkALternativeAddress.Checked)
        {
            this.LoadRecord_State("18");
        }
    }


    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlState.SelectedValue != "-1")
        {
            this.LoadRecord_Province_ForAddress(ddlState.SelectedValue);
        }
    }
    #endregion GENERAL EVENTS

    #region PAGE LOAD EVENT

    protected void Page_Load(object sender, EventArgs e)
    {
        if (ddlCategory.SelectedValue != "-1")
        {
            if (ddlCategory.SelectedItem.Text == "Matrimonial")
            {
                pnlPrice.Visible = false;
                ddlAlternatePrice.SelectedValue = "-1";
                txtPrice.Text = "0";
            }
        }

        try
        {
            this.CheckUserSession();
            this.CheckQueryString();
        }
        catch (Exception ex)
        {
            lblSystemMessage.Text = ex.Message;
        }
        pnlAdSource.Visible = isAdmin;

        if (intCountryID == 18)
        {
            ddlCurrency.SelectedValue = "BDT";

        }
        else
        {
            ddlCurrency.SelectedValue = "USD";
        }

        UTLUtilities.CL_ActiveModule = 6;

        if (!Page.IsPostBack)
        {
            //UTLUtilities.BuildDateControl(ddlDay, ddlMonth, ddlYear);

            this.LoadRecord_ClassifiedCategory();

            //this.LoadRecord_Province();
            this.LoadList_DhakaArea();

            if (intPageMode == 1 && intProductID > 0)
            {
                if (isAdmin)
                {
                    this.SelectRecord_ProductProfile_For_Admin();
                }
                else
                {
                    this.SelectRecord_ProductProfile();
                }
            }
        }
        
    }


    #endregion PAGE LOAD EVENT
}
