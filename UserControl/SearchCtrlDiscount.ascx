<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SearchCtrlDiscount.ascx.cs" Inherits="UserControl_SearchCtrlDiscount" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<table>
<tr>
<td>
<asp:TextBox ID="site_search" runat="server" CssClass="top_search"></asp:TextBox>
    <cc1:TextBoxWatermarkExtender ID="W" TargetControlID="site_search" WatermarkText="Search Discount" runat="server">
    </cc1:TextBoxWatermarkExtender>
</td>
<td>
<asp:ImageButton ID="btnSearchProduct" runat="server" ImageUrl="../images/search_right.png"
    Width="25px" Height="23px" Style="vertical-align: middle;" OnClick="btnSearchProduct_Click" />
</td>
</tr>
</table>
