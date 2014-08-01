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
/// Summary description for DiscountManegar
/// </summary>
public class DiscountManegar
{
	public DiscountManegar()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int Ad_Discount(DiscountZone discountZone)
    {
        int _ActionResult = -1;
        try
        {
            using (BC_DiscountZone bc = new BC_DiscountZone())
            {
                return bc.InsertDiscountCoupon(discountZone);
            }
        }
        catch
        {
            throw;
        }

    }

    public int Ad_Report(DiscountZone discountZone)
    {
        int _ActionResult = -1;
        try
        {
            using (BC_DiscountZone bc = new BC_DiscountZone())
            {
                return bc.InsertReport(discountZone);
            }
        }
        catch
        {
            throw;
        }

    }

    public int Ad_Comment(DiscountZone discountZone)
    {
        int _ActionResult = -1;
        try
        {
            using (BC_DiscountZone bc = new BC_DiscountZone())
            {
                return bc.InsertComment(discountZone);
            }
        }
        catch
        {
            throw;
        }

    }

    public int Update_Discount(DiscountZone discountZone)
    {
        int _ActionResult = -1;
        try
        {
            using (BC_DiscountZone bc = new BC_DiscountZone())
            {
                return bc.UpdateDiscountCoupon(discountZone);
            }
        }
        catch
        {
            throw;
        }

    }

    public int Ad_Store(DiscountZone discountZone)
    {
        int _ActionResult = -1;
        try
        {
            using (BC_DiscountZone bc = new BC_DiscountZone())
            {
                return bc.InsertDiscountStore(discountZone);
            }
        }
        catch
        {
            throw;
        }

    }

    public int UpdateDiscountStore(DiscountZone discountZone)
    {
        int _ActionResult = -1;
        try
        {
            using (BC_DiscountZone bc = new BC_DiscountZone())
            {
                return bc.UpdateDiscountStore(discountZone);
            }
        }
        catch
        {
            throw;
        }

    }

    
    public int AdSubcriptionEmailAddress(DiscountZone discountZone)
    {
        int _ActionResult = -1;
        try
        {
            using (BC_DiscountZone bc = new BC_DiscountZone())
            {
                return bc.AdSubcriptionEmailAddress(discountZone);
            }
        }
        catch
        {
            throw;
        }

    }


    public DataTable GenerateCouponCode()
    {
        int _ActionResult = -1;
        try
        {
            using (BC_DiscountZone bc = new BC_DiscountZone())
            {
                return bc.GenerateCouponCode();
            }
        }
        catch
        {
            throw;
        }

    }

    public DataTable LoadDiscountListLeftPannel()
    {
        int _ActionResult = -1;
        try
        {
            using (BC_DiscountZone bc = new BC_DiscountZone())
            {
                return bc.LoadDiscountListLeftPannel();
            }
        }
        catch
        {
            throw;
        }

    }

    public DataTable LoadAllPrintableDiscount()
    {
        int _ActionResult = -1;
        try
        {
            using (BC_DiscountZone bc = new BC_DiscountZone())
            {
                return bc.LoadAllPrintableDiscount();
            }
        }
        catch
        {
            throw;
        }

    }

    public DataTable Load_RightPanelFeaturedStores()
    {
        int _ActionResult = -1;
        try
        {
            using (BC_DiscountZone bc = new BC_DiscountZone())
            {
                return bc.Load_RightPanelFeaturedStores();
            }
        }
        catch
        {
            throw;
        }

    }

    public DataTable Load_RightPanelPopularCouponAndDealCategoriesCount()
    {
        int _ActionResult = -1;
        try
        {
            using (BC_DiscountZone bc = new BC_DiscountZone())
            {
                return bc.Load_RightPanelPopularCouponAndDealCategoriesCount();
            }
        }
        catch
        {
            throw;
        }

    }


    public DataTable Load_DiscountByCompany(DiscountZone discountZone)
    {
        int _ActionResult = -1;
        try
        {
            using (BC_DiscountZone bc = new BC_DiscountZone())
            {
                return bc.Load_DiscountByCompany(discountZone);
            }
        }
        catch
        {
            throw;
        }

    }


    public DataTable LoadRecord_BS_SpecificDiscount(DiscountZone discountZone)
    {
        int _ActionResult = -1;
        try
        {
            using (BC_DiscountZone bc = new BC_DiscountZone())
            {
                return bc.LoadRecord_BS_SpecificDiscount(discountZone);
            }
        }
        catch
        {
            throw;
        }

    }


    public DataTable Load_DiscountByCategory(DiscountZone discountZone)
    {
        int _ActionResult = -1;
        try
        {
            using (BC_DiscountZone bc = new BC_DiscountZone())
            {
                return bc.Load_DiscountByCategory(discountZone);
            }
        }
        catch
        {
            throw;
        }

    }

    public DataTable LoadDiscuntSoreType(DiscountZone discountZone)
    {
        int _ActionResult = -1;
        try
        {
            using (BC_DiscountZone bc = new BC_DiscountZone())
            {
                return bc.LoadDiscuntSoreType(discountZone);
            }
        }
        catch
        {
            throw;
        }

    }

    public DataTable LoadDiscuntCompany(DiscountZone discountZone)
    {
        int _ActionResult = -1;
        try
        {
            using (BC_DiscountZone bc = new BC_DiscountZone())
            {
                return bc.LoadDiscuntCompany(discountZone);
            }
        }
        catch
        {
            throw;
        }

    }

    public DataTable Load_CouponPrintingInformation(DiscountZone discountZone)
    {
        int _ActionResult = -1;
        try
        {
            using (BC_DiscountZone bc = new BC_DiscountZone())
            {
                return bc.Load_CouponPrintingInformation(discountZone);
            }
        }
        catch
        {
            throw;
        }

    }

    public DataTable Load_DiscountInformation(DiscountZone discountZone)
    {
        int _ActionResult = -1;
        try
        {
            using (BC_DiscountZone bc = new BC_DiscountZone())
            {
                return bc.Load_DiscountInformation(discountZone);
            }
        }
        catch
        {
            throw;
        }

    }

    public DataTable Load_ListComments(DiscountZone discountZone)
    {
        int _ActionResult = -1;
        try
        {
            using (BC_DiscountZone bc = new BC_DiscountZone())
            {
                return bc.Load_ListComments(discountZone);
            }
        }
        catch
        {
            throw;
        }

    }


    public DataTable Load_WonCouponPrintingInformation(DiscountZone discountZone)
    {
        int _ActionResult = -1;
        try
        {
            using (BC_DiscountZone bc = new BC_DiscountZone())
            {
                return bc.Load_WonCouponPrintingInformation(discountZone);
            }
        }
        catch
        {
            throw;
        }

    }

    public DataTable LoadList_DZ_Top5_Discount()
    {
        int _ActionResult = -1;
        try
        {
            using (BC_DiscountZone bc = new BC_DiscountZone())
            {
                return bc.LoadList_DZ_Top5_Discount();
            }
        }
        catch
        {
            throw;
        }

    }

    public DataTable LoadListRecentDiscountHomePage()
    {
        int _ActionResult = -1;
        try
        {
            using (BC_DiscountZone bc = new BC_DiscountZone())
            {
                return bc.LoadListRecentDiscountHomePage();
            }
        }
        catch
        {
            throw;
        }

    }





}
