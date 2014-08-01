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

public partial class Classifieds_ProductProfile_ImageUploader : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        string productID = string.Empty;
        string imagePath = string.Empty;
        int intActionResult = 0;

        productID = Request.QueryString["PID"];
        imagePath = @"ImageHolder/Classifieds/" + productID + ".jpg";



        if (!string.IsNullOrEmpty(productID))
        {
            if (UTLUtilities.IsNumeric(productID))
            {
                if (FileUpload1.HasFile)
                {
                    if (FileUpload1.PostedFile.ContentLength > 204800)
                    {
                        lblSystemMessage.Text = "File size must be less than 200KB.";
                        Page.RegisterStartupScript("Validation", "<script language=\"javascript\">window.alert(\"File size must be less than 200KB.\");</script>");
                        return;
                    }
                    else
                    {
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
                            lblSystemMessage.Text = "Bmp format is not allowed. Please choose any other format.";
                            return;

                        }
                        FileUpload1.SaveAs(Server.MapPath(@"../ImageHolder/Classifieds/") + productID + ".jpg");
                        using (BOC_Classifieds_ProductProfile bocProductProfile = new BOC_Classifieds_ProductProfile())
                        {
                            EOC_PropertyBean eocPropertyBean = new EOC_PropertyBean();
                            eocPropertyBean.Classifieds_ProductProfile_ProductID = Convert.ToInt32(productID);
                            eocPropertyBean.Classifieds_ProductProfile_ProductImage = imagePath;

                            intActionResult = bocProductProfile.UpdateRecord_ProductImage(eocPropertyBean);

                            if (intActionResult > 0)
                            {
                                Response.Redirect("ControlPanel.aspx");
                            }
                        }
                    }
                }
            }
        }

    }
}
