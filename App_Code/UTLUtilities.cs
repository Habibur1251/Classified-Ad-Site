using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography;

public class UTLUtilities
    {

        public static int CL_ActiveModule;
        public static int CP_ActiveModule;
        public static string HP_Location = "Bangladesh";
        static byte[] bytes = ASCIIEncoding.ASCII.GetBytes("ZeroCool");
        public UTLUtilities()
        {
        }
        public class Database
        {
            // Real Server 

            public static string DbConnectionString = "Server=212.74.43.180,1433;Database=deals;UID=appsuser;PWD=Bd54321!123";

            //public static string DbConnectionString = "Server=MOINUR-PC;Database=deals;UID=sa;PWD=moinur12345";

        }

        /// <summary>
        /// Returns True if Conversion Succeeded.
        /// </summary>
        /// <param name="Expression"></param>
        /// <returns></returns>
        public static bool IsNumeric(object Expression)
        {
            bool isNum;
            double retNum;

            isNum = Double.TryParse(Convert.ToString(Expression), System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);

            return isNum;
        }

        public static void BuildDateControl(DropDownList ddlDay, DropDownList ddlMonth, DropDownList ddlYear)
        {
            //DAY OF THE MONTH:-
            ddlDay.Items.Add(new ListItem("dd", "-1"));
            for (int i = 1; i <= 31; i++)
            {
                ddlDay.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }

            //MONTH LIST:-
            ddlMonth.Items.Add(new ListItem("mm", "-1"));
            ddlMonth.Items.Add(new ListItem("Jan", "1"));
            ddlMonth.Items.Add(new ListItem("Feb", "2"));
            ddlMonth.Items.Add(new ListItem("Mar", "3"));
            ddlMonth.Items.Add(new ListItem("Apr", "4"));
            ddlMonth.Items.Add(new ListItem("May", "5"));
            ddlMonth.Items.Add(new ListItem("Jun", "6"));
            ddlMonth.Items.Add(new ListItem("Jul", "7"));
            ddlMonth.Items.Add(new ListItem("Aug", "8"));
            ddlMonth.Items.Add(new ListItem("Sep", "9"));
            ddlMonth.Items.Add(new ListItem("Oct", "10"));
            ddlMonth.Items.Add(new ListItem("Nov", "11"));
            ddlMonth.Items.Add(new ListItem("Dec", "12"));

            //YEAR LIST:-
            ddlYear.Items.Add(new ListItem("yyyy", "-1"));
            for (Int64 j = 2008; j <= (DateTime.Now.Year + 1); j++)
            {
                ddlYear.Items.Add(new ListItem(j.ToString(), j.ToString()));
            }
        }

        public static string Encrypt(string originalString)
        {
            if (String.IsNullOrEmpty(originalString))
            {
                throw new ArgumentNullException("The string which needs to be encrypted can not be null.");
            }

            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoProvider.CreateEncryptor(bytes, bytes), CryptoStreamMode.Write);

            StreamWriter writer = new StreamWriter(cryptoStream);

            writer.Write(originalString);
            writer.Flush();
            cryptoStream.FlushFinalBlock();
            writer.Flush();

            return Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
        }

        public static string Decrypt(string cryptedString)
        {
            if (String.IsNullOrEmpty(cryptedString))
            {
                throw new ArgumentNullException("The string which needs to be decrypted can not be null.");
            }
            cryptedString = cryptedString.Replace(" ", "+"); // Added Due to Error ""
            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(cryptedString));
            CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoProvider.CreateDecryptor(bytes, bytes), CryptoStreamMode.Read);
            StreamReader reader = new StreamReader(cryptoStream);

            return reader.ReadToEnd();
        }

        public static string ShowErrorMessage(string ErrorText)
        {
            string strHTML = string.Empty;

            strHTML = "<table class=\"left_link_bg\" style=\"width:auto; \">";
            strHTML += "<tr>";
            strHTML += "<td align=\"center\" style=\"width:10%;\"><img src=\"http://www.apnerdeal.com/images/icon_error.gif\" width=\"42\" height=\"35\" alt=\"\" /></td>";
            strHTML += "<td valign=\"middle\" style=\"width:90%;font-weight:bold; text-decoration:underline\">Following error occured :</td>";
            strHTML += "</tr>";
            strHTML += "<tr>";
            strHTML += "<td colspan=\"2\" style=\"width:100%;color:#000000;padding-top:7px; padding-left:10px;\">";
            strHTML += "<span class=\"price\">" + ErrorText + "</span>";
            strHTML += "</td>";
            strHTML += "</tr>";
            strHTML += "</table>";

            return strHTML;
        }


        public static string ShowSuccessMessage(string SuccessText)
        {
            string strHTML = string.Empty;
            strHTML = "<table class=\"left_link_bg\" style=\"width:100%; \">";
            strHTML += "<tr>";
            strHTML += "<td align=\"center\" style=\"width:10%;\"><img src=\"http://www.apnerdeal.com/images/icon_successfull.gif\" width=\"42\" height=\"30\" alt=\"\" /></td>";
            strHTML += "<td colspan=\"2\" style=\"width:100%;height:35px;color:#000000;padding-top:0px; padding-left:5px;\">";
            strHTML += "<span class=\"price pageTitle\">" + SuccessText + "</span>";
            strHTML += "</td>";
            strHTML += "</tr>";
            strHTML += "</table>";
            return strHTML;
        }

        public static string ShowGeneralMessageCP(string generalText)
        {
            string strHTML = string.Empty;
            strHTML = "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" align=\"center\" style=\"width:606px; background-color:#3B5998;\">";
            strHTML += "<tr>";
            strHTML += "<td align=\"left\" style=\"width:10%;\"><img src=\"http://www.apnerdeal.com/images/info_image.jpg\" width=\"42\" height=\"35\" alt=\"\" /></td>";
            strHTML += "<td align=\"left\" style=\"height:35px; color:#FFFFFF; font-size:14px; font-weight:bold;\" valign=\"middle\">";
            strHTML += "<span class=\"title\" style=\"font-size:14px;\">";
            strHTML += "</span>" + generalText;
            strHTML += "</td>";
            strHTML += "</tr>";
            strHTML += "</table>";
            return strHTML;
        }

        public static string ShowGeneralMessage(string generalText)
        {
            string strHTML = string.Empty;
            strHTML = "<table class=\"left_link_bg\" style=\"width:100%; \">";
            strHTML += "<tr>";
            strHTML += "<td align=\"center\" style=\"width:10%;\"><img src=\"http://www.apnerdeal.com/images/info_image.jpg\" width=\"42\" height=\"40\" alt=\"\" /></td>";
            strHTML += "<td colspan=\"2\" style=\"width:100%;color:#000000;padding-top:7px; padding-left:10px;\">";
            strHTML += "<span class=\"price pageTitle\">" + generalText + "</span>";
            strHTML += "<br/><br/>";
            strHTML += "</td>";
            strHTML += "</tr>";
            strHTML += "</table>";
            return strHTML;
        }

        /// <summary>
        /// Displays Successfull Add to Cart Message.
        /// </summary>
        /// <param name="_ProductTitle"></param>
        /// <returns></returns>
        public static string DisplayAddToCartMessage(string _ProductTitle)
        {
            string strHtml = "";
            strHtml = "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" style=\"width:500px;margin-left:70px; background-color:#FFA500;\">";
            strHtml += "<tr>";
            strHtml += "<td align=\"center\" style=\"height:45px; color:#FFFFFF; font-size:14px; font-weight:bold;vertical-align:middle\" >";

            strHtml += "<span class=\"title\" style=\"font-size:14px; \">\"";
            strHtml += _ProductTitle + "\"</span> has been added to your cart.";
            strHtml += "<br/>";
            strHtml += "<a href='ShoppingCart.aspx' alt='Shopping Cart'>";
            strHtml += "<img src='../images/viewcartbtn.png' align='middle' border='none' />";
            strHtml += "</a>";
            strHtml += "</td>";
            strHtml += "</tr>";
            strHtml += "</table>";
            return strHtml;
        }

        public static string DisplayAddToCartMessageQunatiy(string _ProductTitle)
        {
            string strHtml = "";
            strHtml = "<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" style=\"width:450px;margin-left:70px; background-color:#ffdab9;\">";
            strHtml += "<tr>";
            strHtml += "<td align=\"center\" style=\"height:60px; color:#FF0000; font-family: Verdana; font-size:12px; font-weight:bold;vertical-align:middle\" >";

            strHtml += "<span class=\"title\" style=\"font-size:14px; \">\"";
            strHtml += _ProductTitle + "\"</span>";
            strHtml += "<br/>";
            strHtml += "Didn't Add in your Cart due to Product has been sold out.";
            strHtml += "<br/>";
            strHtml += "<span style=\"font-size:12px;font-family: Verdana;color:green; \">\"";
            strHtml += "For detail please email at info@apnerdeal.com";
            strHtml += "\"</span>";
            strHtml += "</td>";
            strHtml += "</tr>";
            strHtml += "</table>";
            return strHtml;
        }


        public static string MailLogoHeader()
        {
            string strHtml = string.Empty;
            strHtml = "<table width=\"800px\" border=1px solid #C3C1C1 align=\"center\" cellpadding=\"5px\" cellspacing=\"0px\">";
            strHtml += "<tr><td>";
            //strHtml += "<a color=\"white\" href=\"http://www.apnerdeal.com\">";
            strHtml += "<img src=\"http://www.apnerdeal.com/images/logo.gif\" width=\"260px\" height=\"91\" alt=\"\" />";
            //strHtml += "</a>";
            strHtml += "</td></tr><tr><td style=\"background-color:#3B5998;border:none;font-weight:bold; color: white\">";
            strHtml += "ApnerDeal Sales Team.</td></tr><tr><td>";
            return strHtml;
        }

        public static string MailLogoHeaderBoroMelaDiscount()
        {
            string strHtml = string.Empty;
            strHtml = "<table width=\"800px\" border=1px solid #C3C1C1 align=\"center\" cellpadding=\"5px\" cellspacing=\"0px\">";
            strHtml += "<tr><td>";
            //strHtml += "<a color=\"white\" href=\"http://www.apnerdeal.com\">";
            strHtml += "<img src=\"http://www.apnerdeal.com/Images/apnerdeal_logo.png\" width=\"260px\" height=\"91\" alt=\"\" />";
            //strHtml += "</a>";
            strHtml += "</td></tr><tr><td style=\"background-color:#3B5998;border:none;font-weight:bold; color: white\">";
            strHtml += "ApnerDeal Discount Team.</td></tr><tr><td>";
            return strHtml;
        }
    }

