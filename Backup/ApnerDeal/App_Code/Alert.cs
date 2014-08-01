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
/// Summary description for Alert
/// </summary>
public static class Alert
{
    /// <summary>
    /// Shows a client-side JavaScript alert in the browser.
    /// </summary>
    /// <param name="message">The message to appear in the alert.</param>
public static void Show(string message)
{
   // Cleans the message to allow single quotation marks
   string cleanMessage = message.Replace("'", "\'");

   string script = @"<script type=" + "text/javascript" + ">alert('" + cleanMessage + "');</script>";

   // Gets the executing web page
   Page page = HttpContext.Current.CurrentHandler as Page;
   // Checks if the handler is a Page and that the script isn't allready on the Page
   if (page != null && !page.ClientScript.IsClientScriptBlockRegistered("alert"))
   {
     page.ClientScript.RegisterClientScriptBlock(typeof(Alert), "alert", script);
   }
} 
}