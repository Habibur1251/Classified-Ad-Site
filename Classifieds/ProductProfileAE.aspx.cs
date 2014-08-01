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

public partial class Classifieds_ProductProfileAE : System.Web.UI.Page
{

    /// <summary>
    /// All products properties
    /// </summary>
    #region Product Properties

    //private string strSubCategory = string.Empty;
    //private string strCategory = string.Empty;
    //private string strSecondSubcategory = string.Empty;
    private string strInsertType = string.Empty;
    private string strSku = string.Empty;
    private string strProfileID = string.Empty;
    private int intActionResult = -1;
    private string ClassifiedSeller = "0";

    private bool SellerType = false;

    private bool IsAdmin
    {
        get
        {
            object obj = ViewState["IsAdmin"];
            if (obj != null)
            {
                return (bool)obj;
            }
            return false;
        }

        set { ViewState["IsAdmin"] = value; }
    }


    private int ProfileID
    {
        get
        {
            object obj = ViewState["ProfileID"];
            if (obj != null)
            {
                return (int)obj;
            }
            return 0;
        }

        set { ViewState["ProfileID"] = value; }
    }

    private int PageMode
    {
        get
        {
            object obj = ViewState["PageMode"];
            if (obj != null)
            {
                return (int)obj;
            }
            return 0;
        }

        set { ViewState["PageMode"] = value; }
    }


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

    private string ProductTitle
    {
        get
        {
            object obj = ViewState["ProductTitle"];
            if (obj != null)
            {
                return (string)obj;
            }
            return "";
        }

        set { ViewState["ProductTitle"] = value; }
    }

    public string Category
    {
        get
        {
            object obj = ViewState["Category"];
            if (obj != null)
            {
                return (string)obj;
            }
            return "";
        }

        set { ViewState["Category"] = value; }
    }


    public string Subcategory
    {
        get
        {
            object obj = ViewState["Subcategory"];
            if (obj != null)
            {
                return (string)obj;
            }
            return "";
        }

        set { ViewState["Subcategory"] = value; }
    }


    public string SecondSubcategory
    {
        get
        {
            object obj = ViewState["SecondSubcategory"];
            if (obj != null)
            {
                return (string)obj;
            }
            return "";
        }

        set { ViewState["SecondSubcategory"] = value; }
    }

    private string Sku
    {
        get
        {
            object obj = ViewState["Sku"];
            if (obj != null)
            {
                return (string)obj;
            }
            return "";
        }

        set { ViewState["Sku"] = value; }
    }

    private int CategoryID
    {
        get
        {
            object obj = ViewState["CategoryID"];
            if (obj != null)
            {
                return (int)obj;
            }
            return 0;
        }

        set { ViewState["CategoryID"] = value; }
    }


    private int SubCategoryID
    {
        get
        {
            object obj = ViewState["SubCategoryID"];
            if (obj != null)
            {
                return (int)obj;
            }
            return 0;
        }

        set { ViewState["SubCategoryID"] = value; }
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

    private int ProductModelID
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

    public string ProductModel
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


    private int ProductID
    {
        get
        {
            object obj = ViewState["ProductID"];
            if (obj != null)
            {
                return (int)obj;
            }
            return -1;
        }

        set { ViewState["ProductID"] = value; }
    }

    private string InsertType
    {
        get
        {
            object obj = ViewState["InsertType"];
            if (obj != null)
            {
                return (string)obj;
            }
            return "";
        }

        set { ViewState["InsertType"] = value; }
    }

    private int CanEdit
    {
        get
        {
            object obj = ViewState["CanEdit"];
            if (obj != null)
            {
                return (int)obj;
            }
            return -1;
        }

        set { ViewState["CanEdit"] = value; }
    }
    private string strSystemMessage = null;
    private int intCountryID = -1;



    #endregion Product Properties

    #region GENERAL METHOD


    /// <summary>
    /// Updates Images in the database incase of Editing.
    /// </summary>
    /// <param name="_ProductSellerDetailID"></param>
    /// <param name="_CategoryID"></param>
    /// <param name="_Image"></param>
    /// <returns></returns>
    private bool UpdateImage(int _ProductID, int _CategoryID, string _Image)
    {
        int intActionResult = 0;
        try
        {
            using (BC_Product bcProduct = new BC_Product())
            {
                intActionResult = bcProduct.UpdateImage(_ProductID, _CategoryID, _Image);
            }
        }
        catch (Exception ex)
        {
            lblSystemMessage.Text = UTLUtilities.ShowErrorMessage(ex.Message);
        }
        return intActionResult > 0 ? true : false;
    }

    private void CheckUserSession()
    {
        if (this.Session["CLSF_PROFILE_CODE"] != null && this.Session["CLSF_COUNTRY_CODE"] != null)
        {
            ProfileID = Convert.ToInt32(this.Session["CLSF_PROFILE_CODE"].ToString());
            intCountryID = Convert.ToInt32(this.Session["CLSF_COUNTRY_CODE"].ToString());
            IsAdmin = Convert.ToBoolean(this.Session["IS_ADMIN"].ToString());
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
    }
    private void CheckQueryString()
    {

        bool blnFlag = false;


       
        strProfileID = Request.QueryString["pfi"];
        Sku = Request.QueryString["sku"];
        InsertType = Request.QueryString["inserttype"];
        ProductTitle = Server.UrlDecode(Request.QueryString["title"]);
        Category = Server.UrlDecode(Request.QueryString["c"]);
        Subcategory = Server.UrlDecode(Request.QueryString["sc"]);
        SecondSubcategory = Server.UrlDecode(Request.QueryString["ssc"]);

        if (Request.QueryString["mode"] != null
            && !UTLUtilities.IsNumeric(Request.QueryString["mode"])
            && Request.QueryString["pi"] != null
            && Request.QueryString["sku"] != null
            && Request.QueryString["pfi"] != null
            && Request.QueryString["ci"] != null
            && Request.QueryString["sci"] != null
            && Request.QueryString["ssci"] != null
            && UTLUtilities.IsNumeric(Request.QueryString["pi"])
            && UTLUtilities.IsNumeric(Request.QueryString["pfi"])
            && UTLUtilities.IsNumeric(Request.QueryString["ci"])
            && UTLUtilities.IsNumeric(Request.QueryString["sci"])
            && UTLUtilities.IsNumeric(Request.QueryString["ssci"]))
        {
            blnFlag = false;
        }
        else
        {
            
            Sku = Server.UrlDecode( Request.QueryString["sku"].ToString());
            PageMode = Convert.ToInt32(Request.QueryString["mode"]);
            if (PageMode == 0 || PageMode == 1)
            {
                ProductID = Convert.ToInt32(Request.QueryString["pi"]);
                ProfileID = Convert.ToInt32(Request.QueryString["pfi"]);
                CategoryID = Convert.ToInt32(Request.QueryString["ci"]);
                SubCategoryID = Convert.ToInt32(Request.QueryString["sci"]);
                SecondSubcatID = Convert.ToInt32(Request.QueryString["ssci"]);

                if (CategoryID > 0 && SubCategoryID > 0 && SecondSubcatID > 0)
                {
                    blnFlag = true;
                    if (CategoryID != 1 && Request.QueryString["modelkey"] != null
                             && Request.QueryString["model"] != null
                             && UTLUtilities.IsNumeric(Request.QueryString["modelkey"]))
                    {
                        ProductModelID = Convert.ToInt32(Request.QueryString["modelkey"]);
                        ProductModel = Server.UrlDecode(Request.QueryString["model"]);
                        blnFlag = true;
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

        if (blnFlag == false)
        {
            Response.Redirect("Default.aspx");
        }
    }

    /// <summary>
    /// isEnable = 'True', disables the Master Entry field
    /// </summary>
    /// <param name="isEnable"></param>
    private void Block_MasterField(bool isEnable)
    {
        #region MOVIE DVD GAMES

        txtAuthorMovie.ReadOnly = isEnable;
        txtPublisherMovie.ReadOnly = isEnable;
        txtEditionMovie.ReadOnly = isEnable;
        lblAuthorMovie.Visible = isEnable;
        lblEditionMovie.Visible = isEnable;
        lblPublisherMovie.Visible = isEnable;
        
        

        #endregion MOVIE DVD GAMES

        //txtPaperBack.ReadOnly = isEnable;
        txtISBN.ReadOnly = isEnable;
        txtAuthor.ReadOnly = isEnable;
        txtEdition.ReadOnly = isEnable;
        txtPublisher.ReadOnly = isEnable;
        Enable_Panel(pnlImageUpload, !isEnable);

        lblAuthor.Visible = isEnable;
        lblEdition.Visible = isEnable;
        lblPublisher.Visible = isEnable;
        lblIsbn.Visible = isEnable;

        if (ProfileID == CanEdit)
        {
            txtISBN.ReadOnly = !isEnable;
            txtAuthor.ReadOnly = !isEnable;
            Enable_Panel(pnlImageUpload, !isEnable);
            lblAuthor.Visible = !isEnable;
            lblIsbn.Visible = !isEnable;
        }
    }


    /// <summary>
    /// Enables or disables a Panel
    /// </summary>
    /// <param name="isEnable">True makes a panel enable and visible, false disables and makes invisible.</param>
    private void Enable_Panel(Panel pnl, bool isEnable)
    {
        pnl.Visible = isEnable;
        pnl.Enabled = isEnable;
    }


    #endregion GENERAL METHOD

    #region CONTROLS EVENTS


    protected void chkPaymentOption_SelectedIndexChanged(object sender, EventArgs e)
    {
        string s = e.ToString();
    }

    protected void chkCod_CheckedChanged(object sender, EventArgs e)
    {
        if (chkCod.Checked)
        {
            panelDeliveryOption.Visible = true;
            panelDeliveryOption.Enabled = true;
        }
        else
        {
            panelDeliveryOption.Visible = false;
            panelDeliveryOption.Enabled = false;
        }

    }

    protected void chkNegotiable_CheckedChanged(object sender, EventArgs e)
    {
        if (chkNegotiable.Checked)
        {
            txtProductPrice.Text = "0";
            txtProductPrice.Enabled = false;
        }
        else
        {
            txtProductPrice.Text = "";
            txtProductPrice.Enabled = true;
        }
    }


    protected void ddlDeliveryArea_SelectedIndexChanged(object sender, EventArgs args)
    {
        if (ddlDeliveryArea.SelectedItem.Text == "Outside of Bangladesh")
        {
            pnlForeignAddress.Visible = true;
            pnlForeignAddress.Enabled = true;
        }
        else
        {
            pnlForeignAddress.Visible = false;
            pnlForeignAddress.Enabled = false;
        }

    }

    #endregion CONTROLS EVENTS

    #region DISPLAY PREVIEW METHOD


    private void DisplayPreview()
    {
        string strPreviewUrl = "";

        if (ImagePath == "")
        {
            ImagePath = @"../Corporate_ProductImage/default.png";
        }
        strPreviewUrl =
            "Sku=" + Server.UrlEncode(lblSku.Text)
            + "&Title=" + Server.UrlEncode(lblProductTitle.Text)
            + "&C=" + Server.UrlEncode(lblCategory.Text)
            + "&SC=" + Server.UrlEncode(lblSubcategory.Text)
            + "&SSC=" + Server.UrlEncode(lblSecondSubcategory.Text)
            + "&Q=" + txtQuantity.Text
            + "&Price=" + Server.UrlEncode(txtProductPrice.Text)
            + "&Condition=" + ddlCondition.SelectedItem.Text
            + "&ConditionNote=" + Server.UrlEncode(txtConditionNote.Text)
            + "&Description=" + Server.UrlEncode(txtDescription.Text)


            + "&Image=" + Server.UrlEncode(ImagePath)
            + "&DeliveryArea=" + Server.UrlEncode(ddlDeliveryArea.SelectedItem.Text)
            + "&ForeignAddress=" + Server.UrlEncode(txtDescription.Text)
            + "&Cod=" + Server.UrlEncode(chkCod.Text)
            + "&IsCod=" + chkCod.Checked
            + "&Pfs=" + Server.UrlEncode(chkPfs.Text)
            + "&IsPfs=" + chkPfs.Checked
            + "&CashDeposit=" + Server.UrlEncode(chkCash.Text)
            + "&IsCashDeposit=" + chkCash.Checked
            + "&SalePrice="  //txtSalePrice.Text
            + "&SaleFromDate="  //txtFromDate.Text
            + "&SaleToDate="  //txtToDate.Text
            + "&Currency=" + ddlCurrency.SelectedValue
            + "&CID=" + CategoryID.ToString()


            + "&PaperBack=" + Server.UrlEncode(txtPaperBack.Text)
            + "&Author=" + Server.UrlEncode(txtAuthor.Text)
            + "&Isbn=" + Server.UrlEncode(txtISBN.Text)
            + "&Publisher=" + Server.UrlEncode(txtPublisher.Text)
            + "&Language=" + Server.UrlEncode(txtLanguage.Text)
            + "&Dimension=" + Server.UrlEncode(txtDimensionForBook.Text)
            + "&Shipping=" + Server.UrlEncode(txtShippingWeight.Text)
            + "&Edition=" + Server.UrlEncode(txtEdition.Text)


            + "&Dedicated_Video_Memory=" + txtDedicatedVideoMemory.Text
            + "&Shared_Video_Memory=" + txtSharedVideoMemory.Text
            + "&Tv_Tuner=" + txtTvTuner.Text
            + "&Video_Memory=" + txtVideoMemory.Text
            + "&HDCP_Compliant=" + txtHDCPCompliant.Text
            + "&Audio_Output=" + txtAudioOutput.Text
            + "&Digital_Input=" + txtDigitalInput.Text
            + "&Digital_Output=" + txtDigitalOutput.Text
            + "&Integreted_Microphone=" + txtIntegretedMicrophone.Text
            + "&Line_Out=" + txtLineOut.Text
            + "&Line_In_Input=" + txtLineInInput.Text
            + "&Microphone_Input=" + txtMicrophoneInput.Text
            + "&Sound_Card=" + txtSoundCard.Text
            + "&Ethernet_Port=" + txtEthernetPort.Text
            + "&Integreted_Bluetooth=" + txtIntegretedBluetooth.Text
            + "&Integreted_WiFi=" + txtIntegretedWiFi.Text
            + "&Card_Reader=" + txtCardReader.Text
            + "&DVI_Output=" + txtDVIOutput.Text
            + "&ESata=" + txtESata.Text
            + "&HDMI=" + txtHDMI.Text
            + "&USB2=" + txtUSB2.Text
            + "&VGA_Output=" + txtVGAOutput.Text
            + "&Webcam=" + txtWebcam.Text

            + "&Vin=" + txtVIN.Text
            + "&Mileage=" + txtMileage.Text
            + "&CarSubModel=" + txtCarSubModel.Text
            + "&RegYr=" + txtVehicleRegYear.Text
            + "&Model=" + ProductModel
            ;

        lbtnBookPreview.Attributes.Add("onclick", "window.open('../ProductPreview/BookPreview.aspx?" + strPreviewUrl + "', 'Preview','width=650,height=700,toolbars=no,scrollbars=yes,resizable=no,top=20,left=200'); return false;");
        lbtnCarPreview.Attributes.Add("onclick", "window.open('../ProductPreview/BookPreview.aspx?" + strPreviewUrl + "', 'Preview','width=650,height=700,toolbars=no,scrollbars=yes,resizable=no,top=20,left=200'); return false;");
        lbtnComputerPreview.Attributes.Add("onclick", "window.open('../ProductPreview/BookPreview.aspx?" + strPreviewUrl + "', 'Preview','width=650,height=700,toolbars=no,scrollbars=yes,resizable=no,top=20,left=200'); return false;");
        lbtnMobilePreview.Attributes.Add("onclick", "window.open('../ProductPreview/BookPreview.aspx?" + strPreviewUrl + "', 'Preview','width=650,height=700,toolbars=no,scrollbars=yes,resizable=no,top=20,left=200'); return false;");
        lbtnElectronicsPreview.Attributes.Add("onclick", "window.open('../ProductPreview/BookPreview.aspx?" + strPreviewUrl + "', 'Preview','width=650,height=700,toolbars=no,scrollbars=yes,resizable=no,top=20,left=200'); return false;");
        lbtnMovieDvdGamePreview.Attributes.Add("onclick", "window.open('../ProductPreview/BookPreview.aspx?" + strPreviewUrl + "', 'Preview','width=650,height=700,toolbars=no,scrollbars=yes,resizable=no,top=20,left=200'); return false;");

    }


    #endregion DISPLAY PREVIEW METHOD

    #region PAGE LOAD EVENTS


    protected void Page_Load(object sender, EventArgs e)
    {
        
        UTLUtilities.CP_ActiveModule = 3;
        lblSystemMessage.Text = "";
        ddlCurrency.Enabled = false;
        this.CheckUserSession();


        pnlSource.Visible = IsAdmin;
        pnlSource.Enabled = IsAdmin;

        if (!Page.IsPostBack)
        {
            this.CheckQueryString();
            this.Initialize_ProductHeader();

            ddlCurrency.SelectedValue = intCountryID == 18 ? "BDT" : "USD";
            if (PageMode == 1 && ProductID > 0)
            {
                if (CategoryID == 1)
                {
                    this.SelectRecord_Book();
                }
                else if (CategoryID == 2)
                {
                    this.SelectRecord_Mobile();
                }
                else if (CategoryID == 3)
                {
                    this.SelectRecord_Automobile();
                }
                else if (CategoryID == 4)
                {
                    this.SelectRecord_Computer();
                }
                else if (CategoryID == 6)
                {
                    this.SelectRecord_Electronics();
                }
                else if (CategoryID == 8)     // For MovieDvd 
                {
                    this.SelectRecord_MovieDvd();
                }
                else
                {
                    Response.Redirect("../Error.aspx?data=" + UTLUtilities.Encrypt("The Product may have been removed by the administrator."));
                }

            }
            else if (PageMode == 0 && InsertType == "tag")
            {
                if (CategoryID == 1)
                {
                    this.Select_MasterBookRecord(CategoryID, SubCategoryID, SecondSubcatID, ProfileID, ProductID);
                }
                else if (CategoryID == 2)
                {
                    this.Select_Master_MobileRecord(CategoryID, SubCategoryID, SecondSubcatID, ProfileID, ProductID);
                }
                else if (CategoryID == 3)
                {
                    this.Select_Master_AutoMobileRecord(CategoryID, SubCategoryID, SecondSubcatID, ProductID);
                }
                else if (CategoryID == 6)
                {
                    this.Select_Master_ElectronicsRecord(CategoryID, SubCategoryID, SecondSubcatID, ProductID, ProfileID);
                }
                else if (CategoryID == 8)  // For MovieDvd 
                {
                    this.Select_MasterMovieDvdGameRecord(CategoryID, SubCategoryID, SecondSubcatID, ProfileID, ProductID);
                }

                
                else
                {

                }

                this.Block_MasterField(true);
            }
        }

        if (CategoryID == 1 || CategoryID == 8)
        {
            pnlProductYear.Visible = false;
            pnlProductYear.Enabled = false;
        }
        else
        {

            pnlProductYear.Visible = true;
            pnlProductYear.Enabled = true;
        }

        DisplayPreview();
        Initialize_ProductInfoControl();
        Initialize_ProductHeader();

        chkNegotiable.Visible = IsAdmin;
    }


    #endregion PAGE LOAD EVENTS

    #region INITIALIZATION METHODS


    /// <summary>
    /// Displays Products General Information
    /// </summary>
    private void Initialize_ProductHeader()
    {
        lblSku.Text = Sku;
        lblCategory.Text = Category;
        lblSubcategory.Text = Subcategory;
        lblSecondSubcategory.Text = SecondSubcategory;
        lblProductTitle.Text = ProductTitle;

        lblSkuMovie.Text = Sku;
        lblCategoryMovie.Text = Category;
        lblSubcategoryMovie.Text = Subcategory;
        lblSecondSubCatMovie.Text = SecondSubcategory;
        lblProductTitleMovie.Text = ProductTitle;
    }




    private void Initialize_ProductInfoControl()
    {
        if (CategoryID == 2)
        {
            prodInfoMobile_Ctrl.Sku = Sku;
            prodInfoMobile_Ctrl.Category = Category;
            prodInfoMobile_Ctrl.Subcategory = Subcategory;
            prodInfoMobile_Ctrl.SecondSubcategory = SecondSubcategory;
            prodInfoMobile_Ctrl.Model = ProductModel;
            prodInfoMobile_Ctrl.ProductTitle = ProductTitle;
        }
        else if (CategoryID == 3)
        {
            prodInfoAutomobile_Ctrl.Sku = Sku;
            prodInfoAutomobile_Ctrl.Category = Category;
            prodInfoAutomobile_Ctrl.Subcategory = Subcategory;
            prodInfoAutomobile_Ctrl.SecondSubcategory = SecondSubcategory;
            prodInfoAutomobile_Ctrl.Model = ProductModel;
            prodInfoAutomobile_Ctrl.ProductTitle = ProductTitle;
        }
        else if (CategoryID == 4)
        {
            prodInfoComputer_Ctrl.Sku = Sku;
            prodInfoComputer_Ctrl.Category = Category;
            prodInfoComputer_Ctrl.Subcategory = Subcategory;
            prodInfoComputer_Ctrl.SecondSubcategory = SecondSubcategory;
            prodInfoComputer_Ctrl.Model = ProductModel;
            prodInfoComputer_Ctrl.ProductTitle = ProductTitle;
        }
        else if (CategoryID == 6)
        {
            prodInfoElectronics_Ctrl.Sku = Sku;
            prodInfoElectronics_Ctrl.Category = Category;
            prodInfoElectronics_Ctrl.Subcategory = Subcategory;
            prodInfoElectronics_Ctrl.SecondSubcategory = SecondSubcategory;
            prodInfoElectronics_Ctrl.Model = ProductModel;
            prodInfoElectronics_Ctrl.ProductTitle = ProductTitle;

        }
        else
        {

        }






    }

    #endregion INITIALIZATION METHODS

    #region FOR BOOK


    /// <summary>
    /// Inserts a new row for Book both in Product_Master and Product_Seller_Detail table.
    /// </summary>
    /// <returns></returns>
    private int Add_MasterRecord_BookProduct()
    {
        int intActionResult = 0;

        if (!Check_IsMasterProductDuplicate(CategoryID, SubCategoryID, SecondSubcatID, ProductTitle))
        {
            try
            {
                using (BOC_Corporate_ProdProf_Book bocProductProfile = new BOC_Corporate_ProdProf_Book())
                {
                    EOC_PropertyBean eocPropertyBean = new EOC_PropertyBean();

                    eocPropertyBean.Business_UserProfile_ProfileID = ProfileID;
                    eocPropertyBean.Category_CategoryID = CategoryID;
                    eocPropertyBean.Subcategory_SubcategoryID = SubCategoryID;
                    eocPropertyBean.SecondSubcategory_SubcategoryID = SecondSubcatID;

                    eocPropertyBean.Business_ProductProfile_Books_BookTitle = ProductTitle;
                    eocPropertyBean.Business_ProductProfile_Books_SKU = Sku;
                    eocPropertyBean.Business_ProductProfile_Description = txtDescription.Text;
                    eocPropertyBean.Business_ProductProfile_Quantity = Convert.ToInt32(txtQuantity.Text);

                    eocPropertyBean.Business_ProductProfile_Books_Currency = ddlCurrency.Text;
                    eocPropertyBean.Business_ProductProfile_Books_ProductPrice = Convert.ToDouble(txtProductPrice.Text);

                    eocPropertyBean.Business_ProductProfile_Books_SalePrice = 0.00;
                    eocPropertyBean.Business_ProductProfile_Books_StartDate = DateTime.Now;
                    eocPropertyBean.Business_ProductProfile_Books_EndDate = DateTime.Now;

                    eocPropertyBean.Business_Product_Profile_Books_Condition = ddlCondition.SelectedValue;
                    eocPropertyBean.Business_Product_Profile_Books_ConditionNote = txtConditionNote.Text;

                    eocPropertyBean.Business_ProductProfile_CashOnDelivery = chkCod.Checked;
                    eocPropertyBean.Business_ProductProfile_PickFromStore = chkPfs.Checked;
                    eocPropertyBean.Business_ProductProfile_CashDeposit = chkCash.Checked;
                    eocPropertyBean.IsNegotiable = chkNegotiable.Checked;

                    eocPropertyBean.Business_ProductProfile_General_DeliveryArea = ddlDeliveryArea.SelectedValue;

                    if (chkCod.Checked && ddlDeliveryArea.SelectedValue == "Outside of Bangladesh")
                    {
                        eocPropertyBean.Business_ProductProfile_SellerForeignAddress = txtSellerForeignAddress.Text;
                    }
                    else
                    {
                        eocPropertyBean.Business_ProductProfile_SellerForeignAddress = "";
                    }

                    if (string.IsNullOrEmpty(ImagePath))
                    {
                        eocPropertyBean.Business_ProductProfile_Books_ProductImage = @"Classifieds_ProductImage/default.png";
                    }
                    else
                    {
                        eocPropertyBean.Business_ProductProfile_Books_ProductImage = ImagePath;
                    }

                    eocPropertyBean.Business_ProductProfile_Books_PaperBackForBook = txtPaperBack.Text;
                    eocPropertyBean.Business_Product_Profile_Books_Language = txtLanguage.Text;
                    eocPropertyBean.Business_Product_Profile_Books_DimensionForBook = txtDimensionForBook.Text;
                    eocPropertyBean.Business_Product_Profile_Books_ShippingWeight = txtShippingWeight.Text;
                    eocPropertyBean.Business_ProductProfile_Books_Edition = txtEdition.Text;
                    eocPropertyBean.Business_ProductProfile_Books_ISBN = txtISBN.Text;
                    eocPropertyBean.Business_ProductProfile_Books_Author = txtAuthor.Text;
                    eocPropertyBean.Business_ProductProfile_Books_Publisher = txtPublisher.Text;


                    eocPropertyBean.UserType = ClassifiedSeller;

                    eocPropertyBean.UpdatedOn = DateTime.Now;
                    eocPropertyBean.Business_ProductProfile_IsActive = chkBookIsActive.Checked;


                    eocPropertyBean.Source = rblBoromela.Checked ? "ApnerDeal.com" : txtNewspaper.Text;
                    eocPropertyBean.Is_Alternative_Address = chkIsDisplayAddress.Checked;

                    intActionResult = bocProductProfile.Insert_MasterRecord_BookProduct(eocPropertyBean);

                }
            }
            catch (Exception Exp)
            {
                lblSystemMessage.Text = Exp.Message.ToString();
            }
        }
        else
        {
            return -2;
        }
        return intActionResult;
    }

     /// <summary>
    /// Inserts a new row for Book in Product_Seller_Detail table.
    /// </summary>
    private int Add_DetailRecord_BookProduct()
    {
        //int intActionResult = 0;
        if (!Is_Seller_Tagged_Once(ProductID, ProfileID, SellerType, CategoryID))
        {
            try
            {
                using (BOC_Corporate_ProdProf_Book bocProductProfile = new BOC_Corporate_ProdProf_Book())
                {
                    EOC_PropertyBean eocPropertyBean = new EOC_PropertyBean();

                    eocPropertyBean.Business_UserProfile_ProfileID = ProfileID;
                    eocPropertyBean.Business_ProductProfile_Books_ProductID = ProductID;

                    eocPropertyBean.Business_ProductProfile_Books_SKU = Sku;
                    eocPropertyBean.Business_ProductProfile_Description = txtDescription.Text;
                    eocPropertyBean.Business_ProductProfile_Quantity = Convert.ToInt32(txtQuantity.Text);
                    eocPropertyBean.Business_ProductProfile_Books_Currency = ddlCurrency.SelectedValue;
                    eocPropertyBean.Business_ProductProfile_Books_ProductPrice = Convert.ToDouble(txtProductPrice.Text);
                    eocPropertyBean.IsNegotiable = chkNegotiable.Checked;


                    eocPropertyBean.Business_ProductProfile_Books_SalePrice = 0.00;
                    eocPropertyBean.Business_ProductProfile_Books_StartDate = DateTime.Now;
                    eocPropertyBean.Business_ProductProfile_Books_EndDate = DateTime.Now;


                    eocPropertyBean.Business_Product_Profile_Books_Condition = ddlCondition.SelectedValue;
                    eocPropertyBean.Business_Product_Profile_Books_ConditionNote = txtConditionNote.Text;

                    eocPropertyBean.Business_ProductProfile_CashOnDelivery = chkCod.Checked;
                    eocPropertyBean.Business_ProductProfile_PickFromStore = chkPfs.Checked;
                    eocPropertyBean.Business_ProductProfile_CashDeposit = chkCash.Checked;
                    eocPropertyBean.Business_ProductProfile_General_DeliveryArea = ddlDeliveryArea.SelectedItem.Text;


                    if (chkCod.Checked && ddlDeliveryArea.SelectedValue == "Outside of Bangladesh")
                    {
                        eocPropertyBean.Business_ProductProfile_SellerForeignAddress = txtSellerForeignAddress.Text;
                    }
                    else
                    {
                        eocPropertyBean.Business_ProductProfile_SellerForeignAddress = "";
                    }


                    eocPropertyBean.Business_ProductProfile_Books_PaperBackForBook = txtPaperBack.Text;
                    eocPropertyBean.Business_Product_Profile_Books_Language = txtLanguage.Text;
                    eocPropertyBean.Business_Product_Profile_Books_DimensionForBook = txtDimensionForBook.Text;
                    eocPropertyBean.Business_Product_Profile_Books_ShippingWeight = txtShippingWeight.Text;


                    eocPropertyBean.UserType = ClassifiedSeller;

                    eocPropertyBean.UpdatedOn = DateTime.Now;
                    eocPropertyBean.Business_ProductProfile_IsActive = chkBookIsActive.Checked;

                    eocPropertyBean.Source = rblBoromela.Checked ? "ApnerDeal.com" : txtNewspaper.Text;
                    eocPropertyBean.Is_Alternative_Address = chkIsDisplayAddress.Checked;

                    intActionResult = bocProductProfile.Insert_DetailRecord_BookProduct(eocPropertyBean);

                }
            }
            catch (Exception Exp)
            {
                lblSystemMessage.Text = Exp.Message.ToString();
            }
        }
        else
        {
            
            return -2;
        }
        return intActionResult;
    }

    
    /// <summary>
    /// Updates Book Record of the Master Seller.
    /// </summary>
    /// <returns></returns>
    private int Update_MasterSeller_BookRecord()
    {


        try
        {
            using (BOC_Corporate_ProdProf_Book bocProductProfile = new BOC_Corporate_ProdProf_Book())
            {
                EOC_PropertyBean eocPropertyBean = new EOC_PropertyBean();

                eocPropertyBean.Business_UserProfile_ProfileID = ProfileID;
                eocPropertyBean.Business_ProductProfile_Books_ProductID = ProductID;
                eocPropertyBean.Category_CategoryID = CategoryID;

                eocPropertyBean.Subcategory_SubcategoryID = SubCategoryID;
                eocPropertyBean.SecondSubcategory_SubcategoryID = SecondSubcatID;
                eocPropertyBean.Business_ProductProfile_Description = txtDescription.Text;


                eocPropertyBean.Business_ProductProfile_Quantity = Convert.ToInt32(txtQuantity.Text);
                eocPropertyBean.Business_ProductProfile_Books_Currency = ddlCurrency.SelectedValue;
                eocPropertyBean.Business_ProductProfile_Books_ProductPrice = Convert.ToDouble(txtProductPrice.Text);

                eocPropertyBean.IsNegotiable = chkNegotiable.Checked;


                eocPropertyBean.Business_ProductProfile_Books_SalePrice = 0.00;
                eocPropertyBean.Business_ProductProfile_Books_StartDate = DateTime.Now;
                eocPropertyBean.Business_ProductProfile_Books_EndDate = DateTime.Now;

                eocPropertyBean.Business_Product_Profile_Books_Condition = ddlCondition.SelectedValue;
                eocPropertyBean.Business_Product_Profile_Books_ConditionNote = txtConditionNote.Text;
                //eocPropertyBean.Business_ProductProfile_Books_PaymentOption = ddlPaymentOption.SelectedValue;
                eocPropertyBean.Business_ProductProfile_CashOnDelivery = chkCod.Checked;
                eocPropertyBean.Business_ProductProfile_PickFromStore = chkPfs.Checked;
                eocPropertyBean.Business_ProductProfile_CashDeposit = chkCash.Checked;
                eocPropertyBean.Business_ProductProfile_General_DeliveryArea = ddlDeliveryArea.SelectedValue;

                if (chkCod.Checked && ddlDeliveryArea.SelectedValue == "Outside of Bangladesh")
                {
                    eocPropertyBean.Business_ProductProfile_SellerForeignAddress = txtSellerForeignAddress.Text;
                }
                else
                {
                    eocPropertyBean.Business_ProductProfile_SellerForeignAddress = "";
                }


                if (string.IsNullOrEmpty(ImagePath))
                {
                    eocPropertyBean.Business_ProductProfile_Books_ProductImage = @"Classifieds_ProductImage/default.png";
                }
                else
                {
                    eocPropertyBean.Business_ProductProfile_Books_ProductImage = ImagePath;
                }

                eocPropertyBean.Business_ProductProfile_Books_PaperBackForBook = txtPaperBack.Text;
                eocPropertyBean.Business_Product_Profile_Books_Language = txtLanguage.Text;
                eocPropertyBean.Business_Product_Profile_Books_DimensionForBook = txtDimensionForBook.Text;
                eocPropertyBean.Business_Product_Profile_Books_ShippingWeight = txtShippingWeight.Text;

                eocPropertyBean.Business_ProductProfile_Books_ISBN = txtISBN.Text;
                eocPropertyBean.Business_ProductProfile_Books_Author = txtAuthor.Text;
                eocPropertyBean.UpdatedOn = DateTime.Now;
                eocPropertyBean.Business_ProductProfile_IsActive = chkBookIsActive.Checked;

                eocPropertyBean.UserType = ClassifiedSeller;
                eocPropertyBean.Business_ProductProfile_Books_Publisher = txtPublisher.Text;

                eocPropertyBean.Source = rblBoromela.Checked ? "ApnerDeal.com" : txtNewspaper.Text;
                eocPropertyBean.Is_Alternative_Address = chkIsDisplayAddress.Checked;

                intActionResult = bocProductProfile.Update_MasterSeller_BookProduct(eocPropertyBean);

            }
        }
        catch (Exception Exp)
        {
            lblSystemMessage.Text = Exp.Message.ToString();
        }

        return intActionResult;
    }




    /// <summary>
    /// Updates Book Record of the Tag Seller.
    /// </summary>
    /// <returns></returns>
    private int Update_TagSeller_BookRecord()
    {
        int intActionResult = 0;

        try
        {
            using (BOC_Corporate_ProdProf_Book bocProductProfile = new BOC_Corporate_ProdProf_Book())
            {
                EOC_PropertyBean eocPropertyBean = new EOC_PropertyBean();
                eocPropertyBean.Business_UserProfile_ProfileID = ProfileID;
                eocPropertyBean.Business_ProductProfile_Books_ProductID = ProductID;

                eocPropertyBean.Business_ProductProfile_Description = txtDescription.Text;
                eocPropertyBean.Business_ProductProfile_Quantity = Convert.ToInt32(txtQuantity.Text);
                eocPropertyBean.Business_ProductProfile_Books_Currency = ddlCurrency.SelectedValue;
                eocPropertyBean.Business_ProductProfile_Books_ProductPrice = Convert.ToDouble(txtProductPrice.Text);


                eocPropertyBean.Business_ProductProfile_Books_SalePrice = 0.00;
                eocPropertyBean.Business_ProductProfile_Books_StartDate = DateTime.Now;
                eocPropertyBean.Business_ProductProfile_Books_EndDate = DateTime.Now;


                eocPropertyBean.Business_Product_Profile_Books_Condition = ddlCondition.SelectedValue;
                eocPropertyBean.Business_Product_Profile_Books_ConditionNote = txtConditionNote.Text;

                eocPropertyBean.Business_ProductProfile_CashOnDelivery = chkCod.Checked;
                eocPropertyBean.Business_ProductProfile_PickFromStore = chkPfs.Checked;
                eocPropertyBean.Business_ProductProfile_CashDeposit = chkCash.Checked;
                eocPropertyBean.Business_ProductProfile_General_DeliveryArea = ddlDeliveryArea.SelectedValue;

                if (chkCod.Checked && ddlDeliveryArea.SelectedValue == "Outside of Bangladesh")
                {
                    eocPropertyBean.Business_ProductProfile_SellerForeignAddress = txtSellerForeignAddress.Text;
                }
                else
                {
                    eocPropertyBean.Business_ProductProfile_SellerForeignAddress = "";
                }


                eocPropertyBean.Business_ProductProfile_Books_PaperBackForBook = txtPaperBack.Text;
                eocPropertyBean.Business_Product_Profile_Books_Language = txtLanguage.Text;
                eocPropertyBean.Business_Product_Profile_Books_DimensionForBook = txtDimensionForBook.Text;
                eocPropertyBean.Business_Product_Profile_Books_ShippingWeight = txtShippingWeight.Text;


                eocPropertyBean.UserType = ClassifiedSeller;

                eocPropertyBean.UpdatedOn = DateTime.Now;

                eocPropertyBean.IsNegotiable = chkNegotiable.Checked;
                eocPropertyBean.Business_ProductProfile_IsActive = chkBookIsActive.Checked;

                eocPropertyBean.Source = rblBoromela.Checked ? "ApnerDeal.com" : txtNewspaper.Text;
                eocPropertyBean.Is_Alternative_Address = chkIsDisplayAddress.Checked;

                intActionResult = bocProductProfile.Update_TagSeller_BookRecord(eocPropertyBean);
            }
        }
        catch (Exception Exp)
        {
            lblSystemMessage.Text = Exp.Message.ToString();
        }

        return intActionResult;

    }


  

    /// <summary>
    /// Selects ISBN, Author, Publisher name from Product_Master_Book table.
    /// For Tag users. Will be used in case of Adding a book.
    /// USP: USP_CP_Get_MasterBookRecord
    /// </summary>
    /// <param name="categoryID"></param>
    /// <param name="subcategoryID"></param>
    /// <param name="secondSubcatID"></param>
    /// <param name="profileID"></param>
    /// <param name="productID"></param>
    private void Select_MasterBookRecord(int categoryID, int subcategoryID, int secondSubcatID, int profileID, int productID)
    {
        DataTable dt = new DataTable();
        try
        {
            using (BC_Product bcProduct = new BC_Product())
            {
                dt = bcProduct.SelectSpecific_MasterBookRecord(categoryID, subcategoryID, secondSubcatID, productID);
                if (dt.Rows.Count > 0)
                {
                    txtISBN.Text = dt.Rows[0]["ISBN"].ToString();
                    txtAuthor.Text = dt.Rows[0]["Author"].ToString();
                    txtPublisher.Text = dt.Rows[0]["Publisher"].ToString();
                    txtEdition.Text = dt.Rows[0]["Edition"].ToString();
                }
            }
        }
        catch (Exception ex)
        {
            lblSystemMessage.Text = ex.Message;
        }
    }



    /// <summary>
    /// Selects Dropdownlists and fills out texboxes in case of editing. 
    /// </summary>
    private void SelectRecord_Book()
    {
        //bool _ClassifiedSeller = false;
        try
        {
            using (BC_Book objBook = new BC_Book())
            {
                DataTable dtBook = objBook.LoadRecord_CL_SpecificBook(ProductID, ProfileID, CategoryID, SubCategoryID, SecondSubcatID);

                if (dtBook.Rows.Count > 0)
                {
                    txtQuantity.Text = dtBook.Rows[0]["Qty"].ToString();

                    ddlCurrency.SelectedItem.Text = dtBook.Rows[0]["Currency"].ToString();
                    txtDescription.Text = dtBook.Rows[0]["ProductDesc"].ToString();
                    ddlCondition.SelectedValue = dtBook.Rows[0]["Condition"].ToString();
                    txtConditionNote.Text = dtBook.Rows[0]["ConditionNote"].ToString();

                    chkNegotiable.Checked = Convert.ToBoolean(dtBook.Rows[0]["IsNegotiable"].ToString());
                    Sku = dtBook.Rows[0]["SKU"].ToString();

                    
                    if (chkNegotiable.Checked)
                    {
                        txtProductPrice.Enabled = false;
                        txtProductPrice.Text = "0";
                    }
                    else
                    {
                        txtProductPrice.Enabled = true;
                        txtProductPrice.Text = dtBook.Rows[0]["Price"].ToString();
                    }

                    if (dtBook.Rows[0]["IsActive"] != null)
                    {
                        chkBookIsActive.Checked = Convert.ToBoolean(dtBook.Rows[0]["IsActive"]);
                    }
                    txtPaperBack.Text = dtBook.Rows[0]["PaperBackForBook"].ToString();
                    txtLanguage.Text = dtBook.Rows[0]["Language"].ToString();
                    txtDimensionForBook.Text = dtBook.Rows[0]["DimensionForBook"].ToString();
                    txtShippingWeight.Text = dtBook.Rows[0]["ShippingWeight"].ToString();
                    txtEdition.Text = dtBook.Rows[0]["Edition"].ToString();
                    txtISBN.Text = dtBook.Rows[0]["ISBN"].ToString();
                    txtAuthor.Text = dtBook.Rows[0]["Author"].ToString();
                    txtPublisher.Text = dtBook.Rows[0]["Publisher"].ToString();
                    if (dtBook.Rows[0]["CanEditProduct"] != null)
                    {
                        CanEdit = Convert.ToInt32(dtBook.Rows[0]["CanEditProduct"]);
                    }

                    //string str = dtBook.Rows[0]["ProfileID"].ToString();
                    //string s = dtBook.Rows[0]["CanEditProduct"].ToString();
                    if (object.Equals(dtBook.Rows[0]["ProfileID"], dtBook.Rows[0]["CanEditProduct"]))
                    {
                        this.Block_MasterField(false);
                    }
                    else
                    {
                        this.Block_MasterField(true);
                    }
                    #region SOURCE SELECTION
                    if (dtBook.Rows[0]["Source"].ToString() == "ApnerDeal.com")
                    {
                        rblBoromela.Checked = true;
                        rblNewspaper.Checked = false;
                    }
                    else
                    {
                        rblBoromela.Checked = false;
                        rblNewspaper.Checked = true;
                        txtNewspaper.Text = dtBook.Rows[0]["Source"].ToString();
                    }
                    chkIsDisplayAddress.Checked = Convert.ToBoolean(dtBook.Rows[0]["IsAlternativeAddress"]);
                    #endregion SOURCE SELECTION
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
                    strSystemMessage += "<li>Your Ad may be deleted by ApnerDeal authority for some reason.</li>";
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

    #endregion FOR BOOK

    #region FOR MOBILE

    private void SelectRecord_Mobile()
    {
        //bool _BusinessSeller = true;
        try
        {
            using (BC_Corporate_Mobile objMobile = new BC_Corporate_Mobile())
            {
                DataTable dtMobile = objMobile.LoadRecord_BS_SpecificMobile(ProductID, ProfileID, CategoryID, SubCategoryID, SecondSubcatID);

                if (dtMobile.Rows.Count > 0)
                {
                    //ProductModelID = Convert.ToInt32(dtMobile.Rows[0]["ProductModelID"]);
                    //ProductModel = dtMobile.Rows[0]["ProductModel"].ToString();

                    txtQuantity.Text = dtMobile.Rows[0]["Qty"].ToString();
                    
                    ddlCurrency.SelectedValue = dtMobile.Rows[0]["Currency"].ToString();
                    txtDescription.Text = dtMobile.Rows[0]["ProductDesc"].ToString();
                    ddlCondition.SelectedValue = dtMobile.Rows[0]["Condition"].ToString();
                    txtConditionNote.Text = dtMobile.Rows[0]["ConditionNote"].ToString();


                    chkNegotiable.Checked = Convert.ToBoolean(dtMobile.Rows[0]["IsNegotiable"].ToString());
                    Sku = dtMobile.Rows[0]["SKU"].ToString();

                    
                    if (chkNegotiable.Checked)
                    {
                        txtProductPrice.Enabled = false;
                        txtProductPrice.Text = "0";
                    }
                    else
                    {
                        txtProductPrice.Enabled = true;
                        txtProductPrice.Text = dtMobile.Rows[0]["Price"].ToString();
                    }

                    if (dtMobile.Rows[0]["ProductYear"] != null)
                    {
                        txtProductYear.Text = dtMobile.Rows[0]["ProductYear"].ToString();
                    }
                    else
                    {
                        txtProductYear.Text = "";
                    }



                    ProductModel = dtMobile.Rows[0]["ProductModel"].ToString();
                    ProductModelID = Convert.ToInt32(dtMobile.Rows[0]["ProductModelID"].ToString());

                    if (dtMobile.Rows[0]["IsActive"] != null)
                    {
                        chkMobile.Checked = Convert.ToBoolean(dtMobile.Rows[0]["IsActive"]);
                    }
                    

                    ImagePath = dtMobile.Rows[0]["ProductImage"].ToString();

                    if (dtMobile.Rows[0]["CanEditProduct"] != null)
                    {
                        CanEdit = Convert.ToInt32(dtMobile.Rows[0]["CanEditProduct"]);
                    }

                    if (object.Equals(dtMobile.Rows[0]["ProfileID"], dtMobile.Rows[0]["CanEditProduct"]))
                    {
                        this.Block_MasterField(false);
                    }
                    else
                    {
                        this.Block_MasterField(true);
                    }
                    #region SOURCE PANEL SELCTION
                    if (dtMobile.Rows[0]["Source"].ToString() == "ApnerDeal.com")
                    {
                        rblBoromela.Checked = true;
                        rblNewspaper.Checked = false;
                    }
                    else
                    {
                        rblBoromela.Checked = false;
                        rblNewspaper.Checked = true;
                        txtNewspaper.Text = dtMobile.Rows[0]["Source"].ToString();
                    }
                    chkIsDisplayAddress.Checked = Convert.ToBoolean(dtMobile.Rows[0]["IsAlternativeAddress"]);
                    #endregion SOURCE PANEL SELCTION
                }
                else
                {
                    strSystemMessage = "<table style='width:100%; '>";

                    strSystemMessage += "<tr>";
                    strSystemMessage += "<td colspan='2' style='width:100%; color:#000000; padding-top:7px; padding-left:10px;'>";
                    strSystemMessage += "Product Profile not found!";
                    strSystemMessage += "<br/><br/>";
                    strSystemMessage += "<strong>How did this happen? </strong>";
                    strSystemMessage += "<ul>";
                    strSystemMessage += "<li>You login session may be expired.</li>";
                    strSystemMessage += "<li>Your Ad may be deleted by ApnerDeal authority for some reason.</li>";
                    strSystemMessage += "</ul>";
                    strSystemMessage += "</td>";
                    strSystemMessage += "</tr>";
                    strSystemMessage += "</table>";

                    lblSystemMessage.Text = UTLUtilities.ShowErrorMessage(strSystemMessage);
                }
            }
        }
        catch (Exception Exp)
        {
            lblSystemMessage.Text = UTLUtilities.ShowErrorMessage(Exp.Message.ToString());
        }
    }




    /// <summary>
    /// Inserts New Mobile into Product_Master_Mobile and Product_Seller_Detail_Mobile.
    /// </summary>
    /// <returns></returns>
    private int Add_MasterRecord_Mobile()
    {
        int intActionResult = 0;
        if (!Check_IsMasterProductDuplicate(CategoryID, SubCategoryID, SecondSubcatID, ProductTitle))
        {
            try
            {
                using (BOC_Corporate_Mobile bocProductProfile = new BOC_Corporate_Mobile())
                {
                    EOC_PropertyBean eocPropertyBean = new EOC_PropertyBean();

                    eocPropertyBean.Business_UserProfile_ProfileID = ProfileID;
                    eocPropertyBean.Business_ProductProfile_Books_SKU = Sku;
                    eocPropertyBean.Category_CategoryID = CategoryID;
                    eocPropertyBean.Subcategory_SubcategoryID = SubCategoryID;

                    eocPropertyBean.SecondSubcategory_SubcategoryID = SecondSubcatID;
                    eocPropertyBean.Model_ModelID = ProductModelID;
                    eocPropertyBean.Business_ProductProfile_Books_BookTitle = ProductTitle;


                    eocPropertyBean.Business_ProductProfile_Description = txtDescription.Text;
                    eocPropertyBean.Business_ProductProfile_Quantity = Convert.ToInt32(txtQuantity.Text);
                    eocPropertyBean.Business_ProductProfile_Books_Currency = ddlCurrency.Text;
                    eocPropertyBean.Business_ProductProfile_Books_ProductPrice = Convert.ToDouble(txtProductPrice.Text);

                    eocPropertyBean.Business_ProductProfile_Books_SalePrice = 0.00;
                    eocPropertyBean.Business_ProductProfile_Books_StartDate = DateTime.Now;
                    eocPropertyBean.Business_ProductProfile_Books_EndDate = DateTime.Now;



                    eocPropertyBean.Business_Product_Profile_Books_Condition = ddlCondition.SelectedValue;
                    eocPropertyBean.Business_Product_Profile_Books_ConditionNote = txtConditionNote.Text;

                    eocPropertyBean.Business_ProductProfile_CashOnDelivery = chkCod.Checked;
                    eocPropertyBean.Business_ProductProfile_PickFromStore = chkPfs.Checked;
                    eocPropertyBean.Business_ProductProfile_CashDeposit = chkCash.Checked;
                    eocPropertyBean.Business_ProductProfile_General_DeliveryArea = ddlDeliveryArea.SelectedValue;

                    if (chkCod.Checked && ddlDeliveryArea.SelectedValue == "Outside of Bangladesh")
                    {
                        eocPropertyBean.Business_ProductProfile_SellerForeignAddress = txtSellerForeignAddress.Text;
                    }
                    else
                    {
                        eocPropertyBean.Business_ProductProfile_SellerForeignAddress = "";
                    }


                    if (string.IsNullOrEmpty(ImagePath))
                    {
                        eocPropertyBean.Business_ProductProfile_Books_ProductImage = @"../Corporate_ProductImage/default.png";
                    }
                    else
                    {
                        eocPropertyBean.Business_ProductProfile_Books_ProductImage = ImagePath;
                    }

                    eocPropertyBean.UserType = ClassifiedSeller;

                    eocPropertyBean.UpdatedOn = DateTime.Now;
                    eocPropertyBean.Business_ProductProfile_IsActive = chkMobile.Checked;
                    eocPropertyBean.Business_Product_ProductYear = txtProductYear.Text;

                    eocPropertyBean.IsNegotiable = chkNegotiable.Checked;

                    eocPropertyBean.Source = rblBoromela.Checked ? "ApnerDeal.com" : txtNewspaper.Text;
                    eocPropertyBean.Is_Alternative_Address = chkIsDisplayAddress.Checked;


                    intActionResult = bocProductProfile.Insert_MasterRecord_Mobile(eocPropertyBean);

                }
            }
            catch (Exception Exp)
            {
                lblSystemMessage.Text = UTLUtilities.ShowErrorMessage(Exp.Message.ToString());
            }
        }
        else
        {
            return -2;
        }
        return intActionResult;
    }


    /// <summary>
    /// Inserts TagSellers Data in Mobile.
    /// </summary>
    private int Add_DetailRecord_Mobile()
    {
        if (!Is_Seller_Tagged_Once(ProductID, ProfileID, SellerType, CategoryID))
        {
            try
            {
                using (BOC_Corporate_Mobile bocProductProfile = new BOC_Corporate_Mobile())
                {
                    EOC_PropertyBean eocPropertyBean = new EOC_PropertyBean();

                    eocPropertyBean.Business_UserProfile_ProfileID = ProfileID;
                    eocPropertyBean.Business_ProductProfile_Books_ProductID = ProductID;

                    eocPropertyBean.Business_ProductProfile_Books_SKU = Sku;
                    eocPropertyBean.Business_ProductProfile_Description = txtDescription.Text;
                    eocPropertyBean.Business_ProductProfile_Quantity = Convert.ToInt32(txtQuantity.Text);
                    eocPropertyBean.Business_ProductProfile_Books_Currency = ddlCurrency.SelectedValue;
                    eocPropertyBean.Business_ProductProfile_Books_ProductPrice = Convert.ToDouble(txtProductPrice.Text);


                    eocPropertyBean.Business_ProductProfile_Books_SalePrice = 0.00;
                    eocPropertyBean.Business_ProductProfile_Books_StartDate = DateTime.Now;
                    eocPropertyBean.Business_ProductProfile_Books_EndDate = DateTime.Now;



                    eocPropertyBean.Business_Product_Profile_Books_Condition = ddlCondition.SelectedValue;
                    eocPropertyBean.Business_Product_Profile_Books_ConditionNote = txtConditionNote.Text;

                    eocPropertyBean.Business_ProductProfile_CashOnDelivery = chkCod.Checked;
                    eocPropertyBean.Business_ProductProfile_PickFromStore = chkPfs.Checked;
                    eocPropertyBean.Business_ProductProfile_CashDeposit = chkCash.Checked;
                    eocPropertyBean.Business_ProductProfile_General_DeliveryArea = ddlDeliveryArea.SelectedItem.Text;


                    if (chkCod.Checked && ddlDeliveryArea.SelectedValue == "Outside of Bangladesh")
                    {
                        eocPropertyBean.Business_ProductProfile_SellerForeignAddress = txtSellerForeignAddress.Text;
                    }
                    else
                    {
                        eocPropertyBean.Business_ProductProfile_SellerForeignAddress = "";
                    }

                    eocPropertyBean.UserType = ClassifiedSeller;

                    eocPropertyBean.UpdatedOn = DateTime.Now;
                    eocPropertyBean.Business_ProductProfile_IsActive = chkMobile.Checked;
                    eocPropertyBean.Business_Product_ProductYear = txtProductYear.Text;
                    eocPropertyBean.IsNegotiable = chkNegotiable.Checked;

                    eocPropertyBean.Source = rblBoromela.Checked ? "ApnerDeal.com" : txtNewspaper.Text;
                    eocPropertyBean.Is_Alternative_Address = chkIsDisplayAddress.Checked;

                    intActionResult = bocProductProfile.Insert_DetailRecord_Mobile(eocPropertyBean);

                }
            }
            catch (Exception Exp)
            {
                lblSystemMessage.Text = UTLUtilities.ShowErrorMessage(Exp.Message.ToString());
            }
        }
        else
        {
            return -2;
        }
        return intActionResult;
    }


    /// <summary>
    /// Updates Mobile Record For Master Seller. Who can Edit Image.
    /// </summary>
    /// <returns></returns>
    private int Update_MasterSeller_Mobile()
    {
        try
        {
            using (BOC_Corporate_Mobile bocProductProfile = new BOC_Corporate_Mobile())
            {
                EOC_PropertyBean eocPropertyBean = new EOC_PropertyBean();

                eocPropertyBean.Business_UserProfile_ProfileID = ProfileID;
                eocPropertyBean.Business_ProductProfile_Books_ProductID = ProductID;
                //eocPropertyBean.Business_ProductProfile_Books_SKU = Sku;
                eocPropertyBean.Category_CategoryID = CategoryID;
                eocPropertyBean.Subcategory_SubcategoryID = SubCategoryID;
                eocPropertyBean.SecondSubcategory_SubcategoryID = SecondSubcatID;
                //eocPropertyBean.Model_ModelID = ProductModelID;
                //eocPropertyBean.Business_ProductProfile_Books_BookTitle = ProductTitle;


                eocPropertyBean.Business_ProductProfile_Description = txtDescription.Text;
                eocPropertyBean.Business_ProductProfile_Quantity = Convert.ToInt32(txtQuantity.Text);
                eocPropertyBean.Business_ProductProfile_Books_Currency = ddlCurrency.Text;
                eocPropertyBean.Business_ProductProfile_Books_ProductPrice = Convert.ToDouble(txtProductPrice.Text);


                eocPropertyBean.Business_ProductProfile_Books_SalePrice = 0.00;
                eocPropertyBean.Business_ProductProfile_Books_StartDate = DateTime.Now;
                eocPropertyBean.Business_ProductProfile_Books_EndDate = DateTime.Now;


                eocPropertyBean.Business_Product_Profile_Books_Condition = ddlCondition.SelectedValue;
                eocPropertyBean.Business_Product_Profile_Books_ConditionNote = txtConditionNote.Text;

                eocPropertyBean.Business_ProductProfile_CashOnDelivery = chkCod.Checked;
                eocPropertyBean.Business_ProductProfile_PickFromStore = chkPfs.Checked;
                eocPropertyBean.Business_ProductProfile_CashDeposit = chkCash.Checked;
                eocPropertyBean.Business_ProductProfile_General_DeliveryArea = ddlDeliveryArea.SelectedValue;

                if (chkCod.Checked && ddlDeliveryArea.SelectedValue == "Outside of Bangladesh")
                {
                    eocPropertyBean.Business_ProductProfile_SellerForeignAddress = txtSellerForeignAddress.Text;
                }
                else
                {
                    eocPropertyBean.Business_ProductProfile_SellerForeignAddress = "";
                }


                if (string.IsNullOrEmpty(ImagePath))
                {
                    eocPropertyBean.Business_ProductProfile_Books_ProductImage = @"../Corporate_ProductImage/default.png";
                }
                else
                {
                    eocPropertyBean.Business_ProductProfile_Books_ProductImage = ImagePath;
                }

                eocPropertyBean.UserType = ClassifiedSeller;

                eocPropertyBean.UpdatedOn = DateTime.Now;
                eocPropertyBean.Business_ProductProfile_IsActive = chkMobile.Checked;
                eocPropertyBean.Business_Product_ProductYear = txtProductYear.Text;

                eocPropertyBean.IsNegotiable = chkNegotiable.Checked;

                eocPropertyBean.Source = rblBoromela.Checked ? "ApnerDeal.com" : txtNewspaper.Text;
                eocPropertyBean.Is_Alternative_Address = chkIsDisplayAddress.Checked;

                intActionResult = bocProductProfile.Update_MasterSeller_Mobile(eocPropertyBean);

            }
        }
        catch (Exception Exp)
        {
            lblSystemMessage.Text = UTLUtilities.ShowErrorMessage(Exp.Message.ToString());
        }

        return intActionResult;
    }

    /// <summary>
    /// Updates Book Record of the Tag Seller.
    /// </summary>
    /// <returns></returns>
    private int Update_TagSeller_Mobile()
    {
        int intActionResult = 0;

        try
        {
            using (BOC_Corporate_Mobile bocProductProfile = new BOC_Corporate_Mobile())
            {
                EOC_PropertyBean eocPropertyBean = new EOC_PropertyBean();
                eocPropertyBean.Business_UserProfile_ProfileID = ProfileID;
                eocPropertyBean.Business_ProductProfile_Books_ProductID = ProductID;

                eocPropertyBean.Business_ProductProfile_Description = txtDescription.Text;
                eocPropertyBean.Business_ProductProfile_Quantity = Convert.ToInt32(txtQuantity.Text);
                eocPropertyBean.Business_ProductProfile_Books_Currency = ddlCurrency.SelectedValue;
                eocPropertyBean.Business_ProductProfile_Books_ProductPrice = Convert.ToDouble(txtProductPrice.Text);


                eocPropertyBean.Business_ProductProfile_Books_SalePrice = 0.00;
                eocPropertyBean.Business_ProductProfile_Books_StartDate = DateTime.Now;
                eocPropertyBean.Business_ProductProfile_Books_EndDate = DateTime.Now;



                eocPropertyBean.Business_Product_Profile_Books_Condition = ddlCondition.SelectedValue;
                eocPropertyBean.Business_Product_Profile_Books_ConditionNote = txtConditionNote.Text;

                eocPropertyBean.Business_ProductProfile_CashOnDelivery = chkCod.Checked;
                eocPropertyBean.Business_ProductProfile_PickFromStore = chkPfs.Checked;
                eocPropertyBean.Business_ProductProfile_CashDeposit = chkCash.Checked;
                eocPropertyBean.Business_ProductProfile_General_DeliveryArea = ddlDeliveryArea.SelectedValue;

                if (chkCod.Checked && ddlDeliveryArea.SelectedValue == "Outside of Bangladesh")
                {
                    eocPropertyBean.Business_ProductProfile_SellerForeignAddress = txtSellerForeignAddress.Text;
                }
                else
                {
                    eocPropertyBean.Business_ProductProfile_SellerForeignAddress = "";
                }



                eocPropertyBean.UserType = ClassifiedSeller;

                eocPropertyBean.UpdatedOn = DateTime.Now;
                eocPropertyBean.Business_ProductProfile_IsActive = chkMobile.Checked;
                eocPropertyBean.Business_Product_ProductYear = txtProductYear.Text;

                eocPropertyBean.IsNegotiable = chkNegotiable.Checked;

                eocPropertyBean.Source = rblBoromela.Checked ? "ApnerDeal.com" : txtNewspaper.Text;
                eocPropertyBean.Is_Alternative_Address = chkIsDisplayAddress.Checked;

                intActionResult = bocProductProfile.Update_TagSeller_Mobile(eocPropertyBean);
            }
        }
        catch (Exception Exp)
        {
            lblSystemMessage.Text = UTLUtilities.ShowErrorMessage(Exp.Message.ToString());
        }

        return intActionResult;

    }


    /// <summary>
    /// Selects ProductID, Product Model from LatesPostedMobile
    /// </summary>
    /// <param name="categoryID"></param>
    /// <param name="subcategoryID"></param>
    /// <param name="secondSubcatID"></param>
    /// <param name="profileID"></param>
    /// <param name="productID"></param>
    private void Select_Master_MobileRecord(int categoryID, int subcategoryID, int secondSubcatID, int profileID, int productID)
    {
        DataTable dt = new DataTable();
        try
        {
            using (BC_Corporate_Mobile bcProduct = new BC_Corporate_Mobile())
            {
                dt = bcProduct.SelectSpecific_Master_MobileRecord(categoryID, subcategoryID, secondSubcatID, productID);
                if (dt.Rows.Count > 0)
                {
                    ProductModelID = Convert.ToInt32(dt.Rows[0]["ProductModelID"]);
                    ProductModel = dt.Rows[0]["ProductModel"].ToString();
                }
            }
        }
        catch (Exception ex)
        {
            lblSystemMessage.Text = UTLUtilities.ShowErrorMessage(ex.Message);
        }
    }

    

    #endregion FOR MOBILE

    #region FOR COMPUTER


    /// <summary>
    /// Select Computers Records From the LatestPostedComputer.
    /// </summary>
    private void SelectRecord_Computer()
    {
        try
        {
            using (BC_Corporate_Computer objComputer = new BC_Corporate_Computer())
            {
                DataTable dtComputer = objComputer.LoadRecord_BS_SpecificComputer(ProductID, ProfileID, CategoryID, SubCategoryID, SecondSubcatID);

                if (dtComputer.Rows.Count > 0)
                {
                    ProductModel = dtComputer.Rows[0]["ProductModel"].ToString();
                    ProductModelID = Convert.ToInt32(dtComputer.Rows[0]["ProductModelID"].ToString());

                    txtQuantity.Text = dtComputer.Rows[0]["Qty"].ToString();
                    
                    ddlCurrency.SelectedValue = dtComputer.Rows[0]["Currency"].ToString();
                    txtDescription.Text = dtComputer.Rows[0]["ProductDesc"].ToString();
                    ddlCondition.SelectedValue = dtComputer.Rows[0]["Condition"].ToString();
                    txtConditionNote.Text = dtComputer.Rows[0]["ConditionNote"].ToString();
                    Sku = dtComputer.Rows[0]["SKU"].ToString();

                    

                    if (dtComputer.Rows[0]["ProductYear"] != null)
                    {
                        txtProductYear.Text = dtComputer.Rows[0]["ProductYear"].ToString();
                    }
                    else
                    {
                        txtProductYear.Text = "";
                    }

                    chkNegotiable.Checked = Convert.ToBoolean(dtComputer.Rows[0]["IsNegotiable"].ToString());
                    if (chkNegotiable.Checked)
                    {
                        txtProductPrice.Enabled = false;
                        txtProductPrice.Text = "0";
                    }
                    else
                    {
                        txtProductPrice.Enabled = true;
                        txtProductPrice.Text = dtComputer.Rows[0]["Price"].ToString();
                    }

                  

                    if (dtComputer.Rows[0]["IsActive"] != null)
                    {
                        chkComputer.Checked = Convert.ToBoolean(dtComputer.Rows[0]["IsActive"]);
                    }
                    

                    ImagePath = dtComputer.Rows[0]["ProductImage"].ToString();

                    if (dtComputer.Rows[0]["CanEditProduct"] != null)
                    {
                        CanEdit = Convert.ToInt32(dtComputer.Rows[0]["CanEditProduct"]);
                    }

                    if (object.Equals(dtComputer.Rows[0]["ProfileID"], dtComputer.Rows[0]["CanEditProduct"]))
                    {
                        this.Block_MasterField(false);
                    }
                    else
                    {
                        this.Block_MasterField(true);
                    }

                    if (dtComputer.Rows[0]["DedicatedVideoMemory"] != null)
                    {
                        txtDedicatedVideoMemory.Text = dtComputer.Rows[0]["DedicatedVideoMemory"].ToString();
                    }
                    if (dtComputer.Rows[0]["SharedVideoMemory"] != null)
                    {
                        txtSharedVideoMemory.Text = dtComputer.Rows[0]["SharedVideoMemory"].ToString();
                    }
                    if (dtComputer.Rows[0]["VideoMemory"] != null)
                    {
                        txtTvTuner.Text = dtComputer.Rows[0]["VideoMemory"].ToString();
                    }
                    if (dtComputer.Rows[0]["VideoMemory"] != null)
                    {
                        txtVideoMemory.Text = dtComputer.Rows[0]["VideoMemory"].ToString();
                    }
                    if (dtComputer.Rows[0]["HDCPCompliant"] != null)
                    {
                        txtHDCPCompliant.Text = dtComputer.Rows[0]["HDCPCompliant"].ToString();
                    }
                    if (dtComputer.Rows[0]["AudioOutput"] != null)
                    {
                        txtAudioOutput.Text = dtComputer.Rows[0]["AudioOutput"].ToString();
                    }
                    if (dtComputer.Rows[0]["DigitalInput"] != null)
                    {
                        txtDigitalInput.Text = dtComputer.Rows[0]["DigitalInput"].ToString();
                    }
                    if (dtComputer.Rows[0]["DigitalOutput"] != null)
                    {
                        txtDigitalOutput.Text = dtComputer.Rows[0]["DigitalOutput"].ToString();
                    }
                    if (dtComputer.Rows[0]["IntegretedMicrophone"] != null)
                    {
                        txtIntegretedMicrophone.Text = dtComputer.Rows[0]["IntegretedMicrophone"].ToString();
                    }
                    if (dtComputer.Rows[0]["LineOut"] != null)
                    {
                        txtLineOut.Text = dtComputer.Rows[0]["LineOut"].ToString();
                    }
                    if (dtComputer.Rows[0]["LineInInput"] != null)
                    {
                        txtLineInInput.Text = dtComputer.Rows[0]["LineInInput"].ToString();
                    }
                    if (dtComputer.Rows[0]["MicrophoneInput"] != null)
                    {
                        txtMicrophoneInput.Text = dtComputer.Rows[0]["MicrophoneInput"].ToString();
                    }
                    if (dtComputer.Rows[0]["SoundCard"] != null)
                    {
                        txtSoundCard.Text = dtComputer.Rows[0]["SoundCard"].ToString();
                    }
                    if (dtComputer.Rows[0]["EthernetPort"] != null)
                    {
                        txtEthernetPort.Text = dtComputer.Rows[0]["EthernetPort"].ToString();
                    }
                    if (dtComputer.Rows[0]["IntegretedBluetooth"] != null)
                    {
                        txtIntegretedBluetooth.Text = dtComputer.Rows[0]["IntegretedBluetooth"].ToString();
                    }
                    if (dtComputer.Rows[0]["IntegretedWiFi"] != null)
                    {
                        txtIntegretedWiFi.Text = dtComputer.Rows[0]["IntegretedWiFi"].ToString();
                    }
                    if (dtComputer.Rows[0]["CardReader"] != null)
                    {
                        txtCardReader.Text = dtComputer.Rows[0]["CardReader"].ToString();
                    }
                    if (dtComputer.Rows[0]["DVIOutput"] != null)
                    {
                        txtDVIOutput.Text = dtComputer.Rows[0]["DVIOutput"].ToString();
                    }
                    if (dtComputer.Rows[0]["ESata"] != null)
                    {
                        txtESata.Text = dtComputer.Rows[0]["ESata"].ToString();
                    }
                    if (dtComputer.Rows[0]["HDMI"] != null)
                    {
                        txtHDMI.Text = dtComputer.Rows[0]["HDMI"].ToString();
                    }
                    if (dtComputer.Rows[0]["USB2"] != null)
                    {
                        txtUSB2.Text = dtComputer.Rows[0]["USB2"].ToString();
                    }
                    if (dtComputer.Rows[0]["VGAOutput"] != null)
                    {
                        txtVGAOutput.Text = dtComputer.Rows[0]["VGAOutput"].ToString();
                    }
                    if (dtComputer.Rows[0]["Webcam"] != null)
                    {
                        txtWebcam.Text = dtComputer.Rows[0]["Webcam"].ToString();
                    }
                    #region SOURCE PANEL SELCTION

                    if (dtComputer.Rows[0]["Source"].ToString() == "ApnerDeal.com")
                    {
                        rblBoromela.Checked = true;
                        rblNewspaper.Checked = false;
                    }
                    else
                    {
                        rblBoromela.Checked = false;
                        rblNewspaper.Checked = true;
                        txtNewspaper.Text = dtComputer.Rows[0]["Source"].ToString();
                    }
                    chkIsDisplayAddress.Checked = Convert.ToBoolean(dtComputer.Rows[0]["IsAlternativeAddress"]);
                    #endregion SOURCE PANEL SELCTION

                }
                else
                {
                    strSystemMessage = "<table style='width:100%; '>";

                    strSystemMessage += "<tr>";
                    strSystemMessage += "<td colspan='2' style='width:100%; color:#000000; padding-top:7px; padding-left:10px;'>";
                    strSystemMessage += "Product Profile not found!";
                    strSystemMessage += "<br/><br/>";
                    strSystemMessage += "<strong>How did this happen? </strong>";
                    strSystemMessage += "<ul>";
                    strSystemMessage += "<li>You login session may be expired.</li>";
                    strSystemMessage += "<li>Your Ad may be deleted by ApnerDeal authority for some reason.</li>";
                    strSystemMessage += "</ul>";
                    strSystemMessage += "</td>";
                    strSystemMessage += "</tr>";
                    strSystemMessage += "</table>";

                    lblSystemMessage.Text = UTLUtilities.ShowErrorMessage(strSystemMessage);
                }
            }
        }
        catch (Exception Exp)
        {
            lblSystemMessage.Text = UTLUtilities.ShowErrorMessage(Exp.Message.ToString());
        }
    }


    /// <summary>
    /// Inserts New Computer Entry into DataBase.
    /// </summary>
    /// <returns></returns>
    private int Add_MasterRecord_Computer()
    {
        int intActionResult = 0;
        if (!Check_IsMasterProductDuplicate(CategoryID, SubCategoryID, SecondSubcatID, ProductTitle))
        {
            try
            {
                using (BOC_Corporate_Computer bocProductProfile = new BOC_Corporate_Computer())
                {
                    EOC_PropertyBean eocPropertyBean = new EOC_PropertyBean();

                    eocPropertyBean.Business_UserProfile_ProfileID = ProfileID;
                    eocPropertyBean.Business_ProductProfile_Books_SKU = Sku;

                    eocPropertyBean.Category_CategoryID = CategoryID;
                    eocPropertyBean.Subcategory_SubcategoryID = SubCategoryID;

                    eocPropertyBean.SecondSubcategory_SubcategoryID = SecondSubcatID;
                    eocPropertyBean.Model_ModelID = ProductModelID;
                    eocPropertyBean.Business_ProductProfile_Books_BookTitle = ProductTitle;


                    eocPropertyBean.Business_ProductProfile_Description = txtDescription.Text;
                    eocPropertyBean.Business_ProductProfile_Quantity = Convert.ToInt32(txtQuantity.Text);
                    eocPropertyBean.Business_ProductProfile_Books_Currency = ddlCurrency.Text;
                    eocPropertyBean.Business_ProductProfile_Books_ProductPrice = Convert.ToDouble(txtProductPrice.Text);

                    eocPropertyBean.Business_ProductProfile_Books_SalePrice = 0.00;
                    eocPropertyBean.Business_ProductProfile_Books_StartDate = DateTime.Now;
                    eocPropertyBean.Business_ProductProfile_Books_EndDate = DateTime.Now;


                    eocPropertyBean.Business_Product_Profile_Books_Condition = ddlCondition.SelectedValue;
                    eocPropertyBean.Business_Product_Profile_Books_ConditionNote = txtConditionNote.Text;

                    eocPropertyBean.Business_ProductProfile_CashOnDelivery = chkCod.Checked;
                    eocPropertyBean.Business_ProductProfile_PickFromStore = chkPfs.Checked;
                    eocPropertyBean.Business_ProductProfile_CashDeposit = chkCash.Checked;
                    eocPropertyBean.Business_ProductProfile_General_DeliveryArea = ddlDeliveryArea.SelectedValue;

                    if (chkCod.Checked && ddlDeliveryArea.SelectedValue == "Outside of Bangladesh")
                    {
                        eocPropertyBean.Business_ProductProfile_SellerForeignAddress = txtSellerForeignAddress.Text;
                    }
                    else
                    {
                        eocPropertyBean.Business_ProductProfile_SellerForeignAddress = "";
                    }


                    if (string.IsNullOrEmpty(ImagePath))
                    {
                        eocPropertyBean.Business_ProductProfile_Books_ProductImage = @"../Corporate_ProductImage/default.png";
                    }
                    else
                    {
                        eocPropertyBean.Business_ProductProfile_Books_ProductImage = ImagePath;
                    }

                    eocPropertyBean.UserType = ClassifiedSeller;
                    eocPropertyBean.UpdatedOn = DateTime.Now;
                    eocPropertyBean.Business_ProductProfile_IsActive = chkComputer.Checked;


                    eocPropertyBean.Computer_DedicatedVideoMemory = txtDedicatedVideoMemory.Text;
                    eocPropertyBean.Computer_SharedVideoMemory = txtSharedVideoMemory.Text;
                    eocPropertyBean.Computer_TVTuner = txtTvTuner.Text;
                    eocPropertyBean.Computer_VideoMemory = txtVideoMemory.Text;
                    eocPropertyBean.Computer_HDCPCompliant = txtHDCPCompliant.Text;
                    eocPropertyBean.Computer_AudioOutput = txtAudioOutput.Text;
                    eocPropertyBean.Computer_DigitalInput = txtDigitalInput.Text;
                    eocPropertyBean.Computer_DigitalOutput = txtDigitalOutput.Text;
                    eocPropertyBean.Computer_IntegretedMicrophone = txtIntegretedMicrophone.Text;
                    eocPropertyBean.Computer_LineOut = txtLineOut.Text;
                    eocPropertyBean.Computer_LineInInput = txtLineInInput.Text;
                    eocPropertyBean.Computer_MicrophoneInput = txtMicrophoneInput.Text;
                    eocPropertyBean.Computer_SoundCard = txtSoundCard.Text;
                    eocPropertyBean.Computer_EthernetPort = txtEthernetPort.Text;
                    eocPropertyBean.Computer_IntegretedBluetooth = txtIntegretedBluetooth.Text;
                    eocPropertyBean.Computer_IntegretedWiFi = txtIntegretedWiFi.Text;
                    eocPropertyBean.Computer_CardReader = txtCardReader.Text;
                    eocPropertyBean.Computer_DVIOutput = txtDVIOutput.Text;
                    eocPropertyBean.Computer_ESata = txtESata.Text;
                    eocPropertyBean.Computer_HDMI = txtHDMI.Text;
                    eocPropertyBean.Computer_USB2 = txtUSB2.Text;
                    eocPropertyBean.Computer_VGAOutput = txtVGAOutput.Text;
                    eocPropertyBean.Computer_Webcam = txtWebcam.Text;

                    eocPropertyBean.Business_Product_ProductYear = txtProductYear.Text;
                    eocPropertyBean.IsNegotiable = chkNegotiable.Checked;

                    eocPropertyBean.Source = rblBoromela.Checked ? "ApnerDeal.com" : txtNewspaper.Text;
                    eocPropertyBean.Is_Alternative_Address = chkIsDisplayAddress.Checked;

                    intActionResult = bocProductProfile.Insert_MasterRecord_Computer(eocPropertyBean);

                }
            }
            catch (Exception Exp)
            {
                lblSystemMessage.Text = UTLUtilities.ShowErrorMessage(Exp.Message.ToString());
            }
        }
        else 
        {
            return -2;
        }
        return intActionResult;
    }


    ///// <summary>
    ///// Inserts TagSellers Data in Computer.
    ///// </summary>
    private int Add_DetailRecord_Computer()
    {
        if (!Is_Seller_Tagged_Once(ProductID, ProfileID, SellerType, CategoryID))
        {
            try
            {
                using (BOC_Corporate_Computer bocProductProfile = new BOC_Corporate_Computer())
                {
                    EOC_PropertyBean eocPropertyBean = new EOC_PropertyBean();

                    eocPropertyBean.Business_UserProfile_ProfileID = ProfileID;
                    eocPropertyBean.Business_ProductProfile_Books_ProductID = ProductID;

                    eocPropertyBean.Business_ProductProfile_Books_SKU = Sku;
                    eocPropertyBean.Business_ProductProfile_Description = txtDescription.Text;
                    eocPropertyBean.Business_ProductProfile_Quantity = Convert.ToInt32(txtQuantity.Text);
                    eocPropertyBean.Business_ProductProfile_Books_Currency = ddlCurrency.SelectedValue;
                    eocPropertyBean.Business_ProductProfile_Books_ProductPrice = Convert.ToDouble(txtProductPrice.Text);


                    eocPropertyBean.Business_ProductProfile_Books_SalePrice = 0.00;
                    eocPropertyBean.Business_ProductProfile_Books_StartDate = DateTime.Now;
                    eocPropertyBean.Business_ProductProfile_Books_EndDate = DateTime.Now;

                    eocPropertyBean.Business_Product_Profile_Books_Condition = ddlCondition.SelectedValue;
                    eocPropertyBean.Business_Product_Profile_Books_ConditionNote = txtConditionNote.Text;

                    eocPropertyBean.Business_ProductProfile_CashOnDelivery = chkCod.Checked;
                    eocPropertyBean.Business_ProductProfile_PickFromStore = chkPfs.Checked;
                    eocPropertyBean.Business_ProductProfile_CashDeposit = chkCash.Checked;
                    eocPropertyBean.Business_ProductProfile_General_DeliveryArea = ddlDeliveryArea.SelectedItem.Text;


                    if (chkCod.Checked && ddlDeliveryArea.SelectedValue == "Outside of Bangladesh")
                    {
                        eocPropertyBean.Business_ProductProfile_SellerForeignAddress = txtSellerForeignAddress.Text;
                    }
                    else
                    {
                        eocPropertyBean.Business_ProductProfile_SellerForeignAddress = "";
                    }

                    eocPropertyBean.UserType = ClassifiedSeller;

                    eocPropertyBean.UpdatedOn = DateTime.Now;
                    eocPropertyBean.Business_ProductProfile_IsActive = chkComputer.Checked;


                    eocPropertyBean.Computer_DedicatedVideoMemory = txtDedicatedVideoMemory.Text;
                    eocPropertyBean.Computer_SharedVideoMemory = txtSharedVideoMemory.Text;
                    eocPropertyBean.Computer_TVTuner = txtTvTuner.Text;
                    eocPropertyBean.Computer_VideoMemory = txtVideoMemory.Text;
                    eocPropertyBean.Computer_HDCPCompliant = txtHDCPCompliant.Text;
                    eocPropertyBean.Computer_AudioOutput = txtAudioOutput.Text;
                    eocPropertyBean.Computer_DigitalInput = txtDigitalInput.Text;
                    eocPropertyBean.Computer_DigitalOutput = txtDigitalOutput.Text;
                    eocPropertyBean.Computer_IntegretedMicrophone = txtIntegretedMicrophone.Text;
                    eocPropertyBean.Computer_LineOut = txtLineOut.Text;
                    eocPropertyBean.Computer_LineInInput = txtLineInInput.Text;
                    eocPropertyBean.Computer_MicrophoneInput = txtMicrophoneInput.Text;
                    eocPropertyBean.Computer_SoundCard = txtSoundCard.Text;
                    eocPropertyBean.Computer_EthernetPort = txtEthernetPort.Text;
                    eocPropertyBean.Computer_IntegretedBluetooth = txtIntegretedBluetooth.Text;
                    eocPropertyBean.Computer_IntegretedWiFi = txtIntegretedWiFi.Text;
                    eocPropertyBean.Computer_CardReader = txtCardReader.Text;
                    eocPropertyBean.Computer_DVIOutput = txtDVIOutput.Text;
                    eocPropertyBean.Computer_ESata = txtESata.Text;
                    eocPropertyBean.Computer_HDMI = txtHDMI.Text;
                    eocPropertyBean.Computer_USB2 = txtUSB2.Text;
                    eocPropertyBean.Computer_VGAOutput = txtVGAOutput.Text;
                    eocPropertyBean.Computer_Webcam = txtWebcam.Text;

                    eocPropertyBean.Business_Product_ProductYear = txtProductYear.Text;
                    eocPropertyBean.IsNegotiable = chkNegotiable.Checked;

                    eocPropertyBean.Source = rblBoromela.Checked ? "ApnerDeal.com" : txtNewspaper.Text;
                    eocPropertyBean.Is_Alternative_Address = chkIsDisplayAddress.Checked;

                    intActionResult = bocProductProfile.Insert_DetailRecord_Computer(eocPropertyBean);

                }
            }
            catch (Exception Exp)
            {
                lblSystemMessage.Text = UTLUtilities.ShowErrorMessage(Exp.Message.ToString());
            }
        }
        else
        {
            return -2;
        }
        return intActionResult;
    }


    ///// <summary>
    ///// Updates Computer Record For Master Seller. Who can Edit Image and other Compueter Acessesories.
    ///// </summary>
    ///// <returns></returns>
    private int Update_MasterSeller_Computer()
    {
        try
        {
            using (BOC_Corporate_Computer bocProductProfile = new BOC_Corporate_Computer())
            {
                EOC_PropertyBean eocPropertyBean = new EOC_PropertyBean();

                eocPropertyBean.Business_UserProfile_ProfileID = ProfileID;
                eocPropertyBean.Business_ProductProfile_Books_ProductID = ProductID;
                //eocPropertyBean.Business_ProductProfile_Books_SKU = Sku;
                eocPropertyBean.Category_CategoryID = CategoryID;
                eocPropertyBean.Subcategory_SubcategoryID = SubCategoryID;
                eocPropertyBean.SecondSubcategory_SubcategoryID = SecondSubcatID;
                eocPropertyBean.Model_ModelID = ProductModelID;
                //eocPropertyBean.Business_ProductProfile_Books_BookTitle = ProductTitle;


                eocPropertyBean.Business_ProductProfile_Description = txtDescription.Text;
                eocPropertyBean.Business_ProductProfile_Quantity = Convert.ToInt32(txtQuantity.Text);
                eocPropertyBean.Business_ProductProfile_Books_Currency = ddlCurrency.Text;
                eocPropertyBean.Business_ProductProfile_Books_ProductPrice = Convert.ToDouble(txtProductPrice.Text);


                eocPropertyBean.Business_ProductProfile_Books_SalePrice = 0.00;
                eocPropertyBean.Business_ProductProfile_Books_StartDate = DateTime.Now;
                eocPropertyBean.Business_ProductProfile_Books_EndDate = DateTime.Now;


                eocPropertyBean.Business_Product_Profile_Books_Condition = ddlCondition.SelectedValue;
                eocPropertyBean.Business_Product_Profile_Books_ConditionNote = txtConditionNote.Text;

                eocPropertyBean.Business_ProductProfile_CashOnDelivery = chkCod.Checked;
                eocPropertyBean.Business_ProductProfile_PickFromStore = chkPfs.Checked;
                eocPropertyBean.Business_ProductProfile_CashDeposit = chkCash.Checked;
                eocPropertyBean.Business_ProductProfile_General_DeliveryArea = ddlDeliveryArea.SelectedValue;

                if (chkCod.Checked && ddlDeliveryArea.SelectedValue == "Outside of Bangladesh")
                {
                    eocPropertyBean.Business_ProductProfile_SellerForeignAddress = txtSellerForeignAddress.Text;
                }
                else
                {
                    eocPropertyBean.Business_ProductProfile_SellerForeignAddress = "";
                }


                if (string.IsNullOrEmpty(ImagePath))
                {
                    eocPropertyBean.Business_ProductProfile_Books_ProductImage = @"../Corporate_ProductImage/default.png";
                }
                else
                {
                    eocPropertyBean.Business_ProductProfile_Books_ProductImage = ImagePath;
                }

                eocPropertyBean.UserType = ClassifiedSeller;

                eocPropertyBean.UpdatedOn = DateTime.Now;
                eocPropertyBean.Business_ProductProfile_IsActive = chkComputer.Checked;


                eocPropertyBean.Computer_DedicatedVideoMemory = txtDedicatedVideoMemory.Text;
                eocPropertyBean.Computer_SharedVideoMemory = txtSharedVideoMemory.Text;
                eocPropertyBean.Computer_TVTuner = txtTvTuner.Text;
                eocPropertyBean.Computer_VideoMemory = txtVideoMemory.Text;
                eocPropertyBean.Computer_HDCPCompliant = txtHDCPCompliant.Text;
                eocPropertyBean.Computer_AudioOutput = txtAudioOutput.Text;
                eocPropertyBean.Computer_DigitalInput = txtDigitalInput.Text;
                eocPropertyBean.Computer_DigitalOutput = txtDigitalOutput.Text;
                eocPropertyBean.Computer_IntegretedMicrophone = txtIntegretedMicrophone.Text;
                eocPropertyBean.Computer_LineOut = txtLineOut.Text;
                eocPropertyBean.Computer_LineInInput = txtLineInInput.Text;
                eocPropertyBean.Computer_MicrophoneInput = txtMicrophoneInput.Text;
                eocPropertyBean.Computer_SoundCard = txtSoundCard.Text;
                eocPropertyBean.Computer_EthernetPort = txtEthernetPort.Text;
                eocPropertyBean.Computer_IntegretedBluetooth = txtIntegretedBluetooth.Text;
                eocPropertyBean.Computer_IntegretedWiFi = txtIntegretedWiFi.Text;
                eocPropertyBean.Computer_CardReader = txtCardReader.Text;
                eocPropertyBean.Computer_DVIOutput = txtDVIOutput.Text;
                eocPropertyBean.Computer_ESata = txtESata.Text;
                eocPropertyBean.Computer_HDMI = txtHDMI.Text;
                eocPropertyBean.Computer_USB2 = txtUSB2.Text;
                eocPropertyBean.Computer_VGAOutput = txtVGAOutput.Text;
                eocPropertyBean.Computer_Webcam = txtWebcam.Text;

                eocPropertyBean.Business_Product_ProductYear = txtProductYear.Text;
                eocPropertyBean.IsNegotiable = chkNegotiable.Checked;

                eocPropertyBean.Source = rblBoromela.Checked ? "ApnerDeal.com" : txtNewspaper.Text;
                eocPropertyBean.Is_Alternative_Address = chkIsDisplayAddress.Checked;

                intActionResult = bocProductProfile.Update_MasterSeller_Computer(eocPropertyBean);

            }
        }
        catch (Exception Exp)
        {
            lblSystemMessage.Text = UTLUtilities.ShowErrorMessage(Exp.Message.ToString());
        }

        return intActionResult;
    }




    /// <summary>
    /// Updates Book Record of the Tag Seller.
    /// </summary>
    /// <returns></returns>
    private int Update_TagSeller_Computer()
    {
        int intActionResult = 0;

        try
        {
            using (BOC_Corporate_Computer bocProductProfile = new BOC_Corporate_Computer())
            {
                EOC_PropertyBean eocPropertyBean = new EOC_PropertyBean();
                eocPropertyBean.Business_UserProfile_ProfileID = ProfileID;
                eocPropertyBean.Business_ProductProfile_Books_ProductID = ProductID;

                eocPropertyBean.Business_ProductProfile_Description = txtDescription.Text;
                eocPropertyBean.Business_ProductProfile_Quantity = Convert.ToInt32(txtQuantity.Text);
                eocPropertyBean.Business_ProductProfile_Books_Currency = ddlCurrency.SelectedValue;
                eocPropertyBean.Business_ProductProfile_Books_ProductPrice = Convert.ToDouble(txtProductPrice.Text);

                eocPropertyBean.Business_ProductProfile_Books_SalePrice = 0.00;
                eocPropertyBean.Business_ProductProfile_Books_StartDate = DateTime.Now;
                eocPropertyBean.Business_ProductProfile_Books_EndDate = DateTime.Now;


                eocPropertyBean.Business_Product_Profile_Books_Condition = ddlCondition.SelectedValue;
                eocPropertyBean.Business_Product_Profile_Books_ConditionNote = txtConditionNote.Text;

                eocPropertyBean.Business_ProductProfile_CashOnDelivery = chkCod.Checked;
                eocPropertyBean.Business_ProductProfile_PickFromStore = chkPfs.Checked;
                eocPropertyBean.Business_ProductProfile_CashDeposit = chkCash.Checked;
                eocPropertyBean.Business_ProductProfile_General_DeliveryArea = ddlDeliveryArea.SelectedValue;

                if (chkCod.Checked && ddlDeliveryArea.SelectedValue == "Outside of Bangladesh")
                {
                    eocPropertyBean.Business_ProductProfile_SellerForeignAddress = txtSellerForeignAddress.Text;
                }
                else
                {
                    eocPropertyBean.Business_ProductProfile_SellerForeignAddress = "";
                }



                eocPropertyBean.UserType = ClassifiedSeller;

                eocPropertyBean.UpdatedOn = DateTime.Now;
                eocPropertyBean.Business_ProductProfile_IsActive = chkComputer.Checked;


                eocPropertyBean.Computer_DedicatedVideoMemory = txtDedicatedVideoMemory.Text;
                eocPropertyBean.Computer_SharedVideoMemory = txtSharedVideoMemory.Text;
                eocPropertyBean.Computer_TVTuner = txtTvTuner.Text;
                eocPropertyBean.Computer_VideoMemory = txtVideoMemory.Text;
                eocPropertyBean.Computer_HDCPCompliant = txtHDCPCompliant.Text;
                eocPropertyBean.Computer_AudioOutput = txtAudioOutput.Text;
                eocPropertyBean.Computer_DigitalInput = txtDigitalInput.Text;
                eocPropertyBean.Computer_DigitalOutput = txtDigitalOutput.Text;
                eocPropertyBean.Computer_IntegretedMicrophone = txtIntegretedMicrophone.Text;
                eocPropertyBean.Computer_LineOut = txtLineOut.Text;
                eocPropertyBean.Computer_LineInInput = txtLineInInput.Text;
                eocPropertyBean.Computer_MicrophoneInput = txtMicrophoneInput.Text;
                eocPropertyBean.Computer_SoundCard = txtSoundCard.Text;
                eocPropertyBean.Computer_EthernetPort = txtEthernetPort.Text;
                eocPropertyBean.Computer_IntegretedBluetooth = txtIntegretedBluetooth.Text;
                eocPropertyBean.Computer_IntegretedWiFi = txtIntegretedWiFi.Text;
                eocPropertyBean.Computer_CardReader = txtCardReader.Text;
                eocPropertyBean.Computer_DVIOutput = txtDVIOutput.Text;
                eocPropertyBean.Computer_ESata = txtESata.Text;
                eocPropertyBean.Computer_HDMI = txtHDMI.Text;
                eocPropertyBean.Computer_USB2 = txtUSB2.Text;
                eocPropertyBean.Computer_VGAOutput = txtVGAOutput.Text;
                eocPropertyBean.Computer_Webcam = txtWebcam.Text;


                eocPropertyBean.Business_Product_ProductYear = txtProductYear.Text;
                eocPropertyBean.IsNegotiable = chkNegotiable.Checked;

                eocPropertyBean.Source = rblBoromela.Checked ? "ApnerDeal.com" : txtNewspaper.Text;
                eocPropertyBean.Is_Alternative_Address = chkIsDisplayAddress.Checked;

                intActionResult = bocProductProfile.Update_TagSeller_Computer(eocPropertyBean);
            }
        }
        catch (Exception Exp)
        {
            lblSystemMessage.Text = UTLUtilities.ShowErrorMessage(Exp.Message.ToString());
        }

        return intActionResult;

    }


   

    #endregion FOR COMPUTER

    #region FOR AUTOMOBILE


    private void SelectRecord_Automobile()
    {
        //bool _BusinessSeller = true;
        try
        {
            using (BC_Automobile objProduct = new BC_Automobile())
            {
                DataTable dtAutomobile = objProduct.LoadRecord_BS_SpecificAutomobile(ProductID, ProfileID, CategoryID, SubCategoryID, SecondSubcatID);

                if (dtAutomobile.Rows.Count > 0)
                {
                    ProductModelID = Convert.ToInt32(dtAutomobile.Rows[0]["ProductModelID"]);
                    ProductModel = dtAutomobile.Rows[0]["ProductModel"].ToString();

                    txtQuantity.Text = dtAutomobile.Rows[0]["Qty"].ToString();
                    
                    ddlCurrency.SelectedValue = dtAutomobile.Rows[0]["Currency"].ToString();
                    txtDescription.Text = dtAutomobile.Rows[0]["ProductDesc"].ToString();
                    ddlCondition.SelectedValue = dtAutomobile.Rows[0]["Condition"].ToString();
                    txtConditionNote.Text = dtAutomobile.Rows[0]["ConditionNote"].ToString();

                    Sku = dtAutomobile.Rows[0]["SKU"].ToString();

                    
                    if (dtAutomobile.Rows[0]["ProductYear"] != null)
                    {
                        txtProductYear.Text = dtAutomobile.Rows[0]["ProductYear"].ToString();
                    }
                    else
                    {
                        txtProductYear.Text = "";
                    }


                    chkNegotiable.Checked = Convert.ToBoolean(dtAutomobile.Rows[0]["IsNegotiable"].ToString());
                    if (chkNegotiable.Checked)
                    {
                        txtProductPrice.Enabled = false;
                        txtProductPrice.Text = "0";
                    }
                    else
                    {
                        txtProductPrice.Enabled = true;
                        txtProductPrice.Text = dtAutomobile.Rows[0]["Price"].ToString();
                    }
                    



                    ProductModel = dtAutomobile.Rows[0]["ProductModel"].ToString();
                    ProductModelID = Convert.ToInt32(dtAutomobile.Rows[0]["ProductModelID"].ToString());

                    if (dtAutomobile.Rows[0]["IsActive"] != null)
                    {
                        chkAuto.Checked = Convert.ToBoolean(dtAutomobile.Rows[0]["IsActive"]);
                    }
                    

                    ImagePath = dtAutomobile.Rows[0]["ProductImage"].ToString();

                    if (dtAutomobile.Rows[0]["CanEditProduct"] != null)
                    {
                        CanEdit = Convert.ToInt32(dtAutomobile.Rows[0]["CanEditProduct"]);
                    }
                    if (dtAutomobile.Rows[0]["CarSubModel"] != null)
                    {
                        txtCarSubModel.Text = dtAutomobile.Rows[0]["CarSubModel"].ToString();
                    }
                    if (dtAutomobile.Rows[0]["VIN"] != null)
                    {
                        txtVIN.Text = dtAutomobile.Rows[0]["VIN"].ToString();
                    }
                    if (dtAutomobile.Rows[0]["Mileage"] != null)
                    {
                        txtMileage.Text = dtAutomobile.Rows[0]["Mileage"].ToString();
                    }
                    if (dtAutomobile.Rows[0]["VehicleRegYear"] != null)
                    {
                        txtVehicleRegYear.Text = dtAutomobile.Rows[0]["VehicleRegYear"].ToString();
                    }

                    if (object.Equals(dtAutomobile.Rows[0]["ProfileID"], dtAutomobile.Rows[0]["CanEditProduct"]))
                    {
                        this.Block_MasterField(false);
                    }
                    else
                    {
                        this.Block_MasterField(true);
                    }
                    #region SOURCE PANEL SELCTION

                    if (dtAutomobile.Rows[0]["Source"].ToString() == "ApnerDeal.com")
                    {
                        rblBoromela.Checked = true;
                        rblNewspaper.Checked = false;
                    }
                    else
                    {
                        rblBoromela.Checked = false;
                        rblNewspaper.Checked = true;
                        txtNewspaper.Text = dtAutomobile.Rows[0]["Source"].ToString();
                    }
                    chkIsDisplayAddress.Checked = Convert.ToBoolean(dtAutomobile.Rows[0]["IsAlternativeAddress"]);
                    #endregion SOURCE PANEL SELCTION
                }
                else
                {
                    strSystemMessage = "<table style='width:100%; '>";

                    strSystemMessage += "<tr>";
                    strSystemMessage += "<td colspan='2' style='width:100%; color:#000000; padding-top:7px; padding-left:10px;'>";
                    strSystemMessage += "Product Profile not found!";
                    strSystemMessage += "<br/><br/>";
                    strSystemMessage += "<strong>How did this happen? </strong>";
                    strSystemMessage += "<ul>";
                    strSystemMessage += "<li>You login session may be expired.</li>";
                    strSystemMessage += "<li>Your Ad may be deleted by ApnerDeal authority for some reason.</li>";
                    strSystemMessage += "</ul>";
                    strSystemMessage += "</td>";
                    strSystemMessage += "</tr>";
                    strSystemMessage += "</table>";

                    lblSystemMessage.Text = UTLUtilities.ShowErrorMessage(strSystemMessage);
                }
            }
        }
        catch (Exception Exp)
        {
            lblSystemMessage.Text = UTLUtilities.ShowErrorMessage(Exp.Message.ToString());
        }
    }


    /// <summary>
    /// Selects ProductID, Product Model from LatesPostedMobile
    /// </summary>
    /// <param name="categoryID"></param>
    /// <param name="subcategoryID"></param>
    /// <param name="secondSubcatID"></param>
    /// <param name="profileID"></param>
    /// <param name="productID"></param>
    private void Select_Master_AutoMobileRecord(int categoryID, int subcategoryID, int secondSubcatID, int productID)
    {
        DataTable dt = new DataTable();
        try
        {
            using (BC_Automobile bcProduct = new BC_Automobile())
            {
                dt = bcProduct.SelectSpecific_MasterAutomobileRecord(categoryID, subcategoryID, secondSubcatID, productID);
                if (dt.Rows.Count > 0)
                {
                    ProductModelID = Convert.ToInt32(dt.Rows[0]["ProductModelID"]);
                    ProductModel = dt.Rows[0]["ProductModel"].ToString();

                    txtCarSubModel.Text = dt.Rows[0]["CarSubModel"].ToString();
                }
            }
        }
        catch (Exception ex)
        {
            lblSystemMessage.Text = UTLUtilities.ShowErrorMessage(ex.Message);
        }
    }



    /// <summary>
    /// Inserts New AUTOMOBILE Entry into DataBase.
    /// </summary>
    /// <returns></returns>
    private int Add_MasterRecord_Automobile()
    {
        int intActionResult = 0;
        if (!Check_IsMasterProductDuplicate(CategoryID, SubCategoryID, SecondSubcatID, ProductTitle))
        {
            try
            {
                using (BOC_Corporate_Automobile bocProductProfile = new BOC_Corporate_Automobile())
                {
                    EOC_PropertyBean eocPropertyBean = new EOC_PropertyBean();

                    eocPropertyBean.Business_UserProfile_ProfileID = ProfileID;
                    eocPropertyBean.Business_ProductProfile_Books_SKU = Sku;

                    eocPropertyBean.Category_CategoryID = CategoryID;
                    eocPropertyBean.Subcategory_SubcategoryID = SubCategoryID;

                    eocPropertyBean.SecondSubcategory_SubcategoryID = SecondSubcatID;
                    eocPropertyBean.Model_ModelID = ProductModelID;
                    eocPropertyBean.Business_ProductProfile_Books_BookTitle = ProductTitle;


                    eocPropertyBean.Business_ProductProfile_Description = txtDescription.Text;
                    eocPropertyBean.Business_ProductProfile_Quantity = Convert.ToInt32(txtQuantity.Text);
                    eocPropertyBean.Business_ProductProfile_Books_Currency = ddlCurrency.Text;
                    eocPropertyBean.Business_ProductProfile_Books_ProductPrice = Convert.ToDouble(txtProductPrice.Text);


                    eocPropertyBean.Business_ProductProfile_Books_SalePrice = 0.00;
                    eocPropertyBean.Business_ProductProfile_Books_StartDate = DateTime.Now;
                    eocPropertyBean.Business_ProductProfile_Books_EndDate = DateTime.Now;


                    eocPropertyBean.Business_Product_Profile_Books_Condition = ddlCondition.SelectedValue;
                    eocPropertyBean.Business_Product_Profile_Books_ConditionNote = txtConditionNote.Text;




                    if (string.IsNullOrEmpty(ImagePath))
                    {
                        eocPropertyBean.Business_ProductProfile_Books_ProductImage = @"../Corporate_ProductImage/default.png";
                    }
                    else
                    {
                        eocPropertyBean.Business_ProductProfile_Books_ProductImage = ImagePath;
                    }

                    eocPropertyBean.UserType = ClassifiedSeller;
                    eocPropertyBean.UpdatedOn = DateTime.Now;
                    eocPropertyBean.Business_ProductProfile_IsActive = chkAuto.Checked;


                    eocPropertyBean.Automobile_VIN = txtVIN.Text;
                    eocPropertyBean.Automobile_Mileage = txtMileage.Text;
                    eocPropertyBean.Automobile_VehicleRegYear = txtVehicleRegYear.Text;
                    eocPropertyBean.Automobile_CarSubModel = txtCarSubModel.Text;

                    eocPropertyBean.Business_Product_ProductYear = txtProductYear.Text;




                    eocPropertyBean.Business_ProductProfile_Books_SalePrice = 0.00;
                    eocPropertyBean.Business_ProductProfile_Books_StartDate = DateTime.Now;
                    eocPropertyBean.Business_ProductProfile_Books_EndDate = DateTime.Now;

                    eocPropertyBean.Business_ProductProfile_CashOnDelivery = chkCod.Checked;
                    eocPropertyBean.Business_ProductProfile_PickFromStore = chkPfs.Checked;
                    eocPropertyBean.Business_ProductProfile_CashDeposit = chkCash.Checked;

                    eocPropertyBean.Business_ProductProfile_General_DeliveryArea = ddlDeliveryArea.SelectedValue;
                    if (chkCod.Checked && ddlDeliveryArea.SelectedValue == "Outside of Bangladesh")
                    {
                        eocPropertyBean.Business_ProductProfile_SellerForeignAddress = txtSellerForeignAddress.Text;
                    }
                    else
                    {
                        eocPropertyBean.Business_ProductProfile_SellerForeignAddress = "";
                    }
                    eocPropertyBean.IsNegotiable = chkNegotiable.Checked;

                    eocPropertyBean.Source = rblBoromela.Checked ? "ApnerDeal.com" : txtNewspaper.Text;
                    eocPropertyBean.Is_Alternative_Address = chkIsDisplayAddress.Checked;

                    intActionResult = bocProductProfile.Insert_MasterRecord_Automobile(eocPropertyBean);

                }
            }
            catch (Exception Exp)
            {
                lblSystemMessage.Text = UTLUtilities.ShowErrorMessage(Exp.Message.ToString());
            }
        }
        else
        {
            return -2;
        }
        return intActionResult;
    }






    /// <summary>
    /// Inserts TagSellers Automobile information in Database.
    /// </summary>
    private int Add_DetailRecord_Automobile()
    {
        if (!Is_Seller_Tagged_Once(ProductID, ProfileID, SellerType, CategoryID))
        {
            try
            {
                using (BOC_Corporate_Automobile bocProductProfile = new BOC_Corporate_Automobile())
                {
                    EOC_PropertyBean eocPropertyBean = new EOC_PropertyBean();

                    eocPropertyBean.Business_UserProfile_ProfileID = ProfileID;
                    eocPropertyBean.Business_ProductProfile_Books_ProductID = ProductID;

                    eocPropertyBean.Business_ProductProfile_Books_SKU = Sku;
                    eocPropertyBean.Business_ProductProfile_Description = txtDescription.Text;
                    eocPropertyBean.Business_ProductProfile_Quantity = Convert.ToInt32(txtQuantity.Text);
                    eocPropertyBean.Business_ProductProfile_Books_Currency = ddlCurrency.SelectedValue;
                    eocPropertyBean.Business_ProductProfile_Books_ProductPrice = Convert.ToDouble(txtProductPrice.Text);


                    eocPropertyBean.Business_Product_Profile_Books_Condition = ddlCondition.SelectedValue;
                    eocPropertyBean.Business_Product_Profile_Books_ConditionNote = txtConditionNote.Text;


                    eocPropertyBean.UserType = ClassifiedSeller;

                    eocPropertyBean.UpdatedOn = DateTime.Now;
                    eocPropertyBean.Business_ProductProfile_IsActive = chkAuto.Checked;

                    eocPropertyBean.Automobile_VIN = txtVIN.Text;
                    eocPropertyBean.Automobile_Mileage = txtMileage.Text;
                    eocPropertyBean.Automobile_VehicleRegYear = txtVehicleRegYear.Text;
                    eocPropertyBean.Automobile_CarSubModel = txtCarSubModel.Text;


                    eocPropertyBean.Business_Product_ProductYear = txtProductYear.Text;


                    eocPropertyBean.Business_ProductProfile_Books_SalePrice = 0.00;
                    eocPropertyBean.Business_ProductProfile_Books_StartDate = DateTime.Now;
                    eocPropertyBean.Business_ProductProfile_Books_EndDate = DateTime.Now;

                    eocPropertyBean.Business_ProductProfile_CashOnDelivery = chkCod.Checked;
                    eocPropertyBean.Business_ProductProfile_PickFromStore = chkPfs.Checked;
                    eocPropertyBean.Business_ProductProfile_CashDeposit = chkCash.Checked;

                    eocPropertyBean.Business_ProductProfile_General_DeliveryArea = ddlDeliveryArea.SelectedItem.Text;


                    if (chkCod.Checked && ddlDeliveryArea.SelectedValue == "Outside of Bangladesh")
                    {
                        eocPropertyBean.Business_ProductProfile_SellerForeignAddress = txtSellerForeignAddress.Text;
                    }
                    else
                    {
                        eocPropertyBean.Business_ProductProfile_SellerForeignAddress = "";
                    }
                    eocPropertyBean.IsNegotiable = chkNegotiable.Checked;

                    eocPropertyBean.Source = rblBoromela.Checked ? "ApnerDeal.com" : txtNewspaper.Text;
                    eocPropertyBean.Is_Alternative_Address = chkIsDisplayAddress.Checked;

                    intActionResult = bocProductProfile.Insert_DetailRecord_Automobile(eocPropertyBean);

                }
            }
            catch (Exception Exp)
            {
                lblSystemMessage.Text = UTLUtilities.ShowErrorMessage(Exp.Message.ToString());
            }
        }
        else
        {
            return -2;        
        }
        return intActionResult;
    }




    ///// <summary>
    ///// Updates Computer Record For Master Seller. Who can Edit Image and other Compueter Acessesories.
    ///// </summary>
    ///// <returns></returns>
    private int Update_MasterSeller_Automobile()
    {
        try
        {
            using (BOC_Corporate_Automobile bocProductProfile = new BOC_Corporate_Automobile())
            {
                EOC_PropertyBean eocPropertyBean = new EOC_PropertyBean();

                eocPropertyBean.Business_UserProfile_ProfileID = ProfileID;
                eocPropertyBean.Business_ProductProfile_Books_ProductID = ProductID;
                eocPropertyBean.Business_ProductProfile_Description = txtDescription.Text;
                eocPropertyBean.Business_ProductProfile_Quantity = Convert.ToInt32(txtQuantity.Text);

                eocPropertyBean.Category_CategoryID = CategoryID;
                eocPropertyBean.Subcategory_SubcategoryID = SubCategoryID;
                eocPropertyBean.SecondSubcategory_SubcategoryID = SecondSubcatID;
                eocPropertyBean.Model_ModelID = ProductModelID;


                eocPropertyBean.Business_ProductProfile_Books_Currency = ddlCurrency.Text;
                eocPropertyBean.Business_ProductProfile_Books_ProductPrice = Convert.ToDouble(txtProductPrice.Text);


                eocPropertyBean.Business_Product_Profile_Books_Condition = ddlCondition.SelectedValue;
                eocPropertyBean.Business_Product_Profile_Books_ConditionNote = txtConditionNote.Text;


                if (string.IsNullOrEmpty(ImagePath))
                {
                    eocPropertyBean.Business_ProductProfile_Books_ProductImage = @"../Corporate_ProductImage/default.png";
                }
                else
                {
                    eocPropertyBean.Business_ProductProfile_Books_ProductImage = ImagePath;
                }

                eocPropertyBean.UserType = ClassifiedSeller;

                eocPropertyBean.UpdatedOn = DateTime.Now;
                eocPropertyBean.Business_ProductProfile_IsActive = chkAuto.Checked;


                eocPropertyBean.Automobile_VIN = txtVIN.Text;
                eocPropertyBean.Automobile_Mileage = txtMileage.Text;
                eocPropertyBean.Automobile_VehicleRegYear = txtVehicleRegYear.Text;

                eocPropertyBean.Business_Product_ProductYear = txtProductYear.Text;


                eocPropertyBean.Business_ProductProfile_Books_SalePrice = 0.00;
                eocPropertyBean.Business_ProductProfile_Books_StartDate = DateTime.Now;
                eocPropertyBean.Business_ProductProfile_Books_EndDate = DateTime.Now;

                eocPropertyBean.Business_ProductProfile_CashOnDelivery = chkCod.Checked;
                eocPropertyBean.Business_ProductProfile_PickFromStore = chkPfs.Checked;
                eocPropertyBean.Business_ProductProfile_CashDeposit = chkCash.Checked;
                eocPropertyBean.Business_ProductProfile_General_DeliveryArea = ddlDeliveryArea.SelectedValue;

                if (chkCod.Checked && ddlDeliveryArea.SelectedValue == "Outside of Bangladesh")
                {
                    eocPropertyBean.Business_ProductProfile_SellerForeignAddress = txtSellerForeignAddress.Text;
                }
                else
                {
                    eocPropertyBean.Business_ProductProfile_SellerForeignAddress = "";
                }


                eocPropertyBean.IsNegotiable = chkNegotiable.Checked;

                eocPropertyBean.Source = rblBoromela.Checked ? "ApnerDeal.com" : txtNewspaper.Text;
                eocPropertyBean.Is_Alternative_Address = chkIsDisplayAddress.Checked;

                intActionResult = bocProductProfile.Update_MasterSeller_Automobile(eocPropertyBean);

            }
        }
        catch (Exception Exp)
        {
            lblSystemMessage.Text = UTLUtilities.ShowErrorMessage(Exp.Message.ToString());
        }

        return intActionResult;
    }




    /// <summary>
    /// Updates Automobile Record of the Tag Seller.
    /// </summary>
    /// <returns></returns>
    private int Update_TagSeller_Automobile()
    {
        int intActionResult = 0;

        try
        {
            using (BOC_Corporate_Automobile bocProductProfile = new BOC_Corporate_Automobile())
            {
                EOC_PropertyBean eocPropertyBean = new EOC_PropertyBean();
                eocPropertyBean.Business_UserProfile_ProfileID = ProfileID;
                eocPropertyBean.Business_ProductProfile_Books_ProductID = ProductID;

                eocPropertyBean.Business_ProductProfile_Description = txtDescription.Text;
                eocPropertyBean.Business_ProductProfile_Quantity = Convert.ToInt32(txtQuantity.Text);
                eocPropertyBean.Business_ProductProfile_Books_Currency = ddlCurrency.SelectedValue;
                eocPropertyBean.Business_ProductProfile_Books_ProductPrice = Convert.ToDouble(txtProductPrice.Text);


                eocPropertyBean.Business_ProductProfile_Books_SalePrice = 0.00;
                eocPropertyBean.Business_ProductProfile_Books_StartDate = DateTime.Now;
                eocPropertyBean.Business_ProductProfile_Books_EndDate = DateTime.Now;


                eocPropertyBean.Business_Product_Profile_Books_Condition = ddlCondition.SelectedValue;
                eocPropertyBean.Business_Product_Profile_Books_ConditionNote = txtConditionNote.Text;

                eocPropertyBean.Business_ProductProfile_CashOnDelivery = chkCod.Checked;
                eocPropertyBean.Business_ProductProfile_PickFromStore = chkPfs.Checked;
                eocPropertyBean.Business_ProductProfile_CashDeposit = chkCash.Checked;
                eocPropertyBean.Business_ProductProfile_General_DeliveryArea = ddlDeliveryArea.SelectedValue;

                if (chkCod.Checked && ddlDeliveryArea.SelectedValue == "Outside of Bangladesh")
                {
                    eocPropertyBean.Business_ProductProfile_SellerForeignAddress = txtSellerForeignAddress.Text;
                }
                else
                {
                    eocPropertyBean.Business_ProductProfile_SellerForeignAddress = "";
                }



                eocPropertyBean.UserType = ClassifiedSeller;

                eocPropertyBean.UpdatedOn = DateTime.Now;
                eocPropertyBean.Business_ProductProfile_IsActive = chkMobile.Checked;
                eocPropertyBean.Business_Product_ProductYear = txtProductYear.Text;

                eocPropertyBean.Automobile_VIN = txtVIN.Text;
                eocPropertyBean.Automobile_Mileage = txtMileage.Text;
                eocPropertyBean.Automobile_VehicleRegYear = txtVehicleRegYear.Text;

                eocPropertyBean.IsNegotiable = chkNegotiable.Checked;

                eocPropertyBean.Source = rblBoromela.Checked ? "ApnerDeal.com" : txtNewspaper.Text;
                eocPropertyBean.Is_Alternative_Address = chkIsDisplayAddress.Checked;


                intActionResult = bocProductProfile.Update_TagSeller_Automobile(eocPropertyBean);
            }
        }
        catch (Exception Exp)
        {
            lblSystemMessage.Text = UTLUtilities.ShowErrorMessage(Exp.Message.ToString());
        }

        return intActionResult;

    }




    

    #endregion FOR AUTOMOBILE


    #region FOR ELECTRONICS

    private void SelectRecord_Electronics()
    {

        try
        {
            using (BC_Corporate_Electronics objElectronics = new BC_Corporate_Electronics())
            {
                DataTable dtElectronics = objElectronics.LoadRecord_BS_SpecificElectronics(ProductID, ProfileID, CategoryID, SubCategoryID, SecondSubcatID);

                if (dtElectronics.Rows.Count > 0)
                {
                    txtQuantity.Text = dtElectronics.Rows[0]["Qty"].ToString();
                    ddlCurrency.SelectedValue = dtElectronics.Rows[0]["Currency"].ToString();
                    txtDescription.Text = dtElectronics.Rows[0]["ProductDesc"].ToString();
                    ddlCondition.SelectedValue = dtElectronics.Rows[0]["Condition"].ToString();

                    txtConditionNote.Text = dtElectronics.Rows[0]["ConditionNote"].ToString();
                    chkNegotiable.Checked = Convert.ToBoolean(dtElectronics.Rows[0]["IsNegotiable"].ToString());
                    Sku = dtElectronics.Rows[0]["SKU"].ToString();

                    
                    if (chkNegotiable.Checked)
                    {
                        txtProductPrice.Enabled = false;
                        txtProductPrice.Text = "0";
                    }
                    else
                    {
                        txtProductPrice.Enabled = true;
                        txtProductPrice.Text = dtElectronics.Rows[0]["Price"].ToString();
                    }

                    if (dtElectronics.Rows[0]["ProductYear"] != null)
                    {
                        txtProductYear.Text = dtElectronics.Rows[0]["ProductYear"].ToString();
                    }
                    else
                    {
                        txtProductYear.Text = "";
                    }


                    ProductModel = dtElectronics.Rows[0]["ProductModel"].ToString();
                    ProductModelID = Convert.ToInt32(dtElectronics.Rows[0]["ProductModelID"].ToString());



                    if (dtElectronics.Rows[0]["IsActive"] != null)
                    {
                        chkElectronics.Checked = Convert.ToBoolean(dtElectronics.Rows[0]["IsActive"]);
                    }


                    ImagePath = dtElectronics.Rows[0]["ProductImage"].ToString();

                    if (dtElectronics.Rows[0]["CanEditProduct"] != null)
                    {
                        CanEdit = Convert.ToInt32(dtElectronics.Rows[0]["CanEditProduct"]);
                    }

                    if (object.Equals(dtElectronics.Rows[0]["ProfileID"], dtElectronics.Rows[0]["CanEditProduct"]))
                    {
                        this.Block_MasterField(false);
                    }
                    else
                    {
                        this.Block_MasterField(true);
                    }

                    #region SOURCE PANEL SELCTION

                    if (dtElectronics.Rows[0]["Source"].ToString() == "ApnerDeal.com")
                    {
                        rblBoromela.Checked = true;
                        rblNewspaper.Checked = false;
                    }
                    else
                    {
                        rblBoromela.Checked = false;
                        rblNewspaper.Checked = true;
                        txtNewspaper.Text = dtElectronics.Rows[0]["Source"].ToString();
                    }
                    chkIsDisplayAddress.Checked = Convert.ToBoolean(dtElectronics.Rows[0]["IsAlternativeAddress"]);

                    #endregion SOURCE PANEL SELCTION

                }
                else
                {
                    strSystemMessage = "<table style='width:100%; '>";

                    strSystemMessage += "<tr>";
                    strSystemMessage += "<td colspan='2' style='width:100%; color:#000000; padding-top:7px; padding-left:10px;'>";
                    strSystemMessage += "Product Profile not found!";
                    strSystemMessage += "<br/><br/>";
                    strSystemMessage += "<strong>How did this happen? </strong>";
                    strSystemMessage += "<ul>";
                    strSystemMessage += "<li>You login session may be expired.</li>";
                    strSystemMessage += "<li>Your Ad may be deleted by ApnerDeal authority for some reason.</li>";
                    strSystemMessage += "</ul>";
                    strSystemMessage += "</td>";
                    strSystemMessage += "</tr>";
                    strSystemMessage += "</table>";

                    lblSystemMessage.Text = UTLUtilities.ShowErrorMessage(strSystemMessage);
                }



            }
        }
        catch (Exception Exp)
        {
            lblSystemMessage.Text = UTLUtilities.ShowErrorMessage(Exp.Message.ToString());
        }
    }

    private void Select_Master_ElectronicsRecord(int categoryID, int subcategoryID, int secondSubcatID, int profileID, int productID)
    {
        DataTable dt = new DataTable();
        try
        {
            using (BC_Corporate_Electronics bcProduct = new BC_Corporate_Electronics())
            {
                dt = bcProduct.SelectSpecific_Master_ElectronicsRecord(categoryID, subcategoryID, secondSubcatID, productID);
                if (dt.Rows.Count > 0)
                {
                    ProductModelID = Convert.ToInt32(dt.Rows[0]["ProductModelID"]);
                    ProductModel = dt.Rows[0]["ProductModel"].ToString();
                }
            }
        }
        catch (Exception ex)
        {
            lblSystemMessage.Text = UTLUtilities.ShowErrorMessage(ex.Message);
        }
    }

    private int Add_MasterRecord_Electronics()
    {
        int intActionResult = 0;
        if (!Check_IsMasterProductDuplicate(CategoryID, SubCategoryID, SecondSubcatID, ProductTitle))
        {

            try
            {

                using (BOC_Corporate_Electronics bocProductProfile = new BOC_Corporate_Electronics())
                {
                    EOC_PropertyBean eocPropertyBean = new EOC_PropertyBean();

                    eocPropertyBean.Business_UserProfile_ProfileID = ProfileID;
                    eocPropertyBean.Business_ProductProfile_Books_SKU = Sku;
                    eocPropertyBean.Category_CategoryID = CategoryID;
                    eocPropertyBean.Subcategory_SubcategoryID = SubCategoryID;

                    eocPropertyBean.SecondSubcategory_SubcategoryID = SecondSubcatID;
                    eocPropertyBean.Model_ModelID = ProductModelID;
                    eocPropertyBean.Business_ProductProfile_Books_BookTitle = ProductTitle;


                    eocPropertyBean.Business_ProductProfile_Description = txtDescription.Text;
                    eocPropertyBean.Business_ProductProfile_Quantity = Convert.ToInt32(txtQuantity.Text);
                    eocPropertyBean.Business_ProductProfile_Books_Currency = ddlCurrency.Text;
                    eocPropertyBean.Business_ProductProfile_Books_ProductPrice = Convert.ToDouble(txtProductPrice.Text);

                    eocPropertyBean.Business_ProductProfile_Books_SalePrice = 0.00;
                    eocPropertyBean.Business_ProductProfile_Books_StartDate = DateTime.Now;
                    eocPropertyBean.Business_ProductProfile_Books_EndDate = DateTime.Now;



                    eocPropertyBean.Business_Product_Profile_Books_Condition = ddlCondition.SelectedValue;
                    eocPropertyBean.Business_Product_Profile_Books_ConditionNote = txtConditionNote.Text;

                    eocPropertyBean.Business_ProductProfile_CashOnDelivery = chkCod.Checked;
                    eocPropertyBean.Business_ProductProfile_PickFromStore = chkPfs.Checked;
                    eocPropertyBean.Business_ProductProfile_CashDeposit = chkCash.Checked;
                    eocPropertyBean.Business_ProductProfile_General_DeliveryArea = ddlDeliveryArea.SelectedValue;

                    if (chkCod.Checked && ddlDeliveryArea.SelectedValue == "Outside of Bangladesh")
                    {
                        eocPropertyBean.Business_ProductProfile_SellerForeignAddress = txtSellerForeignAddress.Text;
                    }
                    else
                    {
                        eocPropertyBean.Business_ProductProfile_SellerForeignAddress = "";
                    }


                    if (string.IsNullOrEmpty(ImagePath))
                    {
                        eocPropertyBean.Business_ProductProfile_Books_ProductImage = @"../Corporate_ProductImage/default.png";
                    }
                    else
                    {
                        eocPropertyBean.Business_ProductProfile_Books_ProductImage = ImagePath;
                    }

                    eocPropertyBean.UserType = "0";
                    eocPropertyBean.UpdatedOn = DateTime.Now;
                    eocPropertyBean.Business_ProductProfile_IsActive = chkElectronics.Checked;
                    eocPropertyBean.Business_Product_ProductYear = txtProductYear.Text;

                    eocPropertyBean.IsNegotiable = chkNegotiable.Checked;

                    eocPropertyBean.Source = rblBoromela.Checked ? "ApnerDeal.com" : txtNewspaper.Text;
                    eocPropertyBean.Is_Alternative_Address = chkIsDisplayAddress.Checked;

                    intActionResult = bocProductProfile.Insert_MasterRecord_Electronics(eocPropertyBean);

                }
            }

            catch (Exception Exp)
            {
                lblSystemMessage.Text = UTLUtilities.ShowErrorMessage(Exp.Message.ToString());
            }
        }
        else
        {
            return -2;
        }
        return intActionResult;
    }
    /// <summary>
    /// Inserts TagSellers Data in ELECTRONICS.
    /// </summary>
    private int Add_DetailRecord_Electronics()
    {
        if (!Is_Seller_Tagged_Once(ProductID, ProfileID, SellerType, CategoryID))
        {
            try
            {
                using (BOC_Corporate_Electronics bocProductProfile = new BOC_Corporate_Electronics())
                {
                    EOC_PropertyBean eocPropertyBean = new EOC_PropertyBean();

                    eocPropertyBean.Business_UserProfile_ProfileID = ProfileID;
                    eocPropertyBean.Business_ProductProfile_Books_ProductID = ProductID;

                    eocPropertyBean.Business_ProductProfile_Books_SKU = Sku;
                    eocPropertyBean.Business_ProductProfile_Description = txtDescription.Text;
                    eocPropertyBean.Business_ProductProfile_Quantity = Convert.ToInt32(txtQuantity.Text);
                    eocPropertyBean.Business_ProductProfile_Books_Currency = ddlCurrency.SelectedValue;
                    eocPropertyBean.Business_ProductProfile_Books_ProductPrice = Convert.ToDouble(txtProductPrice.Text);


                    eocPropertyBean.Business_ProductProfile_Books_SalePrice = 0.00;
                    eocPropertyBean.Business_ProductProfile_Books_StartDate = DateTime.Now;
                    eocPropertyBean.Business_ProductProfile_Books_EndDate = DateTime.Now;



                    eocPropertyBean.Business_Product_Profile_Books_Condition = ddlCondition.SelectedValue;
                    eocPropertyBean.Business_Product_Profile_Books_ConditionNote = txtConditionNote.Text;

                    eocPropertyBean.Business_ProductProfile_CashOnDelivery = chkCod.Checked;
                    eocPropertyBean.Business_ProductProfile_PickFromStore = chkPfs.Checked;
                    eocPropertyBean.Business_ProductProfile_CashDeposit = chkCash.Checked;
                    eocPropertyBean.Business_ProductProfile_General_DeliveryArea = ddlDeliveryArea.SelectedItem.Text;


                    if (chkCod.Checked && ddlDeliveryArea.SelectedValue == "Outside of Bangladesh")
                    {
                        eocPropertyBean.Business_ProductProfile_SellerForeignAddress = txtSellerForeignAddress.Text;
                    }
                    else
                    {
                        eocPropertyBean.Business_ProductProfile_SellerForeignAddress = "";
                    }

                    eocPropertyBean.UserType = "0";

                    eocPropertyBean.UpdatedOn = DateTime.Now;
                    eocPropertyBean.Business_ProductProfile_IsActive = chkElectronics.Checked;
                    eocPropertyBean.Business_Product_ProductYear = txtProductYear.Text;
                    eocPropertyBean.IsNegotiable = chkNegotiable.Checked;

                    eocPropertyBean.Source = rblBoromela.Checked ? "ApnerDeal.com" : txtNewspaper.Text;
                    eocPropertyBean.Is_Alternative_Address = chkIsDisplayAddress.Checked;

                    intActionResult = bocProductProfile.Insert_DetailRecord_Electronics(eocPropertyBean);

                }
            }
            catch (Exception Exp)
            {
                lblSystemMessage.Text = UTLUtilities.ShowErrorMessage(Exp.Message.ToString());
            }
        }
        else
        {
            return -2;
        }
        return intActionResult;
    }

    private int Update_MasterSeller_Electronics()
    {
        try
        {
            using (BOC_Corporate_Electronics bocProductProfile = new BOC_Corporate_Electronics())
            {
                EOC_PropertyBean eocPropertyBean = new EOC_PropertyBean();

                eocPropertyBean.Business_UserProfile_ProfileID = ProfileID;
                eocPropertyBean.Business_ProductProfile_Books_ProductID = ProductID;
                //eocPropertyBean.Business_ProductProfile_Books_SKU = Sku;
                eocPropertyBean.Category_CategoryID = CategoryID;
                eocPropertyBean.Subcategory_SubcategoryID = SubCategoryID;
                eocPropertyBean.SecondSubcategory_SubcategoryID = SecondSubcatID;
                //eocPropertyBean.Model_ModelID = ProductModelID;
                //eocPropertyBean.Business_ProductProfile_Books_BookTitle = ProductTitle;


                eocPropertyBean.Business_ProductProfile_Description = txtDescription.Text;
                eocPropertyBean.Business_ProductProfile_Quantity = Convert.ToInt32(txtQuantity.Text);
                eocPropertyBean.Business_ProductProfile_Books_Currency = ddlCurrency.Text;
                eocPropertyBean.Business_ProductProfile_Books_ProductPrice = Convert.ToDouble(txtProductPrice.Text);


                eocPropertyBean.Business_ProductProfile_Books_SalePrice = 0.00;
                eocPropertyBean.Business_ProductProfile_Books_StartDate = DateTime.Now;
                eocPropertyBean.Business_ProductProfile_Books_EndDate = DateTime.Now;


                eocPropertyBean.Business_Product_Profile_Books_Condition = ddlCondition.SelectedValue;
                eocPropertyBean.Business_Product_Profile_Books_ConditionNote = txtConditionNote.Text;

                eocPropertyBean.Business_ProductProfile_CashOnDelivery = chkCod.Checked;
                eocPropertyBean.Business_ProductProfile_PickFromStore = chkPfs.Checked;
                eocPropertyBean.Business_ProductProfile_CashDeposit = chkCash.Checked;
                eocPropertyBean.Business_ProductProfile_General_DeliveryArea = ddlDeliveryArea.SelectedValue;

                if (chkCod.Checked && ddlDeliveryArea.SelectedValue == "Outside of Bangladesh")
                {
                    eocPropertyBean.Business_ProductProfile_SellerForeignAddress = txtSellerForeignAddress.Text;
                }
                else
                {
                    eocPropertyBean.Business_ProductProfile_SellerForeignAddress = "";
                }


                if (string.IsNullOrEmpty(ImagePath))
                {
                    eocPropertyBean.Business_ProductProfile_Books_ProductImage = @"../Corporate_ProductImage/default.png";
                }
                else
                {
                    eocPropertyBean.Business_ProductProfile_Books_ProductImage = ImagePath;
                }

                eocPropertyBean.UserType = "0";
                eocPropertyBean.UpdatedOn = DateTime.Now;
                eocPropertyBean.Business_ProductProfile_IsActive = chkElectronics.Checked;
                eocPropertyBean.Business_Product_ProductYear = txtProductYear.Text;

                eocPropertyBean.IsNegotiable = chkNegotiable.Checked;

                eocPropertyBean.Source = rblBoromela.Checked ? "ApnerDeal.com" : txtNewspaper.Text;
                eocPropertyBean.Is_Alternative_Address = chkIsDisplayAddress.Checked;

                intActionResult = bocProductProfile.Update_MasterSeller_Electronics(eocPropertyBean);

            }
        }
        catch (Exception Exp)
        {
            lblSystemMessage.Text = UTLUtilities.ShowErrorMessage(Exp.Message.ToString());
        }

        return intActionResult;
    }

    /// <summary>
    /// Update Electronics Record of the Tag Seller.
    /// </summary>
    /// <returns></returns>
    private int Update_TagSeller_Electronics()
    {
        int intActionResult = 0;

        try
        {
            using (BOC_Corporate_Electronics bocProductProfile = new BOC_Corporate_Electronics())
            {
                EOC_PropertyBean eocPropertyBean = new EOC_PropertyBean();
                eocPropertyBean.Business_UserProfile_ProfileID = ProfileID;
                eocPropertyBean.Business_ProductProfile_Books_ProductID = ProductID;

                eocPropertyBean.Business_ProductProfile_Description = txtDescription.Text;
                eocPropertyBean.Business_ProductProfile_Quantity = Convert.ToInt32(txtQuantity.Text);
                eocPropertyBean.Business_ProductProfile_Books_Currency = ddlCurrency.SelectedValue;
                eocPropertyBean.Business_ProductProfile_Books_ProductPrice = Convert.ToDouble(txtProductPrice.Text);


                eocPropertyBean.Business_ProductProfile_Books_SalePrice = 0.00;
                eocPropertyBean.Business_ProductProfile_Books_StartDate = DateTime.Now;
                eocPropertyBean.Business_ProductProfile_Books_EndDate = DateTime.Now;



                eocPropertyBean.Business_Product_Profile_Books_Condition = ddlCondition.SelectedValue;
                eocPropertyBean.Business_Product_Profile_Books_ConditionNote = txtConditionNote.Text;

                eocPropertyBean.Business_ProductProfile_CashOnDelivery = chkCod.Checked;
                eocPropertyBean.Business_ProductProfile_PickFromStore = chkPfs.Checked;
                eocPropertyBean.Business_ProductProfile_CashDeposit = chkCash.Checked;
                eocPropertyBean.Business_ProductProfile_General_DeliveryArea = ddlDeliveryArea.SelectedValue;

                if (chkCod.Checked && ddlDeliveryArea.SelectedValue == "Outside of Bangladesh")
                {
                    eocPropertyBean.Business_ProductProfile_SellerForeignAddress = txtSellerForeignAddress.Text;
                }
                else
                {
                    eocPropertyBean.Business_ProductProfile_SellerForeignAddress = "";
                }

                eocPropertyBean.UserType = "0";

                eocPropertyBean.UpdatedOn = DateTime.Now;
                eocPropertyBean.Business_ProductProfile_IsActive = chkElectronics.Checked;
                eocPropertyBean.Business_Product_ProductYear = txtProductYear.Text;

                eocPropertyBean.IsNegotiable = chkNegotiable.Checked;

                eocPropertyBean.Source = rblBoromela.Checked ? "ApnerDeal.com" : txtNewspaper.Text;
                eocPropertyBean.Is_Alternative_Address = chkIsDisplayAddress.Checked;

                intActionResult = bocProductProfile.Update_TagSeller_Electronics(eocPropertyBean);
            }
        }
        catch (Exception Exp)
        {
            lblSystemMessage.Text = UTLUtilities.ShowErrorMessage(Exp.Message.ToString());
        }

        return intActionResult;

    }

    #endregion FOR ELECTRONICS


    #region  FOR MovieDvdGame

    /// <summary>
    /// Insert Master Product for MovieDvdGame 
    /// </summary>
    /// <returns></returns>
    private int Add_MasterRecord_MovieDvdGameProduct()
    {
        int intActionResult = 0;

        if (!Check_IsMasterProductDuplicate(CategoryID, SubCategoryID, SecondSubcatID, ProductTitle))
        {
            try
            {
                using (BOC_Corporate_MovieDvdMusic bocProductProfile = new BOC_Corporate_MovieDvdMusic())
                {
                    EOC_PropertyBean eocPropertyBean = new EOC_PropertyBean();


                    eocPropertyBean.Business_UserProfile_ProfileID = ProfileID;
                    eocPropertyBean.Category_CategoryID = CategoryID;
                    eocPropertyBean.Subcategory_SubcategoryID = SubCategoryID;
                    eocPropertyBean.SecondSubcategory_SubcategoryID = SecondSubcatID;

                    eocPropertyBean.Business_ProductProfile_Books_BookTitle = ProductTitle;
                    eocPropertyBean.Business_ProductProfile_Books_SKU = Sku;
                    eocPropertyBean.Business_ProductProfile_Description = txtDescription.Text;
                    eocPropertyBean.Business_ProductProfile_Quantity = Convert.ToInt32(txtQuantity.Text);

                    eocPropertyBean.Business_ProductProfile_Books_Currency = ddlCurrency.Text;
                    eocPropertyBean.Business_ProductProfile_Books_ProductPrice = Convert.ToDouble(txtProductPrice.Text);

                    eocPropertyBean.Business_ProductProfile_Books_SalePrice = 0.00;
                    eocPropertyBean.Business_ProductProfile_Books_StartDate = DateTime.Now;
                    eocPropertyBean.Business_ProductProfile_Books_EndDate = DateTime.Now;

                    eocPropertyBean.Business_Product_Profile_Books_Condition = ddlCondition.SelectedValue;
                    eocPropertyBean.Business_Product_Profile_Books_ConditionNote = txtConditionNote.Text;

                    eocPropertyBean.Business_ProductProfile_CashOnDelivery = chkCod.Checked;
                    eocPropertyBean.Business_ProductProfile_PickFromStore = chkPfs.Checked;
                    eocPropertyBean.Business_ProductProfile_CashDeposit = chkCash.Checked;
                    eocPropertyBean.IsNegotiable = chkNegotiable.Checked;

                    eocPropertyBean.Business_ProductProfile_General_DeliveryArea = ddlDeliveryArea.SelectedValue;

                    if (chkCod.Checked && ddlDeliveryArea.SelectedValue == "Outside of Bangladesh")
                    {
                        eocPropertyBean.Business_ProductProfile_SellerForeignAddress = txtSellerForeignAddress.Text;
                    }
                    else
                    {
                        eocPropertyBean.Business_ProductProfile_SellerForeignAddress = "";
                    }

                    if (string.IsNullOrEmpty(ImagePath))
                    {
                        eocPropertyBean.Business_ProductProfile_Books_ProductImage = @"Classifieds_ProductImage/default.png";
                    }
                    else
                    {
                        eocPropertyBean.Business_ProductProfile_Books_ProductImage = ImagePath;
                    }

                    eocPropertyBean.Business_ProductProfile_Books_PaperBackForBook = ddlType.SelectedValue;
                    eocPropertyBean.Business_Product_Profile_Books_Language = txtLanguageMovie.Text;
                    eocPropertyBean.Business_Product_Profile_Books_DimensionForBook = txtDuration.Text;
                    eocPropertyBean.Business_Product_Profile_Books_ShippingWeight = txtShWeightMovie.Text;

                    eocPropertyBean.Business_ProductProfile_Books_Edition = txtEditionMovie.Text;
                    eocPropertyBean.Business_ProductProfile_Books_Author = txtAuthorMovie.Text;
                    eocPropertyBean.Business_ProductProfile_Books_Publisher = txtPublisherMovie.Text;
                    eocPropertyBean.UserType = ClassifiedSeller;

                    eocPropertyBean.UpdatedOn = DateTime.Now;
                    eocPropertyBean.Business_ProductProfile_IsActive = chkMovieDvdIsActive.Checked;
                    eocPropertyBean.Source = rblBoromela.Checked ? "ApnerDeal.com" : txtNewspaper.Text;
                    eocPropertyBean.Is_Alternative_Address = chkIsDisplayAddress.Checked;

                    intActionResult = bocProductProfile.Insert_MasterRecord_MovieDvdProduct(eocPropertyBean);

                }
            }
            catch (Exception Exp)
            {
                lblSystemMessage.Text = Exp.Message.ToString();
            }
        }
        else
        {
            return -2;
        }
        return intActionResult;
    }


    /// <summary>
    /// Select All Product Of MovieDvdGame
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>

    private void SelectRecord_MovieDvd()
    {

        try
        {
            using (BC_MovieDvd objMovieDvd = new BC_MovieDvd())
            {
                DataTable dtMovieDvd = objMovieDvd.LoadRecord_CL_SpecificMovieDvd(ProductID, ProfileID, CategoryID, SubCategoryID, SecondSubcatID);

                if (dtMovieDvd.Rows.Count > 0)
                {
                    txtQuantity.Text = dtMovieDvd.Rows[0]["Qty"].ToString();

                    ddlCurrency.SelectedItem.Text = dtMovieDvd.Rows[0]["Currency"].ToString();
                    txtDescription.Text = dtMovieDvd.Rows[0]["ProductDesc"].ToString();
                    ddlCondition.SelectedValue = dtMovieDvd.Rows[0]["Condition"].ToString();
                    txtConditionNote.Text = dtMovieDvd.Rows[0]["ConditionNote"].ToString();
                    //txtProductYear.Text = dtMovieDvd.Rows[0]["ProductYear"].ToString();

                    chkNegotiable.Checked = Convert.ToBoolean(dtMovieDvd.Rows[0]["IsNegotiable"].ToString());
                    Sku = dtMovieDvd.Rows[0]["SKU"].ToString();

                    
                    if (chkNegotiable.Checked)
                    {
                        txtProductPrice.Enabled = false;
                        txtProductPrice.Text = "0";
                    }
                    else
                    {
                        txtProductPrice.Enabled = true;
                        txtProductPrice.Text = dtMovieDvd.Rows[0]["Price"].ToString();
                    }

                    if (dtMovieDvd.Rows[0]["IsActive"] != null)
                    {
                        chkMovieDvdIsActive.Checked = Convert.ToBoolean(dtMovieDvd.Rows[0]["IsActive"]);
                    }
                    ddlType.Text = dtMovieDvd.Rows[0]["MovieType"].ToString();
                    txtLanguageMovie.Text = dtMovieDvd.Rows[0]["Language"].ToString();
                    txtDuration.Text = dtMovieDvd.Rows[0]["Duration"].ToString();
                    txtShWeightMovie.Text = dtMovieDvd.Rows[0]["ShippingWeight"].ToString();
                    txtEditionMovie.Text = dtMovieDvd.Rows[0]["Edition"].ToString();
                    txtAuthorMovie.Text = dtMovieDvd.Rows[0]["Author"].ToString();
                    txtPublisherMovie.Text = dtMovieDvd.Rows[0]["Publisher"].ToString();
                    if (dtMovieDvd.Rows[0]["CanEditProduct"] != null)
                    {
                        CanEdit = Convert.ToInt32(dtMovieDvd.Rows[0]["CanEditProduct"]);
                    }

                    if (object.Equals(dtMovieDvd.Rows[0]["ProfileID"], dtMovieDvd.Rows[0]["CanEditProduct"]))
                    {
                        this.Block_MasterField(false);
                    }
                    else
                    {
                        this.Block_MasterField(true);
                    }
                    #region SOURCE SELECTION

                    if (dtMovieDvd.Rows[0]["Source"].ToString() == "ApnerDeal.com")
                    {
                        rblBoromela.Checked = true;
                        rblNewspaper.Checked = false;
                    }
                    else
                    {
                        rblBoromela.Checked = false;
                        rblNewspaper.Checked = true;
                        txtNewspaper.Text = dtMovieDvd.Rows[0]["Source"].ToString();
                    }
                    chkIsDisplayAddress.Checked = Convert.ToBoolean(dtMovieDvd.Rows[0]["IsAlternativeAddress"]);

                    #endregion SOURCE SELECTION
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
                    strSystemMessage += "<li>Your Ad may be deleted by ApnerDeal authority for some reason.</li>";
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


    /// <summary>
    /// Selects Author, Publisher name from Product_Master_MovieDvdGame table.
    /// </summary>
    /// <param name="categoryID"></param>
    /// <param name="subcategoryID"></param>
    /// <param name="secondSubcatID"></param>
    /// <param name="profileID"></param>
    /// <param name="productID"></param>
    private void Select_MasterMovieDvdGameRecord(int categoryID, int subcategoryID, int secondSubcatID, int profileID, int productID)
    {
        DataTable dt = new DataTable();
        try
        {
            using (BC_Product bcProduct = new BC_Product())
            {
                dt = bcProduct.SelectSpecific_MasterMovieDvdGameRecord(categoryID, subcategoryID, secondSubcatID, productID);
                if (dt.Rows.Count > 0)
                {
                    txtAuthorMovie.Text = dt.Rows[0]["Author"].ToString();
                    txtPublisherMovie.Text = dt.Rows[0]["Publisher"].ToString();
                    txtEditionMovie.Text = dt.Rows[0]["Edition"].ToString();
                }
            }
        }
        catch (Exception ex)
        {
            lblSystemMessage.Text = ex.Message;
        }
    }


    /// <summary>
    /// Inserts a new row for Book in Product_Seller_Detail table.
    /// </summary>
    private int Add_DetailRecord_MovieDvdProduct()
    {
        //int intActionResult = 0;
        if (!Is_Seller_Tagged_Once(ProductID, ProfileID, SellerType, CategoryID))
        {
            try
            {
                using (BOC_Corporate_MovieDvdMusic bocProductProfile = new BOC_Corporate_MovieDvdMusic())
                {
                    EOC_PropertyBean eocPropertyBean = new EOC_PropertyBean();

                    eocPropertyBean.Business_UserProfile_ProfileID = ProfileID;
                    eocPropertyBean.Business_ProductProfile_Books_ProductID = ProductID;
                    eocPropertyBean.Business_ProductProfile_Books_SKU = Sku;
                    eocPropertyBean.Business_ProductProfile_Description = txtDescription.Text;

                    eocPropertyBean.Business_ProductProfile_Quantity = Convert.ToInt32(txtQuantity.Text);
                    eocPropertyBean.Business_ProductProfile_Books_Currency = ddlCurrency.SelectedValue;
                    eocPropertyBean.Business_ProductProfile_Books_ProductPrice = Convert.ToDouble(txtProductPrice.Text);
                    eocPropertyBean.IsNegotiable = chkNegotiable.Checked;


                    eocPropertyBean.Business_ProductProfile_Books_SalePrice = 0.00;
                    eocPropertyBean.Business_ProductProfile_Books_StartDate = DateTime.Now;
                    eocPropertyBean.Business_ProductProfile_Books_EndDate = DateTime.Now;
                    eocPropertyBean.Business_Product_Profile_Books_Condition = ddlCondition.SelectedValue;

                    eocPropertyBean.Business_Product_Profile_Books_ConditionNote = txtConditionNote.Text;
                    eocPropertyBean.Business_ProductProfile_CashOnDelivery = chkCod.Checked;
                    eocPropertyBean.Business_ProductProfile_PickFromStore = chkPfs.Checked;
                    eocPropertyBean.Business_ProductProfile_CashDeposit = chkCash.Checked;

                    eocPropertyBean.Business_ProductProfile_General_DeliveryArea = ddlDeliveryArea.SelectedItem.Text;

                    if (chkCod.Checked && ddlDeliveryArea.SelectedValue == "Outside of Bangladesh")
                    {
                        eocPropertyBean.Business_ProductProfile_SellerForeignAddress = txtSellerForeignAddress.Text;
                    }
                    else
                    {
                        eocPropertyBean.Business_ProductProfile_SellerForeignAddress = "";
                    }


                    eocPropertyBean.Business_ProductProfile_Books_PaperBackForBook = ddlType.SelectedValue;
                    eocPropertyBean.Business_Product_Profile_Books_Language = txtLanguageMovie.Text;
                    eocPropertyBean.Business_Product_Profile_Books_DimensionForBook = txtDuration.Text;
                    eocPropertyBean.Business_Product_Profile_Books_ShippingWeight = txtShWeightMovie.Text;


                    eocPropertyBean.UserType = ClassifiedSeller;
                    eocPropertyBean.UpdatedOn = DateTime.Now;
                    eocPropertyBean.Business_ProductProfile_IsActive = chkBookIsActive.Checked;
                    eocPropertyBean.Source = rblBoromela.Checked ? "ApnerDeal.com" : txtNewspaper.Text;

                    eocPropertyBean.Is_Alternative_Address = chkIsDisplayAddress.Checked;

                    intActionResult = bocProductProfile.Insert_DetailRecord_MovieDvdProduct(eocPropertyBean);

                }
            }
            catch (Exception Exp)
            {
                lblSystemMessage.Text = Exp.Message.ToString();
            }
        }
        else
        {

            return -2;
        }
        return intActionResult;
    }

    /// <summary>
    /// Updates MovieDvdGame Record of the Master Seller.
    /// </summary>
    /// <returns></returns>
    private int Update_MasterSeller_MovieDvdRecord()
    {
        try
        {
            using (BOC_Corporate_MovieDvdMusic bocProductProfile = new BOC_Corporate_MovieDvdMusic())
            {
                EOC_PropertyBean eocPropertyBean = new EOC_PropertyBean();

                eocPropertyBean.Business_UserProfile_ProfileID = ProfileID;
                eocPropertyBean.Business_ProductProfile_Books_ProductID = ProductID;
                eocPropertyBean.Category_CategoryID = CategoryID;

                eocPropertyBean.Subcategory_SubcategoryID = SubCategoryID;
                eocPropertyBean.SecondSubcategory_SubcategoryID = SecondSubcatID;
                eocPropertyBean.Business_ProductProfile_Description = txtDescription.Text;


                eocPropertyBean.Business_ProductProfile_Quantity = Convert.ToInt32(txtQuantity.Text);
                eocPropertyBean.Business_ProductProfile_Books_Currency = ddlCurrency.SelectedValue;
                eocPropertyBean.Business_ProductProfile_Books_ProductPrice = Convert.ToDouble(txtProductPrice.Text);

                eocPropertyBean.IsNegotiable = chkNegotiable.Checked;
                eocPropertyBean.Business_ProductProfile_Books_SalePrice = 0.00;
                eocPropertyBean.Business_ProductProfile_Books_StartDate = DateTime.Now;

                eocPropertyBean.Business_ProductProfile_Books_EndDate = DateTime.Now;
                eocPropertyBean.Business_Product_Profile_Books_Condition = ddlCondition.SelectedValue;
                eocPropertyBean.Business_Product_Profile_Books_ConditionNote = txtConditionNote.Text;

                //eocPropertyBean.Business_ProductProfile_Books_PaymentOption = ddlPaymentOption.SelectedValue;
                eocPropertyBean.Business_ProductProfile_CashOnDelivery = chkCod.Checked;
                eocPropertyBean.Business_ProductProfile_PickFromStore = chkPfs.Checked;

                eocPropertyBean.Business_ProductProfile_CashDeposit = chkCash.Checked;
                eocPropertyBean.Business_ProductProfile_General_DeliveryArea = ddlDeliveryArea.SelectedValue;
                if (chkCod.Checked && ddlDeliveryArea.SelectedValue == "Outside of Bangladesh")
                {
                    eocPropertyBean.Business_ProductProfile_SellerForeignAddress = txtSellerForeignAddress.Text;
                }
                else
                {
                    eocPropertyBean.Business_ProductProfile_SellerForeignAddress = "";
                }


                if (string.IsNullOrEmpty(ImagePath))
                {
                    eocPropertyBean.Business_ProductProfile_Books_ProductImage = @"Classifieds_ProductImage/default.png";
                }
                else
                {
                    eocPropertyBean.Business_ProductProfile_Books_ProductImage = ImagePath;
                }

                eocPropertyBean.Business_ProductProfile_Books_PaperBackForBook = ddlType.SelectedValue;
                eocPropertyBean.Business_Product_Profile_Books_Language = txtLanguageMovie.Text;
                eocPropertyBean.Business_Product_Profile_Books_DimensionForBook = txtDuration.Text;
                eocPropertyBean.Business_Product_Profile_Books_ShippingWeight = txtShWeightMovie.Text;


                eocPropertyBean.Business_ProductProfile_Books_Author = txtAuthorMovie.Text;
                eocPropertyBean.Business_ProductProfile_Books_Publisher = txtPublisherMovie.Text;
                eocPropertyBean.Business_ProductProfile_Books_Edition = txtEditionMovie.Text;
                eocPropertyBean.UpdatedOn = DateTime.Now;
                eocPropertyBean.Business_ProductProfile_IsActive = chkMovieDvdIsActive.Checked;
                eocPropertyBean.UserType = ClassifiedSeller;

                eocPropertyBean.Source = rblBoromela.Checked ? "ApnerDeal.com" : txtNewspaper.Text;
                eocPropertyBean.Is_Alternative_Address = chkIsDisplayAddress.Checked;

                intActionResult = bocProductProfile.Update_MasterSeller_MovieDvdProduct(eocPropertyBean);

            }
        }
        catch (Exception Exp)
        {
            lblSystemMessage.Text = Exp.Message.ToString();
        }

        return intActionResult;
    }

    /// <summary>
    /// Updates MovieDvd Record of the Tag Seller.
    /// </summary>
    /// <returns></returns>
    private int Update_TagSeller_MovieDvdRecord()
    {
        int intActionResult = 0;

        try
        {
            using (BOC_Corporate_MovieDvdMusic bocProductProfile = new BOC_Corporate_MovieDvdMusic())
            {
                EOC_PropertyBean eocPropertyBean = new EOC_PropertyBean();
                eocPropertyBean.Business_UserProfile_ProfileID = ProfileID;
                eocPropertyBean.Business_ProductProfile_Books_ProductID = ProductID;

                eocPropertyBean.Business_ProductProfile_Description = txtDescription.Text;
                eocPropertyBean.Business_ProductProfile_Quantity = Convert.ToInt32(txtQuantity.Text);
                eocPropertyBean.Business_ProductProfile_Books_Currency = ddlCurrency.SelectedValue;
                eocPropertyBean.Business_ProductProfile_Books_ProductPrice = Convert.ToDouble(txtProductPrice.Text);


                eocPropertyBean.Business_ProductProfile_Books_SalePrice = 0.00;
                eocPropertyBean.Business_ProductProfile_Books_StartDate = DateTime.Now;
                eocPropertyBean.Business_ProductProfile_Books_EndDate = DateTime.Now;


                eocPropertyBean.Business_Product_Profile_Books_Condition = ddlCondition.SelectedValue;
                eocPropertyBean.Business_Product_Profile_Books_ConditionNote = txtConditionNote.Text;

                eocPropertyBean.Business_ProductProfile_CashOnDelivery = chkCod.Checked;
                eocPropertyBean.Business_ProductProfile_PickFromStore = chkPfs.Checked;
                eocPropertyBean.Business_ProductProfile_CashDeposit = chkCash.Checked;
                eocPropertyBean.Business_ProductProfile_General_DeliveryArea = ddlDeliveryArea.SelectedValue;

                if (chkCod.Checked && ddlDeliveryArea.SelectedValue == "Outside of Bangladesh")
                {
                    eocPropertyBean.Business_ProductProfile_SellerForeignAddress = txtSellerForeignAddress.Text;
                }
                else
                {
                    eocPropertyBean.Business_ProductProfile_SellerForeignAddress = "";
                }


                eocPropertyBean.Business_ProductProfile_Books_PaperBackForBook = ddlType.SelectedValue;
                eocPropertyBean.Business_Product_Profile_Books_Language = txtLanguageMovie.Text;
                eocPropertyBean.Business_Product_Profile_Books_DimensionForBook = txtDuration.Text;
                eocPropertyBean.Business_Product_Profile_Books_ShippingWeight = txtShWeightMovie.Text;


                eocPropertyBean.UserType = ClassifiedSeller;
                eocPropertyBean.UpdatedOn = DateTime.Now;
                eocPropertyBean.IsNegotiable = chkNegotiable.Checked;
                eocPropertyBean.Business_ProductProfile_IsActive = chkMovieDvdIsActive.Checked;

                eocPropertyBean.Source = rblBoromela.Checked ? "ApnerDeal.com" : txtNewspaper.Text;
                eocPropertyBean.Is_Alternative_Address = chkIsDisplayAddress.Checked;

                intActionResult = bocProductProfile.Update_TagSeller_MovieDvdRecord(eocPropertyBean);
            }
        }
        catch (Exception Exp)
        {
            lblSystemMessage.Text = Exp.Message.ToString();
        }

        return intActionResult;

    }

    #endregion FOR MovieDvdGame

    #region BUTTON CLICK MOVIEMUSICGAME

    protected void btnMovieSubmit_Click(object sender, EventArgs e)
    {
        if (PageMode == 0)
        {
            if (PageMode == 0 && InsertType == "master")
            {
                intActionResult = this.Add_MasterRecord_MovieDvdGameProduct();

            }
            else if (PageMode == 0 && InsertType == "tag")
            {
                intActionResult = this.Add_DetailRecord_MovieDvdProduct();
            }
            else
            {
                lblSystemMessage.Text = "Parameter missing.";
            }

        }
        if (PageMode == 1 && ProductID > 0)
        {
            if (CanEdit == ProfileID)
            {
                intActionResult = this.Update_MasterSeller_MovieDvdRecord();
            }
            else
            {
                intActionResult = this.Update_TagSeller_MovieDvdRecord();
            }

        }
        if (intActionResult > 0)
        {
            MultiView1.ActiveViewIndex = 7;
        }
        else if (intActionResult == -2)
        {
            lblSystemMessage.Text = UTLUtilities.ShowErrorMessage("You have already added this product");
        }
        else
        {
            lblSystemMessage.Text = UTLUtilities.ShowErrorMessage("Error occured while saving record.");
        }
    }

    protected void btnBackFromMovie_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }

    #endregion BUTTON CLICK MOVIEMUSICGAME



    #region BUTTONCLICK_ELECTRONICS

    protected void btnElectronicsSubmit_Click(object sender, EventArgs e)
    {
        if (PageMode == 0)
        {
            if (PageMode == 0 && InsertType == "master")
            {
                intActionResult = this.Add_MasterRecord_Electronics();
            }
            else if (PageMode == 0 && InsertType == "tag")
            {
                intActionResult = this.Add_DetailRecord_Electronics();
            }
            else
            {
                lblSystemMessage.Text = UTLUtilities.ShowGeneralMessage("Parameter missing.");
            }

        }
        if (PageMode == 1 && ProductID > 0)
        {
            if (CanEdit == ProfileID)
            {
                intActionResult = this.Update_MasterSeller_Electronics();
            }
            else
            {
                intActionResult = this.Update_TagSeller_Electronics();
            }

        }
        if (intActionResult > 0)
        {
            MultiView1.ActiveViewIndex = 7;
        }
        else if (intActionResult == -2)
        {
            lblSystemMessage.Text = UTLUtilities.ShowErrorMessage("You have already added this product");
        }
        else
        {
            lblSystemMessage.Text = UTLUtilities.ShowErrorMessage("Error occured while saving record.");
        }
    }


    protected void btnBack_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }

    #endregion BUTTONCLICK_ELECTRONICS

    #region BUTTON CLICK EVENTS



    protected void btnBookSubmit_Click(object sender, EventArgs e)
    {
        //int intActionResult = -1;
        if (PageMode == 0)
        {
            if (PageMode == 0 && InsertType == "master")
            {
                intActionResult = this.Add_MasterRecord_BookProduct();

            }
            else if (PageMode == 0 && InsertType == "tag")
            {
                intActionResult = this.Add_DetailRecord_BookProduct();
            }
            else
            {
                lblSystemMessage.Text = "Parameter missing.";
            }

        }
        if (PageMode == 1 && ProductID > 0)
        {
            if (CanEdit == ProfileID)
            {
                intActionResult = this.Update_MasterSeller_BookRecord();
            }
            else
            {
                intActionResult = this.Update_TagSeller_BookRecord();
            }

        }
        if (intActionResult > 0)
        {
            MultiView1.ActiveViewIndex = 7;
        }
        else if (intActionResult == -2)
        {
            lblSystemMessage.Text = UTLUtilities.ShowErrorMessage("You have already added this product");
        }
        else
        {
            lblSystemMessage.Text = UTLUtilities.ShowErrorMessage("Error occured while saving record.");
        }
    }


    protected void btnComputerSubmit_Click(object sender, EventArgs e)
    {
        if (PageMode == 0)
        {
            if (PageMode == 0 && InsertType == "master")
            {
                intActionResult = this.Add_MasterRecord_Computer();

            }
            else if (PageMode == 0 && InsertType == "tag")
            {
                intActionResult = this.Add_DetailRecord_Computer();
            }
            else
            {
                lblSystemMessage.Text = UTLUtilities.ShowGeneralMessage("Parameter missing.");
            }

        }
        if (PageMode == 1 && ProductID > 0)
        {
            if (CanEdit == ProfileID)
            {
                intActionResult = this.Update_MasterSeller_Computer();
            }
            else
            {
                intActionResult = this.Update_TagSeller_Computer();
            }

        }
        if (intActionResult > 0)
        {
            MultiView1.ActiveViewIndex = 7;
        }
        else if (intActionResult == -2)
        {
            lblSystemMessage.Text = UTLUtilities.ShowErrorMessage("You have already added this product");
        }
        else
        {
            lblSystemMessage.Text = UTLUtilities.ShowErrorMessage("Error occured while saving record.");
        }
    }


    protected void btnMobileSubmit_Click(object sender, EventArgs e)
    {
        if (PageMode == 0)
        {
            if (PageMode == 0 && InsertType == "master")
            {
                intActionResult = this.Add_MasterRecord_Mobile();

            }
            else if (PageMode == 0 && InsertType == "tag")
            {
                intActionResult = this.Add_DetailRecord_Mobile();
            }
            else
            {
                lblSystemMessage.Text = UTLUtilities.ShowGeneralMessage("Parameter missing.");
            }

        }
        if (PageMode == 1 && ProductID > 0)
        {
            if (CanEdit == ProfileID)
            {
                intActionResult = this.Update_MasterSeller_Mobile();
            }
            else
            {
                intActionResult = this.Update_TagSeller_Mobile();
            }

        }
        if (intActionResult > 0)
        {
            MultiView1.ActiveViewIndex = 7;
            //Response.Redirect("ControlPanel.aspx", false);
        }
        else if (intActionResult == -2)
        {
            lblSystemMessage.Text = UTLUtilities.ShowErrorMessage("You have already added this product");
        }
        else
        {
            lblSystemMessage.Text = UTLUtilities.ShowErrorMessage("Error occured while saving record.");
        }

    }

    protected void btnAutoSubmit_Click(object sender, EventArgs e)
    {
        if (PageMode == 0)
        {
            if (PageMode == 0 && InsertType == "master")
            {
                intActionResult = this.Add_MasterRecord_Automobile();

            }
            else if (PageMode == 0 && InsertType == "tag")
            {
                intActionResult = this.Add_DetailRecord_Automobile();
            }
            else
            {
                lblSystemMessage.Text = UTLUtilities.ShowGeneralMessage("Parameter missing.");
            }

        }
        if (PageMode == 1 && ProductID > 0)
        {
            if (CanEdit == ProfileID)
            {
                intActionResult = this.Update_MasterSeller_Automobile();
            }
            else
            {
                intActionResult = this.Update_TagSeller_Automobile();
            }

        }
        if (intActionResult > 0)
        {
            MultiView1.ActiveViewIndex = 7;
        }
        else if (intActionResult == -2)
        {
            lblSystemMessage.Text = UTLUtilities.ShowErrorMessage("You have already added this product");
        }
        else
        {
            lblSystemMessage.Text = UTLUtilities.ShowErrorMessage("Error occured while saving record.");
        }

    }



    protected void btnBackFromBook_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }



    protected void btnNextPage_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            if (CategoryID == 1) // Book
            {
                MultiView1.ActiveViewIndex = 1;
            }
            else if (CategoryID == 2) //Mobile
            {
                MultiView1.ActiveViewIndex = 4;
            }
            else if (CategoryID == 3) // Car Motor
            {
                MultiView1.ActiveViewIndex = 2;
            }
            else if (CategoryID == 4) // Computer Laptop
            {
                MultiView1.ActiveViewIndex = 3;
            }
            else if (CategoryID == 6) // Electronics
            {
                MultiView1.ActiveViewIndex = 5;
            }
            else if (CategoryID == 8) // MovieMusic
            {
                MultiView1.ActiveViewIndex = 8;
            }
            else
            {
                MultiView1.ActiveViewIndex = 4;
            }
        }
    }



    protected void btnUpload_Click(object sender, EventArgs e)
    {
        btnUpload.Enabled = false;
        //CategoryID = Convert.ToInt32(txtCategoryID.Text);
        string _CategoryWiseFolder = "";
        if (CategoryID == 1)
        {
            _CategoryWiseFolder = "books";
        }
        else if (CategoryID == 2)
        {
            _CategoryWiseFolder = "mobiles";
        }
        else if (CategoryID == 3)
        {
            _CategoryWiseFolder = "cars";
        }
        else if (CategoryID == 4)
        {
            _CategoryWiseFolder = "computers";
        }
        else if (CategoryID == 6)
        {
            _CategoryWiseFolder = "electronics";
        }
        else if (CategoryID == 8)
        {
            _CategoryWiseFolder = "moviedvd";
        }


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

                FileUpload1.SaveAs(Server.MapPath(@"../Prdcts/" + _CategoryWiseFolder + "/_" + ProfileID.ToString() + "_CL_" + strFileName + "_" + fileName));
                ImagePath = @"../Prdcts/" + _CategoryWiseFolder + "/_" + ProfileID.ToString() + "_CL_" + strFileName + "_" + fileName;


                if (PageMode == 0)
                {
                    Page.RegisterStartupScript("Validation", "<script language=\"javascript\">window.alert(\"Image uploaded.\");</script>");
                    lblImageUploadMessage.Text = "Image uploaded.";
                }

                if (PageMode == 1 && ProductID > 0)
                {
                    if (this.UpdateImage(ProductID, CategoryID, ImagePath))
                    {
                        Page.RegisterStartupScript("Validation", "<script language=\"javascript\">window.alert(\"Image uploaded.\");</script>");
                        lblImageUploadMessage.Text = "Image uploaded.";
                    }
                    else
                    {
                        Page.RegisterStartupScript("Validation", "<script language=\"javascript\">window.alert(\"Error occured while uploading image.\");</script>");
                        lblImageUploadMessage.Text = "Error occured while uploading image.";
                    }
                }
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

    /// <summary>
    /// Server Validation Methods
    /// </summary>
    /// <param name="source"></param>
    /// <param name="args"></param>
    #region Validation Events Handlers


    protected void csvQuantity_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (txtQuantity.Text == "")
        {
            args.IsValid = false;
        }
        else
        {
            args.IsValid = true;
        }
    }
    protected void csvProductPrice_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (txtProductPrice.Text == "")
        {
            args.IsValid = false;
        }
        else
        {
            args.IsValid = true;
        }

    }

    protected void csvSellerForeignAddress_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (txtSellerForeignAddress.Text == "")
        {
            args.IsValid = false;
        }
        else
        {
            args.IsValid = true;
        }
    }


    protected void csvPaperBack_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (txtPaperBack.Text == "")
        {
            args.IsValid = false;
        }
        else
        {
            args.IsValid = true;
        }
    }
    protected void csvLanguage_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (txtLanguage.Text == "")
        {
            args.IsValid = false;
        }
        else
        {
            args.IsValid = true;
        }
    }
    protected void csvEdition_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (txtEdition.Text == "")
        {
            args.IsValid = false;
        }
        else
        {
            args.IsValid = true;
        }
    }
    protected void csvIsbn_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (txtISBN.Text == "")
        {
            args.IsValid = false;
        }
        else
        {
            args.IsValid = true;
        }
    }
    protected void csvAuthor_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (txtAuthor.Text == "")
        {
            args.IsValid = false;
        }
        else
        {
            args.IsValid = true;
        }
    }
    protected void csvPublisher_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (txtPublisher.Text == "")
        {
            args.IsValid = false;
        }
        else
        {
            args.IsValid = true;
        }
    }

    protected void csvPayment_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (chkCod.Checked || chkPfs.Checked || chkCash.Checked)
        {
            args.IsValid = true;
        }
        else
        {
            args.IsValid = false;
        }
    }

    protected void csvCarSubModel_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (txtCarSubModel.Text == "")
        {
            args.IsValid = false;
        }
        else
        {
            args.IsValid = true;
        }
    }


    #region SERVER VALIDATION FOR MOVIE DVD GAMES

    protected void csvTypeValidator_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (ddlType.SelectedValue == "-1")
        {
            args.IsValid = false;
        }
        else
        {
            args.IsValid = true;
        }

    }
    protected void csvLanguageCheck_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (txtLanguageMovie.Text == "")
        {
            args.IsValid = false;
        }
        else
        {
            args.IsValid = true;
        }
    }
    protected void csvDuration_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (txtDuration.Text == "")
        {
            args.IsValid = false;
        }
        else
        {
            args.IsValid = true;
        }
    }
    protected void csvShippingWeight_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (txtShWeightMovie.Text == "")
        {
            args.IsValid = false;
        }
        else
        {
            args.IsValid = true;
        }
    }

    protected void csvEditionMovie_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (txtEditionMovie.Text == "")
        {
            args.IsValid = false;
        }
        else
        {
            args.IsValid = true;
        }
    }

    protected void csvAuthorMovie_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (txtAuthorMovie.Text == "")
        {
            args.IsValid = false;
        }
        else
        {
            args.IsValid = true;
        }
    }
    protected void csvPublisherMovie_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (txtPublisherMovie.Text == "")
        {
            args.IsValid = false;
        }
        else
        {
            args.IsValid = true;
        }
    }
    #endregion SERVER VALIDATION FOR MOVIE DVD GAMES


    #endregion Validation Events Handlers

    #region DUPLICATION CHECKING


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


    /// <summary>
    /// Returns true if Master seller's given product title already exists.
    /// </summary>
    private bool Check_IsMasterProductDuplicate(int _CategoryID, int _SubcategoryID, int _SecondSubcatID, string _ProductTitle)
    {
        bool blnFlag = true;
        try
        {
            using (BC_Product bcProduct = new BC_Product())
            {
                if (_CategoryID != 1)
                {
                    blnFlag = bcProduct.IsMaster_OtherTitle_Dupllicate(_CategoryID, _SubcategoryID, _SecondSubcatID, ProductModelID, _ProductTitle);
                }
                else
                {
                    blnFlag = bcProduct.IsMaster_ProductTitle_Dupllicate(_CategoryID, _SubcategoryID, _SecondSubcatID, _ProductTitle);
                }

            }
        }
        catch (Exception ex)
        {
            lblSystemMessage.Text = ex.Message;
        }
        return blnFlag;
    }

    #endregion DUPLICATION CHECKING

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

