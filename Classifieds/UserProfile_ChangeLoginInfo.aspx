<%@ Page Language="C#" MasterPageFile="~/Classifieds/MPClassifieds2.master" AutoEventWireup="true" CodeFile="UserProfile_ChangeLoginInfo.aspx.cs" Inherits="Classifieds_UserProfile_ChangeLoginInfo" Title="www.apnerdeal.com – Change Login Information." %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<span class="pageTitle">Classifieds - Change Login Password.</span><br />
<span class="gray11px" style="font-weight:normal; margin-top:7px;">ApnerDeal.com is absolutely <strong style="color:#EC2024;">FREE</strong> for posting classified Ads. It will not cost you anything.</span>
<br /><br />
<table width="100%" border="0px" cellspacing="0px" cellpadding="0px">
   <tr>
   <td>&nbsp;</td>
   <td align="right">
       Fields marked by <span class="mandatory">*</span> are mandatory</td>
   </tr>
   
   <tr>
   <td colspan="2" align="left" style="font-size:11px; height: 118px;">
   <asp:ValidationSummary 
        ID="ValidationSummary1" 
        runat="server" 
        Width="500px" 
        BackColor="#FFFFFF" 
        ForeColor="Black" 
        Font-Bold="False" 
        HeaderText="<table><tr><td style='padding-left:10px; padding-top:7px;'><img src='../images/icon_error.gif' width='42' height='40' alt='' /></td><td valign='middle' style='font-weight:bold; text-decoration:underline;color:#ED0000;'>Following error occured :</td></tr></table>" 
        BorderStyle="Dashed" 
        BorderWidth="1px" Font-Size="11px"/>                 
   <asp:Label 
        ID="lblSystemMessage" 
        runat="server" 
        ForeColor="Red" 
        EnableViewState="False" 
        Width="500px" 
        Font-Size="11px">
   </asp:Label>         
   </td>
   </tr>
</table>
<table width="100%" border="0px" cellspacing="0px" cellpadding="0px" class="cptable" style="border-top:1px solid #EFEFE2;">
    <!--BEGIN: LOGIN INFORMATION-->
    <tr>
    <td align="right">
    Old Password:<span class="mandatory">*</span>
    </td>
    
    <td align="left">
    <asp:TextBox 
        ID="txtOldPassword" 
        runat="server" 
        CssClass="textbox" 
        MaxLength="15" 
        Width="200px" 
        TextMode="Password">
    </asp:TextBox>
    &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:RequiredFieldValidator 
        ID="rfvPassword1" 
        runat="server"
        ErrorMessage="Old Password field is blank! Please type your Old Password properly." 
        ControlToValidate="txtOldPassword" 
        Font-Bold="True" 
        SetFocusOnError="True">?</asp:RequiredFieldValidator>
    <br />
    <asp:RegularExpressionValidator 
        ID="revPassword1" runat="server"
        ControlToValidate="txtOldPassword" 
        ErrorMessage="Your Old Password length is incorrect ! It should be minimum 5 to maximum 15 characters long."
        Font-Size="10px" 
        ValidationExpression="^.{5,15}$" 
        SetFocusOnError="True">
    </asp:RegularExpressionValidator>
    </td>
    </tr>

    <tr>
    <td align="right">New Password:<span class="mandatory">*</span></td>
    <td align="left">
    <asp:TextBox 
        ID="txtNewPassword1" 
        runat="server" 
        CssClass="textbox" 
        MaxLength="15" 
        Width="200px" 
        TextMode="Password">
    </asp:TextBox>
    &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:RequiredFieldValidator 
        ID="rfvNewPassword1" 
        runat="server"
        ErrorMessage="New Password field is blank! Please type your New Password properly." 
        ControlToValidate="txtNewPassword1" 
        Font-Bold="True" 
        SetFocusOnError="True">?</asp:RequiredFieldValidator>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <span class="gray11px">(5 to 15 characters long.)</span>                    
    <br />
    <asp:RegularExpressionValidator 
        ID="revNewPassword1" runat="server"
        ControlToValidate="txtNewPassword1" 
        ErrorMessage="Your New Password length is incorrect ! It should be minimum 5 to maximum 15 characters long."
        Font-Size="10px" 
        ValidationExpression="^.{5,15}$" 
        SetFocusOnError="True">
    </asp:RegularExpressionValidator>
    </td>
    </tr>
    
    <tr>
    <td align="right" style="height: 25px">Confirm new Password:<span class="mandatory">*</span></td>
    <td align="left" style="height: 25px">
    <asp:TextBox 
        ID="txtNewPassword2" 
        runat="server" 
        CssClass="textbox" 
        MaxLength="15" 
        Width="200px" 
        TextMode="Password">
    </asp:TextBox>
    &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:RequiredFieldValidator 
        ID="rfvNewPassword2" 
        runat="server" 
        ErrorMessage="Password confirmation field is blank! Please re-type your New Password properly." 
        ControlToValidate="txtNewPassword2" 
        Font-Bold="True" 
        SetFocusOnError="True">?</asp:RequiredFieldValidator>
    <br />    
    <asp:CompareValidator ID="cmvPassword" runat="server" ErrorMessage="Your re-typed password does not match!  Please type the same Password in both fields." ControlToCompare="txtNewPassword1" ControlToValidate="txtNewPassword2" Font-Size="10px" SetFocusOnError="True"></asp:CompareValidator>        
    </td>        
    </tr>
    <!--END: LOGIN INFORMATION-->
</table>
<br /><br />

<div style="padding-left:150px;">
<asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="image_btn" OnClick="btnSubmit_Click"/>
       <asp:Label ID="messageLabel" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Green"></asp:Label></div>
<br />

</asp:Content>

