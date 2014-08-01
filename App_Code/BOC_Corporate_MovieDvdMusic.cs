using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Collections;
using System.Data.SqlClient;

/// <summary>
/// Summary description for BOC_Corporate_MovieDvdMusic
/// </summary>
public class BOC_Corporate_MovieDvdMusic : UTLDBHandler
{
    public BOC_Corporate_MovieDvdMusic() : base(UTLUtilities.Database.DbConnectionString)
	{
		//
		// TODO: Add constructor logic here
		//
	}

    /// <summary>
    ///  Inserts a new row in both Product_Master_MovieDvdMusic and Product_Detail_MovieDvdMusic table.
    /// USP: USP_CP_Public_Insert_Master_BookProduct
    /// </summary>
    /// <param name="eocPropertyBean"></param>
    /// <returns></returns>
    public int Insert_MasterRecord_MovieDvdProduct(EOC_PropertyBean eocPropertyBean)
    {
        int intActionResult = 0;
        string strOutputValue = string.Empty;
        //bool canEditProduct = true;

        try
        {
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@ProfileID", eocPropertyBean.Business_UserProfile_ProfileID.ToString()));
            arlSQLParameters.Add(new SqlParameter("@SKU", eocPropertyBean.Business_ProductProfile_Books_SKU));
            arlSQLParameters.Add(new SqlParameter("@CategoryID", eocPropertyBean.Category_CategoryID.ToString()));
            arlSQLParameters.Add(new SqlParameter("@SubcategoryID", eocPropertyBean.Subcategory_SubcategoryID.ToString()));

            arlSQLParameters.Add(new SqlParameter("@SecondSubcatID", eocPropertyBean.SecondSubcategory_SubcategoryID.ToString()));
            arlSQLParameters.Add(new SqlParameter("@ProductTitle", eocPropertyBean.Business_ProductProfile_Books_BookTitle));
            arlSQLParameters.Add(new SqlParameter("@ProductDesc", eocPropertyBean.Business_ProductProfile_Description));
            arlSQLParameters.Add(new SqlParameter("@Qty", eocPropertyBean.Business_ProductProfile_Quantity.ToString()));

            arlSQLParameters.Add(new SqlParameter("@Currency", eocPropertyBean.Business_ProductProfile_Books_Currency));
            arlSQLParameters.Add(new SqlParameter("@Price", eocPropertyBean.Business_ProductProfile_Books_ProductPrice));
            arlSQLParameters.Add(new SqlParameter("@IsNegotiable", eocPropertyBean.IsNegotiable));

            arlSQLParameters.Add(new SqlParameter("@DiscountPrice", eocPropertyBean.Business_ProductProfile_Books_SalePrice));
            arlSQLParameters.Add(new SqlParameter("@DisStartDate", eocPropertyBean.Business_ProductProfile_Books_StartDate.ToString()));

            arlSQLParameters.Add(new SqlParameter("@DisEndDate", eocPropertyBean.Business_ProductProfile_Books_EndDate.ToString()));
            arlSQLParameters.Add(new SqlParameter("@Condition", eocPropertyBean.Business_Product_Profile_Books_Condition.ToString()));
            arlSQLParameters.Add(new SqlParameter("@ConditionNote", eocPropertyBean.Business_Product_Profile_Books_ConditionNote.ToString()));
            //arlSQLParameters.Add(new SqlParameter("@PaymentOption", eocPropertyBean.Business_ProductProfile_Books_PaymentOption));

            arlSQLParameters.Add(new SqlParameter("@CashOnDelivery", eocPropertyBean.Business_ProductProfile_CashOnDelivery));
            arlSQLParameters.Add(new SqlParameter("@PickFromStore", eocPropertyBean.Business_ProductProfile_PickFromStore));
            arlSQLParameters.Add(new SqlParameter("@CashDeposit", eocPropertyBean.Business_ProductProfile_CashDeposit));
            arlSQLParameters.Add(new SqlParameter("@SellerForeignAddress", eocPropertyBean.Business_ProductProfile_SellerForeignAddress));




            arlSQLParameters.Add(new SqlParameter("@DeliveryArea", eocPropertyBean.Business_ProductProfile_General_DeliveryArea));
            //arlSQLParameters.Add(new SqlParameter("@CodCost", eocPropertyBean.Business_ProductProfile_Books_CashOnDeliveryCost));
            arlSQLParameters.Add(new SqlParameter("@MovieType", eocPropertyBean.Business_ProductProfile_Books_PaperBackForBook.ToString()));
            arlSQLParameters.Add(new SqlParameter("@Duration", eocPropertyBean.Business_Product_Profile_Books_DimensionForBook.ToString()));

            arlSQLParameters.Add(new SqlParameter("@ShippingWeight", eocPropertyBean.Business_Product_Profile_Books_ShippingWeight.ToString()));
            arlSQLParameters.Add(new SqlParameter("@Edition", eocPropertyBean.Business_ProductProfile_Books_Edition));          
            arlSQLParameters.Add(new SqlParameter("@Author", eocPropertyBean.Business_ProductProfile_Books_Author));
            arlSQLParameters.Add(new SqlParameter("@Publisher", eocPropertyBean.Business_ProductProfile_Books_Publisher));

            arlSQLParameters.Add(new SqlParameter("@ProductImage", eocPropertyBean.Business_ProductProfile_Books_ProductImage));
            arlSQLParameters.Add(new SqlParameter("@MasterUpdatedOn", eocPropertyBean.UpdatedOn.ToString()));
            arlSQLParameters.Add(new SqlParameter("@DetailUpdatedOn", eocPropertyBean.UpdatedOn.ToString()));
            arlSQLParameters.Add(new SqlParameter("@Language", eocPropertyBean.Business_Product_Profile_Books_Language.ToString()));

            arlSQLParameters.Add(new SqlParameter("@IsActive", eocPropertyBean.Business_ProductProfile_IsActive));
            arlSQLParameters.Add(new SqlParameter("@SellerType", eocPropertyBean.UserType));
            arlSQLParameters.Add(new SqlParameter("@Source", eocPropertyBean.Source));
            arlSQLParameters.Add(new SqlParameter("@IsAlternativeAddress", eocPropertyBean.Is_Alternative_Address));



            intActionResult = this.ExecuteActionQuery("USP_CP_Public_Insert_Master_MovieDvdProduct", arlSQLParameters);
        }
        catch
        {
            throw;
        }

        return intActionResult;
    }

    /// <summary>
    ///  Inserts new row in the table Product_Detail_Book table using productID of Master table
    /// </summary>
    /// <param name="eocPropertyBean"></param>
    /// <returns></returns>
    public int Insert_DetailRecord_MovieDvdProduct(EOC_PropertyBean eocPropertyBean)
    {
        int intActionResult = 0;
        string strOutputValue = string.Empty;
        

        try
        {
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Add(new SqlParameter("@ProductID", eocPropertyBean.Business_ProductProfile_Books_ProductID.ToString()));
            arlSQLParameters.Add(new SqlParameter("@ProfileID", eocPropertyBean.Business_UserProfile_ProfileID.ToString()));
            arlSQLParameters.Add(new SqlParameter("@SKU", eocPropertyBean.Business_ProductProfile_Books_SKU));

            arlSQLParameters.Add(new SqlParameter("@ProductDesc", eocPropertyBean.Business_ProductProfile_Description));
            arlSQLParameters.Add(new SqlParameter("@Qty", eocPropertyBean.Business_ProductProfile_Quantity.ToString()));
            arlSQLParameters.Add(new SqlParameter("@Currency", eocPropertyBean.Business_ProductProfile_Books_Currency));
            arlSQLParameters.Add(new SqlParameter("@Price", eocPropertyBean.Business_ProductProfile_Books_ProductPrice));
            arlSQLParameters.Add(new SqlParameter("@IsNegotiable", eocPropertyBean.IsNegotiable));

            arlSQLParameters.Add(new SqlParameter("@DiscountPrice", eocPropertyBean.Business_ProductProfile_Books_SalePrice));
            arlSQLParameters.Add(new SqlParameter("@DisStartDate", eocPropertyBean.Business_ProductProfile_Books_StartDate.ToString()));
            arlSQLParameters.Add(new SqlParameter("@DisEndDate", eocPropertyBean.Business_ProductProfile_Books_EndDate.ToString()));
            arlSQLParameters.Add(new SqlParameter("@Condition", eocPropertyBean.Business_Product_Profile_Books_Condition.ToString()));

            arlSQLParameters.Add(new SqlParameter("@ConditionNote", eocPropertyBean.Business_Product_Profile_Books_ConditionNote.ToString()));
            arlSQLParameters.Add(new SqlParameter("@CashOnDelivery", eocPropertyBean.Business_ProductProfile_CashOnDelivery));
            arlSQLParameters.Add(new SqlParameter("@PickFromStore", eocPropertyBean.Business_ProductProfile_PickFromStore));
            arlSQLParameters.Add(new SqlParameter("@CashDeposit", eocPropertyBean.Business_ProductProfile_CashDeposit));

            arlSQLParameters.Add(new SqlParameter("@SellerForeignAddress", eocPropertyBean.Business_ProductProfile_SellerForeignAddress));
            arlSQLParameters.Add(new SqlParameter("@DeliveryArea", eocPropertyBean.Business_ProductProfile_General_DeliveryArea));
            arlSQLParameters.Add(new SqlParameter("@MovieType", eocPropertyBean.Business_ProductProfile_Books_PaperBackForBook.ToString()));
            arlSQLParameters.Add(new SqlParameter("@Duration", eocPropertyBean.Business_Product_Profile_Books_DimensionForBook.ToString()));

            arlSQLParameters.Add(new SqlParameter("@Language", eocPropertyBean.Business_Product_Profile_Books_Language.ToString()));
            arlSQLParameters.Add(new SqlParameter("@ShippingWeight", eocPropertyBean.Business_Product_Profile_Books_ShippingWeight.ToString()));
            arlSQLParameters.Add(new SqlParameter("@DetailUpdatedOn", eocPropertyBean.UpdatedOn.ToString()));
            arlSQLParameters.Add(new SqlParameter("@IsActive", eocPropertyBean.Business_ProductProfile_IsActive));
            arlSQLParameters.Add(new SqlParameter("@SellerType", eocPropertyBean.UserType));

            arlSQLParameters.Add(new SqlParameter("@Source", eocPropertyBean.Source));
            arlSQLParameters.Add(new SqlParameter("@IsAlternativeAddress", eocPropertyBean.Is_Alternative_Address));

            intActionResult = this.ExecuteActionQuery("USP_CP_Public_Insert_TagSeller_MovieDvdProduct", arlSQLParameters);

        }
        catch
        {
            throw;
        }

        return intActionResult;
    }


    /// <summary>
    /// Updates both Product_Master_Book and Product_Seller_Detail_Book table. 
    /// In master table Updates ISBN, Author.
    /// USP: USP_CP_Public_Update_MasterSeller_BookRecord
    /// </summary>
    /// <param name="eocPropertyBean"></param>
    /// <returns></returns>
    public int Update_MasterSeller_MovieDvdProduct(EOC_PropertyBean eocPropertyBean)
    {
        int intActionResult = 0;
        string strOutputValue = string.Empty;
        
        try
        {
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@ProfileID", eocPropertyBean.Business_UserProfile_ProfileID.ToString()));
            arlSQLParameters.Add(new SqlParameter("@ProductID", eocPropertyBean.Business_ProductProfile_Books_ProductID.ToString()));
            arlSQLParameters.Add(new SqlParameter("@CategoryID", eocPropertyBean.Category_CategoryID.ToString()));

            arlSQLParameters.Add(new SqlParameter("@SubcategoryID", eocPropertyBean.Subcategory_SubcategoryID.ToString()));
            arlSQLParameters.Add(new SqlParameter("@SecondSubcatID", eocPropertyBean.SecondSubcategory_SubcategoryID.ToString()));
            arlSQLParameters.Add(new SqlParameter("@ProductDesc", eocPropertyBean.Business_ProductProfile_Description));

            arlSQLParameters.Add(new SqlParameter("@Qty", eocPropertyBean.Business_ProductProfile_Quantity.ToString()));
            arlSQLParameters.Add(new SqlParameter("@Currency", eocPropertyBean.Business_ProductProfile_Books_Currency));
            arlSQLParameters.Add(new SqlParameter("@Price", eocPropertyBean.Business_ProductProfile_Books_ProductPrice));
            arlSQLParameters.Add(new SqlParameter("@IsNegotiable", eocPropertyBean.IsNegotiable));

            arlSQLParameters.Add(new SqlParameter("@DiscountPrice", eocPropertyBean.Business_ProductProfile_Books_SalePrice));
            arlSQLParameters.Add(new SqlParameter("@DisStartDate", eocPropertyBean.Business_ProductProfile_Books_StartDate.ToString()));
            arlSQLParameters.Add(new SqlParameter("@DisEndDate", eocPropertyBean.Business_ProductProfile_Books_EndDate.ToString()));

            arlSQLParameters.Add(new SqlParameter("@Condition", eocPropertyBean.Business_Product_Profile_Books_Condition.ToString()));
            arlSQLParameters.Add(new SqlParameter("@ConditionNote", eocPropertyBean.Business_Product_Profile_Books_ConditionNote.ToString()));
            //arlSQLParameters.Add(new SqlParameter("@PaymentOption", eocPropertyBean.Business_ProductProfile_Books_PaymentOption));

            arlSQLParameters.Add(new SqlParameter("@CashOnDelivery", eocPropertyBean.Business_ProductProfile_CashOnDelivery));
            arlSQLParameters.Add(new SqlParameter("@PickFromStore", eocPropertyBean.Business_ProductProfile_PickFromStore));
            arlSQLParameters.Add(new SqlParameter("@CashDeposit", eocPropertyBean.Business_ProductProfile_CashDeposit));

            arlSQLParameters.Add(new SqlParameter("@SellerForeignAddress", eocPropertyBean.Business_ProductProfile_SellerForeignAddress));
            arlSQLParameters.Add(new SqlParameter("@DeliveryArea", eocPropertyBean.Business_ProductProfile_General_DeliveryArea));
            arlSQLParameters.Add(new SqlParameter("@MovieType", eocPropertyBean.Business_ProductProfile_Books_PaperBackForBook.ToString()));

            arlSQLParameters.Add(new SqlParameter("@Language", eocPropertyBean.Business_Product_Profile_Books_Language.ToString()));
            arlSQLParameters.Add(new SqlParameter("@Duration", eocPropertyBean.Business_Product_Profile_Books_DimensionForBook.ToString()));
            arlSQLParameters.Add(new SqlParameter("@ShippingWeight", eocPropertyBean.Business_Product_Profile_Books_ShippingWeight.ToString()));
            arlSQLParameters.Add(new SqlParameter("@Edition", eocPropertyBean.Business_ProductProfile_Books_Edition));

            
            arlSQLParameters.Add(new SqlParameter("@Author", eocPropertyBean.Business_ProductProfile_Books_Author));
            arlSQLParameters.Add(new SqlParameter("@Publisher", eocPropertyBean.Business_ProductProfile_Books_Publisher));
            arlSQLParameters.Add(new SqlParameter("@MasterUpdatedOn", eocPropertyBean.UpdatedOn.ToString()));
            arlSQLParameters.Add(new SqlParameter("@DetailUpdatedOn", eocPropertyBean.UpdatedOn.ToString()));

            arlSQLParameters.Add(new SqlParameter("@SellerType", eocPropertyBean.UserType.ToString()));
            arlSQLParameters.Add(new SqlParameter("@IsActive", eocPropertyBean.Business_ProductProfile_IsActive));
            arlSQLParameters.Add(new SqlParameter("@ProductImage", eocPropertyBean.Business_ProductProfile_Books_ProductImage.ToString()));
            arlSQLParameters.Add(new SqlParameter("@Source", eocPropertyBean.Source));
            arlSQLParameters.Add(new SqlParameter("@IsAlternativeAddress", eocPropertyBean.Is_Alternative_Address));


            intActionResult = this.ExecuteActionQuery("USP_CP_Public_Update_MasterSeller_MovieDvdRecord", arlSQLParameters);
        }
        catch
        {
            throw;
        }

        return intActionResult;
    }


    /// <summary>
    /// Update Product_Seller_Detail_Book table.
    /// USP: USP_CP_Public_Update_TagSeller_BookRecord
    /// </summary>
    /// <param name="eocPropertyBean"></param>
    /// <returns></returns>
    public int Update_TagSeller_MovieDvdRecord(EOC_PropertyBean eocPropertyBean)
    {
        int intActionResult = 0;        

        try
        {
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Add(new SqlParameter("@ProductID", eocPropertyBean.Business_ProductProfile_Books_ProductID.ToString()));
            arlSQLParameters.Add(new SqlParameter("@ProfileID", eocPropertyBean.Business_UserProfile_ProfileID.ToString()));
            arlSQLParameters.Add(new SqlParameter("@ProductDesc", eocPropertyBean.Business_ProductProfile_Description));
            arlSQLParameters.Add(new SqlParameter("@Qty", eocPropertyBean.Business_ProductProfile_Quantity.ToString()));

            arlSQLParameters.Add(new SqlParameter("@Currency", eocPropertyBean.Business_ProductProfile_Books_Currency));
            arlSQLParameters.Add(new SqlParameter("@Price", eocPropertyBean.Business_ProductProfile_Books_ProductPrice));
            arlSQLParameters.Add(new SqlParameter("@IsNegotiable", eocPropertyBean.IsNegotiable));
            arlSQLParameters.Add(new SqlParameter("@DiscountPrice", eocPropertyBean.Business_ProductProfile_Books_SalePrice));

            arlSQLParameters.Add(new SqlParameter("@DisStartDate", eocPropertyBean.Business_ProductProfile_Books_StartDate.ToString()));
            arlSQLParameters.Add(new SqlParameter("@DisEndDate", eocPropertyBean.Business_ProductProfile_Books_EndDate.ToString()));
            arlSQLParameters.Add(new SqlParameter("@Condition", eocPropertyBean.Business_Product_Profile_Books_Condition.ToString()));
            arlSQLParameters.Add(new SqlParameter("@ConditionNote", eocPropertyBean.Business_Product_Profile_Books_ConditionNote.ToString()));

            arlSQLParameters.Add(new SqlParameter("@CashOnDelivery", eocPropertyBean.Business_ProductProfile_CashOnDelivery));
            arlSQLParameters.Add(new SqlParameter("@PickFromStore", eocPropertyBean.Business_ProductProfile_PickFromStore));
            arlSQLParameters.Add(new SqlParameter("@CashDeposit", eocPropertyBean.Business_ProductProfile_CashDeposit));
            arlSQLParameters.Add(new SqlParameter("@SellerForeignAddress", eocPropertyBean.Business_ProductProfile_SellerForeignAddress));


            arlSQLParameters.Add(new SqlParameter("@DeliveryArea", eocPropertyBean.Business_ProductProfile_General_DeliveryArea));
            arlSQLParameters.Add(new SqlParameter("@MovieType", eocPropertyBean.Business_ProductProfile_Books_PaperBackForBook.ToString()));
            arlSQLParameters.Add(new SqlParameter("@Language", eocPropertyBean.Business_Product_Profile_Books_Language.ToString()));
            arlSQLParameters.Add(new SqlParameter("@Duration", eocPropertyBean.Business_Product_Profile_Books_DimensionForBook.ToString()));

            arlSQLParameters.Add(new SqlParameter("@ShippingWeight", eocPropertyBean.Business_Product_Profile_Books_ShippingWeight.ToString()));
            arlSQLParameters.Add(new SqlParameter("@DetailUpdatedOn", eocPropertyBean.UpdatedOn.ToString()));
            arlSQLParameters.Add(new SqlParameter("@IsActive", eocPropertyBean.Business_ProductProfile_IsActive));
            arlSQLParameters.Add(new SqlParameter("@SellerType", eocPropertyBean.UserType));

            arlSQLParameters.Add(new SqlParameter("@Source", eocPropertyBean.Source));
            arlSQLParameters.Add(new SqlParameter("@IsAlternativeAddress", eocPropertyBean.Is_Alternative_Address));

            intActionResult = this.ExecuteActionQuery("USP_CP_Public_Update_TagSeller_MovieDvdRecord", arlSQLParameters);

        }
        catch
        {
            throw;
        }

        return intActionResult;

    }

}
