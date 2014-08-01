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

public partial class Corporate_SelectDiscountType : System.Web.UI.Page
{
    private bool _Business_Seller = true;
    private int intProfileID = -1;
    private int intCountryID = -1;
    private int intCategoryID = -1;

    /// <summary>
    /// Enables or disables a Panel
    /// </summary>
    /// <param name="isEnable">True makes a panel enable and visible, false disables and makes invisible.</param>
    private void Enable_Panel(Panel pnl, bool isEnable)
    {
        pnl.Visible = isEnable;
        pnl.Enabled = isEnable;
    }

    public string GetDiscountType
    {
        get { return DiscountTypeEdit.SelectedValue; }
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

    public string GetCategoryID
    {
        get { return ddlCategory.SelectedValue; }
    }

    public string GetSubCategoryID
    {
        get { return ddlSubcategory.SelectedValue; }
    }
    protected int DiscountType
    {
        get
        {
            object obj = ViewState["DiscountType"];
            if (obj != null)
            {
                return (int)obj;
            }
            return 0;
        }
        set { ViewState["DiscountType"] = value; }
    }

    private bool _IsAdmin;
    public bool IsAdmin
    {
        get { return _IsAdmin; }
        set { _IsAdmin = value; }
    }

    protected String DiscountTypeName
    {
        get
        {
            object obj = ViewState["DiscountTypeName"];
            if (obj != null)
            {
                return obj.ToString();
            }
            return "";
        }
        set { ViewState["DiscountTypeName"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
       UTLUtilities.CP_ActiveModule = 20;
       this.CheckUserSession();
       if (!Page.IsPostBack)
       {
           this.DiscountStoreType();
           this.LoadRecord_Category();
       }
    }

    private void CheckUserSession()
    {
        if (this.Session["CORP_PROFILE_CODE"] != null && this.Session["CORP_COUNTRY_CODE"] != null)
        {
            intCountryID = Convert.ToInt32(this.Session["CORP_COUNTRY_CODE"].ToString());
            IsAdmin = Convert.ToBoolean(this.Session["ISADMIN"]);

            if (IsAdmin.ToString() == "True")
            {
                intProfileID = Convert.ToInt32(this.Session["AdminCompanyProfileID"].ToString());
                ProfileID = Convert.ToInt32(this.Session["AdminCompanyProfileID"].ToString());
            }
            else
            {
                intProfileID = Convert.ToInt32(this.Session["CORP_PROFILE_CODE"].ToString());
                ProfileID = Convert.ToInt32(this.Session["CORP_PROFILE_CODE"].ToString());
            }
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
    }

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
                if (dtCategory.Rows.Count > 0)
                {

                    ddlCategory.DataSource = dtCategory;
                    ddlCategory.DataValueField = "CategoryID";
                    ddlCategory.DataTextField = "Category";
                    ddlCategory.DataBind();
                }
                else
                {
                    lblSystemMessage.Text = "No Category available";
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
                //System.Threading.Thread.Sleep(9999);
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
                    lblSystemMessage.Text = "No Subcategory available";
                }
            }
        }
        catch (Exception Exp)
        {
            lblSystemMessage.Text = Exp.Message.ToString();
        }
    }

    protected void btnChangeCategory_Click(object sender, EventArgs e)
    {

        
    }
    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        intCategoryID = Convert.ToInt32(ddlCategory.SelectedItem.Value);
        if (ddlCategory.SelectedItem.Value.ToString() != "-1")
        {
            this.LoadRecord_Subcategory(intCategoryID);
        }
    }

    protected void btnNextPage_Click(object sender, EventArgs e)
    {
        int intActionStatus = 0;
        if (changeCheckBox.Checked)
        {
            if (Page.IsValid)
            {
                intActionStatus = this.UpdateRecord_DiscountStore();
            }
            else
            {
                //
            }
            if (intActionStatus == 0)
            {
                lblSystemMessage.Text = "Your Discount store type could not be saved.";
            }
            else if (intActionStatus > 0)
            {
                Enable_Panel(panelSaleOffer, false);
                changeCheckBox.Checked = false;
                this.DiscountStoreType();
                string strQueryString = "&mode=0&CI=" + Server.UrlEncode(GetCategoryID);
                strQueryString += "&SUBC=" + Server.UrlEncode(GetSubCategoryID);
                strQueryString += "&DT=" + Server.UrlEncode(DiscountType.ToString());
                Response.Redirect("DiscountProfileAE.aspx?" + strQueryString, false);
            }
        }
        else
        {
            string strQueryString = "&mode=0&CI=" + Server.UrlEncode(GetCategoryID);
            strQueryString += "&SUBC=" + Server.UrlEncode(GetSubCategoryID);
            strQueryString += "&DT=" + Server.UrlEncode(DiscountType.ToString());
            Response.Redirect("DiscountProfileAE.aspx?" + strQueryString, false);
        }

    }

    private void DiscountStoreType()
    {
        int inAction = -1;
         try
        {
            DiscountManegar manager = new DiscountManegar();
            DataTable dt = new DataTable();
            DiscountZone objDiscountZone = new DiscountZone();
            objDiscountZone.ProfileID =intProfileID;
            dt = manager.LoadDiscuntSoreType(objDiscountZone);
            if (dt.Rows.Count > 0)
            {
                DiscountType = Convert.ToInt32(dt.Rows[0]["DiscountStoreType"]);
                if (DiscountType==1)
                {
                    DiscountTypeName = "Premium";
                }
                else if (DiscountType == 2)
                {
                    DiscountTypeName = "Standard";
                }
                else
                {
                    ///
                }
            }
            else
            {
                Response.Redirect("StoreType.aspx");
            }
        }
        catch (Exception ex)
        {
            lblSystemMessage.Text = ex.Message;
        }
    }
    protected void changeCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        if (changeCheckBox.Checked)
        {
            Enable_Panel(panelSaleOffer, true);
            if (DiscountType == 1)
            {
                DiscountTypeEdit.SelectedValue = "1";
            }
            else if (DiscountType == 2)
            {
                DiscountTypeEdit.SelectedValue = "2";
            }
            else
            {
                ///
            }
        }
        else
        {
            Enable_Panel(panelSaleOffer, false);
        }
    }


    private int UpdateRecord_DiscountStore()
    {
        int intActionResult = 0;
        DiscountZone discountZone = new DiscountZone();
        DiscountManegar manager = new DiscountManegar();
        discountZone.ProfileID = Convert.ToInt16(ProfileID);
        discountZone.DiscountUserType = Convert.ToInt16(GetDiscountType);
        try
        {
            if (ProfileID != 0)
            {
                intActionResult = manager.UpdateDiscountStore(discountZone);
            }
            else
            {

            }

        }
        catch (Exception ex)
        {
            lblSystemMessage.Text = ex.Message;
        }

        return intActionResult;

    }
}
