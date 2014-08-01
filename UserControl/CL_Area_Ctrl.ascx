<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CL_Area_Ctrl.ascx.cs" Inherits="UserControl_CL_Area_Ctrl" %>

<style type="text/css">
div.hover
{
background:#0088CC none repeat scroll 0 0;
color:#FFFFFF;
}

</style>

<table width="99%" cellpadding="0px" cellspacing="0px" style="border:1px solid #C9E1F4; margin-top:10px;">
    <tr style="padding:0px;">
    <td>
    <asp:DataList 
        ID="dlstArea" 
        runat="server"  
        DataMember="AreaID"  
        ItemStyle-HorizontalAlign="justify"
        Font-Names="Verdana" 
        HeaderStyle-Height="20px"
        RepeatLayout="table" 
        
        CaptionAlign="Top" RepeatColumns="2" OnItemCommand="dlstArea_ItemCommand">
        <HeaderStyle BackColor="#EFEFE2" HorizontalAlign="Center" Width="99%" Height="20px"/>
        
        <HeaderTemplate> 
        <span class="price" style="font-size:14px; " >
        Inside Dhaka
        </span>
        </HeaderTemplate>
            
            <ItemTemplate> 
            <div style="width:110px; cursor:pointer; padding-left:2px; margin:0px;">
            <asp:LinkButton 
                ID="lbtnArea" 
                runat="server" 
                CssClass="onHoverBlue leftLinkFontSize"
                CommandArgument='<%# Eval("AreaID") %>'>
                
                
                        <%#Eval("Area") %>(<%#Eval("NumberOfClassifiedProduct")%>)
                                       
                                  
                
            </asp:LinkButton>
            </div>      
        
            </ItemTemplate>
        <ItemStyle HorizontalAlign="justify" />
    </asp:DataList>
    
    </td>
    </tr>
    </table>