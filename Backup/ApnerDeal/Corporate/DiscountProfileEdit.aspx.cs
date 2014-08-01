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


public partial class Corporate_DiscountProfileEdit : System.Web.UI.Page
{
    private int intCountryID = -1;
    private string strSystemMessage = null;

    private bool _IsAdmin;
    public bool IsAdmin
    {
        get { return _IsAdmin; }
        set { _IsAdmin = value; }
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

    private int CouponID
    {
        get
        {
            object obj = ViewState["CouponID"];
            if (obj != null)
            {
                return (int)obj;
            }
            return 0;
        }

        set { ViewState["CouponID"] = value; }
    }

    public string CouponCode
    {
        get
        {
            object obj = ViewState["CouponCode"];
            if (obj != null)
            {
                return obj.ToString();
            }
            return "";
        }
        set { ViewState["CouponCode"] = value; }

    }

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

    public string CompanyInformationEditingPage
    {
        get
        {
            object obj = ViewState["CompanyInformationEditingPage"];
            if (obj != null)
            {
                return obj.ToString();
            }
            return "";
        }
        set
        {
            ViewState["CompanyInformationEditingPage"] = value;
        }
    }

    private void CheckQueryString()
    {
        try
        {
            object objPFI = Request.QueryString["PI"];
            object objCI = Request.QueryString["CI"];
            object objCC = Request.QueryString["CC"];

            if (objPFI != null && objCI != null)
            {
               ProfileID = Convert.ToInt32(objPFI);
               CouponID = Convert.ToInt32(objCI);
               CouponCode = objCC.ToString();
            }
            else
            {
                string data = UTLUtilities.Encrypt("Parameter missing");
                Server.Transfer("../Error.aspx?data=" + data, false);
            }

        }
        catch (Exception ex)
        {
            lblSystemMessage.Text = ex.Message;
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

    protected void Page_Load(object sender, EventArgs e)
    {
        this.CheckUserSession();
        this.CheckQueryString();
        if (!Page.IsPostBack)
        {
         this.SelectRecordDiscount();
         if (IsAdmin.ToString() == "True")
         {
             CompanyInformationEditingPage = "AdminCompanyEdit.aspx";
             this.Session["AdminEditCompanyProfileID"] = ProfileID.ToString();
         }
         else
         {
             CompanyInformationEditingPage = "UserProfile_Edit.aspx";
         }
        }

    }

    private void Enable_Panel(Panel pnl, bool isEnable)
    {
        pnl.Visible = isEnable;
        pnl.Enabled = isEnable;
    }


    private void SelectRecordDiscount()
    {
        DiscountZone discountZone = new DiscountZone();
        DateTimeValidation dateTimeValidation = new DateTimeValidation();
        DiscountManegar manager = new DiscountManegar();
        DataTable dt = new DataTable();
        discountZone.CouponID = CouponID;
        discountZone.ProfileID = ProfileID;
        discountZone.CouponCode = CouponCode;
        dt = manager.LoadRecord_BS_SpecificDiscount(discountZone);
        if (dt.Rows.Count > 0)
        {
            couponTitleTextBox.Text = dt.Rows[0]["CouponTitle"].ToString();
            couponDescriptionTextBox.Text = dt.Rows[0]["CouponDescription"].ToString();
            txtFromDate.Text = dt.Rows[0]["CouponEffectiveDate"].ToString();
            txtToDate.Text = dt.Rows[0]["CouponExpirydate"].ToString();
            string PrientedCouponNeed = dt.Rows[0]["PrintedCouponNeed"].ToString();
            if (PrientedCouponNeed == "True")
            {
                isPrintedCouponNeedRadioButtonList.SelectedValue = "True";
            }
            else if(PrientedCouponNeed=="False")
            {
                isPrintedCouponNeedRadioButtonList.SelectedValue = "False";
            }
            string CouponTemplate = dt.Rows[0]["UseBoromelaCoupon"].ToString();
            if (CouponTemplate == "UsedBoromelaCouponTemplate")
            {
                DiscountType.SelectedValue = "1";
                Enable_Panel(userCouponUpload, false);
                Enable_Panel(urlPanel, false);
            }
            else if (CouponTemplate == "UsedCompanyCouponTemplate")
            {
                DiscountType.SelectedValue = "2";
                Enable_Panel(userCouponUpload, true);
                Enable_Panel(urlPanel, false);
                ImagePath = dt.Rows[0]["UserUploadedCouponPath"].ToString();
            }
            else if (CouponTemplate == "UsedCompanyURL")
            {
                DiscountType.SelectedValue = "3";
                Enable_Panel(urlPanel, true);
                Enable_Panel(userCouponUpload, false);
                urlTextBox.Text = dt.Rows[0]["DiscountCouponURL"].ToString();
            }
            termsConditionsTextBox.Text = dt.Rows[0]["TermsCondition"].ToString();
        }

        else
        {
            strSystemMessage = "<table style='width:500px; border:1px dashed #666666;'>";

            strSystemMessage += "<tr>";
            strSystemMessage += "<td colspan='2' style='width:100%; color:#000000; padding-top:7px; padding-left:10px;'>";
            strSystemMessage += "Product Profile not found!";
            strSystemMessage += "<br/><br/>";
            strSystemMessage += "<strong>How did this happen? </strong>";
            strSystemMessage += "<ul>";
            strSystemMessage += "<li>You login session may be expired.</li>";
            strSystemMessage += "<li>Your Discount may be deleted by ApnerDeal authority for some reason.</li>";
            strSystemMessage += "</ul>";
            strSystemMessage += "</td>";
            strSystemMessage += "</tr>";
            strSystemMessage += "</table>";

            lblSystemMessage.Text = UTLUtilities.ShowErrorMessage(strSystemMessage);
        }
    }

    private int UpdateRecord_DiscountProfile()
    {
        DateTime dtFrom;
        DateTime dtTo;

        dtFrom = Convert.ToDateTime(txtFromDate.Text);
        dtTo = Convert.ToDateTime(txtToDate.Text);

        txtFromDate.Text = dtFrom.ToString("MM/dd/yyyy");
        txtToDate.Text = dtTo.ToString("MM/dd/yyyy");


        int intActionResult = 0;
        int validateInputDate = 0;
        int validateInputCoupon = 0;
        DataTable dt = new DataTable();
        DiscountZone discountZone = new DiscountZone();
        discountZone.CouponID = CouponID;
        discountZone.ProfileID = ProfileID;
        discountZone.CouponCode = CouponCode;
        DateTimeValidation dateTimeValidation = new DateTimeValidation();
        DiscountManegar manager = new DiscountManegar();
        DateTimeValidation.Date_Validation dateValidation = new DateTimeValidation.Date_Validation();
        
        int validDateRange = DateTime.Compare(Convert.ToDateTime(dateValidation.date_Format_Back_End(txtToDate.Text.Trim())),
                        Convert.ToDateTime(dateValidation.date_Format_Back_End(txtFromDate.Text.Trim())));

        if (validDateRange >= 0)
        {
            validateInputDate = 1;
            dateTimeLabel.Text = "";
        }
        else
        {
            validateInputDate = 0;
            dateTimeLabel.Text = "*Enter valid date range.";
        }

        discountZone.CouponTitle = couponTitleTextBox.Text.ToString();
        discountZone.TermsCondition = termsConditionsTextBox.Text.ToString();
        discountZone.CouponDescription = couponDescriptionTextBox.Text.ToString();
        discountZone.CouponType = ddlCouponType.SelectedItem.ToString();
        discountZone.UseBoromelaCoupon = Convert.ToInt16(DiscountType.SelectedValue);
        discountZone.UserUploadedCouponPath = ImagePath.ToString();
        discountZone.NeedToPrintCoupon = Convert.ToBoolean(isPrintedCouponNeedRadioButtonList.SelectedValue);
        discountZone.CouponEffectiveDate = Convert.ToDateTime(dateValidation.date_Format_Back_End(txtFromDate.Text.Trim()));
        discountZone.CouponExpirydate = Convert.ToDateTime(dateValidation.date_Format_Back_End(txtToDate.Text.Trim()));
        discountZone.UpdatedOn = DateTime.Now;
        discountZone.DiscountCouponURL = urlTextBox.Text.ToString();

        if (DiscountType.SelectedValue.ToString() == "2" && ImagePath == "")
        {

            validateInputCoupon = 0;
            couponLabel.Text = "*Please upload your won coupon.";
        }
        else
        {
            validateInputCoupon = 1;
            couponLabel.Text = "";
        }


        try
        {
            if (validateInputCoupon == 1 && validateInputDate == 1)
            {
                intActionResult = manager.Update_Discount(discountZone);
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


    protected void DiscountType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DiscountType.SelectedValue.ToString() == "2")
        {
            Enable_Panel(userCouponUpload, true);
            Enable_Panel(urlPanel, false);
        }
        else if (DiscountType.SelectedValue.ToString() == "1")
        {
            Enable_Panel(userCouponUpload, false);
            Enable_Panel(urlPanel, false);
        }
        else if (DiscountType.SelectedValue.ToString() == "3")
        {
            Enable_Panel(urlPanel, true);
            Enable_Panel(userCouponUpload, false);
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

                FileUpload1.SaveAs(Server.MapPath(@"../Images/UserUploadedCoupon" + "/" + strFileName + "_CorporateDiscountCoupon_" + strExtension));
                ImagePath = @"Images/UserUploadedCoupon" + "/" + strFileName + "_CorporateDiscountCoupon_" + strExtension;



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
    protected void btnCouponSubmit_Click(object sender, EventArgs e)
    {
        int intActionStatus = 0;
        if (Page.IsValid)
        {

            intActionStatus = this.UpdateRecord_DiscountProfile();
        }
        else
        {
            //
        }
        if (intActionStatus == 0)
        {

            lblSystemMessage.Text = "Your Discount could not be saved.";
        }
        else if (intActionStatus > 0)
        {
            Response.Redirect("MessageDiscountUpdate.aspx");
        }
    }
}
