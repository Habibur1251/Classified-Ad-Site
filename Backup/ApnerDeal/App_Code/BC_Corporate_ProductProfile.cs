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
/// Summary description for BC_Corporate_ProductProfile
/// </summary>
public class BC_Corporate_ProductProfile : DbBaseClass
{
	public BC_Corporate_ProductProfile() : base(StaticSettings.Database.DbConnectionString)
	{
		//
		// TODO: Add constructor logic here
		//
	}


    /// <summary>
    /// Loads Subcategory Names With Number of items available on that subcategory.
    /// USP: USP_Common_LoadSubcategory_With_Count
    /// </summary>
    /// <param name="_Country"></param>
    /// <param name="_CategoryID"></param>
    /// <returns></returns>
    public DataTable LoadRecord_Subcategory_WithCount(int _CategoryID)
    {
        Hashtable htParams = new Hashtable();
        //htParams.Add("@Country", _Country);
        htParams.Add("@CategoryID", _CategoryID);

        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_Common_LoadSubcategory_With_Count", htParams);
        }
        catch
        {
            throw;
        }
    }
    /// <summary>
    /// Selects CategoryID, Category, InsertedOn, UpdatedOn
    /// from Category table
    /// </summary>
    /// <param name=""></param>
    /// <returns></returns>
    public DataTable LoadRecord_Category(int countryID)
    {
        Hashtable htParams = new Hashtable();
        htParams.Add("@CountryID", countryID);
        
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_CP_ProdProfile_LoadCategory", htParams);
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Loads entire subcategory from subcategory table. Using CategoryID.
    /// </summary>
    /// <returns></returns>
    public DataTable LoadRecord_Subcategory(int categoryID)
    {
        Hashtable htParams = new Hashtable();
        htParams.Add("@CategoryID", categoryID);

        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_CP_Public_LoadSubcategory", htParams);
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Loads all the 2ndSubcategory from SecondarySubCategory table
    /// </summary>
    /// <param name="SubcategoryID"></param>
    /// <returns></returns>
    public DataTable LoadRecord_2ndSubcategory(int categoryID, int subcategoryID)
    { 
        Hashtable htParams = new Hashtable();
        htParams.Add("@CategoryID", categoryID);
        htParams.Add("@SubcategoryID", subcategoryID);

        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_CP_ProdProf_Books_Load2ndSubcategory", htParams);
        }
        catch
        {
            throw;
        }
       
    }


    /// <summary>
    /// Loads Product Model.
    /// USP: USP_Public_LoadModel
    /// </summary>
    /// <param name="categoryID"></param>
    /// <param name="subcategoryID"></param>
    /// <param name="secondSubcatID"></param>
    /// <returns></returns>
    public DataTable LoadList_Model(int categoryID, int subcategoryID, int secondSubcatID)
    {
        Hashtable htParams = new Hashtable();
        htParams.Add("@CategoryID", categoryID);
        htParams.Add("@SubcategoryID", subcategoryID);
        htParams.Add("@SecondSubcatID", secondSubcatID);

        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_Public_LoadModel", htParams);
        }
        catch
        {
            throw;
        }

    }


    #region FOR HOMEPAGE

    /// <summary>
    /// Loads Top 5 Most Viewed Product.
    /// USP: USP_HP_Top_5_Product
    /// </summary>
    /// <param name="_Country"></param>
    /// <returns></returns>
    public DataTable LoadList_HP_Top5_Product(string _Country)
    {
        Hashtable htParams = new Hashtable();
        htParams.Add("@Country", _Country);

        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_HP_Top_5_Product", htParams);
        }
        catch
        {
            throw;
        }

    }


    /// <summary>
    /// Loads Top 5 Products Depending on Administrator Choice
    /// Author: Zakaria
    /// </summary>
    /// <returns></returns>
    public DataTable LoadList_HP_Customized_Top5_Product()
    {
        Hashtable htParams = new Hashtable();
        
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_HP_Customized_Top_5_Product", htParams);
        }
        catch
        {
            throw;
        }

    }

    /// <summary>
    /// Top Discounted Control. Displays Top Discounted Items
    /// </summary>
    /// <returns></returns>
    public DataTable LoadList_TopDiscounted_Product()
    {
        Hashtable htParams = new Hashtable();

        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_HP_TopFive_DiscountedItems", htParams);
        }
        catch
        {
            throw;
        }

    }

    public DataTable LoadList_AllTopDiscounted_Product()
    {
        Hashtable htParams = new Hashtable();

        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_HP_All_DiscountedItems", htParams);
        }
        catch
        {
            throw;
        }

    }

    public DataTable LoadList_SearchAllTopDiscounted_Product(int categoryID)
    {
        Hashtable htParams = new Hashtable();
        htParams.Add("@CategoryID", categoryID);
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_HP_SearchByCategory_DiscountedItems", htParams);
        }
        catch
        {
            throw;
        }

    }


    #endregion FOR HOMEPAGE


    #region FOR REAL ESTATE

    public DataTable RealEstate_LoadList_SellerType(int subcategoryID)
    {
        Hashtable htParams = new Hashtable();
        //htParams.Add("@CategoryID", categoryID);
        htParams.Add("@SubcategoryID", subcategoryID);
        //htParams.Add("@SecondSubcatID", secondSubcatID);

        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_CP_RealEstate_Load_SellerType", htParams);
        }
        catch
        {
            throw;
        }

    }

    #endregion FOR REAL ESTATE

    #region Filtering Method For MovieMusicGame

    /// <summary>
    /// Loads latest producttitle For MovieMusicGame.
    /// USP:USP_Load_TopMoviesTitle_MovieMusic
    /// Author: Mokammal
    /// </summary>
    /// <param name="_Country"></param>
    /// <param name="_CategoryID"></param>
    /// <returns></returns>
    public DataTable LoadRecord_LatestProductTitle_MovieMusic(int _CategoryID, int _SubCatID)
    {
        Hashtable htParams = new Hashtable();
        htParams.Add("@CategoryID", _CategoryID);
        htParams.Add("@SubCategoryID", _SubCatID);

        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_Load_TopMoviesTitle_MovieMusic", htParams);
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Load Top 10 Director of Movie
    /// USP:USP_Common_MovieMusicGame_Load_Top10Director
    /// Author: Mokammal
    /// </summary>
    /// <param name="_Country"></param>
    /// <param name="_CategoryID"></param>
    /// <returns></returns>
    public DataTable LoadRecord_Top10Director_Movie(int _CategoryID, int _SubCatID, string _Location)
    {
        Hashtable htParams = new Hashtable();
        htParams.Add("@CategoryID", _CategoryID);
        htParams.Add("@SubCategoryID", _SubCatID);
        htParams.Add("@Country", _Location);

        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_Common_MovieMusicGame_Load_Top10Director", htParams);
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Load Movies By language
    /// USP:USP_MovieMusicGame_Load_LatestMovies_ByLanguage
    /// Author: Mokammal
    /// </summary>
    /// <param name="_Country"></param>
    /// <param name="_CategoryID"></param>
    /// <returns></returns>
    public DataTable Loadlist_Movies_ByLanguage(int _CategoryID, int _SubCatID, string _Location)
    {
        Hashtable htParams = new Hashtable();
        htParams.Add("@CategoryID", _CategoryID);
        htParams.Add("@SubCategoryID", _SubCatID);
        htParams.Add("@Country", _Location);

        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_MovieMusicGame_Load_LatestMovies_ByLanguage", htParams);
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Load Top 10 SecondSubCategory of Movie Music Games
    /// USP:USP_MovieMusicGame_Load_Top10_SecondSubCat
    /// Author: Mokammal
    /// </summary>
    /// <param name="_Country"></param>
    /// <param name="_CategoryID"></param>
    /// <returns></returns>
    public DataTable Load_Top10Secondsubcat_MovieMusicGame(int _CategoryID, int _SubCatID, string _Location)
    {
        Hashtable htParams = new Hashtable();
        htParams.Add("@CategoryID", _CategoryID);
        htParams.Add("@SubCategoryID", _SubCatID);
        htParams.Add("@Country", _Location);

        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_MovieMusicGame_Load_Top10_SecondSubCat", htParams);
        }
        catch
        {
            throw;
        }
    }

    #endregion Filtering Method For MovieMusicGame

}
