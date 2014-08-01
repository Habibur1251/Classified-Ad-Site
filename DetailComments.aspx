<%@ Page Language="C#" MasterPageFile="~/Discount.master" AutoEventWireup="true" CodeFile="DetailComments.aspx.cs" Inherits="DetailComments" Title="ApnerDeal.com" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/UserControl/DZ_TOPFive_ViewedDiscount.ascx" TagName="Hp_TopFive_Discount_Ctrl"
    TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <asp:Label ID="lblSystemMessage" runat="server" ForeColor="Red" EnableViewState="False"
        Width="500px" Font-Size="14px">
    </asp:Label>
<table>
<tr>
<td  valign="top" width="210">
<uc2:Hp_TopFive_Discount_Ctrl ID="Hp_TopFive_Discount_Ctrl1" runat="server" />
</td>
<td valign="top" style="width: 670px">
<table>
<tr>
<td style="width: 678px">
<div class="floatleft"  style="width:650px; vertical-align:top;background-color:#FFFFFF; padding:1px;border-top:solid 1px #FFAA0D; border-bottom:solid 1px #FFAA0D; border-left:solid 1px #FFAA0D;border-right:solid 1px #FFAA0D ">
               <asp:GridView 
                    ID="grvListDiscountLeftpannel"
                    runat="server" 
                    Width="650px"
                    GridLines="none"
                    AllowPaging="false"
                    AutoGenerateColumns="false" FooterStyle-BorderStyle="Solid"  PagerStyle-CssClass="paging" OnRowDataBound="grvListDiscountLeftpannel_RowDataBound" OnSelectedIndexChanged="grvListDiscountLeftpannel_SelectedIndexChanged">
                    <FooterStyle BackColor="#2E4D7B" Height="20px" ForeColor="White" Font-Size="10px" Font-Names="Verdana" Font-Bold="True" BorderStyle="Solid" />
                    <HeaderStyle BackColor="#507CD1" Height="20px" ForeColor="White" Font-Size="10px" Font-Names="Verdana" Font-Bold="True"></HeaderStyle>
                   <AlternatingRowStyle BackColor="White" />
               <Columns>
               <asp:TemplateField>
               <HeaderTemplate>
</HeaderTemplate>
               <ItemTemplate>
               <table cellpadding="5" cellspacing="1" border="0">
               <tr>
               <td valign="top" style="width:125px; height:110px">
               <div class="t" style="width:130px">
                    <div class="b">
                        <div class="l">
                            <div class="r">
                                <div class="bl">
                                    <div class="br">
                                        <div class="tl">
                                            <div class="tr" style="height: auto; padding: 5px;">
               <img src='<%#Eval("ImagePath")%>' alt="Coupon Image" onerror="javascript:this.src='Images/CompanyDefaultImage.png';"
                   style="width: 120px; border: none;" height="75" />
                   </div>
                   </div>
                   </div>
                   </div>
                   </div>
                   </div>
                   </div>
                   </div>
               </td>
               <td  class="DiscountContent" valign="top"  style="width:450px; height:auto">
               <table>
               <tr>
               <td>
                <asp:PlaceHolder ID="phCouponLink" runat="server">
                  </asp:PlaceHolder>
               </td>
               </tr>
               <tr>
               <td align="left">
               <table>
               <tr>
               <td>
                <img src="Images/view.jpg" alt="" />Viewed (<soan class="colortitle"></soan><%#Eval("HitCounter")%>) times
               </td>
               <td>
                | <img src="images/comment.jpg" width="16" height="16" border="none" alt="" />Comments (<soan class="colortitle"></soan><%#Eval("NoOfComments")%>)
               </td>
               </tr>
               </table>
               </td>
               </tr>
               </table>  
               </td>
              
               <td width="170" valign="top">
                  <div class="t" style="width:170px">
                      <div class="b">
                          <div class="l">
                              <div class="r">
                                  <div class="bl">
                                      <div class="br">
                                          <div class="tl">
                                              <div class="tr" style="height: auto">
                                                  <div id="qm0" class="qmmc left_link">
                                                      <table>
                                                          <tr>
                                                           <td  style="width:170px;">
                                                           <table>
                                                           <tr>
                                                           <td>
                                                            <img src="Images/CPImage/Discount.png" border=none height=16 width=16 />
                                                           </td>
                                                           <td>
                                                           <a target="_self" href="ShowAllPrintableDiscount.aspx" class="titleCP onHoverBlue">Go To Discount Zone</a>
                                                           </td>
                                                           </tr>
                                                           </table>
                                                           </td>
                                                          </tr>
                                                           <tr>
                                                          <td style="width:170px;">
                                                          <table>
                                                          <tr>
                                                          <td>
                                                           <img src="images/postdiscount.jpg" width="16" height="16" border="none" alt="" />
                                                          </td>
                                                          <td>
                                                          <a target="_blank" href="Corporate/Default.aspx" class="titleCP onHoverBlue">Post Your Discount</a>
                                                          </td>
                                                          </tr>
                                                          </table>
                                                          </td>
                                                         </tr>
                                                          <tr>
                                                              <td style="width:170px;">
                                                              <table>
                                                              <tr>
                                                               <td>
                                                              <asp:Image ID="Image47" runat="server"  ImageUrl="~/Images/facebook.png" Height="16px" Width="16px"/>
                                                              </td>
                                                              <td>
                                                              <a target="_blank" class="titleCP onHoverBlue" href="http://www.facebook.com/sharer.php?u=http://www.apnerdeal.com/ShowAllPrintableDiscount.aspx&t=ApnerDeal.com: Find Bangladeshi Discounts, Coupons, Deals, Price Reduction news all in one place. Save money to your next purchase!" title="Send to Facebook">Share to your facebook</a>
                                                              </td>
                                                              </tr>
                                                              </table>
                                                               </td>
                                                          </tr>
                                                          <tr>
                                                          <td style="width:170px;">
                                                          <table>
                                                          <tr>
                                                          <td>
                                                          <img src="images/Email.jpg" width="16" height="16" alt="" />
                                                          </td>
                                                          <td>
                                                          <a target="_self" href="EmailAFriend.aspx?data=www.apnerdeal.com/DetailComments.aspx?PI=<%#Eval("ProfileID") %>&CI=<%#Eval("CouponID") %>" onClick='genericPopup(this.href,600,500,0,0,170,280,0,0,0,0);return(false);' class="titleCP onHoverBlue">Email to your friend</a>
                                                          </td>
                                                          </tr>
                                                          </table>
                                                          </td>
                                                          </tr>
                                                          <tr>
                                                             <td>
                                                             <table>
                                                             <tr>
                                                             <td>
                                                             <img src="images/report.jpg" width="16" height="16" border="none" alt="" />
                                                             </td>
                                                             <td>
                                                              <a target="_self" href="ReportDiscount.aspx?PI=<%#Eval("ProfileID") %>&CI=<%#Eval("CouponID") %>" onClick='genericPopup(this.href,620,620,0,0,170,280,0,0,0,0);return(false);' class="titleCP onHoverBlue">Report abuse</a>
                                                             </td>
                                                             </tr>
                                                             </table>
                                                              </td>
                                                          </tr>
                                                          <tr>
                                                              <td>
                                                              <table>
                                                              <tr>
                                                              <td>
                                                               <img src="images/comment.jpg" width="16" height="16" border="none" alt="" />
                                                              </td>
                                                              <td>
                                                               <a target="_self" href="CommentDiscount.aspx?PI=<%#Eval("ProfileID") %>&CI=<%#Eval("CouponID") %>" onClick='genericPopup(this.href,620,620,0,0,170,280,0,0,0,0);return(false);' class="titleCP onHoverBlue">Post a comment</a>
                                                              </td>
                                                              </tr>
                                                              </table>
                                                              </td>
                                                          </tr>
                                                          <tr>
                                                              <td class="onHoverBlue">
                                                              <table>
                                                              <tr>
                                                              <td>
                                                              <img src="images/Vendor.jpg" width="16" height="16" border="none" alt="" />
                                                              </td>
                                                              <td>
                                                               <a target="_self" href="Discount.aspx" class="titleCP onHoverBlue">More from Vendor</a>
                                                              </td>
                                                              </tr>
                                                              </table>
                                                              </td>
                                                          </tr>
                                                         
                                                      </table>
                                                  </div>
                                              </div>
                                          </div>
                                      </div>
                                  </div>
                              </div>
                          </div>
                      </div>
                  </div>
               </td>
               </tr>
               </table>
               <hr size="1" style="color:#5C9EBF;" />
               </ItemTemplate>
               </asp:TemplateField>
               </Columns>
                   <PagerStyle CssClass="paging" />
               </asp:GridView>
         <asp:GridView ID="grvComments" Width="100%" runat="server" GridLines="none" AutoGenerateColumns="false"
        Caption="Comment(s) of this discount">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <table cellpadding="0px" cellspacing="0px" width="100%" border="0px">
                        <tr>
                            <td>
                                <span class="onHoverRedLink" style="color: #004b91">
                                    <img src="../Images/bullet1.gif" alt="" align="middle" />
                                    <%#Eval("Name")%>
                                </span>says:
                            </td>
                            <td width="25%" class="gray11px plaintext">
                                Posted On:
                                <%#Eval("InsertOn")%>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="padding: 5px 0px; text-align: justify; font-family: Verdana;">
                                <div class="t topContent" style="width: 100%; height: auto; background-color: #EAF3FE;">
                                    <div class="b">
                                        <div class="l">
                                            <div class="r">
                                                <div class="bl">
                                                    <div class="br">
                                                        <div class="tl">
                                                            <div class="tr" style="height: auto; padding: 5px;">
                                                                <p>
                                                                    <%#Eval("Comment").ToString().Replace(Environment.NewLine, "<br/>")%>
                                                                </p>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </td>
                        </tr>
                    </table>
                    <hr size="1px" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
               </div>
</td>
</tr>
</table>
</td>
<td valign="top"  style="width: 160px">

<%--Space for Google Adsense--%>

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


</td>
</tr>
</table>
</asp:Content>

