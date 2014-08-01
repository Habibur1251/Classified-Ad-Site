<%@ Page Language="C#" MasterPageFile="~/Corporate/MPCorporate2.master" AutoEventWireup="true" CodeFile="MessageDiscountUpdate.aspx.cs" Inherits="Corporate_MessageDiscountUpdate" Title="ApnerDeal.com Discount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div>
<table cellpadding="10px" align="left" style="width:100%">
<tr>
<td align="left" class="latestTitle" style="width:100%; height:auto;">
Congratulations!!! Your Discount has been successfullly Updated.
</td>
</tr>
<tr>
<td align="left" style="width: 100%">
 <asp:LinkButton ID="LinkButton2" runat="server" Font-Bold="True" Font-Size="14px" Font-Underline="True" PostBackUrl="~/Corporate/ControlPanel.aspx">Return to your discount</asp:LinkButton>   
</td>
</tr>
</table>
</div>
</asp:Content>

