<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ClassifiedCounter.ascx.cs" Inherits="UserControl_ClassifiedCounter" %>                             
    <div style="width:425px;" class="set3_t">
    <div class="b">
        <div class="l">
            <div class="r">
                <div class="bl">
                    <div class="br">
                       <div class="set3_tl">
                            <div style="padding: 5px; " class="set3_tr">
                            <table style="width: 207px">
                            <tr>
                            <td style="width: 207px">
                            <strong class="latestTitle"><span style="font-size: 10pt; color:#3382D6; font-family: Verdana">Search Classified Ads</span></strong>
                            </td>
                            </tr>
                            </table>
                                <br />
<table id="cat_list" style="width: 373px;border-right: gainsboro 0px solid; border-top: gainsboro 0px solid; border-left: gainsboro 0px solid; border-bottom: gainsboro 0px solid;">

    <tr >
    <td style="width: 250px; height: auto;">
        <ul>
    <asp:GridView 
        ID="grvCategory" DataKeyNames="CategoryID,ImageClassName,Category,NoOfItems,Country"
        runat="server" Width="100%"
        AllowPaging="false" 
        GridLines="none"
       AutoGenerateColumns="false" HeaderStyle-Height="40px" OnRowDataBound="grvCategory_RowDataBound">
    <HeaderStyle BackColor="#ffffff" Height="0px"/>
    <Columns>
    <asp:TemplateField>
    <HeaderTemplate>
    <span class="latestTitle" style="font-size:12px; font-weight:bold;" >
    </span>
    </HeaderTemplate>
    <ItemTemplate>
<li class="<%#Eval("ImageClassName") %>">
<a target="_blank" class="onHoverRedLink onHoverBlue" 
    style="font-size:11px; color:#3382D6;" 
    href="ItemList_Classifieds.aspx?PageMode=0&CID=<%# Eval("CategoryID")%>&Location=<%#Eval("Country")%>" >
    <%#Eval("Category") %>
    (<%#Eval("NoOfItems") %>) 
</a>
</li> 
</div>
</ItemTemplate>
</asp:TemplateField> 

</Columns>
</asp:GridView>
    
            <li class="<%=ImageClassName %>"><a target="_blank" class="onHoverRedLink onHoverBlue" style="font-size: 11px;color:#3382D6;"
                href="Common/ItemList_RealEstate.aspx?PageMode=1&CID=7&SCID=54&Location=<%=Country %>">
                Housing(<%=NoOfItems %>)</a>
        <asp:Repeater ID="repNegotiable" runat="server">
        <ItemTemplate>
        <li class="">
        <a target="_blank" class="onHoverBlue leftLinkFontSize" style ="color:#3382D6;" href="ItemList_Classifieds.aspx?PageMode=2&CID=<%=this.CategoryID %>">
            Negotiable(<%#DataBinder.Eval(Container.DataItem, "Negotiable") %>)
        </a>
        </li>
        </ItemTemplate>
    </asp:Repeater>
        </li></ul>
    </td>
        <td style="width: 250px; height: auto">
    <br />
            <br />
<br />
            <br />
            </td>
        
    </tr>
    <tr>
    <td style="height:auto; width: 227px;">
     <asp:Label ID="lblSystemMessage" runat="server" ForeColor="red" Font-Size="11px" EnableViewState="False" >
    </asp:Label>
    </td> 
        <td style="width: 250px; height: auto">
        </td>
    </tr>
    </table>
                                &nbsp;&nbsp;
                                <br />
    <a target="_blank" class="onHoverBlue price smallfont" href="ItemList_Classifieds.aspx?PageMode=0&CID=12&Location=Bangladesh">
                                                 <span style="font-size:10px">View All Classified Ads.</span></a>
                                |
            <a target="_blank" class="onHoverBlue price smallfont" href="Classifieds/Default.aspx"><span style="font-size:10px">Post Classified Ads.</span></a></div>
    </div>
    </div>
    </div>
    </div>
    </div>
    </div>
    </div>