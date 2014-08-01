using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class CommentDiscount : System.Web.UI.Page
{
    private int intProfileID = 0;
    private int intCouponID = 0;

    protected void Page_PreRender(object sender, EventArgs e)
    {
        ViewState["intProfileID"] = intProfileID;
        ViewState["intCouponID"] = intCouponID;
    }

    protected void Page_Init(object sender, EventArgs e)
    {

        if (Convert.ToInt32(Request.QueryString["PI"]) > 0 && Convert.ToInt32(Request.QueryString["CI"]) > 0)
        {
            intProfileID = Convert.ToInt32(ViewState["PI"]);
            intCouponID = Convert.ToInt32(ViewState["CI"]);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToInt32(Request.QueryString["PI"]) > 0 && Convert.ToInt32(Request.QueryString["CI"]) > 0)
        {
            intProfileID = Convert.ToInt32(Request.QueryString["PI"]);
            intCouponID = Convert.ToInt32(Request.QueryString["CI"]);
        }
        else
        {
        }
    }

    protected void csvReq_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (txtEmailAddress.Text == "" || txtName.Text == "" || txtSubject.Text == "" || txtReport.Text == "")
        {
            args.IsValid = false;
        }
        else
        {
            args.IsValid = true;
        }

    }

    private int AddComment()
    {
        int intActionResult = -1;
        DiscountZone discountZone = new DiscountZone();
        DiscountManegar manager = new DiscountManegar();
        discountZone.ProfileID = intProfileID;
        discountZone.CouponID = intCouponID;
        discountZone.EmailAddress = txtEmailAddress.Text.ToString();
        discountZone.Name = txtName.Text.ToString();
        discountZone.Subject = txtSubject.Text.ToString();
        discountZone.Comment = txtReport.Text.ToString();
        try
        {
            intActionResult = manager.Ad_Comment(discountZone);
        }
        catch (Exception ex)
        {
            multiview.ActiveViewIndex = 2;
            lblSystemMessage.Text = ex.Message;
        }
        return intActionResult;
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        int intActionStatus = 0;
        if (Page.IsValid)
        {

            intActionStatus = this.AddComment();

        }
        else
        {
            //
        }
        if (intActionStatus == 0)
        {
            multiview.ActiveViewIndex = 2;
        }
        else if (intActionStatus > 0)
        {
            multiview.ActiveViewIndex = 1;
        }

    }
    protected void btnPrev_Click(object sender, EventArgs e)
    {

    }
}
