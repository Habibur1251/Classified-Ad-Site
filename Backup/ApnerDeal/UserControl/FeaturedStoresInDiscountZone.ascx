<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FeaturedStoresInDiscountZone.ascx.cs" Inherits="UserControl_FeaturedStoresInDiscountZone" %>
<div class="floatleft"  style="width:420px; vertical-align:top;background-color:#FFFCFC; padding:0px;border-top:solid 1px #E26E22; border-bottom:solid 1px #E26E22; border-left:solid 1px #E26E22;border-right:solid 1px #E26E22 ">
<table background="Images/BG2.jpg" cellpadding="0px" height="25px"  cellspacing="0px" width="420px" style="float: left; margin-top: 0px;
               margin-left:0px; padding-left:0px">
<tr>
<td valign="top" style="width: 420px; height: 20px; padding-top:3px;padding-left:2px">
<span class="colortitle mediumfont" style="color:#3382D6;">Featured Stores</span>
</td>
</tr>
</table>
<table  cellpadding="0px" cellspacing="0px" width="420px" style="float: left; margin-top: 2px;
               margin-left:0px;">
    <tr>
    <td bgcolor="#FFEED4" valign="top" class="DiscountContent;" style="width: 420px; height:20px;">
     Click a logo to see all available coupons & deals for that store
     <br />
    </td>
    </tr>
    <tr>
    <td>
    <hr size="1" style="color:#5C9EBF;" />
    </td>
    </tr>
    <tr>
    <td style="width: 415px">
    <asp:DataList ID="dlist"  runat="server" RepeatLayout="Flow"  RepeatDirection="Horizontal" BorderColor="Transparent" Width="415px">
         <ItemTemplate>
            <table cellpadding="5" cellspacing="0" width="auto" style="float: left; margin-top: 10px;
               margin-left: 10px;">
            <tr>
            <td valign="top">
                <div class="t" style="width:115px;">
                    <div class="b">
                        <div class="l">
                            <div class="r">
                                <div class="bl">
                                    <div class="br">
                                        <div class="tl">
                                            <div class="tr" style="height: auto; padding: 5px;">
            <a target="_self" style="font-weight:bold;" class="onHoverRedLink colortitle" href="DiscountList.aspx?mode=0&PI=<%#Eval("ProfileID") %>&CN=<%#Eval("CompanyName") %>">
             <img src='<%#Eval("ImagePath")%>' onerror="javascript:this.src='Images/CompanyDefaultImage.png';"style="width: 100px; border: none;" height="75" />
            </a>
             </div>
             </div>
             </div>
             </div>
             </div>
             </div>
             </div>
             </div>
                <a target="_self" style="font-weight:bold;" class="onHoverRedLink" href="DiscountList.aspx?mode=0&PI=<%#Eval("ProfileID") %>&CN=<%#Eval("CompanyName") %>"><u><span class="title mediumfont" style="font-size:7pt;font-family:Verdana">See all <%#Eval("NoOfDiscount")%> Offers>></span></u></a>
            </td>
            </tr>
            </table>
 </ItemTemplate>
 </asp:DataList>
    </td>
    </tr>
    <tr>
    <td height="25px" style="width: 415px">
    <asp:Label id="lblSystemMessage" runat="server" Width="385px" Font-Size="14px" EnableViewState="False" ForeColor="Red">
       </asp:Label>
    </td>
    </tr>
</table>

</div>

