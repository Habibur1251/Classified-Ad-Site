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
/// Summary description for Enumerators
/// </summary>
public class Enumerators
{
    public enum EmailSentStatus
    {
        UNSENT = 0,
        FETCHED = 1,
        SENT = 2
    }
}
