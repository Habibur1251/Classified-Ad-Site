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
/// Summary description for BC_MovieDvd
/// </summary>
public class BC_MovieDvd : DbBaseClass
{
    public BC_MovieDvd()
        : base(StaticSettings.Database.DbConnectionString)
	{
		//
		// TODO: Add constructor logic here
		//
	}

    #region For Classified Seller MovieDvd  Entry

    /// <summary>
    /// Loads Classified Seller's MovieDvd Information.
    /// User Type is Implicitly Given in the Stored Proc.
    /// USP: USP_CP_CL_SelectSpecific_BookRecord
    /// </summary>
    /// <param name="intProductId"></param>
    /// <param name="intProfileID"></param>
    /// <param name="intCategoryID"></param>
    /// <param name="intSubcategoryID"></param>
    /// <param name="intSecondSubcatID"></param>
    /// <returns></returns>
    public DataTable LoadRecord_CL_SpecificMovieDvd(int intProductID, int intProfileID, int intCategoryID, int intSubcategoryID,
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
            return this.ExecuteStoredProcedureDataTable("USP_CP_CL_SelectSpecific_MovieDvdRecord", ht);
        }
        catch
        {
            throw;
        }
    }

    #endregion For Classified Seller  MovieDVD Entry

    #region For Business_ Seller MovieDvd Entry

    public DataTable LoadRecord_BS_SpecificMovieDvd(int intProductID, int intProfileID, int intCategoryID, int intSubcategoryID,
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
            return this.ExecuteStoredProcedureDataTable("USP_CP_BS_SelectSpecific_MovieDvdRecord", ht);
        }
        catch
        {
            throw;
        }
    }
    #endregion For Business_ Seller MovieDvd Entry

    #region Methods for ItemList_MovieDvdGame 

    /// <summary>
    /// Loads all Latest posted MovieDvdGame by Subcategory.
    /// </summary>
    /// <param name="intCountryID"></param>
    /// <returns></returns>
    public DataTable LoadList_MovieDvdProduct_ByCategory(string strCountry, int intSubcategoryID)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@Country", strCountry);
        ht.Add("@SubcategoryID", intSubcategoryID);
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_Common_ItemListMovie_ShowLatestPosted_MovieDvdGameList_BySubcategory", ht);
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Loads MovieDvd Items. Based On Price Range.
    /// USP: USP_Common_ItemList_LatestPosted_Product_ByPrice
    /// </summary>
    /// <param name="intCategoryID"></param>
    /// <param name="intSubcategoryID"></param>
    /// <param name="intPriceRangeID"></param>
    /// <returns></returns>
    public DataTable LoadList_MovieMusic_ByPrice(int intCategoryID, int intSubcategoryID, int intPriceRangeID)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@CategoryID", intCategoryID);
        ht.Add("@SubcategoryID", intSubcategoryID);
        ht.Add("@PriceRangeID", intPriceRangeID);
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_Common_ItemList_LatestPosted_Product_ByPrice", ht);
        }
        catch
        {
            throw;
        }
    }

    #endregion Methods for ItemList_MovieDvdGame

    #region Methods for ItemDetail_MovieMusicGame

    /// <summary>
    /// Loads Lowest Priced MovieMusicGame for ItemDetail_MovieMusicGame.
    /// USP: USP_Common_ItemDetailMovie_LoadMovieMusicGame_LowestPriced
    /// </summary>
    /// <param name="intCountryID"></param>
    /// <param name="intCategoryID"></param>
    /// <param name="intSubcategoryID"></param>
    /// <returns></returns>
    public DataTable LoadMovieMusic_LowestPriced(int intProductID, string strCountry, int intCategoryID, int intSubcategoryID, int intSecondSubcatID)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@ProductID", intProductID);
        ht.Add("@Country", strCountry);
        ht.Add("@CategoryID", intCategoryID);
        ht.Add("@SubcategoryID", intSubcategoryID);
        ht.Add("@SecondSubcatID", intSecondSubcatID);
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_Common_ItemDetailMovie_LoadMovieMusicGame_LowestPriced", ht);
        }
        catch
        {
            throw;
        }
    }


    /// <summary>
    /// Loads Specific MovieMusicGame record using ProductSellerDetailID \n
    /// USP:
    /// </summary>
    /// <param name="intProductSellerDetailID"></param>
    /// <param name="intCountryID"></param>
    /// <param name="intCategoryID"></param>
    /// <param name="intSubcategoryID"></param>
    /// <param name="intSecondSubcatID"></param>
    /// <returns></returns>
    public DataTable LoadRecord_SpecificMovieMusicGame(int intProductSellerDetailID, int intProductID, string strCountry,
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
            return this.ExecuteStoredProcedureDataTable("USP_Common_ItemDetail_LoadRecord_SpecificMovieMusicGame", ht);
        }
        catch
        {
            throw;
        }
    }

    #endregion Methods for ItemDetail_MovieMusicGame

    #region Methods for Common_Selller page

    /// <summary>
    /// Loads Mixed MovieMusicDvd list for a specific ProductID.
    /// USP: USP_Common_LoadMovieMusicList_MixedSeller
    /// </summary>
    /// <param name="intProductID"></param>
    /// <param name="intCountryID"></param>
    /// <param name="intCategoryID"></param>
    /// <param name="intSubcategoryID"></param>
    /// <param name="intSecondSubcatID"></param>
    /// <returns></returns>
    public DataTable Load_MovieMusicList_MixedSeller(int intProductID, string strCountry, int intCategoryID, int intSubcategoryID, int intSecondSubcatID)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@ProductID", intProductID);
        ht.Add("@Country", strCountry);
        ht.Add("@CategoryID", intCategoryID);
        ht.Add("@SubcategoryID", intSubcategoryID);
        ht.Add("@SecondSubcatID", intSecondSubcatID);
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_Common_LoadMovieMusicList_MixedSeller", ht);
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Loads Mixed Movie list for a specific ProductID.
    /// USP: USP_Common_LoadMovieMusicList_NewSeller
    /// </summary>
    /// <param name="intProductID"></param>
    /// <param name="intCountryID"></param>
    /// <param name="intCategoryID"></param>
    /// <param name="intSubcategoryID"></param>
    /// <param name="intSecondSubcatID"></param>
    /// <returns></returns>
    public DataTable Load_MovieList_NewSeller(int intProductID, string strCountry, int intCategoryID, int intSubcategoryID, int intSecondSubcatID)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@ProductID", intProductID);
        ht.Add("@Country", strCountry);
        ht.Add("@CategoryID", intCategoryID);
        ht.Add("@SubcategoryID", intSubcategoryID);
        ht.Add("@SecondSubcatID", intSecondSubcatID);
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_Common_LoadMovieMusicList_NewSeller", ht);
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Loads used MovieMusicGame list for a specific ProductID.
    /// USP:  USP_Common_LoadMovieList_UsedSeller
    /// </summary>
    /// <param name="intProductID"></param>
    /// <param name="intCountryID"></param>
    /// <param name="intCategoryID"></param>
    /// <param name="intSubcategoryID"></param>
    /// <param name="intSecondSubcatID"></param>
    /// <returns></returns>
    public DataTable Load_MovieList_UsedSeller(int intProductID, string strCountry, int intCategoryID, int intSubcategoryID, int intSecondSubcatID)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@ProductID", intProductID);
        ht.Add("@Country", strCountry);
        ht.Add("@CategoryID", intCategoryID);
        ht.Add("@SubcategoryID", intSubcategoryID);
        ht.Add("@SecondSubcatID", intSecondSubcatID);
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_Common_LoadMovieList_UsedSeller", ht);
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Loads ProductTitle, Author, MaxPrice, Min Price of Specific ProductID for MovieMusic game category
    /// USP: USP_Common_LoadRecord_BookHeader
    /// </summary>
    /// <param name="intProductID"></param>
    /// <param name="intCountryID"></param>
    /// <param name="intCategoryID"></param>
    /// <param name="intSubcategoryID"></param>
    /// <param name="intSecondSubcatID"></param>
    /// <returns></returns>
    public DataTable LoadRecord_MovieMusicHeader(int intProductID, string strCountry, int intCategoryID, int intSubcategoryID, int intSecondSubcatID)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@ProductID", intProductID);
        ht.Add("@Country", strCountry);
        ht.Add("@CategoryID", intCategoryID);
        ht.Add("@SubcategoryID", intSubcategoryID);
        ht.Add("@SecondSubcatID", intSecondSubcatID);
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_Common_LoadRecord_MovieMusicHeader", ht);
        }
        catch
        {
            throw;
        }
    }

    
    #endregion Methods for Common_Selller page

    #region LatestProductTitle for Movie, Music, Game

    /// <summary>
    /// Loads all Latest posted Movie, Music, Game by SecondSubcat.
    /// </summary>
    /// <param name="intCountryID"></param>
    /// <returns></returns>
    public DataTable Load_LatestPosted_MovieTitle_BySecondSubCat(string strCountry, int intCategoryID, int intSubcategoryID, int intSecondSubCatID)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@Country", strCountry);
        ht.Add("@CategoryID", intCategoryID);
        ht.Add("@SubcategoryID", intSubcategoryID);
        ht.Add("@SecondSubCatID", intSecondSubCatID);        
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_Common_ItemListMovie_ShowLatestPostedMovie_BySecondSubcategory", ht);
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Loads Top 10 Director of Movie
    /// </summary>
    /// <param name="intCountryID"></param>
    /// <returns></returns>
    public DataTable Load_Top10Director_Movie(string _Author,string _Country, int _SubcategoryID)
    {
        Hashtable htParams = new Hashtable();
        htParams.Add("@Author", _Author);
        htParams.Add("@Country", _Country);
        htParams.Add("@SubcategoryID", _SubcategoryID);

        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_Common_ItemListMovieMusic_ShowTop10_MovieDirector", htParams);
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Select Movies by Language
    /// </summary>
    /// <param name="intCountryID"></param>
    /// <returns></returns>
    public DataTable Load_Movies_ByLanguage(string _Language, string _Country, int _SubcategoryID)
    {
        Hashtable htParams = new Hashtable();
        htParams.Add("@Language", _Language);
        htParams.Add("@Country", _Country);
        htParams.Add("@SubcategoryID", _SubcategoryID);

        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_Common_ItemListMovieMusic_ShowMovie_ByLanguage", htParams);
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Select Movies by SecondSubCategory
    /// </summary>
    /// <param name="intCountryID"></param>
    /// <returns></returns>
    public DataTable Load_Movies_BySecondsubcat(string _SecondSubcat, string _Country, int _SubcategoryID)
    {
        Hashtable htParams = new Hashtable();
        htParams.Add("@SecondSubcategory", _SecondSubcat);
        htParams.Add("@Country", _Country);
        htParams.Add("@SubcategoryID", _SubcategoryID);

        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_Common_ItemListMovieMusic_ShowMovie_BySecondSubcategory", htParams);
        }
        catch
        {
            throw;
        }
    }

    #endregion LatestProductTitle for Movie, Music, Game
}
