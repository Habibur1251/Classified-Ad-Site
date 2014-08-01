<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RealEstate_SecondSubcategory_List_Ctrl.ascx.cs" Inherits="UserControl_RealEstate_SecondSubcategory_List_Ctrl" %>

<div class="leftContent" style="width:165px; padding:0px; margin:0px; border:1px solid #C9E1F4">
    <div class="header" style="margin-top:0px;">
    Category
    </div>
    <div class="top10ContentList" style="padding:10px 0px 5px 5px; margin-top:none" >
    <asp:Repeater ID="repList" runat="server" OnItemCommand="repList_ItemCommand" >
        <ItemTemplate>
            <asp:LinkButton 
                ID="lbtnSecondSubcategory" 
                runat="server" CssClass="onHoverBlue"
                CausesValidation="false"
                CommandArgument='<%# Eval("SecondSubcatID") %>'>
                
                    <%#Eval("SecondSubcategory")%>(<%# Eval("NoOfProduct") %>)<br />
                
            </asp:LinkButton>
        </ItemTemplate>
    </asp:Repeater>
    </div>
</div>
