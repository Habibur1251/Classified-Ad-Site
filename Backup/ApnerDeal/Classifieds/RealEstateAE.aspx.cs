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
using System.IO;

public partial class Classifieds_RealEstateAE : System.Web.UI.Page
{

    #region PROPERTY

    private int _DhakaProvinceID = 18;
    private int intPageMode = -1;
    private int intProductID = -1;
    private int _CategoryID = 7; // Real Estate CategoryID = 7
    private int _ProfileID = -1;

    private bool _ClassifiedSeller = false;

    private string ImagePath
    {
        get
        {
            object obj = ViewState["ImagePath"];
            if (obj != null)
            {
                return (string)obj;
            }
            return "";
        }

        set { ViewState["ImagePath"] = value; }
    }

    private bool _IsAdmin;

    public bool IsAdmin
    {
        get { return _IsAdmin; }
        set { _IsAdmin = value; }
    }

    #endregion PROPERTY

    #region AUTHENTICATION METHODS

    private void CheckUserSession()
    {
        if (this.Session["IS_ADMIN"] != null)
        {
            IsAdmin = Convert.ToBoolean(Session["IS_ADMIN"]);
        }
        else
        {
            IsAdmin = false;
        }
        if (this.Session["CLSF_PROFILE_CODE"] != null)
        {
            _ProfileID = Convert.ToInt32(this.Session["CLSF_PROFILE_CODE"]);
            this.Session["CLSF_PROFILE_CODE"] = _ProfileID;
        }
        else if (this.Session["CORP_PROFILE_CODE"] != null)
        {
            _ProfileID = Convert.ToInt32(this.Session["CORP_PROFILE_CODE"]);
            this.Session["CORP_PROFILE_CODE"] = _ProfileID;
        }
        else
        {
            //Response.re
        }
        }

    #endregion AUTHENTICATION METHODS

    #region CHECKQUERYSTRING METHOD

    private void CheckQueryString()
    {
        bool blnFlag = false;

        string strPageMode = Request.QueryString["mode"];
        string strPID = Request.QueryString["pi"];

        //string strCID = Request.QueryString["CID"];


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
            intPageMode = Convert.ToInt32(Request.QueryString["mode"]);
            intProductID = Convert.ToInt32(Request.QueryString["pi"]);
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
    }

    #endregion CHECKQUERYSTRING METHOD

    #region PAGE LOAD EVENTS

    protected void Page_Load(object sender, EventArgs e)
    {
        this.CheckUserSession();
        this.CheckQueryString();

        pnlSource.Visible = IsAdmin;
        pnlSource.Enabled = IsAdmin;

        if (!Page.IsPostBack)
        {


            this.Load_Subcategory(_CategoryID);
            if (intPageMode == 1 && intProductID > 0)
            {

                this.SelectRecord_ProductProfile(intProductID);
            }
            if (intPageMode == 0 && intProductID == -1)
            {
                this.LoadList_DhakaArea();
                this.LoadProjectType("");
                Generate_ProfileSpecific_UniqueSKU(Get_Last_ProfileSpecificSKU(_ProfileID, _ClassifiedSeller));
            }
        }
    }
    #endregion PAGE LOAD EVENTS

    #region CONTROL LOAD METHODS


    private void LoadProjectType(string _Type)
    {
        ddlProjectType.Items.Clear();
        ddlProjectType.Items.Add(new ListItem("Select Project Type", "-1"));
        ddlProjectType.Items.Add(new ListItem("Ready", "1"));
        ddlProjectType.Items.Add(new ListItem("Ongoing project", "2"));
        ddlProjectType.Items.Add(new ListItem("Upcoming project", "3"));

        if (_Type == "Ready")
        {
            ddlProjectType.SelectedValue = "1";
        }
        else if (_Type == "Ongoing project")
        {
            ddlProjectType.SelectedValue = "2";
        }
        else if (_Type == "Upcoming project")
        {
            ddlProjectType.SelectedValue = "3";
        }
        else
        {
            ddlProjectType.SelectedValue = "-1";
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
                eocPropertyBean.Country_CountryID = 18; // change this portion
                DataTable dt = bocProductProfile.LoadRecord_Province(eocPropertyBean);
                if (dt.Rows.Count > 0)
                {

                    ddlLocation.Items.Clear();
                    ddlLocation.Items.Add(new ListItem("Select District", "-1"));

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
                    ddlLocation.Items.Add(new ListItem("Select Area", "-1"));
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
    /// Loads SecondSubcategory List Based On SubcategoryID.
    /// </summary>
    private void LoadRecord_SecondSubcategory(int intCategoryID, int intSubcategoryID)
    {
        try
        {
            using (BC_Corporate_ProductProfile bcProductProfile = new BC_Corporate_ProductProfile())
            {
                ddlSecondSubcategory.Items.Clear();
                ddlSecondSubcategory.Items.Add(new ListItem("Select Second Subcategory", "-1"));

                DataTable dt2ndSubcategory = bcProductProfile.LoadRecord_2ndSubcategory(intCategoryID, intSubcategoryID);
                if (dt2ndSubcategory.Rows.Count > 0)
                {
                    ddlSecondSubcategory.DataSource = dt2ndSubcategory;
                    ddlSecondSubcategory.DataValueField = "SecondSubcatID";
                    ddlSecondSubcategory.DataTextField = "SecondSubCategory";
                    ddlSecondSubcategory.DataBind();
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
    /// Loads List of seller type epending On SubcategoryID from RealEstateSellerType table.
    /// </summary>
    /// <param name="intSubcategoryID"></param>
    private void LoadList_SellerType(int intSubcategoryID)
    {
        try
        {
            using (BC_Corporate_ProductProfile bcProductProfile = new BC_Corporate_ProductProfile())
            {
                ddlSellerType.Items.Clear();
                ddlSellerType.Items.Add(new ListItem("Select Seller Type", "-1"));

                DataTable dtSellerType = bcProductProfile.RealEstate_LoadList_SellerType(intSubcategoryID);
                if (dtSellerType.Rows.Count > 0)
                {
                    ddlSellerType.DataSource = dtSellerType;
                    ddlSellerType.DataValueField = "SellerTypeID";
                    ddlSellerType.DataTextField = "SellerType";
                    ddlSellerType.DataBind();
                }
                else
                {
                    lblSystemMessage.Text = UTLUtilities.ShowGeneralMessage("No Seller Type available.");
                }
            }
        }
        catch (Exception Exp)
        {
            lblSystemMessage.Text = Exp.Message.ToString();
        }
    }




    #endregion CONTROL LOAD METHODS

    


    #region RICH DATA CONTROLS EVENTS
    #endregion RICH DATA CONTROLS EVENTS



    
   


    #region GENERAL EVENTS
    #endregion GENERAL EVENTS

    #region SELECT METHODS

    /// <summary>
    /// Loads Specific Real Estate Product Record.
    /// </summary>
    private void SelectRecord_ProductProfile(int _ProductID)
    {

        try
        {
            RealEstate objRealEstate =new RealEstate();
            objRealEstate.ProductID = _ProductID;
            RealEstateManager manager = new RealEstateManager();
            
            objRealEstate = manager.SelectRecord_RealEstate(objRealEstate);
            //objRealEstate = new RealEstate();
            if (objRealEstate.ProductID > 0)
            {
                lblSku.Text = objRealEstate.SKU;
                if (objRealEstate.IsInsideDhaka)
                {
                    this.LoadList_DhakaArea();
                    ddlLocation.SelectedValue = objRealEstate.AreaID.ToString();
                    rblLocation.SelectedValue = "InDhaka";
                    EnablePanel(pnlArea, false);
                }
                else
                {
                    this.LoadRecord_Province();
                    ddlLocation.SelectedValue = objRealEstate.ProvinceID.ToString();
                    rblLocation.SelectedValue = "OutDhaka";
                    txtArea.Text = Server.HtmlDecode(objRealEstate.Area);
                    EnablePanel(pnlArea, true);
                }
                txtAddress.Text = Server.HtmlDecode(objRealEstate.Address);
                ddlSubcategory.SelectedValue = objRealEstate.SubcategoryID.ToString();

                this.LoadRecord_SecondSubcategory(objRealEstate.CategoryID, objRealEstate.SubcategoryID);

                ddlSecondSubcategory.SelectedValue = objRealEstate.SecondSubcatID.ToString();

                this.LoadList_SellerType(objRealEstate.SubcategoryID);
                ddlSellerType.SelectedValue = objRealEstate.SellerType.ToString();

                txtSellerName.Text = Server.HtmlDecode(objRealEstate.SellerName);

                if (objRealEstate.SubcategoryID == 55)//IF FOR SALE
                {
                    EnablePanel(pnlProjectType, false);
                }
                else
                {
                    EnablePanel(pnlProjectType, true);
                    this.LoadProjectType(objRealEstate.ProjectType);
                }
                txtSize.Text = objRealEstate.Size.ToString();
                lblSizeUnit.Text = objRealEstate.SizeUnit;
                txtPrice.Text = objRealEstate.Price.ToString();
                txtQuantity.Text = objRealEstate.Quantity.ToString();
                ddlCurrency.SelectedValue = objRealEstate.Currency;


                if (objRealEstate.SecondSubcatID == 249 || objRealEstate.SecondSubcatID == 252
                    || objRealEstate.SecondSubcatID == 253 || objRealEstate.SecondSubcatID == 254) // Only for office & apartment
                {
                    txtWashRooms.Text = objRealEstate.NoOfWashRoom;
                    EnablePanel(pnlWashRooms, true);
                    if (objRealEstate.SecondSubcatID == 249 || objRealEstate.SecondSubcatID == 252) // Only for apartment
                    {
                        txtBedRooms.Text = objRealEstate.NoOfBedRoom;
                        EnablePanel(pnlBedRooms, true);
                    }
                    else
                    {
                        EnablePanel(pnlBedRooms, false);
                    }
                }
                else
                {
                    EnablePanel(pnlBedRooms, false);
                    EnablePanel(pnlWashRooms, false);
                }

                if (objRealEstate.SecondSubcatID != 250 && objRealEstate.SecondSubcatID != 251) // Everything except land
                {
                    txtServiceCharge.Text = objRealEstate.ServiceCharge.ToString();
                    EnablePanel(pnlServiceCharge, true);
                    EnablePanel(pnlCarParking, true);

                    EnablePanel(pnlLandNature, false);

                }
                else
                {
                    EnablePanel(pnlServiceCharge, false);
                    EnablePanel(pnlCarParking, false);
                    EnablePanel(pnlLandNature, true);
                }

                chkIsCarParkingAvailable.Checked = objRealEstate.IsCarParkingAvailable;
                txtProjectName.Text = Server.HtmlDecode(objRealEstate.ProjectName);
                txtDescription.Text = Server.HtmlDecode(objRealEstate.Description);

                chkIsActive.Checked = objRealEstate.IsActive;
                ImagePath = objRealEstate.ProductImage;

                #region SOURCE SELECTION

                if (objRealEstate.Source == "ApnerDeal.com")
                {
                    rblBoromela.Checked = true;
                    rblNewspaper.Checked = false;
                }
                else
                {
                    rblBoromela.Checked = false;
                    rblNewspaper.Checked = true;
                    txtNewspaper.Text = objRealEstate.Source;
                }
                chkIsDisplayAddress.Checked = objRealEstate.IsAlternativeAddress;

                #endregion SOURCE SELECTION
                
            }
            else
            {
                string strSystemMessage = "";
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
        catch (Exception Exp)
        {
            lblSystemMessage.Text = Exp.Message.ToString();
        }
    }


    #endregion SELECT METHODS

    #region DROPDOWNLIST SELECTED INDEX CHANGE EVENTS


    protected void ddlSubcategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSubcategory.SelectedValue != "-1")
        {
            this.LoadRecord_SecondSubcategory(_CategoryID, Convert.ToInt32(ddlSubcategory.SelectedValue));
            this.LoadList_SellerType(Convert.ToInt32(ddlSubcategory.SelectedValue));

            if (ddlSubcategory.SelectedValue == "54")// If For Sale Option Selected
            {
                EnablePanel(pnlProjectType, true);
            }
            else
            {
                EnablePanel(pnlProjectType, false);
            }
        }
    }
    protected void ddlSecondSubcategory_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (ddlSecondSubcategory.SelectedValue != "250" && ddlSecondSubcategory.SelectedValue != "251") // Everything Except Land
        {
            EnablePanel(pnlCarParking, true);
            EnablePanel(pnlServiceCharge, true);
            lblSizeUnit.Text = "Square Feet";
            EnablePanel(pnlLandNature, false);
        }
        else
        {
            EnablePanel(pnlCarParking, false);
            EnablePanel(pnlServiceCharge, false);
            lblSizeUnit.Text = "Katha";
            EnablePanel(pnlLandNature, true);
        }

        if (ddlSecondSubcategory.SelectedValue == "249" || ddlSecondSubcategory.SelectedValue == "252" 
            || ddlSecondSubcategory.SelectedValue == "253" || ddlSecondSubcategory.SelectedValue == "254")// For Appartments & office
        {
            //EnablePanel(pnlBedRooms, true);
            EnablePanel(pnlWashRooms, true);
            if (ddlSecondSubcategory.SelectedValue == "249" || ddlSecondSubcategory.SelectedValue == "252") // For Apartment
            {
                EnablePanel(pnlBedRooms, true);
            }
            else
            {
                EnablePanel(pnlBedRooms, false);
            }
        }
        else
        {
            EnablePanel(pnlBedRooms, false);
            EnablePanel(pnlWashRooms, false);
        }

        
    }
    protected void rblLocation_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblLocation.SelectedValue == "OutDhaka")
        {
            this.LoadRecord_Province();
            EnablePanel(pnlArea, true);
        }
        else
        {
            this.LoadList_DhakaArea();
            EnablePanel(pnlArea, false);
        }
    }

    #endregion DROPDOWNLIST SELECTED INDEX CHANGE EVENTS

    #region ADD METHOD


    private int AddRecord_ProductProfile()
    {
        int intActionResult = 0;

        RealEstate objRealEstate = new RealEstate();
        RealEstateManager manager = new RealEstateManager();

        objRealEstate.ProfileID = _ProfileID;
        objRealEstate.UserType = _ClassifiedSeller;
        objRealEstate.SKU = lblSku.Text;
        objRealEstate.CategoryID = _CategoryID;
        objRealEstate.SubcategoryID = Convert.ToInt32(ddlSubcategory.SelectedValue);
        objRealEstate.SecondSubcatID = Convert.ToInt32(ddlSecondSubcategory.SelectedValue);

        objRealEstate.SellerType = Convert.ToInt32(ddlSellerType.SelectedValue);

        objRealEstate.SellerName = Server.HtmlEncode(txtSellerName.Text);

        objRealEstate.ProjectType = ddlProjectType.SelectedItem.Text;

        objRealEstate.ProjectName = Server.HtmlEncode(txtProjectName.Text);

        if (rblLocation.SelectedValue == "OutDhaka")
        {
            objRealEstate.ProvinceID = Convert.ToInt32(ddlLocation.SelectedValue);
            objRealEstate.Area = Server.HtmlEncode(txtArea.Text);
            objRealEstate.IsInsideDhaka = false;
            objRealEstate.LocationID = objRealEstate.ProvinceID;
            objRealEstate.IsInsideDhaka = false;
        }
        else
        {
            objRealEstate.ProvinceID = _DhakaProvinceID;
            objRealEstate.AreaID = Convert.ToInt32(ddlLocation.SelectedValue);
            objRealEstate.IsInsideDhaka = true;
            objRealEstate.Area = "";
            objRealEstate.LocationID = objRealEstate.AreaID;
            objRealEstate.IsInsideDhaka = true;
        }

        objRealEstate.Size = Convert.ToDouble(txtSize.Text);
        objRealEstate.SizeUnit = lblSizeUnit.Text;

        objRealEstate.LandNature = rblLandNature.SelectedValue;
        objRealEstate.Quantity = Convert.ToInt32(txtQuantity.Text);

        objRealEstate.Price = Convert.ToDouble(txtPrice.Text);
        objRealEstate.Currency = ddlCurrency.SelectedValue;



        if (ddlSecondSubcategory.SelectedValue == "249" || ddlSecondSubcategory.SelectedValue == "252"
            || ddlSecondSubcategory.SelectedValue == "253" || ddlSecondSubcategory.SelectedValue == "254") // Only for office & apartment
        {
            objRealEstate.NoOfWashRoom = Server.HtmlEncode(txtWashRooms.Text);

            if (ddlSecondSubcategory.SelectedValue == "249" || ddlSecondSubcategory.SelectedValue == "252") // Only for apartment
            {
                objRealEstate.NoOfBedRoom = Server.HtmlEncode(txtBedRooms.Text);
            }
            else
            {
                objRealEstate.NoOfBedRoom = "";
            }
        }
        else
        {
            objRealEstate.NoOfWashRoom = "";
            objRealEstate.NoOfBedRoom = "";
        }


        if (ddlSecondSubcategory.SelectedValue != "250" && ddlSecondSubcategory.SelectedValue != "251") // Everything except land
        {
            objRealEstate.ServiceCharge = Convert.ToDouble(txtServiceCharge.Text);

        }
        else
        {
            objRealEstate.ServiceCharge = -1;
        }
        objRealEstate.IsCarParkingAvailable = chkIsCarParkingAvailable.Checked;

        objRealEstate.Description = Server.HtmlEncode(txtDescription.Text);
        objRealEstate.IsActive = chkIsActive.Checked;


        objRealEstate.Address = Server.HtmlEncode(txtAddress.Text);

        objRealEstate.ProductImage = ImagePath == "" ? "Prdtcs/Defaults/realestate.jpg" : ImagePath;

        objRealEstate.Source = rblBoromela.Checked ? "ApnerDeal.com" : txtNewspaper.Text;
        objRealEstate.IsAlternativeAddress = chkIsDisplayAddress.Checked;

        objRealEstate.UpdatedOn = DateTime.Now;

        try
        {
            intActionResult = manager.AddRealEstate(objRealEstate);
        }
        catch (Exception ex)
        {
            lblSystemMessage.Text = ex.Message;
        }

        return intActionResult;






    }

    #endregion ADD METHOD

    #region UPDATE METHODS

    private int UpdateRecord_ProductProfile(int intProductID)
    {
        int intActionResult = 0;

        RealEstate objRealEstate = new RealEstate();
        RealEstateManager manager = new RealEstateManager();

        objRealEstate.ProfileID = _ProfileID;
        objRealEstate.UserType = _ClassifiedSeller;
        objRealEstate.ProductID = intProductID;
        //objRealEstate.SKU = lblSku.Text;
        //objRealEstate.CategoryID = _CategoryID;
        objRealEstate.SubcategoryID = Convert.ToInt32(ddlSubcategory.SelectedValue);
        objRealEstate.SecondSubcatID = Convert.ToInt32(ddlSecondSubcategory.SelectedValue);

        objRealEstate.SellerType = Convert.ToInt32(ddlSellerType.SelectedValue);
        objRealEstate.SellerName = Server.HtmlEncode(txtSellerName.Text);

        objRealEstate.ProjectType = ddlProjectType.SelectedItem.Text;

        objRealEstate.ProjectName = Server.HtmlEncode(txtProjectName.Text);

        if (rblLocation.SelectedValue == "OutDhaka")
        {
            objRealEstate.ProvinceID = Convert.ToInt32(ddlLocation.SelectedValue);
            objRealEstate.Area = Server.HtmlEncode(txtArea.Text);
            objRealEstate.IsInsideDhaka = false;
            objRealEstate.LocationID = objRealEstate.ProvinceID;
            objRealEstate.IsInsideDhaka = false;
        }
        else
        {
            objRealEstate.ProvinceID = _DhakaProvinceID;
            objRealEstate.AreaID = Convert.ToInt32(ddlLocation.SelectedValue);
            objRealEstate.IsInsideDhaka = true;
            objRealEstate.Area = "";
            objRealEstate.LocationID = objRealEstate.AreaID;
            objRealEstate.IsInsideDhaka = true;
        }

        objRealEstate.Size = Convert.ToDouble(txtSize.Text);
        objRealEstate.SizeUnit = lblSizeUnit.Text;

        objRealEstate.LandNature = rblLandNature.SelectedValue;
        objRealEstate.Quantity = Convert.ToInt32(txtQuantity.Text);

        objRealEstate.Price = Convert.ToDouble(txtPrice.Text);
        objRealEstate.Currency = ddlCurrency.SelectedValue;



        if (ddlSecondSubcategory.SelectedValue == "249" || ddlSecondSubcategory.SelectedValue == "252"
            || ddlSecondSubcategory.SelectedValue == "253" || ddlSecondSubcategory.SelectedValue == "254") // Only for office & apartment
        {
            objRealEstate.NoOfWashRoom = Server.HtmlEncode(txtWashRooms.Text);

            if (ddlSecondSubcategory.SelectedValue == "249" || ddlSecondSubcategory.SelectedValue == "252") // Only for apartment
            {
                objRealEstate.NoOfBedRoom = Server.HtmlEncode(txtBedRooms.Text);
            }
            else
            {
                objRealEstate.NoOfBedRoom = "";
            }
        }
        else
        {
            objRealEstate.NoOfWashRoom = "";
            objRealEstate.NoOfBedRoom = "";
        }


        if (ddlSecondSubcategory.SelectedValue != "250" && ddlSecondSubcategory.SelectedValue != "251") // Everything except land
        {
            objRealEstate.ServiceCharge = Convert.ToDouble(txtServiceCharge.Text);

        }
        else
        {
            objRealEstate.ServiceCharge = -1;
        }
        objRealEstate.IsCarParkingAvailable = chkIsCarParkingAvailable.Checked;

        objRealEstate.Description = Server.HtmlEncode(txtDescription.Text);
        objRealEstate.IsActive = chkIsActive.Checked;


        objRealEstate.Address = Server.HtmlEncode(txtAddress.Text);

        objRealEstate.UpdatedOn = DateTime.Now;
        objRealEstate.ProductImage = ImagePath == "Prdcts/Default/realestate.jpg" ? "Prdcts/Default/realestate.jpg" : ImagePath;

        objRealEstate.Source = rblBoromela.Checked ? "ApnerDeal.com" : txtNewspaper.Text;
        objRealEstate.IsAlternativeAddress = chkIsDisplayAddress.Checked;

        try
        {
            intActionResult = manager.UpdateRealEstate(objRealEstate);
        }
        catch (Exception ex)
        {
            lblSystemMessage.Text = ex.Message;
        }

        return intActionResult;
    }


    #endregion UPDATE METHODS




    #region BUTTON CLICK EVENTS
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int intActionStatus = 0;
        string strSystemMessage = string.Empty;
        //string s = rblSource.SelectedValue;

        if (Page.IsValid)
        {
            if (intPageMode == 0 && intProductID == -1)
            {
                intActionStatus = this.AddRecord_ProductProfile();
            }
            if (intPageMode == 1 && intProductID > 0)
            {
                intActionStatus = this.UpdateRecord_ProductProfile(intProductID);
            }
            
            if (intActionStatus == 0)
            {
                lblSystemMessage.Text = "Your product could not be saved.";
            }
            else if (intActionStatus > 0)
            {
                lblSystemMessage.Text = "Successfully added your product.";
            }
            else if (intActionStatus == -1)
            {
                lblSystemMessage.Text = "Project name already exists! Please provide a different project name";
            }
            else
            {
 
            }
            
       
            


            if (intActionStatus > 0)
            {
                Response.Redirect("ControlPanel.aspx");
            }
            //if (intActionStatus == 0)
            //{
            //    DisplayErrorMessage("System failed to save product/service advertisement information.");
            //}
            //if (intActionStatus == -1)
            //{
            //    DisplayErrorMessage("Duplication occurred ! This  product/service advertisement already posted once and the deadline is not expired.");
            //}
        }
        else
        {
            //
        }
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {

        if (FileUpload1.HasFile)
        {
            try
            {
                if (FileUpload1.PostedFile.ContentLength > 204800)
                {
                    lblImageUploadMessage.Text = "File size must be less than 200KB.";
                    Page.RegisterStartupScript("Validation", "<script language=\"javascript\">window.alert(\"File size must be less than 200KB.\");</script>");
                    btnUpload.Enabled = true;
                    return;
                }
                string strExtension = "";
                String UploadedFile = FileUpload1.PostedFile.FileName;
                if (UploadedFile.Trim() == "")
                {
                    btnUpload.Enabled = true;
                    return;
                }
                int ExtractPos = UploadedFile.LastIndexOf(".");
                strExtension = UploadedFile.Substring(ExtractPos, UploadedFile.Length - ExtractPos);

                if ((strExtension.ToUpper() == ".BMP"))
                {
                    Page.RegisterStartupScript("Validation", "<script language=\"javascript\">window.alert(\"Bmp format is not allowed. Please choose any other format.\");</script>");
                    btnUpload.Enabled = true;
                    return;

                }

                string strFileName = DateTime.Now.ToString("hh.mm.ss");
                strFileName += "_" + DateTime.Today.Day.ToString();
                strFileName += "." + DateTime.Today.Month.ToString();
                strFileName += "." + DateTime.Now.Year.ToString();

                string fileName = Path.GetFileName(FileUpload1.FileName);

                FileUpload1.SaveAs(Server.MapPath(@"../Prdcts/" + "realestate" + "/_" + _ProfileID.ToString() + "_CL_" + strFileName + "_" + fileName));
                ImagePath = @"Prdcts/" + "realestate" + "/_" + _ProfileID.ToString() + "_CL_" + strFileName + "_" + fileName;

                lblImageUploadMessage.Text = "Image uploaded.";
                //if (PageMode == 0)
                //{
                //    Page.RegisterStartupScript("Validation", "<script language=\"javascript\">window.alert(\"Image uploaded.\");</script>");
                //    lblImageUploadMessage.Text = "Image uploaded.";
                //}

                //if (PageMode == 1 && ProductID > 0)
                //{
                //    if (this.UpdateImage(ProductID, CategoryID, ImagePath))
                //    {
                //        Page.RegisterStartupScript("Validation", "<script language=\"javascript\">window.alert(\"Image uploaded.\");</script>");
                //        lblImageUploadMessage.Text = "Image uploaded.";
                //    }
                //    else
                //    {
                //        Page.RegisterStartupScript("Validation", "<script language=\"javascript\">window.alert(\"Error occured while uploading image.\");</script>");
                //        lblImageUploadMessage.Text = "Error occured while uploading image.";
                //    }
                //}
                //txtImagePath.Text = imagePath;

            }
            catch (Exception ex)
            {

                lblSystemMessage.Text = "Error occured while uploading the image." + ex.Message;
            }
        }
        else
        {
            lblImageUploadMessage.Text = "Please browse an image.";
        }
        btnUpload.Enabled = true;
    }

    #endregion BUTTON CLICK EVENTS


    #region GENERAL METHODS



 

    /// <summary>
    /// Enables and disables any panel.
    /// </summary>
    /// <param name="pnl"></param>
    /// <param name="enable">If true panel is activated, deactivated otherwise.</param>
    private void EnablePanel(Panel pnl, bool enable)
    {
        pnl.Visible = enable;
        pnl.Enabled = enable;
    }

    #endregion GENERAL METHODS

    #region SKU GENERATION METHOD

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

    #endregion SKU GENERATION METHOD

    #region SERVER VALIDATOR EVENTS

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

    #endregion SERVER VALIDATOR EVENTS
}
