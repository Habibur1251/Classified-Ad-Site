<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ClassifiedSearchModule.ascx.cs" Inherits="UserControl_ClassifiedSearchModule" %>

<link href="CSS/catIcons.css" rel="stylesheet" type="text/css" />
   

<table id="cat_list" cellpadding="0px" cellspacing="0px" style="border:1px solid #C9E1F4; width: 202px;">
    <tr>
    <td align="center" style="width: 202px">
    <asp:Label ID="lblSystemMessage" runat="server" ForeColor="red" Font-Size="11px" EnableViewState="False" >
    </asp:Label>
    </td>
    </tr>
    <tr >
    <td style="width: 202px">
        <ul>
    <asp:GridView 
        ID="grvCategory" DataKeyNames="CategoryID,ImageClassName,Category,NoOfItems,Country"
        runat="server" Width="71%"
        AllowPaging="false" 
        GridLines="none"
        AutoGenerateColumns="false" HeaderStyle-Height="20px" OnRowDataBound="grvCategory_RowDataBound">
    <HeaderStyle  BackColor="#EFEFE2" Height="20px"/>
    <Columns>
    <asp:TemplateField>
    <HeaderTemplate>
    <span class="price" style="font-size:14px; font-weight:bold;" >
    All Categories
    </span>
    </HeaderTemplate>
    <ItemTemplate>
<li class="<%#Eval("ImageClassName") %>">
<a class="onHoverRedLink onHoverBlue" 
    style="font-size:11px" 
    href="ItemList_Classifieds.aspx?PageMode=0&CID=9&Location=<%#Eval("Country")%>" >
    <%#Eval("Category") %>
    (<%#Eval("NoOfItems") %>) 
</a>
                        </li>  
        </div>
    </ItemTemplate>
    </asp:TemplateField>
    
    </Columns>
    
    </asp:GridView>
    
    
    
            <li class="<%=ImageClassName %>"><a class="onHoverRedLink onHoverBlue" style="font-size: 11px"
                href="Common/ItemList_RealEstate.aspx?PageMode=1&CID=7&SCID=54&Location=<%=Country %>">
                Housing(<%=NoOfItems %>) </a>
            </li>
    </ul>
    </td>
    </tr>
    <tr>
    <td style="height:25px; width: 202px;">
    <ul>
    <asp:Repeater ID="repNegotiable" runat="server">
        <ItemTemplate>
        <li class="">
        <a class="onHoverBlue leftLinkFontSize" href="ItemList_Classifieds.aspx?PageMode=2&CID=<%=this.CategoryID %>">
            Negotiable(<%#DataBinder.Eval(Container.DataItem, "Negotiable") %>)
        </a>
        </li>
        </ItemTemplate>
    </asp:Repeater>
    </ul>
    </td>
    </tr>
    
    
    </table>