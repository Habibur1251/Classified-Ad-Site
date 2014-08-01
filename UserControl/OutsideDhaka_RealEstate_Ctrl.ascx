<%@ Control Language="C#" AutoEventWireup="true" CodeFile="OutsideDhaka_RealEstate_Ctrl.ascx.cs" Inherits="UserControl_OutsideDhaka_RealEstate_Ctrl" %>


<div class="leftContent" style="width:165px; padding:0px; margin:0px; border:1px solid #C9E1F4">
    <div class="header" style="margin-top:0px;">
    Outside Dhaka
    </div>
    <div class="top10ContentList" style="padding:10px 0px 5px 5px;" >
    <asp:Repeater ID="repProvince" runat="server" OnItemCommand="repProvince_ItemCommand">
    
        <ItemTemplate> 
            <div style="width:110px; cursor:pointer; padding-left:2px; margin:0px;">
           <asp:LinkButton 
                ID="lbtnProvince" 
                runat="server" 
                CssClass="onHoverBlue"
                CommandArgument='<%# Eval("ProvinceID") %>'>
                <%#Eval("Province") %>(<%#Eval("NumberOfClassifiedProduct")%>)
            </asp:LinkButton>
            </div>
        
            </ItemTemplate>
    </asp:Repeater>
            
    </div>
</div>
