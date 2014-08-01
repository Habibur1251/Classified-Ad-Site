<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ClassifiedSellerList.ascx.cs" Inherits="UserControl_ClassifiedSellerList" %>

<link href="../CSS/style.css" rel="stylesheet" type="text/css" />

<div class="leftContent" style="width:165px; padding:0px; margin:0px; border:1px solid #C9E1F4">
    <div class="header" style="margin-top:0px;">
    All Individual Seller
    </div>
    <div class="top10ContentList" style="padding:10px 0px 5px 5px; margin-top:none" >
    <asp:Repeater ID="repClassifiedSeller" runat="server" OnItemCommand="repClassifiedSeller_ItemCommand">
        <ItemTemplate>
            <asp:LinkButton 
                ID="btnClassifedSeller" 
                runat="server" 
                CausesValidation="false" CssClass="onHoverBlue"
                CommandArgument='<%# Eval("SubcategoryID") %>'>
                
                <%#Eval("Subcategory") %>(<%#Eval("NoOfSeller") %>)<br />
                
            </asp:LinkButton>
        </ItemTemplate>
    </asp:Repeater>
    </div>
</div>
