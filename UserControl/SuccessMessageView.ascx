<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SuccessMessageView.ascx.cs"
    Inherits="UserControl_SuccessMessageView" %>
<table width="100%" border="0" cellspacing="0" cellpadding="0" style="margin-top: 25px">
    <tr>
        <td style="width: 20px; height: 25px">
         </td>
        <td style="height: 25px" >
            <%=UTLUtilities.ShowSuccessMessage("Your Product/Ad Successfully Posted.") %>
        </td>
    </tr>
    <tr>
        <td style="margin-top: 20px; font-weight:bold; padding-left: 20px; padding-top:20px; line-height: 20px"
            colspan="2">
            <a href="Product_ManagementCL.aspx" class="onHoverRedLink" style="font-weight: bold">Click
                Here</a> to add another product. Or you can revisit your 
            <a href="ControlPanel.aspx" class="onHoverRedLink" style="font-weight: bold">
                Control Panel </a>
        </td>
    </tr>
</table>
