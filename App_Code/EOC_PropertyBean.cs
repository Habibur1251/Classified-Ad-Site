using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public class EOC_PropertyBean
{

    private int _Classified_ProductSellerDetailID;

    public int Classified_ProductSellerDetailID
    {
        get { return _Classified_ProductSellerDetailID; }
        set { _Classified_ProductSellerDetailID = value; }
    }

    private string _UserName;

    public string Username
    {
        get { return _UserName; }
        set { _UserName = value; }
    }


    #region CommonMembers
    private DateTime _UpdatedOn;
    private DateTime _FromDate;
    private DateTime _ToDate;
    private string condition;
    private string conditionNote;
    private int canEditProduct;
    private bool _isNegotiable;

    private bool _IsDisplayAddress;

    private string _ClassifiedImagePathEdit;

    public string ClassifiedImagePathEdit
    {
        get { return _ClassifiedImagePathEdit; }
        set { _ClassifiedImagePathEdit = value; }
    }

    private string _CorporateImagePathEdit;

    public string CorporateImagePathEdit
    {
        get { return _CorporateImagePathEdit; }
        set { _CorporateImagePathEdit = value; }
    }

    private string _ImagePath;

    public string ImagePath
    {
        get {return _ImagePath; }
        set{_ImagePath=value;}
    }

    private string _CorporateImagePathE;

    public string CorporateImagePathE
    {
        get { return _CorporateImagePathE; }
        set { _CorporateImagePathE = value; }
    }


    private string _Classified_ImagePath;

    public string Classified_ImagePath
    {
        get { return _Classified_ImagePath; }
        set { _Classified_ImagePath = value; }
    }

    private string _Corporate_ImagePath;

    public string CorporateImagePath
    {
        get { return _Corporate_ImagePath; }
        set { _Corporate_ImagePath = value; }
    }

    public bool IsDisplayAddress
    {
        get { return _IsDisplayAddress; }
        set { _IsDisplayAddress = value; }
    }

    private string _Source;

    public string Source
    {
        get { return _Source; }
        set { _Source = value; }
    }

    private string _ReferalName;

    public string ReferalName
    {
        get { return _ReferalName; }
        set { _ReferalName = value; }
    }


    public bool IsNegotiable
    {
        get { return _isNegotiable; }
        set { _isNegotiable = value; }
    }


    public int CanEditProduct
    {
        get { return canEditProduct; }
        set { canEditProduct = value; }
    }

    public string ConditionNote
    {
        get { return conditionNote; }
        set { conditionNote = value; }
    }

    public string Condition
    {
        get { return condition; }
        set { condition = value; }
    }

    private string _Message;

    public string Message
    {
        get { return _Message; }
        set { _Message = value; }
    }


    private string _User_LoginEmail;

    public string User_LoginEmail
    {
        get { return _User_LoginEmail; }
        set { _User_LoginEmail = value; }
    }

    private int _User_ProfileID;

    public int User_ProfileID
    {
        get { return _User_ProfileID; }
        set { _User_ProfileID = value; }
    }

    private string _UserInfo;

    public string UserInfo
    {
        get { return _UserInfo; }
        set { _UserInfo = value; }
    }


    private string _UserType; //Moinur(its checking whether the User Is Business or Classified)
    

    public DateTime UpdatedOn
    {
        get { return _UpdatedOn; }
        set { _UpdatedOn = value; }
    }
    public DateTime FromDate
    {
        get { return _FromDate; }
        set { _FromDate = value; }
    }
    public DateTime ToDate
    {
        get { return _ToDate; }
        set { _ToDate = value; }
    }

    public string UserType
    {
        get
        {
            return _UserType;
        }
        set
        {
            _UserType = value;
        }
    }


    private string _LoginEmail;

    public string LoginEmail
    {
        get { return _LoginEmail; }
        set { _LoginEmail = value; }
    }

    private string _Password;

    public string Password
    {
        get { return _Password; }
        set { _Password = value; }
    }

    #endregion

    #region Country
    private int _Country_CountryID;
    
    private string _Country_CountryName;

    public int Country_CountryID
    {
        get
        {
            return _Country_CountryID;
        }
        set
        {
            

            _Country_CountryID = value;
        }
    }
    public string Country_CountryName
    {
        get
        {
            return _Country_CountryName;
        }
        set
        {
            
            _Country_CountryName = value;
        }
    }
    #endregion

    #region State
    private int _State_StateID;
    private string _State_StateName;

    public int State_StateID
    {
        get
        {
            return _State_StateID;
        }
        set
        {
            _State_StateID = value;
        }
    }
    public string State_StateName
    {
        get
        {
            return _State_StateName;
        }
        set
        {
            _State_StateName = value;
        }
    }
    #endregion

    #region Province
    private int _Province_ProvinceID;
    private string _Province_ProvinceName;

    public int Province_ProvinceID
    {
        get
        {
            return _Province_ProvinceID;
        }
        set
        {
            _Province_ProvinceID = value;
        }
    }
    public string Province_ProvinceName
    {
        get
        {
            return _Province_ProvinceName;
        }
        set
        {
            _Province_ProvinceName = value;
        }
    }
    #endregion

    #region Category
    private int _Category_CategoryID;
    private string _Category_CategoryName;
    private bool _IsSpecialCategory;

    public int Category_CategoryID
    {
        get
        {
            return _Category_CategoryID;
        }
        set
        {
            _Category_CategoryID = value;
        }
    }
    public string Category_CategoryName
    {
        get
        {
            return _Category_CategoryName;
        }
        set
        {
            _Category_CategoryName = value;
        }
    }
    public bool IsSpecialCategory
    {
        get
        {
            return _IsSpecialCategory;
        }
        set
        {
            _IsSpecialCategory = value;
        }
    }
    #endregion
    public int SecondSubcatID
    {
        get
        {
            return _SecondSubcategoryID;
        }
        set
        {
            _SecondSubcategoryID = value;
        }
    }

    #region Subcategory
    private int _Subcategory_SubcategoryID;
    private string _Subcategory_SubcategoryName;
    private int _Subcategory_CategoryID;
    private int _SecondSubcategoryID;

    public int Subcategory_SubcategoryID
    {
        get
        {
            return _Subcategory_SubcategoryID;
        }
        set
        {
            _Subcategory_SubcategoryID = value;
        }
    }
    public string Subcategory_SubcategoryName
    {
        get
        {
            return _Subcategory_SubcategoryName;
        }
        set
        {
            _Subcategory_SubcategoryName = value;
        }
    }

    public int Subcategory_CategoryID
    {
        get
        {
            return _Subcategory_CategoryID;
        }
        set
        {
            _Subcategory_CategoryID = value;
        }
    }

    #endregion

    #region ProductModel
    private int _ProductModelID;

    public int ProductModelID
    {
        get { return _ProductModelID; }
        set { _ProductModelID = value; }
    }


    private string _ProductModel;

    public string ProductModel
    {
        get { return _ProductModel; }
        set { _ProductModel = value; }
    }


    #endregion ProductModel


    #region 2ndSubcategory
    private int _2ndSubcategory_SubcategoryID;
    
    public int SecondSubcategory_SubcategoryID
    {
        get
        {
            return _2ndSubcategory_SubcategoryID;
        }
        set
        {
            _2ndSubcategory_SubcategoryID = value;
        }
    }


    private int _Model_ModelID;

    public int Model_ModelID
    {
        get { return _Model_ModelID; }
        set { _Model_ModelID = value; }
    }



    #endregion 2ndSubcategory

    #region BusinessCategory
    private int _BusinessCategory_BusinessID;
    private string _BusinessCategory_BusinessCategoryName;

    public int BusinessCategory_BusinessID
    {
        get
        {
            return _BusinessCategory_BusinessID;
        }
        set
        {
            _BusinessCategory_BusinessID = value;
        }
    }
    public string BusinessCategory_BusinessCategoryName
    {
        get
        {
            return _BusinessCategory_BusinessCategoryName;
        }
        set
        {
            _BusinessCategory_BusinessCategoryName = value;
        }
    }
    #endregion

    #region Business_UserProfile
    private int _Business_UserProfile_ProfileID;
    private string _Business_UserProfile_LoginEmail;
    private string _Business_UserProfile_LoginPassword;
    private string _Business_UserProfile_OldPassword;
    private string _Business_UserProfile_CompanyName;
    private string _Business_UserProfile_BusinessAddress;
    private string _Business_UserProfile_ContactPhone;
    private string _Business_UserProfile_CompanyURL;
    private string _Business_UserProfile_BillingPerson;
    private string _Business_UserProfile_WebInventoryManager;
    private string _Business_UserProfile_CompanyProfile;
    private string _Business_UserProfile_CompanyLogo;
    private bool _Business_UserProfile_IsActive;

    public int Business_UserProfile_ProfileID
    {
        get
        {
            return _Business_UserProfile_ProfileID;
        }
        set
        {
            _Business_UserProfile_ProfileID = value;
        }
    }
    public string Business_UserProfile_LoginEmail
    {
        get
        {
            return _Business_UserProfile_LoginEmail;
        }
        set
        {
            _Business_UserProfile_LoginEmail = value;
        }
    }
    public string Business_UserProfile_LoginPassword
    {
        get
        {
            return _Business_UserProfile_LoginPassword;
        }
        set
        {
            _Business_UserProfile_LoginPassword = value;
        }
    }
    public string Business_UserProfile_OldPassword
    {
        get
        {
            return _Business_UserProfile_OldPassword;
        }
        set
        {
            _Business_UserProfile_OldPassword = value;
        }
    }
    public string Business_UserProfile_CompanyName
    {
        get
        {
            return _Business_UserProfile_CompanyName;
        }
        set
        {
            _Business_UserProfile_CompanyName = value;
        }
    }
    public string Business_UserProfile_BusinessAddress
    {
        get
        {
            return _Business_UserProfile_BusinessAddress;
        }
        set
        {
            _Business_UserProfile_BusinessAddress = value;
        }
    }
    public string Business_UserProfile_ContactPhone
    {
        get
        {
            return _Business_UserProfile_ContactPhone;
        }
        set
        {
            _Business_UserProfile_ContactPhone = value;
        }
    }
    public string Business_UserProfile_CompanyURL
    {
        get
        {
            return _Business_UserProfile_CompanyURL;
        }
        set
        {
            _Business_UserProfile_CompanyURL = value;
        }
    }
    public string Business_UserProfile_BillingPerson
    {
        get
        {
            return _Business_UserProfile_BillingPerson;
        }
        set
        {
            _Business_UserProfile_BillingPerson = value;
        }
    }
    public string Business_UserProfile_WebInventoryManager
    {
        get
        {
            return _Business_UserProfile_WebInventoryManager;
        }
        set
        {
            _Business_UserProfile_WebInventoryManager = value;
        }
    }
    public string Business_UserProfile_CompanyProfile
    {
        get
        {
            return _Business_UserProfile_CompanyProfile;
        }
        set
        {
            _Business_UserProfile_CompanyProfile = value;
        }
    }
    public string Business_UserProfile_CompanyLogo
    {
        get
        {
            return _Business_UserProfile_CompanyLogo;
        }
        set
        {
            _Business_UserProfile_CompanyLogo = value;
        }
    }
    public bool Business_UserProfile_IsActive
    {
        get
        {
            return _Business_UserProfile_IsActive;
        }
        set
        {
            _Business_UserProfile_IsActive = value;
        }
    }
    #endregion

    #region Business_ActivationLinks
    private int _Business_ActivationLinks_LinkID;
    private bool _Business_ActivationLinks_IsChecked;

    public int Business_ActivationLinks_LinkID
    {
        get { return _Business_ActivationLinks_LinkID; }
        set { _Business_ActivationLinks_LinkID = value; }
    }
    public bool Business_ActivationLinks_IsChecked
    {
        get { return _Business_ActivationLinks_IsChecked; }
        set { _Business_ActivationLinks_IsChecked = value; }
    }
    #endregion

    #region Business_ProductProfile_GeneralItems
    private int _Business_ProductProfile_GeneralItems_ProductID;
    private string _Business_ProductProfile_GeneralItems_SKU;
    private string _Business_ProductProfile_GeneralItems_ProductTitle;
    private string _Business_ProductProfile_GeneralItems_KeyFeatures;
    private string _Business_ProductProfile_GeneralItems_ProductDescription;
    private int _Business_ProductProfile_GeneralItems_ProductCondition;
    private string _Business_ProductProfile_GeneralItems_ConditionNote;
    private int _Business_ProductProfile_GeneralItems_Quantity;
    private string _Business_ProductProfile_GeneralItems_ProductImage;
    private string _Business_ProductProfile_GeneralItems_Currency;
    private double _Business_ProductProfile_GeneralItems_ProductPrice;
    private double _Business_ProductProfile_GeneralItems_SalePrice;
    private double _Business_ProductProfile_GeneralItems_CashOnDeliveryCost;
    private string _Business_ProductProfile_GeneralItems_PaymentOption;
    private DateTime _Business_ProductProfile_GeneralItems_StartDate;
    private DateTime _Business_ProductProfile_GeneralItems_EndDate;
    private bool _Business_ProductProfile_IsActive;
    private bool _Business_ProductProfile_CashOnDelivery;
    private bool _Business_ProductProfile_PickFromStore;
    private bool _Business_ProductProfile_CashDeposit;
    private string _Business_ProductProfile_SellerForeignAddress;

    public string Business_ProductProfile_SellerForeignAddress
    {
        get { return _Business_ProductProfile_SellerForeignAddress; }
        set { _Business_ProductProfile_SellerForeignAddress = value; }
    }


    public bool Business_ProductProfile_CashDeposit
    {
        get { return _Business_ProductProfile_CashDeposit; }
        set { _Business_ProductProfile_CashDeposit = value; }
    }


    public bool Business_ProductProfile_PickFromStore
    {
        get { return _Business_ProductProfile_PickFromStore; }
        set { _Business_ProductProfile_PickFromStore = value; }
    }


    public bool Business_ProductProfile_CashOnDelivery
    {
        get { return _Business_ProductProfile_CashOnDelivery; }
        set { _Business_ProductProfile_CashOnDelivery = value; }
    }


    public int Business_ProductProfile_GeneralItems_ProductID
    {
        get
        {
            return _Business_ProductProfile_GeneralItems_ProductID;
        }
        set
        {
            _Business_ProductProfile_GeneralItems_ProductID = value;
        }
    }
    public string Business_ProductProfile_GeneralItems_SKU
    {
        get
        {
            return _Business_ProductProfile_GeneralItems_SKU;
        }
        set
        {
            _Business_ProductProfile_GeneralItems_SKU = value;
        }
    }
    public string Business_ProductProfile_GeneralItems_ProductTitle
    {
        get
        {
            return _Business_ProductProfile_GeneralItems_ProductTitle;
        }
        set
        {
            _Business_ProductProfile_GeneralItems_ProductTitle = value;
        }
    }
    public string Business_ProductProfile_GeneralItems_KeyFeatures
    {
        get
        {
            return _Business_ProductProfile_GeneralItems_KeyFeatures;
        }
        set
        {
            _Business_ProductProfile_GeneralItems_KeyFeatures = value;
        }
    }
    public string Business_ProductProfile_GeneralItems_ProductDescription
    {
        get
        {
            return _Business_ProductProfile_GeneralItems_ProductDescription;
        }
        set
        {
            _Business_ProductProfile_GeneralItems_ProductDescription = value;
        }
    }
    public int Business_ProductProfile_GeneralItems_ProductCondition
    {
        get
        {
            return _Business_ProductProfile_GeneralItems_ProductCondition;
        }
        set
        {
            _Business_ProductProfile_GeneralItems_ProductCondition = value;
        }
    }
    public string Business_ProductProfile_GeneralItems_ConditionNote
    {
        get
        {
            return _Business_ProductProfile_GeneralItems_ConditionNote;
        }
        set
        {
            _Business_ProductProfile_GeneralItems_ConditionNote = value;
        }
    }
    public int Business_ProductProfile_GeneralItems_Quantity
    {
        get
        {
            return _Business_ProductProfile_GeneralItems_Quantity;
        }
        set
        {
            _Business_ProductProfile_GeneralItems_Quantity = value;
        }
    }
    public string Business_ProductProfile_GeneralItems_ProductImage
    {
        get
        {
            return _Business_ProductProfile_GeneralItems_ProductImage;
        }
        set
        {
            _Business_ProductProfile_GeneralItems_ProductImage = value;
        }
    }
    public string Business_ProductProfile_GeneralItems_Currency
    {
        get
        {
            return _Business_ProductProfile_GeneralItems_Currency;
        }
        set
        {
            _Business_ProductProfile_GeneralItems_Currency = value;
        }
    }
    public double Business_ProductProfile_GeneralItems_ProductPrice
    {
        get
        {
            return _Business_ProductProfile_GeneralItems_ProductPrice;
        }
        set
        {
            _Business_ProductProfile_GeneralItems_ProductPrice = value;
        }
    }
    public double Business_ProductProfile_GeneralItems_SalePrice
    {
        get
        {
            return _Business_ProductProfile_GeneralItems_SalePrice;
        }
        set
        {
            _Business_ProductProfile_GeneralItems_SalePrice = value;
        }
    }
    public double Business_ProductProfile_GeneralItems_CashOnDeliveryCost
    {
        get
        {
            return _Business_ProductProfile_GeneralItems_CashOnDeliveryCost;
        }
        set
        {
            _Business_ProductProfile_GeneralItems_CashOnDeliveryCost = value;
        }
    }
    public string Business_ProductProfile_GeneralItems_PaymentOption
    {
        get
        {
            return _Business_ProductProfile_GeneralItems_PaymentOption;
        }
        set
        {
            _Business_ProductProfile_GeneralItems_PaymentOption = value;
        }
    }
    public DateTime Business_ProductProfile_GeneralItems_StartDate
    {
        get
        {
            return _Business_ProductProfile_GeneralItems_StartDate;
        }
        set
        {
            _Business_ProductProfile_GeneralItems_StartDate = value;
        }
    }
    public DateTime Business_ProductProfile_GeneralItems_EndDate
    {
        get
        {
            return _Business_ProductProfile_GeneralItems_EndDate;
        }
        set
        {
            _Business_ProductProfile_GeneralItems_EndDate = value;
        }
    }
    public bool Business_ProductProfile_IsActive
    {
        get
        {
            return _Business_ProductProfile_IsActive;
        }
        set
        {
            _Business_ProductProfile_IsActive = value;
        }
    }
    #endregion

    #region Business_OrderDetail_GeneralItems
    private int _Business_OrderDetail_GeneralItems_OrderID;
    private int _Business_OrderDetail_GeneralItems_Quantity;
    private string _Business_OrderDetail_GeneralItems_CustomerEmail;
    private string _Business_OrderDetail_GeneralItems_Mobile;
    private string _Business_OrderDetail_GeneralItems_CustomerName;
    private string _Business_OrderDetail_GeneralItems_CustomerMessage;
    private string _Business_OrderDetail_GeneralItems_ShipplinAddress;
    private bool _Business_OrderDetail_GeneralItems_IsDelivered;
    private bool _Business_OrderDetail_GeneralItems_IsCancelled;
    private DateTime _Business_OrderDetail_GeneralItems_OrderDate;

    public int Business_OrderDetail_GeneralItems_OrderID
    {
        get { return _Business_OrderDetail_GeneralItems_OrderID; }
        set { _Business_OrderDetail_GeneralItems_OrderID = value; }
    }
    public int Business_OrderDetail_GeneralItems_Quantity
    {
        get { return _Business_OrderDetail_GeneralItems_Quantity; }
        set { _Business_OrderDetail_GeneralItems_Quantity = value; }
    }
    public string Business_OrderDetail_GeneralItems_CustomerEmail
    {
        get { return _Business_OrderDetail_GeneralItems_CustomerEmail; }
        set { _Business_OrderDetail_GeneralItems_CustomerEmail = value; }
    }
    public string Business_OrderDetail_GeneralItems_Mobile
    {
        get { return _Business_OrderDetail_GeneralItems_Mobile; }
        set { _Business_OrderDetail_GeneralItems_Mobile = value; }
    }
    public string Business_OrderDetail_GeneralItems_CustomerName
    {
        get { return _Business_OrderDetail_GeneralItems_CustomerName; }
        set { _Business_OrderDetail_GeneralItems_CustomerName = value; }
    }
    public string Business_OrderDetail_GeneralItems_CustomerMessage
    {
        get { return _Business_OrderDetail_GeneralItems_CustomerMessage; }
        set { _Business_OrderDetail_GeneralItems_CustomerMessage = value; }
    }
    public string Business_OrderDetail_GeneralItems_ShipplinAddress
    {
        get { return _Business_OrderDetail_GeneralItems_ShipplinAddress; }
        set { _Business_OrderDetail_GeneralItems_ShipplinAddress = value; }
    }
    public bool Business_OrderDetail_GeneralItems_IsDelivered
    {
        get { return _Business_OrderDetail_GeneralItems_IsDelivered; }
        set { _Business_OrderDetail_GeneralItems_IsDelivered = value; }
    }
    public bool Business_OrderDetail_GeneralItems_IsCancelled
    {
        get { return _Business_OrderDetail_GeneralItems_IsCancelled; }
        set { _Business_OrderDetail_GeneralItems_IsCancelled = value; }
    }
    public DateTime Business_OrderDetail_GeneralItems_OrderDate
    {
        get { return _Business_OrderDetail_GeneralItems_OrderDate; }
        set { _Business_OrderDetail_GeneralItems_OrderDate = value; }
    }
    #endregion

    #region Business_ProductProfile_Books
    private int _Business_ProductProfile_Books_ProductID;
    private string _Business_ProductProfile_Books_SKU;
    private string _Business_ProductProfile_Books_BookTitle;
    private string _Business_ProductProfile_Books_Author;
    private string _Business_ProductProfile_Books_Publisher;
    private string _Business_ProductProfile_Books_ISBN;
    private string _Business_ProductProfile_Books_Edition;
    private string _Business_ProductProfile_Description;
    private int _Business_ProductProfile_Books_Quantity;
    private string _Business_ProductProfile_Books_ProductImage;
    private string _Business_ProductProfile_Books_Currency;
    private double _Business_ProductProfile_Books_ProductPrice;
    private double _Business_ProductProfile_Books_SalePrice;
    private double _Business_ProductProfile_Books_CashOnDeliveryCost;
    private string _Business_ProductProfile_Books_PaymentOption;
    private DateTime _Business_ProductProfile_Books_StartDate;
    private DateTime _Business_ProductProfile_Books_EndDate;
    private bool _Business_ProductProfile_Books_IsActive;
    private string _Business_ProductProfile_Books_Language;

    private string _Business_ProductProfile_General_DeliveryArea; //Moinur 23Mar2009

    private string _Business_ProductProfile_SubCategoryID; //Moinur 24Mar2009
    private string _Business_ProductProfile_Books_2ndSubCategoryID; //Moinur 24Mar2009
    private string _Business_ProductProfile_Books_PaperBackForBook;
    private string _Business_Product_Profile_Books_DimensionForBook;
    private string _Business_Product_Profile_Books_ShippingWeight;
    
    private bool _Business_Product_Profile_Books_TitleViolation;
    private string _Business_Product_Profile_Books_Condition;
    private string _Business_Product_Profile_Books_ConditionNote;
    private string _Business_Product_ProductYear;

    public string Business_Product_ProductYear
    {
        get { return _Business_Product_ProductYear; }
        set { _Business_Product_ProductYear = value; }
    }



    public string Business_Product_Profile_Books_Language
    {
        get { return _Business_ProductProfile_Books_Language; }
        set { _Business_ProductProfile_Books_Language = value; }
    }

    public string Business_Product_Profile_Books_ConditionNote
    {
        get { return _Business_Product_Profile_Books_ConditionNote; }
        set { _Business_Product_Profile_Books_ConditionNote = value; }
    }

    public string Business_Product_Profile_Books_Condition
    {
        get { return _Business_Product_Profile_Books_Condition; }
        set { _Business_Product_Profile_Books_Condition = value; }
    }



    public bool Business_Product_Profile_Books_TitleViolation
    {
        get { return _Business_Product_Profile_Books_TitleViolation; }
        set { _Business_Product_Profile_Books_TitleViolation = value; }
    }


  


    public string Business_Product_Profile_Books_ShippingWeight
    {
        get { return _Business_Product_Profile_Books_ShippingWeight; }
        set { _Business_Product_Profile_Books_ShippingWeight = value; }
    }


    public string Business_Product_Profile_Books_DimensionForBook
    {
        get { return _Business_Product_Profile_Books_DimensionForBook; }
        set { _Business_Product_Profile_Books_DimensionForBook = value; }
    }


    public string Business_ProductProfile_Books_PaperBackForBook
    {
        get { return _Business_ProductProfile_Books_PaperBackForBook; }
        set { _Business_ProductProfile_Books_PaperBackForBook = value; }
    }


    public int Business_ProductProfile_Books_ProductID
    {
        get
        {
            return _Business_ProductProfile_Books_ProductID;
        }
        set
        {
            _Business_ProductProfile_Books_ProductID = value;
        }
    }
    public string Business_ProductProfile_Books_SKU
    {
        get        
        {
            return _Business_ProductProfile_Books_SKU;
        }
        set
        {
            _Business_ProductProfile_Books_SKU = value;
        }
    }
    public string Business_ProductProfile_Books_BookTitle
    {
        get
        {
            return _Business_ProductProfile_Books_BookTitle;
        }
        set
        {
            _Business_ProductProfile_Books_BookTitle = value;
        }
    }
    public string Business_ProductProfile_Books_Author
    {
        get
        {
            return _Business_ProductProfile_Books_Author;
        }
        set
        {
            _Business_ProductProfile_Books_Author = value;
        }
    }
    public string Business_ProductProfile_Books_Publisher
    {
        get
        {
            return _Business_ProductProfile_Books_Publisher;
        }
        set
        {
            _Business_ProductProfile_Books_Publisher = value;
        }
    }
    public string Business_ProductProfile_Books_ISBN
    {
        get
        {
            return _Business_ProductProfile_Books_ISBN;
        }
        set
        {
            _Business_ProductProfile_Books_ISBN = value;
        }
    }
    public string Business_ProductProfile_Books_Edition
    {
        get
        {
            return _Business_ProductProfile_Books_Edition;
        }
        set
        {
            _Business_ProductProfile_Books_Edition = value;
        }
    }
    public string Business_ProductProfile_Description
    {
        get
        {
            return _Business_ProductProfile_Description;
        }
        set
        {
            _Business_ProductProfile_Description = value;
        }
    }
    public int Business_ProductProfile_Quantity
    {
        get
        {
            return _Business_ProductProfile_Books_Quantity;
        }
        set
        {
            _Business_ProductProfile_Books_Quantity = value;
        }
    }
    public string Business_ProductProfile_Books_ProductImage
    {
        get
        {
            return _Business_ProductProfile_Books_ProductImage;
        }
        set
        {
            _Business_ProductProfile_Books_ProductImage = value;
        }
    }
    public string Business_ProductProfile_Books_Currency
    {
        get
        {
            return _Business_ProductProfile_Books_Currency;
        }
        set
        {
            _Business_ProductProfile_Books_Currency = value;
        }
    }
    public double Business_ProductProfile_Books_ProductPrice
    {
        get
        {
            return _Business_ProductProfile_Books_ProductPrice;
        }
        set
        {
            _Business_ProductProfile_Books_ProductPrice = value;
        }
    }
    public double Business_ProductProfile_Books_SalePrice
    {
        get
        {
            return _Business_ProductProfile_Books_SalePrice;
        }
        set
        {
            _Business_ProductProfile_Books_SalePrice = value;
        }
    }
    public double Business_ProductProfile_Books_CashOnDeliveryCost
    {
        get
        {
            return _Business_ProductProfile_Books_CashOnDeliveryCost;
        }
        set
        {
            _Business_ProductProfile_Books_CashOnDeliveryCost = value;
        }
    }
    public string Business_ProductProfile_Books_PaymentOption
    {
        get
        {
            return _Business_ProductProfile_Books_PaymentOption;
        }
        set
        {
            _Business_ProductProfile_Books_PaymentOption = value;
        }
    }

    public DateTime Business_ProductProfile_Books_StartDate
    {
        get
        {
            return _Business_ProductProfile_Books_StartDate;
        }
        set
        {
            _Business_ProductProfile_Books_StartDate = value;
        }
    }
    public DateTime Business_ProductProfile_Books_EndDate
    {
        get
        {
            return _Business_ProductProfile_Books_EndDate;
        }
        set
        {
            _Business_ProductProfile_Books_EndDate = value;
        }
    }
    public bool Business_ProductProfile_Books_IsActive
    {
        get
        {
            return _Business_ProductProfile_Books_IsActive;
        }
        set
        {
            _Business_ProductProfile_Books_IsActive = value;
        }
    }

    public string Business_ProductProfile_General_DeliveryArea
    {
        get
        {
            return _Business_ProductProfile_General_DeliveryArea;
        }
        set
        {
            _Business_ProductProfile_General_DeliveryArea = value;
        }
    }

    public string Business_ProductProfile_Books_SubCategoryID
    {
        get
        {
            return _Business_ProductProfile_SubCategoryID;
        }
        set
        {
            _Business_ProductProfile_SubCategoryID = value;
        }
    }

    public string Business_ProductProfile_Books_2ndSubCategoryID
    {
        get
        {
            return _Business_ProductProfile_Books_2ndSubCategoryID;
        }
        set
        {
            _Business_ProductProfile_Books_2ndSubCategoryID = value;
        }
    }
    


    #endregion

    #region Business_OrderDetail_Books
    private int _Business_OrderDetail_Books_OrderID;
    private int _Business_OrderDetail_Books_Quantity;
    private string _Business_OrderDetail_Books_CustomerEmail;
    private string _Business_OrderDetail_Books_Mobile;
    private string _Business_OrderDetail_Books_CustomerName;
    private string _Business_OrderDetail_Books_CustomerMessage;
    private string _Business_OrderDetail_Books_ShipplinAddress;
    private bool _Business_OrderDetail_Books_IsDelivered;
    private bool _Business_OrderDetail_Books_IsCancelled;
    private DateTime _Business_OrderDetail_Books_OrderDate;
    
    public int Business_OrderDetail_Books_OrderID
    {
        get { return _Business_OrderDetail_Books_OrderID; }
        set { _Business_OrderDetail_Books_OrderID = value; }
    }
    public int Business_OrderDetail_Books_Quantity
    {
        get { return _Business_OrderDetail_Books_Quantity; }
        set { _Business_OrderDetail_Books_Quantity = value; }
    }
    public string Business_OrderDetail_Books_CustomerEmail
    {
        get { return _Business_OrderDetail_Books_CustomerEmail; }
        set { _Business_OrderDetail_Books_CustomerEmail = value; }
    }
    public string Business_OrderDetail_Books_Mobile
    {
        get { return _Business_OrderDetail_Books_Mobile; }
        set { _Business_OrderDetail_Books_Mobile = value; }
    }
    public string Business_OrderDetail_Books_CustomerName
    {
        get { return _Business_OrderDetail_Books_CustomerName; }
        set { _Business_OrderDetail_Books_CustomerName = value; }
    }
    public string Business_OrderDetail_Books_CustomerMessage
    {
        get { return _Business_OrderDetail_Books_CustomerMessage; }
        set { _Business_OrderDetail_Books_CustomerMessage = value; }
    }
    public string Business_OrderDetail_Books_ShipplinAddress
    {
        get { return _Business_OrderDetail_Books_ShipplinAddress; }
        set { _Business_OrderDetail_Books_ShipplinAddress = value; }
    }
    public bool Business_OrderDetail_Books_IsDelivered
    {
        get { return _Business_OrderDetail_Books_IsDelivered; }
        set { _Business_OrderDetail_Books_IsDelivered = value; }
    }
    public bool Business_OrderDetail_Books_IsCancelled
    {
        get { return _Business_OrderDetail_Books_IsCancelled; }
        set { _Business_OrderDetail_Books_IsCancelled = value; }
    }
    public DateTime Business_OrderDetail_Books_OrderDate
    {
        get { return _Business_OrderDetail_Books_OrderDate; }
        set { _Business_OrderDetail_Books_OrderDate = value; }
    }
    #endregion

    #region ProductReview_GeneralItems
    private int _ProductReview_GeneralItems_ReviewID;
    private string _ProductReview_GeneralItemsCriticsName;
    private string _ProductReview_GeneralItemsReview;

    public int ProductReview_GeneralItems_ReviewID
    {
        get { return _ProductReview_GeneralItems_ReviewID; }
        set { _ProductReview_GeneralItems_ReviewID = value; }
    }
    
    public string ProductReview_GeneralItems_CriticsName
    {
        get { return _ProductReview_GeneralItemsCriticsName; }
        set { _ProductReview_GeneralItemsCriticsName = value; }
    }

    public string ProductReview_GeneralItems_Review
    {
        get { return _ProductReview_GeneralItemsReview; }
        set { _ProductReview_GeneralItemsReview = value; }
    }
    #endregion

    #region ProductReview_Books
    private int _ProductReview_Books_ReviewID;
    private string _ProductReview_Books_CriticsName;
    private string _ProductReview_Books_Review;

    public int ProductReview_Books_ReviewID
    {
        get { return _ProductReview_Books_ReviewID; }
        set { _ProductReview_Books_ReviewID = value; }
    }

    public string ProductReview_Books_CriticsName
    {
        get { return _ProductReview_Books_CriticsName; }
        set { _ProductReview_Books_CriticsName = value; }
    }

    public string ProductReview_Books_Review
    {
        get { return _ProductReview_Books_Review; }
        set { _ProductReview_Books_Review = value; }
    }
    #endregion

    #region Classified Product Review
    private int _ProductReview_Classified_ReviewID;
    private string _ProductReview_Classified_CriticsName;
    private string _ProductReview_Classified_Review;

    public int ProductReview_Classified_ReviewID
    {
        get { return _ProductReview_Classified_ReviewID; }
        set { _ProductReview_Classified_ReviewID = value; }
    }

    public string ProductReview_Classified_CriticsName
    {
        get { return _ProductReview_Classified_CriticsName; }
        set { _ProductReview_Classified_CriticsName = value; }
    }

    public string ProductReview_Classified_Review
    {
        get { return _ProductReview_Classified_Review; }
        set { _ProductReview_Classified_Review = value; }
    }
    #endregion 

    #region Classifieds_UserProfile
    private int _Classifieds_UserProfile_ProfileID;
    private string _Classifieds_UserProfile_LoginEmail;
    private string _Classifieds_UserProfile_LoginPassword;
    private string _Classifieds_UserProfile_OldPassword;
    private string _Classifieds_UserProfile_AdvertiserName;
    private string _Classifieds_UserProfile_ContactAddress;
    private string _Classifieds_UserProfile_Mobile;
    private bool _Classifieds_UserProfile_IsActive;

    public int Classifieds_UserProfile_ProfileID
    {
        get
        {
            return _Classifieds_UserProfile_ProfileID;
        }
        set
        {
            _Classifieds_UserProfile_ProfileID = value;
        }
    }
    public string Classifieds_UserProfile_LoginEmail
    {
        get
        {
            return _Classifieds_UserProfile_LoginEmail;
        }
        set
        {
            _Classifieds_UserProfile_LoginEmail = value;
        }
    }
    public string Classifieds_UserProfile_LoginPassword
    {
        get        
        {
            return _Classifieds_UserProfile_LoginPassword;
        }
        set
        {
            _Classifieds_UserProfile_LoginPassword = value;
        }
    }
    public string Classifieds_UserProfile_OldPassword
    {
        get
        {
            return _Classifieds_UserProfile_OldPassword;
        }
        set
        {
            _Classifieds_UserProfile_OldPassword = value;
        }
    }
    public string Classifieds_UserProfile_AdvertiserName
    {
        get
        {
            return _Classifieds_UserProfile_AdvertiserName;
        }
        set
        {
            _Classifieds_UserProfile_AdvertiserName = value;
        }
    }
    public string Classifieds_UserProfile_ContactAddress
    {
        get
        {
            return _Classifieds_UserProfile_ContactAddress;
        }
        set
        {
            _Classifieds_UserProfile_ContactAddress = value;
        }
    }
    public string Classifieds_UserProfile_Mobile
    {
        get
        {
            return _Classifieds_UserProfile_Mobile;
        }
        set
        {
            _Classifieds_UserProfile_Mobile = value;
        }
    }
    public bool Classifieds_UserProfile_IsActive
    {
        get
        {
            return _Classifieds_UserProfile_IsActive;
        }
        set
        {
            _Classifieds_UserProfile_IsActive = value;
        }
    }
    #endregion

    #region Classifieds_ActivationLinks
    private int _Classifieds_ActivationLinks_LinkID;
    private bool _Classifieds_ActivationLinks_IsChecked;

    public int Classifieds_ActivationLinks_LinkID
    {
        get { return _Classifieds_ActivationLinks_LinkID; }
        set { _Classifieds_ActivationLinks_LinkID = value; }
    }
    public bool Classifieds_ActivationLinks_IsChecked
    {
        get { return _Classifieds_ActivationLinks_IsChecked; }
        set { _Classifieds_ActivationLinks_IsChecked = value; }
    }
    #endregion

    #region Classifieds_ProductProfile
    private int _Classifieds_ProductProfile_ProductID;
    private string _Classifieds_ProductProfile_AdvertisementType;
    private string _Classifieds_ProductProfile_ProductTitle;
    private string _Classifieds_ProductProfile_ProductDescription;
    private string _Classifieds_ProductProfile_ProductImage;
    private string _Classifieds_ProductProfile_Currency;
    private double _Classifieds_ProductProfile_SalePrice;
    private int _Classifieds_ProductProfile_AlternatePriceOffer;
    private bool _Classifieds_ProductProfile_IsAbused;
    private string _Classifieds_ProductProfile_Deadline;

    private string _Classifieds_ProductProfile_Source;

    private int _Classifieds_ProductProfile_AreaID;
    private bool _Classifieds_ProductProfile_IsInsideDhaka;

    public bool Classifieds_ProductProfile_IsInsideDhaka
    {
        get { return _Classifieds_ProductProfile_IsInsideDhaka; }
        set { _Classifieds_ProductProfile_IsInsideDhaka = value; }
    }


    public int Area_AreaID
    {
        get { return _Classifieds_ProductProfile_AreaID; }
        set { _Classifieds_ProductProfile_AreaID = value; }
    }

    public string Classifieds_ProductProfile_Source
    {
        get { return _Classifieds_ProductProfile_Source; }
        set { _Classifieds_ProductProfile_Source = value; }
    }


    public int Classifieds_ProductProfile_ProductID
    {
        get
        {
            return _Classifieds_ProductProfile_ProductID;
        }
        set
        {
            _Classifieds_ProductProfile_ProductID = value;
        }
    }
    public string Classifieds_ProductProfile_AdvertisementType
    {
        get
        {
            return _Classifieds_ProductProfile_AdvertisementType;
        }
        set
        {
            _Classifieds_ProductProfile_AdvertisementType = value;
        }
    }
    public string Classifieds_ProductProfile_ProductTitle
    {
        get
        {
            return _Classifieds_ProductProfile_ProductTitle;
        }
        set
        {
            _Classifieds_ProductProfile_ProductTitle = value;
        }
    }
    public string Classifieds_ProductProfile_ProductDescription
    {
        get
        {
            return _Classifieds_ProductProfile_ProductDescription;
        }
        set
        {
            _Classifieds_ProductProfile_ProductDescription = value;
        }
    }
    public string Classifieds_ProductProfile_ProductImage
    {
        get
        {
            return _Classifieds_ProductProfile_ProductImage;
        }
        set
        {
            _Classifieds_ProductProfile_ProductImage = value;
        }
    }
    public string Classifieds_ProductProfile_Currency
    {
        get
        {
            return _Classifieds_ProductProfile_Currency;
        }
        set
        {
            _Classifieds_ProductProfile_Currency = value;
        }
    }
    public double Classifieds_ProductProfile_SalePrice
    {
        get
        {
            return _Classifieds_ProductProfile_SalePrice;
        }
        set
        {
            _Classifieds_ProductProfile_SalePrice = value;
        }
    }
    public int Classifieds_ProductProfile_AlternatePriceOffer
    {
        get
        {
            return _Classifieds_ProductProfile_AlternatePriceOffer;
        }
        set
        {
            _Classifieds_ProductProfile_AlternatePriceOffer = value;
        }
    }
    public bool Classifieds_ProductProfile_IsAbused
    {
        get
        {
            return _Classifieds_ProductProfile_IsAbused;
        }
        set
        {
            _Classifieds_ProductProfile_IsAbused = value;
        }
    }
    public string Classifieds_ProductProfile_Deadline
    {
        get
        {
            return _Classifieds_ProductProfile_Deadline;
        }
        set
        {
            _Classifieds_ProductProfile_Deadline = value;
        }
    }

    private string _Classifieds_AdvertisementType;

    public string AdvertisementType
    {
        get { return _Classifieds_AdvertisementType; }
        set { _Classifieds_AdvertisementType = value; }
    }

	
    #endregion

    #region Classifieds_OrderDetail
    private int _Classifieds_OrderDetail_OrderID;
    private string _Classifieds_OrderDetail_CustomerEmail;
    private string _Classifieds_OrderDetail_Mobile;
    private string _Classifieds_OrderDetail_CustomerName;
    private string _Classifieds_OrderDetail_CustomerMessage;
    private bool _Classifieds_OrderDetail_IsDelivered;
    private DateTime _Classifieds_OrderDetail_OrderDate;

    public int Classifieds_OrderDetail_OrderID
    {
        get { return _Classifieds_OrderDetail_OrderID; }
        set { _Classifieds_OrderDetail_OrderID = value; }
    }

    public string Classifieds_OrderDetail_CustomerEmail
    {
        get { return _Classifieds_OrderDetail_CustomerEmail; }
        set { _Classifieds_OrderDetail_CustomerEmail = value; }
    }

    public string Classifieds_OrderDetail_Mobile
    {
        get { return _Classifieds_OrderDetail_Mobile; }
        set { _Classifieds_OrderDetail_Mobile = value; }
    }

    public string Classifieds_OrderDetail_CustomerName
    {
        get { return _Classifieds_OrderDetail_CustomerName; }
        set { _Classifieds_OrderDetail_CustomerName = value; }
    }

    public string Classifieds_OrderDetail_CustomerMessage
    {
        get { return _Classifieds_OrderDetail_CustomerMessage; }
        set { _Classifieds_OrderDetail_CustomerMessage = value; }
    }

    public bool Classifieds_OrderDetail_IsDelivered
    {
        get { return _Classifieds_OrderDetail_IsDelivered; }
        set { _Classifieds_OrderDetail_IsDelivered = value; }
    }

    public DateTime Classifieds_OrderDetail_OrderDate
    {
        get { return _Classifieds_OrderDetail_OrderDate; }
        set { _Classifieds_OrderDetail_OrderDate = value; }
    }
    #endregion

    #region AdvertiseMent Request
    private int _ad_landing_si_no;
    private string _AdRequest_User_Name;
    private string _AdRequest_User_Address;
    private string _AdRequest_User_PhoneNo;
    private string _AdRequest_User_Mail;
    private string _AdRequest_User_Message;

    public string AdRequest_User_Name
    {
        get
        {
            return _AdRequest_User_Name;
        }
        set
        {
            _AdRequest_User_Name = value;
        }

    }
    public string AdRequest_User_Address
    {
        get
        {
            return _AdRequest_User_Address;
        }
        set
        {
            _AdRequest_User_Address = value;
        }
    }
    public string AdRequest_User_PhoneNo
    {
        get
        {
            return _AdRequest_User_PhoneNo;
        }
        set
        {
            _AdRequest_User_PhoneNo = value;
        }
    }
    public string AdRequest_User_Mail
    {
        get
        {
            return _AdRequest_User_Mail;
        }
        set
        {
            _AdRequest_User_Mail = value;
        }
    }
    public string AdRequest_User_Message
    {
        get
        {
            return _AdRequest_User_Message;
        }
        set
        {
            _AdRequest_User_Message = value;
        }
    }
    public int Ad_Landing_Si_No
    {
        get
        {
            return _ad_landing_si_no;
        }
        set
        {
            _ad_landing_si_no = value;
        }
    }

    #endregion AdvertiseMent Request

    #region UserProfile
    private bool _IsUser_Administrator;

    public bool IsAdmin
    {
        get { return _IsUser_Administrator; }
        set { _IsUser_Administrator = value; }
    }


    private string _UserProfile_BillingPerson;

    public string UserProfile_BillingPerson
    {
        get { return _UserProfile_BillingPerson; }
        set { _UserProfile_BillingPerson = value; }
    }

    private string _UserProfile_UserName;

    public string UserProfile_UserName
    {
        get { return _UserProfile_UserName; }
        set { _UserProfile_UserName = value; }
    }


    #endregion UserProfile

    #region PROPERTIES FOR COMPUTER PRODUCT


    private string _Computer_DedicatedVideoMemory;
    private string _Computer_SharedVideoMemory;
    private string _Computer_TVTuner;
    private string _Computer_VideoMemory;
    private string _Computer_HDCPCompliant;
    private string _Computer_AudioOutput;
    private string _Computer_DigitalInput;
    private string _Computer_DigitalOutput;
    private string _Computer_IntegretedMicrophone;
    private string _Computer_LineOut;
    private string _Computer_LineInInput;
    private string _Computer_MicrophoneInput;
    private string _Computer_SoundCard;
    private string _Computer_EthernetPort;
    private string _Computer_IntegretedBluetooth;
    private string _Computer_IntegretedWiFi;
    private string _Computer_CardReader;
    private string _Computer_DVIOutput;
    private string _Computer_ESata;
    private string _Computer_HDMI;
    private string _Computer_USB2;
    private string _Computer_VGAOutput;
    private string _Computer_Webcam;

    public string Computer_Webcam
    {
        get { return _Computer_Webcam; }
        set { _Computer_Webcam = value; }
    }

    public string Computer_VGAOutput
    {
        get { return _Computer_VGAOutput; }
        set { _Computer_VGAOutput = value; }
    }

    public string Computer_USB2
    {
        get { return _Computer_USB2; }
        set { _Computer_USB2 = value; }
    }


    public string Computer_HDMI
    {
        get { return _Computer_HDMI; }
        set { _Computer_HDMI = value; }
    }


    public string Computer_ESata
    {
        get { return _Computer_ESata; }
        set { _Computer_ESata = value; }
    }


    public string Computer_DVIOutput
    {
        get { return _Computer_DVIOutput; }
        set { _Computer_DVIOutput = value; }
    }


    public string Computer_CardReader
    {
        get { return _Computer_CardReader; }
        set { _Computer_CardReader = value; }
    }

    public string Computer_IntegretedWiFi
    {
        get { return _Computer_IntegretedWiFi; }
        set { _Computer_IntegretedWiFi = value; }
    }



    public string Computer_IntegretedBluetooth
    {
        get { return _Computer_IntegretedBluetooth; }
        set { _Computer_IntegretedBluetooth = value; }
    }



    public string Computer_EthernetPort
    {
        get { return _Computer_EthernetPort; }
        set { _Computer_EthernetPort = value; }
    }



    public string Computer_SoundCard
    {
        get { return _Computer_SoundCard; }
        set { _Computer_SoundCard = value; }
    }


    public string Computer_MicrophoneInput
    {
        get { return _Computer_MicrophoneInput; }
        set { _Computer_MicrophoneInput = value; }
    }

    public string Computer_LineInInput
    {
        get { return _Computer_LineInInput; }
        set { _Computer_LineInInput = value; }
    }



    public string Computer_LineOut
    {
        get { return _Computer_LineOut; }
        set { _Computer_LineOut = value; }
    }





    public string Computer_IntegretedMicrophone
    {
        get { return _Computer_IntegretedMicrophone; }
        set { _Computer_IntegretedMicrophone = value; }
    }


    public string Computer_DigitalOutput
    {
        get { return _Computer_DigitalOutput; }
        set { _Computer_DigitalOutput = value; }
    }


    public string Computer_DigitalInput
    {
        get { return _Computer_DigitalInput; }
        set { _Computer_DigitalInput = value; }
    }



    public string Computer_AudioOutput
    {
        get { return _Computer_AudioOutput; }
        set { _Computer_AudioOutput = value; }
    }
    public string Computer_HDCPCompliant
    {
        get { return _Computer_HDCPCompliant; }
        set { _Computer_HDCPCompliant = value; }
    }



    public string Computer_VideoMemory
    {
        get { return _Computer_VideoMemory; }
        set { _Computer_VideoMemory = value; }
    }




    public string Computer_TVTuner
    {
        get { return _Computer_TVTuner; }
        set { _Computer_TVTuner = value; }
    }


    public string Computer_SharedVideoMemory
    {
        get { return _Computer_SharedVideoMemory; }
        set { _Computer_SharedVideoMemory = value; }
    }



    public string Computer_DedicatedVideoMemory
    {
        get { return _Computer_DedicatedVideoMemory; }
        set { _Computer_DedicatedVideoMemory = value; }
    }




    #endregion PROPERTIES FOR COMPUTER PRODUCT

    #region PROPERTIES FOR CAR PRODUCT
    private string _Automobile_VIN;
    private string _Automobile_CarSubModel;
    private string _Automobile_Mileage;
    private string _Automobile_VehicleRegYear;

    public string Automobile_VehicleRegYear
    {
        get { return _Automobile_VehicleRegYear; }
        set { _Automobile_VehicleRegYear = value; }
    }

    public string Automobile_Mileage
    {
        get { return _Automobile_Mileage; }
        set { _Automobile_Mileage = value; }
    }

    public string Automobile_CarSubModel
    {
        get { return _Automobile_CarSubModel; }
        set { _Automobile_CarSubModel = value; }
    }

    public string Automobile_VIN
    {
        get { return _Automobile_VIN; }
        set { _Automobile_VIN = value; }
    }


    #endregion PROPERTIES FOR CAR PRODUCT

    #region PROPERTIES FOR CLASSIFIEDS SELLER ADDRESS

    private string _Classifieds_Seller_Address;

    public string Classifieds_Seller_Address
    {
        get { return _Classifieds_Seller_Address; }
        set { _Classifieds_Seller_Address = value; }
    }

    private string _Classifieds_Seller_Name;

    public string Classifieds_Seller_Name
    {
        get { return _Classifieds_Seller_Name; }
        set { _Classifieds_Seller_Name = value; }
    }
    private string _Classifieds_Seller_Mobile;

    public string Classifieds_Seller_Mobile
    {
        get { return _Classifieds_Seller_Mobile; }
        set { _Classifieds_Seller_Mobile = value; }
    }
    private int _Classifieds_Seller_ProvinceID;

    public int Classifieds_Seller_ProvinceID
    {
        get { return _Classifieds_Seller_ProvinceID; }
        set { _Classifieds_Seller_ProvinceID = value; }
    }
    private int _Classifieds_Seller_StateID;

    public int Classifieds_Seller_StateID
    {
        get { return _Classifieds_Seller_StateID; }
        set { _Classifieds_Seller_StateID = value; }
    }

    private bool _Is_Alternative_Address;

    public bool Is_Alternative_Address
    {
        get { return _Is_Alternative_Address; }
        set { _Is_Alternative_Address = value; }
    }
    private int _AlternativeAddressID;

    public int AlternativeAddressID
    {
        get { return _AlternativeAddressID; }
        set { _AlternativeAddressID = value; }
    }



    #endregion PROPERTIES FOR CLASSIFIEDS SELLER ADDRESS

    #region DiscountEmail 

    private string _DiscountEmail;

    public string DiscountEmail
    {
        get { return _DiscountEmail; }
        set { _DiscountEmail = value; }
    }
    #endregion DiscountEmail


    #region AddDiscountAdminCompany

    private int _ReferanceID;

    public int ReferanceID
    {
        get { return _ReferanceID; }
        set { _ReferanceID = value; }
    }
    #endregion AddDiscountAdminCompany


    public EOC_PropertyBean()
	{
	}
}


