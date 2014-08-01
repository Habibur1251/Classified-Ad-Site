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
/// Summary description for BC_DiscountZone
/// </summary>
public class BC_DiscountZone : DbBaseClass
{
    public BC_DiscountZone(): base(StaticSettings.Database.DbConnectionString)
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int InsertDiscountCoupon(DiscountZone discountZone)
    {
        try
        {
            Hashtable ht = new Hashtable();
            ht.Add("@CategoryID", discountZone.CategoryID);
            ht.Add("@SubcategoryID", discountZone.SubcategoryID);
            ht.Add("@ProfileID", discountZone.ProfileID);
            ht.Add("@CouponTitle", discountZone.CouponTitle);
            ht.Add("@CouponDescription", discountZone.CouponDescription);
            ht.Add("@CouponType", discountZone.CouponType);
            ht.Add("@CouponCode", discountZone.CouponCode);
            ht.Add("@UseBoromelaCoupon", discountZone.UseBoromelaCoupon);
            ht.Add("@UserUploadedCouponPath", discountZone.UserUploadedCouponPath);
            ht.Add("@IsActive", discountZone.IsActive);
            ht.Add("@CouponEffectiveDate", discountZone.CouponEffectiveDate);
            ht.Add("@CouponExpirydate", discountZone.CouponExpirydate);
            ht.Add("@UpdatedOn", discountZone.UpdatedOn);
            ht.Add("@TermsCondition", discountZone.TermsCondition);
            ht.Add("@PrintedCouponNeed", discountZone.NeedToPrintCoupon);
            ht.Add("@DiscountCouponURL", discountZone.DiscountCouponURL);
            return this.ExecuteNonQueryStoredProcedure("USP_DiscountZone_InsertDiscountCoupon", ht);
        }
        catch
        {
            throw;
        }

    }
    public int InsertReport(DiscountZone discountZone)
    {
        try
        {
            Hashtable ht = new Hashtable();
            ht.Add("@ProfileID", discountZone.ProfileID);
            ht.Add("@CouponID", discountZone.CouponID);
            ht.Add("@EmailAddress", discountZone.EmailAddress);
            ht.Add("@Name", discountZone.Name);
            ht.Add("@Subject", discountZone.Subject);
            ht.Add("@Report", discountZone.Report);
            return this.ExecuteNonQueryStoredProcedure("USP_DiscountZone_InsertReport", ht);
        }
        catch
        {
            throw;
        }

    }


    public int InsertComment(DiscountZone discountZone)
    {
        try
        {
            Hashtable ht = new Hashtable();
            ht.Add("@ProfileID", discountZone.ProfileID);
            ht.Add("@CouponID", discountZone.CouponID);
            ht.Add("@EmailAddress", discountZone.EmailAddress);
            ht.Add("@Name", discountZone.Name);
            ht.Add("@Subject", discountZone.Subject);
            ht.Add("@Comment", discountZone.Comment);
            return this.ExecuteNonQueryStoredProcedure("USP_DiscountZone_InsertComment", ht);
        }
        catch
        {
            throw;
        }

    }

    public int UpdateDiscountCoupon(DiscountZone discountZone)
    {
        try
        {
            Hashtable ht = new Hashtable();
            ht.Add("@CouponID", discountZone.CouponID);
            ht.Add("@ProfileID", discountZone.ProfileID);
            ht.Add("@CouponCode", discountZone.CouponCode);
            ht.Add("@CouponTitle", discountZone.CouponTitle);
            ht.Add("@CouponDescription", discountZone.CouponDescription);
            ht.Add("@CouponType", discountZone.CouponType);
            ht.Add("@UseBoromelaCoupon", discountZone.UseBoromelaCoupon);
            ht.Add("@UserUploadedCouponPath", discountZone.UserUploadedCouponPath);
            ht.Add("@CouponEffectiveDate", discountZone.CouponEffectiveDate);
            ht.Add("@CouponExpirydate", discountZone.CouponExpirydate);
            ht.Add("@UpdatedOn", discountZone.UpdatedOn);
            ht.Add("@TermsCondition", discountZone.TermsCondition);
            ht.Add("@PrintedCouponNeed", discountZone.NeedToPrintCoupon);
            ht.Add("@DiscountCouponURL", discountZone.DiscountCouponURL);

            return this.ExecuteNonQueryStoredProcedure("USP_DiscountZone_UpdateDiscountCoupon", ht);
        }
        catch
        {
            throw;
        }

    }

    public int InsertDiscountStore(DiscountZone discountZone)
    {
        try
        {
            Hashtable ht = new Hashtable();
            ht.Add("@ProfileID", discountZone.ProfileID);
            ht.Add("@DiscountStoreType", discountZone.DiscountUserType);
            ht.Add("@StoresIsActive", discountZone.IsActive);
            ht.Add("@IsAdminAuthentication", discountZone.IsAdminAuthentication);
            ht.Add("@CheckAdminForListiong", discountZone.CheckAdminForListing);
            ht.Add("@CheckAdminForListiongFeaturedStore", discountZone.CheckAdminForListingFeatureStore);
            ht.Add("@UserType", discountZone.IsAdminAuthentication);
            return this.ExecuteNonQueryStoredProcedure("USP_DiscountZone_InsertDiscountStore", ht);
        }
        catch
        {
            throw;
        }
    }
    public int UpdateDiscountStore(DiscountZone discountZone)
    {
        try
        {
            Hashtable ht = new Hashtable();
            ht.Add("@ProfileID", discountZone.ProfileID);
            ht.Add("@DiscountStoreType", discountZone.DiscountUserType);
            return this.ExecuteNonQueryStoredProcedure("USP_DiscountZone_UpdateDiscountStore", ht);
        }
        catch
        {
            throw;
        }
    }

    public int AdSubcriptionEmailAddress(DiscountZone discountZone)
    {
        int intActionResult = 0;
        try
        {
            Hashtable ht = new Hashtable();
            ht.Add("@emailAddress", discountZone.DiscountSubcriptionEmail);
            if (this.ExecuteStoredProcedureDataTable("USP_DRP_Common_SignUP_BeforeInsert_IsSignUPEmailDuplicate", ht).Rows.Count == 0)
            {
                ht.Clear();
                ht.Add("@emailAddress", discountZone.DiscountSubcriptionEmail);
                intActionResult = this.ExecuteNonQueryStoredProcedure("USP_SaveDiscountEmail", ht);
            }
            else
            {
                intActionResult = -1;
            }
        }
        catch
        {
            throw;
        }
        return intActionResult;
    }
    public DataTable GenerateCouponCode()
    {
        try
        {
            Hashtable ht = new Hashtable();
            return this.ExecuteStoredProcedureDataTable("USP_DiscountZone_GenerateCouponCode", ht);
        }
        catch
        {
            throw;
        }
    }
    public DataTable LoadDiscountListLeftPannel()
    {
        try
        {
            Hashtable ht = new Hashtable();
            return this.ExecuteStoredProcedureDataTable("USP_DRP_Common_LeftPanel_DiscountList", ht);
        }
        catch
        {
            throw;
        }
    }

    public DataTable LoadAllPrintableDiscount()
    {
        try
        {
            Hashtable ht = new Hashtable();
            return this.ExecuteStoredProcedureDataTable("USP_DRP_Common_LoadAllPrintable_Discount", ht);
        }
        catch
        {
            throw;
        }
    }

    public DataTable Load_RightPanelFeaturedStores()
    {
        try
        {
            Hashtable ht = new Hashtable();
            return this.ExecuteStoredProcedureDataTable("USP_DRP_Common_RightPanel_FeaturedStores", ht);
        }
        catch
        {
            throw;
        }
    }
    public DataTable Load_RightPanelPopularCouponAndDealCategoriesCount()
    {
        try
        {
            Hashtable ht = new Hashtable();
            return this.ExecuteStoredProcedureDataTable("USP_DRP_Common_RightPanel_PopularCouponAndDealCategoriesCount", ht);
        }
        catch
        {
            throw;
        }
    }
    public DataTable Load_DiscountByCompany(DiscountZone discountZone)
    {
        try
        {
            Hashtable ht = new Hashtable();
            ht.Add("@ProfileID", discountZone.ProfileID);
            return this.ExecuteStoredProcedureDataTable("USP_DRP_Common_Load_DiscountByCompany", ht);
        }
        catch
        {
            throw;
        }

    }
    public DataTable LoadRecord_BS_SpecificDiscount(DiscountZone discountZone)
    {
        try
        {
            Hashtable ht = new Hashtable();
            ht.Add("@CouponID", discountZone.CouponID);
            ht.Add("@ProfileID", discountZone.ProfileID);
            ht.Add("@CouponCode",discountZone.CouponCode);
            return this.ExecuteStoredProcedureDataTable("USP_DRP_CP_Load_SpecificDiscount", ht);
        }
        catch
        {
            throw;
        }
    }
    public DataTable Load_DiscountByCategory(DiscountZone discountZone)
    {
        try
        {
            Hashtable ht = new Hashtable();
            ht.Add("@CategoryID", discountZone.CategoryID);
            return this.ExecuteStoredProcedureDataTable("USP_DRP_Common_Load_DiscountByCategory", ht);
        }
        catch
        {
            throw;
        }
    }
    public DataTable LoadDiscuntSoreType(DiscountZone discountZone)
    {
        try
        {
            Hashtable ht = new Hashtable();
            ht.Add("@ProfileID", discountZone.ProfileID);
            return this.ExecuteStoredProcedureDataTable("USP_DRP_Common_Load_DiscountStoreType", ht);
        }
        catch
        {
            throw;
        }
    }

    public DataTable LoadDiscuntCompany(DiscountZone discountZone)
    {
        try
        {
            Hashtable ht = new Hashtable();
            ht.Add("@ProfileID", discountZone.ProfileID);
            return this.ExecuteStoredProcedureDataTable("USP_DRP_Common_Load_DiscountAdminCompany", ht);
        }
        catch
        {
            throw;
        }
    }
    public DataTable  Load_CouponPrintingInformation(DiscountZone discountZone)
    {
        try
        {
            Hashtable ht = new Hashtable();
            ht.Add("@ProfileID", discountZone.ProfileID);
            ht.Add("@CouponID", discountZone.CouponID);
            return this.ExecuteStoredProcedureDataTable("USP_DRP_PrintCouponInformation", ht);
        }
        catch
        {
            throw;
        }
    }

    public DataTable Load_DiscountInformation(DiscountZone discountZone)
    {
        try
        {
            Hashtable ht = new Hashtable();
            ht.Add("@ProfileID", discountZone.ProfileID);
            ht.Add("@CouponID", discountZone.CouponID);
            return this.ExecuteStoredProcedureDataTable("USP_DRP_Common_Load_SpecificDiscount", ht);
        }
        catch
        {
            throw;
        }
    }

    public DataTable Load_ListComments(DiscountZone discountZone)
    {
        try
        {
            Hashtable ht = new Hashtable();
            ht.Add("@CouponID", discountZone.CouponID);
            return this.ExecuteStoredProcedureDataTable("USP_DRP_Common_LoadListComments", ht);
        }
        catch
        {
            throw;
        }
    }
    public DataTable Load_WonCouponPrintingInformation(DiscountZone discountZone)
    {
        try
        {
            Hashtable ht = new Hashtable();
            ht.Add("@ProfileID", discountZone.ProfileID);
            ht.Add("@CouponID", discountZone.CouponID);
            return this.ExecuteStoredProcedureDataTable("USP_DRP_WonPrintCouponInformation", ht);
        }
        catch
        {
            throw;
        }
    }

    public int IncrementDiscountCounter(int _ProfileID, int _CouponID)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@ProfileID", _ProfileID);
        ht.Add("@CouponID", _CouponID);
        try
        {
            return this.ExecuteNonQueryStoredProcedure("USP_DRP_Common_BS_Discount_HitCounter", ht);
        }
        catch
        {
            throw;
        }
    }


    public DataTable LoadList_DZ_Top5_Discount()
    {
        Hashtable htParams = new Hashtable();
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_DRP_Common_Top_5_Discount", htParams);
        }
        catch
        {
            throw;
        }
    }

    public DataTable LoadListRecentDiscountHomePage()
    {
        Hashtable htParams = new Hashtable();
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_DRP_HP_Common_Resent_Discount", htParams);
        }
        catch
        {
            throw;
        }
    }

}
