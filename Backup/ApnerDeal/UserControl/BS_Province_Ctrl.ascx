<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BS_Province_Ctrl.ascx.cs" Inherits="UserControl_BS_Province_Ctrl" %>


    
    
<div class="leftContent" style="width:165px; padding:0px; margin:0px; border:1px solid #C9E1F4">
    <div class="header" style="margin-top:0px;">
    Location
    </div>
    <div class="top10ContentList" style="padding:10px 0px 5px 5px;" >
    <asp:Repeater ID="repProvince" runat="server" OnItemCommand="repProvince_ItemCommand">
        <ItemTemplate>
            <asp:LinkButton 
                ID="lbtnProvince" 
                runat="server"
                CausesValidation="false" CssClass="onHoverBlue"
                CommandArgument='<%# Eval("ProvinceID") %>'>
                
                    <%#Eval("Province") %><br />
                
            </asp:LinkButton>
        </ItemTemplate>
    </asp:Repeater>
            
    </div>
</div>
