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

public partial class UserControl_RealEstate_CP_Ctrl : System.Web.UI.UserControl
{
    private int _ProfileID = -1;
    //public bool UserType = false;
    public string Path = "";

    private bool _UserType;

    public bool UserType
    {
        get { return _UserType; }
        set { _UserType = value; }
    }

    private DateTime _StartDate;

    public DateTime StartDate
    {
        get { return _StartDate; }
        set { _StartDate = value; }
    }

    private DateTime _EndDate;

    public DateTime EndDate
    {
        get { return _EndDate; }
        set { _EndDate = value; }
    }

	

    private void LoadList_PostedRealEstate(int _ProfileID, DateTime startDate, DateTime endDate)
    {

        RealEstate objRealEstate = new RealEstate();
        RealEstateManager manager = new RealEstateManager();

        objRealEstate.ProfileID = _ProfileID;
        objRealEstate.StartDate = startDate;
        objRealEstate.EndDate = endDate;

        try
        {
            DataTable dt = manager.LoadList_PostedRealEstate(objRealEstate);
            if (dt.Rows.Count > 0)
            {
                grvRealEstate.DataSource = dt;
                grvRealEstate.DataBind();
            }
            else
            {
                grvRealEstate.DataSource = null;
                grvRealEstate.DataBind();
            }
        }
        catch (Exception ex)
        {
            lblSystemMessage.Text = ex.Message;
        }
    }

    

    protected void Page_Load(object sender, EventArgs e)
    {
        if (UserType)
        {
            Path = "../Corporate/";
        }
        else
        {
            Path = "../Classifieds/";
        }
        
        if (this.Session["CLSF_PROFILE_CODE"] != null)
        {
            _ProfileID = Convert.ToInt32(this.Session["CLSF_PROFILE_CODE"]);
        }
        else if (this.Session["CORP_PROFILE_CODE"] != null)
        {
            _ProfileID = Convert.ToInt32(this.Session["CORP_PROFILE_CODE"]);
        }
        else
        {
            //Response.re
        }
        if (!Page.IsPostBack)
        {
//            this.LoadList_PostedRealEstate(_ProfileID, StartDate, EndDate);
        }
    }
    protected void grvClassifiedProduct_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            grvRealEstate.PageIndex = e.NewPageIndex;
            this.LoadList_PostedRealEstate(_ProfileID, StartDate, EndDate);
        }
        catch (Exception ex)
        {
            lblSystemMessage.Text = ex.Message;
        }

    }

    protected void Page_PreRender(object sender, EventArgs args)
    {
        this.LoadList_PostedRealEstate(_ProfileID, StartDate, EndDate);
    }
    protected void grvRealEstate_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
