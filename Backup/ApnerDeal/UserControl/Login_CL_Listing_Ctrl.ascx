<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Login_CL_Listing_Ctrl.ascx.cs" Inherits="UserControl_Login_CL_Listing_Ctrl" %>


<div class="set2_t" style="width:100%; margin-bottom:10px;">
                <div class="set2_b">
                    <div class="set2_l">
                        <div class="set2_r">
                            <div class="set2_bl">
                                <div class="set2_br">
                                    <div class="set2_tl">
                                        <div class="set2_tr" style=" padding:15px;">
                                            <strong>Login to ApnerDeal Classified </strong>&nbsp;&nbsp;<br /><br />
                                            <br />
                                            <table cellpadding="0px" cellspacing="0px" border="0px" align="center">
                                                <tr>
                                                    <td>
                                                        User name<br />
                                                        <asp:TextBox ID="txtLoginEmail" runat="server" Width="150px" MaxLength="100" CssClass="textbox">
                                                        </asp:TextBox><asp:RequiredFieldValidator ID="rfvLoginEmail" runat="server" ErrorMessage="Please type your Login Email."
                                                            ControlToValidate="txtLoginEmail" SetFocusOnError="True" Font-Bold="False" Display="Dynamic"
                                                            Font-Size="11px" ValidationGroup="login"></asp:RequiredFieldValidator><asp:RegularExpressionValidator
                                                                ID="revLoginEmail" runat="server" ErrorMessage="Please type your valid Login Email address."
                                                                ControlToValidate="txtLoginEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                                Font-Bold="False" Display="Dynamic" Font-Size="11px" ValidationGroup="login"></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Password&nbsp;<br />
                                                        <asp:TextBox ID="txtPassword" runat="server" Width="150px" MaxLength="15" TextMode="Password"
                                                            CssClass="textbox">
                                                        </asp:TextBox><asp:RequiredFieldValidator ID="rfvPassword" runat="server" ErrorMessage="Password field is blank ! "
                                                            Font-Bold="False" SetFocusOnError="True" ControlToValidate="txtPassword" Display="Dynamic"
                                                            Font-Size="11px" ValidationGroup="login"></asp:RequiredFieldValidator><asp:Label
                                                                ID="lblSystemMessage" runat="server" ForeColor="Red" Font-Size="11px"></asp:Label><br />
                                                        <br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center">
                                                        <asp:Button ID="btnLogin" runat="server" CssClass="image_btn1" OnClick="btnLogin_Click"
                                                            Text="" Width="108px" ValidationGroup="login" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center">
                                                        <a style="font-size: 11px" onclick="javascript:window.open('<%=this.ForgotPassWordLink %>','plyr_pop','width=600,height=390,toolbar=no,location=no,directories=no,status=no,menubar=no,scrollbars=yes,resizable=no');"
                                                            class="onHoverRedLink" href="javascript:void(0)">Forgot Password?</a>
                                                        <br />
                                                        <a class="onHoverRedLink" href="Corporate/Default.aspx" style="font-size: 11px;">Create
                                                            New User</a>
                                                        <br />
                                                    </td>
                                                </tr>
                                            </table>
                                            
                                            
                                            
            
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>