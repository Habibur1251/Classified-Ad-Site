<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Login_Ctrl.ascx.cs" Inherits="UserControl_Login_Ctrl" %>
<link href="../CSS/style.css" rel="stylesheet" type="text/css" />
<div class="leftContent" style="width: 165px; padding: 0px; margin: 0px; border: 1px solid #C9E1F4">
    <div class="header" style="margin-top: 0px;">
        <span style="font-size: 7pt">
        Sign In to My ApnerDeal </span>
    </div>
    <div class="top10ContentList" style="padding: 0px;">
    <div style="padding-left:10px; margin-top:10px;">
    Email
    </div>
    
    <div style="padding-left:10px;">
    
    <asp:TextBox ID="txtLoginEmail" runat="server" Width="140px" MaxLength="100" CssClass="textbox"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvLoginEmail" runat="server" ErrorMessage="Please type your Login Email."
            ControlToValidate="txtLoginEmail" SetFocusOnError="True" Font-Bold="False" Display="Dynamic"
            Font-Size="11px" ValidationGroup="login"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="revLoginEmail" runat="server" ErrorMessage="Please type your valid Login Email address."
            ControlToValidate="txtLoginEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
            Font-Bold="False" Display="Dynamic" Font-Size="11px" ValidationGroup="login"></asp:RegularExpressionValidator>
        <br />
        
    </div>
    
    
    <div style="padding-left:10px;">
    Password
    </div>
    
    <div style="padding-left:10px;">
    <asp:TextBox ID="txtPassword" runat="server" Width="140px" MaxLength="15" TextMode="Password"
            CssClass="textbox"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ErrorMessage="Password field is blank ! "
            Font-Bold="False" SetFocusOnError="True" ControlToValidate="txtPassword" Display="Dynamic"
            Font-Size="11px" ValidationGroup="login"></asp:RequiredFieldValidator><br />
        <asp:Label ID="lblSystemMessage" runat="server" ForeColor="Red" Font-Size="11px"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnLogin" runat="server" CssClass="image_btn" OnClick="btnLogin_Click"
            Text="Login" Width="108px" ValidationGroup="login" />
    </div>
    
    <div style="text-align:center;">
    <a style="font-size: 11px" onclick="javascript:window.open('../ForgotPassword.aspx','plyr_pop','width=600,height=390,toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=yes,resizable=no');"
            class="onHoverRedLink" href="javascript:void(0)">Forgot Password?
            </a>
        
    </div>
    <div style="text-align:center">
    <a class="onHoverRedLink" href="../Corporate/Default.aspx" style="font-size:11px;">Create New User</a>
    </div>
    
    <div style="padding-left:10px;">
    
    </div>
        
        
        
        
                
    </div>
</div>
