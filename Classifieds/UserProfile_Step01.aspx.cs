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

public partial class Classifieds_UserProfile_Step01 : System.Web.UI.Page
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

    private void LoadRecord_Country()
    {
        try
        {
            using (BOC_Classifieds_UserProfile bocUserProfile = new BOC_Classifieds_UserProfile())
            {
                DataTable dtCountry = bocUserProfile.LoadRecord_Country();

                if (dtCountry.Rows.Count > 0)
                {
                    ddlCountry.DataSource = dtCountry;
                    ddlCountry.DataValueField = "CountryID";
                    ddlCountry.DataTextField = "Country";
                    ddlCountry.DataBind();
                }
            }
        }
        catch (Exception Exp)
        {
            lblSystemMessage.Text = Exp.Message.ToString();
        }
    }
    private void LoadRecord_State(string CountryID)
    {
        try
        {
            if (!string.IsNullOrEmpty(CountryID) && CountryID != "-1")
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
        }
        catch (Exception Exp)
        {
            lblSystemMessage.Text = Exp.Message.ToString();
        }
    }
    private void LoadRecord_Province(string StateID)
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
    private int AddRecord_UserProfile()
    {
        int intActionResult = 0;

        try
        {
            using (BOC_Classifieds_UserProfile bocUserProfile = new BOC_Classifieds_UserProfile())
            {
                EOC_PropertyBean eocPropertyBean = new EOC_PropertyBean();

                eocPropertyBean.Classifieds_UserProfile_LoginEmail = txtEmail1.Text;
                eocPropertyBean.Classifieds_UserProfile_LoginPassword = txtPassword1.Text;
                eocPropertyBean.Classifieds_UserProfile_AdvertiserName = txtName.Text;
                eocPropertyBean.Classifieds_UserProfile_ContactAddress = txtAddress.Text;
                eocPropertyBean.Province_ProvinceID = Convert.ToInt32(ddlProvince.SelectedItem.Value);
                eocPropertyBean.Classifieds_UserProfile_Mobile = txtCellPhoe.Text;                
                eocPropertyBean.UpdatedOn = DateTime.Now;
                eocPropertyBean.ImagePath = ImagePath.ToString();
                eocPropertyBean.Source = ddlSource.SelectedValue;
                if (ddlSource.SelectedValue == "News Paper" || ddlSource.SelectedValue == "Search Engine" || ddlSource.SelectedValue == "Friend")
                {
                    eocPropertyBean.ReferalName = Server.HtmlEncode( txtReferalName.Text);
                }
                else
                {
                    eocPropertyBean.ReferalName = "";
                }

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
            lblSource.Text = "Please provide friends email address.";
            this.LoadRecord_Country();
        }
    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        int intActionResult = 0;
        string strSystemMessage = string.Empty;
        //CaptchaControl1.ValidateCaptcha(txtCaptcha.Text);
        
        //if (CaptchaControl1.UserValidated)
        //{
            intActionResult = this.AddRecord_UserProfile();

            if (intActionResult > 0)
            {
                this.Session["CLSF_PROFILE_EMAIL"] = txtEmail1.Text;
                Response.Redirect("UserProfile_Step02.aspx");
            }
            if (intActionResult == -1)
            {
                strSystemMessage += "This email address already used in another user profile.";
                strSystemMessage += "<br/><br/>";
                strSystemMessage += "<strong>How did this happen? </strong>";
                strSystemMessage += "<ul>";
                strSystemMessage += "<li>You may have already registered with www.apnerdeal.com earlier but forgot about it.</li>";
                strSystemMessage += "<li>If you share your email address with someone else, they may have signed up for a ApnerDeal Free Classified account with this address.</li>";
                strSystemMessage += "</ul>";

                lblSystemMessage.Text = UTLUtilities.ShowErrorMessage(strSystemMessage);
            }
        //}
    }

    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadRecord_Province(ddlState.SelectedItem.Value);
    }
    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.LoadRecord_State(ddlCountry.SelectedItem.Value);
    }
    protected void ddlSource_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtReferalName.Text = "";
        if (ddlSource.SelectedValue == "News Paper" || ddlSource.SelectedValue == "Search Engine" || ddlSource.SelectedValue == "Friend")
        {
            pnlRefaralName.Visible = true;
            pnlRefaralName.Enabled = true;
            if (ddlSource.SelectedValue == "Friend")
            {
                revFrndEmail.Enabled = true;
            }
            else
            {
                revFrndEmail.Enabled = false;
            }
        }
        else
        {
            pnlRefaralName.Visible = false;
            pnlRefaralName.Enabled = false;
        }

        if(ddlSource.SelectedValue == "Friend")
        {
            lblSource.Text = "Please provide friends email address.";
        }
        else if(ddlSource.SelectedValue == "News Paper")
        {
            lblSource.Text = "Please provide news paper name.";
        }
        else if(ddlSource.SelectedValue == "Search Engine")
        {
            lblSource.Text = "Please provide search engine name.";
        }
        else if (ddlSource.SelectedValue == "News Paper")
        {
            lblSource.Text = "Please provide news paper name.";
        }
        else
        {
            lblSource.Text = "";
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

                FileUpload1.SaveAs(Server.MapPath(@"../Classifieds/Images" + "/" + strFileName + "_CLProfilePicture_" + strExtension));
                ImagePath = @"../Classifieds/images" + "/" + strFileName + "_CLProfilePicture_" + strExtension;

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
