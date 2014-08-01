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

public partial class ItemDetail_Classifieds : System.Web.UI.Page
{
    #region Common Property
    private bool IsProfileFound = false;
    private string profileID = string.Empty;
    private string productID = string.Empty;
    private string categoryID = string.Empty;
    private string subcategoryID = string.Empty;
    private string location = string.Empty;
    private string advertisementType = string.Empty;

    public string strCurrency = "";
    public string strSalePrice = "";

    public DataTable dtProductProfile = null;
    public DataTable dtOrder;
    public EOC_PropertyBean eocProductProfile = new EOC_PropertyBean();

    public string ProfileID
    {
        get { return this.profileID; }
        set { this.profileID = value; }
    }

    public string ProductID
    {
        get { return this.productID; }
        set { this.productID = value; }
    }

    public string CategoryID
    {
        get { return this.categoryID; }
        set { this.categoryID = value; }
    }

    public string SubcategoryID
    {
        get { return this.subcategoryID; }
        set { this.subcategoryID = value; }
    }

    public string Location
    {
        get { return this.location; }
        set { this.location = value; }
    }

    public string AdvertisementType
    {
        get { return this.advertisementType; }
        set { this.advertisementType = value; }
    }

    #endregion Common Property

    private bool SelectRecord_ProductProfile(int intProductID, int intProfileID)
    {
        bool blnFlag = false;

        try
        {
            using (BOC_Classifieds_Orders bocProductProfile = new BOC_Classifieds_Orders())
            {
                EOC_PropertyBean eocPropertyBean = new EOC_PropertyBean();

                eocPropertyBean.Classifieds_ProductProfile_ProductID = intProductID;
                eocPropertyBean.Classifieds_UserProfile_ProfileID = intProfileID;

                dtProductProfile = bocProductProfile.SelectRecord_ProductProfile_Classifieds(eocPropertyBean);

                if (dtProductProfile.Rows.Count > 0)
                {
                    blnFlag = true;

                    string strAlternatePrice = dtProductProfile.Rows[0]["AlternatePriceOffer"].ToString();
                    string strCurrency = dtProductProfile.Rows[0]["Currency"].ToString();

                    //lblPricingOffer.Text = String.Format("{0:#,###}", dtProductProfile.Rows[0]["SalePrice"]);

                    if (strAlternatePrice == "-1")
                    {
                        lblPricingOffer.Text = "Price (Not Available)";
                    }
                    else if (strAlternatePrice == "1")
                    {
                        lblPricingOffer.Text = "Best Offer (" + strCurrency + " " + String.Format("{0:#,###}", dtProductProfile.Rows[0]["SalePrice"]) + ")";
                    }
                    else if (strAlternatePrice == "2")
                    {
                        lblPricingOffer.Text = "Please Contact";
                    }
                    else if (strAlternatePrice == "3")
                    {
                        lblPricingOffer.Text = "Exchange";
                    }
                    else if (strAlternatePrice == "4")
                    {
                        lblPricingOffer.Text = "Free";
                    }
                    else if (strAlternatePrice == "5")
                    {
                        lblPricingOffer.Text = "Fixed (" + strCurrency + " " + String.Format("{0:#,###}", dtProductProfile.Rows[0]["SalePrice"]) + ")";
                    }
                    else if (strAlternatePrice == "6")
                    {
                        lblPricingOffer.Text = "Negotiable (" + strCurrency + " " + String.Format("{0:#,###}", dtProductProfile.Rows[0]["SalePrice"]) + ")";
                    }
                    else
                    {
                        lblPricingOffer.Text = "Price (" + strCurrency + " " + String.Format("{0:#,###}", dtProductProfile.Rows[0]["SalePrice"]) + ")";
                    }

                }
            }
        }
        catch (Exception Exp)
        {
            lblSystemMessage.Text = Exp.Message.ToString();
        }

        return blnFlag;
    }


    /// <summary>
    /// Takes Index object of alternate price offer. Returns AlternatePriceOffer as string.
    /// </summary>
    /// <param name="objIndex"></param>
    /// <returns></returns>
    public string Get_AlternatePriceOffer(object objIndex)
    {
        string strIndex = objIndex.ToString();
        string strAlternatePriceOffer = string.Empty;
        switch (strIndex)
        {
            case "1":
                {
                    strAlternatePriceOffer = "User would like to get<strong class=\"colortitle\"> Best Offer</strong>.";
                    break;
                }
            case "2":
                {
                    strAlternatePriceOffer = "Please <strong class=\"colortitle\">Contact </strong>the User for pricing detail.";
                    break;
                }
            case "3":
                {
                    strAlternatePriceOffer = "User would like to <strong class=\"colortitle\">Exchange </strong>this product.";
                    break;
                }
            case "4":
                {
                    strAlternatePriceOffer = "User wants to provide this product/service for <strong class=\"colortitle\">Free</strong>.";
                    break;
                }
            case "5":
                {
                    strAlternatePriceOffer = "User's price is <strong class=\"colortitle\">Fixed</strong>.";
                    break;
                }
            case "6":
                {
                    strAlternatePriceOffer = "User describes this price as <strong class=\"colortitle\">Negotiable</strong>.";
                    break;
                }
        }
        return strAlternatePriceOffer;
    }

    private int AddRecord_ProductOrder(int intProductID, string strCustomerEmail, string strCustomerName, string strCustomerMessage)
    {

        int intActionStatus = 0;

        try
        {
            using (BOC_Classifieds_Orders bocProductOrder = new BOC_Classifieds_Orders())
            {
                EOC_PropertyBean eocProduct = new EOC_PropertyBean();

                eocProduct.Classifieds_ProductProfile_ProductID = intProductID;
                eocProduct.Classifieds_OrderDetail_CustomerEmail = strCustomerEmail;
                eocProduct.Classifieds_OrderDetail_CustomerName = strCustomerName;
                eocProduct.Classifieds_OrderDetail_CustomerMessage = strCustomerMessage;
                //eocProduct.UpdatedOn = DateTime.Now;

                intActionStatus = bocProductOrder.AddRecord_ProductOrder(eocProduct);
            }
        }
        catch (Exception Exp)
        {
            lblSystemMessage.Text = Exp.Message.ToString();
        }

        return intActionStatus;
    }


    private void Clear()
    {
        txtEmail.Text = "";
        txtName.Text = "";
        txtMessage.Text="";
        //txtCaptcha.Text = "";
    }
   

    protected void btnSend_Click(object sender, EventArgs e)
    {
       
        int intActionResult = 0;

        intActionResult = this.AddRecord_ProductOrder(Convert.ToInt32(this.ProductID), txtEmail.Text, txtName.Text, txtMessage.Text);

        if (intActionResult > 0)
        {
            this.SendEmail(Convert.ToInt32(this.ProductID));

            lblSystemMessage.Text = UTLUtilities.ShowSuccessMessage("Your message has been sent.");
            this.Clear();
            //Response.Redirect("ItemList_Classifieds.aspx?CID=" + this.CategoryID + "&Location=" + this.Location + "&CMSG=1");

            //Response.Redirect("ItemList_Classifieds.aspx?CID=" + this.CategoryID + "&SCID=" + this.SubcategoryID + "&Location=" + this.Location + "&AdType=" + this.AdvertisementType + "&CMSG=1");

        }
        else
        {
            Response.Redirect("ItemList_Classifieds.aspx?CID=" + this.CategoryID + "&SCID=" + this.SubcategoryID + "&Location=" + this.Location + "&AdType=" + this.AdvertisementType + "&CMSG=0");
        }
    }

    private void SendEmail(int _ProductID)
    {
        string mailMessage = string.Empty;
        try
        {
            using (BOC_Classifieds_Orders bocProductOrder = new BOC_Classifieds_Orders())
            {
                EOC_PropertyBean eocProduct = new EOC_PropertyBean();
                eocProduct.Classifieds_ProductProfile_ProductID = _ProductID;

                dtOrder = bocProductOrder.LoadList_Information_ClassifiedProducts(eocProduct);
                if (dtOrder.Rows.Count > 0)
                {
                    string strUrlContactSeller = Request.Url.ToString();
                    this.SendSeller_ConfirmationMail(dtOrder.Rows[0]["AdvertiserName"].ToString(), dtOrder.Rows[0]["LoginEmail"].ToString(), dtOrder, strUrlContactSeller);
                    this.SendBuyer_ConfirmationMail(txtName.Text, txtEmail.Text, dtOrder, strUrlContactSeller);
                }
                else
                    lblSystemMessage.Text = "Mail can't send. Amount is not fully received.";
            }
        }
        catch (Exception Exp)
        {
            Response.Write(Exp.Message.ToString());
        }
    }

    private void SendSeller_ConfirmationMail(string sellerName, string mailTo, DataTable dtOrderedItems, string strUrlContactSeller)
    {
        string mailMessage = string.Empty;
        string mailFrom = "order@apnerdeal.com";
        string MailBody = "One of our registered user has submit an order against your ad. Following are the ad's and interested users detail information.  ";


        string MailBody1 = "Interested user's Message is: " +@" ' "+ txtMessage.Text + @" '";

        string mailSubject = "Order from " + txtName.Text+" (ApnerDeal.com).";

        mailMessage = UTLUtilities.MailLogoHeader();
        mailMessage += "<div style=\"color:#000000; line-height:18px\">Dear <strong>Mr./Ms. " + sellerName + "</strong>,<br/>";
        mailMessage += "<br/>";
        mailMessage += Server.HtmlEncode(MailBody);
        mailMessage += "<br/><br/>";
        mailMessage += Server.HtmlEncode(MailBody1);
        mailMessage += "<br/><br/>";
        mailMessage += "</br></br>Please Click on the link for Detail:";
        mailMessage += "</br><a href=\"" + strUrlContactSeller + "\" target=\"blank\">" + strUrlContactSeller + "</a>";
       // mailMessage += "<strong>Profile ID: " + dtOrderedItems.Rows[0]["ProfileID"].ToString() + "</strong>";
        //mailMessage += "<br/><strong>Product Name: " + dtOrderedItems.Rows[0]["ProductTitle"].ToString() + "</strong>";
        mailMessage += "<br/><br/>";




        mailMessage += GetOrderDetail_Header();

        if (dtOrderedItems.Rows.Count > 0)
        {

            mailMessage += "<table id=\"OrderList\" style=\"width:100%; color:#000000; border:0px solid #EFEFE2\"";
            mailMessage += "cellspacing=\"0px\"  cellpadding=\"0px\">";
            for (int index = 0; index < dtOrderedItems.Rows.Count; index++)
            {
                string strBackgroundColor = "";
                if (index % 2 == 1)
                {
                    strBackgroundColor = "#F5F5F7";
                }
                else
                {
                    strBackgroundColor = "white";
                }
                mailMessage += "<tr style=\"vertical-align:top; background-color:" + strBackgroundColor + "\">";
                mailMessage += "<td  style=\"width:150px;padding:5px\">" + dtOrderedItems.Rows[index]["ProductTitle"].ToString() + "</td>";
                //mailMessage += "<td  style=\"width:80px;\">" + dtOrderedItems.Rows[index]["Quantity"].ToString() + "</td>";
                if (CategoryID == "9")
                {
                    mailMessage += "<td align=\"right\" style=\"width:80px;\">&nbsp;</td>";
                }
                else
                {
                    mailMessage += "<td  style=\"width:110px;\">" + dtOrderedItems.Rows[index]["SalePrice"].ToString() + "</td>";
                }
                //mailMessage += "</div><div><strong>Charge:<br/> </strong>" + dtOrderedItems.Rows[index]["CodCost"].ToString() + "</td>";
                // mailMessage += "<td  style=\"width:80px;padding:5px\">" + dtOrderedItems.Rows[index]["CodCost"].ToString() + "</td>";
                // mailMessage += "<td  style=\"width:90px;padding:5px\">" + dtOrderedItems.Rows[index]["Subtotal"].ToString() + "</td>";
                // mailMessage += "<td  style=\"width:90px;\">" + dtOrderedItems.Rows[index]["PaymentOption"].ToString() + "</td>";

                mailMessage += "<td class=\"columnheader\" style=\"font-weight:normal; line-height:17px;\">";
                //mailMessage += "<strong>Company Name: </strong>" + dtOrderedItems.Rows[index]["SellerInfo"].ToString() + "<br/>";
                // mailMessage += "<strong>Billing Person: </strong>" + dtOrderedItems.Rows[index]["Seller_BillingPerson"].ToString() + "<br /> ";
                mailMessage += "<strong>Buyer Name: </strong>" + txtName.Text + "<br/>";
                //mailMessage += "<strong>User Address: </strong>" + dtOrderedItems.Rows[index]["ContactAddress"].ToString() + "<br />";
                mailMessage += "<strong>LoginEmail: </strong>" + txtEmail.Text + "<br />";
                // mailMessage += "<strong>Website Url: </strong>" + dtOrderedItems.Rows[index]["Seller_URL"].ToString() + "<br />";
            }
            mailMessage += "</td></tr>";
            mailMessage += "<tr><td colspan=\"6\" style=\"text-align:center;line-height:25px\">";
            mailMessage += "<span style=\"color:#990000;font-weight:bold;font-family:verdana;\">";
            //mailMessage += "Total Amount: " + dtOrderedItems.Rows[0]["Currency"].ToString() + " " + dtOrderedItems.Rows[0]["SubTotal"].ToString() + "</span>";
            mailMessage += "</td></tr>";
            mailMessage += "</table></div>";
            mailMessage += "<div align=\"center\" style=\"color:red; margin-top:15px; text-align:left; font-weight:bold\">This is an auto generated mail. Please do not reply.</div>";
        }
        mailMessage += "</td></tr></table>";
        MailMaster.SendMail(mailTo, mailFrom, mailSubject, mailMessage);
    }

    private void SendBuyer_ConfirmationMail(string sellerName, string mailTo, DataTable dtOrderedItems, string strUrlContactSeller)
    {
        string mailMessage = string.Empty;
        string mailFrom = "order@apnerdeal.com";
        string MailBody = "Thank you for your order at ApnerDeal.com. This is an acknowledegement of your order. Please email to order@apnerdeal.com for further query.";

        string mailSubject = "Order from ApnerDeal.com";
        //string mailSubject = "Your ApnerDeal order no." + dtOrderedItems.Rows[0]["OrderID"].ToString();

        mailMessage = UTLUtilities.MailLogoHeader();
        mailMessage += "<div style=\"color:#000000; line-height:18px\">Dear <strong>Mr./Ms. " + sellerName + "</strong>,<br/>";
        mailMessage += "<br/>";
        mailMessage += Server.HtmlEncode(MailBody);
        mailMessage += "<br/><br/>";

        mailMessage += "</br></br>Please Click on the link for Detail:";
        mailMessage += "</br><a href=\"" + strUrlContactSeller + "\" target=\"blank\">" + strUrlContactSeller + "</a>";
      //  mailMessage += "<strong>Profile ID: " + dtOrderedItems.Rows[0]["ProfileID"].ToString() + "</strong>";
       // mailMessage += "<br/><strong>Product Name: " + dtOrderedItems.Rows[0]["ProductTitle"].ToString() + "</strong>";
        mailMessage += "<br/><br/>";
        


        mailMessage += GetOrderDetail_Header();

        if (dtOrderedItems.Rows.Count > 0)
        {

            mailMessage += "<table id=\"OrderList\" style=\"width:100%; color:#000000; border:0px solid #EFEFE2\"";
            mailMessage += "cellspacing=\"0px\"  cellpadding=\"0px\">";
            for (int index = 0; index < dtOrderedItems.Rows.Count; index++)
            {
                string strBackgroundColor = "";
                if (index % 2 == 1)
                {
                    strBackgroundColor = "#F5F5F7";
                }
                else
                {
                    strBackgroundColor = "white";
                }
                mailMessage += "<tr style=\"vertical-align:top; background-color:" + strBackgroundColor + "\">";
                mailMessage += "<td  style=\"width:150px;padding:5px\">" + dtOrderedItems.Rows[index]["ProductTitle"].ToString() + "</td>";
                //mailMessage += "<td  style=\"width:80px;\">" + dtOrderedItems.Rows[index]["Quantity"].ToString() + "</td>";
                if (CategoryID == "9")
                {
                    mailMessage += "<td align=\"right\" style=\"width:80px;\">&nbsp;</td>";
                }
                else
                {
                    mailMessage += "<td  style=\"width:110px;\">" + dtOrderedItems.Rows[index]["SalePrice"].ToString() + "</td>";
                }
                //mailMessage += "</div><div><strong>Charge:<br/> </strong>" + dtOrderedItems.Rows[index]["CodCost"].ToString() + "</td>";
               // mailMessage += "<td  style=\"width:80px;padding:5px\">" + dtOrderedItems.Rows[index]["CodCost"].ToString() + "</td>";
               // mailMessage += "<td  style=\"width:90px;padding:5px\">" + dtOrderedItems.Rows[index]["Subtotal"].ToString() + "</td>";
               // mailMessage += "<td  style=\"width:90px;\">" + dtOrderedItems.Rows[index]["PaymentOption"].ToString() + "</td>";

                mailMessage += "<td class=\"columnheader\" style=\"font-weight:normal;padding:5px; line-height:17px;\">";
                //mailMessage += "<strong>Company Name: </strong>" + dtOrderedItems.Rows[index]["SellerInfo"].ToString() + "<br/>";
               // mailMessage += "<strong>Billing Person: </strong>" + dtOrderedItems.Rows[index]["Seller_BillingPerson"].ToString() + "<br /> ";
                mailMessage += "<strong>Seller Cell No: </strong>" + dtOrderedItems.Rows[index]["Mobile"].ToString() + "<br/>";
                mailMessage += "<strong>Seller Address: </strong>" + dtOrderedItems.Rows[index]["ContactAddress"].ToString() + "<br />";
                mailMessage += "<strong>LoginEmail: </strong>" + dtOrderedItems.Rows[index]["LoginEmail"].ToString() + "<br />";
               // mailMessage += "<strong>Website Url: </strong>" + dtOrderedItems.Rows[index]["Seller_URL"].ToString() + "<br />";

            }
            mailMessage += "</td></tr>";
            mailMessage += "<tr><td colspan=\"6\" style=\"text-align:center;line-height:25px\">";
            mailMessage += "<span style=\"color:#990000;font-weight:bold;font-family:verdana;\">";
            //mailMessage += "Total Amount: " + dtOrderedItems.Rows[0]["Currency"].ToString() + " " + dtOrderedItems.Rows[0]["SubTotal"].ToString() + "</span>";
            mailMessage += "</td></tr>";
            mailMessage += "</table></div>";
            mailMessage += "<div align=\"center\" style=\"color:red; margin-top:15px; text-align:left; font-weight:bold\">This is an auto generated mail. Please do not reply.</div>";
        }
        mailMessage += "</td></tr></table>";
        MailMaster.SendMail(mailTo, mailFrom, mailSubject, mailMessage);
    }   

    private string GetOrderDetail_Header()
    {
        string strOrderDetailHeader = string.Empty;
        strOrderDetailHeader = "<table width=\"100%\" border=\"0px\" cellspacing=\"0px\" cellpadding=\"0px\" style=\"border-bottom:";
        strOrderDetailHeader += "1px solid #d5d5d5; margin-bottom:15px;\">";
        strOrderDetailHeader += "<tr>";
        strOrderDetailHeader += "<td width=\"3px\"><img src=\"http://www.apnerdeal.com/images/title_bar_left.gif\" width=\"3px\"";
        strOrderDetailHeader += "height=\"28px\" alt=\"\" /></td>";

        strOrderDetailHeader += "<td width=\"600px\" style=\"background-image:url(http://www.apnerdeal.com/images/title_bar_bg.gif);";
        strOrderDetailHeader += "background-repeat:repeat-x; padding-left:5px;\">";
        strOrderDetailHeader += "Ordered Items";
        strOrderDetailHeader += "</td>";
        strOrderDetailHeader += "<td width=\"3px\"><img src=\"http://www.apnerdeal.com/images/title_bar_right.gif\" width=\"3px\" ";
        strOrderDetailHeader += "height=\"28px\" alt=\"\" /></td>";
        strOrderDetailHeader += "<td align=\"right\">&nbsp;</td>";
        strOrderDetailHeader += "</tr>";
        strOrderDetailHeader += "</table>";

        strOrderDetailHeader += "<table id=\"OrderListHeader\"  style=\"width:100%;margin-top:0px;color:black;";
        strOrderDetailHeader += "background-color:#EFEFE2\"  cellspacing=\"0px\" cellpadding=\"0px\" border=\"0px\">";
        strOrderDetailHeader += "<thead>";
        strOrderDetailHeader += "<tr style=\"text-align:left;line-height:25px\">";
        strOrderDetailHeader += "<th style=\"width:150px; \">Product Name</th>";
        //strOrderDetailHeader += "<th style=\"width:80px; \">Quantity</th>";
        if (CategoryID == "9")
        {
            strOrderDetailHeader += "<th style=\"width:100px;\">&nbsp;</th>";
        }
        else
        {
            strOrderDetailHeader += "<th style=\"width:120px;\">Price</th>";
        }
        //strOrderDetailHeader += "<th style=\"width:80px;\">Charge</th>";
        //strOrderDetailHeader += "<th style=\"width:90px;\">Subtotal</th>";
        //strOrderDetailHeader += "<th style=\"width:120px;\">Delivery Option</th>";
        strOrderDetailHeader += "<th style=\"font-weight:bold;\">Information</th>";
        strOrderDetailHeader += "</tr>";
        strOrderDetailHeader += "</thead>";
        strOrderDetailHeader += "</table>";
        return strOrderDetailHeader;

    }

    private int AddRecord_ProductReview(int intProductID, string strCriticsName, string strReview)
    {
        int intActionStatus = 0;

        try
        {
            using (BOC_Classifieds_Orders bocProductReview = new BOC_Classifieds_Orders())
            {
                EOC_PropertyBean eocReview = new EOC_PropertyBean();

                eocReview.Classifieds_ProductProfile_ProductID = intProductID;
                eocReview.ProductReview_Classified_CriticsName = strCriticsName;
                eocReview.ProductReview_Classified_Review = strReview;

                intActionStatus = bocProductReview.AddRecord_ProductReview(eocReview);
            }
        }
        catch (Exception Exp)
        {
            lblSystemMessage.Text = Exp.Message.ToString();
        }

        return intActionStatus;
    }

    private void LoadRecord_ProductReview(int intProductID)
    {
        try
        {
            using (BOC_Classifieds_Orders bocProductReview = new BOC_Classifieds_Orders())
            {
                EOC_PropertyBean eocReview = new EOC_PropertyBean();

                eocReview.Classifieds_ProductProfile_ProductID = intProductID;

                DataTable dtReview = bocProductReview.LoadRecord_ProductReview(eocReview);

                if (dtReview.Rows.Count > 0)
                {
                    Repeater1.DataSource = dtReview;
                    Repeater1.DataBind();
                }
            }

        }
        catch (Exception Exp)
        {
            lblSystemMessage.Text = Exp.Message.ToString();
        }
    }

    protected void btnPost_Click(object sender, EventArgs e)
    {
        bool blnFlag = false;

        if (string.IsNullOrEmpty(txtCriticsName.Text) || string.IsNullOrEmpty(txtComments.Text))
        {
            blnFlag = false;

            if (string.IsNullOrEmpty(txtCriticsName.Text))
            {
                lblCriticsName.Text = "Name is required!";
            }

            if (string.IsNullOrEmpty(txtComments.Text))
            {
                lblComments.Text = "Comments is required!";
            }
        }
        else
        {
            blnFlag = true;
        }

        if (blnFlag == true)
        {
            int i = this.AddRecord_ProductReview(Convert.ToInt32(this.ProductID), txtCriticsName.Text, txtComments.Text);
            this.LoadRecord_ProductReview(Convert.ToInt32(this.ProductID));

            txtCriticsName.Text = "";
            txtComments.Text = "";
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        this.ProductID = Request.QueryString["ItemKey"];
        this.ProfileID = Request.QueryString["ProfKey"];
        this.CategoryID = Request.QueryString["CID"];
        this.SubcategoryID = Request.QueryString["SCID"];
        this.Location = Request.QueryString["Location"];
        this.AdvertisementType = Request.QueryString["AdType"];
        string strHtml = "";

        if (UTLUtilities.IsNumeric(this.ProductID) && UTLUtilities.IsNumeric(this.ProfileID) && UTLUtilities.IsNumeric(this.CategoryID) && UTLUtilities.IsNumeric(this.SubcategoryID))
        {
            this.IsProfileFound = this.SelectRecord_ProductProfile(Convert.ToInt32(this.ProductID), Convert.ToInt32(this.ProfileID));
            //lblLocationn.Text = this.Location;
            txtProductID.Text = this.ProductID;
            string strAdvertisementType = string.Empty;
            //strAdvertisementType = GetOfferType(this.CategoryID, dtProductProfile.Rows[0]["AdvertiseMentType"].ToString());
            if (IsProfileFound)
            {

                this.LoadRecord_ProductReview(Convert.ToInt32(this.ProductID));
                if (CategoryID == "9")
                {
                    pnlPrice.Visible = false;
                    pnlAlternatePriceOffer.Visible = false;
                }
                else
                {
                    pnlPrice.Visible = true;
                }
            }
            else
            {
                strHtml = "This product may have been removed by the administrator.";
                strHtml = UTLUtilities.Encrypt(strHtml);
                Response.Redirect("Error.aspx?data=" + strHtml);
            }
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
    }
}
