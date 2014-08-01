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

public partial class Corporate_CheckAdmin : System.Web.UI.Page
{
    private int intProfileID = -1;
    private int intCountryID = -1;
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
    private bool _IsAdmin;
    public bool IsAdmin
    {
        get { return _IsAdmin; }
        set { _IsAdmin = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        UTLUtilities.CP_ActiveModule = 40;
        this.CheckUserSession();
        if (!Page.IsPostBack)
        {
            if(IsAdmin.ToString()=="True")
            {
                LoadRecord_Company();
            }
            else
            {
              Response.Redirect("StoreType.aspx");
            }
        }
    }

    private void LoadRecord_Company()
    {
        try
        {
            DiscountManegar manager = new DiscountManegar();
            DataTable dt = new DataTable();
            DiscountZone discountZone = new DiscountZone();
            discountZone.ProfileID = ProfileID;
            dt = manager.LoadDiscuntCompany(discountZone);
            if (dt.Rows.Count > 0)
            {

                ddlCompanyName.DataSource = dt;
                ddlCompanyName.DataValueField = "ProfileID";
                ddlCompanyName.DataTextField = "CompanyName";
                ddlCompanyName.DataBind();
            }
            else
            {
                lblSystemMessage.Text = "No Category available";
            }
        }
        catch (Exception Exp)
        {
            lblSystemMessage.Text = Exp.Message.ToString();
        }
    }
    private void CheckUserSession()
    {
        if (this.Session["CORP_PROFILE_CODE"] != null && this.Session["CORP_COUNTRY_CODE"] != null)
        {
            ProfileID = Convert.ToInt32(this.Session["CORP_PROFILE_CODE"].ToString());
            intCountryID = Convert.ToInt32(this.Session["CORP_COUNTRY_CODE"].ToString());
            IsAdmin = Convert.ToBoolean(this.Session["ISADMIN"]);
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
    }
    protected void btnNextPage_Click(object sender, EventArgs e)
    {
        this.Session["AdminCompanyProfileID"] = ddlCompanyName.SelectedValue.ToString();
        Response.Redirect("StoreType.aspx");

    }
    protected void btnChangeCategory_Click(object sender, EventArgs e)
    {
    }
}
