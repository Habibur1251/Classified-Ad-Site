<%@ Page Language="C#" MasterPageFile="~/Corporate/MPCorporate1.master" AutoEventWireup="true" CodeFile="UserProfile_Step02.aspx.cs" Inherits="Corporate_UserProfile_Step02" Title="ApnerDeal.com : User Registration." %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="1040px" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
        <td valign="top" style="padding-left:10px;padding-top:10px;padding-right:10px; height: 374px;">    
        <div align="right" class="top_secondary_link">&nbsp;</div>
        <img src="../images/email1.jpg" width="108" height="119" align="middle" style="margin-right:10px;" alt="" />    
        <span class="pageTitle">Check your Email.</span>                                 
        <br />
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
             <tr>
             <td>&nbsp;</td>
             <td align="left">
             <asp:Label ID="lblSystemMessage" runat="server" ForeColor="Red" EnableViewState="False" Width="300px" Font-Size="11px"></asp:Label>
             </td>
             </tr>

             <tr>
             <td>&nbsp;</td>
             <td height="20" align="right" valign="bottom"><div  class="step">Step 2 of 2</div></td>
             </tr>
        </table>
        <br /><br />
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="cptable" style="border-top:1px solid #EFEFE2;">
            <!--BEGIN: LOGIN INFORMATION-->
            <tr>
            <td style="height:37px; color:#365EBF;"><strong>Just one step more !</strong></td>
            </tr>
            
            <tr>
            <td valign="top" style="height:100px; padding-top:5px;">
            <ul>
            <li style="padding-bottom:7px;">
            We have sent an email to your address&nbsp;<asp:Label ID="lblEmailAddress" runat="server" ForeColor="#365EBF"></asp:Label>
            </li>
                       
            <li>
            If you do not find the mail in your Inbox, please check your Spam / Junk box.
            </li>
            
            <li>
             If you do not find the Registration Confirmation mail in your E-mail Inbox. Please email us to info@apnerdeal.com
            </li>
            
            </ul>
            </td>
            </tr> 
        </table>
        </td>
        </tr>         
    </table>
</asp:Content>

