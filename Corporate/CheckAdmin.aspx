<%@ Page Language="C#" MasterPageFile="~/Corporate/MPCorporate2.master" AutoEventWireup="true" CodeFile="CheckAdmin.aspx.cs" Inherits="Corporate_CheckAdmin" Title="ApnerDealDiscount" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../UserControl/ImageResizeLink_Ctrl.ascx" TagName="ImageResizeLink_Ctrl"
    TagPrefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <div align="left" style="padding-right: 0px; padding-left: 0px; padding-bottom: 0px; margin: 0px; width: 100%; padding-top: 0px">
   <table width="100%" border="0" cellspacing="0" cellpadding="0">
   <tr>
   <td align="left" style="height: 17px">
   <span class="pageTitle">Add/Edit Discount Information.</span></td>
   <td style="height: 17px">
   </td>
   </tr>
   </table>
   <table width="100%" border="0" cellspacing="0" cellpadding="0">
   <tr>
    <td style="font-size: 11px; height: 25px" align="left" colspan="2">
   <asp:ValidationSummary ID="ValidationSummary1" runat="server" Width="500px" BackColor="#FFFFFF"
                            ForeColor="Black" Font-Bold="False" HeaderText="<table><tr><td style='padding-left:10px; padding-top:7px;'><img src='../images/icon_error.gif' width='42' height='40' alt='' /></td><td valign='middle' style='font-weight:bold; text-decoration:underline;color:#ED0000;'>Following error occured :</td></tr></table>"
                            BorderStyle="Dashed" BorderWidth="1px" Font-Size="11px"></asp:ValidationSummary>
                        <asp:Label ID="lblSystemMessage" runat="server" Width="500px" ForeColor="Red" Font-Size="11px"
                            EnableViewState="False">
                        </asp:Label>
   <td style="height: 17px">
   </td>
   </tr>
        <tr>
            <td style="width: 270px; height: 25px" valign="middle">
             <A target="_blank" href="../Discount/Default.aspx">How to post discount? <IMG alt="" src="../Images/question.jpg" border=0 /> </A>
            </td>
            <td style="height: 25px" align="right">
                Fields marked by <span class="mandatory">*</span> are mandatory
            </td>
        </tr>
   </table>
   <table style="border-top: #efefe2 1px solid; color: #000000" class="cptable" cellspacing="0"
            cellpadding="5" width="100%" border="0">
            <tbody>
                <tr>
                    <td style="width: 259px" align="right">
                      Company Name:<span class="mandatory">*</span>
                    </td>
                    <td>
                    <asp:UpdatePanel ID="UdatePanel1" runat="server">
                    <ContentTemplate>
                    <asp:DropDownList ID="ddlCompanyName" runat="server" Width="280px" AutoPostBack="True"
                            AppendDataBoundItems="True" 
                            DataValueField="CategoryID" DataTextField="Category">
                            <asp:ListItem Text="Select Company Name" Value="-1"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvCompany" runat="server" Font-Bold="True" ControlToValidate="ddlCompanyName"
                            ErrorMessage="Select Company" InitialValue="-1">?</asp:RequiredFieldValidator>
                        <asp:LinkButton ID="btnChangeCategory" OnClick="btnChangeCategory_Click" runat="server"
                            Font-Underline="true" Font-Size="12px" Font-Names="verdana,arial,helvetica,sans-serif"
                            Visible="False">Refine Search</asp:LinkButton>
                    </ContentTemplate>
                    </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                <td>
                </td>
                <td>
                <a href="AddCompany.aspx"><u><b>Add New Company</b></u></a>
                </td>
                </tr>
                <tr>
                    <td style="width: 259px">
                    </td>
                    <td align="left">
                    <asp:Button ID="btnNextPage" OnClick="btnNextPage_Click" runat="server" BorderStyle="Groove"
                            Text="Next" CssClass="image_btn"></asp:Button>
                    </td>
                </tr>
                </tbody>
                </table>
  </div>
</asp:Content>

