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
/// Summary description for RealEstateManager
/// </summary>
public class RealEstateManager
{
	public RealEstateManager()
	{
		//
		// TODO: Add constructor logic here
		//
    }

    #region SELECT METHOD


    public RealEstate SelectRecord_RealEstate(RealEstate objRealEstate)
    {
        int _ActionResult = -1;
        RealEstate obj = new RealEstate();
        try
        {
            using (BC_RealEstate bc = new BC_RealEstate())
            {
                DataTable dt = bc.SelectRecord_RealEstate(objRealEstate);
                if (dt.Rows.Count >0)
                {
                    obj.ProductID = Convert.ToInt32( dt.Rows[0]["ProductID"]);
                    obj.ProfileID  = Convert.ToInt32( dt.Rows[0]["ProfileID"]);  
                    obj.UserType  = Convert.ToBoolean(dt.Rows[0]["UserType"]);  
                    obj.SKU  = dt.Rows[0]["SKU"].ToString();  
                    obj.CategoryID  = Convert.ToInt32(dt.Rows[0]["CategoryID"]);  
                    obj.SubcategoryID  = Convert.ToInt32(dt.Rows[0]["SubcategoryID"]);  
                    obj.SecondSubcatID  = Convert.ToInt32(dt.Rows[0]["SecondsubcatID"]);  
                    obj.SellerType  = Convert.ToInt32(dt.Rows[0]["SellerType"]);  
                    obj.SellerName  = dt.Rows[0]["SellerName"].ToString();
                    obj.ProjectName = dt.Rows[0]["ProjectName"].ToString();
                    obj.ProjectType = dt.Rows[0]["ProjectType"].ToString();  
                    obj.ProvinceID  = Convert.ToInt32(dt.Rows[0]["ProvinceID"]);  
        			                      
                    obj.AreaID  = Convert.ToInt32(dt.Rows[0]["AreaID"]);
                    obj.Area = dt.Rows[0]["Area"].ToString();
                    obj.Address = dt.Rows[0]["Address"].ToString();  
                    obj.Size  = Convert.ToDouble(dt.Rows[0]["Size"]);  
                    obj.SizeUnit  = dt.Rows[0]["SizeUnit"].ToString();
                    obj.LandNature = dt.Rows[0]["LandNature"].ToString();  
                    obj.Quantity  = Convert.ToInt32(dt.Rows[0]["Quantity"]);  
                    obj.Price  = Convert.ToDouble(dt.Rows[0]["Price"]);  
                    obj.Currency  = dt.Rows[0]["Currency"].ToString();  
                    obj.NoOfBedRoom  = dt.Rows[0]["NoOfBedRoom"].ToString();  
                    obj.NoOfWashRoom  = dt.Rows[0]["NoOfWashRoom"].ToString();  
                    obj.ServiceCharge  = Convert.ToDouble(dt.Rows[0]["ServiceCharge"]);  
                    obj.IsCarParkingAvailable  = Convert.ToBoolean( dt.Rows[0]["IsCarParkingAvailable"]);  
        			                      
                    obj.Description  = dt.Rows[0]["Description"].ToString();
                    obj.IsActive = Convert.ToBoolean( dt.Rows[0]["IsActive"]);
                    obj.IsInsideDhaka = Convert.ToBoolean( dt.Rows[0]["IsInsideDhaka"]);
                    //obj.HitCounter = dt.Rows[0]["HitCounter"];
                    obj.ProductImage = dt.Rows[0]["ProductImage"].ToString();

                    obj.IsAlternativeAddress = Convert.ToBoolean(dt.Rows[0]["IsAlternativeAddress"]);
                    obj.Source = dt.Rows[0]["Source"].ToString();

                    //obj.UpdatedOn =  dt.Rows[0]["UpdatedOn"];
                    
                    
                }
                
            }
        }
        catch
        {
            throw;
        }
        return obj;
    }

    #endregion SELECT METHOD

    #region INSERT METHODS

    /// <summary>
    /// Inserts Real Estate Product in the Database.
    /// </summary>
    /// <param name="objRealEstate"></param>
    /// <returns></returns>
    public int AddRealEstate(RealEstate objRealEstate)
    {
        int _ActionResult = -1;
        try
        {
            using (BC_RealEstate bc = new BC_RealEstate())
            {
                if (!bc.BeforeInsert_IsRealEstateTitle_Duplicate(objRealEstate))
                {
                    return bc.InsertRealEstate(objRealEstate);
                }
                else
                {
                    return -1;
                }
            }
        }
        catch
        {
            throw;
        }

    }


    #endregion INSERT METHODS


    #region UPDATE METHODS

    public int UpdateRealEstate(RealEstate objRealEstate)
    {
        int _ActionResult = -1;
        try
        {
            using (BC_RealEstate bc = new BC_RealEstate())
            {
                if (!bc.BeforeUpdate_IsRealEstateTitle_Duplicate(objRealEstate))
                {
                    return bc.UpdateRealEstate(objRealEstate);
                }
                else
                {
                    return -1;
                }
            }
        }
        catch
        {
            throw;
        }

    }
    #endregion UPDATE METHODS

    #region LOAD METHODS FOR CONTROL PANEL


    public DataTable LoadList_PostedRealEstate(RealEstate objRealEstate)
    {
        int _ActionResult = -1;
        try
        {
            using (BC_RealEstate bc = new BC_RealEstate())
            {
                return bc.LoadList_PostedRealEstate(objRealEstate);
            }
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
        try
        {
            using (BC_RealEstate bc = new BC_RealEstate())
            {
                return bc.Load_List_RealEstate_BySubcategory(objRealEstate);
            }
        }
        catch
        {
            throw;
        }

    }


    public DataTable Load_RealEstate_CLProductList_BySubcategory(RealEstate objRealEstate)
    {
        try
        {
            using (BC_RealEstate bc = new BC_RealEstate())
            {
                return bc.Load_List_RealEstate_ClassifiedSellerProduct_BySubcategory(objRealEstate);
            }
        }
        catch
        {
            throw;
        }

    }



    public DataTable LoadRecord_Detail_RealEstate(RealEstate objRealEstate)
    {
        try
        {
            using (BC_RealEstate bc = new BC_RealEstate())
            {
                return bc.LoadRecord_Detail_RealEstate(objRealEstate);
            }
        }
        catch
        {
            throw;
        }
    }


    public DataTable LoadList_RealEstate_BySecondSubcateogry(RealEstate objRealEstate)
    {
        try
        {
            using (BC_RealEstate bc = new BC_RealEstate())
            {
                return bc.LoadList_RealEstate_BySecondSubcategory(objRealEstate);
            }
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
        //int _ActionResult = -1;
        try
        {
            using (BC_RealEstate bc = new BC_RealEstate())
            {
                return bc.Load_LeftMenu_SecondSubcategory(objRealEstate);
            }
        }
        catch
        {
            throw;
        }
    }
    #endregion LOAD METHODS FOR LEFT MENU
}
