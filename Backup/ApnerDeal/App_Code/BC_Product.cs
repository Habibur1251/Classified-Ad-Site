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

/// <summary>
/// Summary description for BC_Product
/// </summary>
public class BC_Product : DbBaseClass
{
	public BC_Product() : base(StaticSettings.Database.DbConnectionString)
	{
		//
		// TODO: Add constructor logic here
		//
	}

    /// <summary>
    /// Increments a products HitCounterField.
    /// USP: USP_Common_BS_Product_HitCounter
    /// </summary>
    /// <param name="objProduct"></param>
    /// <returns></returns>
    public int IncrementProductCounter(CommonProduct objProduct)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@CategoryID", objProduct.CategoryID);
        ht.Add("@ProductSellerDetailID", objProduct.ProductSellerDetailID);

        try
        {
            return this.ExecuteNonQueryStoredProcedure("USP_Common_BS_Product_HitCounter", ht);
        }
        catch
        {
            throw;
        }
    }


    /// <summary>
    /// Loads all the book title, image and author name based on Cat, Subcategory, SecSubcatID and Title
    /// USP: USP_CP_Public_SearchProductTitle_Book
    /// </summary>
    /// <param name="categoryID"></param>
    /// <param name="subcategoryID"></param>
    /// <param name="secondSubcatID"></param>
    /// <param name="productTitle"></param>
    /// <returns></returns>
    public DataTable GetList_BookTitle(int categoryID, int subcategoryID, string productTitle)
    {
        productTitle = "%" + productTitle + "%";
        Hashtable ht = new Hashtable();
        ht.Add("@CategoryID", categoryID);
        ht.Add("@SubcategoryID", subcategoryID);
        //ht.Add("@SecondSubcatID", secondSubcatID);
        ht.Add("@ProductTitle", productTitle);

        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_CP_Public_SearchProductTitle_Book", ht);
        }
        catch
        {
            throw;
        }
    }



    /// <summary>
    /// Loads all the Mobile title  based on Cat, Subcategory, SecSubcatID, ProductModelID and Title
    /// USP: USP_CP_Public_SearchProductTitle_Others
    /// </summary>
    /// <param name="categoryID"></param>
    /// <param name="subcategoryID"></param>
    /// <param name="secondSubcatID"></param>
    /// <param name="productModelID"></param>
    /// <param name="productTitle"></param>
    /// <returns></returns>
    public DataTable GetList_MobileTitle(int categoryID, int subcategoryID, int secondSubcatID, int productModelID, string productTitle)
    {
        productTitle = "%" + productTitle + "%";
        Hashtable ht = new Hashtable();
        ht.Add("@CategoryID", categoryID);
        ht.Add("@SubcategoryID", subcategoryID);
        ht.Add("@SecondSubcatID", secondSubcatID);
        ht.Add("@ProductModelID", productModelID);
        ht.Add("@ProductTitle", productTitle);

        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_CP_Public_SearchProductTitle_Others", ht);
        }
        catch
        {
            throw;
        }
    }


    /// <summary>
    /// Loads all the Electronics title based on Category, SubCategory, SecondSubCategory, ProductTitle
    /// USP: USP_CP_Public_SearchProductTitle_Others
    /// </summary>
    /// <param name="_IntCategoryID"></param>
    /// <param name="_IntSubcategoryID"></param>
    /// <param name="_IntSecondSubcatID"></param>
    /// <param name="_ProductModelID"></param>
    /// <param name="_ProductTitle"></param>
    /// <returns></returns>
    public DataTable GetList_ElectronicsTitle(int _IntCategoryID, int _IntSubcategoryID, int _IntSecondSubcatID, int _ProductModelID, string _ProductTitle)
    {
        _ProductTitle = "%" + _ProductTitle + "%";
        Hashtable ht = new Hashtable();
        ht.Add("@CategoryID", _IntCategoryID);
        ht.Add("@SubcategoryID", _IntSubcategoryID);
        ht.Add("@SecondSubcatID", _IntSecondSubcatID);
        ht.Add("@ProductModelID", _ProductModelID);
        ht.Add("@ProductTitle", _ProductTitle);

        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_CP_Public_SearchProductTitle_Others", ht);
        }
        catch
        {
            throw;
        }
    }


    /// <summary>
    /// Loads all the Product list, based on ProfileID.
    /// USP: USP_CP_Public_Load_Posted_ProductList
    /// </summary>
    /// <param name="profileID"></param>
    /// <returns></returns>
    public DataTable GetList_BS_PostedProduct(int profileID,int intCategoryID, DateTime startDate, DateTime endDate)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@ProfileID", profileID);
        ht.Add("@CategoryID", intCategoryID);
        ht.Add("@StartDate", startDate);
        ht.Add("@EndDate", endDate);

        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_CP_Public_Load_Posted_ProductList", ht);
        }
        catch
        {
            throw;
        }
    }

    public DataTable GetList_BS_PostedAllUserProduct(int profileID)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@ProfileID", profileID);
      
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_CP_Public_Load_Posted_AllUserProductList", ht);
        }
        catch
        {
            throw;
        }
    }


    public DataTable GetList_BS_PostedAllUserDiscount(int profileID)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@ProfileID", profileID);

        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_DRP_CP_Public_Load_PostedAllUserDiscount", ht);
        }
        catch
        {
            throw;
        }
    }


    public DataTable GetList_BS_PostedAllUserBoroMelaDiscountSpecial(int profileID)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@ProfileID", profileID);

        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_DRP_CP_Public_Load_PostedAllUserBoroMelaDiscountSpecial", ht);
        }
        catch
        {
            throw;
        }
    }


    public DataTable GetList_BS_SignUPDetailBoroMelaDiscountSpecial(int BoroMelaDiscountSpecialID)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@BoroMelaDiscountSpecialID", BoroMelaDiscountSpecialID);

        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_DRP_CP_Public_Load_SignUPDetailBoroMelaDiscountSpecial", ht);
        }
        catch
        {
            throw;
        }
    }

    public DataTable GetList_BS_PostedAllUserActiveProductList(int profileID)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@ProfileID", profileID);

        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_CP_Public_Load_Posted_AllActiveUserProductList", ht);
        }
        catch
        {
            throw;
        }
    }

    public DataTable GetList_BS_PostedAllUserInActiveProductList(int profileID)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@ProfileID", profileID);

        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_CP_Public_Load_Posted_AllInActiveUserProductList", ht);
        }
        catch
        {
            throw;
        }
    }

    public DataTable GetList_BS_PostedAllUserActiveProductCount(int profileID)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@ProfileID", profileID);

        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_CP_Public_Load_Posted_TotalActiveUserProduct", ht);
        }
        catch
        {
            throw;
        }
    }



    public DataTable GetList_BS_PostedAllUserInActiveProductCount(int profileID)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@ProfileID", profileID);

        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_CP_Public_Load_Posted_TotalInActiveUserProduct", ht);
        }
        catch
        {
            throw;
        }
    }


    public DataTable GetList_BS_PostedProductByCategory(int intProfileID,int intCategoryID)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@ProfileID", intProfileID);
        ht.Add("@CategoryID", intCategoryID);
        
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_CP_Public_Load_Posted_ProductListByCategory", ht);
        }
        catch
        {
            throw;
        }
    }


    public DataTable GetList_CL_PostedProductByCategory(int intProfileID, int intCategoryID)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@ProfileID", intProfileID);
        ht.Add("@CategoryID", intCategoryID);

        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_CP_Public_Load_Posted_ClassifiedProductListByCategory", ht);
        }
        catch
        {
            throw;
        }
    }

    public DataTable GetList_BS_PostedProductByDateRange(int intProfileID, DateTime startDate, DateTime endDate)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@ProfileID", intProfileID);
        ht.Add("@StartDate", startDate);
        ht.Add("@EndDate", endDate);

        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_CP_Public_Load_Posted_ProductListByDateRange", ht);
        }
        catch
        {
            throw;
        }
    }

    public int Update_ActivationStatus(int CategoryID,int ProductID, int ProfileID)
    {
        try
        {
            Hashtable ht = new Hashtable();
            ht.Add("@CategoryID",CategoryID);
            ht.Add("@ProductID", ProductID);
            ht.Add("@ProfileID", ProfileID);
           try
            {
                return this.ExecuteNonQueryStoredProcedure("USP_Update_ActivationStatus", ht);
            }
            catch
            {
                throw;
            }

        }
        catch
        {
            throw;
        }
    }


    public int Update_ActivationStatusBoroMelaDiscountSpecial(int BoroMelaDiscountSpecialID,int ProfileID)
    {
        try
        {
            Hashtable ht = new Hashtable();
            ht.Add("@BoroMelaDiscountSpecialID", BoroMelaDiscountSpecialID);
            ht.Add("@ProfileID", ProfileID);
            try
            {
                return this.ExecuteNonQueryStoredProcedure("USP_Update_ActivationStatusBoroMelaDiscountSpecial", ht);
            }
            catch
            {
                throw;
            }

        }
        catch
        {
            throw;
        }
    }


    public int Update_ActivationStatusDiscount(int CouponID, int ProfileID, string CouponCode)
    {
        try
        {
            Hashtable ht = new Hashtable();
            ht.Add("@CouponID", CouponID);
            ht.Add("@ProfileID", ProfileID);
            ht.Add("@CouponCode", CouponCode);
            try
            {
                return this.ExecuteNonQueryStoredProcedure("USP_DRP_CP_Update_ActivationStatusDiscount", ht);
            }
            catch
            {
                throw;
            }

        }
        catch
        {
            throw;
        }
    }


    public int Update_ActivationStatusClassified(int ProductID)
    {
        try
        {
            Hashtable ht = new Hashtable();
            ht.Add("@ProductID", ProductID);
            try
            {
                return this.ExecuteNonQueryStoredProcedure("USP_Update_ActivationStatusClassified", ht);
            }
            catch
            {
                throw;
            }

        }
        catch
        {
            throw;
        }
    }

    public bool Update_ProductPriceStatus(int CategoryID, int ProductID, int ProfileID,int Price)
    {
       Hashtable ht = new Hashtable();
       ht.Add("@CategoryID", CategoryID);
       ht.Add("@ProductID", ProductID);
       ht.Add("@ProfileID", ProfileID);
       ht.Add("@Price",Price);
       try
       {
           int intActionResult = ExecuteNonQueryStoredProcedure("USP_Update_ProductsAdsPriceStatus", ht);
           return (intActionResult > 0 ? true : false);
       }
       catch
       {
           throw;
       }
    }

    public bool Update_DiscounteffectiveDate(int CouponID, int ProfileID, DateTime effectiveDate, DateTime expirydate)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@CouponID", CouponID);
        ht.Add("@ProfileID", ProfileID);
        ht.Add("@effectiveDate", effectiveDate);
        ht.Add("@expirydate", expirydate);
        try
        {
            int intActionResult = ExecuteNonQueryStoredProcedure("USP_DRP_CP_Update_DiscountDateRange", ht);
            return (intActionResult > 0 ? true : false);
        }
        catch
        {
            throw;
        }
    }

    public bool Update_ProductQtyStatus(int CategoryID, int ProductID, int ProfileID, int Quantity)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@CategoryID", CategoryID);
        ht.Add("@ProductID", ProductID);
        ht.Add("@ProfileID", ProfileID);
        ht.Add("@Qty", Quantity);
        try
        {
            int intActionResult = ExecuteNonQueryStoredProcedure("USP_Update_ProductsQuantityStatus", ht);
            return (intActionResult > 0 ? true : false);
        }
        catch
        {
            throw;
        }
    }


    /// <summary>
    /// Selects ISBN, Author, Publisher name from Product_Master_Book table.
    /// For Tag users.
    /// </summary>
    /// <param name="categoryID"></param>
    /// <param name="subcategoryID"></param>
    /// <param name="secondSubcatIDstring"></param>
    /// <param name="?"></param>
    /// <param name="productID"></param>
    /// <returns></returns>
    public DataTable SelectSpecific_MasterBookRecord(int categoryID, int subcategoryID, int secondSubcatID, int productID)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@CategoryID", categoryID);
        ht.Add("@SubcategoryID", subcategoryID);
        ht.Add("@SecondSubcatID", secondSubcatID);
        ht.Add("@ProductID", productID);
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_CP_Public_Select_MasterBookRecord", ht);
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Checks Product_Master_Book table with CategoryID, SubcategoryID, SecondSubcategoryID and ProductTitle.
    /// Returns true if Duplicate record occurs.
    /// </summary>
    /// <param name="eocPropertyBean"></param>
    /// <returns></returns>
    public bool IsMaster_ProductTitle_Dupllicate(int categoryID, int subcategoryID, int secondSubcatID, string productTitle)
    {
        int intActionResult = -1;
        DataTable dt = new DataTable();

        try
        {
            Hashtable ht = new Hashtable();
            ht.Add("@CategoryID", categoryID);
            ht.Add("@SubcategoryID", subcategoryID);
            ht.Add("@SecondSubcatID", secondSubcatID);
            ht.Add("@ProductTitle", productTitle);

            dt = this.ExecuteStoredProcedureDataTable("USP_CP_Public_BeforeInsertMasterBook_IsProductTitle_Duplicate", ht);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch
        {
            throw;
        }
        
    }

    /// <summary>
    /// Checks Master table with CategoryID, SubcategoryID, SecondSubcategoryID, ModelID and ProductTitle.
    /// </summary>
    /// <param name="categoryID"></param>
    /// <param name="subcategoryID"></param>
    /// <param name="secondSubcatID"></param>
    /// <param name="productTitle"></param>
    /// <returns></returns>
    public bool IsMaster_OtherTitle_Dupllicate(int categoryID, int subcategoryID, int secondSubcatID, int productModelID, string productTitle)
    {
        int intActionResult = -1;
        DataTable dt = new DataTable();

        try
        {
            Hashtable ht = new Hashtable();
            ht.Add("@CategoryID", categoryID);
            ht.Add("@SubcategoryID", subcategoryID);
            ht.Add("@SecondSubcatID", secondSubcatID);
            ht.Add("@ProductModelID", productModelID);
            ht.Add("@ProductTitle", productTitle);


            dt = this.ExecuteStoredProcedureDataTable("USP_CP_Public_BeforeInsertMaster_IsProductTitle_Duplicate", ht);
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch
        {
            throw;
        }

    }
    /// <summary>
    /// Checks Product_Detail_Book table with ProductID, ProfileID and SellerType.
    /// Returns true Seller Tagged this product once.
    /// </summary>
    /// <param name="eocPropertyBean"></param>
    /// <returns></returns>
    public bool Is_Seller_Tagged_Once(int profileID, int productID, bool sellerType, int categoryID)
    {
        //int intActionResult = -1;
        DataTable dt = new DataTable();
        try
        {
            Hashtable ht = new Hashtable();
            ht.Add("@ProfileID", profileID);
            ht.Add("@ProductID", productID);
            ht.Add("@SellerType", sellerType);
            ht.Add("@CategoryID", categoryID);
            dt = this.ExecuteStoredProcedureDataTable("USP_CP_Public_Is_Seller_Tagged_Once", ht);
            
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch
        {
            throw;
        }

    }

    /// <summary>
    /// Selects PaperBackForBook, [Language], DimensionForBook, ShippingWeight, ISBN, 
    ///	Author, Publisher, Edition, CanEditProduct, IsActive From Latest_Posted_BookProduct_View.
    /// It is used in Edit Mode.
    /// USP: USP_CP_Public_Select_Specific_BookRecord /// Need to check
    /// </summary>
    /// <param name="categoryID"></param>
    /// <param name="subcategoryID"></param>
    /// <param name="secondSubcatID"></param>
    /// <param name="productID"></param>
    /// <param name="profileID"></param>
    /// <returns></returns>
    public DataTable Select_BookRecord(int categoryID, int subcategoryID, int secondSubcatID, int productID, int profileID, bool sellerType)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@CategoryID", categoryID);
        ht.Add("@SubcategoryID", subcategoryID);
        ht.Add("@SecondSubcatID", secondSubcatID);
        ht.Add("@ProfileID", profileID);
        ht.Add("@ProductID", productID);
        ht.Add("@SellerType", sellerType);
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_CP_Public_Select_Specific_BookRecord", ht);
        }
        catch
        {
            throw;
        }
    }

   /// <summary>
   /// Inserts Book/Product review in ProductReview_Books table.
   /// USP: USP_Common_ItemDetail_InsertRecord_BookReview.
   /// Previous USP: USP_Common_ItemDetail_InsertReview.
   /// </summary>
   /// <param name="intProductSellerDetailID"></param>
   /// <param name="intProductID"></param>
   /// <param name="intCategoryID"></param>
   /// <param name="strCriticsName"></param>
   /// <param name="strReview"></param>
   /// <returns></returns>
    public int Insert_ProductReview(int intProductSellerDetailID, int intProductID, int intCategoryID, string strCriticsName, string strReview)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@ProductSellerDetailID", intProductSellerDetailID);
        ht.Add("@ProductID", intProductID);
        ht.Add("@CategoryID", intCategoryID);
        ht.Add("@CriticsName", strCriticsName);
        ht.Add("@Review", strReview);
        ht.Add("@UpdatedOn", DateTime.Now);
        try
        {
            return this.ExecuteNonQueryStoredProcedure("USP_Common_ItemDetail_InsertReview", ht);
        }
        catch
        {
            throw;
        }
    }


    /// <summary>
    /// Loads all reviews from ProductReview_Books table.
    /// USP: USP_Common_ItemDetail_LoadList_ProductReview.
    /// 
    /// Previous USP: USP_CP_ProdReview_Books_LoadRecord.
    /// </summary>
    /// <param name="intProfileID"></param>
    /// <param name="intProductID"></param>
    /// <param name="intCateogryID"></param>
    /// <returns></returns>
    public DataTable LoadList_ProductReview(int intProductSellerDetailID, int intProductID, int intCategoryID)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@ProductSellerDetailID", intProductSellerDetailID);
        ht.Add("@ProductID", intProductID);
        ht.Add("@CategoryID", intCategoryID);
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_Common_ItemDetail_LoadList_ProductReview", ht);
        }
        catch
        {
            throw;
        }
    }


    /// <summary>
    /// Loads a single Products Information.
    /// </summary>
    /// <param name="objReview"></param>
    /// <returns></returns>
    public DataTable LoadSingleProduct(int _ProductID, int _CategoryID)
    {
        //int _ActionResult = -1;
        DataTable dt = null;
        Hashtable ht = new Hashtable();
        ht.Add("@ProductID", _ProductID);
        ht.Add("@CategoryID", _CategoryID);
        try
        {
            dt = this.ExecuteStoredProcedureDataTable("USP_Review_LoadSingleProduct", ht);
        }
        catch
        {
            throw;
        }
        return dt;
    }


    /// <summary>
    /// Selects Author, Publisher name from Product_Master_MovieDvdGame table.
    /// For Tag users.
    /// </summary>
    /// <param name="categoryID"></param>
    /// <param name="subcategoryID"></param>
    /// <param name="secondSubcatIDstring"></param>
    /// <param name="?"></param>
    /// <param name="productID"></param>
    /// <returns></returns>
    public DataTable SelectSpecific_MasterMovieDvdGameRecord(int categoryID, int subcategoryID, int secondSubcatID, int productID)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@CategoryID", categoryID);
        ht.Add("@SubcategoryID", subcategoryID);
        ht.Add("@SecondSubcatID", secondSubcatID);
        ht.Add("@ProductID", productID);
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_CP_Public_Select_MasterMovie_DvdGameRecord", ht);
        }
        catch
        {
            throw;
        }
    }


    #region IMAGE UPDATE METHOD
    /// <summary>
    /// Update Image Location in the database.
    /// </summary>
    /// <param name="intProductSellerDetailID"></param>
    /// <param name="intProductID"></param>
    /// <param name="intCategoryID"></param>
    /// <returns></returns>
    public int UpdateImage(int intProductID, int intCategoryID, string strImage)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@ProductID", intProductID);
        ht.Add("@ProductImage", strImage);
        ht.Add("@CategoryID", intCategoryID);
        try
        {
            return this.ExecuteNonQueryStoredProcedure("USP_CP_UpdateImage", ht);
        }
        catch
        {
            throw;
        }
    }

    #endregion IMAGE UPDATE METHOD

    #region Place Order Methods


    /// <summary>
    /// LOads Buyer information.
    /// USP: USP_Common_LoadProduct_Buyer_Information
    /// </summary>
    /// <param name="intProfileID"></param>
    /// <param name="userType"></param>
    /// <returns></returns>

    public DataTable LoadProduct_Buyer_Information(int _OrderID)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@OrderID", _OrderID);
        //ht.Add("@UserType", userType);
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_Common_LoadProduct_Buyer_Information", ht);
        }
        catch
        {
            throw;
        }
    }


    #endregion Place Order Methods



    #region Methods for OrderConfirmation
    /// <summary>
    /// Loads all products listed in the OrderDetail table, and related seller information.
    /// USP: USP_ShoppingCart_LoadList_Product_SellerInformation
    /// </summary>
    /// <param name="intOrderID"></param>
    public DataTable LoadList_Product_Seller_Information(int intOrderID)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@OrderID", intOrderID);
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_ShoppingCart_LoadList_Product_SellerInformation", ht);
        }
        catch
        {
            throw;
        }

    }


    #endregion Methods for OrderConfirmation



    #region Methods For Classified Control Panel

    /// <summary>
    /// Loads Corporate Product Order List. Can be used for both Classified and Corporate Control Panel.
    /// USP: USP_CP_Common_Load_CorporatePlaced_Orders
    /// </summary>
    /// <param name="intProfileID"></param>
    /// <param name="userType"></param>
    /// <returns></returns>
    public DataTable LoadList_PlacedOrder_CorporateProduct(int intProfileID)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@ProfileID", intProfileID);
        
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_CP_Common_Load_CorporatePlaced_Orders", ht);
        }
        catch
        {
            throw;
        }
    }


    #endregion Methods For Classified Control Panel


    #region FOR PRODUCT MODEL LEFT MENU


    /// <summary>
    /// Loads Product Models For Left Menu.
    /// USP: USP_Common_LatestProduct_Load_Model
    /// </summary>
    /// <param name="intCategoryID"></param>
    /// <param name="intSubcategoryID"></param>
    /// <returns></returns>
    public DataTable LoadList_ProductModel(int intCategoryID, int intSubcategoryID)
    {
        Hashtable ht = new Hashtable();
        
        ht.Add("@CategoryID", intCategoryID);
        ht.Add("@SubcategoryID", intSubcategoryID);

        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_Common_LatestProduct_Load_Model", ht);
        }
        catch
        {
            throw;
        }
    }

    #endregion FOR PRODUCT MODEL LEFT MENU


    #region FOR CORPORATE CP
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="_OrderID"></param>
    /// <returns></returns>
    public DataTable Check_Stock( int _ProductSellerDetailID, int _CategoryID)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@CategoryID", _CategoryID);
        ht.Add("@ProductSellerDetailID", _ProductSellerDetailID);
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_CP_Check_Stock", ht);
        }
        catch
        {
            throw;
        }
    }


    #endregion FOR CORPORATE CP


    #region FOR REVIEW LANDING PAGE

    /// <summary>
    /// Loads product that doesnot 
    /// </summary>
    /// <param name="_CategoryID"></param>
    /// <param name="_SubcategoryID"></param>
    /// <param name="_SecondSubcatID"></param>
    /// <param name="_ProductTitile"></param>
    /// <returns></returns>
    public DataTable SearchProduct_WithoutReview(int _CategoryID, int _SubcategoryID, int _SecondSubcatID, string _ProductTitle)
    {
        //int _ActionResult = -1;
        DataTable dt = null;
        Hashtable ht = new Hashtable();
        ht.Add("@ProductTitle", "%"+_ProductTitle+"%");
        ht.Add("@CategoryID", _CategoryID);
        ht.Add("@SubcategoryID", _SubcategoryID);
        ht.Add("@SecondSubcatID", _SecondSubcatID);
        try
        {
            dt = this.ExecuteStoredProcedureDataTable("USP_RLP_Search_Product_WithoutReview", ht);
        }
        catch
        {
            throw;
        }
        return dt;
    }



    #endregion FOR REVIEW LANDING PAGE



    #region FOR REVIEW DISPLAY LANDING PAGE

    /// <summary>
    /// Loads All Products Category With Review Count
    /// </summary>
    /// <param name="_Country"></param>
    /// <returns></returns>
    public DataTable LoadProductCategory_WithReviewCount(string _Country)
    {
        //int _ActionResult = -1;
        DataTable dt = null;
        Hashtable ht = new Hashtable();
        ht.Add("@Country", _Country);
        try
        {
            dt = this.ExecuteStoredProcedureDataTable("USP_Common_LoadProductReview_WithCount", ht);
        }
        catch
        {
            throw;
        }
        return dt;
    }

    #endregion FOR REVIEW DISPLAY LANDING PAGE


    #region FOR CONTROL PANEL

    /// <summary>
    /// Loads Category And Subcategory For CP
    /// </summary>
    /// <returns></returns>
    public DataTable Load_BS_Subcategories()
    {
        DataTable dt = null;
        Hashtable ht = new Hashtable();
        try
        {
            dt = this.ExecuteStoredProcedureDataTable("USP_CP_LoadList_BS_SubCategory", ht);
        }
        catch
        {
            throw;
        }
        return dt;
    }

    /// <summary>
    /// Loads Classified Categories
    /// </summary>
    /// <returns></returns>
    public DataTable Load_CL_Categories()
    {
        DataTable dt = null;
        Hashtable ht = new Hashtable();
        try
        {
            dt = this.ExecuteStoredProcedureDataTable("USP_CP_LoadList_CL_Category", ht);
        }
        catch
        {
            throw;
        }
        return dt;
    }

    #endregion FOR CONTROL PANEL

}


