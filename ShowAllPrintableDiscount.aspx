<%@ Page Language="C#" MasterPageFile="~/Discount.master" AutoEventWireup="true" CodeFile="ShowAllPrintableDiscount.aspx.cs" Inherits="ShowAllPrintableDiscount" Title="ApnerDeal.com: Deals and discounts site of Bangladesh" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/UserControl/DZ_TOPFive_ViewedDiscount.ascx" TagName="Hp_TopFive_Discount_Ctrl"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
<asp:Label ID="lblSystemMessage" runat="server" ForeColor="Red" EnableViewState="False"
        Width="500px" Font-Size="14px">
</asp:Label>
<br />
<table  align="center" border="0" cellpadding="3" cellspacing="0" style="width: 1050px;">
<tr>
<td valign="top" width="210">
<uc2:Hp_TopFive_Discount_Ctrl ID="Hp_TopFive_Discount_Ctrl1" runat="server" />
</td>
<td valign="top" style="width: 700px">
<div class="floatleft" style="width:650px; padding:2px; border-top:solid 1px #5C9EBF; border-bottom:solid 1px #5C9EBF; border-left:solid 1px #5C9EBF;border-right:solid 1px #5C9EBF ">
               <asp:GridView 
                    ID="grvListDiscountLeftpannel"
                    runat="server" 
                    Width="650px"
                    GridLines="none"
                    PageSize="15"
                    AllowPaging="true"
                    OnPageIndexChanging="grvListDiscountLeftpannel_PageIndexChanging"
                    AutoGenerateColumns="false" FooterStyle-BorderStyle="Solid"  PagerStyle-CssClass="paging" OnRowDataBound="grvListDiscountLeftpannel_RowDataBound">
                    <PagerSettings Position="TopAndBottom"></PagerSettings>
                     <FooterStyle BackColor="#2E4D7B" Height="20px" ForeColor="White" Font-Size="10px" Font-Names="Verdana" Font-Bold="True" BorderStyle="Solid" />
                    <PagerStyle BackColor="Gainsboro" BorderStyle="None" CssClass="paging" BorderColor="Linen"></PagerStyle>
                    <HeaderStyle BackColor="#507CD1" Height="20px" ForeColor="White" Font-Size="10px" Font-Names="Verdana" Font-Bold="True"></HeaderStyle>
                   <AlternatingRowStyle BackColor="White" />
               <Columns>
               <asp:TemplateField>
<HeaderTemplate>                  
<table width="100%" height="20px" cellpadding="0px" cellspacing="0px" border="0px" bgcolor="#507CD1">
<tr>
<td style="text-align: left; padding-left: 5px;font-family:Verdana;">
   Displaying
    <%=  (grvListDiscountLeftpannel.PageIndex * grvListDiscountLeftpannel.PageSize) + 1%>
    -
    <%= grvListDiscountLeftpannel.Rows.Count < grvListDiscountLeftpannel.PageSize ? Total_Record : (grvListDiscountLeftpannel.PageIndex + 1) * 15%>
</td>
<td style="text-align: center;font-family:Verdana;">
Page
    <%=grvListDiscountLeftpannel.PageIndex + 1%>
</td>

<td style="text-align: right; padding-right: 5px; font-family:Verdana;">
Total
<%=Total_Record%>
store(s) found
</td>
<td style="text-align: right; padding-right: 5px; font-family:Verdana;">
</td>
</tr>
</table>
<table background="images/BG2.jpg" width="100%" height="20px" cellpadding="0px" cellspacing="0px" border="0px" bgcolor="#FFAA0D">

<tr>
<td class="colortitle" style="text-align: left; padding-left: 5px;font-family:Verdana;">
  Store
</td>
<td class="colortitle" style="text-align: center;font-family:Verdana;">
  Discount Details
</td>
<td class="colortitle" style="text-align: right; padding-right: 0px; font-family:Verdana;">
Coupon code
</td>
<td style="text-align: right; width:55px; padding-right: 1px; font-family:Verdana;">
</td>
</tr>
</table>
</HeaderTemplate>
               <ItemTemplate>
               <table width="100%" cellpadding="5" cellspacing="1" border="0">
               <tr>
               <td valign="top" style="width:120px; height:110px">
                <div class="t" style="width:120px">
                    <div class="b">
                        <div class="l">
                            <div class="r">
                                <div class="bl">
                                    <div class="br">
                                        <div class="tl">
                                            <div class="tr" style="height: auto; padding: 5px;">
                <a target="_self" style="" class="onHoverTitleLinkDiscount title" href="DiscountList.aspx?mode=0&PI=<%#Eval("ProfileID") %>&CN=<%#Eval("CompanyName") %>">
               <img src='<%#Eval("ImagePath")%>' onerror="javascript:this.src='Images/CompanyDefaultImage.png';"
                   style="width: 110px; border: none;" height="75" />
                 </a>
                 </div>
             </div>
             </div>
             </div>
             </div>
             </div>
             </div>
             </div>
               </td>
               <td class="DiscountContent" valign="top"  style="width:320px; height:auto">
               <asp:PlaceHolder ID="phCouponLink" runat="server">
                 </asp:PlaceHolder>
                  <div style=""><span style=" color:Black;">
                  <p class="formatParagraphDiscount">
                  <%#Eval("CouponDescription")%>
                  </p>
                  </span></div>
                   <span style="color: #cc0066">
                  *This Coupon Expires:</span>
                   <%#Eval("CouponExpirydate")%><br />
                   <span style="color: #990066">
                   *This Coupon Starts On:</span>
                    <%#Eval("CouponEffectiveDate")%><br /><br/>
                  *See All:
                   <a target="_blank" style="" class="onHoverRedLink colortitle" href="DiscountList.aspx?mode=0&PI=<%#Eval("ProfileID") %>&CN=<%#Eval("CompanyName") %>"><u><%#Eval("CompanyName")%>(<%#Eval("NoOfDiscount")%>)</u></a>
               </td>
               <td align="left" class="colortitle" valign="top" style="width:60px; height:110px">
                <span style="font-size:9px;"><%#Eval("CouponCode")%></span>
               </td>
               <td  align="right" style="width:20px;height:110px">
               <a target="_self" href="http://www.facebook.com/sharer.php?u=http://www.apnerdeal.com/ShowAllPrintableDiscount.aspx&t=ApnerDeal.com: Find Bangladeshi Discounts, Coupons, Deals, Price Reduction news all in one place. Save money to your next purchase!"><asp:Image ID="Image47" runat="server"  ImageUrl="~/Images/facebook.png" Height="16px" Width="16px"/></a><br /><br />
               <a target="_blank" href="http://twitter.com/apnerdeal/" title="Twitter" ><asp:Image ID="Image48" runat="server"  ImageUrl="~/Images/twitter.png" Height="16px" Width="16px"/></a>
               </td>
               </tr>
               </table>
               <hr size="1" style="color:#5C9EBF;" />
               </ItemTemplate>
               </asp:TemplateField>
               </Columns>
               </asp:GridView>
</div>
</td>
<td valign="top" width="260">

<%--Space for Google Adsense--%>

<script type="text/javascript"> 
 
  var _gaq = _gaq || [];
  _gaq.push(['_setAccount', 'UA-29319949-1']);
  _gaq.push(['_trackPageview']);
 
  (function() {
    var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
    ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
    var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
  })();
 
</script>


</td>
</tr>
</table>
</asp:Content>

