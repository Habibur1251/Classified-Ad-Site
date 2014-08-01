<%@ Page Language="C#" MasterPageFile="~/Corporate/MPCorporate2.master" AutoEventWireup="true" CodeFile="SelectDiscountType.aspx.cs" Inherits="Corporate_SelectDiscountType" Title="ApnerDeal.com" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <div align="left" style="padding-right: 0px; padding-left: 0px; padding-bottom: 0px;
    
        margin: 0px; width: 100%; padding-top: 0px">
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
                <A target="_blank" style="FONT-WEIGHT: bold; VERTICAL-ALIGN: middle; TEXT-DECORATION: underline" href="Default.aspx">How to post discount? <IMG alt="" src="../Images/question.jpg" border=0 /> </A>
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
                    <td style="width: 250px" align="right">
                      Category:<span class="mandatory">*</span>
                    </td>
                    <td>
                     <asp:UpdatePanel ID="updatePane2" runat="server">
                       <contenttemplate>
                         <asp:DropDownList ID="ddlCategory" runat="server" Width="260px" AutoPostBack="True"
                            AppendDataBoundItems="True" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged"
                            DataValueField="CategoryID" DataTextField="Category">
                            <asp:ListItem Text="Select Category" Value="-1"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvCategory" runat="server" Font-Bold="True" ControlToValidate="ddlCategory"
                            ErrorMessage="Select Category" InitialValue="-1">?</asp:RequiredFieldValidator>
                        <asp:LinkButton ID="btnChangeCategory" OnClick="btnChangeCategory_Click" runat="server"
                            Font-Underline="true" Font-Size="12px" Font-Names="verdana,arial,helvetica,sans-serif"
                            Visible="False">Refine Search</asp:LinkButton>
                            </contenttemplate>
                            </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td style="width: 250px" align="right">
                       Subcategory:<span class="mandatory">*</span>
                    </td>
                    <td align="left">
                     <asp:UpdatePanel ID="updatePanel3" runat="server">
                       <contenttemplate>
                        <asp:DropDownList ID="ddlSubcategory" runat="server" Width="260px" AutoPostBack="True"
                            AppendDataBoundItems="True" DataValueField="SubcategoryID" DataTextField="Subcategory">
                            <asp:ListItem Text="Select Subcategory" Value="-1"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvSubcategory" runat="server" Font-Bold="True" ControlToValidate="ddlSubcategory"
                            ErrorMessage="Select Subcategory" InitialValue="-1" SetFocusOnError="True">?</asp:RequiredFieldValidator>
                            </contenttemplate>
                            </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <td style="width: 250px; height: 25px" align="right">
                    </td>
                    <td style="height: 30px" align="left">
                     <span style="font-size:small" class="title"><%=DiscountTypeName%></span> <asp:CheckBox ID="changeCheckBox" Text="Check this if you have edit member type.Leave uncheck otherwise" runat="server" OnCheckedChanged="changeCheckBox_CheckedChanged" AutoPostBack="True" Visible="False" />
                     </td>
                    <td style="height: 25px">
                    </td>
                </tr>
               <tr>
               <td>
              </td>
               <td>
               <asp:UpdatePanel ID="updatePanel" runat="server">
                       <contenttemplate>
<asp:Panel id="panelSaleOffer" runat="server" Width="200px" Visible="false" Enabled="false"><TABLE><TBODY><TR><TD><asp:RadioButtonList id="DiscountTypeEdit" runat="server" Width="380px" Font-Bold="False" Visible="False" Height="72px"><asp:ListItem Value="1">P Package&lt;br /&gt;For pricing and detail please email us at&lt;a href=&quot;mailto:info@ApnerDeal.com &quot;&gt;info@ApnerDeal.com &lt;/a&gt;&lt;br /&gt;</asp:ListItem>
<asp:ListItem Value="2">Standard Package&lt;br /&gt;For pricing and detail please email us at&lt;a href=&quot;mailto:info@ApnerDeal.com &quot;&gt;info@ApnerDeal.com &lt;/a&gt;&lt;br /&gt;</asp:ListItem>
</asp:RadioButtonList> </TD><TD><asp:RequiredFieldValidator id="discountTypeRequiredFieldValidator" runat="server" Font-Bold="True" ErrorMessage="Select Discount Type" ControlToValidate="DiscountTypeEdit" SetFocusOnError="True">?</asp:RequiredFieldValidator> </TD></TR><TR><TD><SPAN class="colortitle"></SPAN><BR /></TD></TR></TBODY></TABLE></asp:Panel> 
</contenttemplate>
                   </asp:UpdatePanel>
               </td>
               </tr>
                <tr>
                    <td style="width: 200px">
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

