<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CountDiscountByCategory.ascx.cs" Inherits="UserControl_CountDiscountByCategory" %>
<div class="floatleft"  style="width:420px; vertical-align:top;background-color:#FFFAFA; padding:0px;border-top:solid 1px #E26E22; border-bottom:solid 1px #E26E22; border-left:solid 1px #E26E22;border-right:solid 1px #E26E22 ">
<table background="BG2.jpg" cellpadding="0px" height="25px"  cellspacing="0px" style="float: left; margin-top: 0px;
               margin-left:0px; padding-left:0px; width: 420px;">
<tr>
<td valign="top" style="width: 415px; height: 20px; padding-top:3px;padding-left:2px">
<span class="colortitle mediumfont" style="color:#3382D6;">Popular coupon &amp; deal categories</span>
</td>
</tr>
</table>
<table cellpadding="0px"  cellspacing="2px" width="415px" style="float: left; margin-top: 2px;
               margin-left:0px; padding-left:1px">
    <tr>
    <td style="width: 415px;">
    <asp:DataList ID="dlist" runat="server" OnItemDataBound="dlstCountCategory_OnItemDataBound" RepeatLayout="Flow"  RepeatDirection="Horizontal" BorderColor="Transparent" Width="415px">
         <ItemTemplate>
         <table cellpadding="1px" cellspacing="0px" width="200px" style="float: left; margin-top: 1px;
               margin-left: 1px;">
            <tr>
            <td style="width:200px; height:100%;" valign="top">
         <asp:Image ID="Image1" runat="server"  ImageUrl="~/Images/Bullet-home.png" Height="7px" Width="7px" />
         <a target="_self" style="color:#3382D6;" class="onHoverBlue title" href="DiscountList.aspx?mode=1&CI=<%#Eval("CategoryID") %>&CA=<%#Eval("Category") %>"><span><span style="font-size: 7pt;font-family:Verdana"><%#Eval("Category")%> (<%#Eval("NoOfDiscountWithSubcategory") %>)</span></span>
        </a>
             </td>
            </tr>
            </table>
 </ItemTemplate>
 </asp:DataList>
    </td>
    </tr>
    <tr>
    <td height="25px" style="width: 420px">
    <table>
    <tr>
    <td>
    <asp:Label id="lblSystemMessage" runat="server" Width="275px" Font-Size="14px" EnableViewState="False" ForeColor="Red">
    </asp:Label>
    </td>
    <td align="right" style="width: 130px">
    <a target="_blank" class="onHoverBlue price smallfont" href="ShowAllPrintableDiscount.aspx"><span style="font-size:10px">View All Discount</span></a>
    </td>
    </tr>
    </table>
    </td>
    </tr>
</table>
</div>

