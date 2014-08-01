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
/// Summary description for RealEstate
/// </summary>
public class RealEstate
{
    private DateTime _StartDate;

    public DateTime StartDate
    {
        get { return _StartDate; }
        set { _StartDate = value; }
    }

    private DateTime _EndDate;

    public DateTime EndDate
    {
        get { return _EndDate; }
        set { _EndDate = value; }
    }

    private string _Country;

    public string Country
    {
        get { return _Country; }
        set { _Country = value; }
    }

    private int _LocationID;

    public int LocationID
    {
        get { return _LocationID; }
        set { _LocationID = value; }
    }


    private int _ProductID;

    public int ProductID
    {
        get { return _ProductID; }
        set { _ProductID = value; }
    }
    private int _ProfileID;

    public int ProfileID
    {
        get { return _ProfileID; }
        set { _ProfileID = value; }
    }

    private bool _UserType;

    public bool UserType
    {
        get { return _UserType; }
        set { _UserType = value; }
    }

    private string _SKU;

    public string SKU
    {
        get { return _SKU; }
        set { _SKU = value; }
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

    private int _SecondSubcatID;

    public int SecondSubcatID
    {
        get { return _SecondSubcatID; }
        set { _SecondSubcatID = value; }
    }

    private int _SellerType;

    public int SellerType
    {
        get { return _SellerType; }
        set { _SellerType = value; }
    }

    private string _SellerName;

    public string SellerName
    {
        get { return _SellerName; }
        set { _SellerName = value; }
    }


    private string _ProjectType;

    public string ProjectType
    {
        get { return _ProjectType; }
        set { _ProjectType = value; }
    }

    private int _AreaID;

    public int AreaID
    {
        get { return _AreaID; }
        set { _AreaID = value; }
    }

    private string _Area;

    public string Area
    {
        get { return _Area; }
        set { _Area = value; }
    }

    private int _ProvinceID;

    public int ProvinceID
    {
        get { return _ProvinceID; }
        set { _ProvinceID = value; }
    }

    private string _Address;

    public string Address
    {
        get { return _Address; }
        set { _Address = value; }
    }

    private double _Size;

    public double Size
    {
        get { return _Size; }
        set { _Size = value; }
    }

    private string _SizeUnit;

    public string SizeUnit
    {
        get { return _SizeUnit; }
        set { _SizeUnit = value; }
    }


    private string _LandNature;

    public string LandNature
    {
        get { return _LandNature; }
        set { _LandNature = value; }
    }


    private int _Quantity;

    public int Quantity
    {
        get { return _Quantity; }
        set { _Quantity = value; }
    }


    private string _Currency;

    public string Currency
    {
        get { return _Currency; }
        set { _Currency = value; }
    }

    private double _Price;

    public double Price
    {
        get { return _Price; }
        set { _Price = value; }
    }

    private string _NoOfBedRoom;

    public string NoOfBedRoom
    {
        get { return _NoOfBedRoom; }
        set { _NoOfBedRoom = value; }
    }

    private string _NoOfWashRoom;

    public string NoOfWashRoom
    {
        get { return _NoOfWashRoom; }
        set { _NoOfWashRoom = value; }
    }

    private double _ServiceCharge;

    public double ServiceCharge
    {
        get { return _ServiceCharge; }
        set { _ServiceCharge = value; }
    }

	

    private bool _IsCarParkingAvailable;

    public bool IsCarParkingAvailable
    {
        get { return _IsCarParkingAvailable; }
        set { _IsCarParkingAvailable = value; }
    }


    private string _Description;

    public string Description
    {
        get { return _Description; }
        set { _Description = value; }
    }


    private bool _IsActive;

    public bool IsActive
    {
        get { return _IsActive; }
        set { _IsActive = value; }
    }

    private string _ProjectName;

    public string ProjectName
    {
        get { return _ProjectName; }
        set { _ProjectName = value; }
    }

    private bool _IsInsideDhaka;

    public bool IsInsideDhaka
    {
        get { return _IsInsideDhaka; }
        set { _IsInsideDhaka = value; }
    }

    private DateTime _UpdatedOn;

    public DateTime UpdatedOn
    {
        get { return _UpdatedOn; }
        set { _UpdatedOn = value; }
    }


    private string _ProductImage;

    public string ProductImage
    {
        get { return _ProductImage; }
        set { _ProductImage = value; }
    }

    private bool _IsAlternativeAddress;

    public bool IsAlternativeAddress
    {
        get { return _IsAlternativeAddress; }
        set { _IsAlternativeAddress = value; }
    }

    private string _Source;

    public string Source
    {
        get { return _Source; }
        set { _Source = value; }
    }


	public RealEstate()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}
