<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/New.master" CodeFile="ForgotPassword.aspx.cs" Inherits="ForgotPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content" Runat="Server">
 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>Forgot Password</title>
    <link href="CSS/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" >
    <div>
    <table width="600" border="0" align="center" cellpadding="0" cellspacing="0">
    <tr>
    <td height="50" class="pageTitle colortitle" style="width: 1001px; padding:5px;">Forgot Password</td>
    </tr>

    <tr>
    <td height="210" valign="top" style="padding-right:20px; width: 50%;">
    <div class="t" style="width:100%px">
       <div class="b">
          <div class="l">
             <div class="r">
                <div class="bl">
                   <div class="br">
                      <div class="tl">
                         <div class="tr" style="height:200px; padding:20px;">
                         <%if(this.actionStatus == "Yes"){ %>
                              <strong>Check your inbox, we have sent an email with your login information.</strong>                         
                         <%} %>
                         <%if(this.actionStatus != "Yes"){ %>
                         <strong>Confirm your identity to retrieve password</strong>
                         <br /><br />
                         Enter your email address below and we will send you an email with your login credentials.
                         <br /><br /><br />
                         <table width="80%" border="0" align="left" cellpadding="0" cellspacing="0">
                            <tr>
                            <td colspan="2">
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" Width="300px" ShowMessageBox="True" HeaderText="Following error occurred:" Font-Size="11px"/>                                        
                            </td>
                            </tr>
                         
                            <tr>
                            <td height="30" align="right" style="padding-right:5px; width: 100px;">Login Email :</td>
                            <td>
                            <asp:TextBox 
                                ID="txtLoginEmail" 
                                runat="server" 
                                Width="250px" 
                                MaxLength="100" 
                                CssClass="textbox"></asp:TextBox>
                            <asp:RequiredFieldValidator 
                                ID="rfvLoginEmail" 
                                runat="server" 
                                ErrorMessage="Login Email field is blank! Please type your Login Email." 
                                ControlToValidate="txtLoginEmail" 
                                SetFocusOnError="True" 
                                Font-Bold="True">?</asp:RequiredFieldValidator>                            
                            <asp:RegularExpressionValidator 
                                ID="revLoginEmail" 
                                runat="server" 
                                ErrorMessage="Invalid Email address! Please type your valid Login Email address." 
                                ControlToValidate="txtLoginEmail" 
                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                Font-Bold="True">?</asp:RegularExpressionValidator>
                            </td>
                            </tr>

                            <tr>
                            <td height="30" style="width: 100px">&nbsp;</td>                           
                            <td style="height: 14px; padding-top:3px;">
                            <asp:Button ID="btnSubmit" runat="server" CssClass="image_btn" Text="Submit" Width="104px" OnClick="btnSubmit_Click"/>
                            <br />                            
                            </td>
                            </tr>
                                                        
                            <tr>                           
                            <td colspan="2" style="height: 14px; padding-top:3px;">
                            <asp:Label ID="lblSystemMessage" runat="server" ForeColor="Red" EnableViewState="False" Width="300px" Font-Size="11px"></asp:Label>                            
                            </td>
                            </tr>                            
                         </table>
                         <%}%>                         
                      </div>
                   </div>
                </div>
             </div>
          </div>
       </div>
    </div>
    <br />        
    </td>
    </tr>
</table>
    </div>
    </form>
</body>
</html>
</asp:Content>