<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrintedCoupons.aspx.cs" Inherits="PrintedCoupons" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ApnerDeal.com</title>
    <link href="CSS/style.css" rel="stylesheet" type="text/css" />
    <link href="CSS/styleDiscount.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="JavaScript">
	function myprint()
	{
		window.print();
	}
</script>
</head>
<body>
    <form id="form1" runat="server">
     <div align="center">
    <br />
    <div style="width:575px; padding:2px; border-top:dashed 2px #5C9EBF; border-bottom:dashed 2px #5C9EBF; border-left:dashed  2px #5C9EBF;border-right:dashed  2px #5C9EBF ">
    <table >
    <tr>
    <td>
    <img src="Images/NewCouponHeader.png" style="width:556px; height:110px" />
    </td>
    </tr>
    <tr>
    <td valign="top"style="HEIGHT:556px;width:556px;">
        <asp:FormView ID="fvPrientCoupon" runat="server" DataKeyNames="ProfileID,CouponID,PrintedCouponNeed"
            AllowPaging="false" Font-Size="11px">
            <ItemTemplate>
                <table align="center" border="0" cellpadding="5" cellspacing="0">
                    <tr>
                        <td  align="center" valign="top" style="height: 556px; width: 556px;" background="Images/Body.gif">
                       <table>
                       <tr>
                       <td align="center">
                       <span class="title mediumfont"><%#Eval("CouponCode")%></span>
                       </td>
                       </tr>
                        <tr>
                        <td  align="center">
                        <span class="colortitle mediumfont"><b><%#Eval("CompanyName")%></b></span>
                        </td>
                        </tr>
                        <tr>
                        <td align="center">
                         <br />
                         <img src='<%#Eval("ImagePath")%>' onerror="javascript:this.src='Images/CompanyDefaultImage.png';" style="width: 135px; border: none;" height="95" />
                         </td>
                        </tr>
                        <tr>
                        <td align="center" > 
                        <span style="font-size:25px;" class="titleDiscount mediumfont"><b><%#Eval("CouponTitle")%></b></span><br />
                        <hr size="1" style="color:#5C9EBF;" />
                        </td>
                        </tr>
                        <tr>
                        <td align="justify" class="DiscountContent" valign="top" style="height:auto; width: 450px;">
                        <p class="formatParagraphDiscount1">
                        <%#Eval("CouponDescription")%><br />
                        </p>
                        </td>
                        </tr>
                        <tr>
                        </tr>
                         <tr>
                        <td align="left" class="DiscountContent">
                        *This Coupon Expires:
                   <%#Eval("CouponExpirydate")%><br />
                   *This Coupon Starts On:
                    <%#Eval("CouponEffectiveDate")%><br /><br />
                    
                        </td>
                        </tr>
                           <tr>
                        <td align="left">
                        <span style="font-size:10px;" class="titleDiscount mediumfont">Phone :<%#Eval("ContactPhone")%></span><br />
                        </td>
                           </tr>
                        <tr>
                        <td align="left">
                        <span style="font-size:10px;" class="titleDiscount mediumfont"><%#Eval("CompanyName")%></span>
                        </td>
                        </tr>
                        <tr>
                        <td align="left" style="height:85px" >
                        <%=this.Address.ToString().Replace(Environment.NewLine, "<br/>")%>
                        </td>
                        </tr>
                        <tr>
                        <td align="left">
                        Web Site: <a target="_blank" href="<%#Eval("CompanyURL")%>"><%#Eval("CompanyURL")%></a>
                        </td>
                        </tr>
                        <tr>
                        <td align="left" valign="top" style="height:85px; width: 450px;">
                         <%#Eval("TermsCondition")%>
                        </td>
                        </tr>
                        <tr>
                        <td align="center"valign="top">
                        <span class="DiscountContent"><b>Powered By:ApnerDeal.com</b></span>
                        </td>
                        </tr>
                        </table>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:FormView>
    </td>
    </tr>
    
    <tr>
    <td align="center">
      <a href="javascript:myprint();" id="print"><asp:Image ID="Image10" runat="server" ImageUrl="~/Images/CouponImage/print.gif" /></a>
    </td>
    </tr>
    <tr>
    <td style="">
    <asp:Label ID="lblSystemMessage" runat="server" ForeColor="Red" EnableViewState="False"
        Width="500px" Font-Size="14px">
    </asp:Label>
    </td>
    </tr>
    </table>
    </div>
    </div>
    </form>
</body>
</html>
