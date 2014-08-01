<%@ Page Language="C#" MasterPageFile="~/ClassifiedListing.master" AutoEventWireup="true" CodeFile="ItemList_Classifieds.aspx.cs" Inherits="ItemList_Classifieds" Title="www.ApnerDeal.com Classified Listing." %>

<%@ Register Src="UserControl/ClassifiedCounterTD.ascx" TagName="CounterListClassifiedCategory" TagPrefix="ClassifiedCounterUsercontrol" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register Src="UserControl/Login_CL_Listing_Ctrl.ascx" TagName="Login_CL_Listing_Ctrl"
    TagPrefix="uc7" %>

<%@ Register Src="UserControl/Login_Ctrl.ascx" TagName="Login_Ctrl" TagPrefix="uc5" %>

<%@ Register Src="UserControl/CL_Area_Ctrl.ascx" TagName="CL_Area_Ctrl" 
    TagPrefix="uc2" %>
    
<%@ Register Src="UserControl/CL_Province_Ctrl.ascx" TagName="CL_Province_Ctrl" 
    TagPrefix="uc6" %>
    
<%@ Register Src="UserControl/CorporateSellerList.ascx" TagName="CorporateSellerList" 
    TagPrefix="uc4" %>
<%@ Register Src="UserControl/PriceRangeCtrl.ascx" TagName="PriceRangeCtrl" 
    TagPrefix="uc3" %>
    
<%@ Register Src="~/UserControl/Display_Filter_Ctrl.ascx" TagName="Display_Filter_Ctrl" TagPrefix="Filter" %>
    
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

<table width="1000px" border="0px" align="center" cellpadding="0px" cellspacing="0px">
<tr>
    <td style="width: 230px; vertical-align:top;">
        <br />
        
        <ClassifiedCounterUsercontrol:CounterListClassifiedCategory ID="CounterListClassifiedCategory1" runat="server" />
        <uc2:CL_Area_Ctrl id="insideDhakaCtrl" runat="server" />
        <uc6:CL_Province_Ctrl ID="outsideDhakaCtrl" runat="server" />
        <uc3:PriceRangeCtrl id="rangeCtrl" runat="server">
        </uc3:PriceRangeCtrl>
        <br />
        <uc7:Login_CL_Listing_Ctrl ID="Login_CL_Listing_Ctrl1" runat="server" Classified_CP_VirtualPath="Classifieds"
            Corporate_CP_VirtualPath="Corporate" ForgotPassWordLink="ForgotPassword.aspx" />
    </td>
    
    <td style="width: 580px; vertical-align:top; padding-left:10px">
        <table width="580px" border="0px" cellspacing="0px" cellpadding="0px" style="border-bottom: 1px solid #d5d5d5;">
            <tr>
                <td colspan="3">
                    <asp:Label ID="lblSystemMessage" runat="server" ForeColor="Red" EnableViewState="False"
                        Width="60%" Font-Size="11px"> </asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="height: auto; padding:0px 0px 5px 0px;">
                  <span >
                        <h1 class="pageTitle colortitle" style="background-color:Silver; margin-top:20px; text-align:center;">  <%=this.Category%> </h1> <br /><br /> 
                    </span> 
                    
                    <Filter:Display_Filter_Ctrl ID="DisplayFilter" runat="server" />
                    
                    
                    
                    <br />
                    Following Item(s) are in 
                    <strong style="color: #004B91;"><%=this.TitleLocation%></strong>
                    
                </td>
            </tr>
            <!--Category Name-->
            <tr>
                <td width="3px">
                    <img src="images/title_bar_left.gif" alt="" width="3px" height="28px" /></td>
                <td width="400px" style="background-image: url(images/title_bar_bg.gif); background-repeat: repeat-x;
                    padding-left: 5px;">
                    <%=this.Subcategory%>
                </td>
                <td width="3px">
                    <img src="images/title_bar_right.gif" alt="" width="3" height="28" /></td>
                <td align="right" valign="top">
                    <!--Subcategory List-->
                    <asp:Panel ID="pnlSubcategory" runat="server" Visible="false" Width="200px" Height="28px">
                        <asp:Label ID="lblFilter" runat="server" Text="Filter: " ForeColor="#C00000" Font-Names="Verdana"
                            Font-Bold="False" BackColor="Transparent"></asp:Label>
                        <asp:DropDownList 
                            ID="ddlSubcategory" 
                            runat="server" 
                            AppendDataBoundItems="true"
                            AutoPostBack="true" 
                            DataTextField="Subcategory" 
                            DataValueField="SubcategoryID"
                            Width="150px" 
                            OnSelectedIndexChanged="ddlSubcategory_SelectedIndexChanged">
                        </asp:DropDownList>
                        
                    </asp:Panel>
                </td>
            </tr>
        </table>
                <br />
                <!--Headers-->
        <asp:GridView 
            ID="grvItemList" 
            runat="server" Width="99%" AutoGenerateColumns="false"
            DataKeyNames="ProductID, CategoryID" GridLines="None" 
            AllowPaging="true" PageSize="20" Font-Size="11px"
            OnPageIndexChanging="grvItemList_PageIndexChanging" OnRowDataBound="grvItemList_RowDataBound">
            <Columns>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <table width="100%" height="20px" cellpadding="0px" cellspacing="0px" border="0px"
                            bgcolor="#c9e1f4">
                            <tr>
                                <td style="text-align: left; padding-left: 5px;">
                                    Displaying
                                    <%=  (grvItemList.PageIndex * grvItemList.PageSize) + 1%>
                                    -
                                    <%= grvItemList.Rows.Count < grvItemList.PageSize ? Total_Record : (grvItemList.PageIndex + 1) * grvItemList.PageSize%>
                                </td>
                                <td style="text-align: center;">
                                    Page
                                    <%=grvItemList.PageIndex + 1%>
                                </td>
                                <td style="text-align: right; padding-right: 5px;">
                                    Total
                                    <%=Total_Record%>
                                    items found.
                                </td>
                            </tr>
                        </table>
                        <table style="width: 100%; height: 25px; color: Black; background-color: #EFEFE2;"
                            border="0px" cellspacing="0px" cellpadding="0px">
                            <thead>
                                <tr>
                                    <th class="columnheader" style="width: 22%; text-align: left;">
                                        &nbsp;
                                    </th>
                                    <th class="columnheader" style="width: 40%; text-align: left; padding: 5px;">
                                        <asp:Label ID="lblPrice" runat="server" Text="Brief Description"></asp:Label>
                                    </th>
                                    <th class="columnheader" style="text-align: left; padding: 5px; width:38%">
                                        Ad Poster Information
                                    </th>
                                </tr>
                            </thead>
                        </table>
                        
                           
                            
                    </HeaderTemplate>
                    <ItemTemplate>
                        <table width="99%" border="0px" cellspacing="0px" cellpadding="0px" style="color: black">
                            <tr>
                                <td style="width: 22%;">
                                    
                                    
                                    <a class="onHoverRedLink" style="font-weight:bold" onclick="window.open(this.href, 'ItemDetail', 'width=800,height=500,left=200,top=50,scrollbars,resizable'); return false;" href="ItemDetail_Classifieds.aspx?ItemKey=<%#Eval("ProductID")%>&ProfKey=<%#Eval("ProfileID")%>&CID=<%=this.CategoryID%>&SCID=<%=this.SubcategoryID%>&Location=<%=this.Location%>&AdType=<%=this.AdvertisementType%>">
                                    <div class="itemListImage1" style="cursor:pointer;">
                                            <asp:Image ID="image" runat="server" ImageUrl='<%#(string)Eval("ProductImage")%>'
                                                AlternateText='<%#(string)Eval("Title")%>' Width="115px" Height="115px" />
                                    </div>
                                    </a>
                                </td>
                                <td style="width:40%; overflow:hidden; padding: 5px; vertical-align: top; line-height: 18px;">
                                    <span style="text-align: left; width:50px;">
                                        <asp:PlaceHolder ID="pnlAdvertisementType" runat="server">
<a class="onHoverBlue colortitle" style="font-weight:bold; font-size:14px; " onclick="window.open(this.href, 'ItemDetail', 'width=800,height=500,left=200,top=50,scrollbars,resizable'); return false;" href="ItemDetail_Classifieds.aspx?ItemKey=<%#Eval("ProductID")%>&ProfKey=<%#Eval("ProfileID")%>&CID=<%=this.CategoryID%>&SCID=<%=this.SubcategoryID%>&Location=<%=this.Location%>&AdType=<%=this.AdvertisementType%>">
                                        
                                    
                                                                            
                                            <strong class="" style="font-size: 12px;">
                                            <%#Eval("Title")%></strong> 
</a>                                            
                                            From <strong class="price"> <%#Eval("Item_Location")%><br />
                                            </strong>
                                        </asp:PlaceHolder>
                                         
                                        
                                    </span>
                                    
                                    <strong style="font-size: 12px;">Description: </strong>
                                    
                                    <div style="width:219px; word-wrap:break-word; word-break:normal">
                                    <%#Eval("Description")%>
                                    </div>
                                    </span>
                                    <br />
                                    
                                    
                                    <asp:PlaceHolder ID="phPrice" runat="server">
                                    <span class="price" style="font-weight: bold; font-family: verdana">
                                    
                                    </span>
                                    </asp:PlaceHolder>
                                </td>
                                <td style="padding: 5px; vertical-align: top; line-height: 18px; width:200px" valign="top">
                                    <div>
                                        <strong >Name: </strong>
                                        <%#Eval("AdvertiserName")%>
                                    </div>
                                    <div>
                                        <strong >Cell # </strong>
                                        <%#Eval("Mobile") %>
                                    </div>
                                    <div>
                                        <strong >Address: </strong><span
                                            class="sellerInfo" style="font-weight: bold; font-size: 12px; font-family: verdana,arial,helvetica,sans-serif;">
                                        </span>
                                        <%#Eval("ContactAddress")%><br />
                                        
                                        <%--<strong >District: </strong>
                                        <%#Eval("Province") %><br />
                                        <strong >Division: </strong>
                                        <%#Eval("State") %><br />
                                        <strong >Country: </strong>
                                        <%#Eval("Country") %><br />--%>
                                    </div>
                                    <div>
                                        <strong >Posted On: </strong>
                                        <%#Eval("Posted") %>
                                    </div>
                                    
                                    
                                    <div>
                                        <strong>Source: </strong>
                                        <%#Eval("Source") %>
                                    </div>
                                    <%--<div>
                                        <strong class="price" >
                                        <%#Eval("DaysRemaining") %> day's left
                                        </strong>
                                    </div>--%>
                                    
                                </td>
                        </table>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <AlternatingRowStyle BackColor="#F5F5F7" />
            <EmptyDataTemplate>
                <div class="emptyDataMessage" style="width: 100%; text-align: center; margin: 20px">
                    <span class="price">We are sorry that there are currently no posted items on this search
                        criteria.</span>
                </div>
            </EmptyDataTemplate>
            <PagerSettings Position="TopAndBottom" />
        </asp:GridView>
            
            
    </td>
    <td style="width: 170px; padding-left:10px;" valign="top">
        
                     
<%--for goole adesnse--%>

    </td>
</tr>
</table>



    <!--END: VALIDATION SUMMARY CONTROL-->
    <table width="770px" border="0px" align="center" cellpadding="0px" cellspacing="0px">
        <tr>
            
            
            
            <td style="width:170px">
            &nbsp;
            </td>
        </tr>
    </table>
    <asp:HiddenField Visible="false" runat="Server"  ID="hfProvinceID"/>
    <asp:HiddenField Visible="false" runat="Server" ID="hfSubcategoryID"/>
    
   
           
            
<script type="text/javascript"> 
 
  var _gaq = _gaq || [];
  _gaq.push(['_setAccount', 'UA-29319949-1']);
  _gaq.push(['_trackPageview']);
 
  (function() {
    var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
    ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
    var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
  })();
 
</script>

        
</asp:Content>

