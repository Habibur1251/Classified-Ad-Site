<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CorporateSellerList.ascx.cs" Inherits="UserControl_CorporateSellerList" %>

<link href="../CSS/style.css" rel="stylesheet" type="text/css" />

<div class="leftContent" style="width:165px; padding:0px; margin:0px; border:1px solid #C9E1F4">
    <div class="header" style="margin-top:0px;">
    List of Seller
    </div>
    <div class="top10ContentList" style="padding:10px 0px 5px 5px; margin-top:none" >
    <asp:Repeater ID="repCorporateSeller" runat="server" OnItemCommand="repCorporateSeller_ItemCommand">
        <ItemTemplate>
            <asp:LinkButton 
                ID="lbtnCorporateSeller" 
                runat="server" 
                CausesValidation="false" CssClass="onHoverBlue"
                CommandArgument='<%# Eval("ProfileID") %>'>
                
                <%#Eval("SellerInfo") %><br />
                
            </asp:LinkButton>
        </ItemTemplate>
    </asp:Repeater>
    </div>
</div>