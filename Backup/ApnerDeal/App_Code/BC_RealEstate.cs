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
/// Summary description for BC_RealEstate
/// </summary>
public class BC_RealEstate : DbBaseClass
{
    public BC_RealEstate(): base(StaticSettings.Database.DbConnectionString)
	{
		//
		// TODO: Add constructor logic here
		//
    }

    #region UPDATE METHOD

    public int UpdateRealEstate(RealEstate objRealEstate)
    {
        try
        {
            Hashtable ht = new Hashtable();
            ht.Add("@ProductID", objRealEstate.ProductID);
            ht.Add("@ProfileID", objRealEstate.ProfileID);
            ht.Add("@UserType", objRealEstate.UserType);

            ht.Add("@SubcategoryID", objRealEstate.SubcategoryID);
            ht.Add("@SecondSubcatID", objRealEstate.SecondSubcatID);
            ht.Add("@SellerType", objRealEstate.SellerType);
            ht.Add("@SellerName", objRealEstate.SellerName);

            ht.Add("@ProjectType", objRealEstate.ProjectType);
            ht.Add("@ProjectName", objRealEstate.ProjectName);
            ht.Add("@ProvinceID", objRealEstate.ProvinceID);
            ht.Add("@AreaID", objRealEstate.AreaID);

            ht.Add("@Area", objRealEstate.Area);
            ht.Add("@SizeUnit", objRealEstate.SizeUnit);
            ht.Add("@Address", objRealEstate.Address);
            ht.Add("@Size", objRealEstate.Size);


            ht.Add("@LandNature", objRealEstate.LandNature);
            ht.Add("@Quantity", objRealEstate.Quantity);
            ht.Add("@Price", objRealEstate.Price);
            ht.Add("@Currency", objRealEstate.Currency);

            ht.Add("@NoOfBedRoom", objRealEstate.NoOfBedRoom);
            ht.Add("@NoOfWashRoom", objRealEstate.NoOfWashRoom);
            ht.Add("@ServiceCharge", objRealEstate.ServiceCharge);
            ht.Add("@IsCarParkingAvailable", objRealEstate.IsCarParkingAvailable);

            ht.Add("@Description", objRealEstate.Description);
            ht.Add("@IsActive", objRealEstate.IsActive);
            ht.Add("@UpdatedOn", objRealEstate.UpdatedOn);
            ht.Add("@IsInsideDhaka", objRealEstate.IsInsideDhaka);
            ht.Add("@ProductImage", objRealEstate.ProductImage);
            ht.Add("@IsAlternativeAddress", objRealEstate.IsAlternativeAddress);
            ht.Add("@Source", objRealEstate.Source);


            return this.ExecuteNonQueryStoredProcedure("USP_RealEState_UpdateRealEState", ht);
        }
        catch
        {
            throw;
        }
    }

    #endregion UPDATE METHOD



    /// <summary>
    /// Inserts Real Estate in the Database.
    /// USP: USP_RealState_InsertRealState
    /// </summary>
    /// <param name="objRealEstate"></param>
    /// <returns></returns>
    public int InsertRealEstate(RealEstate objRealEstate)
    {
        try
        {
            Hashtable ht = new Hashtable();
            ht.Add("@ProfileID", objRealEstate.ProfileID);
            ht.Add("@UserType", objRealEstate.UserType);
            ht.Add("@SKU", objRealEstate.SKU);
            ht.Add("@CategoryID", objRealEstate.CategoryID);

            ht.Add("@SubcategoryID", objRealEstate.SubcategoryID);
            ht.Add("@SecondSubcatID", objRealEstate.SecondSubcatID);
            ht.Add("@SellerType", objRealEstate.SellerType);
            ht.Add("@SellerName", objRealEstate.SellerName);

            ht.Add("@ProjectType", objRealEstate.ProjectType);
            ht.Add("@ProjectName", objRealEstate.ProjectName);
            ht.Add("@ProvinceID", objRealEstate.ProvinceID);
            ht.Add("@AreaID", objRealEstate.AreaID);

            ht.Add("@Area", objRealEstate.Area);
            ht.Add("@SizeUnit", objRealEstate.SizeUnit);
            ht.Add("@Address", objRealEstate.Address);
            ht.Add("@Size", objRealEstate.Size);

            
            ht.Add("@LandNature", objRealEstate.LandNature);
            ht.Add("@Quantity", objRealEstate.Quantity);
            ht.Add("@Price", objRealEstate.Price);
            ht.Add("@Currency", objRealEstate.Currency);

            ht.Add("@NoOfBedRoom", objRealEstate.NoOfBedRoom);
            ht.Add("@NoOfWashRoom", objRealEstate.NoOfWashRoom);
            ht.Add("@ServiceCharge", objRealEstate.ServiceCharge);
            ht.Add("@IsCarParkingAvailable", objRealEstate.IsCarParkingAvailable);

            ht.Add("@Description", objRealEstate.Description);
            ht.Add("@IsActive", objRealEstate.IsActive);
            ht.Add("@UpdatedOn", objRealEstate.UpdatedOn);
            ht.Add("@IsInsideDhaka", objRealEstate.IsInsideDhaka);
            ht.Add("@ProductImage", objRealEstate.ProductImage);
            ht.Add("@IsAlternativeAddress", objRealEstate.IsAlternativeAddress);
            ht.Add("@Source", objRealEstate.Source);

            return this.ExecuteNonQueryStoredProcedure("USP_RealState_InsertRealState", ht);
        }
        catch
        {
            throw;
        }
    }


    #region SELECT METHOD

    public DataTable SelectRecord_RealEstate(RealEstate objRealEstate)
    {
        try
        {
            Hashtable ht = new Hashtable();
            ht.Add("@ProductID", objRealEstate.ProductID);

            return this.ExecuteStoredProcedureDataTable("USP_CP_RealEstate_SelectRecord", ht);
        }
        catch
        {
            throw;
        }
    }
    #endregion SELECT METHOD

    #region DUPLICATION CHECKING METHOD

    /// <summary>
    /// Before insert Checks if the Real estate title is duplicate, returns true if duplicate, false other wise.
    /// </summary>
    /// <param name="objReview"></param>
    /// <returns></returns>
    public bool BeforeInsert_IsRealEstateTitle_Duplicate(RealEstate objRealEstate)
    {
        DataTable dt = null;
        Hashtable ht = new Hashtable();
        //ht.Add("@ProductID", objRealEstate.ProductID);
        ht.Add("@ProjectName", objRealEstate.ProjectName);
        ht.Add("@SubcategoryID", objRealEstate.SubcategoryID);
        ht.Add("@LocationID", objRealEstate.LocationID);
        ht.Add("@IsInsideDhaka", objRealEstate.IsInsideDhaka);
        try
        {
            dt = this.ExecuteStoredProcedureDataTable("USP_CP_RealEstate_BeforeInsert_IsProjectNameDuplicate", ht);
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
    /// Before Update Checks if the Real estate title is duplicate, returns true if duplicate, false other wise.
    /// </summary>
    /// <param name="objReview"></param>
    /// <returns></returns>
    public bool BeforeUpdate_IsRealEstateTitle_Duplicate(RealEstate objRealEstate)
    {
        DataTable dt = null;
        Hashtable ht = new Hashtable();
        ht.Add("@ProductID", objRealEstate.ProductID);
        ht.Add("@SubCategoryID", objRealEstate.SubcategoryID);
        ht.Add("@LocationID", objRealEstate.LocationID);
        ht.Add("@IsInsideDhaka", objRealEstate.IsInsideDhaka);
        ht.Add("@ProjectName", objRealEstate.ProjectName);
        try
        {
            dt = this.ExecuteStoredProcedureDataTable("USP_CP_RealEstate_BeforeUpdate_IsProjectNameDuplicate", ht);
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

    #endregion DUPLICATION CHECKING METHOD


    #region LOAD METHODS FOR CONTROL PANEL

    public DataTable LoadList_PostedRealEstate(RealEstate objRealEstate)
    {
        DataTable dt = null;
        Hashtable ht = new Hashtable();
        ht.Add("@ProfileID", objRealEstate.ProfileID);
        ht.Add("@StartDate", objRealEstate.StartDate);
        ht.Add("@EndDate", objRealEstate.EndDate);
        //ht.Add("@SubCategoryID", objRealEstate.SubcategoryID);

        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_CP_RealEstate_LoadList_Posted_RealEstate", ht);
        }
        catch
        {
            throw;
        }
    }

    #endregion LOAD METHODS FOR CONTROL PANEL

    #region LOAD METHODS FOR LISTING AND DETAIL PAGE

    public DataTable Load_List_RealEstate_BySubcategory(RealEstate objRealEstate)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@CategoryID", objRealEstate.CategoryID);
        ht.Add("@SubcategoryID", objRealEstate.SubcategoryID);

        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_RealEstate_LoadListRealState_BySubcategory", ht);

        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Loads All Items of a Specific CL Seller. Based on CategoryID and SubcategoryID
    /// USP: USP_Common_ItemList_Load_CL_Seller_Product
    /// </summary>
    public DataTable Load_List_RealEstate_ClassifiedSellerProduct_BySubcategory(RealEstate objRealEstate)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@CategoryID", objRealEstate.CategoryID);
        ht.Add("@SubcategoryID", objRealEstate.SubcategoryID);

        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_Common_ItemList_Load_CL_Seller_Product", ht);
        }
        catch
        {
            throw;
        }
    }


    public DataTable LoadList_RealEstate_BySecondSubcategory(RealEstate objRealEstate)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@SubcategoryID", objRealEstate.SubcategoryID);
        ht.Add("@SecondSubcatID", objRealEstate.SecondSubcatID);

        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_RealEstate_LoadListRealState_BySecondsubcategory", ht);

        }
        catch
        {
            throw;
        }
    }

    public DataTable LoadRecord_Detail_RealEstate(RealEstate objRealEstate)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@ProductID", objRealEstate.ProductID);

        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_RealEstate_SelectDetail_RealEstate", ht);
        }
        catch
        {
            throw;
        }
    }

    public DataTable Load_List_RealEstate_ByProvince(RealEstate objRealEstate)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@CategoryID", objRealEstate.CategoryID);
        ht.Add("@SubcategoryID", objRealEstate.SubcategoryID);
        ht.Add("@ProvinceID", objRealEstate.ProvinceID);

        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_Common_ItemList_LatestPosted_RealEstate_ByProvince", ht);
        }
        catch
        {
            throw;
        }
    }


    #endregion LOAD METHODS FOR LISTING AND DETAIL PAGE

    #region LOAD METHODS FOR LEFT MENU

    public DataTable Load_LeftMenu_SecondSubcategory(RealEstate objRealEstate)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@SubcategoryID", objRealEstate.SubcategoryID);

        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_RealEstate_LeftMenu_Load_SecondSubcategory", ht);
        }
        catch
        {
            throw;
        }
    }

    #endregion LOAD METHODS FOR LEFT MENU
    

    /// <summary>
    /// Loads Name of the Locations inside Dhaka with Number of Classified items Posted on that specific Location.
    /// Loads Items For Specific Classified Categories
    /// USP:
    /// </summary>
    /// <param name="intCategoryID"></param>
    /// <returns></returns>
    public DataTable LoadList_CL_Items_ByArea(int intCategoryID, int intSubCategoryID)
    {
        Hashtable htParams = new Hashtable();
        htParams.Add("@CategoryID", intCategoryID);
        htParams.Add("@SubCategoryID", intSubCategoryID);
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_LeftMenu_RealEstate_ItemList_ByArea", htParams);
        }
        catch
        {
            throw;
        }
    }


    public DataTable LoadList_CL_Items_ByProvince(int intCategoryID, int intSubCategoryID)
    {
        Hashtable htParams = new Hashtable();
        htParams.Add("@CategoryID", intCategoryID);
        htParams.Add("@SubCategoryID", intSubCategoryID);
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_LeftMenu_RealEstate_ItemList_ByProvince", htParams);
        }
        catch
        {
            throw;
        }
    }


    public DataTable Load_List_RealEstate_ByArea_InsideDhaka(RealEstate objRealEstate)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@CategoryID", objRealEstate.CategoryID);
        ht.Add("@SubcategoryID", objRealEstate.SubcategoryID);
        ht.Add("@AreaID", objRealEstate.AreaID);

        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_Common_ItemList_LatestPosted_RealEstate_ByArea_InsideDhaka", ht);
        }
        catch
        {
            throw;
        }
    }

    


}
