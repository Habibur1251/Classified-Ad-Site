<%@ Page Language="C#" MasterPageFile="~/Classifieds/MPClassifieds2.master" AutoEventWireup="true" CodeFile="SelectCategory.aspx.cs" Inherits="Classifieds_SelectCategory" Title="Select a Category" %>

<%@ Register Src="../UserControl/CL_SelectCategory_Ctrl.ascx" TagName="CL_SelectCategory_Ctrl"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<uc1:CL_SelectCategory_Ctrl ID="CL_SelectCategory_Ctrl1" runat="server" IsCorporateControlPanel="false" />

</asp:Content>

