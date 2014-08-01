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

public partial class UserControl_ProductInfo_Ctrl : System.Web.UI.UserControl
{

    public string ProductTitle
    {
        set { lblProductTitle.Text = value; }
    }



    public string Model
    {
        set { lblModel.Text = value; }
    }


    public string SecondSubcategory
    {
        set { lblSecondSubcategory.Text = value; }
    }


    public string Subcategory
    {
        set { lblSubcategory.Text = value; }
    }


    public string Category
    {
        set { lblCategory.Text = value; }
    }


    public string Sku
    {
        set { lblSku.Text = value; }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        //lblSku.Text = Sku;
        //lblCategory.Text = Category;
        //lblSubcategory.Text = Subcategory;
        //lblSecondSubcategory.Text = SecondSubcategory;
        //lblModel.Text = Model;
        //lblProductTitle.Text = ProductTitle;
    }
}
