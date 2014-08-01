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

public class BOC_Corporate_ProdProf_Book : UTLDBHandler
{
    public BOC_Corporate_ProdProf_Book() : base(UTLUtilities.Database.DbConnectionString)
	{
	}


    /// <summary>
    /// Selects CategoryID, Category, InsertedOn, UpdatedOn
    /// from Category table
    /// </summary>
    /// <param name="eocPropertyBean"></param>
    /// <returns></returns>
    public DataTable LoadRecord_Category(EOC_PropertyBean eocPropertyBean)
    {
        try
        {
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Add(new SqlParameter("@CountryID", eocPropertyBean.Country_CountryID.ToString()));
            return this.ExecuteQuery("[USP_Common_LoadCategory]", arlSQLParameters);
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Selects Email Address From LoginTable
    /// from UserProfile
    /// </summary>
    /// <param name="eocPropertyBean"></param>
    /// <returns></returns>
    public DataTable LoadRecord_UserProfile(EOC_PropertyBean eocPropertyBean)
    {
        try
        {
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Add(new SqlParameter("@LoginEmail", eocPropertyBean.LoginEmail.ToString()));
            return this.ExecuteQuery("[USP_Common_Classified_Load_LoginInformation]", arlSQLParameters);
        }
        catch
        {
            throw;
        }
    }


    /// <summary>
    /// Selects Email Address From LoginTable
    /// from UserProfile
    /// </summary>
    /// <param name="eocPropertyBean"></param>
    /// <returns></returns>
    public DataTable LoadRecord_UserProfileCorporate(EOC_PropertyBean eocPropertyBean)
    {
        try
        {
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Add(new SqlParameter("@LoginEmail", eocPropertyBean.LoginEmail.ToString()));
            return this.ExecuteQuery("[USP_Common_Corporate_Load_LoginInformation]", arlSQLParameters);
        }
        catch
        {
            throw;
        }
    }



    /// <summary>
    /// Load Subcategory list from the table Subcategory . Load only special items like Book etc.
    /// </summary>
    /// <param name="eocPropertyBean"></param>
    /// <returns></returns>
    public DataTable LoadRecord_Subcategory(EOC_PropertyBean eocPropertyBean)
    {
        try
        {
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@CountryID", eocPropertyBean.Country_CountryID.ToString()));
            return this.ExecuteQuery("USP_CP_ProdProf_Books_LoadSubcategory", arlSQLParameters);
        }
        catch
        {
            throw;
        }
    }

   

    public DataTable LoadRecord_2ndSubcategory(EOC_PropertyBean eocPropertyBean)
    {
        try
        {
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@SubCategoryID", eocPropertyBean.Business_ProductProfile_Books_SubCategoryID.ToString()));
            return this.ExecuteQuery("USP_CP_ProdProf_Books_Load2ndSubcategory", arlSQLParameters);
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Select all rows and specific columns from table Business_ProductProfile_GeneralItems.
    /// </summary>
    /// <param name="eocPropertyBean"></param>
    /// <returns></returns>
    public DataTable LoadRecord_ProductProfile(EOC_PropertyBean eocPropertyBean)
    {
        try
        {
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@ProfileID", eocPropertyBean.Business_UserProfile_ProfileID.ToString()));
            return this.ExecuteQuery("USP_CP_ProdProf_Books_LoadRecord", arlSQLParameters);
        }
        catch
        {
            throw;
        }
    }

    #region Original SelectRecord_ProductProfile
    /// <summary>
    /// Select specific rows and columns from table Business_ProductProfile_Books.
    /// </summary>
    /// <param name="eocPropertyBean"></param>
    /// <returns></returns>
    public bool SelectRecord_ProductProfile(EOC_PropertyBean eocPropertyBean)
    {
        bool blnFlag = false;

        try
        {
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@ProfileID", eocPropertyBean.Business_UserProfile_ProfileID.ToString()));
            arlSQLParameters.Add(new SqlParameter("@ProductID", eocPropertyBean.Business_ProductProfile_Books_ProductID.ToString()));
            DataTable objDataTable = this.ExecuteQuery("USP_CP_ProdProf_Books_SelectSpecificRecord", arlSQLParameters);

            if (objDataTable.Rows.Count > 0)
            {
                blnFlag = true;

                eocPropertyBean.Subcategory_SubcategoryID = Convert.ToInt32(objDataTable.Rows[0]["SubcategoryID"].ToString());
                eocPropertyBean.Business_ProductProfile_Books_SKU = objDataTable.Rows[0]["SKU"].ToString();
                eocPropertyBean.Business_ProductProfile_Books_BookTitle = objDataTable.Rows[0]["ProductTitle"].ToString();
                //eocPropertyBean.Business_ProductProfile_Books_Author = objDataTable.Rows[0]["Author"].ToString();
                //eocPropertyBean.Business_ProductProfile_Books_Publisher = objDataTable.Rows[0]["Publisher"].ToString();
                //eocPropertyBean.Business_ProductProfile_Books_ISBN = objDataTable.Rows[0]["ISBN"].ToString();
                //eocPropertyBean.Business_ProductProfile_Books_Edition = objDataTable.Rows[0]["Edition"].ToString();
                eocPropertyBean.Business_ProductProfile_Description = objDataTable.Rows[0]["BookDescription"].ToString();
                eocPropertyBean.Business_ProductProfile_Quantity = Convert.ToInt32(objDataTable.Rows[0]["Quantity"].ToString());
                eocPropertyBean.Business_ProductProfile_Books_ProductImage = objDataTable.Rows[0]["ProductImage"].ToString();
                eocPropertyBean.Business_ProductProfile_Books_Currency = objDataTable.Rows[0]["Currency"].ToString();
                eocPropertyBean.Business_ProductProfile_Books_ProductPrice = Convert.ToDouble(objDataTable.Rows[0]["ProductPrice"].ToString());
                eocPropertyBean.Business_ProductProfile_Books_SalePrice = Convert.ToDouble(objDataTable.Rows[0]["SalePrice"]);
                eocPropertyBean.Business_ProductProfile_Books_CashOnDeliveryCost = Convert.ToDouble(objDataTable.Rows[0]["CashOnDeliveryCost"].ToString());
                eocPropertyBean.Business_ProductProfile_Books_PaymentOption = objDataTable.Rows[0]["PaymentOption"].ToString();
                eocPropertyBean.Business_ProductProfile_Books_StartDate = Convert.ToDateTime(objDataTable.Rows[0]["StartDate"].ToString());
                eocPropertyBean.Business_ProductProfile_Books_EndDate = Convert.ToDateTime(objDataTable.Rows[0]["EndDate"].ToString());

                eocPropertyBean.Business_ProductProfile_General_DeliveryArea = objDataTable.Rows[0]["DeliveryArea"].ToString(); //Moinur 23Mar09

                eocPropertyBean.SecondSubcategory_SubcategoryID = Convert.ToInt32(objDataTable.Rows[0]["SecBookSubcategoryID"].ToString());//Moinur 23Mar09

            }
            else
            {
                blnFlag = false;
            }
        }
        catch
        {
            throw;
        }

        return blnFlag;
    }
    #endregion Original SelectRecord_ProductProfile



    public bool SelectRecord_General_BookProfile(EOC_PropertyBean eocPropertyBean)
    {
        bool blnFlag = false;
        string strSalePrice = null;

        try
        {
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@ProfileID", eocPropertyBean.Business_UserProfile_ProfileID.ToString()));
            arlSQLParameters.Add(new SqlParameter("@ProductID", eocPropertyBean.Business_ProductProfile_Books_ProductID.ToString()));
            arlSQLParameters.Add(new SqlParameter("@CategoryID", eocPropertyBean.Category_CategoryID.ToString()));
            arlSQLParameters.Add(new SqlParameter("@SubcategoryID", eocPropertyBean.Subcategory_SubcategoryID.ToString()));
            arlSQLParameters.Add(new SqlParameter("@SecondSubcatID", eocPropertyBean.SecondSubcategory_SubcategoryID.ToString()));
            arlSQLParameters.Add(new SqlParameter("@SellerType", eocPropertyBean.UserType.ToString()));


            DataTable objDataTable = this.ExecuteQuery("USP_CP_Public_ProdProf_Books_SelectSpecificRecord", arlSQLParameters);

            if (objDataTable.Rows.Count > 0)
            {
                blnFlag = true;

                eocPropertyBean.Business_ProductProfile_Books_SKU = objDataTable.Rows[0]["SKU"].ToString();
                eocPropertyBean.Category_CategoryID = Convert.ToInt32(objDataTable.Rows[0]["CategoryID"].ToString());
                eocPropertyBean.Subcategory_SubcategoryID = Convert.ToInt32(objDataTable.Rows[0]["SubcategoryID"].ToString());
                eocPropertyBean.SecondSubcategory_SubcategoryID = Convert.ToInt32(objDataTable.Rows[0]["SecondSubcatID"].ToString());
                
                eocPropertyBean.Business_ProductProfile_Books_BookTitle = objDataTable.Rows[0]["ProductTitle"].ToString();
                eocPropertyBean.Business_ProductProfile_Description = objDataTable.Rows[0]["ProductDesc"].ToString();
                eocPropertyBean.Business_ProductProfile_Quantity = Convert.ToInt32(objDataTable.Rows[0]["Qty"].ToString());
                eocPropertyBean.Business_ProductProfile_Books_Currency = objDataTable.Rows[0]["Currency"].ToString();
                eocPropertyBean.Business_ProductProfile_Books_ProductPrice = Convert.ToDouble(objDataTable.Rows[0]["Price"].ToString());

                strSalePrice = objDataTable.Rows[0]["DiscountPrice"].ToString();
                if(!string.IsNullOrEmpty(strSalePrice))
                {
                    eocPropertyBean.Business_ProductProfile_Books_SalePrice = Convert.ToDouble(strSalePrice);
                }
                
                eocPropertyBean.FromDate= Convert.ToDateTime(objDataTable.Rows[0]["DisStartDate"].ToString());
                eocPropertyBean.ToDate = Convert.ToDateTime(objDataTable.Rows[0]["DisEndDate"].ToString());
                eocPropertyBean.Condition = objDataTable.Rows[0]["Condition"].ToString();
                eocPropertyBean.ConditionNote = objDataTable.Rows[0]["ConditionNote"].ToString();

                eocPropertyBean.Business_ProductProfile_Books_PaymentOption = objDataTable.Rows[0]["PaymentOption"].ToString();
        
                eocPropertyBean.Business_ProductProfile_General_DeliveryArea = objDataTable.Rows[0]["DeliveryArea"].ToString();
                eocPropertyBean.Business_ProductProfile_Books_CashOnDeliveryCost = Convert.ToDouble(objDataTable.Rows[0]["CodCost"].ToString());
                eocPropertyBean.CanEditProduct = Convert.ToInt32(objDataTable.Rows[0]["CanEditProduct"].ToString());
            }
            else
            {
                blnFlag = false;
            }
        }
        catch
        {
            throw;
        }

        return blnFlag;
    }
    

    public int UpdateRecord_ProductImage(EOC_PropertyBean eocPropertyBean)
    {
        int intActionResult = 0;

        try
        {
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Add(new SqlParameter("@ProductImage", eocPropertyBean.Business_ProductProfile_Books_ProductImage));
            arlSQLParameters.Add(new SqlParameter("@ProductID", eocPropertyBean.Business_ProductProfile_Books_ProductID.ToString()));

            intActionResult = this.ExecuteActionQuery("USP_CP_ProdProf_Books_UpdateRecord_ImageInfo", arlSQLParameters);
        }
        catch
        {
            throw;
        }

        return intActionResult;
    }

    public int UpdateRecord_ProductProfile(EOC_PropertyBean eocPropertyBean)
    {
        int intActionResult = 0;
        string strOutputValue = string.Empty;

        try
        {
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@ProductID", eocPropertyBean.Business_ProductProfile_Books_ProductID.ToString()));
            arlSQLParameters.Add(new SqlParameter("@ProfileID", eocPropertyBean.Business_UserProfile_ProfileID.ToString()));
            arlSQLParameters.Add(new SqlParameter("@SubcategoryID", eocPropertyBean.Subcategory_SubcategoryID.ToString()));
            arlSQLParameters.Add(new SqlParameter("@SKU", eocPropertyBean.Business_ProductProfile_Books_SKU));
            arlSQLParameters.Add(new SqlParameter("@BookTitle", eocPropertyBean.Business_ProductProfile_Books_BookTitle));
            arlSQLParameters.Add(new SqlParameter("@Author", eocPropertyBean.Business_ProductProfile_Books_Author));
            arlSQLParameters.Add(new SqlParameter("@Publisher", eocPropertyBean.Business_ProductProfile_Books_Publisher));
            arlSQLParameters.Add(new SqlParameter("@ISBN", eocPropertyBean.Business_ProductProfile_Books_ISBN));
            arlSQLParameters.Add(new SqlParameter("@Edition", eocPropertyBean.Business_ProductProfile_Books_Edition));
            arlSQLParameters.Add(new SqlParameter("@BookDescription", eocPropertyBean.Business_ProductProfile_Description));
            arlSQLParameters.Add(new SqlParameter("@Quantity", eocPropertyBean.Business_ProductProfile_Quantity.ToString()));
            arlSQLParameters.Add(new SqlParameter("@ProductImage", eocPropertyBean.Business_ProductProfile_Books_ProductImage));
            arlSQLParameters.Add(new SqlParameter("@Currency", eocPropertyBean.Business_ProductProfile_Books_Currency));
            arlSQLParameters.Add(new SqlParameter("@ProductPrice", eocPropertyBean.Business_ProductProfile_Books_ProductPrice));
            arlSQLParameters.Add(new SqlParameter("@SalePrice", eocPropertyBean.Business_ProductProfile_Books_SalePrice));
            arlSQLParameters.Add(new SqlParameter("@CashOnDeliveryCost", eocPropertyBean.Business_ProductProfile_Books_CashOnDeliveryCost));
            arlSQLParameters.Add(new SqlParameter("@PaymentOption", eocPropertyBean.Business_ProductProfile_Books_PaymentOption));
            arlSQLParameters.Add(new SqlParameter("@StartDate", eocPropertyBean.Business_ProductProfile_Books_StartDate.ToString()));
            arlSQLParameters.Add(new SqlParameter("@EndDate", eocPropertyBean.Business_ProductProfile_Books_EndDate.ToString()));
            arlSQLParameters.Add(new SqlParameter("@UpdatedOn", eocPropertyBean.UpdatedOn.ToString()));

            arlSQLParameters.Add(new SqlParameter("@DeliveryArea", eocPropertyBean.Business_ProductProfile_General_DeliveryArea));
            arlSQLParameters.Add(new SqlParameter("@SecBookSubcategoryID", eocPropertyBean.Business_ProductProfile_Books_2ndSubCategoryID));


            intActionResult = this.ExecuteActionQuery("USP_CP_ProdProf_Books_UpdateRecord", arlSQLParameters, "@ProductIDValue");
        }
        catch
        {
            throw;
        }

        return intActionResult;
    }

    public DataTable SellLead_Set01_BuyerList_Books(EOC_PropertyBean eocPropertyBean)
    {
        try
        {
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@ProfileID", eocPropertyBean.Business_UserProfile_ProfileID.ToString()));
            arlSQLParameters.Add(new SqlParameter("@FromDate", eocPropertyBean.FromDate.ToString()));
            arlSQLParameters.Add(new SqlParameter("@ToDate", eocPropertyBean.ToDate.ToString()));

            return this.ExecuteQuery("USP_CP_SellLead_Set01_BuyerList_Books", arlSQLParameters);
        }
        catch
        {
            throw;
        }
    }

    public DataTable SellLead_OrderDetail(EOC_PropertyBean eocPropertyBean)
    {
        try
        {
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@ProfileID", eocPropertyBean.Business_UserProfile_ProfileID.ToString()));
            arlSQLParameters.Add(new SqlParameter("@CustomerEmail", eocPropertyBean.Business_OrderDetail_Books_CustomerEmail));
            arlSQLParameters.Add(new SqlParameter("@FromDate", eocPropertyBean.FromDate.ToString()));
            arlSQLParameters.Add(new SqlParameter("@ToDate", eocPropertyBean.ToDate.ToString()));
            
            return this.ExecuteQuery("USP_CP_SellLead_Set01_OrderDetail_Books", arlSQLParameters);
        }
        catch
        {
            throw;
        }
    }

    public DataTable SellLead_Set02_ProductList_Books(EOC_PropertyBean eocPropertyBean)
    {
        try
        {
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@ProfileID", eocPropertyBean.Business_UserProfile_ProfileID.ToString()));
            arlSQLParameters.Add(new SqlParameter("@FromDate", eocPropertyBean.FromDate.ToString()));
            arlSQLParameters.Add(new SqlParameter("@ToDate", eocPropertyBean.ToDate.ToString()));

            return this.ExecuteQuery("USP_CP_SellLead_Set02_ProductList_Books", arlSQLParameters);
        }
        catch
        {
            throw;
        }
    }

    

    

   

    /// <summary>
    ///  Insert new row in the table Business_ProductProfile_GeneralItems
    /// USP: USP_CP_ProdProf_Books_InsertRecord
    /// </summary>
    /// <param name="eocPropertyBean"></param>
    /// <returns></returns>
    public int AddRecord_ProductProfile(EOC_PropertyBean eocPropertyBean)
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
            arlSQLParameters.Add(new SqlParameter("@Description", eocPropertyBean.Business_ProductProfile_Description));
            arlSQLParameters.Add(new SqlParameter("@Qty", eocPropertyBean.Business_ProductProfile_Quantity.ToString()));
            arlSQLParameters.Add(new SqlParameter("@Currency", eocPropertyBean.Business_ProductProfile_Books_Currency));
            arlSQLParameters.Add(new SqlParameter("@Price", eocPropertyBean.Business_ProductProfile_Books_ProductPrice));
            arlSQLParameters.Add(new SqlParameter("@SalePrice", eocPropertyBean.Business_ProductProfile_Books_SalePrice));
            arlSQLParameters.Add(new SqlParameter("@DisStartDate", eocPropertyBean.Business_ProductProfile_Books_StartDate.ToString()));
            arlSQLParameters.Add(new SqlParameter("@DisEndDate", eocPropertyBean.Business_ProductProfile_Books_EndDate.ToString()));
            arlSQLParameters.Add(new SqlParameter("@Condition", eocPropertyBean.Business_Product_Profile_Books_Condition.ToString()));
            arlSQLParameters.Add(new SqlParameter("@ConditionNote", eocPropertyBean.Business_Product_Profile_Books_ConditionNote.ToString()));
            arlSQLParameters.Add(new SqlParameter("@PaymentOption", eocPropertyBean.Business_ProductProfile_Books_PaymentOption));
            arlSQLParameters.Add(new SqlParameter("@DeliveryArea", eocPropertyBean.Business_ProductProfile_General_DeliveryArea));
            arlSQLParameters.Add(new SqlParameter("@CodCost", eocPropertyBean.Business_ProductProfile_Books_CashOnDeliveryCost));


            arlSQLParameters.Add(new SqlParameter("@PaperBackForBook", eocPropertyBean.Business_ProductProfile_Books_PaperBackForBook.ToString()));
            arlSQLParameters.Add(new SqlParameter("@DimensionForBook", eocPropertyBean.Business_Product_Profile_Books_DimensionForBook.ToString()));
            arlSQLParameters.Add(new SqlParameter("@ShippingWeight", eocPropertyBean.Business_Product_Profile_Books_ShippingWeight.ToString()));
            arlSQLParameters.Add(new SqlParameter("@Edition", eocPropertyBean.Business_ProductProfile_Books_Edition));
            arlSQLParameters.Add(new SqlParameter("@ISBN", eocPropertyBean.Business_ProductProfile_Books_ISBN));

            arlSQLParameters.Add(new SqlParameter("@Author", eocPropertyBean.Business_ProductProfile_Books_Author));
            arlSQLParameters.Add(new SqlParameter("@Publisher", eocPropertyBean.Business_ProductProfile_Books_Publisher));
            arlSQLParameters.Add(new SqlParameter("@ProductImage", eocPropertyBean.Business_ProductProfile_Books_ProductImage));


            arlSQLParameters.Add(new SqlParameter("@CanEditPeoduct", eocPropertyBean.Business_UserProfile_ProfileID.ToString()));
            arlSQLParameters.Add(new SqlParameter("@TitleViolation", eocPropertyBean.Business_Product_Profile_Books_TitleViolation));
            arlSQLParameters.Add(new SqlParameter("@SellerType", eocPropertyBean.UserType));

            intActionResult = this.ExecuteActionQuery("USP_CP_ProdProf_Books_InsertRecord", arlSQLParameters, "@ProductID");



            //arlSQLParameters.Add(new SqlParameter("@SecBookSubcategoryID", eocPropertyBean.Business_ProductProfile_Books_2ndSubCategoryID));

            //arlSQLParameters.Add(new SqlParameter("@ProvinceID", eocPropertyBean.Province_ProvinceID));

            //arlSQLParameters.Add(new SqlParameter("@UpdatedOn", eocPropertyBean.UpdatedOn.ToString()));


            //eocPropertyBean.Business_ProductProfile_Books_ProductID = Convert.ToInt32(strOutputValue);
        }
        catch
        {
            throw;
        }

        return intActionResult;
    }

    #region New methods for new input screen.
    /// <summary>
    ///  Inserts a new row in both Product_Master_Book and Product_Detail_Book table.
    /// USP: USP_CP_Public_Insert_Master_BookProduct
    /// </summary>
    /// <param name="eocPropertyBean"></param>
    /// <returns></returns>
    public int Insert_MasterRecord_BookProduct(EOC_PropertyBean eocPropertyBean)
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
            arlSQLParameters.Add(new SqlParameter("@PaperBackForBook", eocPropertyBean.Business_ProductProfile_Books_PaperBackForBook.ToString()));
            arlSQLParameters.Add(new SqlParameter("@DimensionForBook", eocPropertyBean.Business_Product_Profile_Books_DimensionForBook.ToString()));

            arlSQLParameters.Add(new SqlParameter("@ShippingWeight", eocPropertyBean.Business_Product_Profile_Books_ShippingWeight.ToString()));
            arlSQLParameters.Add(new SqlParameter("@Edition", eocPropertyBean.Business_ProductProfile_Books_Edition));
            arlSQLParameters.Add(new SqlParameter("@ISBN", eocPropertyBean.Business_ProductProfile_Books_ISBN));
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



            intActionResult = this.ExecuteActionQuery("USP_CP_Public_Insert_Master_BookProduct", arlSQLParameters);
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
    public int Insert_DetailRecord_BookProduct(EOC_PropertyBean eocPropertyBean)
    {
        int intActionResult = 0;
        string strOutputValue = string.Empty;
        //bool canEditProduct = true;

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
            arlSQLParameters.Add(new SqlParameter("@PaperBackForBook", eocPropertyBean.Business_ProductProfile_Books_PaperBackForBook.ToString()));
            arlSQLParameters.Add(new SqlParameter("@DimensionForBook", eocPropertyBean.Business_Product_Profile_Books_DimensionForBook.ToString()));

            arlSQLParameters.Add(new SqlParameter("@Language", eocPropertyBean.Business_Product_Profile_Books_Language.ToString()));
            arlSQLParameters.Add(new SqlParameter("@ShippingWeight", eocPropertyBean.Business_Product_Profile_Books_ShippingWeight.ToString()));
            arlSQLParameters.Add(new SqlParameter("@DetailUpdatedOn", eocPropertyBean.UpdatedOn.ToString()));
            arlSQLParameters.Add(new SqlParameter("@IsActive", eocPropertyBean.Business_ProductProfile_IsActive));
            arlSQLParameters.Add(new SqlParameter("@SellerType", eocPropertyBean.UserType));

            arlSQLParameters.Add(new SqlParameter("@Source", eocPropertyBean.Source));
            arlSQLParameters.Add(new SqlParameter("@IsAlternativeAddress", eocPropertyBean.Is_Alternative_Address));

            intActionResult = this.ExecuteActionQuery("USP_CP_Public_Insert_TagSeller_BookProduct", arlSQLParameters);

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
    public int Update_TagSeller_BookRecord(EOC_PropertyBean eocPropertyBean)
    {
        int intActionResult = 0;
        //string strOutputValue = string.Empty;
        //bool canEditProduct = true;

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
            arlSQLParameters.Add(new SqlParameter("@PaperBackForBook", eocPropertyBean.Business_ProductProfile_Books_PaperBackForBook.ToString()));
            arlSQLParameters.Add(new SqlParameter("@Language", eocPropertyBean.Business_Product_Profile_Books_Language.ToString()));
            arlSQLParameters.Add(new SqlParameter("@DimensionForBook", eocPropertyBean.Business_Product_Profile_Books_DimensionForBook.ToString()));

            arlSQLParameters.Add(new SqlParameter("@ShippingWeight", eocPropertyBean.Business_Product_Profile_Books_ShippingWeight.ToString()));
            arlSQLParameters.Add(new SqlParameter("@DetailUpdatedOn", eocPropertyBean.UpdatedOn.ToString()));
            arlSQLParameters.Add(new SqlParameter("@IsActive", eocPropertyBean.Business_ProductProfile_IsActive));
            arlSQLParameters.Add(new SqlParameter("@SellerType", eocPropertyBean.UserType));

            arlSQLParameters.Add(new SqlParameter("@Source", eocPropertyBean.Source));
            arlSQLParameters.Add(new SqlParameter("@IsAlternativeAddress", eocPropertyBean.Is_Alternative_Address));

            intActionResult = this.ExecuteActionQuery("USP_CP_Public_Update_TagSeller_BookRecord", arlSQLParameters);

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
    public int Update_MasterSeller_BookProduct(EOC_PropertyBean eocPropertyBean)
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
            arlSQLParameters.Add(new SqlParameter("@PaperBackForBook", eocPropertyBean.Business_ProductProfile_Books_PaperBackForBook.ToString()));

            arlSQLParameters.Add(new SqlParameter("@Language", eocPropertyBean.Business_Product_Profile_Books_Language.ToString()));
            arlSQLParameters.Add(new SqlParameter("@DimensionForBook", eocPropertyBean.Business_Product_Profile_Books_DimensionForBook.ToString()));
            arlSQLParameters.Add(new SqlParameter("@ShippingWeight", eocPropertyBean.Business_Product_Profile_Books_ShippingWeight.ToString()));

            arlSQLParameters.Add(new SqlParameter("@ISBN", eocPropertyBean.Business_ProductProfile_Books_ISBN));
            arlSQLParameters.Add(new SqlParameter("@Author", eocPropertyBean.Business_ProductProfile_Books_Author));
            arlSQLParameters.Add(new SqlParameter("@MasterUpdatedOn", eocPropertyBean.UpdatedOn.ToString()));

            arlSQLParameters.Add(new SqlParameter("@DetailUpdatedOn", eocPropertyBean.UpdatedOn.ToString()));
            arlSQLParameters.Add(new SqlParameter("@SellerType", eocPropertyBean.UserType.ToString()));
            arlSQLParameters.Add(new SqlParameter("@IsActive", eocPropertyBean.Business_ProductProfile_IsActive));

            arlSQLParameters.Add(new SqlParameter("@ProductImage", eocPropertyBean.Business_ProductProfile_Books_ProductImage.ToString()));

            arlSQLParameters.Add(new SqlParameter("@Source", eocPropertyBean.Source));
            arlSQLParameters.Add(new SqlParameter("@IsAlternativeAddress", eocPropertyBean.Is_Alternative_Address));
            arlSQLParameters.Add(new SqlParameter("@Publisher", eocPropertyBean.Business_ProductProfile_Books_Publisher));
            //eocPropertyBean.Business_ProductProfile_Books_Publisher = txtPublisher.Text;


            intActionResult = this.ExecuteActionQuery("USP_CP_Public_Update_MasterSeller_BookRecord", arlSQLParameters);
        }
        catch
        {
            throw;
        }

        return intActionResult;
    }
    #endregion New methods for new input screen.
}
