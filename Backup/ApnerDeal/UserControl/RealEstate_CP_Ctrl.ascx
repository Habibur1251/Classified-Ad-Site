<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RealEstate_CP_Ctrl.ascx.cs" Inherits="UserControl_RealEstate_CP_Ctrl" %>




    <table width="100%" border="0px" cellspacing="0px" cellpadding="0px">
    <tr>
    <td colspan="2" align="left" style="font-size:11px;">
        <asp:Label 
        ID="lblSystemMessage" 
        runat="server" 
        ForeColor="Red" 
        EnableViewState="False" 
        Width="500px" 
        Font-Size="11px">
    </asp:Label>                                        
    </td>
    </tr>
    <tr>
    <td valign="top">
    
    <asp:GridView 
        ID="grvRealEstate" 
        runat="server" 
        Width="100%" 
        AutoGenerateColumns="false" 
        DataKeyNames="ProductID" 
        CssClass="cptable" 
        GridLines="None" 
        AllowPaging="true" 
        
        PageSize="5" OnPageIndexChanging="grvClassifiedProduct_PageIndexChanging">    
        <HeaderStyle Height="25px" BackColor="#EFEFE2" />
        <AlternatingRowStyle BackColor="#F5F5F7" />
        <Columns>
            <asp:TemplateField>
            <ItemTemplate>
            <a style="font-weight:bold" target="_blank" href="../Common/ItemDetail_RealEstate.aspx?PageMode=0&PID=<%#Eval("ProductID") %>&ProfKey=<%#Eval("ProfileID") %>&CID=<%#Eval("CategoryID") %>&SCID=<%#Eval("SubcategoryID") %>&Location=<%#Eval("Items_Country") %>">
            <%#Eval("ProjectName") %>
            </a>
            </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Viewed" HeaderText="Viewed"  HeaderStyle-Width="15%" HeaderStyle-HorizontalAlign="Left"/>
            <asp:BoundField DataField="InsertedOn" HeaderText="Posted" DataFormatString="{0:MMM dd, yyyy}" HeaderStyle-Width="15%" HeaderStyle-HorizontalAlign="Left"/>
            <asp:TemplateField>
            <ItemTemplate>
            <a id="editLink" href="<%=this.Path %>RealEstateAE.aspx?PageMode=1&PID=<%#Eval("ProductID") %>">
            Edit
            </a>
            </ItemTemplate>
            </asp:TemplateField>
            
        </Columns>
        <EmptyDataTemplate>
        <span class="price">You have not posted any real estate product yet.</span>
        </EmptyDataTemplate>
    </asp:GridView>
    </td>
    </tr>
    </table>