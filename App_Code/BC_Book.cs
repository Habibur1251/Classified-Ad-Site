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
/// Summary description for BC_Book
/// </summary>
public class BC_Book : DbBaseClass
{
	public BC_Book() : base(StaticSettings.Database.DbConnectionString)
	{
		//
		// TODO: Add constructor logic here
		//
	}

    /// <summary>
    /// Inserts a new row for Book both in Product_Master and Product_Seller_Detail table.
    /// </summary>
    /// <returns></returns>
    public void Add_Master_BookProfile(bool sellerType, bool isActive, bool canEditProduct, int categoryId, int subCategoryId, int secondSubcatId, string productTitle, string description, string qty, string currency, string price, string discountedPrice, string disStartDate, string DisEndDate, string condition, string conditionNote, string paymentOption, string deliveryArea, string codCost, string paperBackForBook, string dimensionForBook, string shippingWeight, string edition, string isbn, string author, string publisher, string image)
    {
        
    }

    /// <summary>
    /// Gets the last SKU(Profile specific) from Product_Seller_Detail table.
    /// USP: USP_CP_Public_GetLastSKU
    /// </summary>
    /// <param name="intProfileID"></param>
    /// <returns></returns>
    public DataTable Get_Last_ProfileSpecificSKU(int intProfileID, bool sellerType)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@ProfileID", intProfileID);
        ht.Add("@SellerType", sellerType);
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_CP_Public_GetLastSKU", ht);
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Generates profile specific unique Sku from supplied strSku.
    /// USP: USP_CP_Public_GetNew_SKU.
    /// </summary>
    /// <param name="strSku"></param>
    /// <returns></returns>
    public DataTable Generate_ProfileSpecific_UniqueSKU(string strSku)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@LastSku",Convert.ToInt32( strSku));
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_CP_Public_GetNew_SKU", ht);
        }
        catch
        {
            throw;
        }
    }

    #region Methods for ItemList_Book page

    /// <summary>
    /// Loads all Latest posted Book by Subcategory.
    /// Uses Country to load Country specific list.
    /// USP: USP_Common_ItemListBook_ShowLatestPostedBookList
    /// </summary>
    /// <param name="intCountryID"></param>
    /// <returns></returns>
    public DataTable LoadList_BookProduct_ByCategory(string strCountry, int intSubcategoryID)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@Country", strCountry);
        ht.Add("@SubcategoryID", intSubcategoryID);
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_Common_ItemListBook_ShowLatestPostedBookList_BySubcategory", ht);
            //return this.ExecuteStoredProcedureDataTable("test1", ht);
        }
        catch
        {
            throw;
        }
    }
    #endregion Methods for ItemList_Book page



    #region Methods for ItemDetail_Book page

    /// <summary>
    /// Loads Lowest Priced Book for ItemDetail_Book page.
    /// USP: USP_Common_ItemDetailBook_LoadBook_LowestPriced
    /// </summary>
    /// <param name="intCountryID"></param>
    /// <param name="intCategoryID"></param>
    /// <param name="intSubcategoryID"></param>
    /// <returns></returns>
    public DataTable LoadBook_LowestPriced(int intProductID, string strCountry, int intCategoryID, int intSubcategoryID, int intSecondSubcatID)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@ProductID", intProductID);
        ht.Add("@Country", strCountry);
        ht.Add("@CategoryID", intCategoryID);
        ht.Add("@SubcategoryID", intSubcategoryID);
        ht.Add("@SecondSubcatID", intSecondSubcatID);
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_Common_ItemDetailBook_LoadBook_LowestPriced", ht);
        }
        catch
        {
            throw;
        }
    }


    /// <summary>
    /// Loads Specific Book record using ProductSellerDetailID \n
    /// USP:
    /// </summary>
    /// <param name="intProductSellerDetailID"></param>
    /// <param name="intCountryID"></param>
    /// <param name="intCategoryID"></param>
    /// <param name="intSubcategoryID"></param>
    /// <param name="intSecondSubcatID"></param>
    /// <returns></returns>
    public DataTable LoadRecord_SpecificBook(int intProductSellerDetailID,int intProductID, string strCountry, 
        int intCategoryID, int intSubcategoryID, int intSecondSubcatID)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@ProductSellerDetailID", intProductSellerDetailID);
        ht.Add("@ProductID", intProductID);
        ht.Add("@Country", strCountry);
        ht.Add("@CategoryID", intCategoryID);
        ht.Add("@SubcategoryID", intSubcategoryID);
        ht.Add("@SecondSubcatID", intSecondSubcatID);
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_Common_ItemDetailBook_LoadRecord_SpecificBook", ht);
        }
        catch
        {
            throw;
        }
    }




    #endregion Methods for ItemDetail_Book page



    #region Methods for Common_Selller page
    /// <summary>
    /// Loads Mixed Book list for a specific ProductID.
    /// USP: USP_Common_LoadBookList_MixedSeller
    /// </summary>
    /// <param name="intProductID"></param>
    /// <param name="intCountryID"></param>
    /// <param name="intCategoryID"></param>
    /// <param name="intSubcategoryID"></param>
    /// <param name="intSecondSubcatID"></param>
    /// <returns></returns>
    public DataTable Load_BookList_MixedSeller(int intProductID, string strCountry, int intCategoryID, int intSubcategoryID, int intSecondSubcatID)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@ProductID", intProductID);
        ht.Add("@Country", strCountry);
        ht.Add("@CategoryID", intCategoryID);
        ht.Add("@SubcategoryID", intSubcategoryID);
        ht.Add("@SecondSubcatID", intSecondSubcatID);
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_Common_LoadBookList_MixedSeller", ht);
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Loads Mixed Book list for a specific ProductID.
    /// USP: USP_Common_LoadBookList_NewSeller
    /// </summary>
    /// <param name="intProductID"></param>
    /// <param name="intCountryID"></param>
    /// <param name="intCategoryID"></param>
    /// <param name="intSubcategoryID"></param>
    /// <param name="intSecondSubcatID"></param>
    /// <returns></returns>
    public DataTable Load_BookList_NewSeller(int intProductID, string strCountry, int intCategoryID, int intSubcategoryID, int intSecondSubcatID)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@ProductID", intProductID);
        ht.Add("@Country", strCountry);
        ht.Add("@CategoryID", intCategoryID);
        ht.Add("@SubcategoryID", intSubcategoryID);
        ht.Add("@SecondSubcatID", intSecondSubcatID);
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_Common_LoadBookList_NewSeller", ht);
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Loads Mixed Book list for a specific ProductID.
    /// USP:  USP_Common_LoadBookList_UsedSeller
    /// </summary>
    /// <param name="intProductID"></param>
    /// <param name="intCountryID"></param>
    /// <param name="intCategoryID"></param>
    /// <param name="intSubcategoryID"></param>
    /// <param name="intSecondSubcatID"></param>
    /// <returns></returns>
    public DataTable Load_BookList_UsedSeller(int intProductID, string strCountry, int intCategoryID, int intSubcategoryID, int intSecondSubcatID)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@ProductID", intProductID);
        ht.Add("@Country", strCountry);
        ht.Add("@CategoryID", intCategoryID);
        ht.Add("@SubcategoryID", intSubcategoryID);
        ht.Add("@SecondSubcatID", intSecondSubcatID);
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_Common_LoadBookList_UsedSeller", ht);
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Loads ProductTitle, Author, MaxPrice, Min Price of Specific ProductID.
    /// USP: USP_Common_LoadRecord_BookHeader
    /// </summary>
    /// <param name="intProductID"></param>
    /// <param name="intCountryID"></param>
    /// <param name="intCategoryID"></param>
    /// <param name="intSubcategoryID"></param>
    /// <param name="intSecondSubcatID"></param>
    /// <returns></returns>
    public DataTable LoadRecord_BookHeader(int intProductID, string strCountry, int intCategoryID, int intSubcategoryID, int intSecondSubcatID)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@ProductID", intProductID);
        ht.Add("@Country", strCountry);
        ht.Add("@CategoryID", intCategoryID);
        ht.Add("@SubcategoryID", intSubcategoryID);
        ht.Add("@SecondSubcatID", intSecondSubcatID);
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_Common_LoadRecord_BookHeader", ht);
        }
        catch
        {
            throw;
        }
    }


    #endregion Methods for Common_Selller page


    #region For Classified Seller Book Entry

    /// <summary>
    /// Loads Classified Seller's Book Information.
    /// User Type is Implicitly Given in the Stored Proc.
    /// USP: USP_CP_CL_SelectSpecific_BookRecord
    /// </summary>
    /// <param name="intProductId"></param>
    /// <param name="intProfileID"></param>
    /// <param name="intCategoryID"></param>
    /// <param name="intSubcategoryID"></param>
    /// <param name="intSecondSubcatID"></param>
    /// <returns></returns>
    public DataTable LoadRecord_CL_SpecificBook(int intProductID, int intProfileID, int intCategoryID, int intSubcategoryID,
        int intSecondSubcatID)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@ProductID", intProductID);
        ht.Add("@ProfileID", intProfileID);
        ht.Add("@CategoryID", intCategoryID);
        ht.Add("@SubcategoryID", intSubcategoryID);
        ht.Add("@SecondSubcatID", intSecondSubcatID);
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_CP_CL_SelectSpecific_BookRecord", ht);
        }
        catch
        {
            throw;
        }
    }
    #endregion For Classified Seller Book Entry


    #region For Business Seller Book Entry


    /// <summary>
    /// Loads Business Seller's Book Information.
    /// User Type is Implicitly Given in the Stored Proc.
    /// USP: USP_CP_BS_SelectSpecific_BookRecord
    /// </summary>
    /// <param name="intProductId"></param>
    /// <param name="intProfileID"></param>
    /// <param name="intCategoryID"></param>
    /// <param name="intSubcategoryID"></param>
    /// <param name="intSecondSubcatID"></param>
    /// <returns></returns>
    public DataTable LoadRecord_BS_SpecificBook(int intProductID, int intProfileID, int intCategoryID, int intSubcategoryID,
        int intSecondSubcatID)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@ProductID", intProductID);
        ht.Add("@ProfileID", intProfileID);
        ht.Add("@CategoryID", intCategoryID);
        ht.Add("@SubcategoryID", intSubcategoryID);
        ht.Add("@SecondSubcatID", intSecondSubcatID);
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_CP_BS_SelectSpecific_BookRecord", ht);
        }
        catch
        {
            throw;
        }
    }


    #endregion For Business Seller Book Entry

}

