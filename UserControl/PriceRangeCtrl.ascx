<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PriceRangeCtrl.ascx.cs" Inherits="UserControl_PriceRangeCtrl" %>

<asp:PlaceHolder ID="phPriceRange" runat="server">
<table width="230px" cellpadding="0px" cellspacing="0px" style="border:1px solid #C9E1F4; margin-top:10px">
    <tr>
        <td>
            <asp:Label ID="lblSystemMessage" runat="server" ForeColor="red" Font-Size="11px"
                EnableViewState="False">
            </asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Repeater ID="repPriceRange" runat="server" OnItemCommand="repPriceRange_ItemCommand">
                <HeaderTemplate>
                    <div class="price" style="font-size: 14px; font-weight: bold; text-align: center;
                        background-color: #EFEFE2">
                        Price
                    </div>
                </HeaderTemplate>
                <ItemTemplate>
                <div style="cursor:pointer; padding-left:2px; margin:0px;">
                    <asp:LinkButton 
                        ID="lbtnRange" 
                        runat="server" 
                        CssClass="onHoverBlue leftLinkFontSize"
                        CommandArgument='<%# Eval("PriceRangeID") %>'
                        CommandName="DisplayRange">
                        <%# Eval("LowerBound") %> - <%# Eval("UpperBound") %>   
                    </asp:LinkButton>
                </div>
                </ItemTemplate>
            </asp:Repeater>
        </td>
    </tr>
</table>

</asp:PlaceHolder>