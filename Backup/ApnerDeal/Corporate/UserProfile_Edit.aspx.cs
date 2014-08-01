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
using System.Text;

public partial class Corporate_UserProfile_Edit : System.Web.UI.Page
{
    private int intProfileID = -1;
    private int intCountryID = -1;


    public string ImagePathCorporateEdit
    {
        get
        {
            object obj = ViewState["ImagePathCorporateEdit"];
            if (obj != null)
            {
                return obj.ToString();
            }
            return "";
        }
        set
        {
            ViewState["ImagePathCorporateEdit"] = value;
        }
    }


    public string ImagePathCorporate
    {
        get
        {
            object obj = ViewState["ImagePathCorporate"];
            if (obj != null)
            {
                return obj.ToString();
            }
            return "";
        }
        set
        {
            ViewState["ImagePathCorporate"] = value;
        }
    }

    private string strSystemMessage = string.Empty;

    /// <summary>
    /// Description      : Checking user login status in the session.
    /// </summary>
    private void CheckUserSession()
    {
        if (this.Session["CORP_PROFILE_CODE"] != null && this.Session["CORP_COUNTRY_CODE"] != null)
        {
            intProfileID = Convert.ToInt32(this.Session["CORP_PROFILE_CODE"].ToString());
            intCountryID = Convert.ToInt32(this.Session["CORP_COUNTRY_CODE"].ToString());
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
    }

    /// <summary>
    /// Description      : Load country list from the table Country.
    /// Stored Procedure : USP_CP_UsrPro_LoadCountry
    /// Associate Control: ddlCountry [Drop Down List]
    /// </summary>
    private void LoadRecord_Country()
    {
        try
        {
            using (BOC_Corporate_UserProfile bocUserProfile = new BOC_Corporate_UserProfile())
            {
                ddlCountry.DataSource = bocUserProfile.LoadRecord_Country();
                ddlCountry.DataValueField = "CountryID";
                ddlCountry.DataTextField = "Country";
                ddlCountry.DataBind();
            }
        }
        catch (Exception Exp)
        {
            lblSystemMessage.Text = Exp.Message.ToString();
        }
    }

    /// <summary>
    /// Description      : Load country wise state list from the table State.
    /// Stored Procedure : USP_CP_UsrPro_LoadState
    /// Associate Control: ddlState [Drop Down List]
    /// </summary>
    /// <param name="CountryID">String</param>
    private void LoadRecord_State(string CountryID)
    {
        try
        {
            if (!string.IsNullOrEmpty(CountryID) && CountryID != "-1")
            {
                using (BOC_Corporate_UserProfile bocUserProfile = new BOC_Corporate_UserProfile())
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
        }
        catch (Exception Exp)
        {
            lblSystemMessage.Text = Exp.Message.ToString();
        }
    }

    /// <summary>
    /// Description      : Load state wise province list.
    /// Stored Procedure : USP_CP_UsrPro_LoadProvince
    /// Associate Control: ddlProvince [Drop Down List]
    /// </summary>
    /// <param name="StateID">String</param>
    private void LoadRecord_Province(string StateID)
    {
        try
        {
            if (!string.IsNullOrEmpty(StateID) && StateID != "-1")
            {
                using (BOC_Corporate_UserProfile bocUserProfile = new BOC_Corporate_UserProfile())
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

    /// <summary>
    /// Description      : Load business category list from the table BusinessCategory.
    /// Stored Procedure : USP_CP_UsrPro_LoadBusinessCategory
    /// Associate Control: ddlBusinessType [Drop Down List]
    /// </summary>
    private void LoadRecord_BusinessCategory()
    {
        try
        {
            using (BOC_Corporate_UserProfile bocUserProfile = new BOC_Corporate_UserProfile())
            {
                ddlBusinessType.DataSource = bocUserProfile.LoadRecord_BusinessCategoey();
                ddlBusinessType.DataValueField = "BusinessID";
                ddlBusinessType.DataTextField = "BusinessCategory";
                ddlBusinessType.DataBind();
            }
        }
        catch (Exception Exp)
        {
            lblSystemMessage.Text = Exp.Message.ToString();
        }
    }

    /// <summary>
    /// Description      : Select specific user profile from the table Business_UserProfile.
    /// Stored Procedure : USP_CP_UsrPro_SelectSpecificRecord
    /// Associate Control: -
    /// </summary>
    /// <param name="intProfileID">Integer</param>
    private void SelectRecord_UserProfile(int intProfileID)
    {
        try
        {
            using (BOC_Corporate_UserProfile bocUserProfile = new BOC_Corporate_UserProfile())
            {
                EOC_PropertyBean eocPropertyBean = new EOC_PropertyBean();
                eocPropertyBean.Business_UserProfile_ProfileID = intProfileID;

                if (bocUserProfile.SelectRecord_UserProfile(eocPropertyBean))
                {
                    txtEmail1.Text = eocPropertyBean.Business_UserProfile_LoginEmail;
                    txtEmail2.Text = eocPropertyBean.Business_UserProfile_LoginEmail;
                    txtCompany.Text = eocPropertyBean.Business_UserProfile_CompanyName;
                    ddlBusinessType.SelectedValue = eocPropertyBean.BusinessCategory_BusinessID.ToString();
                    ddlCountry.SelectedValue = eocPropertyBean.Country_CountryID.ToString();
                    ddlState.SelectedValue = eocPropertyBean.State_StateID.ToString();
                    ddlProvince.SelectedValue = eocPropertyBean.Province_ProvinceID.ToString();
                    txtAddress.Text = eocPropertyBean.Business_UserProfile_BusinessAddress;
                    txtPhone.Text = eocPropertyBean.Business_UserProfile_ContactPhone;
                    txtURL.Text = eocPropertyBean.Business_UserProfile_CompanyURL;
                    txtBillingContact.Text = eocPropertyBean.Business_UserProfile_BillingPerson;
                    txtInventoryManager.Text = eocPropertyBean.Business_UserProfile_WebInventoryManager;
                    txtProfile.Text = eocPropertyBean.Business_UserProfile_CompanyProfile;
                    ImagePathCorporate = eocPropertyBean.CorporateImagePath.ToString();
                    if (ImagePathCorporate == "")
                    {
                        ImagePathCorporate = "../Classifieds_ProductImage/index.jpg";
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
                    strSystemMessage += "Corporate User Profile not found!";
                    strSystemMessage += "<br/><br/>";
                    strSystemMessage += "<strong>How did this happen? </strong>";
                    strSystemMessage += "<ul>";
                    strSystemMessage += "<li>You login session may be expired.</li>";
                    strSystemMessage += "<li>Your Corporate Account may be deleted by ApnerDeal authority for some reason.</li>";
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
    /// Description      : Update specific row in the table Business_UserProfile.
    /// Stored Procedure : USP_CP_UsrPro_BeforeUpdate_IsLoginEmailDuplicate, USP_CP_UsrPro_BeforeUpdate_IsCompanyNameDuplicate, USP_CP_UsrPro_UpdateRecord
    /// Associate Control: -
    /// </summary>
    /// <returns></returns>
    private int UpdateRecord_UserProfile()
    {
        int intActionResult = 0;

        try
        {
            using (BOC_Corporate_UserProfile bocUserProfile = new BOC_Corporate_UserProfile())
            {
                EOC_PropertyBean eocPropertyBean = new EOC_PropertyBean();

                eocPropertyBean.Business_UserProfile_ProfileID = intProfileID;
                eocPropertyBean.BusinessCategory_BusinessID = Convert.ToInt32(ddlBusinessType.SelectedItem.Value);
                eocPropertyBean.Business_UserProfile_LoginEmail = txtEmail1.Text;
                eocPropertyBean.Business_UserProfile_CompanyName = txtCompany.Text;
                eocPropertyBean.Business_UserProfile_BusinessAddress = txtAddress.Text;
                eocPropertyBean.Province_ProvinceID = Convert.ToInt32(ddlProvince.SelectedItem.Value);
                eocPropertyBean.Business_UserProfile_ContactPhone = txtPhone.Text;
                eocPropertyBean.Business_UserProfile_CompanyURL = txtURL.Text;
                eocPropertyBean.Business_UserProfile_BillingPerson = txtBillingContact.Text;
                eocPropertyBean.Business_UserProfile_WebInventoryManager = txtInventoryManager.Text;
                eocPropertyBean.Business_UserProfile_CompanyProfile = txtProfile.Text;
               // eocPropertyBean.UpdatedOn = DateTime.Now;
                eocPropertyBean.CorporateImagePathEdit = ImagePathCorporateEdit.ToString();

                intActionResult = bocUserProfile.UpdateRecord_UserProfile(eocPropertyBean);
            }
        }
        catch (Exception Exp)
        {
            lblSystemMessage.Text = Exp.Message.ToString();
        }

        return intActionResult;
    }   

    protected void Page_Load(object sender, EventArgs e)
    {
        this.CheckUserSession();

        UTLUtilities.CP_ActiveModule = 2;

        if (!Page.IsPostBack)
        {
            this.SelectRecord_UserProfile(intProfileID);
            this.LoadRecord_Country();
            this.LoadRecord_State(ddlCountry.SelectedItem.Value);
            this.LoadRecord_Province(ddlState.SelectedItem.Value);
            this.LoadRecord_BusinessCategory();                       
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int intActionResult = 0;
        string strSystemMessage = string.Empty;

        intActionResult = this.UpdateRecord_UserProfile();

        if (intActionResult > 0)
        {
            Response.Redirect("ControlPanel.aspx");
        }

        if (intActionResult == -1)
        {
            strSystemMessage = "<table style='width:500px; border:1px dashed #666666;'>";
            strSystemMessage += "<tr>";
            strSystemMessage += "<td align='center' style='width:10%;'><img src='../images/icon_error.gif' width='42' height='40' alt='' /></td>";
            strSystemMessage += "<td valign='middle' style='width:90%;font-weight:bold; text-decoration:underline'>Following error occured :</td>";
            strSystemMessage += "</tr>";

            strSystemMessage += "<tr>";
            strSystemMessage += "<td colspan='2' style='width:100%; color:#000000; padding-top:7px; padding-left:10px;'>";
            strSystemMessage += "This email address already used in another company profile.";
            strSystemMessage += "<br/><br/>";
            strSystemMessage += "<strong>How did this happen? </strong>";
            strSystemMessage += "<ul>";
            strSystemMessage += "<li>You may have already registered with www.apnerdeal.com earlier but forgot about it.</li>";
            strSystemMessage += "<li>If you share your email address with someone else, they may have signed up for a ApnerDeal corporate account with this address.</li>";
            strSystemMessage += "</ul>";
            strSystemMessage += "</td>";
            strSystemMessage += "</tr>";
            strSystemMessage += "</table>";

            lblSystemMessage.Text = strSystemMessage;
        }
    }

    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlState.Items.Clear();
        ddlState.Items.Add(new ListItem("Select", "-1"));

        ddlProvince.Items.Clear();
        ddlProvince.Items.Add(new ListItem("Select", "-1"));

        this.LoadRecord_State(ddlCountry.SelectedItem.Value);
    }

    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadRecord_Province(ddlState.SelectedItem.Value);
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

                // code start for "do not upload .txt, .doc file "

                if ((strExtension.ToUpper() == ".TXT"))
                {

                    Page.RegisterStartupScript("Validation", "<script language=\"javascript\">window.alert(\"Txt file is not allowed. Please choose any other format.\");</script>");
                    btnUpload.Enabled = true;
                    return;

                }

                // code end for "do not upload .txt file "

                string strFileName = DateTime.Now.ToString("hh.mm.ss");
                strFileName += "_" + DateTime.Today.Day.ToString();
                strFileName += "." + DateTime.Today.Month.ToString();
                strFileName += "." + DateTime.Now.Year.ToString();

                string fileName = Path.GetFileName(FileUpload1.FileName);

                FileUpload1.SaveAs(Server.MapPath(@"../Classifieds/Images" + "/" + strFileName + "_CorporateCompanyLogo_" + strExtension));
                ImagePathCorporateEdit = @"../Classifieds/Images" + "/" + strFileName + "_CorporateCompanyLogo_" + strExtension;



                Page.RegisterStartupScript("Validation", "<script language=\"javascript\">window.alert(\"Image uploaded.\");</script>");
                lblImageUploadMessage.Text = "Image uploaded.";



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

    }
}
