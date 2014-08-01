<%@ Control Language="C#" AutoEventWireup="true" CodeFile="InsideDhaka_RealEstate_Ctrl.ascx.cs" Inherits="UserControl_InsideDhaka_RealEstate_Ctrl" %>

<div class="leftContent" style="width:165px; padding:0px; margin:0px; border:1px solid #C9E1F4">
    <div class="header" style="margin-top:0px;">
    Inside Dhaka
    </div>
    <div class="top10ContentList" style="padding:10px 0px 5px 5px;" >
    <asp:Repeater ID="repProvince" runat="server" OnItemCommand="repProvince_ItemCommand">
    
         <ItemTemplate> 
            <div style="width:110px; cursor:pointer; padding-left:2px; margin:0px;">
            <asp:LinkButton 
                ID="lbtnArea" 
                runat="server" 
                CssClass="onHoverBlue"
                CommandArgument='<%# Eval("AreaID") %>'>
                
                 <%#Eval("Area") %>(<%#Eval("NumberOfClassifiedProduct")%>)
                
            </asp:LinkButton>
            </div>      
        
            </ItemTemplate>
            
    </asp:Repeater>
            
    </div>
</div>