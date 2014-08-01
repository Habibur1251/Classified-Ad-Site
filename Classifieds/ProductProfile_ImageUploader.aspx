<%@ Page Language="C#" MasterPageFile="~/Classifieds/MPClassifieds2.master" AutoEventWireup="true" CodeFile="ProductProfile_ImageUploader.aspx.cs" Inherits="Classifieds_ProductProfile_ImageUploader" Title="www.apnerdeal.com" %>

<%@ Register Src="../UserControl/ImageResizeLink_Ctrl.ascx" TagName="ImageResizeLink_Ctrl"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="100%" border="0px" cellspacing="0px" cellpadding="0px" class="cptable" style="border-top:1px solid #EFEFE2;">    
    <tr>
        <td colspan="2">
        <asp:Label ID="lblSystemMessage" ForeColor="red" runat="server">
        </asp:Label>&nbsp;
        </td>
    </tr>
    <tr>
    <td style="height: 12px;">
        Select Product Image:
    </td>
    <td style="height: 12px;">
    <asp:FileUpload 
        ID="FileUpload1" 
        runat="server" 
        CssClass="textbox" 
        Width="500px" />
    &nbsp;&nbsp;    
    <asp:Button ID="btnUpload" runat="server" BorderStyle="Groove" Text="Upload" Width="85px" OnClick="btnUpload_Click" />&nbsp;
        
        
    </td>
    </tr>    
    <tr>
    <td colspan="2">
    <span class="gray11px" style="color:Coral">
        Image size must be less then 200 KB. Choose any format except .bmp.&nbsp;
        Preferred width height ratio 200 by 300 px.
        <br />
        <uc1:ImageResizeLink_Ctrl ID="ImageResizeLink_Ctrl1" runat="server" />
    </span>
    </td>
    </tr>
</table>
</asp:Content>

