<%@ Page Language="C#" MasterPageFile="~/Classifieds/MPClassifieds1.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Classifieds_Default" Title="www.apnerdeal.com – Classifieds User Login."%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="1000" border="0px" align="center" cellpadding="0px" cellspacing="0px">
    <tr>
    <td height="50" class="pageTitle">Welcome to ApnerDeal.com Classified User Login</td>
    <td valign="top">&nbsp;</td>
    </tr>

    <tr>
    <td height="210" valign="top" style="padding-right:20px;">
    <div class="t" style="width:100%">
       <div class="b">
          <div class="l">
             <div class="r">
                <div class="bl">
                   <div class="br">
                      <div class="tl">
                         <div class="tr" style="height:260px; padding:20px;">
                         <span style="color:#E47911">
                             <strong>New in ApnerDeal.com ? Register here as Classified user</strong></span>.......<br />
                             <p>Register as a ApnerDeal.com Classified User and enjoy privileges including:</p>
                             <ul style="margin-left:10px;padding-left:10px; line-height:2">
                                <li>Post advertisement in our classified section.</li><li>Edit your advertisement.</li><li>Manage advertisement feedback using just your email.</li></ul>
                             <br />                             
                             <a href="../Corporate/UserProfile_Step01.aspx"><img src="../images/btn_register.gif" alt="Register" width="141" height="30" border="0px" id="IMG1" /></a>&nbsp;
                             <br />
                         </div>
                      </div>
                   </div>
                </div>
             </div>
          </div>
       </div>
    </div>
    </td>

    <td width="355" valign="top">
    <div class="set2_t" style="width:100%">
       <div class="set2_b">
          <div class="set2_l">
             <div class="set2_r">
                <div class="set2_bl">
                   <div class="set2_br">
                      <div class="set2_tl">
                         <div class="set2_tr" style=" padding:15px;">
                         <span style="color:#E47911">
                         <strong>Sign in to your Classified User Control Panel</strong>
                         </span>
                         <br />
                         <br />
                         <br />
                         <table width="90%" border="0px" align="center" cellpadding="0px" cellspacing="0">
                            <tr>
                            <td colspan="2">
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" Width="300px" ShowMessageBox="True" HeaderText="Following error occurred:" Font-Size="11px"/>                                        
                            </td>
                            </tr>
                         
                            <tr>
                            <td height="30">Login Email</td>
                            <td>
                            <asp:TextBox 
                                ID="txtLoginEmail" 
                                runat="server" 
                                Width="150px" 
                                MaxLength="100" 
                                CssClass="textbox">
                            </asp:TextBox>
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
                            <br />
                            </td>
                            </tr>
                            
                            <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            </tr>
                            
                            <tr>
                            <td height="30">Password</td>
                            <td>
                            <asp:TextBox 
                                ID="txtPassword" 
                                runat="server" 
                                Width="150px" 
                                MaxLength="15" 
                                TextMode="Password" 
                                CssClass="textbox">
                            </asp:TextBox>                            
                            <asp:RequiredFieldValidator 
                                ID="rfvPassword" 
                                runat="server" 
                                ErrorMessage="Password field is blank ! " 
                                Font-Bold="True" 
                                SetFocusOnError="True" ControlToValidate="txtPassword">?</asp:RequiredFieldValidator>
                            </td>
                            </tr>
                           
                            <tr>
                            <td>&nbsp;</td>
                            <td>
                            <a style="font-size: 11px" onclick="javascript:window.open('../ForgotPassword.aspx','plyr_pop','width=600,height=390,toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=yes,resizable=no');"
            class="onHoverRedLink" href="javascript:void(0)">Forgot Password?</a>
                            </td>
                            </tr>

                            <tr>                           
                            <td colspan="2" style="height: 14px; padding-top:3px;">
                            <asp:Label ID="lblSystemMessage" runat="server" ForeColor="Red" EnableViewState="False" Width="300px" Font-Size="11px"></asp:Label>                            
                            </td>
                            </tr>                            
                         </table>
                         <!--
                         <br />
                         <input type="checkbox" name="checkbox" id="checkbox"/>
                         <span class="gray11px"> <strong>Keep me signed in for today.</strong> Don't check this<br />
                         <img src="../images/pix.gif" width="20" height="10" alt="" /> box if you're at a public or shared computer.</span>
                         <br />
                         &nbsp;
                         -->                         
                         <br />
                         <div align="right">
                         <!--input type="image" src="../images/btn_login.png" alt="Login" width="96" height="29" id="Image1" /-->
                         <asp:Button ID="btnLogin" runat="server" CssClass="image_btn1" OnClick="btnLogin_Click"/>                         
                         </div>
                        
                      </div>
                   </div>
                </div>
             </div>
          </div>
       </div>
    </div>
    </div>
    
    <%-- <div align="center">
                         <strong>
                         <a class="onHoverRedLink colortitle" 
                            target="_blank" 
                            style="vertical-align:bottom; font-weight:bold;"
                            href='../Common/CampaignLandingPage.aspx'>
                            Participate to win a laptop..
                         </a>
                         </strong>
                         </div>--%>
    </td>
    </tr>
</table>
</asp:Content>

