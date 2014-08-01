using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.Common;
using System.Collections;

/// <summary>
/// Summary description for ShoppingCartAccess
/// </summary>
public class ShoppingCartAccess : DbBaseClass
{
	
    public ShoppingCartAccess() : base(StaticSettings.Database.DbConnectionString)
    {
    //
    // TODO: Add constructor logic here
    //
    }
    // returns the shopping cart ID for the current user
    private static string shoppingCartId
    {
        get
        {
            // get the current HttpContext
            HttpContext context = HttpContext.Current;
            // try to retrieve the cart ID from the user session object
            string cartId = "";
            object cartIdSession = context.Session["BalloonShop_CartID"];
            if (cartIdSession != null)
            {
                cartId = cartIdSession.ToString();
            }
            // if the ID exists in the current session...
            if (cartId != "")
            {
                // return its value
                return cartId;
            }
            else
            // if the cart ID isn't in the session...
            {
                // check if the cart ID exists as a cookie
                if (context.Request.Cookies["BalloonShop_CartID"] != null)
                {
                    // if the cart exists as a cookie, use the cookie to get its value
                    cartId = context.Request.Cookies["BalloonShop_CartID"].Value;
                    // save the id to the session, to avoid reading the cookie next time
                    context.Session["BalloonShop_CartID"] = cartId;
                    // return the id
                    return cartId;
                }
                else
                // if the cart ID doesn't exist in the cookie as well,
                //generate a new ID
                {
                    // generate a new GUID
                    cartId = Guid.NewGuid().ToString();
                    // create the cookie object and set its value
                    HttpCookie cookie = new HttpCookie("BalloonShop_CartID",
                    cartId.ToString());
                    // set the cookie's expiration date
                    int howManyDays = ShopConfiguration.CartPersistDays;
                    DateTime currentDate = DateTime.Now;
                    TimeSpan timeSpan = new TimeSpan(howManyDays, 0, 0, 0);
                    DateTime expirationDate = currentDate.Add(timeSpan);
                    cookie.Expires = expirationDate;
                    // set the cookie on the client's browser
                    context.Response.Cookies.Add(cookie);
                    // save the ID to the Session as well
                    context.Session["BalloonShop_CartID"] = cartId;
                    // return the CartID
                    return cartId.ToString();
                }
            }
        }
    }

    /// <summary>
    /// Adds a item in the Shopping Cart
    /// USP: USP_ShoppingCart_AddItem
    /// </summary>
    /// <param name="productId"></param>
    /// <param name="profileID"></param>
    /// <param name="sellerType"></param>
    /// <returns></returns>
    public bool ShoppingCart_AddItem(string strProductSellerDetailID, int intProductID, int intCategoryID)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@CartID", shoppingCartId );
        ht.Add("@ProductID", intProductID);
        ht.Add("@ProductSellerDetailID", strProductSellerDetailID);
        ht.Add("@CategoryID", intCategoryID);
        try
        {
            int intActionResult = ExecuteNonQueryStoredProcedure("USP_ShoppingCart_AddItem", ht);
            return (intActionResult > 0 ? true : false);
        }
        catch
        {
            throw;
        }
    }


    /// <summary>
    /// Updates item quantity in the shopping cart.
    /// USO: USP_ShoppingCart_UpdateItem
    /// </summary>
    /// <param name="productId"></param>
    /// <param name="profileID"></param>
    /// <param name="sellerType"></param>
    /// <param name="qty"></param>
    /// <returns></returns>
    public bool ShoppingCart_UpdateItem(int intCategoryID, int intProductID, int intProductSellerDetailID, int qty)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@CartID", shoppingCartId);
        ht.Add("@CategoryID", intCategoryID);
        ht.Add("@ProductID", intProductID);
        ht.Add("@ProductSellerDetailID", intProductSellerDetailID);
        ht.Add("@Quantity", qty);
        try
        {
            int intActionResult = ExecuteNonQueryStoredProcedure("USP_ShoppingCart_UpdateItem", ht);
            return (intActionResult > 0 ? true : false);
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Removes an item from the ShoppingCart.
    /// USP: USP_ShoppingCart_RemoveItem
    /// </summary>
    /// <param name="productId"></param>
    /// <param name="profileID"></param>
    /// <param name="sellerType"></param>
    /// <returns></returns>
    public bool ShoppingCart_RemoveItem(int intCategoryID, int intProductID, int intProductSellerDetailId)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@CartID", shoppingCartId);
        ht.Add("@CategoryID", intCategoryID);
        ht.Add("@ProductID", intProductID);
        ht.Add("@ProductSellerDetailId", intProductSellerDetailId);
        try
        {
            int intActionResult = ExecuteNonQueryStoredProcedure("USP_ShoppingCart_RemoveItem", ht);
            return (intActionResult > 0 ? true : false);
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Gets the total list of items stored in the cart.
    /// USP: USP_ShoppingCart_GetItems
    /// </summary>
    /// <returns></returns>
    public DataTable LoadList_ShoppingCartItems()
    {
        Hashtable ht = new Hashtable();
        ht.Add("@CartID", shoppingCartId );
        try
        {
            return ExecuteStoredProcedureDataTable("USP_ShoppingCart_GetItems", ht);
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Retrieve total value and currency for shopping cart items.
    /// USP: USP_ShoppingCart_GetTotalAmount
    /// </summary>
    /// <returns></returns>
    public DataTable ShoppingCart_GetTotalAmount()
    {
        Hashtable ht = new Hashtable();
        ht.Add("@CartID", shoppingCartId);
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_ShoppingCart_GetTotalAmount", ht);
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Creates an Order in the Orders and OrderDetail table.
    /// USP: USP_ShoppingCart_CreateOrder
    /// </summary>
    /// <returns></returns>
    public string ShoppingCart_CreateOrder()
    {
        Hashtable ht = new Hashtable();
        ht.Add("@CartID", shoppingCartId);
        //ht.Add("@PaymentOption", strPaymentOption);
        try
        {
            return this.ExecuteStoredProcedureScalar("USP_ShoppingCart_CreateOrder", ht).ToString();
        }
        catch
        {
            throw;
        }

    }

    /// <summary>
    /// Loads all the Ordered items From the OrderDetail Table.
    /// USP: USP_ShoppingCart_LoadList_OrderedItems
    /// </summary>
    /// <param name="intOrderedID"></param>
    /// <returns></returns>
    public DataTable LoadList_Ordered_Items(int intOrderID)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@OrderID", intOrderID);
        try
        {
            return this.ExecuteStoredProcedureDataTable("USP_ShoppingCart_LoadList_OrderedItems", ht);
        }
        catch
        {
            throw;
        }
    }


    /// <summary>
    /// Inserts Shipping Address for placing Orders.
    /// Returns a bool indicating if the verification entry in database is successful.
    /// USP: USP_ShoppingCart_Insert_ShippingAddress
    /// </summary>
    /// <param name="intOrderID"></param>
    /// <param name="strCustomerName"></param>
    /// <param name="strCustomerEmail"></param>
    /// <param name="strShippingAddress"></param>
    /// <param name="strBillingAddress"></param>
    /// <returns></returns>
    public bool Insert_ShippingAddress
        (
        int intOrderID,

        string _Shipping_UserName,
        string _Shipping_UserAddress,
        string _Shipping_UserDivision,
        string _Shipping_UserDistrict,

        string _Shipping_UserCountry,
        string _Shipping_UserCellNo,
        string _Shipping_UserUrl,
        string _Shipping_UserEmail,

        string _Billing_UserName,
        string _Billing_UserAddress,
        string _Billing_UserDivision,
        string _Billing_UserDistrict,

        string _Billing_UserCountry,
        string _Billing_UserCellNo,
        string _Billing_UserUrl,
        string _Billing_UserEmail
        )
    {
        Hashtable ht = new Hashtable();
        ht.Add("@OrderID", intOrderID);

        ht.Add("@Shipping_UserName", _Shipping_UserName);
        ht.Add("@Shipping_UserAddress", _Shipping_UserAddress);
        ht.Add("@Shipping_UserCity", _Shipping_UserDistrict);
        ht.Add("@Shipping_UserDivision", _Shipping_UserDivision);
        ht.Add("@Shipping_UserDistrict", _Shipping_UserDistrict);
        ht.Add("@Shipping_UserCountry", _Shipping_UserCountry);
        ht.Add("@Shipping_UserCellNo", _Shipping_UserCellNo);
        ht.Add("@Shipping_UserUrl", _Shipping_UserUrl);
        ht.Add("@Shipping_UserEmail", _Shipping_UserEmail);

        ht.Add("@Billing_UserName", _Billing_UserName);
        ht.Add("@Billing_UserAddress", _Billing_UserAddress);
        ht.Add("@Billing_UserCity", _Billing_UserDistrict);
        ht.Add("@Billing_UserDivision", _Billing_UserDivision);
        ht.Add("@Billing_UserDistrict", _Billing_UserDistrict);
        ht.Add("@Billing_UserCountry", _Billing_UserCountry);
        ht.Add("@Billing_UserCellNo", _Billing_UserCellNo);
        ht.Add("@Billing_UserUrl", _Billing_UserUrl);
        ht.Add("@Billing_UserEmail", _Billing_UserEmail);

        try
        {
            int intActionResult = this.ExecuteNonQueryStoredProcedure("USP_ShoppingCart_Update_ShippingAddress", ht);
            return (intActionResult > 0 ? true : false);
        }
        catch
        {
            throw;
        }
    }


    /// <summary>
    /// Mainly Updates the IsVerified column field in the Orders table to True.
    /// Returns a bool indicating if the verification entry in database is successful.
    /// USP: USP_ShoppingCart_VerifyOrder
    /// </summary>
    /// <param name="intOrderID"></param>
    /// <param name="strCustomerName"></param>
    /// <param name="strCustomerEmail"></param>
    /// <param name="strShippingAddress"></param>
    /// <param name="strBillingAddress"></param>
    /// <returns></returns>
    public bool Verify_CustomerOrder(int intOrderID, string strCustomerName,
        string strCustomerEmail, string strShippingAddress, string strBillingAddress)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@OrderID", intOrderID);
        ht.Add("@CustomerName", strCustomerName);
        ht.Add("@CustomerEmail", strCustomerEmail);
        ht.Add("@ShippingAddress", strShippingAddress);
        ht.Add("@BillingAddress", strBillingAddress);
        try
        {
            int intActionResult = this.ExecuteNonQueryStoredProcedure("USP_ShoppingCart_VerifyOrder", ht);
            return (intActionResult > 0 ? true : false);
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Checks if The User already Placed the order.
    /// Returns True if User Already Placed this Order. False Otherwise.
    /// USP: USP_ShoppingCart_IsOrder_PlacedOnce
    /// </summary>
    /// <param name="intOrderID"></param>
    /// <returns></returns>
    public bool IsOrder_PlacedOnce(int intOrderID)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@OrderID", intOrderID);
        try
        {
            DataTable dt = this.ExecuteStoredProcedureDataTable("USP_ShoppingCart_IsOrder_PlacedOnce", ht);

            return (dt.Rows.Count > 0 ? true : false);
        }
        catch
        {
            throw;
        }
    }


    /// <summary>
    /// Inserts Payment Option in the Shopping Cart Table Before Processing the Checkout Function.
    /// USP: USP_ShoppingCart_InsertPaymentOption
    /// </summary>
    /// <param name="intCategoryID"></param>
    /// <param name="intProductID"></param>
    /// <param name="intProductSellerDetailID"></param>
    /// <param name="strPaymentOption"></param>
    /// <returns></returns>
    public bool ShoppingCart_InsertPaymentOption(int intCategoryID, int intProductID, int intProductSellerDetailID, string strPaymentOption)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@CartID", shoppingCartId);
        ht.Add("@CategoryID", intCategoryID);
        ht.Add("@ProductID", intProductID);
        ht.Add("@ProductSellerDetailID", intProductSellerDetailID);
        ht.Add("@PaymentOption", strPaymentOption);
        try
        {
            int intActionResult = ExecuteNonQueryStoredProcedure("USP_ShoppingCart_InsertPaymentOption", ht);
            return (intActionResult > 0 ? true : false);
        }
        catch
        {
            throw;
        }
    }




    /// <summary>
    /// Inserts ProfileID in the Orders Table. For a specific OrderID.
    /// USP: USP_ShoppingCart_InsertProfileID
    /// </summary>
    /// <param name="intProfileID"></param>
    /// <param name="intOrderID"></param>
    /// <returns></returns>
    public bool ShoppingCart_Insert_Orders_ProfileID_CodCost(int intProfileID, int intOrderID)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@ProfileID", intProfileID);
        ht.Add("@OrderID", intOrderID);
        try
        {
            int intActionResult = ExecuteNonQueryStoredProcedure("USP_ShoppingCart_Insert_ProfileID_OrderID_CodCost", ht);
            return (intActionResult > 0 ? true : false);
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// Retrieves Cart Summary From Shopping Cart.
    /// USP: USP_ShoppingCart_GetCartSummary
    /// </summary>
    /// <returns></returns>
    public DataTable ShoppingCart_GetCartSummary()
    {
        Hashtable ht = new Hashtable();
        ht.Add("@CartID", shoppingCartId);
        //ht.Add("@PaymentOption", strPaymentOption);
        try
        {
            return ExecuteStoredProcedureDataTable("USP_ShoppingCart_GetCartSummary", ht);
        }
        catch
        {
            throw;
        }

    }


    /// <summary>
    /// Updates Orders Table. Inserts Address From UserProfile Table as default Shipping and Billing address.
    /// USP: USP_ShoppingCart_Insert_AddressInfo
    /// </summary>
    /// <param name="_ProfileID"></param>
    /// <param name="_OrderID"></param>
    /// <returns></returns>
    public bool ShoppingCart_Insert_Orders_AddressInfo(int _ProfileID, int _OrderID)
    {
        Hashtable ht = new Hashtable();
        ht.Add("@ProfileID", _ProfileID);
        ht.Add("@OrderID", _OrderID);
        try
        {
            int intActionResult = ExecuteNonQueryStoredProcedure("USP_ShoppingCart_Insert_AddressInfo", ht);
            return (intActionResult > 0 ? true : false);
        }
        catch
        {
            throw;
        }
    }


}

