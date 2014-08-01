<%@ Control Language="C#" AutoEventWireup="true" CodeFile="OuterViewCart_Ctrl.ascx.cs"
    Inherits="UserControl_OuterViewCart_Ctrl" %>
<table width="102px" border="0px" cellspacing="0px" cellpadding="0px" style="margin-right: 10px;">
    <tr>
        <td style="height: 35px;">
            <a href="Common/ShoppingCart.aspx" style="border: none;">
                <img src="../Images/viewcartbtn.png" alt="" border="none" />
            </a>
        </td>
    </tr>
    <tr>
    <td>
    <a class="onHoverRedLink " href="Common/ShoppingCart.aspx" style="border: none; font-size:11px">
    <%=this._CartSummary%>
    </a>
    </td>
    </tr>
</table>
