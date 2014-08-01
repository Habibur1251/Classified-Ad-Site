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
/// Summary description for BC_Classifieds_Item
/// </summary>
public class BC_Classifieds_Item : DbBaseClass
{
	public BC_Classifieds_Item(): base(StaticSettings.Database.DbConnectionString)
	{
		//
		// TODO: Add constructor logic here
		//
	}

    /// <summary>
    /// Loads Name of the Province with Number of Classified items Posted on that specific Province.
    /// Loads Items For Specific Classified Categories
    /// USP: USP_Load_ItemList_Classifieds_ByProvince
    /// </summary>
    /// <param name="intCountryID"></param>
    /// <returns></returns>
    public DataTable LoadList_CL_Items_ByProvince(int intCategoryID)
    {
        Hashtable htParams = new Hashtable();
        htParams.Add("@CategoryID", intCategoryID);
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_LeftMenu_Classifieds_ItemList_ByProvince", htParams);
        }
        catch
        {
            throw;
        }
 
    }

    /// <summary>
    /// Loads Name of the Locations inside Dhaka with Number of Classified items Posted on that specific Location.
    /// Loads Items For Specific Classified Categories
    /// USP: 
    /// </summary>
    /// <param name="intCategoryID"></param>
    /// <returns></returns>
    public DataTable LoadList_CL_Items_ByArea(int intCategoryID)
    {
        Hashtable htParams = new Hashtable();
        htParams.Add("@CategoryID", intCategoryID);
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_LeftMenu_Classifieds_ItemList_ByArea", htParams);
        }
        catch
        {
            throw;
        }

    }


    /// <summary>
    /// Loads all the Area name inside Dhaka.
    /// USP: USP_Common_Public_LoadList_Area
    /// </summary>
    /// <param name="intCategoryID"></param>
    /// <returns></returns>
    public DataTable LoadList_CL_Dhaka_Area(int intProvinceID)
    {
        Hashtable htParams = new Hashtable();
        htParams.Add("@ProvinceID", intProvinceID);
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_Common_Public_LoadList_Area", htParams);
        }
        catch
        {
            throw;
        }

    }



    #region Classified Left Menu

    /// <summary>
    /// Loads all Classified Category with Number of items posted in that Category.
    /// USP: USP_Classified_LeftMenu_LoadAllCategory_WithNoOf_Items
    /// </summary>
    /// <param name="strCountry"></param>
    /// <returns></returns>
    public DataTable LoadList_ClassifiedCategory_WithNoOf_Items(string strCountry)
    {
        Hashtable htParams = new Hashtable();
        htParams.Add("@Country", strCountry);
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_Classified_LeftMenu_LoadAllCategory_WithNoOf_Items", htParams);
        }
        catch
        {
            throw;
        }
    }



    public DataTable LoadList_Classified_Housing_WithNoOf_Items(string strCountry, int _SubcategoryID)
    {
        Hashtable htParams = new Hashtable();
        htParams.Add("@Country", strCountry);
        htParams.Add("@SubcategoryID", _SubcategoryID);
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_Classified_LeftMenu_Load_Housing_WithNoOf_Items", htParams);
        }
        catch
        {
            throw;
        }
    }

    

    /// <summary>
    /// Loads Number of Negotiable Classified Items.
    /// USP: USP_Classified_LeftMenu_Load_NumberOf_NegotiableItems
    /// </summary>
    /// <param name="strCountry"></param>
    /// <returns></returns>
    public DataTable LoadNumberOf_NegotiableItems(int intCategoryID)
    {
        Hashtable htParams = new Hashtable();
        htParams.Add("@CategoryID", intCategoryID);
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_Classified_LeftMenu_Load_NumberOf_NegotiableItems", htParams);
        }
        catch
        {
            throw;
        }
    }

    #endregion Classified Left Menu




    #region ItemList_Classified Page

    /// <summary>
    /// Loads Classified Items Based on Province and CategoryID.
    /// USP: USP_Selector_ItemList_ClassifiedItems_ByProvince
    /// </summary>
    /// <param name="intProvince"></param>
    /// <param name="intCategoryID"></param>
    /// <returns></returns>
    public DataTable LoadList_Classified_Items_By_Province_Category(int intProvinceID, int intCategoryID)
    {
        Hashtable htParams = new Hashtable();
        htParams.Add("@ProvinceID", intProvinceID);
        htParams.Add("@CategoryID", intCategoryID);
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_Classified_ItemList_LoadAll_CategoryItem_ByProvince", htParams);
        }
        catch
        {
            throw;
        }

    }


    /// <summary>
    /// Loads Product of a Specific Area Under Specific Province. Primarily It displays Dhaka Areas only.
    /// USP: USP_Classified_ItemList_LoadAll_CategoryItem_ByProvince_Area
    /// </summary>
    /// <param name="intProvinceID"></param>
    /// <param name="intCategoryID"></param>
    /// <returns></returns>
    public DataTable LoadList_Classified_Items_By_Province_Area_Category(int intAreaID, int intCategoryID)
    {
        Hashtable htParams = new Hashtable();
        htParams.Add("@AreaID", intAreaID);
        htParams.Add("@CategoryID", intCategoryID);
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_Classified_ItemList_LoadAll_CategoryItem_ByProvince_Area", htParams);
        }
        catch
        {
            throw;
        }

    }





    /// <summary>
    /// Loads Only Negotiable Classified Items.
    /// USP: USP_CL_Public_LoadList_Classifieds_NegotiableItems
    /// </summary>
    /// <param name="intProvinceID"></param>
    /// <param name="intCategoryID"></param>
    /// <returns></returns>
    public DataTable LoadList_Negotiable_ClassifiedItems(int intCategoryID)
    {
        Hashtable htParams = new Hashtable();
        htParams.Add("@CategoryID", intCategoryID);
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_CL_Public_LoadList_Classifieds_NegotiableItems", htParams);
        }
        catch
        {
            throw;
        }

    }



    /// <summary>
    /// Loads Negotiable Classified Items By their subcategory.
    /// USP: USP_CL_Public_LoadList_Classifieds_NegotiableItems_BySubcategory
    /// </summary>
    /// <param name="intCategoryID"></param>
    /// <returns></returns>
    public DataTable LoadList_Negotiable_ClassifiedItems_BySubcategory(int intCategoryID, int intSubcategory)
    {
        Hashtable htParams = new Hashtable();
        htParams.Add("@CategoryID", intCategoryID);
        htParams.Add("@SubcategoryID", intSubcategory);
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_CL_Public_LoadList_Classifieds_NegotiableItems_BySubcategory", htParams);
        }
        catch
        {
            throw;
        }

    }

    /// <summary>
    /// Loads Specific Category and SubcategoryItems of a selected Province.
    /// USP:  USP_CL_Public_LoadList_Classifieds_ProvinceItems_BySubcategory
    /// </summary>
    /// <param name="intCategoryID"></param>
    /// <param name="intSubcategory"></param>
    /// <param name="intProvinceID"></param>
    /// <returns></returns>
    public DataTable LoadList_Province_ClassifiedItems_BySubcategory(int intCategoryID, int intSubcategory, int intProvinceID)
    {
        Hashtable htParams = new Hashtable();
        htParams.Add("@CategoryID", intCategoryID);
        htParams.Add("@SubcategoryID", intSubcategory);
        htParams.Add("@ProvinceID", intProvinceID);
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_CL_Public_LoadList_Classifieds_ProvinceItems_BySubcategory", htParams);
        }
        catch
        {
            throw;
        }

    }

    #endregion ItemList_Classified Page
}

