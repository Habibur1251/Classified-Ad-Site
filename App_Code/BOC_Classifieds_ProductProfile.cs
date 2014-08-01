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

public class BOC_Classifieds_ProductProfile : UTLDBHandler
{
    public BOC_Classifieds_ProductProfile(): base(UTLUtilities.Database.DbConnectionString)
	{
	}


    public int SaveRecord_Classified(
        int ProfileID,
        int intProvinceID,
        int intSubCategory,
        string strAdvertisementType,
        string ProductTitle,
        string ProductDescription,
        string strProductImage,
        string strCurrency,
        double dblSalePrice,
        int intAlternatePriceOffer,
        string DeadLine,
        DateTime dtUpdatedon, 
        int intCategoryID,
        string strSource,
        int intAreaID,
        int intInsideDhaka
        
        )
    {
        Hashtable htParams = new Hashtable();
        htParams.Add("@ProfileID", ProfileID);
        htParams.Add("@ProvinceID", intProvinceID);
        htParams.Add("@SubcategoryID", intSubCategory);
        htParams.Add("@AdvertisementType", strAdvertisementType);
        htParams.Add("@ProductTitle", ProductTitle);
        htParams.Add("@ProductDescription", ProductDescription);
        htParams.Add("@ProductImage", strProductImage);
        htParams.Add("@Currency", strCurrency);
        htParams.Add("@SalePrice", dblSalePrice);
        htParams.Add("@AlternatePriceOffer", intAlternatePriceOffer);
        htParams.Add("@Deadline", DeadLine);
        htParams.Add("@UpdatedOn", dtUpdatedon);
        htParams.Add("@CategoryID", intCategoryID);
        htParams.Add("@Source", strSource);
        htParams.Add("@AreaID", intAreaID);
        htParams.Add("@IsInsideDhaka", intInsideDhaka);

        try
        {
            int intActionResult = this.ExecuteNonQueryStoredProcedure("InsertClassified", htParams);
            return intActionResult;
        }
        catch
        {
            throw;
        }

    }

    public int UpdateRecord_Classified(
    int ProductID,
    int ProfileID,
    int intProvinceID,
    int intSubCategory,
    string strAdvertisementType,
    string ProductTitle,
    string ProductDescription,
    string strCurrency,
    double dblSalePrice,
    int intAlternatePriceOffer,
    string DeadLine,
    DateTime dtUpdatedon,
    int intCategoryID,
    string strSource,
    int intAreaID,
    int intInsideDhaka

    )
    {
        Hashtable htParams = new Hashtable();
        htParams.Add("@ProductID", ProductID);
        htParams.Add("@ProfileID", ProfileID);
        htParams.Add("@ProvinceID", intProvinceID);
        htParams.Add("@SubcategoryID", intSubCategory);
        htParams.Add("@AdvertisementType", strAdvertisementType);
        htParams.Add("@ProductTitle", ProductTitle);
        htParams.Add("@ProductDescription", ProductDescription);
        htParams.Add("@Currency", strCurrency);
        htParams.Add("@SalePrice", dblSalePrice);
        htParams.Add("@AlternatePriceOffer", intAlternatePriceOffer);
        htParams.Add("@Deadline", DeadLine);
        htParams.Add("@UpdatedOn", dtUpdatedon);
        htParams.Add("@CategoryID", intCategoryID);
        htParams.Add("@Source", strSource);
        htParams.Add("@AreaID", intAreaID);
        htParams.Add("@IsInsideDhaka", intInsideDhaka);

        try
        {
            int intActionResult = this.ExecuteNonQueryStoredProcedure("UpdateClassified", htParams);
            return intActionResult;
        }
        catch
        {
            throw;
        }

    }


    public DataTable LoadRecord_ClassifiedCategory(EOC_PropertyBean eocPropertyBean)
    {
        try
        {
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@CountryID", eocPropertyBean.Country_CountryID.ToString()));
            return this.ExecuteQuery("USP_CL_ProdProf_LoadClassifiedCategory", arlSQLParameters);
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Loads Subcategory.
    /// </summary>
    /// <param name="eocPropertyBean"></param>
    /// <returns></returns>
    public DataTable LoadRecord_ClassifiedSubCategory(EOC_PropertyBean eocPropertyBean)
    {
        try
        {
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@CategoryID", eocPropertyBean.Category_CategoryID.ToString()));
            return this.ExecuteQuery("USP_CL_Public_LoadSubcategory", arlSQLParameters);
        }
        catch
        {
            throw;
        }
    }

    public DataTable Load_CategoryID(EOC_PropertyBean eocPropertyBean)
    {
        try
        {
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@SubcategoryID", eocPropertyBean.Subcategory_SubcategoryID.ToString()));

            return this.ExecuteQuery("USP_CL_ProdProf_GetCategoryID", arlSQLParameters);
        }
        catch
        {
            throw;
        }
    }


    /// <summary>
    /// Loads all Province
    /// USP: USP_CL_ProdProf_LoadProvince
    /// </summary>
    /// <param name="eocPropertyBean"></param>
    /// <returns></returns>
    public DataTable LoadRecord_Province(EOC_PropertyBean eocPropertyBean)
    {
        try
        {
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@CountryID", eocPropertyBean.Country_CountryID.ToString()));
            return this.ExecuteQuery("USP_CL_ProdProf_LoadProvince", arlSQLParameters);
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Loads Classified Posted Product
    /// </summary>
    /// <param name="eocPropertyBean"></param>
    /// <returns></returns>
    public DataTable LoadRecord_ProductProfile(EOC_PropertyBean eocPropertyBean)
    {
        try
        {
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@ProfileID", eocPropertyBean.Classifieds_UserProfile_ProfileID.ToString()));
            arlSQLParameters.Add(new SqlParameter("@StartDate", eocPropertyBean.FromDate.ToString()));
            arlSQLParameters.Add(new SqlParameter("@EndDate", eocPropertyBean.ToDate.ToString()));
            return this.ExecuteQuery("USP_CL_ProdProf_LoadProductProfile", arlSQLParameters);
        }
        catch
        {
            throw;
        }
    }

    public DataTable LoadRecord_AllProductProfile(EOC_PropertyBean eocPropertyBean)
    {
        try
        {
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@ProfileID", eocPropertyBean.Classifieds_UserProfile_ProfileID.ToString()));
            return this.ExecuteQuery("USP_CL_ProdProf_LoadAllProductProfile", arlSQLParameters);
        }
        catch
        {
            throw;
        }
    }

    public DataTable LoadRecord_OrderDetails(EOC_PropertyBean eocPropertyBean)
    {
        try
        {
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@ProductID", eocPropertyBean.Classifieds_ProductProfile_ProductID.ToString()));
            arlSQLParameters.Add(new SqlParameter("@ProfileID", eocPropertyBean.Classifieds_UserProfile_ProfileID.ToString()));

            return this.ExecuteQuery("USP_CL_ProdProf_SelectOrderDetails", arlSQLParameters);
        }
        catch
        {
            throw;
        }
    }    

    /// <summary>
    /// Loads Classified Product record.
    /// </summary>
    /// <param name="eocPropertyBean"></param>
    /// <returns></returns>
    public bool SelectRecord_ProductProfile(EOC_PropertyBean eocPropertyBean)
    {
        bool blnFlag = false;

        try
        {
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@ProductID", eocPropertyBean.Classifieds_ProductProfile_ProductID.ToString()));
            DataTable objDataTable = this.ExecuteQuery("USP_CL_ProdProf_SelectSpecificRecord", arlSQLParameters);

            if (objDataTable.Rows.Count > 0)
            {
                blnFlag = true;

                eocPropertyBean.Province_ProvinceID = Convert.ToInt32(objDataTable.Rows[0]["ProvinceID"].ToString());
                eocPropertyBean.Area_AreaID = Convert.ToInt32(objDataTable.Rows[0]["AreaID"].ToString());
                eocPropertyBean.Classifieds_ProductProfile_IsInsideDhaka = Convert.ToBoolean(objDataTable.Rows[0]["IsInsideDhaka"].ToString());

                eocPropertyBean.Category_CategoryID = Convert.ToInt32(objDataTable.Rows[0]["CategoryID"].ToString());
                eocPropertyBean.Subcategory_SubcategoryID = Convert.ToInt32(objDataTable.Rows[0]["SubcategoryID"].ToString());

                eocPropertyBean.Classifieds_ProductProfile_AdvertisementType = objDataTable.Rows[0]["AdvertisementType"].ToString();
                eocPropertyBean.Classifieds_ProductProfile_ProductTitle = objDataTable.Rows[0]["ProductTitle"].ToString();
                eocPropertyBean.Classifieds_ProductProfile_ProductDescription = objDataTable.Rows[0]["ProductDescription"].ToString();
                eocPropertyBean.Classifieds_ProductProfile_ProductImage = objDataTable.Rows[0]["ProductImage"].ToString();
                eocPropertyBean.Classifieds_ProductProfile_Currency = objDataTable.Rows[0]["Currency"].ToString();
                eocPropertyBean.Classifieds_ProductProfile_SalePrice = Convert.ToDouble(objDataTable.Rows[0]["SalePrice"].ToString());
                eocPropertyBean.Classifieds_ProductProfile_AlternatePriceOffer = Convert.ToInt32(objDataTable.Rows[0]["AlternatePriceOffer"].ToString());
                
                //eocPropertyBean.Classifieds_ProductProfile_Deadline = Convert.ToDateTime(objDataTable.Rows[0]["Deadline"].ToString());

                eocPropertyBean.Classifieds_ProductProfile_Deadline = objDataTable.Rows[0]["Deadline"].ToString();

                eocPropertyBean.Classifieds_ProductProfile_Source = objDataTable.Rows[0]["Source"].ToString();
            }
            else
            {
                blnFlag = false;
            }
        }
        catch
        {
            throw;
        }

        return blnFlag;
    }



    /// <summary>
    /// Loads Classified Product record for Boromela User.
    /// </summary>
    /// <param name="eocPropertyBean"></param>
    /// <returns></returns>
    public bool SelectRecord_ProductProfile_For_Admin(EOC_PropertyBean eocPropertyBean)
    {
        bool blnFlag = false;

        try
        {
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@ProductID", eocPropertyBean.Classifieds_ProductProfile_ProductID.ToString()));
            DataTable objDataTable = this.ExecuteQuery("USP_CL_ProdProf_SelectSpecificRecord_For_Admin", arlSQLParameters);

            if (objDataTable.Rows.Count > 0)
            {
                blnFlag = true;

                eocPropertyBean.Province_ProvinceID = Convert.ToInt32(objDataTable.Rows[0]["ProvinceID"].ToString());
                eocPropertyBean.Area_AreaID = Convert.ToInt32(objDataTable.Rows[0]["AreaID"].ToString());
                eocPropertyBean.Classifieds_ProductProfile_IsInsideDhaka = Convert.ToBoolean(objDataTable.Rows[0]["IsInsideDhaka"].ToString());

                eocPropertyBean.Category_CategoryID = Convert.ToInt32(objDataTable.Rows[0]["CategoryID"].ToString());
                eocPropertyBean.Subcategory_SubcategoryID = Convert.ToInt32(objDataTable.Rows[0]["SubcategoryID"].ToString());

                eocPropertyBean.Classifieds_ProductProfile_AdvertisementType = objDataTable.Rows[0]["AdvertisementType"].ToString();
                eocPropertyBean.Classifieds_ProductProfile_ProductTitle = objDataTable.Rows[0]["ProductTitle"].ToString();
                eocPropertyBean.Classifieds_ProductProfile_ProductDescription = objDataTable.Rows[0]["ProductDescription"].ToString();
                eocPropertyBean.Classifieds_ProductProfile_ProductImage = objDataTable.Rows[0]["ProductImage"].ToString();
                eocPropertyBean.Classifieds_ProductProfile_Currency = objDataTable.Rows[0]["Currency"].ToString();
                eocPropertyBean.Classifieds_ProductProfile_SalePrice = Convert.ToDouble(objDataTable.Rows[0]["SalePrice"].ToString());
                eocPropertyBean.Classifieds_ProductProfile_AlternatePriceOffer = Convert.ToInt32(objDataTable.Rows[0]["AlternatePriceOffer"].ToString());
                
                //eocPropertyBean.Classifieds_ProductProfile_Deadline = Convert.ToDateTime(objDataTable.Rows[0]["Deadline"].ToString());

                eocPropertyBean.Classifieds_ProductProfile_Deadline = objDataTable.Rows[0]["Deadline"].ToString();

                eocPropertyBean.Classifieds_ProductProfile_Source = objDataTable.Rows[0]["Source"].ToString();

                eocPropertyBean.Is_Alternative_Address = Convert.ToBoolean(objDataTable.Rows[0]["IsAlternativeAddress"]);
                if (eocPropertyBean.Is_Alternative_Address)
                {
                    if (objDataTable.Rows[0]["AlternativeAddress"] != null)
                    {
                        eocPropertyBean.Classifieds_Seller_Address = objDataTable.Rows[0]["AlternativeAddress"].ToString();
                    }

                    if (objDataTable.Rows[0]["SellerName"] != null)
                    {
                        eocPropertyBean.Classifieds_Seller_Name = objDataTable.Rows[0]["SellerName"].ToString();
                    }

                    if (objDataTable.Rows[0]["Mobile"] != null)
                    {
                        eocPropertyBean.Classifieds_Seller_Mobile = objDataTable.Rows[0]["Mobile"].ToString();
                    }
                    
                    eocPropertyBean.Classifieds_Seller_StateID = Convert.ToInt32(objDataTable.Rows[0]["StateID"]);
                    eocPropertyBean.Classifieds_Seller_ProvinceID = Convert.ToInt32(objDataTable.Rows[0]["AddressProvinceID"]);
                    eocPropertyBean.AlternativeAddressID = Convert.ToInt32(objDataTable.Rows[0]["AlternativeAddressID"]);
                }
            }
            else
            {
                blnFlag = false;
            }
        }
        catch
        {
            throw;
        }

        return blnFlag;
    }

    /// <summary>
    /// Inserts Classified Products into Database.
    /// USP: USP_CL_ProdProf_InserRecord
    /// </summary>
    /// <param name="eocPropertyBean"></param>
    /// <returns></returns>
    /// 
    public int Check_Duplicate(EOC_PropertyBean eocPropertyBean)
    {
        int intActionResult = 0;

        try
        {
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@ProfileID", eocPropertyBean.Classifieds_UserProfile_ProfileID.ToString()));
            //arlSQLParameters.Add(new SqlParameter("@CategoryID", eocPropertyBean.Category_CategoryID.ToString()));
            arlSQLParameters.Add(new SqlParameter("@SubcategoryID", eocPropertyBean.Subcategory_SubcategoryID.ToString()));
            arlSQLParameters.Add(new SqlParameter("@ProductTitle", eocPropertyBean.Classifieds_ProductProfile_ProductTitle));

            if (this.ExecuteQuery("USP_CL_ProdProf_BeforeInsert_IsAdDuplicate", arlSQLParameters).Rows.Count == 0)
            {
                
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

    public int AddRecord_ProductProfile(EOC_PropertyBean eocPropertyBean)
    {
        int intActionResult = 0;

        try
        {
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@ProfileID", eocPropertyBean.Classifieds_UserProfile_ProfileID.ToString()));
            //arlSQLParameters.Add(new SqlParameter("@CategoryID", eocPropertyBean.Category_CategoryID.ToString()));
            arlSQLParameters.Add(new SqlParameter("@SubcategoryID", eocPropertyBean.Subcategory_SubcategoryID.ToString()));
            arlSQLParameters.Add(new SqlParameter("@ProductTitle", eocPropertyBean.Classifieds_ProductProfile_ProductTitle));

            if (this.ExecuteQuery("USP_CL_ProdProf_BeforeInsert_IsAdDuplicate", arlSQLParameters).Rows.Count == 0)
            {
                arlSQLParameters.Clear();

                arlSQLParameters.Add(new SqlParameter("@ProfileID", eocPropertyBean.Classifieds_UserProfile_ProfileID.ToString()));
                arlSQLParameters.Add(new SqlParameter("@ProvinceID", eocPropertyBean.Province_ProvinceID.ToString()));
                arlSQLParameters.Add(new SqlParameter("@SubcategoryID", eocPropertyBean.Subcategory_SubcategoryID.ToString()));
                arlSQLParameters.Add(new SqlParameter("@AdvertisementType", eocPropertyBean.Classifieds_ProductProfile_AdvertisementType));
                arlSQLParameters.Add(new SqlParameter("@ProductTitle", eocPropertyBean.Classifieds_ProductProfile_ProductTitle));
                arlSQLParameters.Add(new SqlParameter("@ProductDescription", eocPropertyBean.Classifieds_ProductProfile_ProductDescription));
                arlSQLParameters.Add(new SqlParameter("@ProductImage", eocPropertyBean.Classifieds_ProductProfile_ProductImage));
                arlSQLParameters.Add(new SqlParameter("@Currency", eocPropertyBean.Classifieds_ProductProfile_Currency));
                arlSQLParameters.Add(new SqlParameter("@SalePrice", eocPropertyBean.Classifieds_ProductProfile_SalePrice));
                arlSQLParameters.Add(new SqlParameter("@AlternatePriceOffer", eocPropertyBean.Classifieds_ProductProfile_AlternatePriceOffer.ToString()));
                arlSQLParameters.Add(new SqlParameter("@Deadline", eocPropertyBean.Classifieds_ProductProfile_Deadline.ToString()));
                arlSQLParameters.Add(new SqlParameter("@UpdatedOn", eocPropertyBean.UpdatedOn.ToString()));
                arlSQLParameters.Add(new SqlParameter("@CategoryID", eocPropertyBean.Category_CategoryID.ToString()));
                arlSQLParameters.Add(new SqlParameter("@Source", eocPropertyBean.Classifieds_ProductProfile_Source));
                arlSQLParameters.Add(new SqlParameter("@AreaID", eocPropertyBean.Area_AreaID.ToString()));
                arlSQLParameters.Add(new SqlParameter("@IsInsideDhaka", eocPropertyBean.Classifieds_ProductProfile_IsInsideDhaka.ToString()));

                intActionResult = this.ExecuteActionQuery("USP_CL_ProdProf_InserRecord", arlSQLParameters);
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

    /// <summary>
    /// Inserts New Product for boromela user.
    /// USP: USP_CL_ProdProf_Admin_InsertRecord
    /// </summary>
    /// <param name="eocPropertyBean"></param>
    /// <returns></returns>
    public int AddRecord_ProductProfile_For_Admin(EOC_PropertyBean eocPropertyBean)
    {
        int intActionResult = 0;

        try
        {
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@ProfileID", eocPropertyBean.Classifieds_UserProfile_ProfileID.ToString()));
            //arlSQLParameters.Add(new SqlParameter("@CategoryID", eocPropertyBean.Category_CategoryID.ToString()));
            arlSQLParameters.Add(new SqlParameter("@SubcategoryID", eocPropertyBean.Subcategory_SubcategoryID.ToString()));
            arlSQLParameters.Add(new SqlParameter("@ProductTitle", eocPropertyBean.Classifieds_ProductProfile_ProductTitle));

            if (this.ExecuteQuery("USP_CL_ProdProf_BeforeInsert_IsAdDuplicate", arlSQLParameters).Rows.Count == 0)
            {
                arlSQLParameters.Clear();
                arlSQLParameters.Add(new SqlParameter("@ProfileID", eocPropertyBean.Classifieds_UserProfile_ProfileID.ToString()));
                arlSQLParameters.Add(new SqlParameter("@IsInsideDhaka", eocPropertyBean.Classifieds_ProductProfile_IsInsideDhaka.ToString()));
                arlSQLParameters.Add(new SqlParameter("@AreaID", eocPropertyBean.Area_AreaID.ToString()));
                arlSQLParameters.Add(new SqlParameter("@ProvinceID", eocPropertyBean.Province_ProvinceID.ToString()));
                arlSQLParameters.Add(new SqlParameter("@CategoryID", eocPropertyBean.Category_CategoryID.ToString()));
                arlSQLParameters.Add(new SqlParameter("@SubcategoryID", eocPropertyBean.Subcategory_SubcategoryID.ToString()));
                arlSQLParameters.Add(new SqlParameter("@AdvertisementType", eocPropertyBean.Classifieds_ProductProfile_AdvertisementType));
                arlSQLParameters.Add(new SqlParameter("@ProductTitle", eocPropertyBean.Classifieds_ProductProfile_ProductTitle));
                arlSQLParameters.Add(new SqlParameter("@ProductDescription", eocPropertyBean.Classifieds_ProductProfile_ProductDescription));
                arlSQLParameters.Add(new SqlParameter("@ProductImage", eocPropertyBean.Classifieds_ProductProfile_ProductImage));
                arlSQLParameters.Add(new SqlParameter("@Currency", eocPropertyBean.Classifieds_ProductProfile_Currency));
                arlSQLParameters.Add(new SqlParameter("@SalePrice", eocPropertyBean.Classifieds_ProductProfile_SalePrice));
                arlSQLParameters.Add(new SqlParameter("@AlternatePriceOffer", eocPropertyBean.Classifieds_ProductProfile_AlternatePriceOffer.ToString()));
                arlSQLParameters.Add(new SqlParameter("@Deadline", eocPropertyBean.Classifieds_ProductProfile_Deadline.ToString()));
                arlSQLParameters.Add(new SqlParameter("@UpdatedOn", eocPropertyBean.UpdatedOn.ToString()));
                arlSQLParameters.Add(new SqlParameter("@Source", eocPropertyBean.Classifieds_ProductProfile_Source));


                arlSQLParameters.Add(new SqlParameter("@IsAlternativeAddress", eocPropertyBean.Is_Alternative_Address));
                arlSQLParameters.Add(new SqlParameter("@AlternativeAddress", eocPropertyBean.Classifieds_Seller_Address));
                arlSQLParameters.Add(new SqlParameter("@AddressProvinceID", eocPropertyBean.Classifieds_Seller_ProvinceID));
                arlSQLParameters.Add(new SqlParameter("@StateID", eocPropertyBean.Classifieds_Seller_StateID));
                arlSQLParameters.Add(new SqlParameter("@SellerName", eocPropertyBean.Classifieds_Seller_Name));
                arlSQLParameters.Add(new SqlParameter("@Mobile", eocPropertyBean.Classifieds_Seller_Mobile));

                intActionResult = this.ExecuteActionQuery("USP_CL_ProdProf_Admin_InsertRecord", arlSQLParameters);
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

    public int UpdateRecord_ProductImage(EOC_PropertyBean eocPropertyBean)
    {
        int intActionResult = 0;

        try
        {
            ArrayList arlSQLParameters = new ArrayList();
            arlSQLParameters.Add(new SqlParameter("@ProductImage", eocPropertyBean.Classifieds_ProductProfile_ProductImage));
            arlSQLParameters.Add(new SqlParameter("@ProductID", eocPropertyBean.Classifieds_ProductProfile_ProductID.ToString()));

            intActionResult = this.ExecuteActionQuery("USP_CL_ProdProf_UpdateRecord_ImageInfo", arlSQLParameters);
        }
        catch
        {
            throw;
        }

        return intActionResult;
    }

    /// <summary>
    /// Updates Classified Product Records
    /// USP: USP_CL_ProdPro_UpdateRecord
    /// </summary>
    /// <param name="eocPropertyBean"></param>
    /// 
    /// <returns>int</returns>
    public int UpdateRecord_ProductProfile(EOC_PropertyBean eocPropertyBean)
    {
        int intActionResult = 0;

        try
        {
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@ProductID", eocPropertyBean.Classifieds_ProductProfile_ProductID.ToString()));
            arlSQLParameters.Add(new SqlParameter("@ProfileID", eocPropertyBean.Classifieds_UserProfile_ProfileID.ToString()));
            //arlSQLParameters.Add(new SqlParameter("@CategoryID", eocPropertyBean.Category_CategoryID.ToString()));
            arlSQLParameters.Add(new SqlParameter("@SubcategoryID", eocPropertyBean.Subcategory_SubcategoryID.ToString()));
            arlSQLParameters.Add(new SqlParameter("@ProductTitle", eocPropertyBean.Classifieds_ProductProfile_ProductTitle));

            if (this.ExecuteQuery("USP_CL_ProdProf_BeforeUpdate_IsAdDuplicate", arlSQLParameters).Rows.Count == 0)
            {
                arlSQLParameters.Clear();


                arlSQLParameters.Add(new SqlParameter("@ProductID", eocPropertyBean.Classifieds_ProductProfile_ProductID.ToString()));
                arlSQLParameters.Add(new SqlParameter("@ProfileID", eocPropertyBean.Classifieds_UserProfile_ProfileID.ToString()));
               
                arlSQLParameters.Add(new SqlParameter("@ProvinceID", eocPropertyBean.Province_ProvinceID.ToString()));
                arlSQLParameters.Add(new SqlParameter("@SubcategoryID", eocPropertyBean.Subcategory_SubcategoryID.ToString()));
                arlSQLParameters.Add(new SqlParameter("@AdvertisementType", eocPropertyBean.Classifieds_ProductProfile_AdvertisementType));
                arlSQLParameters.Add(new SqlParameter("@ProductTitle", eocPropertyBean.Classifieds_ProductProfile_ProductTitle));
                arlSQLParameters.Add(new SqlParameter("@ProductDescription", eocPropertyBean.Classifieds_ProductProfile_ProductDescription));
                arlSQLParameters.Add(new SqlParameter("@Currency", eocPropertyBean.Classifieds_ProductProfile_Currency));
                arlSQLParameters.Add(new SqlParameter("@SalePrice", eocPropertyBean.Classifieds_ProductProfile_SalePrice));
                arlSQLParameters.Add(new SqlParameter("@AlternatePriceOffer", eocPropertyBean.Classifieds_ProductProfile_AlternatePriceOffer.ToString()));
                arlSQLParameters.Add(new SqlParameter("@Deadline", eocPropertyBean.Classifieds_ProductProfile_Deadline.ToString()));
                arlSQLParameters.Add(new SqlParameter("@UpdatedOn", eocPropertyBean.UpdatedOn.ToString()));
                arlSQLParameters.Add(new SqlParameter("@CategoryID", eocPropertyBean.Category_CategoryID.ToString()));
                arlSQLParameters.Add(new SqlParameter("@Source", eocPropertyBean.Classifieds_ProductProfile_Source));
                arlSQLParameters.Add(new SqlParameter("@AreaID", eocPropertyBean.Area_AreaID.ToString()));
                arlSQLParameters.Add(new SqlParameter("@IsInsideDhaka", eocPropertyBean.Classifieds_ProductProfile_IsInsideDhaka.ToString()));

               // arlSQLParameters.Add(new SqlParameter("@IsAlternativeAddress", eocPropertyBean.Is_Alternative_Address));


                intActionResult = this.ExecuteActionQuery("USP_CL_ProdPro_UpdateRecord", arlSQLParameters);
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



    /// <summary>
    /// Updates Classified Product Records. Special Methods for boromela user.
    /// USP: USP_CL_ProdPro_UpdateRecord_For_Admin
    /// </summary>
    /// <param name="eocPropertyBean"></param>
    /// <returns></returns>
    public int UpdateRecord_ProductProfile_For_Admin(EOC_PropertyBean eocPropertyBean)
    {
        int intActionResult = 0;

        try
        {
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@ProductID", eocPropertyBean.Classifieds_ProductProfile_ProductID.ToString()));
            arlSQLParameters.Add(new SqlParameter("@ProfileID", eocPropertyBean.Classifieds_UserProfile_ProfileID.ToString()));
            //arlSQLParameters.Add(new SqlParameter("@CategoryID", eocPropertyBean.Category_CategoryID.ToString()));
            arlSQLParameters.Add(new SqlParameter("@SubcategoryID", eocPropertyBean.Subcategory_SubcategoryID.ToString()));
            arlSQLParameters.Add(new SqlParameter("@ProductTitle", eocPropertyBean.Classifieds_ProductProfile_ProductTitle));

            if (this.ExecuteQuery("USP_CL_ProdProf_BeforeUpdate_IsAdDuplicate", arlSQLParameters).Rows.Count == 0)
            {
                arlSQLParameters.Clear();

                arlSQLParameters.Add(new SqlParameter("@ProductID", eocPropertyBean.Classifieds_ProductProfile_ProductID.ToString()));
                arlSQLParameters.Add(new SqlParameter("@ProfileID", eocPropertyBean.Classifieds_UserProfile_ProfileID.ToString()));
                arlSQLParameters.Add(new SqlParameter("@ProvinceID", eocPropertyBean.Province_ProvinceID.ToString()));
                arlSQLParameters.Add(new SqlParameter("@AreaID", eocPropertyBean.Area_AreaID.ToString()));
                arlSQLParameters.Add(new SqlParameter("@IsInsideDhaka", eocPropertyBean.Classifieds_ProductProfile_IsInsideDhaka.ToString()));

                arlSQLParameters.Add(new SqlParameter("@CategoryID", eocPropertyBean.Category_CategoryID.ToString()));
                arlSQLParameters.Add(new SqlParameter("@SubcategoryID", eocPropertyBean.Subcategory_SubcategoryID.ToString()));
                arlSQLParameters.Add(new SqlParameter("@AdvertisementType", eocPropertyBean.Classifieds_ProductProfile_AdvertisementType));
                arlSQLParameters.Add(new SqlParameter("@ProductTitle", eocPropertyBean.Classifieds_ProductProfile_ProductTitle));
                arlSQLParameters.Add(new SqlParameter("@ProductDescription", eocPropertyBean.Classifieds_ProductProfile_ProductDescription));
                //arlSQLParameters.Add(new SqlParameter("@ProductImage", eocPropertyBean.Classifieds_ProductProfile_ProductImage));
                arlSQLParameters.Add(new SqlParameter("@Currency", eocPropertyBean.Classifieds_ProductProfile_Currency));
                arlSQLParameters.Add(new SqlParameter("@SalePrice", eocPropertyBean.Classifieds_ProductProfile_SalePrice));
                arlSQLParameters.Add(new SqlParameter("@AlternatePriceOffer", eocPropertyBean.Classifieds_ProductProfile_AlternatePriceOffer.ToString()));
                arlSQLParameters.Add(new SqlParameter("@Deadline", eocPropertyBean.Classifieds_ProductProfile_Deadline.ToString()));
                arlSQLParameters.Add(new SqlParameter("@UpdatedOn", eocPropertyBean.UpdatedOn.ToString()));
                arlSQLParameters.Add(new SqlParameter("@Source", eocPropertyBean.Classifieds_ProductProfile_Source));



                arlSQLParameters.Add(new SqlParameter("@IsAlternativeAddress", eocPropertyBean.Is_Alternative_Address));
                arlSQLParameters.Add(new SqlParameter("@AlternativeAddress", eocPropertyBean.Classifieds_Seller_Address));
                arlSQLParameters.Add(new SqlParameter("@AddressProvinceID", eocPropertyBean.Classifieds_Seller_ProvinceID));
                arlSQLParameters.Add(new SqlParameter("@StateID", eocPropertyBean.Classifieds_Seller_StateID));
                arlSQLParameters.Add(new SqlParameter("@SellerName", eocPropertyBean.Classifieds_Seller_Name));
                arlSQLParameters.Add(new SqlParameter("@Mobile", eocPropertyBean.Classifieds_Seller_Mobile));

                intActionResult = this.ExecuteActionQuery("USP_CL_ProdPro_UpdateRecord_For_Admin", arlSQLParameters);
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





    
}
