<%@ Page Language="C#" MasterPageFile="~/Corporate/MPCorporate2.master" AutoEventWireup="true" CodeFile="StoreType.aspx.cs" Inherits="Corporate_StoreType" Title="ApnerDeal.com" %>
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
            <td style="width: 195px; height: 25px" valign="middle">
            <A target="_blank" style="FONT-WEIGHT: bold; VERTICAL-ALIGN: middle; TEXT-DECORATION: underline" href="Default.aspx">How to post discount? <IMG alt="" src="../Images/question.jpg" border=0 /> </A>
            </td>
            <td style="height: 25px" align="right">
                Fields marked by <span class="mandatory">*</span> are mandatory
            </td>
        </tr>
        <tr>
        <td style="height: 20px; width:600px;">
        <span class="colortitle"><b>&nbsp;Policy of ApnerDeal&nbsp; services</b></span>
        </td>
        </tr>
   </table>
   
   <table style="border-top: #efefe2 1px solid; color: #000000" class="cptable" cellspacing="0"
            cellpadding="5" width="100%" border="0">
           <tr>
           <td style="width: 800px">
            <span class="DiscountContent"><b>Please select one of the packages below - you can change the options later if you like</b></span>
            </td>
           </tr>
            <tr>
                    <td style="height: 30px; width: 860px;" align="left">
                    <table style="width: 860px">
                    <tr>
                    <td valign="top" style="width:380px; height:auto;">
                      <table>
                      <tr>
                      <td>
                      <asp:RadioButtonList ID="DiscountType" runat="server" Width="375px" Font-Bold="False"
                            Height="72px">
                            <asp:ListItem Value="1">Premium Package&lt;br /&gt;&lt;br /&gt;&lt;br /&gt;For any query and more detail please email us at:  &lt;a href=&quot;mailto:info@ApnerDeal.com &quot;&gt;info@ApnerDeal.com &lt;/a&gt;&lt;br /&gt;</asp:ListItem>
                        </asp:RadioButtonList>
                      </td>
                      <td>
                      <asp:RequiredFieldValidator ID="discountTypeRequiredFieldValidator" runat="server"
                            Font-Bold="True" ControlToValidate="DiscountType" ErrorMessage="Select Discount Member Type"
                            SetFocusOnError="True">?</asp:RequiredFieldValidator>
                      </td>
                      </tr>
                      </table>
                    </td>
                    <td valign="top" style="height: 25px; width: 460px;">
                    <table>
                    <tr>
                    <td class="DiscountContent" valign="top">
                    <li style="text-align: justify">Discount offer will be listed at ApnerDeal</li><p>
                            </p>
                        <li style="text-align: justify">Discount offer will be emailed to all ApnerDeal registered Users</li><p>
                            </p>
                        <li style="text-align: justify">Your company will be displayed under Featured Store at ApnerDeal Page</li><p>
                            </p>
                    </td>
                    </tr>
                    </table>
                    </td>
                    </tr>
                    </table>
                     </td>
                </tr>
                
                <tr>
                <td style="width: 860px">
                <table style="width: 860px">
                <tr>
                <td style="height: 25px; width: 860px;">
                 <span class="colortitle"><b>Please select from the option to continue:</b></span>
                 </td>
                </tr>
                <tr>
                <td align="center" style="width: 860px">
                    <asp:RadioButtonList ID="policyRadioButtonList" runat="server" RepeatDirection="Horizontal" Width="590px">
                     <asp:ListItem Selected="True" Value="1">I have read policy &amp; accept it</asp:ListItem>
                    <asp:ListItem Value="2">I do not accept terms</asp:ListItem>
                    </asp:RadioButtonList>
                 </td>
                </tr>
                </table>
                </td>
                </tr>
                <tr>
                    <td align="center" style="width: 799px">
                      <asp:Button ID="btnNextPage" OnClick="btnNextPage_Click" runat="server" BorderStyle="Groove"
                            Text="Continue" CssClass="image_btn"></asp:Button>
                    </td>
                </tr>
   </table>
   
   </div>
   
</asp:Content>

