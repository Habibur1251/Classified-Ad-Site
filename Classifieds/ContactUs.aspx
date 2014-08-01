<%@ Page Language="C#" MasterPageFile="~/Classifieds/MPClassifieds2.master" AutoEventWireup="true" CodeFile="ContactUs.aspx.cs" Inherits="Classifieds_ContactUs" Title="www.ApnerDeal.com – Classified User Control Panel." %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<img src="../images/email1.jpg" width="108" height="119" align="middle" style="margin-right:10px;" alt="" />
<span class="pageTitle">Classifieds - Contact ApnerDeal.com</span>
<br /><br />
<table width="100%" border="0px" cellspacing="0px" cellpadding="0" class="cptable" style="border-top:1px solid #EFEFE2;">    
    <!--BEGIN: PRODUCT DETAILS-->
    <tr>
    <td align="right">Fields marked by <span class="mandatory">*</span> are mandatory</td>
    </tr>
   
    <tr>
    <td align="left" style="font-size:11px;">
    <asp:ValidationSummary 
        ID="ValidationSummary1" 
        runat="server" 
        Width="500px" 
        BackColor="#FFFFFF" 
        ForeColor="Black" 
        Font-Bold="False" 
        HeaderText="<table><tr><td style='padding-left:10px; padding-top:7px;'><img src='../images/icon_error.gif' width='42' height='40' alt='' /></td><td valign='middle' style='font-weight:bold; text-decoration:underline;color:#ED0000;'>Following error occured :</td></tr></table>" 
        BorderStyle="Dashed" 
        BorderWidth="1px" 
        Font-Size="11px"/>                 
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

    <tr>
    <td style="height: 27px; text-align:left; width: 813px;">Your Email:<span class="mandatory">*</span></td>    
    </tr>

    <tr>
    <td style="height: 27px; text-align:left; width: 813px;">
    <asp:TextBox ID="txtEmail" runat="server" CssClass="textbox" MaxLength="100" Width="450px"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:RequiredFieldValidator 
        ID="rfvEmail" 
        runat="server" 
        ControlToValidate="txtEmail"
        ErrorMessage="Email address field is blank! Please type your Email address properly."
        Font-Bold="True" 
        SetFocusOnError="True">?</asp:RequiredFieldValidator>
    &nbsp;
    <asp:RegularExpressionValidator 
        ID="revEmail" 
        runat="server" 
        ControlToValidate="txtEmail"
        ErrorMessage="Invalid Email address! Please type your valid Email address properly." 
        Font-Bold="True"
        SetFocusOnError="True" 
        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">?</asp:RegularExpressionValidator>    
    </td>    
    </tr>
    
    <tr>
    <td style="height: 27px; text-align:left; width: 813px;">Subject:<span class="mandatory">*</span></td>
    </tr>

    <tr>
    <td style="text-align:left; width: 813px;">
    <asp:TextBox ID="txtSubject" runat="server" CssClass="textbox" Width="450px" MaxLength="150"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:RequiredFieldValidator 
        ID="rfvSubject" 
        runat="server" 
        ControlToValidate="txtSubject"
        ErrorMessage="Subject field is blank! Please type your Email Subject properly."
        Font-Bold="True" 
        SetFocusOnError="True">?</asp:RequiredFieldValidator>    
    </td>
    </tr>
    

    <tr>
    <td valign="middle" style="height: 27px; width: 813px;">Your Message:<span class="mandatory">*</span></td>
    </tr>

    <tr>
    <td valign="top" style="text-align:left; width: 813px;">    
    <asp:TextBox ID="txtMessage" runat="server" CssClass="textbox" Height="180px" TextMode="MultiLine" Width="450px" MaxLength="400"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:RequiredFieldValidator 
        ID="rfvMessage" 
        runat="server" 
        ControlToValidate="txtMessage"
        ErrorMessage="Message field is blank! Please type your Email Message."
        Font-Bold="True" 
        SetFocusOnError="True">?</asp:RequiredFieldValidator>        
    </td>
    </tr>
    
    <tr>
    <td valign="middle" align="left" style="height: 27px;width: 813px; padding-left:150px; padding-top:7px; padding-bottom:7px;">   
    <asp:Button ID="btnSendMail" runat="server" CssClass="image_btn" Text="Send" Width="102px" OnClick="btnSendMail_Click" /></td>
    </tr>    
</table>
</asp:Content>

