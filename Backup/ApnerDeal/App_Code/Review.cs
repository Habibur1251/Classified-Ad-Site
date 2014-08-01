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

/// <summary>
/// Summary description for Review
/// </summary>
public class Review
{
    private int _ProfileID;

    public int ProfileID
    {
        get { return _ProfileID; }
        set { _ProfileID = value; }
    }
    private int _CountryID;

    public int CountryID
    {
        get { return _CountryID; }
        set { _CountryID = value; }
    }

    private string _Review;

    public string CustomerReview
    {
        get { return _Review; }
        set { _Review = value; }
    }

    private int _BusinessServiceID;

    public int BusinessServiceID
    {
        get { return _BusinessServiceID; }
        set { _BusinessServiceID = value; }
    }


    private string _BusinessService;

    public string BusinessService
    {
        get { return _BusinessService; }
        set { _BusinessService = value; }
    }

    private string _ReviewTitle;

    public string ReviewTitle
    {
        get { return _ReviewTitle; }
        set { _ReviewTitle = value; }
    }

    private int _CategoryID;

    public int CategoryID
    {
        get { return _CategoryID; }
        set { _CategoryID = value; }
    }

    private int _SubcategoryID;

    public int SubcategoryID
    {
        get { return _SubcategoryID; }
        set { _SubcategoryID = value; }
    }


    private int _ProductSellerDetailID;

    public int ProductSellerDetailID
    {
        get { return _ProductSellerDetailID; }
        set { _ProductSellerDetailID = value; }
    }
    private int _ProductID;

    public int ProductID
    {
        get { return _ProductID; }
        set { _ProductID = value; }
    }

    private int _Rating;

    public int Rating
    {
        get { return _Rating; }
        set { _Rating = value; }
    }

    private int _HelpfulReview;

    public int HelpfulReview
    {
        get { return _HelpfulReview; }
        set { _HelpfulReview = value; }
    }
    private bool _IsAbused;

    public bool IsAbused
    {
        get { return _IsAbused; }
        set { _IsAbused = value; }
    }

    private int _ReviewID;

    public int ReviewID
    {
        get { return _ReviewID; }
        set { _ReviewID = value; }
    }

    private string _Comment;

    public string Comment
    {
        get { return _Comment; }
        set { _Comment = value; }
    }

    private int _CommentID;

    public int CommentID
    {
        get { return _CommentID; }
        set { _CommentID = value; }
    }

    private string _Reply;

    public string Reply
    {
        get { return _Reply; }
        set { _Reply = value; }
    }

    private bool _VoteType;

    public bool VoteType
    {
        get { return _VoteType; }
        set { _VoteType = value; }
    }

    private string _ContactAddress;

    public string ContactAddress
    {
        get { return _ContactAddress; }
        set { _ContactAddress = value; }
    }

    private string _Phone;

    public string Phone
    {
        get { return _Phone; }
        set { _Phone = value; }
    }

    private string _Description;

    public string Descriptiom
    {
        get { return _Description; }
        set { _Description = value; }
    }


    private string _ProductImage;

    public string ProductImage
    {
        get { return _ProductImage; }
        set { _ProductImage = value; }
    }


    private bool _IsBizReview;

    public bool IsBizReview
    {
        get { return _IsBizReview; }
        set { _IsBizReview = value; }
    }



	public Review()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    



}
