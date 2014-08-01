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

public partial class UserControl_HP_LatestClassifiedsAds : System.Web.UI.UserControl
{
    private void GenerateLatestClassifieds(string _Country)
    {
        string strHtml = string.Empty;
        string strURL = string.Empty;
        string strFilePath = string.Empty;
        string strEncrypt = string.Empty;
        string strDecrypt = string.Empty;
        string strAdvertisementType = string.Empty;
        string AdvertisementType = string.Empty;
        //DataTable dtLatestProduct = null;

        try
        {
            using (HomePageHandler homePageHandler = new HomePageHandler())
            {
                EOC_PropertyBean eocPropertyBean = new EOC_PropertyBean();
                eocPropertyBean.Country_CountryID = Convert.ToInt32(_Country);
                //eocPropertyBean.AdvertisementType = "Want";

                DataTable dtLatestProduct = homePageHandler.LoadRecord_02_LatestClassifieds(eocPropertyBean);

                if (dtLatestProduct.Rows.Count > 0)
                {
                    repWant.DataSource = dtLatestProduct;
                    repWant.DataBind();
                }
                else
                {
                    repWant.DataSource = null;
                    repWant.DataBind();

                }

                //eocPropertyBean.AdvertisementType = "Offer";
                //DataTable dtLatestOfferedProduct = homePageHandler.LoadRecord_02_LatestClassifieds(eocPropertyBean);
                //if (dtLatestOfferedProduct.Rows.Count > 0)
                //{
                //    repOffer.DataSource = dtLatestOfferedProduct;
                //    repOffer.DataBind();
                //}

            }
        }
        catch(Exception ex)
        {
            lblSystemMessage.Text = ex.Message;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        GenerateLatestClassifieds("18");
    }
}
