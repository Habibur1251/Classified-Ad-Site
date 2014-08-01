<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProductInfo_Ctrl.ascx.cs" Inherits="UserControl_ProductInfo_Ctrl" %>
<table cellspacing="0px" cellpadding="0px" border="0px" style="border-bottom: 1px solid rgb(213, 213, 213); width: 950px;">
    <tbody>
        <tr >
            <td width="3px" style="height: 30px; padding:0px">
                <img alt="" height="28" width="3px" src="../Images/title_bar_left.gif" />
            </td>
            <td style="background-image: url(../Images/title_bar_bg.gif); background-repeat: repeat-x;
                padding-left: 5px; height: 30px; width: 400px;">
                <strong>Product General Information</strong>
            </td>
            
            <td style="width: 3px; height: 30px; padding:0px">
                <img alt="" height="28px" width="3px" src="../Images/title_bar_right.gif" />
            </td>
            <td style="width: 10px">
            </td>
            <td style="width: 201px">
            </td>
        </tr>
    </tbody>
</table>

<table width="100%" border="0px" cellspacing="0px" cellpadding="0px" class="cptable"
    style="background-color: #F8F8F8; border-top: 1px solid #EFEFE2;" id="TABLE2">
    <tr>
        <td align="right" style="width: 210px; height: 25px">
            SKU:</td>
        <td align="left" style="height: 25px">
            <asp:Label ID="lblSku" runat="server" Font-Bold="False"></asp:Label>
            &nbsp;&nbsp;
        </td>
    </tr>
    <tr>
        <td align="right" style="width: 210px; height: 25px">
            Category:</td>
        <td align="left" style="height: 25px">
            <asp:Label ID="lblCategory" runat="server" Font-Bold="False" />&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;</td>
    </tr>
    <tr>
        <td align="right" style="width: 210px; height: 25px">
            Subcategory:</td>
        <td align="left" style="height: 25px">
            <asp:Label ID="lblSubcategory" runat="server" Font-Bold="False" />&nbsp;
        </td>
    </tr>
    <tr>
        <td align="right" style="width: 210px; height: 25px">
            Second Subcategory:</td>
        <td align="left" style="height: 25px">
            <asp:Label ID="lblSecondSubcategory" runat="server" Font-Bold="False" />&nbsp;&nbsp;
        </td>
    </tr>
    <tr>
        <td align="right" style="width: 210px; height: 25px">
            Model:</td>
        <td align="left" style="height: 25px">
            <asp:Label ID="lblModel" runat="server" Font-Bold="False" /></td>
    </tr>
    <tr>
        <td align="right" style="width: 210px; height: 9px">
            Product Title:</td>
        <td align="left" style="height: 25px">
            <asp:Label ID="lblProductTitle" runat="server" Font-Bold="False" />&nbsp;
        </td>
    </tr>
    <tr>
    </tr>
</table>
