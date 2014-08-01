<%@ Page Language="C#" MasterPageFile="~/Corporate/MPCorporate1.master" AutoEventWireup="true" CodeFile="UserProfile_Step03.aspx.cs" Inherits="Corporate_UserProfile_Step03" Title="www.ApnerDeal.com : User Registration." %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="1040px" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
        <td valign="top" style="padding-left:10px;padding-top:10px;padding-right:10px">    
        <div align="right" class="top_secondary_link">&nbsp;</div>
        <%if(this.intActionResult > 0){ %>
            <img src="../images/email1.jpg" width="108" height="119" align="middle" style="margin-right:10px;" alt="" />    
            <span class="pageTitle">Congratulation!</span> &nbsp; You have successfully register with www.ApnerDeal.com
            <br />
        <%} %>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
             <tr>
             <td style="height: 16px">&nbsp;</td>
             <td align="left" style="height: 16px">
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
             <td>&nbsp;</td>
             <td height="20" align="right" valign="bottom"><div  class="step">Step 3 of 3</div></td>
             </tr>
        </table>
        <br /><br />
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="cptable" style="border-top:1px solid #EFEFE2;">
            <!--BEGIN: LOGIN INFORMATION-->
            <tr>
            <td align="center" style="height:37px; color:#365EBF; width: 980px;">
            <%if(this.intActionResult > 0){ %>
                 Click <strong><a href="Default.aspx">here</a> </strong> if this page does not redirect
                within 5 seconds.        
            <%} %>                  
            </td>
            </tr>            
            <tr>
            <td valign="top" style="height:100px; padding-top:5px; width: 980px;">
            </td>
            </tr> 
        </table>    
        </td>
        </tr>         
    </table>
</asp:Content>

