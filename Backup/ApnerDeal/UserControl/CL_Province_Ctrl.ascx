<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CL_Province_Ctrl.ascx.cs" Inherits="UserControl_CL_Province_Ctrl" %>
<table width="99%" cellpadding="0px" cellspacing="0px" style="border:1px solid #C9E1F4; margin-top:10px;">
    <tr style="padding:0px;">
    <td >
    <asp:DataList 
        ID="dlstProvince" 
        runat="server"  
        DataMember="ProviceID"  
        ItemStyle-HorizontalAlign="justify"
        Font-Names="Verdana" 
        Font-Size="11px" 
        HeaderStyle-Height="20px"
        RepeatLayout="table" 
        
        CaptionAlign="Top" RepeatColumns="2" OnItemCommand="dlstProvince_ItemCommand">
        <HeaderStyle BackColor="#EFEFE2" HorizontalAlign="Center" Width="99%" Height="20px"/>
        
        <HeaderTemplate> 
        <div style="width:99%">
        <span class="price" style="font-size:14px; " >
        Outside Dhaka
        </span>
        </div>
        </HeaderTemplate>
            
            <ItemTemplate> 
            <div style="width:110px; cursor:pointer; padding-left:2px; margin:0px;">
           <asp:LinkButton 
                ID="lbtnProvince" 
                runat="server" 
                CssClass="onHoverBlue leftLinkFontSize"
                CommandArgument='<%# Eval("ProvinceID") %>'>
                <%#Eval("Province") %>(<%#Eval("NumberOfClassifiedProduct")%>)
            </asp:LinkButton>
            </div>
        
            </ItemTemplate>
        <ItemStyle HorizontalAlign="Justify" />
    </asp:DataList>
    
    </td>
    </tr>
    </table>
