using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for MenuEventArgs
/// </summary>
public class MenuEventArgs : EventArgs
{
	public MenuEventArgs()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    private string strCategoryID;
    private string strSubcategoryID;
    private string strProfileID;
    private string  strLowerBound;
    private string strUpperBound;
    private string  strPriceRangeID;
    private string _AreaID;
    private string _ProvinceID;
    private string _ProductSellerDetailID;
    private string _ProductID;
    private string _ProductModelID;
    private string _Author;
    private string _Publisher;
    private string _SecondSubcatID;

    public string SecondSubcatID
    {
        get { return _SecondSubcatID; }
        set { _SecondSubcatID = value; }
    }


    public string Publisher
    {
        get { return _Publisher; }
        set { _Publisher = value; }
    }


    public string Author
    {
        get { return _Author; }
        set { _Author = value; }
    }



    public string ProductModelID
    {
        get { return _ProductModelID; }
        set { _ProductModelID = value; }
    }


    public string ProductID
    {
        get { return _ProductID; }
        set { _ProductID = value; }
    }



    public string ProductSellerDetailID
    {
        get { return _ProductSellerDetailID; }
        set { _ProductSellerDetailID = value; }
    }


    public string ProvinceID
    {
        get { return _ProvinceID; }
        set { _ProvinceID = value; }
    }


    public string AreaID
    {
        get { return _AreaID; }
        set { _AreaID = value; }
    }


    public string  PriceRangeID
    {
        get { return strPriceRangeID; }
        set { strPriceRangeID = value; }
    }

    public string UpperBound
    {
        get { return strUpperBound; }
        set { strUpperBound = value; }
    }


    public string  LowerBound
    {
        get { return strLowerBound; }
        set { strLowerBound = value; }
    }

    public string ProfileID
    {
        get { return strProfileID; }
        set { strProfileID = value; }
    }


    public string CategoryID
    {
        get { return strCategoryID; }
        set { strCategoryID = value; }
    }

    public string SubcategoryID
    {
        get { return strSubcategoryID; }
        set { strSubcategoryID = value; }
    }


    private string _ListingPage;

    public string ListingPage
    {
        get { return _ListingPage; }
        set { _ListingPage = value; }
    }


    /* Add for MovieMusicGame   */
    private string _SecondSubcategory;
    public string SecondSubcategory
    {
        get { return _SecondSubcategory; }
        set { _SecondSubcategory = value; }
    }
    private string _Language;

    public string Language
    {
        get { return _Language; }
        set { _Language = value; }
    }
    private string _ProductTitle;
    public string ProductTitle
    {
        get { return _ProductTitle; }
        set { _ProductTitle = value; }
    }
    /* ....END...  */

	
}
