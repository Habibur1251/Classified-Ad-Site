<%@ Page Language="C#" MasterPageFile="~/Common/MPCommonListing.master" AutoEventWireup="true" CodeFile="ItemDetail_RealEstate.aspx.cs" Inherits="Common_ItemDetail_RealEstate" Title="www.apnerdeal.com Real Estate Detail" %>

<%@ Register Src="../UserControl/Login_Ctrl.ascx" TagName="Login_Ctrl" TagPrefix="uc1" %>


<%@ Register Src="../UserControl/ClassifiedCategory_Ctrl.ascx" TagName="ClassifiedCategory_Ctrl"
    TagPrefix="uc4" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<table width="1000" border="0" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td width="180" valign="top">
        <br /><br />
            <uc4:classifiedcategory_ctrl id="ClassifiedCategory_Ctrl1" runat="server" />
            <uc1:Login_Ctrl ID="Login_Ctrl1" runat="server" Classified_CP_VirtualPath="../Classifieds"
                Corporate_CP_VirtualPath="../Corporate" />
        </td>
        
        <td style=" margin-left:15px; width: 625px;" valign="top">
        <div class="topContent" style="padding:0px; margin:0px; width:100%">
                <div style="padding:0px; margin:0px; width:100%">
                <asp:Label 
                    ID="lblSystemMessage" 
                    runat="server" 
                    ForeColor="Red" 
                    EnableViewState="False" 
                    Width="100%" 
                    Font-Size="11px">
                </asp:Label>
                </div> 
            <asp:ScriptManager id="ScriptManager1" runat="server">
            </asp:ScriptManager>
                
          </div>
          
          <div class="bottomContent" style="padding:0px; padding-top: 20px; margin:0px">
          <asp:FormView 
            ID="fvRealEstateDetail" 
            runat="server" 
            DataKeyNames="ProductID"
            AllowPaging="false" 
            Font-Size="11px" OnItemCreated="fvRealEstateDetail_ItemCreated">
            <ItemTemplate> 
            
         <table width="620px" cellpadding="0px" cellspacing="0px" border="0px">
         <tr>
         <td>
         
        
                <div class="imageDetailContainer">
                    <img alt="" src ='<%# Eval("ProductImage") %>'
                        onerror="javascript:this.src='../Classifieds_ProductImage/default.png';"
                        border="0"
                        width='240' 
                        height="240"/> 
                </div>
                   
         </td>
        <td style="width:300px" valign="top">
         
                    <div class="miscLine">
                        <span class="title"><%#Eval("ProjectName") %></span>
                        
                     </div>
                     <div class="floatleft miscLine" style="font-weight: normal; vertical-align:bottom">

                    </div>
                     
                     <div class="floatleft miscLine" style="font-weight: normal; vertical-align:top">

                    </div>
                  
                    <br />
                        <div class="miscLine" style="clear:both">
                            <hr noshade="noshade" size="1px" />
                        </div>
                        
                        
                        <div class="miscLine" style="margin:10px 0px 10px 0px">
                            
                        <strong style="color:#990000; font-size:13px;">
                        Price: <strong style=" font-size:8pt;color: #990000;">
                            <%# Convert.ToDouble(Eval("Price")) == 0 ? "Contact Seller for price" : Eval("Currency") + " " + String.Format("{0:#,###}", Eval("Price"))%>
                            (Per <%#Eval("SizeUnit") %>)
                        </strong>
                        </strong>
                        <asp:Label ID="lblSaleOffer" runat="server">
                        </asp:Label>
                        </div>
                        
                        
                        <div class="miscLine">
                        <strong style="font-size:13px;">
                        Seller:</strong> <%#Convert.ToBoolean(Eval("IsAlternativeAddress"))? "N/A" : Eval("SellerInfo").ToString() %>
                        </div>
                        
                        <div class="miscLine">
                        <strong style="font-size:13px;">
                        Contact No:</strong> 
                        <%#Convert.ToBoolean(Eval("IsAlternativeAddress"))? "N/A" : Eval("CellNo").ToString() %>
                        
                        </div>
                        
                        <div class="miscLine">
                        <strong>Address:</strong> 
                        <%#Convert.ToBoolean(Eval("IsAlternativeAddress"))? "N/A" : Eval("UserAddress").ToString() %>
                        </div>

                        
                        <div class="miscLine">
                        This Item has been viewed<strong style="color:#990000"> (<%#Eval("HitCounter") %>) </strong>Times.
                        </div>
                        
                        <div class="miscLine" style="margin-top:10px;">
                        <img src="../images/email1.jpg" width="50" height="60" align="middle" style="margin-right:10px;" alt="" />
                        <asp:LinkButton ID="lbtnEmailFriend" CssClass="onHoverRedLink" runat="server" Font-Bold="true" OnClick="lbtnEmailFriend_Click">
                        Email this item to a friend.
                        </asp:LinkButton>
                        
                        </div>
         </td>
         </tr>
         </table>
         <br /><br />
         
         <div class="pageTitle colortitle" style="clear: both">
            Product Description
        </div>
        <div class="productDescription" style="padding: 10px">
            
            <p class="formatParagraph">
                <%#Eval("Description").ToString().Replace(Environment.NewLine, "<br/>")%>
            </p>
        </div>
        <table width="620px" cellpadding="0px" cellspacing="0px" border="0px">
            <tr>
                <td style="vertical-align: top; height: auto;">
                    <div class="pageTitle colortitle" style="padding-bottom: 5px;">
                        Product Detail
                    </div>
                    <div class="leftFooterContainer" style="width: 300px; float: left; padding: 10px;
                        margin-bottom: 10px;">
                        <div class="miscLine">
                            <%#Eval("NoOfBedRoom").ToString() == "" ? "" : "<strong>BedRoom: </strong>" + Eval("NoOfBedRoom")%>
                        </div>
                        <div class="miscLine">
                            <%#Eval("NoOfWashRoom").ToString() == "" ? "" : "<strong>WashRoom: </strong>" + Eval("NoOfWashRoom")%>
                        </div>
                        <div class="miscLine">
                            <%#Eval("Size").ToString() == "" ? "" : "<strong>Size: </strong>" + Eval("Size") +" "+ Eval("SizeUnit")%>
                        </div>
                        <div class="miscLine">
                            <%#Eval("Quantity").ToString() == "" ? "" : "<strong>Quantity: </strong>" + Eval("Quantity")%>
                        </div>
                        <!--div class="miscLine">
                            <%#Eval("Price").ToString() == "" ? "" : "<strong>Price: </strong>" + Eval("Currency") + " " + Eval("Price")%>
                        </div-->
                        <div class="miscLine">
                            <%#Eval("ServiceCharge").ToString() == "-1" ? "" : "<strong>ServiceCharge: </strong>" + Eval("Currency") + " " + Eval("ServiceCharge")%>
                        </div>
                        <div class="miscLine">
                            <strong>Car Parking : </strong> <%#Eval("IsCarParkingAvailable") %>
                        </div>
                        <div class="miscLine">
                            <%#Eval("Items_Location").ToString() == "" ? "" : "<strong>Area: </strong>" + Eval("Items_Location")%>
                        </div>
                        <div class="miscLine">
                            <%#Eval("Items_District").ToString() == "" ? "" : "<strong>District: </strong>" + Eval("Items_District")%>
                        </div>
                        <div class="miscLine">
                            <%#Eval("Address").ToString() == "" ? "" : "<strong>Address: </strong>" + Eval("Address")%>
                        </div>
                </td>
                <td style="width:300px;" valign="top">
                     <div class="rightFooterContainer" style="width: 300px; float: left; height:356;">
                     <asp:PlaceHolder ID="phAddToCart" runat="server">
                     </asp:PlaceHolder>
                </div>
                </td>
            </tr>
        </table>
  </ItemTemplate>
  </asp:FormView>
       </div>
       <br />
<div class="set3_t"; style="border-width:0px;  border-style: solid;  border-color:Silver;">
 <div class="b">
<div class="l">
<div class="r">
<div class="bl">
<div class="br">
<div class="set3_tl">
<div style="padding: 10px; text-align: justify;" class="set3_tr">
<div class="pageTitle colortitle" style="clear: both">
    <span style="font-size: 10pt"><strong>How to Buy this Product:</strong></span></div>
<br />
Thank you for your interest in this product. If you are considering buying or hiring
    this product here is the option you have. Please look for the <strong>“CONTACT NO or ADDRESS or EMAIL” </strong> in to the ad.<br />
    <br />
    Furthermore You can also directly contact with the seller through phone or email.<br />
<br /> For more questions, please email us at
<a href="mailto:info@apnerdeal.com"><span style="text-decoration: underline">info@apnerdeal.com</span></a></div>
</div>
</div>
</div>
</div>
</div>
</div>
</div>
  </td>
  <td width="180px" valign="top">
  &nbsp;

<%--Place for google adsense--%>

  </td>
        </tr>
        
 
    </table>  

  
   
</asp:Content>

