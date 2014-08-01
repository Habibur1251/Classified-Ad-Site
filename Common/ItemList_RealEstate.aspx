<%@ Page Language="C#" MasterPageFile="~/Common/MPCommonListing.master" AutoEventWireup="true" CodeFile="ItemList_RealEstate.aspx.cs" Inherits="Common_ItemList_RealEstate" Title="www.apnerdeal.com Real Estate listing" %>

<%@ Register Src="../UserControl/InsideDhaka_RealEstate_Ctrl.ascx" TagName="InsideDhaka_RealEstate_Ctrl"
    TagPrefix="uc9" %>
    
<%@ Register Src="../UserControl/OutsideDhaka_RealEstate_Ctrl.ascx" TagName="OutsideDhaka_RealEstate_Ctrl"
    TagPrefix="uc10" %>

<%@ Register Src="../UserControl/ClassifiedSellerList.ascx" TagName="ClassifiedSellerList"
    TagPrefix="uc8" %>

<%@ Register Src="../UserControl/BS_Province_Ctrl.ascx" TagName="BS_Province_Ctrl"
    TagPrefix="uc5" %>
    
<%@ Register Src="../UserControl/CorporateSellerList.ascx" TagName="CorporateSellerList"
    TagPrefix="uc6" %>
    
<%@ Register Src="../UserControl/Information_Ctrl.ascx" TagName="Information_Ctrl"
    TagPrefix="uc7" %>

<%@ Register Src="../UserControl/ClassifiedCategory_Ctrl.ascx" TagName="ClassifiedCategory_Ctrl"
    TagPrefix="uc4" %>

<%@ Register Src="../UserControl/Login_Ctrl.ascx" TagName="Login_Ctrl" 
    TagPrefix="uc2" %>
    
<%@ Register Src="../UserControl/Display_Filter_Ctrl.ascx" TagName="Display_Filter_Ctrl"
    TagPrefix="uc3" %>

<%@ Register Src="../UserControl/RealEstate_SecondSubcategory_List_Ctrl.ascx" TagName="RealEstate_SecondSubcategory_List_Ctrl"
    TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<table width="1000px" border="0" align="center" cellpadding="0" cellspacing="0">
<tr>
<td valign="top" style="width: 180px">
    
        <br /><br /><br />
    <uc1:RealEstate_SecondSubcategory_List_Ctrl id="SecondSubcategory_Ctrl" CategoryID="7"
        runat="server">
    </uc1:RealEstate_SecondSubcategory_List_Ctrl>
    
    
    <uc9:InsideDhaka_RealEstate_Ctrl id="InsideDhaka_RealEstate_Ctrl1" runat="server" CategoryID="7">
    
    </uc9:InsideDhaka_RealEstate_Ctrl>
    
    <uc10:OutsideDhaka_RealEstate_Ctrl id="OutsideDhaka_RealEstate_Ctrl1"
        runat="server" CategoryID="7"></uc10:OutsideDhaka_RealEstate_Ctrl>
        
        
    <uc6:CorporateSellerList ID="BS_Seller" runat="server" CategoryID="7" />
    
    <uc8:ClassifiedSellerList id="CL_Seller_Ctrl" runat="server" CategoryID="7">
    </uc8:ClassifiedSellerList>
    
    <uc2:Login_Ctrl ID="Login_Ctrl1" runat="server" Classified_CP_VirtualPath="../Classifieds" Corporate_CP_VirtualPath="../Corporate" />
    &nbsp;
    <uc5:BS_Province_Ctrl ID="ProvinceCtrl" runat="server" CategoryID="7" Visible="false" />
</td>

<td width="625px" style=" margin-left:15px" valign="top">

        <div style="padding:0px; margin:0px; width:100%">
                    <asp:Label 
                    ID="lblSystemMessage" 
                    runat="server" 
                    ForeColor="Red" 
                    EnableViewState="False" 
                    Width="100%" 
                    Font-Size="11px">
                </asp:Label>
            <asp:ScriptManager id="ScriptManager1" runat="server">
            </asp:ScriptManager>
                </div>
            <div style="padding:0px; margin:0px; width:100%">
                        <span class="pageTitle colortitle"> <%=this.Subcategory%></span>
                        <br /><br />
                <uc3:Display_Filter_Ctrl ID="DisplayFilter" runat="server" />
                        
                        <br />
                        Shown below are <strong style="color:Red;"> <%=this.Subcategory%></strong> in <strong style="color:#004B91;"><%=this.Location%></strong>
                        <br /><br />
                        
                        <table width="100%" border="0" cellspacing="0" cellpadding="0" style="border-bottom:1px solid #d5d5d5;">
                            <tr>
                            <td width="3"><img src="../images/title_bar_left.gif" alt="" width="3" height="28" /></td>
                            <td width="600" style="background-image:url(../images/title_bar_bg.gif); background-repeat:repeat-x; padding-left:5px;"><%=this.Subcategory%></td>
                            <td width="3"><img src="../images/title_bar_right.gif" alt="" width="3" height="28" /></td>
                            </tr>
                        </table>
                    </div>



                <div id="itemListContainer" runat="server" style="width: 100%; margin-top: 0px">
                    
                    
                    <asp:GridView 
                        ID="grvRealEstate" 
                        runat="server" 
                        Width="625px" 
                        AutoGenerateColumns="false"
                        DataKeyNames="ProductID" 
                        GridLines="None" 
                        AllowPaging="true" 
                        PageSize="10" Font-Size="11px" OnPageIndexChanging="grvRealEstate_PageIndexChanging">
                        <EmptyDataTemplate>
                        </EmptyDataTemplate>
                        <AlternatingRowStyle BackColor="#F5F5F7" />
                        <Columns>
                            <asp:TemplateField>
                            <HeaderTemplate>
                            <table width="100%" height="20px" cellpadding="0px" cellspacing="0px" border="0px"
                                    bgcolor="#c9e1f4">
                                    <tr>
                                        <td style="text-align: left; padding-left: 5px;">
                                            Displaying
                                            <%=  (grvRealEstate.PageIndex * grvRealEstate.PageSize) + 1%>
                                            -
                                            <%= grvRealEstate.Rows.Count < grvRealEstate.PageSize ? Total_Record : (grvRealEstate.PageIndex + 1) * 10%>
                                        </td>
                                        <td style="text-align: center;">
                                            Page
                                            <%=grvRealEstate.PageIndex + 1%>
                                        </td>
                                        <td style="text-align: right; padding-right: 5px;">
                                            Total
                                            <%=Total_Record%>
                                            items found
                                        </td>
                                    </tr>
                                </table>
                                
                                
                            
                            
                            </HeaderTemplate>
                                <ItemTemplate>
                                    <table cellpadding="0" cellspacing="0" border="0">
                                        <tr>
                                            <td class="firstcolumn" width="125">
                                                <div class="itemListImage">
                                                    <a class="onHoverRedLink" target="_blank" href="ItemDetail_RealEstate.aspx?PageMode=1&PID=<%#Eval("ProductID") %>&CID=<%#Eval("CategoryID") %>&SCID=<%#Eval("SubcategoryID") %>&SSCID=<%#Eval("SecondSubcatID")%>&Location=<%#Eval("Items_Country")%>">
                                                        <img  alt="" src='<%# Eval("ProductImage") %>' onerror="javascript:this.src='../Classifieds_ProductImage/default.png';"
                                                            border="0" width='110' height="110" />
                                                    </a>
                                                </div>
                                            </td>
                                            <td class="middlecolumn" width="295">
                                            <span class="title">
                                            <a class="onHoverBlue" target="_blank" href='ItemDetail_RealEstate.aspx?PageMode=1&PID=<%#Eval("ProductID") %>&CID=<%#Eval("CategoryID") %>&SCID=<%#Eval("SubcategoryID") %>&SSCID=<%#Eval("SecondSubcatID")%>&Location=<%#Eval("Items_Country")%>'>
                                                    <span style="font-size: 10pt; font-family: Verdana"><%#Eval("ProjectName") %></span>
                                                </a></span>
                                                <br />
                                                <br />
                                                <span style="padding: 2px; background-color: rgb(86, 120, 162); color: white;">
                                                    <%#Eval("Subcategory") %>
                                                </span>&nbsp; <%#Eval("SecondSubcategory") %>
                                                
                                             
                                                <div class="miscLine">
                                                    <%#Eval("SellerName") %>
                                                </div>
                                                <div class="miscLine">
                                                    Size:
                                                    <%#Eval("Size") %>
                                                    <%#Eval("SizeUnit") %>
                                                </div>
                                                <div class="miscLine">
                                                    <strong>
                                                        <%#Eval("Items_Location") %>
                                                        ,
                                                        <%#Eval("Items_District") %>
                                                    </strong>
                                                </div>
                                                <div class="miscLine">
                                                    Price: <strong style=" font-size:8pt; color: #990000;">
                                                        <%# Convert.ToDouble(Eval("Price")) == 0 ? "Contact Seller for price" : Eval("Currency") + " " + String.Format("{0:#,###}", Eval("Price"))%>
                                                     (Per <%#Eval("SizeUnit") %>)
                                                    </strong>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                
                                   
                                    
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerSettings Position="TopAndBottom" />
                    </asp:GridView>
                </div>           
 </td>

<td width="180px" valign="top" style="padding-left:15px">
    <uc4:ClassifiedCategory_Ctrl ID="ClassifiedCategory_Ctrl1" runat="server" />

<%--Place for google adsense--%>
                       
</td>

</tr>

</table>



        
</asp:Content>

