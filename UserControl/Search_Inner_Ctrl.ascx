<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Search_Inner_Ctrl.ascx.cs"
    Inherits="UserControl_Search_Inner_Ctrl" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %> 
<asp:TextBox ID="site_search"  runat="server" CssClass="top_search"></asp:TextBox>
<cc1:TextBoxWatermarkExtender ID="W" TargetControlID="site_search" WatermarkText="Search this site" runat="server">
</cc1:TextBoxWatermarkExtender>
<%--<input name="site_search" runat="server" type="text" id="site_search" value="" class="top_search" />--%>
<asp:ImageButton ID="btnSearchProduct" runat="server" ImageUrl="../images/search_right.png"
    Width="25px" Height="23px" Style="vertical-align: middle;" OnClick="btnSearchProduct_Click" />