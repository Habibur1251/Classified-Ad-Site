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
/// Summary description for BC_Review
/// </summary>
public class BC_Review:DbBaseClass
{
   // public string ImagePath
    //{
    //    get { return ImagePath; }
    //    set { ImagePath = value; }
    //}

	public BC_Review():base(StaticSettings.Database.DbConnectionString)
	{
    }
    
    
    
    
    //new add code

    private string _ProductImage;

    public string ProductImage
    {
        get { return _ProductImage; }
        set { _ProductImage = value; }
    }
    
    
    

    //new add code

    /// <summary>
    /// Inserts a review in the review table.
    /// </summary>
    /// <param name="objReview"></param>
    /// <returns></returns>
    public bool AddReview(Review objReview)
    {
        int _ActionResult = -1;
        Hashtable ht = new Hashtable();
        //ht.Add("@ProductSellerDetailID", objReview.ProductSellerDetailID);
        ht.Add("@ProductID", objReview.ProductID);
        ht.Add("@CategoryID", objReview.CategoryID);
        ht.Add("@ProfileID", objReview.ProfileID);
        ht.Add("@Review", objReview.CustomerReview);
        ht.Add("@ReviewTitle", objReview.ReviewTitle);
        ht.Add("@Rating", objReview.Rating);
        double length = objReview.CustomerReview.Length;
        try
        {
             _ActionResult = this.ExecuteNonQueryStoredProcedure("USP_Review_InsertReview", ht);
        }
        catch
        {
            throw;
        }
        return _ActionResult > 0 ? true : false;
    }

    /// <summary>
    /// Increments a Product Review HitCounterField.
    /// USP: USP_Common_BS_ProductReview_HitCounter
    /// </summary>
    /// <param name="objProduct"></param>
    /// <returns></returns>
    public int IncrementReviewCounter(Review objReview)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@CategoryID", objReview.CategoryID);
        ht.Add("@ProductID", objReview.ProductID);
        try
        {
            return this.ExecuteNonQueryStoredProcedure("USP_Common_BS_ProductReview_HitCounter", ht);
        }
        catch
        {
            throw;
        }
    }


    public int IncrementReviewCounterDetail(Review objReview)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@ProfileID", objReview.ProfileID);
        ht.Add("@CategoryID", objReview.CategoryID);
        ht.Add("@ProductID", objReview.ProductID);
        try
        {
            return this.ExecuteNonQueryStoredProcedure("USP_Common_BS_ProductReviewDetail_HitCounter", ht);
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Increments a General Review HitCounterField.
    /// USP: USP_Common_BS_ProductReview_HitCounter
    /// </summary>
    /// <param name="objProduct"></param>
    /// <returns></returns>
    public int IncrementGeneralReviewCounter(int _BusinessServiceID, int _ReviewCategoryID)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@BusinessServiceID", _BusinessServiceID);
        ht.Add("@ReviewCategoryID", _ReviewCategoryID);
        try
        {
            return this.ExecuteNonQueryStoredProcedure("USP_Common_BS_GeneralReview_HitCounter", ht);
        }
        catch
        {
            throw;
        }
    }

    public int IncrementGeneralReviewCounterDeatail(int _BusinessServiceID, int _ReviewCategoryID, int _ReviewID)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@BusinessServiceID", _BusinessServiceID);
        ht.Add("@ReviewCategoryID", _ReviewCategoryID);
        ht.Add("@ReviewID", _ReviewID);
        try
        {
            return this.ExecuteNonQueryStoredProcedure("USP_Common_BS_GeneralReview_HitCounterDetail", ht);
        }
        catch
        {
            throw;
        }
    }


    /// <summary>
    /// Checks if any User is trying to add multiple review.
    /// Returns False if User already added a review, True otherwise.
    /// </summary>
    /// <param name="objReview"></param>
    /// <returns></returns>
    public bool IsDuplicateReview(Review objReview)
    {
        DataTable dt = null;
        Hashtable ht = new Hashtable();
        ht.Add("@ProductID", objReview.ProductID);
        ht.Add("@CategoryID", objReview.CategoryID);
        ht.Add("@ProfileID", objReview.ProfileID);
        try
        {
            dt = this.ExecuteStoredProcedureDataTable("USP_Review_IsReviewDuplicate", ht);
        }
        catch
        {
            throw;
        }
        if (dt.Rows.Count > 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    /// <summary>
    /// Checks if a user has already voted for a review.
    /// Returns true if user already vote once, false otherwise.
    /// USP: USP_Review_IS_UserVotedOnce
    /// </summary>
    /// <param name="objReview"></param>
    /// <returns></returns>
    public bool IsUserVotedOnce(Review objReview)
    {
        DataTable dt = null;
        Hashtable ht = new Hashtable();
        ht.Add("@ReviewID", objReview.ReviewID);
        ht.Add("@ProfileID", objReview.ProfileID);
        try
        {
            dt = this.ExecuteStoredProcedureDataTable("USP_Review_IS_UserVotedOnce", ht);
        }
        catch
        {
            throw;
        }
        if (dt.Rows.Count > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Updates Helpful review Column. And also inserts profileid and reviewid in HelpfulReviewVote
    /// USP: USP_Review_InsertVote
    /// </summary>
    /// <param name="objReview"></param>
    /// <returns></returns>
    public bool InsertYesVote(Review objReview)
    {
        int _ActionResult = -1;
        Hashtable ht = new Hashtable();
        ht.Add("@ReviewID", objReview.ReviewID);
        ht.Add("@ProfileID", objReview.ProfileID);
        try
        {
            _ActionResult = this.ExecuteNonQueryStoredProcedure("USP_Review_InsertYesVote", ht);
        }
        catch
        {
            throw;
        }
        return _ActionResult > 0 ? true : false;
    }

    /// <summary>
    /// Updates NotHelpful review Column. And also inserts profileid and reviewid in HelpfulReviewVote.
    /// USP: 
    /// </summary>
    /// <param name="objReview"></param>
    /// <returns></returns>
    public bool InsertNoVote(Review objReview)
    {
        int _ActionResult = -1;
        Hashtable ht = new Hashtable();
        ht.Add("@ReviewID", objReview.ReviewID);
        ht.Add("@ProfileID", objReview.ProfileID);
        try
        {
            _ActionResult = this.ExecuteNonQueryStoredProcedure("USP_Review_InsertNoVote", ht);
        }
        catch
        {
            throw;
        }
        return _ActionResult > 0 ? true : false;
    }



    /// <summary>
    /// Inserts a comment in the comment table.
    /// </summary>
    /// <param name="objReview"></param>
    /// <returns></returns>
    public bool InsertComment(Review objReview)
    {
        int _ActionResult = -1;
        Hashtable ht = new Hashtable();
        ht.Add("@ReviewID", objReview.ReviewID);
        ht.Add("@Comment", objReview.Comment);
        ht.Add("@ProfileID", objReview.ProfileID);

        try
        {
            _ActionResult = this.ExecuteNonQueryStoredProcedure("USP_Review_InsertComment", ht);
        }
        catch
        {
            throw;
        }
        return _ActionResult > 0 ? true : false;
    }

    /// <summary>
    /// Inserts a reply in the reply table.
    /// </summary>
    /// <param name="objReview"></param>
    /// <returns></returns>
    public bool InsertReply(Review objReview)
    {
        int _ActionResult = -1;
        Hashtable ht = new Hashtable();
        ht.Add("@Reply", objReview.Reply);
        ht.Add("@CommentID", objReview.CommentID);
        ht.Add("@ProfileID", objReview.ProfileID);
        try
        {
            _ActionResult = this.ExecuteNonQueryStoredProcedure("USP_Review_InsertReply", ht);
        }
        catch
        {
            throw;
        }
        return _ActionResult > 0 ? true : false;
    }


    /// <summary>
    /// Loads a Single Review
    /// USP: USP_Review_LoadSingleReview
    /// </summary>
    /// <param name="objReview"></param>
    /// <returns></returns>
    public DataTable LoadSingleReview(Review objReview)
    {
        int _ActionResult = -1;
        Hashtable ht = new Hashtable();
        ht.Add("@CategoryID", objReview.CategoryID);
        ht.Add("@ProfileID", objReview.ProfileID);
        ht.Add("@ProductID", objReview.ProductID);
        try
        {
             return this.ExecuteStoredProcedureDataTable("USP_Review_LoadSingleReview", ht);
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Loads Rating Detail
    /// USP: USP_Review_LoadDetailRating
    /// </summary>
    /// <param name="objReview"></param>
    /// <returns></returns>
    public DataTable LoadDetailRating(Review objReview)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@ProductID", objReview.ProductID);
        ht.Add("@CategoryID", objReview.CategoryID);
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_Review_LoadDetailRating", ht);
        }
        catch
        {
            throw;
        }
    }


    /// <summary>
    /// Loads Rating Detail For Non BoroMela Product
    /// USP: USP_Review_LoadDetailRating
    /// </summary>
    /// <param name="objReview"></param>
    /// <returns></returns>
    public DataTable LoadDetailRating_Non_BoroMelaProduct(Review objReview)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@ProductID", objReview.ProductID);
        ht.Add("@CategoryID", objReview.CategoryID);
        ht.Add("@IsBizReview", objReview.IsBizReview);
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_Review_LoadDetailRating_Non_BoroMelaProduct", ht);
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Loads all reviews made on a single product.
    /// Order By latest inserted review.
    /// USP: USP_Review_LoadListReview_OrderByLatest.sql
    /// </summary>
    /// <param name="objReview"></param>
    /// <returns></returns>
    public DataTable LoadListReview_OrderByLatest(Review objReview)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@ProductID", objReview.ProductID);
        ht.Add("@CategoryID", objReview.CategoryID);
        //ht.Add("@SubcategoryID", objReview.SubcategoryID);

        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_Review_LoadListReview_OrderByLatest", ht);
        }
        catch
        {
            throw;
        }
    }


    /// <summary>
    /// Loads all reviews made on a single product.
    /// Order By latest inserted review.
    /// USP: USP_Review_LoadListReview_OrderByLatest_BoromelaProduct
    /// </summary>
    /// Author: Mokammal
    /// <param name="objReview"></param>
    /// <returns></returns>
    public DataTable LoadListReview_OrderByLatest_BoromelaProduct(Review objReview)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@ProductID", objReview.ProductID);
        ht.Add("@CategoryID", objReview.CategoryID);
        ht.Add("@SubcategoryID", objReview.SubcategoryID);
        ht.Add("@IsBizReview", objReview.IsBizReview);

        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_Review_LoadListReview_OrderByLatest_BoromelaProduct", ht);
        }
        catch
        {
            throw;
        }
    }



    /// <summary>
    /// Loads Top one most helpful review
    /// USP: USP_Review_Load_Most_Helpful_Review
    /// </summary>
    /// <param name="objReview"></param>
    /// <returns></returns>
    public DataTable LoadTop_MostHelful_Review(Review objReview)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@ProductID", objReview.ProductID);
        ht.Add("@CategoryID", objReview.CategoryID);
        //ht.Add("@SubcategoryID", objReview.SubcategoryID);
       // ht.Add("@IsBizReview", objReview.IsBizReview);

        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_Review_Load_Most_Helpful_Review", ht);
            //return this.ExecuteStoredProcedureDataTable("USP_Review_Load_Most_HelpfulAndCritical_Review", ht);
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Loads Top one most helpful review
    /// USP: USP_Review_Load_Most_Critical_Review
    /// </summary>
    /// <param name="objReview"></param>
    /// <returns></returns>
    public DataTable LoadTop_MostCritical_Review(Review objReview)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@ProductID", objReview.ProductID);
        ht.Add("@CategoryID", objReview.CategoryID);
       // ht.Add("@SubcategoryID", objReview.SubcategoryID);
      //  ht.Add("@IsBizReview", objReview.IsBizReview);

        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_Review_Load_Most_Critical_Review", ht);
            //return this.ExecuteStoredProcedureDataTable("USP_Review_Load_Most_HelpfulAndCritical_Review", ht);
        }
        catch
        {
            throw;
        }
    }


    /// <summary>
    /// Loads all reviews made on a single product.
    /// Order By Mosthelpful review.
    /// USP: USP_Review_LoadListReview_OrderByMostHelpful
    /// </summary>
    /// <param name="objReview"></param>
    /// <returns></returns>
    public DataTable LoadListReview_OrderByMostHelpful(Review objReview)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@ProductID", objReview.ProductID);
        ht.Add("@CategoryID", objReview.CategoryID);

        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_Review_LoadListReview_OrderByMostHelpful", ht);
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Loads Comments on a particular review.
    /// </summary>
    /// <param name="objReview"></param>
    /// <returns></returns>
    public DataTable LoadListComments(Review objReview)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@ReviewID", objReview.ReviewID);
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_Review_LoadListComments", ht);
        }
        catch
        {
            throw;
        }
    }


    /// <summary>
    /// Loads all Reply made on a single Comment
    /// USP: USP_Review_LoadListReply
    /// </summary>
    /// <param name="objReview"></param>
    /// <returns></returns>
    public DataTable LoadListReply(Review objReview)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@CommentID", objReview.CommentID);
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_Review_LoadListReply", ht);
        }
        catch
        {
            throw;
        }
    }


    #region REVIEW HOMEPAGE CONTROL

    /// <summary>
    /// Loads latest review for homepage.
    /// USP: USP_HP_Review_LoadLatest_Review
    /// </summary>
    /// <param name="objReview"></param>
    /// <returns></returns>
    public DataTable HP_LoadLatestReview(Review objReview)
    {
        int _ActionResult = -1;
        Hashtable ht = new Hashtable();
        ht.Add("@CountryID", objReview.CountryID);
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_HP_Review_LoadLatest_Review", ht);
        }
        catch
        {
            throw;
        }
    }

    public DataTable HP_LoadAllUserReview(Review objReview)
    {
        int _ActionResult = -1;
        Hashtable ht = new Hashtable();
        ht.Add("@ProfileID", objReview.ProfileID);
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_HP_Review_LoadAllUser_Review", ht);
        }
        catch
        {
            throw;
        }
    }


    public DataTable HP_LoadAllPostedReview()
    {
        int _ActionResult = -1;
        Hashtable ht = new Hashtable();
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_HP_Review_LoadAllPosted_Review", ht);
        }
        catch
        {
            throw;
        }
    }

    

    #endregion REVIEW HOMEPAGE CONTROL


    #region REVIEW LANDING PAGE

    /// <summary>
    /// Loads General Review Category
    /// </summary>
    /// <returns></returns>
    public DataTable LoadList_ReviewCategory()
    {
        Hashtable ht = new Hashtable();
        //ht.Add("@CommentID", objReview.CommentID);
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_RLP_Load_ReviewCategory", ht);
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Loads Business Service Category
    /// </summary>
    /// <returns></returns>
    public DataTable LoadList_Review_BusinessCategory()
    {
        Hashtable ht = new Hashtable();
        //ht.Add("@CommentID", objReview.CommentID);
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_RLP_LoadReview_BusinessCategory", ht);
        }
        catch
        {
            throw;
        }
    }



    /// <summary>
    /// Loads Review Subcategory
    /// </summary>
    /// <returns></returns>
    public DataTable LoadList_ReviewSubcategory(int _ReviewCategoryID)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@ReviewCategoryID", _ReviewCategoryID);
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_RLP_LoadReviewSubcateogry", ht);
        }
        catch
        {
            throw;
        }
    }


    /// <summary>
    /// Searches for Product to write a review.
    /// </summary>
    /// <param name="_CategoryID"></param>
    /// <param name="_ProductTitle"></param>
    /// <returns></returns>
    public DataTable LoadSearched_ProductsReview(int _CategoryID, int _SubcategoryID, int _SecondSubcatID, string _ProductTitle)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@CategoryID", _CategoryID);
        ht.Add("@SubcategoryID", _SubcategoryID);
        ht.Add("@SecondSubcatID", _SecondSubcatID);
        ht.Add("@ProductTitle", "%" + _ProductTitle + "%");
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_RLP_SearchProduct", ht);
        }
        catch
        {
            throw;
        }
    }


    /// <summary>
    /// Searches for Business/Service to write a review.
    /// </summary>
    /// <param name="_CategoryID"></param>
    /// <param name="_ProductTitle"></param>
    /// <returns></returns>
    public DataTable LoadSearched_BusinessService_Review(int _ReviewCategoryID, int _ReviewSubcategoryID, string _BusinessService)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@ReviewCategoryID", _ReviewCategoryID);
        ht.Add("@ReviewSubcategoryID", _ReviewSubcategoryID);
        ht.Add("@BusinessService", "%" + _BusinessService + "%");
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_RLP_SearchBusinessService_Review", ht);
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Inserts new Business and then inserts reveiew on it.
    /// </summary>
    /// <param name="objReview"></param>
    /// <returns></returns>
    public bool Insert_NewBusinessReview(Review objReview)
    {
        int _ActionResult = -1;
        Hashtable ht = new Hashtable();
        ht.Add("@BusinessService", objReview.BusinessService);
        ht.Add("@ReviewCategoryID", objReview.CategoryID);
        ht.Add("@ReviewSubcategoryID", objReview.SubcategoryID);
        ht.Add("@ProfileID", objReview.ProfileID);
        ht.Add("@Review", objReview.CustomerReview);
        ht.Add("@Description", objReview.Descriptiom);
        ht.Add("@ReviewTitle", objReview.ReviewTitle);
        ht.Add("@Rating", objReview.Rating);
        ht.Add("@ContactAddress", objReview.ContactAddress);
        ht.Add("@Phone", objReview.Phone);
        ht.Add("@ProductImage", objReview.ProductImage);
        try
        {
            _ActionResult = this.ExecuteNonQueryStoredProcedure("USP_RLP_Insert_NewBusinessReview", ht);
        }
        catch
        {
            throw;
        }
        return _ActionResult > 0 ? true : false;
    }


    /// <summary>
    /// Inserts review on a specific business/service
    /// </summary>
    /// <param name="objReview"></param>
    /// <returns></returns>
    public bool Insert_BusinessReview(Review objReview)
    {
        int _ActionResult = -1;
        Hashtable ht = new Hashtable();
        ht.Add("@BusinessServiceID", objReview.BusinessServiceID);
        ht.Add("@ProfileID", objReview.ProfileID);
        ht.Add("@Review", objReview.CustomerReview);


        ht.Add("@ReviewTitle", objReview.ReviewTitle);
        ht.Add("@Rating", objReview.Rating);
        try
        {
            if (objReview.CategoryID == 6)
            {
                ht.Add("@ReviewCategoryID", objReview.CategoryID);
                ht.Add("@ReviewSubcategoryID", objReview.SubcategoryID);
                ht.Add("ProductCategoryID", objReview.ProductID);
                _ActionResult = this.ExecuteNonQueryStoredProcedure("USP_RLP_Insert_SellerProductReview", ht);
            }
            else
            {
                _ActionResult = this.ExecuteNonQueryStoredProcedure("USP_RLP_Insert_BusinessReview", ht);
            }
        }
        catch
        {
            throw;
        }
        return _ActionResult > 0 ? true : false;
    }


    /// <summary>
    /// Checks if the Business/Services name is duplicate.
    /// Returns false if it is duplicate.
    /// </summary>
    /// <param name="objReview"></param>
    /// <returns></returns>
    public bool IsDuplicateBusiness(Review objReview)
    {
        DataTable dt = null;
        Hashtable ht = new Hashtable();
        ht.Add("@BusinessService", objReview.BusinessService);
        ht.Add("@ReviewCategoryID", objReview.CategoryID);
        ht.Add("@ReviewSubcategoryID", objReview.SubcategoryID);
        try
        {
            dt = this.ExecuteStoredProcedureDataTable("USP_RLP_IsBusinessDuplicate", ht);
        }
        catch
        {
            throw;
        }
        if (dt.Rows.Count > 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }


    /// <summary>
    /// Loads List of Biz Service review lists
    /// </summary>
    /// <param name="objReview"></param>
    /// <returns></returns>
    public DataTable LoadList_RLP_Review_OrderByLatest(int _BusinessServiceID, int _ReviewCategoryID)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@BusinessServiceID", _BusinessServiceID);
        ht.Add("@ReviewCategoryID", _ReviewCategoryID);

        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_RLP_Review_LoadListReview_OrderByLatest", ht);
        }
        catch
        {
            throw;
        }
    }

    public DataTable LoadList_RLP_Review_OrderByMostHelpful(int _BusinessServiceID, int _ReviewCategoryID)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@BusinessServiceID", _BusinessServiceID);
        ht.Add("@ReviewCategoryID", _ReviewCategoryID);

        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_RLP_Review_LoadListReview_OrderByMostHelpful", ht);
        }
        catch
        {
            throw;
        }
    }



    public DataTable Load_RLP_Top_MostHelful_Review(int _BusinessServiceID, int _ReviewCategoryID)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@BusinessServiceID", _BusinessServiceID);
        ht.Add("@ReviewCategoryID", _ReviewCategoryID);

        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_RLP_Review_Load_Most_Helpful_Review", ht);
            //return this.ExecuteStoredProcedureDataTable("USP_Review_Load_Most_HelpfulAndCritical_Review", ht);
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Loads Top one most helpful review
    /// USP: 
    /// </summary>
    /// <param name="objReview"></param>
    /// <returns></returns>
    public DataTable Load_RLP_Top_MostCritical_Review(int _BusinessServiceID, int _ReviewCategoryID)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@BusinessServiceID", _BusinessServiceID);
        ht.Add("@ReviewCategoryID", _ReviewCategoryID);

        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_RLP_Review_Load_Most_Critical_Review", ht);
            //return this.ExecuteStoredProcedureDataTable("USP_Review_Load_Most_HelpfulAndCritical_Review", ht);
        }
        catch
        {
            throw;
        }
    }


    public DataTable Load_RLP_DetailRating(int _BusinessServiceID, int _ReviewCategoryID)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@BusinessServiceID", _BusinessServiceID);
        ht.Add("@ReviewCategoryID", _ReviewCategoryID);
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_RLP_Review_LoadDetailRating", ht);
        }
        catch
        {
            throw;
        }
    }

    


    /// <summary>
    /// Loads a Single Review
    /// USP: USP_Review_LoadSingleReview
    /// </summary>
    /// <param name="objReview"></param>
    /// <returns></returns>
    public DataTable Load_RLP_SingleReview(int _BusinessServiceID, int _ReviewCategoryID, int _ReviewID)
    {
        int _ActionResult = -1;
        Hashtable ht = new Hashtable();
        ht.Add("@BusinessServiceID", _BusinessServiceID);
        ht.Add("@ReviewCategoryID", _ReviewCategoryID);
        ht.Add("@ReviewID", _ReviewID);
        try
        {
            if (_ReviewCategoryID == 6)
            {
                return this.ExecuteStoredProcedureDataTable("USP_RLP_Review_LoadSingleSellerCompanyReview", ht);
            }
            else
            {
                return this.ExecuteStoredProcedureDataTable("USP_RLP_Review_LoadSingleReview", ht);
            }
            
        }
        catch
        {
            throw;
        }
    }


    /// <summary>
    /// Loads Comments on a particular review.
    /// </summary>
    /// <param name="objReview"></param>
    /// <returns></returns>
    public DataTable LoadList_RLP_Comments(int _ReviewID)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@ReviewID", _ReviewID);
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_RLP_Review_LoadListComments", ht);
        }
        catch
        {
            throw;
        }
    }


    /// <summary>
    /// Loads all Reply made on a single Comment
    /// USP: USP_Review_LoadListReply
    /// </summary>
    /// <param name="objReview"></param>
    /// <returns></returns>
    public DataTable LoadList_RLP_Reply(int _CommentID)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@CommentID", _CommentID);
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_RLP_Review_LoadListReply", ht);
        }
        catch
        {
            throw;
        }
    }


    /// <summary>
    /// Inserts a comment in the comment table.
    /// </summary>
    /// <param name="objReview"></param>
    /// <returns></returns>
    public bool RLP_InsertComment(int _ReviewID, string _Comment, int _ProfileID)
    {
        int _ActionResult = -1;
        Hashtable ht = new Hashtable();
        ht.Add("@ReviewID", _ReviewID);
        ht.Add("@Comment", _Comment);
        ht.Add("@ProfileID", _ProfileID);

        try
        {
            _ActionResult = this.ExecuteNonQueryStoredProcedure("USP_RLP_Review_InsertComment", ht);
        }
        catch
        {
            throw;
        }
        return _ActionResult > 0 ? true : false;
    }


    /// <summary>
    /// Inserts a reply in the reply table.
    /// </summary>
    /// <param name="objReview"></param>
    /// <returns></returns>
    public bool RLP_InsertReply(int _CommentID, int _ProfileID, string _Reply)
    {
        int _ActionResult = -1;
        Hashtable ht = new Hashtable();
        ht.Add("@Reply", _Reply);
        ht.Add("@CommentID", _CommentID);
        ht.Add("@ProfileID", _ProfileID);
        try
        {
            _ActionResult = this.ExecuteNonQueryStoredProcedure("USP_RLP_Review_InsertReply", ht);
        }
        catch
        {
            throw;
        }
        return _ActionResult > 0 ? true : false;
    }


    /// <summary>
    /// Updates Helpful review Column. And also inserts profileid and reviewid in HelpfulReviewVote
    /// USP: USP_Review_InsertVote
    /// </summary>
    /// <param name="objReview"></param>
    /// <returns></returns>
    public bool RLP_InsertVote(int _ReviewID, int _ProfileID, bool _Vote)
    {
        int _ActionResult = -1;
        Hashtable ht = new Hashtable();
        ht.Add("@ReviewID", _ReviewID);
        ht.Add("@ProfileID", _ProfileID);
        ht.Add("@Vote", _Vote);

        try
        {
            _ActionResult = this.ExecuteNonQueryStoredProcedure("USP_RLP_Review_InsertVote", ht);
        }
        catch
        {
            throw;
        }
        return _ActionResult > 0 ? true : false;
    }

    /// <summary>
    /// Returns Fallse if Duplicate
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public bool RLP_IsDuplicateReview(Review obj)
    {
        DataTable dt = null;
        Hashtable ht = new Hashtable();
        ht.Add("@BusinessServiceID", obj.BusinessServiceID);
        ht.Add("@ReviewCategoryID", obj.CategoryID);
        ht.Add("@ProfileID", obj.ProfileID);
        ht.Add("@ReviewTitle", obj.ReviewTitle);

        try
        {
            dt = this.ExecuteStoredProcedureDataTable("USP_RLP_Review_IsReviewDuplicate", ht);
        }
        catch
        {
            throw;
        }
        if (dt.Rows.Count > 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }


    /// <summary>
    /// Loads latest #/4 Reviews FOR Review Landing Page
    /// </summary>
    /// <returns></returns>
    public DataTable RLP_LoadLatestReview()
    {
        int _ActionResult = -1;
        Hashtable ht = new Hashtable();
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_RLP1_LoadLatest_Review", ht);
        }
        catch
        {
            throw;
        }
    }



    #endregion REVIEW LANDING PAGE


    #region LOADING REVIEW BY SUBCATEGORY

    /// <summary>
    /// Loads all reviews made on a SubcategoryLoadListReview_BoromelaProduct_BySubcategory
    /// Order By latest inserted review.
    /// 
    /// </summary>
    /// <param name="objReview"></param>
    /// <returns></returns>
    public DataTable LoadListReview_OrderByLatest_BySubcategory(Review objReview)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@CategoryID", objReview.CategoryID);
        ht.Add("@SubcategoryID", objReview.SubcategoryID);
        ht.Add("@IsBizReview", objReview.IsBizReview);
        

        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_Review_LoadListReview_OrderByLatest_BySubcategory", ht);
        }
        catch
        {
            throw;
        }
    }


    /// <summary>
    /// Loads all reviews made on a Subcategory 
    /// Order By latest inserted review.
    /// 
    /// </summary>
    /// <param name="objReview"></param>
    /// <returns></returns>
    
    public DataTable LoadListReview_BoromelaProduct_BySubcategory(Review objReview)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@CategoryID", objReview.CategoryID);
        ht.Add("@SubcategoryID", objReview.SubcategoryID);
        ht.Add("@ProductID", objReview.ProductID);
        ht.Add("@IsBizReview", objReview.IsBizReview);

        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_Review_LoadListReview_OrderByLatest_BoromelaProduct", ht);
        }
        catch
        {
            throw;
        }
    }



    /// <summary>
    /// Loads all reviews made on a Subcategory 
    /// 
    /// 
    /// </summary>
    /// <param name="objReview"></param>
    /// <returns></returns>

    public DataTable LoadListReview_BoromelaProduct_BySubcategory_ReviewList_View(Review objReview)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@CategoryID", objReview.CategoryID);
        ht.Add("@SubcategoryID", objReview.SubcategoryID);        
        ht.Add("@IsBizReview", objReview.IsBizReview);

        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_Review_LoadListReview_BySubcategory", ht);
        }
        catch
        {
            throw;
        }
    }



    /// <summary>
    /// Loads all reviews made on a Subcategory for Non BoroMela Product
    /// Order By latest inserted review.
    /// 
    /// </summary>
    /// <param name="objReview"></param>
    /// <returns></returns>

    public DataTable LoadListReview_NonBoromelaProduct_BySubcategory(Review objReview)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@ReviewCategoryID", objReview.CategoryID);
        ht.Add("@ReviewSubcategoryID", objReview.SubcategoryID);
        //ht.Add("@IsBizReview", objReview.IsBizReview);

        if (objReview.CategoryID == 6)
        {  

            try
            {
                return this.ExecuteStoredProcedureDataTable("USP_Review_LoadListReview_ReviewsOn_Seller", ht);
            }
            catch
            {
                throw;
            }

        }
        else
        {
           
            try
            {
                return this.ExecuteStoredProcedureDataTable("USP_Review_LoadListReview_Non_BoromelaProduct", ht);
            }
            catch
            {
                throw;
            }
        }
    }


    /// <summary>
    /// Loads Top one most helpful review
    /// USP: USP_Review_Load_Most_Helpful_Review
    /// </summary>
    /// <param name="objReview"></param>
    /// <returns></returns>
    public DataTable LoadTop_MostHelful_Review_BySubcategory(Review objReview)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@CategoryID", objReview.CategoryID);
        ht.Add("@SubcategoryID", objReview.SubcategoryID);
        ht.Add("@ProductID", objReview.ProductID);
        ht.Add("@IsBizReview", objReview.IsBizReview);

        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_Review_Load_Most_Helpful_Review_BySubcategory", ht);
            //return this.ExecuteStoredProcedureDataTable("USP_Review_Load_Most_HelpfulAndCritical_Review", ht);
        }
        catch
        {
            throw;
        }
    }

    /// <summary>// Non boromela product
    /// Loads Top one most helpful review
    /// USP: USP_Review_Load_Most_Critical_Review
    /// </summary>
    /// <param name="objReview"></param>
    /// <returns></returns>
    public DataTable LoadTop_MostCritical_Review_BySubcategory(Review objReview)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@CategoryID", objReview.CategoryID);
        ht.Add("@SubcategoryID", objReview.SubcategoryID);
        ht.Add("@ProductID", objReview.ProductID);
        ht.Add("@IsBizReview", objReview.IsBizReview);

        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_Review_Load_Most_Critical_Review_BySubcategory", ht);
            //return this.ExecuteStoredProcedureDataTable("USP_Review_Load_Most_HelpfulAndCritical_Review", ht);
        }
        catch
        {
            throw;
        }
    }


    /// <summary>
    /// Loads all reviews made on a single product.
    /// Order By Mosthelpful review.
    /// USP: USP_Review_LoadListReview_OrderByMostHelpful
    /// </summary>
    /// <param name="objReview"></param>
    /// <returns></returns>
    public DataTable LoadListReview_OrderByMostHelpful_BySubcategory(Review objReview)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@CategoryID", objReview.CategoryID);
        ht.Add("@SubcategoryID", objReview.SubcategoryID);
        ht.Add("ProductID", objReview.ProductID);
        ht.Add("@IsBizReview", objReview.IsBizReview);

        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_Review_LoadListReview_OrderByMostHelpful_BySubcategory", ht);
        }
        catch
        {
            throw;
        }
    }

    #endregion LOADING REVIEW BY SUBCATEGORY




    /// <summary>
    /// Searches for Business/Service to write a review.
    /// </summary>
    /// <param name="_CategoryID"></param>
    /// <param name="_ProductTitle"></param>
    /// <returns></returns>
    public DataTable LoadSearched_SellerListByCompanyName(int _ReviewCategoryID, int _ProductCategoryID, string _SellerCompnayName)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@ReviewCategoryID", _ReviewCategoryID);
        ht.Add("@ProductCategoryID", _ProductCategoryID);
        ht.Add("@CompanyName", "%" + _SellerCompnayName + "%");
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_RLP_SearchSellerCompany", ht);
        }
        catch
        {
            throw;
        }
    }




    /// <summary>
    /// Searches for Business/Service to write a review.
    /// </summary>
    /// <param name="_CategoryID"></param>
    /// <param name="_ProductTitle"></param>
    /// <returns></returns>
    public DataTable Load_ReviewCOunt(int _ProfileID)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@ProfileID", _ProfileID);
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_CP_DisplayNoOfReview", ht);
        }
        catch
        {
            throw;
        }
    }

    //working on this funciton to 
    //reason: add picture upload option 
    //by Girish data: 3 May 2010
   // public int UpdateReview(int _ProfileID, int reviewID, string reviewTitle, string review, bool isBizReview)

    public int UpdateReview(int _ProfileID, int reviewID, int ProductID, string reviewTitle, string review, bool isBizReview, string ImagePath)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@ProfileID", _ProfileID);
        ht.Add("@ReviewID", reviewID);
        ht.Add("@ProductID", ProductID);
        ht.Add("@ReviewTitle", reviewTitle);
        ht.Add("@Review", review);
        ht.Add("@IsBizReview", isBizReview);
        ht.Add("@ImagePath", ImagePath);
        
        //ht.Add("@ProductImage", ProductImage);add this parameter for image
                
        try
        {
            //return this.ExecuteNonQueryStoredProcedure("USP_CP_UpdateReview", ht);

            return this.ExecuteNonQueryStoredProcedure("USP_CP_UpdateReviewImage", ht);
        }
        catch
        {
            throw;
        }
    }
//code end

    public DataTable LoadSingleReview(int _ProfileID, int reviewID, bool isBizReview)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@ProfileID", _ProfileID);
        ht.Add("@ReviewID", reviewID);
        ht.Add("@IsBizReview", isBizReview);
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_CP_LoadSingleReview", ht);
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Search review from ReviewList_View
    /// </summary>
    /// <param name="_ProfileID"></param>
    /// <param name="_CategoryID"></param>
    /// <returns></returns>
    /// 
    public DataTable LoadList_Review_ClassifiedUser(int _ProfileID, DateTime _StartDate, DateTime _EndDate)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@ProfileID", _ProfileID);
        ht.Add("@StartDate", _StartDate);
        ht.Add("@EndDate", _EndDate);
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_LoadList_Review_ClassifiedUser", ht);
        }
        catch
        {
            throw;
        }
    }
    
}
