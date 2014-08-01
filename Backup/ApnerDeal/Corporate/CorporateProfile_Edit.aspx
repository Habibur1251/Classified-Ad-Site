<%@ Page Language="C#" MasterPageFile="~/Corporate/MPCorporate2.master" AutoEventWireup="true" CodeFile="CorporateProfile_Edit.aspx.cs" Inherits="Corporate_CorporateProfile_Edit" Title="www.apnerdeal.com – Edit Corporate Profile." %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div align="right" class="top_secondary_link">
    <a href="Default.aspx">Sign out</a>
</div>

<span class="pageTitle">Edit Corporate Profile.</span>
<br /><br />

<table width="100%" border="0" cellspacing="0" cellpadding="0">
   <tr>
   <td>&nbsp;</td>
   <td align="right">Fields marked by <span class="mandatory">*</span> are mandatory</td>
   </tr>
   
   <tr>
   <td colspan="2" align="left" style="font-size:11px;">
   <asp:ValidationSummary 
        ID="ValidationSummary1" 
        runat="server" 
        Width="500px" 
        BackColor="#FFFFFF" 
        ForeColor="Black" 
        Font-Bold="False" 
        HeaderText="<table><tr><td style='padding-left:10px; padding-top:7px;'><img src='../images/icon_error.gif' width='42' height='40' alt='' /></td><td valign='middle' style='font-weight:bold; text-decoration:underline;color:#ED0000;'>Following error occured :</td></tr></table>" 
        BorderStyle="Dashed" 
        BorderWidth="1px"/>                 
   <asp:Label ID="lblSystemMessage" runat="server" ForeColor="Red" EnableViewState="False" Width="500px" Font-Size="11px"></asp:Label>                                        
   </td>
   </tr>
</table>
<table width="100%" border="0" cellspacing="0" cellpadding="0" class="cptable" style="border-top:1px solid #EFEFE2;" id="TABLE1">
    <tr>
    <td colspan="2" style="height:37px; color:#365EBF; text-decoration:underline;"><strong>Login Information </strong></td>
    </tr>

    <tr>
    <td width="200" style="height: 25px">Email:<span class="mandatory">*</span></td>
    <td style="height: 25px">
    <asp:TextBox 
        ID="txtLoginEmail1" 
        runat="server" 
        Width="180px" 
        Height="15px"                        
        MaxLength="100" CssClass="textbox">
    </asp:TextBox>
    <asp:RequiredFieldValidator 
        ID="rfvLoginEmail1" 
        runat="server" 
        ControlToValidate="txtLoginEmail1" 
        ErrorMessage="Email address field is blank! Please type your Email address properly." 
        SetFocusOnError="true" Font-Bold="True">?</asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator 
        ID="revLoginEmail1" 
        runat="server" 
        ControlToValidate="txtLoginEmail1" 
        ErrorMessage="Invalid Email address! Please type your valid Email address." 
        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
        Font-Bold="True">?</asp:RegularExpressionValidator>       
    <span class="gray11px">(this will be your Login ID.)</span>        
    </td>
    </tr>

    <tr>
    <td>Re-enter Email:<span class="mandatory">*</span></td>
    <td>
    <asp:TextBox 
        ID="txtLoginEmail2" 
        runat="server"             
        Width="180px" 
        Height="15px" 
        MaxLength="100" CssClass="textbox">
    </asp:TextBox>
    <asp:RequiredFieldValidator 
        ID="rfvLoginEmail2" 
        runat="server" 
        ControlToValidate="txtLoginEmail2" 
        ErrorMessage="Email confirmation field is blank! Please re-type your Email address properly." 
        SetFocusOnError="true" Font-Bold="True">?</asp:RequiredFieldValidator>
    <asp:RegularExpressionValidator 
        ID="revLoginEmail2" 
        runat="server" 
        ControlToValidate="txtLoginEmail2" 
        ErrorMessage="You re-type an invalid Email address! Please type your valid Email address." 
        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
        Font-Bold="True">?</asp:RegularExpressionValidator>
    <br />            
    <asp:CompareValidator 
        ID="cmvEmail" 
        runat="server" 
        ControlToCompare="txtLoginEmail1"
        ControlToValidate="txtLoginEmail2" 
        ErrorMessage="Your re-typed Email address does not match!  Please type the same Email address in both fields." 
        Font-Size="11px">
    </asp:CompareValidator>        
    </td>
    </tr>
            
    <tr>
    <td colspan="2" style="height:37px; color:#365EBF; text-decoration:underline;"><strong>Corporate Details</strong></td>
    </tr>

    <tr>
    <td style="height: 25px">Company Name:<span class="mandatory">*</span></td>
    <td style="height: 25px">
    <asp:TextBox 
        ID="txtCompanyName" 
        runat="server"             
        Width="345px" 
        Height="15px" 
        MaxLength="250" CssClass="textbox">
    </asp:TextBox>
    <asp:RequiredFieldValidator 
        ID="rfvCompanyName" 
        runat="server"
        ControlToValidate="txtCompanyName"
        ErrorMessage="Company Name field is blank! Please type your Company Name properly." 
        SetFocusOnError="true" Font-Bold="True">?</asp:RequiredFieldValidator>        
    </td>
    </tr>        

    <tr>
    <td>Business Type:<span class="mandatory">*</span></td>
    <td>
    <asp:DropDownList 
        ID="ddlBusinessType" 
        runat="server" 
        Width="258px" 
        AppendDataBoundItems="True">
        <asp:ListItem Text="Select" Value="-1"></asp:ListItem>
    </asp:DropDownList>
    <asp:RequiredFieldValidator 
        ID="rfvBusinessType" 
        runat="server" 
        ControlToValidate="ddlBusinessType" 
        InitialValue="-1"
        ErrorMessage="Business Type field is not selected! Please select your Business Type properly."             
        SetFocusOnError="True" Font-Bold="True">?</asp:RequiredFieldValidator>        
    </td>
    </tr>        

    <tr>
    <td style="height: 25px">Location:<span class="mandatory">*</span></td>
    <td style="height: 25px">
    <asp:DropDownList 
        ID="ddlCountry" 
        runat="server" 
        Width="180px" 
        AppendDataBoundItems="True">
        <asp:ListItem Text="Select" Value="-1"></asp:ListItem>            
    </asp:DropDownList>
    <asp:RequiredFieldValidator 
        ID="rfvCountry" 
        runat="server" 
        ControlToValidate="ddlCountry"
        InitialValue="-1"            
        ErrorMessage="Country name field is not selected! Please select the Country name properly."             
        SetFocusOnError="True" Font-Bold="True">?</asp:RequiredFieldValidator>        
    </td>
    </tr>        

    <tr>
    <td>Contact/Business Address:<span class="mandatory">*</span></td>
    <td>
    <asp:TextBox 
        ID="txtBusinessAddress" 
        runat="server"             
        Width="345px" 
        Height="60px" 
        TextMode="MultiLine" 
        MaxLength="300" CssClass="textbox">
    </asp:TextBox>
    <asp:RequiredFieldValidator 
        ID="rfvBusinessAddress" 
        runat="server" 
        ErrorMessage="Business Address field is blank! Please type your Business Address properly." 
        ControlToValidate="txtBusinessAddress" Font-Bold="True">?</asp:RequiredFieldValidator>

    </td>
    </tr>

    <tr>
    <td>Contact Phone:<span class="mandatory">*</span></td>
    <td>
    <asp:TextBox 
        ID="txtContactPhone" 
        runat="server"             
        Width="180px" 
        Height="15px" 
        MaxLength="50" CssClass="textbox">
    </asp:TextBox>
    <asp:RequiredFieldValidator 
        ID="rfvContactPhone" 
        runat="server" 
        ControlToValidate="txtContactPhone"
        ErrorMessage="Contact Phone number field is blank! Please type Contact Phone number properly."
        SetFocusOnError="True" Font-Bold="True">?</asp:RequiredFieldValidator>        
    </td>
    </tr>                        

    <tr>
    <td style="height: 25px">Web Site Address (URL):</td>
    <td style="height: 25px">
    <asp:TextBox 
        ID="txtCompanyURL" 
        runat="server"             
        Width="300px" 
        Height="15px" 
        MaxLength="100" CssClass="textbox">
    </asp:TextBox>        
    </td>
    </tr>                        

    <tr>
    <td>Billing Person:<span class="mandatory">*</span></td>
    <td>
    <asp:TextBox 
        ID="txtBillingPerson" 
        runat="server"             
        Width="345px" 
        Height="15px" 
        MaxLength="200" CssClass="textbox">
    </asp:TextBox>
    <asp:RequiredFieldValidator 
        ID="rfvBillingPerson" 
        runat="server" 
        ControlToValidate="txtBillingPerson"
        ErrorMessage="Billing Person field is blank! Please type Billing Person’s name properly." 
        SetFocusOnError="true" Font-Bold="True">?</asp:RequiredFieldValidator>        
    </td>
    </tr>                        

    <tr>
    <td>Inventory Manager:</td>
    <td>
    <asp:TextBox 
        ID="txtWebInventoryManager" 
        runat="server" 
        Width="345px" 
        Height="15px" 
        MaxLength="200" CssClass="textbox">
    </asp:TextBox>
    </td>
    </tr>                        

    <tr>
    <td>Company Profile:</td>
    <td>
    <asp:TextBox 
        ID="txtCompanyProfile" 
        runat="server"             
        Width="345px" 
        Height="150px" 
        TextMode="MultiLine" 
        MaxLength="400" CssClass="textbox">
    </asp:TextBox>        
    </td>
    </tr>
</table>

<br />
<span style="font-size:11px; padding-left:150px;">Our <a href="#" style="text-decoration:underline;">Terms of Use</a> and <a href="#" style="text-decoration:underline;">Privacy Policy</a>.</span>

<br /><br />

<div style="padding-left:200px;">
<asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="image_btn" OnClick="btnSubmit_Click"/>
</div>
<br />
</asp:Content>

