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

public partial class Corporate_DiscountProfileAE : System.Web.UI.Page
{
    private bool _IsAdmin;

    private void Enable_Panel(Panel pnl, bool isEnable)
    {
        pnl.Visible = isEnable;
        pnl.Enabled = isEnable;
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

    private string GetDiscountType
    {
        get
        {
            object obj = ViewState["GetDiscountType"];
            if (obj != null)
            {
                return (string)obj;
            }
            return "";
        }

        set { ViewState["GetDiscountType"] = value; }
    }

    private string GeneratedCopunCode
    {
        get
        {
            object obj = ViewState["GeneratedCopunCode"];
            if (obj != null)
            {
                return (string)obj;
            }
            return "";
        }

        set { ViewState["GeneratedCopunCode"] = value; }
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


    private int intCountryID = -1;

    protected void Page_Load(object sender, EventArgs e)
    {
        DateTime dtFrom;
        DateTime dtTo;


        DateTimeValidation dateTimeValidation = new DateTimeValidation();
        DateTimeValidation.Date_Validation dateValidation = new DateTimeValidation.Date_Validation();
        ddlCouponType.Enabled = false;
        this.CheckUserSession();
        if (!Page.IsPostBack)
        {
            this.CheckQueryString();

            dtFrom = DateTime.Today;
            dtTo = DateTime.Today.AddMonths(1);

            txtFromDate.Text = dtFrom.ToString("MM/dd/yyyy");
            txtToDate.Text = dtTo.ToString("MM/dd/yyyy");

            //txtFromDate.Text = Convert.ToString(dateValidation.date_Format_Front_End(DateTime.Today));
            //txtToDate.Text = Convert.ToString(dateValidation.date_Format_Front_End(DateTime.Today.AddMonths(1)));

            
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
                ProfileID = Convert.ToInt32(this.Session["AdminCompanyProfileID"].ToString());
            }
            else
            {
                ProfileID = Convert.ToInt32(this.Session["CORP_PROFILE_CODE"].ToString());
            }
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
    }

    private void CheckQueryString()
    {
        bool blnFlag = false;
        if (Request.QueryString["mode"] == null && Request.QueryString["CI"] == null && Request.QueryString["SUBC"] == null && Request.QueryString["DITY"] == null)
        {
            blnFlag = false;
        }
        else
        {
            PageMode = Convert.ToInt32(Request.QueryString["mode"]);
            CategoryID = Convert.ToInt32(Request.QueryString["CI"]);
            SubCategoryID = Convert.ToInt32(Request.QueryString["SUBC"]);
            GetDiscountType = Request.QueryString["DT"].ToString();
            if (PageMode == 0 || PageMode == 1)
            {
                CategoryID = Convert.ToInt32(Request.QueryString["CI"]);
                SubCategoryID = Convert.ToInt32(Request.QueryString["SUBC"]);
                if (CategoryID > 0 && SubCategoryID > 0)
                {
                    blnFlag = true;
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

    private int AddRecord_DiscountProfile()
    {
            int intActionResult = 0;
            int validateInputDate = 0;
            int validateInputCoupon = 0;
            DataTable dt = new DataTable();
            int startDigit = 00000;
            DiscountZone discountZone = new DiscountZone();
            DateTimeValidation dateTimeValidation = new DateTimeValidation();
            DiscountManegar manager = new DiscountManegar();
            
        DateTimeValidation.Date_Validation dateValidation = new DateTimeValidation.Date_Validation();

            int validDateRange = DateTime.Compare(Convert.ToDateTime(dateValidation.date_Format_Back_End(txtToDate.Text.Trim())),
                            Convert.ToDateTime(dateValidation.date_Format_Back_End(txtFromDate.Text.Trim())));

            try
            {
                 dt  = manager.GenerateCouponCode();
                if (dt.Rows.Count > 0)
                {
                    GeneratedCopunCode = dt.Rows[0]["MaxCouponCode"].ToString();
                }
            }
            catch (Exception ex)
            {
                lblSystemMessage.Text = ex.Message;
            }
            if (validDateRange > 0)
            {
                validateInputDate = 1;
                dateTimeLabel.Text = "";
            }
            else
            {
                validateInputDate = 0;
                dateTimeLabel.Text = "*Enter valid date range.";
            }

            
                discountZone.CategoryID = Convert.ToInt16(CategoryID);
                discountZone.SubcategoryID = Convert.ToInt16(SubCategoryID);
                discountZone.ProfileID = Convert.ToInt16(ProfileID);
                discountZone.CouponTitle = couponTitleTextBox.Text.ToString();
                discountZone.TermsCondition = termsConditionsTextBox.Text.ToString();
                discountZone.CouponDescription = couponDescriptionTextBox.Text.ToString();
                discountZone.CouponType = ddlCouponType.SelectedItem.ToString();
                if (GetDiscountType =="1")
                {
                    discountZone.CouponCode = "ApnerDeal-" + (startDigit + Convert.ToInt32(GeneratedCopunCode)+1);

                }
                else
                {
                    discountZone.CouponCode = "BM-STAN-" + (startDigit + Convert.ToInt32(GeneratedCopunCode)+1);
                }
                discountZone.NeedToPrintCoupon=Convert.ToBoolean(isPrintedCouponNeedRadioButtonList.SelectedValue);
                discountZone.UseBoromelaCoupon=Convert.ToInt16(DiscountType.SelectedValue);
                discountZone.UserUploadedCouponPath=ImagePath.ToString();
                discountZone.IsActive=true;
                discountZone.IsAdminAuthentication=true;
                discountZone.CheckAdminForListing = false;
                discountZone.UserType = Convert.ToBoolean(IsAdmin);
                discountZone.CouponEffectiveDate = Convert.ToDateTime(dateValidation.date_Format_Back_End(txtFromDate.Text));
                discountZone.CouponExpirydate = Convert.ToDateTime(dateValidation.date_Format_Back_End(txtToDate.Text));
                discountZone.UpdatedOn = DateTime.Now;
                discountZone.DiscountCouponURL = urlTextBox.Text.ToString();

                if (DiscountType.SelectedValue.ToString() == "2" && ImagePath =="")
                {
                    
                        validateInputCoupon = 0;
                        couponLabel.Text = "*Please upload your own coupon.";
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
                    intActionResult = manager.Ad_Discount(discountZone);
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

    protected void btnCouponSubmit_Click(object sender, EventArgs e)
    {
        int intActionStatus = 0;
        if (Page.IsValid)
        {
            if (PageMode == 0)
            {
                intActionStatus = this.AddRecord_DiscountProfile();
            }
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
            Response.Redirect("MessageDiscount.aspx");
        }
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


}
