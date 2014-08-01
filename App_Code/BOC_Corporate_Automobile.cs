using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Collections;

/// <summary>
/// Summary description for BOC_Corporate_Automobile
/// </summary>
public class BOC_Corporate_Automobile : UTLDBHandler
{
	public BOC_Corporate_Automobile():base(UTLUtilities.Database.DbConnectionString)
	{
		//
		// TODO: Add constructor logic here
		//
	}
    /// <summary>
    ///  Inserts a new Automobile Record.
    /// USP: USP_CP_Public_Insert_Master_COM_LAP_ACC
    /// </summary>
    /// <param name="eocPropertyBean"></param>
    /// <returns></returns>
    public int Insert_MasterRecord_Automobile(EOC_PropertyBean eocPropertyBean)
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
            arlSQLParameters.Add(new SqlParameter("@ProductModelID", eocPropertyBean.Model_ModelID.ToString()));
            arlSQLParameters.Add(new SqlParameter("@ProductTitle", eocPropertyBean.Business_ProductProfile_Books_BookTitle));
            arlSQLParameters.Add(new SqlParameter("@ProductDesc", eocPropertyBean.Business_ProductProfile_Description));

            arlSQLParameters.Add(new SqlParameter("@Qty", eocPropertyBean.Business_ProductProfile_Quantity.ToString()));
            arlSQLParameters.Add(new SqlParameter("@Currency", eocPropertyBean.Business_ProductProfile_Books_Currency));
            arlSQLParameters.Add(new SqlParameter("@Price", eocPropertyBean.Business_ProductProfile_Books_ProductPrice));

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
            arlSQLParameters.Add(new SqlParameter("@ProductImage", eocPropertyBean.Business_ProductProfile_Books_ProductImage));

            arlSQLParameters.Add(new SqlParameter("@UpdatedOn", eocPropertyBean.UpdatedOn.ToString()));
            arlSQLParameters.Add(new SqlParameter("@IsActive", eocPropertyBean.Business_ProductProfile_IsActive));
            arlSQLParameters.Add(new SqlParameter("@SellerType", eocPropertyBean.UserType));
            arlSQLParameters.Add(new SqlParameter("@IsNegotiable", eocPropertyBean.IsNegotiable));



            arlSQLParameters.Add(new SqlParameter("@CarSubModel", eocPropertyBean.Automobile_CarSubModel));
            arlSQLParameters.Add(new SqlParameter("@VIN", eocPropertyBean.Automobile_VIN));
            arlSQLParameters.Add(new SqlParameter("@Mileage", eocPropertyBean.Automobile_Mileage));
            arlSQLParameters.Add(new SqlParameter("@VehicleRegYear", eocPropertyBean.Automobile_VehicleRegYear));

            arlSQLParameters.Add(new SqlParameter("@ProductYear", eocPropertyBean.Business_Product_ProductYear));

            arlSQLParameters.Add(new SqlParameter("@Source", eocPropertyBean.Source));
            arlSQLParameters.Add(new SqlParameter("@IsAlternativeAddress", eocPropertyBean.Is_Alternative_Address));




            intActionResult = this.ExecuteActionQuery("USP_CP_Public_Insert_Master_CAR_MC", arlSQLParameters);
        }
        catch
        {
            throw;
        }

        return intActionResult;
    }



    /// <summary>
    /// Inserts new row in the table Product_Detail_Mobile table using productID of Master table
    /// USP: USP_CP_Public_Insert_TagSeller_MOBILE
    /// </summary>
    /// <param name="eocPropertyBean"></param>
    /// <returns></returns>
    public int Insert_DetailRecord_Automobile(EOC_PropertyBean eocPropertyBean)
    {
        int intActionResult = 0;
        string strOutputValue = string.Empty;

        try
        {
            ArrayList arlSQLParameters = new ArrayList();

            
            arlSQLParameters.Add(new SqlParameter("@ProfileID", eocPropertyBean.Business_UserProfile_ProfileID.ToString()));
            arlSQLParameters.Add(new SqlParameter("@SKU", eocPropertyBean.Business_ProductProfile_Books_SKU));
            arlSQLParameters.Add(new SqlParameter("@ProductDesc", eocPropertyBean.Business_ProductProfile_Description));
            arlSQLParameters.Add(new SqlParameter("@ProductID", eocPropertyBean.Business_ProductProfile_Books_ProductID.ToString()));

            arlSQLParameters.Add(new SqlParameter("@Qty", eocPropertyBean.Business_ProductProfile_Quantity.ToString()));
            arlSQLParameters.Add(new SqlParameter("@Currency", eocPropertyBean.Business_ProductProfile_Books_Currency));
            arlSQLParameters.Add(new SqlParameter("@Price", eocPropertyBean.Business_ProductProfile_Books_ProductPrice));
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
            arlSQLParameters.Add(new SqlParameter("@UpdatedOn", eocPropertyBean.UpdatedOn.ToString()));
            arlSQLParameters.Add(new SqlParameter("@IsActive", eocPropertyBean.Business_ProductProfile_IsActive));
            arlSQLParameters.Add(new SqlParameter("@SellerType", eocPropertyBean.UserType));

            arlSQLParameters.Add(new SqlParameter("@ProductYear", eocPropertyBean.Business_Product_ProductYear));
            arlSQLParameters.Add(new SqlParameter("@IsNegotiable", eocPropertyBean.IsNegotiable));

            //arlSQLParameters.Add(new SqlParameter("@CarSubModel", eocPropertyBean.Automobile_CarSubModel));
            arlSQLParameters.Add(new SqlParameter("@VIN", eocPropertyBean.Automobile_VIN));
            arlSQLParameters.Add(new SqlParameter("@Mileage", eocPropertyBean.Automobile_Mileage));
            arlSQLParameters.Add(new SqlParameter("@VehicleRegYear", eocPropertyBean.Automobile_VehicleRegYear));


            arlSQLParameters.Add(new SqlParameter("@Source", eocPropertyBean.Source));
            arlSQLParameters.Add(new SqlParameter("@IsAlternativeAddress", eocPropertyBean.Is_Alternative_Address));

            intActionResult = this.ExecuteActionQuery("USP_CP_Public_Insert_TagSeller_CAR_MC", arlSQLParameters);

        }
        catch
        {
            throw;
        }

        return intActionResult;
    }





    /// <summary>
    /// Updates both Product_Master_COM_LAP_ACC and Product_Seller_Detail_COM_LAP_ACC table. 
    /// In master table Updates Image.
    /// USP: USP_CP_Public_Update_MasterSeller_CAR_MC
    /// </summary>
    /// <param name="eocPropertyBean"></param>
    /// <returns></returns>
    public int Update_MasterSeller_Automobile(EOC_PropertyBean eocPropertyBean)
    {
        int intActionResult = 0;
        string strOutputValue = string.Empty;
        //bool canEditProduct = true;

        try
        {
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@ProfileID", eocPropertyBean.Business_UserProfile_ProfileID.ToString()));
            arlSQLParameters.Add(new SqlParameter("@ProductID", eocPropertyBean.Business_ProductProfile_Books_ProductID.ToString()));
            arlSQLParameters.Add(new SqlParameter("@CategoryID", eocPropertyBean.Category_CategoryID.ToString()));
            arlSQLParameters.Add(new SqlParameter("@SubcategoryID", eocPropertyBean.Subcategory_SubcategoryID.ToString()));

            arlSQLParameters.Add(new SqlParameter("@SecondSubcatID", eocPropertyBean.SecondSubcategory_SubcategoryID.ToString()));
            arlSQLParameters.Add(new SqlParameter("@ProductModelID", eocPropertyBean.Model_ModelID.ToString()));
            arlSQLParameters.Add(new SqlParameter("@ProductDesc", eocPropertyBean.Business_ProductProfile_Description));
            arlSQLParameters.Add(new SqlParameter("@Qty", eocPropertyBean.Business_ProductProfile_Quantity.ToString()));

            arlSQLParameters.Add(new SqlParameter("@Currency", eocPropertyBean.Business_ProductProfile_Books_Currency));
            arlSQLParameters.Add(new SqlParameter("@Price", eocPropertyBean.Business_ProductProfile_Books_ProductPrice));
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

            arlSQLParameters.Add(new SqlParameter("@UpdatedOn", eocPropertyBean.UpdatedOn.ToString()));
            arlSQLParameters.Add(new SqlParameter("@SellerType", eocPropertyBean.UserType.ToString()));
            arlSQLParameters.Add(new SqlParameter("@IsActive", eocPropertyBean.Business_ProductProfile_IsActive));
            arlSQLParameters.Add(new SqlParameter("@ProductImage", eocPropertyBean.Business_ProductProfile_Books_ProductImage.ToString()));

            arlSQLParameters.Add(new SqlParameter("@ProductYear", eocPropertyBean.Business_Product_ProductYear));
            arlSQLParameters.Add(new SqlParameter("@VIN", eocPropertyBean.Automobile_VIN));
            arlSQLParameters.Add(new SqlParameter("@Mileage", eocPropertyBean.Automobile_Mileage));
            arlSQLParameters.Add(new SqlParameter("@VehicleRegYear", eocPropertyBean.Automobile_VehicleRegYear));

            arlSQLParameters.Add(new SqlParameter("@IsNegotiable", eocPropertyBean.IsNegotiable));

            arlSQLParameters.Add(new SqlParameter("@Source", eocPropertyBean.Source));
            arlSQLParameters.Add(new SqlParameter("@IsAlternativeAddress", eocPropertyBean.Is_Alternative_Address));

            intActionResult = this.ExecuteActionQuery("USP_CP_Public_Update_MasterSeller_CAR_MC", arlSQLParameters);
        }
        catch
        {
            throw;
        }

        return intActionResult;
    }



    /// <summary>
    /// Update Product_Seller_Detail_CAR_MC table.
    /// USP: USP_CP_Public_Update_TagSeller_CAR_MC
    /// </summary>
    /// <param name="eocPropertyBean"></param>
    /// <returns></returns>
    public int Update_TagSeller_Automobile(EOC_PropertyBean eocPropertyBean)
    {
        int intActionResult = 0;
        //string strOutputValue = string.Empty;
        //bool canEditProduct = true;

        try
        {
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Add(new SqlParameter("@ProfileID", eocPropertyBean.Business_UserProfile_ProfileID.ToString()));
            arlSQLParameters.Add(new SqlParameter("@ProductID", eocPropertyBean.Business_ProductProfile_Books_ProductID.ToString()));
            arlSQLParameters.Add(new SqlParameter("@ProductDesc", eocPropertyBean.Business_ProductProfile_Description));
            arlSQLParameters.Add(new SqlParameter("@Qty", eocPropertyBean.Business_ProductProfile_Quantity.ToString()));

            arlSQLParameters.Add(new SqlParameter("@Currency", eocPropertyBean.Business_ProductProfile_Books_Currency));
            arlSQLParameters.Add(new SqlParameter("@Price", eocPropertyBean.Business_ProductProfile_Books_ProductPrice));
            arlSQLParameters.Add(new SqlParameter("@DiscountPrice", eocPropertyBean.Business_ProductProfile_Books_SalePrice));
            arlSQLParameters.Add(new SqlParameter("@DisStartDate", eocPropertyBean.Business_ProductProfile_Books_StartDate));

            arlSQLParameters.Add(new SqlParameter("@DisEndDate", eocPropertyBean.Business_ProductProfile_Books_EndDate));
            arlSQLParameters.Add(new SqlParameter("@Condition", eocPropertyBean.Business_Product_Profile_Books_Condition.ToString()));
            arlSQLParameters.Add(new SqlParameter("@ConditionNote", eocPropertyBean.Business_Product_Profile_Books_ConditionNote.ToString()));
            arlSQLParameters.Add(new SqlParameter("@CashOnDelivery", eocPropertyBean.Business_ProductProfile_CashOnDelivery));

            arlSQLParameters.Add(new SqlParameter("@PickFromStore", eocPropertyBean.Business_ProductProfile_PickFromStore));
            arlSQLParameters.Add(new SqlParameter("@CashDeposit", eocPropertyBean.Business_ProductProfile_CashDeposit));
            arlSQLParameters.Add(new SqlParameter("@SellerForeignAddress", eocPropertyBean.Business_ProductProfile_SellerForeignAddress));
            arlSQLParameters.Add(new SqlParameter("@DeliveryArea", eocPropertyBean.Business_ProductProfile_General_DeliveryArea));

            arlSQLParameters.Add(new SqlParameter("@UpdatedOn", eocPropertyBean.UpdatedOn));
            arlSQLParameters.Add(new SqlParameter("@SellerType", eocPropertyBean.UserType.ToString()));
            arlSQLParameters.Add(new SqlParameter("@IsActive", eocPropertyBean.Business_ProductProfile_IsActive));
            //arlSQLParameters.Add(new SqlParameter("@ProductImage", eocPropertyBean.Business_ProductProfile_Books_ProductImage.ToString()));

            arlSQLParameters.Add(new SqlParameter("@ProductYear", eocPropertyBean.Business_Product_ProductYear));
            arlSQLParameters.Add(new SqlParameter("@VIN", eocPropertyBean.Automobile_VIN));
            arlSQLParameters.Add(new SqlParameter("@Mileage", eocPropertyBean.Automobile_Mileage));
            arlSQLParameters.Add(new SqlParameter("@VehicleRegYear", eocPropertyBean.Automobile_VehicleRegYear));

            arlSQLParameters.Add(new SqlParameter("@IsNegotiable", eocPropertyBean.IsNegotiable));

            arlSQLParameters.Add(new SqlParameter("@Source", eocPropertyBean.Source));
            arlSQLParameters.Add(new SqlParameter("@IsAlternativeAddress", eocPropertyBean.Is_Alternative_Address));

            intActionResult = this.ExecuteActionQuery("USP_CP_Public_Update_TagSeller_CAR_MC", arlSQLParameters);

        }
        catch
        {
            throw;
        }

        return intActionResult;

    }
}
