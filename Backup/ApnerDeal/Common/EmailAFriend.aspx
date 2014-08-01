<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EmailAFriend.aspx.cs" Inherits="Common_EmailAFriend" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<head runat="server">
    <title>Email a friend</title>
    <link href="../CSS/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="600px" border="0" style="margin-top: 20px" align="center" cellpadding="0"
            cellspacing="0">
            <tr>
                <td>
                    <img src="../images/logo.gif" width="260" height="91" alt="" />
                </td>
            </tr>
        </table>
    <asp:MultiView ID="multiview" runat="server" ActiveViewIndex="0" >
    <asp:View ID="View1" runat="server">
   
    <table width="600px" border="0" style="margin-top: 20px" align="center" cellpadding="0"cellspacing="0">
            <tr>
                <td colspan="3" style="background-color: #3B5998; font-weight: bold; color: White;
                    height: 25px; font-size: 14px">
                    Welcome to ApnerDeal Email a friend service
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <p style="word-break: normal; word-wrap: normal; padding: 5px" class="gray11px">
                        Welcome to Mail a Friend service of ApnerDeal.com . You can send information about
                        an item to your friend using this service. Your Friend will be notified about the
                        item/product through e-mail. To use this service you are required to provide the
                        following information:
                    </p>
                </td>
            </tr>
        </table>
        <table width="400px" border="0" style="margin-top: 20px" align="center" cellpadding="0"
            cellspacing="0">
            <tr>
                <td width="3px">
                    <img src="../images/title_bar_left.gif" alt="" width="3" height="28" /></td>
                <td width="300px" style="font-size: 14px; font-weight: bold; background-image: url(../images/title_bar_bg.gif);
                    background-repeat: repeat-x; padding-left: 5px;">
                    Email this product to a friend.
                </td>
                <td width="3px">
                    <img src="../images/title_bar_right.gif" alt="" width="3" height="28" /></td>
            </tr>
        </table>
        <table class="cptable" width="400px" border="0" style="margin-top: 20px; border-top: 1px solid rgb(213, 213, 213);"
            align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td style="width: 210px; height: 25px">
                    Name of your friend:<span class="mandatory"></span></td>
                <td style="height: 25px">
                    <asp:TextBox ID="txtFriendName" runat="server" CssClass="textbox" MaxLength="100"
                        Width="150px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvFriendName" runat="server" ControlToValidate="txtFriendName"
                        ErrorMessage="Please type your friends name.">?</asp:RequiredFieldValidator>
            </tr>
            <tr>
                <td style="width: 210px; height: 25px">
                    His/Her email address:<span class="mandatory"></span></td>
                <td style="height: 25px">
                    <asp:TextBox ID="txtFriendEmailAddress" runat="server" CssClass="textbox" MaxLength="100"
                        Width="150px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvFriendEmailAddress" runat="server" ControlToValidate="txtFriendEmailAddress"
                        ErrorMessage="Please type your friends email address.">?</asp:RequiredFieldValidator>
            </tr>
            <tr>
                <td style="width: 210px; height: 25px">
                    Your name:<span class="mandatory"></span></td>
                <td style="height: 25px">
                    <asp:TextBox ID="txtSenderName" runat="server" CssClass="textbox" MaxLength="100"
                        Width="150px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvSenderName" runat="server" ControlToValidate="txtSenderName"
                        ErrorMessage="Please enter your name.">?</asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="csvReq" runat="server" ErrorMessage="CustomValidator" OnServerValidate="csvReq_ServerValidate"></asp:CustomValidator>
            </tr>
            <tr>
                <td style="width: 210px; height: 25px">
                    &nbsp;
                <td style="height: 25px">
                    <asp:Button 
                        ID="btnSendEmail" 
                        runat="Server" 
                        Text="Send" 
                        CssClass="image_btn"
                        BorderStyle="Groove" 
                        OnClick="btnSendEmail_Click" />
            </tr>
        </table>
        <table width="400px" border="0" style="margin-top: 20px" align="center" cellpadding="0"
            cellspacing="0">
            <tr>
                <td>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                        ShowSummary="False" />
                </td>
            </tr>
            
        </table>
    </asp:View>
    
    
    <asp:View ID="View2" runat="server">
    <table width="600" border="0" style="margin-top: 20px" align="center" cellpadding="0"cellspacing="0">
            <tr>
                <td colspan="3" style="background-color: #3B5998; font-weight: bold; color: White;
                    height: 25px; font-size: 14px">
                    ApnerDeal Email a friend service
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <span style="text-align:center;" class="gray11px">
                        Your email has been sent to your friends email address.<br />
                        Thank you for using our service.
                        
                        
                        
                    </span>
                </td>
            </tr>
            <tr>
            <td colspan="2" style="text-align:center;padding-top:30px; ">
                <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
                <a href="#" style="vertical-align:middle;font-weight:bold; text-decoration:underline;" onclick="self.close();">Close this window</a>
            </td>
            </tr>
        </table>
    </asp:View>
    
    <asp:View ID="View3" runat="server">
      <table width="600" border="0" style="margin-top: 20px" align="center" cellpadding="0"cellspacing="0">
            <tr>
                <td colspan="3" style="background-color: #3B5998; font-weight: bold; color: White;
                    height: 25px; font-size: 14px">
                    ApnerDeal Email a friend service
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <p style="word-break: normal; word-wrap: normal; padding: 5px" class="gray11px">
                        There has been some problem sending your mail. Please try after some time.
                    </p>
                </td>
            </tr>
             <tr>
                <td colspan="2" style="height: 8px; padding-top:50px">
                    <asp:Button 
                        ID="btnPrev" 
                        runat="server"  
                        BorderStyle="Groove" 
                        OnClick="btnPrev_Click" 
                        CssClass="image_btn_left"
                        Text="Try Again" />
                </td>
            </tr>
        </table>
    
    </asp:View>
    </asp:MultiView>
    </div>
    </form>
</body>
</html>
