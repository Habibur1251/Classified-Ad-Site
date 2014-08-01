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

public partial class Corporate_UserProfile_Step01 : System.Web.UI.Page
{

    public string ImagePath
    {
        get
        {
            object obj = ViewState["ImagePath"];
            if (obj != null)
            {
                return obj.ToString();
            }
            return "";
        }
        set
        {
            ViewState["ImagePath"] = value;
        }
    }
    
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
    /// Description      : Insert new record in the table Business_UserProfile.
    /// Stored Procedure : USP_CP_UsrPro_BeforeInsert_IsLoginEmailDuplicate
    ///                    USP_CP_UsrPro_BeforeInsert_IsCompanyNameDuplicate
    ///                    USP_CP_UsrPro_InserRecord
    /// Associate Control: btnRegister [Button]
    /// </summary>
    /// <returns>Integer</returns>
    private int AddRecord_UserProfile()
    {
        int intActionResult = 0;

        try
        {
            using (BOC_Corporate_UserProfile bocUserProfile = new BOC_Corporate_UserProfile())
            {
                EOC_PropertyBean eocPropertyBean = new EOC_PropertyBean();

                eocPropertyBean.BusinessCategory_BusinessID = Convert.ToInt32(ddlBusinessType.SelectedItem.Value);
                eocPropertyBean.Business_UserProfile_LoginEmail = txtEmail1.Text;
                eocPropertyBean.Business_UserProfile_LoginPassword = txtPassword1.Text;
                eocPropertyBean.Business_UserProfile_CompanyName = txtCompany.Text;
                eocPropertyBean.Business_UserProfile_BusinessAddress = txtAddress.Text;
                eocPropertyBean.Business_UserProfile_ContactPhone = txtPhone.Text;
                eocPropertyBean.Business_UserProfile_CompanyURL = txtURL.Text;
                eocPropertyBean.Business_UserProfile_BillingPerson = txtBillingContact.Text;
                eocPropertyBean.Business_UserProfile_WebInventoryManager = txtInventoryManager.Text;
                eocPropertyBean.Business_UserProfile_CompanyProfile = txtProfile.Text;
                eocPropertyBean.Business_UserProfile_CompanyLogo = @"Corporate_Logos/default.png";

                eocPropertyBean.CorporateImagePathE = ImagePath.ToString();


                intActionResult = bocUserProfile.AddRecord_UserProfile(eocPropertyBean);
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
        if (!Page.IsPostBack)
        {
            this.LoadRecord_BusinessCategory();
        }
    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        int intActionResult = 0;
        string strSystemMessage = string.Empty;

        intActionResult = this.AddRecord_UserProfile();

        //Case 01 : Successfully insertion of record:
        if (intActionResult > 0)
        {
            this.Session["CORP_PROFILE_EMAIL"] = txtEmail1.Text;
            Response.Redirect("UserProfile_Step02.aspx");
        }

        //Case 02 : Record insertion unsuccessful for duplicate login email address:
        if (intActionResult == -1)
        {
            strSystemMessage = "<table style='width:500px; border:1px dashed #666666;'>";
            strSystemMessage += "<tr>";
            strSystemMessage += "<td align='center' style='width:10%;'><img src='../images/icon_error.gif' width='42' height='40' alt='' /></td>";
            strSystemMessage += "<td valign='middle' style='width:90%;font-weight:bold; text-decoration:underline'>Following error occured :</td>";
            strSystemMessage += "</tr>";
            strSystemMessage += "<tr>";
            strSystemMessage += "<td colspan='2' style='width:100%;color:#000000;padding-top:7px; padding-left:10px;'>";
            strSystemMessage += "This email address already used in another corporate profile.";
            strSystemMessage += "<br/><br/>";
            strSystemMessage += "<strong>How did this happen? </strong>";
            strSystemMessage += "<ul>";
            strSystemMessage += "<li>You may have already registered with www.apnerdeal.com earlier but forgot about it.</li>";
            strSystemMessage += "<li>If you share your email address with someone else, they may have signed up for a ApnerDeal corporate account with this address.</li>";
            strSystemMessage += "</ul>";
            strSystemMessage += "</td>";
            strSystemMessage += "</tr>";
            strSystemMessage += "</table>";

            lblSystemMessage.Text = strSystemMessage.ToString();
        }

        //Case 03 : Record insertion unsuccessful for duplicate company name:
        if (intActionResult == -2)
        {
            strSystemMessage = "<table style='width:500px; border:1px dashed #666666;'>";
            strSystemMessage += "<tr>";
            strSystemMessage += "<td align='center' style='width:10%;'><img src='../images/icon_error.gif' width='42' height='40' alt='' /></td>";
            strSystemMessage += "<td valign='middle' style='width:90%;font-weight:bold; text-decoration:underline'>Following error occured :</td>";
            strSystemMessage += "</tr>";
            strSystemMessage += "<tr>";
            strSystemMessage += "<td colspan='2' style='width:100%;color:#000000;padding-top:7px; padding-left:10px;'>";
            strSystemMessage += "This company name already exists in another corporate profile.";
            strSystemMessage += "<br/><br/>";
            strSystemMessage += "<strong>How did this happen? </strong>";
            strSystemMessage += "<ul>";
            strSystemMessage += "<li>You may have already registered with www.apnerdeal.com earlier but forgot about it.</li>";
            strSystemMessage += "<li>Some one else use this corporate name and signed up for a ApnerDeal.com corporate account.</li>";
            strSystemMessage += "</ul>";
            strSystemMessage += "</td>";
            strSystemMessage += "</tr>";
            strSystemMessage += "</table>";

            lblSystemMessage.Text = strSystemMessage.ToString();
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
                ImagePath = @"Classifieds/Images" + "/" + strFileName + "_CorporateCompanyLogo_" + strExtension;


             
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
