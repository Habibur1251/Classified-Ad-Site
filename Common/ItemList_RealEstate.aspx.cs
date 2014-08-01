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

public partial class Common_ItemList_RealEstate : System.Web.UI.Page
{
    #region Common Property

    protected DataTable dtRealState = null;

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
    
    int intPageMode = -1;
   
    private string strHtml = string.Empty;
    private string strCID = string.Empty;
    private string strSCID = string.Empty;
    private string strSSCID = string.Empty;
    private string category = string.Empty;
    private string subcategory = string.Empty;

    //private string selectedLocation = string.Empty;  
    //private string location = string.Empty;
    //private string customMessage = string.Empty;
    //private string strPageMode = string.Empty;


    private int intCountryID = -1;
    private string strPageMode = string.Empty;
    //private int intSecondSubcatID = -1;

    protected int ProfileID
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

    protected int CategoryID
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


    protected int SubcategoryID
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

    protected int SecondSubcatID
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


    protected int ProvinceID
    {
        get
        {
            object obj = ViewState["ProvinceID"];
            if (obj != null)
            {
                return (int)obj;
            }
            return 0;
        }

        set { ViewState["ProvinceID"] = value; }
    }

    protected int AreaID
    {
        get
        {
            object obj = ViewState["AreaID"];
            if (obj != null)
            {
                return (int)obj;
            }
            return 0;
        }

        set { ViewState["AreaID"] = value; }
    }


    protected string Location
    {
        get
        {
            object obj = ViewState["Location"];
            if (obj != null)
            {
                return (string)obj;
            }
            return "";
        }

        set { ViewState["Location"] = value; }
    }

    public int CountryID
    {
        get { return intCountryID; }
        set { intCountryID = value; }
    }

    public string Category
    {
        get { return this.category; }
        set { this.category = value; }
    }

    //public string SubcategoryID
    //{
    //    get { return this.strSCID; }
    //    set { this.strSCID = value; }
    //}

    public string Subcategory
    {
        get
        {
            string strSubcategory = string.Empty;
            switch (SubcategoryID)
            {
                case 54:
                    {
                        strSubcategory = "For Sale";
                        break;
                    }
                case 55:
                    {
                        strSubcategory = "For Rent";
                        break;
                    }
            }
            return strSubcategory;
        }

    }


    public enum FilterType
    {
        BySubcategory,
        BySecondSubcategory,
        ByBsSeller,
        ByProvince,
        ByClSeller,
        ByInsideDhaka,
        ByOutSideDhaka
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
            return FilterType.BySubcategory;

        }
        set
        {
            ViewState["Filter"] = value;
        }
    }

    #endregion Common Property

    #region GENERAL METHODS
    /// <summary>
    /// Initializes the gridview with the parameter datatable.
    /// </summary>
    /// <param name="dt"></param>
    private void InitializeGridView(DataTable dt, GridView grv)
    {
        //this.Category = dt.Rows[0]["Category"].ToString();
        //this.Subcategory = dt.Rows[0]["Subcategory"].ToString();
        //this.Location = dt.Rows[0]["Country"].ToString();
        grv.DataSource = dt;
        grv.DataBind();
        if (dt == null)
        {
            Total_Record = 0;
            lblSystemMessage.Text = "No items found.";
        }
        else
        {
            Total_Record = dt.Rows.Count;
        }
    }

    #endregion GENERAL METHODS

    #region CHECKQUERYSTRING METHOD
    /// <summary>
    /// Checks the query string and returns the pagemode.
    /// </summary>
    /// <returns></returns>
    private string CheckQueryString()
    {
             
            object objPageMode = Request.QueryString["PageMode"];
            object objCID = Request.QueryString["CID"];
            object objSCID = Request.QueryString["SCID"];
            
            Location = Request.QueryString["Location"];

            if (objPageMode != null && objCID != null && objSCID != null && Location != null)
            {

                CategoryID = Convert.ToInt32(objCID);
                SubcategoryID = Convert.ToInt32(objSCID);
            }
            else
            {
                Response.Redirect("Default.aspx");
            }

        return objPageMode.ToString();
    }


    #endregion CHECKQUERYSTRING METHOD

    #region PAGE LOAD EVENTS
  
    protected void Page_Load(object sender, EventArgs e)
    {
        strPageMode = this.CheckQueryString();

        

        SecondSubcategory_Ctrl.SubcategoryID = SubcategoryID;
        SecondSubcategory_Ctrl.LinkClicked += new UserControl_RealEstate_SecondSubcategory_List_Ctrl.SecondSubcategory_Clicked(SecondSubcategory_Ctrl_LinkClicked);
        ProvinceCtrl.SubcategoryID = SubcategoryID;
        InsideDhaka_RealEstate_Ctrl1.SubcategoryID = SubcategoryID;
        OutsideDhaka_RealEstate_Ctrl1.SubcategoryID = SubcategoryID;

        ProvinceCtrl.LinkClicked += new UserControl_BS_Province_Ctrl.ProvinceClicked(ProvinceCtrl_LinkClicked);
        InsideDhaka_RealEstate_Ctrl1.LinkClicked += new UserControl_InsideDhaka_RealEstate_Ctrl.AreaClicked(InsideDhaka_RealEstate_Ctrl1_LinkClicked);
        OutsideDhaka_RealEstate_Ctrl1.LinkClicked += new UserControl_OutsideDhaka_RealEstate_Ctrl.ProvinceClicked(OutsideDhaka_RealEstate_Ctrl1_LinkClicked);

        BS_Seller.SubcategoryID = SubcategoryID;
        BS_Seller.LinkClicked += new UserControl_CorporateSellerList.BS_SellerClicked(BS_Seller_LinkClicked);

        CL_Seller_Ctrl.SubcategoryID = SubcategoryID;
        CL_Seller_Ctrl.LinkClicked += new UserControl_ClassifiedSellerList.CL_SellerClicked(CL_Seller_Ctrl_LinkClicked);
        if (!Page.IsPostBack)
        {
            if (strPageMode == "1")
            {
                this.LoadList_RealEstate_CL_SellerProduct(CategoryID, SubcategoryID);
            }
            else
            {
                this.LoadList_RealEstate_BySubcategory(CategoryID, SubcategoryID); 
            }            
        }
    }
    

    #endregion PAGE LOAD EVENTS

    #region USER CONTROL EVENTS


    protected void CL_Seller_Ctrl_LinkClicked(object sender, MenuEventArgs e)
    {
        Filter = FilterType.ByClSeller;
        DisplayFilter.Filter_Name = "Individual Seller";
        SubcategoryID = Convert.ToInt32(e.SubcategoryID);
        this.LoadList_RealEstate_CL_SellerProduct(CategoryID, SubcategoryID);

    }


    protected void BS_Seller_LinkClicked(object sender, MenuEventArgs e)
    {
        Filter = FilterType.ByBsSeller;
        DisplayFilter.Filter_Name = "Specific Seller";
        ProfileID = Convert.ToInt32(e.ProfileID);
        this.LoadList_RealEstate_BS_SellerProduct(CategoryID, SubcategoryID, ProfileID, Location);
    }

    protected void ProvinceCtrl_LinkClicked(object sender, MenuEventArgs args)
    {
        Filter = FilterType.ByProvince;
        DisplayFilter.Filter_Name = "Location";
        ProvinceID = Convert.ToInt32(args.ProvinceID);
        this.LoadList_LatestPosted_RealEstate_ByProvince(CategoryID, SubcategoryID, ProvinceID);
    }

    protected void OutsideDhaka_RealEstate_Ctrl1_LinkClicked(object sender, MenuEventArgs args)
    {
        Filter = FilterType.ByOutSideDhaka;
        DisplayFilter.Filter_Name = "OutsideDhaka";
        ProvinceID = Convert.ToInt32(args.ProvinceID);
        this.LoadList_LatestPosted_RealEstate_ByProvince(CategoryID, SubcategoryID, ProvinceID);
    }

    protected void InsideDhaka_RealEstate_Ctrl1_LinkClicked(object sender, MenuEventArgs args)
    {
        Filter = FilterType.ByInsideDhaka;
        DisplayFilter.Filter_Name = "InsideDhaka";
        AreaID = Convert.ToInt32(args.AreaID);
        this.LoadList_LatestPosted_RealEstate_ByArea_InsideDhaka(CategoryID, SubcategoryID, AreaID);

    }


    protected void SecondSubcategory_Ctrl_LinkClicked(object sender, MenuEventArgs e)
    {
        Filter = FilterType.BySecondSubcategory;
        DisplayFilter.Filter_Name = "Category";
        SecondSubcatID = Convert.ToInt32(e.SecondSubcatID);
        this.LoadList_RealEstate_BySecondSubcategory(Convert.ToInt32(e.SubcategoryID), SecondSubcatID);
    }


    #endregion USER CONTROL EVENTS

    #region LoadMethods

    private void LoadList_RealEstate_BySubcategory(int _CategoryID, int _SubcategoryID)
    {
        RealEstate objRealEstate = new RealEstate();
        RealEstateManager objrealEstatemanager = new RealEstateManager();
        objRealEstate.CategoryID = _CategoryID;
        objRealEstate.SubcategoryID = _SubcategoryID;

        try
        {
            DataTable dt = objrealEstatemanager.Load_List_RealEstate_BySubcategory(objRealEstate);
            if (dt.Rows.Count > 0)
            {
                InitializeGridView(dt, grvRealEstate);
            }
            else
            {
                InitializeGridView(null, grvRealEstate);
            }
        }
        catch (Exception ex)
        {
            lblSystemMessage.Text = ex.Message;
        }
    }

    private void LoadList_RealEstate_BySecondSubcategory(int _SubcategoryID, int _SecondSubcatID)
    {
        RealEstate objRealEstate = new RealEstate();
        RealEstateManager objrealEstatemanager = new RealEstateManager();
        objRealEstate.SubcategoryID = _SubcategoryID;
        objRealEstate.SecondSubcatID = _SecondSubcatID;

        try
        {
            DataTable dt = objrealEstatemanager.LoadList_RealEstate_BySecondSubcateogry(objRealEstate);
            if (dt.Rows.Count > 0)
            {
                InitializeGridView(dt, grvRealEstate);
            }
            else
            {
                InitializeGridView(null, grvRealEstate);
            }
        }
        catch (Exception ex)
        {
            lblSystemMessage.Text = ex.Message;
        }
    }


    /// <summary>
    /// Loads List of Real Estate of Classified Seller by Subcategory.
    /// </summary>
    /// <param name="_CategoryID"></param>
    /// <param name="_SubcategoryID"></param>
    private void LoadList_RealEstate_CL_SellerProduct(int _CategoryID, int _SubcategoryID)
    {
        RealEstate objRealEstate = new RealEstate();
        RealEstateManager objrealEstatemanager = new RealEstateManager();
        objRealEstate.CategoryID = _CategoryID;
        objRealEstate.SubcategoryID = _SubcategoryID;

        try
        {
            DataTable dt = objrealEstatemanager.Load_RealEstate_CLProductList_BySubcategory(objRealEstate);
            if (dt.Rows.Count > 0)
            {
                InitializeGridView(dt, grvRealEstate);
            }
            else
            {
                InitializeGridView(null, grvRealEstate);
            }
        }
        catch (Exception ex)
        {
            lblSystemMessage.Text = ex.Message;
        }
    }


    private void LoadList_RealEstate_BS_SellerProduct(int _CategoryID, int _SubcategoryID, int _ProfileID, string _Country)
    {
        RealEstate objRealEstate = new RealEstate();
        RealEstateManager objrealEstatemanager = new RealEstateManager();
        objRealEstate.CategoryID = _CategoryID;
        objRealEstate.SubcategoryID = _SubcategoryID;
        objRealEstate.ProfileID = _ProfileID;
        objRealEstate.Country = _Country;

        try
        {
            using (BC_CorporateSeller bs_Seller = new BC_CorporateSeller())
            {
                DataTable dt = bs_Seller.LoadSpecific_BS_SellerProduct(_CategoryID, _SubcategoryID, _ProfileID, _Country);
                if (dt.Rows.Count > 0)
                {
                    InitializeGridView(dt, grvRealEstate);
                }
                else
                {
                    InitializeGridView(null, grvRealEstate);
                }
            }
        }
        catch (Exception ex)
        {
            lblSystemMessage.Text = ex.Message;
        }
    }

    /// <summary>
    ///  Generates a list of seller specific  by ProvinceID.
    /// </summary>
    /// <param name="intCategoryID"></param>
    /// <param name="intSubcategoryID"></param>
    /// <param name="intProfileID"></param>
    /// <param name="strCountry"></param>
    private void LoadList_LatestPosted_RealEstate_ByProvince(int intCategoryID, int intSubcategoryID, int intProvinceID)
    {
        try
        {
            using (BC_RealEstate bcRealEstate = new BC_RealEstate())
            {
                RealEstate objRealEstate = new RealEstate();
                objRealEstate.CategoryID = intCategoryID;
                objRealEstate.SubcategoryID = intSubcategoryID;
                objRealEstate.ProvinceID = intProvinceID;

                DataTable dt = bcRealEstate.Load_List_RealEstate_ByProvince(objRealEstate);

                if (dt.Rows.Count > 0)
                {
                    InitializeGridView(dt, grvRealEstate);
                }
                else
                {
                    InitializeGridView(null, grvRealEstate);
                }
            }
        }
        catch (Exception ex)
        {
            lblSystemMessage.Text = ex.Message;
        }
    }


    /// <summary>
    ///  Generates a list of seller specific  by ProvinceID.
    /// </summary>
    /// <param name="intCategoryID"></param>
    /// <param name="intSubcategoryID"></param>
    /// <param name="intProfileID"></param>
    /// <param name="strCountry"></param>
    private void LoadList_LatestPosted_RealEstate_ByArea_InsideDhaka(int intCategoryID, int intSubcategoryID, int intAreaID)
    {
        try
        {
            using (BC_RealEstate bcRealEstate = new BC_RealEstate())
            {
                RealEstate objRealEstate = new RealEstate();
                objRealEstate.CategoryID = intCategoryID;
                objRealEstate.SubcategoryID = intSubcategoryID;
                objRealEstate.AreaID = intAreaID;

                DataTable dt = bcRealEstate.Load_List_RealEstate_ByArea_InsideDhaka(objRealEstate);

                if (dt.Rows.Count > 0)
                {
                    InitializeGridView(dt, grvRealEstate);
                }
                else
                {
                    InitializeGridView(null, grvRealEstate);
                }
            }
        }
        catch (Exception ex)
        {
            lblSystemMessage.Text = ex.Message;
        }
    }

    #endregion LoadMethods

    #region RICH DATA CONTROLS EVENTS
    

    protected void grvRealEstate_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grvRealEstate.PageIndex = e.NewPageIndex;
        if (Filter == FilterType.BySecondSubcategory)
        {
            this.LoadList_RealEstate_BySecondSubcategory(SubcategoryID, SecondSubcatID);
        }
        else if(Filter == FilterType.ByOutSideDhaka)
        {
            this.LoadList_LatestPosted_RealEstate_ByProvince(CategoryID, SubcategoryID, ProvinceID);
        }
        else if (Filter == FilterType.ByInsideDhaka)
        {
            this.LoadList_LatestPosted_RealEstate_ByArea_InsideDhaka(CategoryID, SubcategoryID, AreaID);
        }
        else if (Filter == FilterType.ByBsSeller)
        {
            this.LoadList_RealEstate_BS_SellerProduct(CategoryID, SubcategoryID, ProfileID, Location);
        }
        else if (Filter == FilterType.ByClSeller)
        {
            this.LoadList_RealEstate_CL_SellerProduct(CategoryID, SubcategoryID);
        }
        else
        {
            this.LoadList_RealEstate_BySubcategory(CategoryID, SubcategoryID);
        }
    }


    #endregion RICH DATA CONTROLS EVENTS
    
}
