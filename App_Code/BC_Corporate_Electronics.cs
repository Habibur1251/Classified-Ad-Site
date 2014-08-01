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
/// Summary description for BC_Corporate_Electronics
/// </summary>
public class BC_Corporate_Electronics : DbBaseClass
{
    public BC_Corporate_Electronics()
        : base(StaticSettings.Database.DbConnectionString)
	{
		//
		// TODO: Add constructor logic here
		//
	}

    /// <summary>
    /// Loads Specific Electronics Record
    /// </summary>
    /// <param name="_ProductID"></param>
    /// <param name="_ProfileID"></param>
    /// <param name="_CategoryID"></param>
    /// <param name="_SubCategoryID"></param>
    /// <param name="_SecondSubcatID"></param>
    /// <returns></returns>
    public DataTable LoadRecord_BS_SpecificElectronics(int _ProductID, int _ProfileID, int _CategoryID, int _SubCategoryID, int _SecondSubcatID)
    {
        {
            Hashtable ht = new Hashtable();
            ht.Add("@ProductID", _ProductID);
            ht.Add("@ProfileID", _ProfileID);
            ht.Add("@CategoryID", _CategoryID);
            ht.Add("@SubcategoryID", _SubCategoryID);
            ht.Add("@SecondSubcatID", _SecondSubcatID);
            try
            {
                return this.ExecuteStoredProcedureDataTable("USP_CP_BS_SelectSpecific_Electronics", ht);
            }
            catch
            {
                throw;
            }
        }
    }

    /// Selects  Category, SUbcategory, SecondSubcat, Model ID From Latest_Posted_Electronics
    /// For Tag users.
    /// USP: USP_CP_Public_Select_Master_ElectronicsRecord
    /// </summary>
    /// <param name="categoryID"></param>
    /// <param name="subcategoryID"></param>
    /// <param name="secondSubcatID"></param>
    /// <param name="productID"></param>
    /// <returns></returns>
    public DataTable SelectSpecific_Master_ElectronicsRecord(int _CategoryID, int _SubcategoryID, int _SecondSubcatID, int _ProductID)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@CategoryID", _CategoryID);
        ht.Add("@SubcategoryID", _SubcategoryID);
        ht.Add("@SecondSubcatID", _SecondSubcatID);
        ht.Add("@ProductID", _ProductID);
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_CP_Public_Select_Master_ElectronicsRecord", ht);
        }
        catch
        {
            throw;
        }
    }
}
