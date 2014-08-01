<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ViewCart_Ctrl.ascx.cs" Inherits="UserControl_ViewCart_Ctrl" %>

<table width="102px" border="0px" cellspacing="0px" cellpadding="0px" style="margin-right: 10px;">
    <tr>
        <td style="height: 35px;">
            <a href='<%=this.VirtualPath_Prefix %>Common/ShoppingCart.aspx' style="border: none;">
                <img src="<%=this.VirtualPath_Prefix %>Images/viewcartbtn.png" alt="" width="92px" height="25px" border="none" />
            </a>
        </td>
    </tr>
    <tr>
    <td>
    <!--span class="price gray11px">Cart Summary</span><br /-->
    <a class="onHoverRedLink " href="<%=this.VirtualPath_Prefix %>Common/ShoppingCart.aspx" style="border: none; font-size:10px">
    <%=this._CartSummary%>
    </a>
    </td>
    </tr>
</table>
