<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ClassifiedCategory_Ctrl.ascx.cs" Inherits="UserControl_ClassifiedCategory_Ctrl" %>
<table id="cat_list"  cellpadding="0px" cellspacing="0px" style="border: 1px solid #C9E1F4; margin:15px 0px;">
    <%--<tr>
        <td align="left" style="height: 19px">
        </td>
    </tr>--%>
    <tr>
        <td>
        <ul>
            <asp:GridView 
                ID="grvCategory" 
                DataKeyNames="CategoryID"
                runat="server" Width="99%"  AllowPaging="false" GridLines="none"
                AutoGenerateColumns="false" HeaderStyle-Height="20px" CellPadding="0" OnRowDataBound="grvCategory_RowDataBound">
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                        <div class="header" style="width:155px" >
                            <span style="font-size: 14px; color:#FFFFFF; font-weight: bold;">Classified Ads </span>
                        </div>
                        </HeaderTemplate>
                        <ItemTemplate>
                        
                        <li class="<%#Eval("ImageClassName") %>">
<a class="onHoverRedLink onHoverBlue" 
    style="font-size:11px" 
    href="../ItemList_Classifieds.aspx?PageMode=0&CID=<%# Eval("CategoryID")%>&Location=<%#Eval("Country")%>" >
        <%#Eval("Category") %>
        (<%#Eval("NoOfItems") %>) 
</a>
                        </li>  
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            
            <li class="<%=ImageClassName %>">
            <a class="onHoverRedLink onHoverBlue" style="font-size:11px" href="../Common/ItemList_RealEstate.aspx?PageMode=1&CID=7&SCID=54&Location=<%=Country %>">
            Housing(<%=NoOfItems %>)
            </a>
            </li>
            </ul>
            
            </td>
    </tr>
    <tr>
    <td>
        &nbsp;<asp:Label ID="lblSystemMessage" runat="server" ForeColor="red" Font-Size="11px"
                EnableViewState="False">
            </asp:Label></td>
    </tr>
</table>
