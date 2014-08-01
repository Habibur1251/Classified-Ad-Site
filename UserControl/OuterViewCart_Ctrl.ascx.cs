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

public partial class UserControl_OuterViewCart_Ctrl : System.Web.UI.UserControl
{
    

    protected string _CartSummary = "";
    private void LoadCart_Summary()
    {
        try
        {
            using (ShoppingCartAccess cart = new ShoppingCartAccess())
            {
                DataTable dt = cart.ShoppingCart_GetCartSummary();
                if (dt.Rows.Count > 0)
                {
                    _CartSummary = dt.Rows[0]["Quantity"].ToString() + " items<br/>";
                    _CartSummary += "Total :" + dt.Rows[0]["TotalAmount"].ToString() + " " + dt.Rows[0]["Currency"].ToString();
                }
                else
                {
                    _CartSummary = "Your cart is empty.";
                }
            }
        }
        catch (Exception ex)
        {
 
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        this.LoadCart_Summary();
    }
}
