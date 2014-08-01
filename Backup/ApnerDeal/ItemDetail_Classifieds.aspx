<%@ Page Language="C#" MasterPageFile="~/ClassifiedListing.master" AutoEventWireup="true" CodeFile="ItemDetail_Classifieds.aspx.cs" Inherits="ItemDetail_Classifieds" Title="www.apnerdeal.com Classified Detail." %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>
<%@ Register Src="UserControl/ClassifiedSearchModule.ascx" TagName="ClassifiedSearchModule" TagPrefix="uc1" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1" ><!--BEGIN: CONTENT HOLDER (1st Column)-->
<table width="1248px" border="0px" align="left" cellpadding="0px" cellspacing="0px" style="background:white; margin-left:-30px;">
<tr>
<td valign="top" style="padding-left:15px;padding-right:0px"><!--BEGIN: VALIDATION SUMMARY CONTROL--><br />
<asp:ValidationSummary 
        ID="ValidationSummary1" 
        runat="server" 
        Width="100%" 
        BackColor="#FFFFFF" 
        ForeColor="Black" 
        Font-Bold="False" 
        HeaderText="<table><tr><td style='padding-left:10px; padding-top:7px;'><img src='images/icon_error.gif' width='42' height='40' alt='' /></td><td valign='middle' style='font-weight:bold; text-decoration:underline;color:#ED0000;'>Following error occured :</td></tr></table>" 
        BorderStyle="Dashed" 
        BorderWidth="1px" 
        Font-Size="11px"/> 
        <asp:Label 
        ID="lblSystemMessage" 
        runat="server" 
        ForeColor="Red" 
        EnableViewState="False" 
        Width="100%" 
        Font-Size="11px">
    </asp:Label> <!--END: VALIDATION SUMMARY CONTROL--><!--
    Product Title
    --><span class="pageTitle"><%=this.dtProductProfile.Rows[0]["ProductTitle"].ToString()%></span><br /><table width="100%" border="0" cellspacing="0" cellpadding="0" class="listing" style="color:Black;"><tr><td style="width: 356px"><!--
        Product Price:
        --><asp:Label ID="lblConcatTitle" runat="server">
        </asp:Label> </td><td width="200px" align="right"><!--Ad ID: 51009836,   Total Viewed: 98--></td></tr><tr><td valign="top" style="width: 356px"><table cellpadding="0px" cellspacing="0px" width="500px" border="0px"><tr><td width="174px"><a href="#"><img src="<%=this.dtProductProfile.Rows[0]["ProductImage"].ToString()%>" 
                alt="" 
                width="350" height="350" 
                border="0px" align="left" 
                style="margin-right:10px;margin-bottom:10px;" class="border" /> </a></td><td><div style="width: 100%; height: 200px; line-height:20px; text-align: left;"><strong>Name: </strong><%=this.dtProductProfile.Rows[0]["UserName"].ToString().Replace(Environment.NewLine, "<br/>")%><br /><strong>Cell # </strong><%=this.dtProductProfile.Rows[0]["CellNo"].ToString()%><p style="word-break:normal; word-wrap:normal;"><strong>Address:</strong> <%=this.dtProductProfile.Rows[0]["UserAddress"].ToString()%><br /><%--<strong>District: </strong>
                <%=this.dtProductProfile.Rows[0]["Province"].ToString().Replace(Environment.NewLine, "<br/>")%><br />
                <strong>Division: </strong>
                <%=this.dtProductProfile.Rows[0]["State"].ToString().Replace(Environment.NewLine, "<br/>")%><br />
                <strong>Country: </strong>
                <%=this.dtProductProfile.Rows[0]["Country"].ToString().Replace(Environment.NewLine, "<br/>")%>.--%></p></div></td></tr><tr><td colspan="2"><div style="line-height:20px; margin:0px; padding:0px; position:relative"><strong>Source: </strong><%=this.dtProductProfile.Rows[0]["Source"].ToString().Replace(Environment.NewLine, "<br/>")%><br /><strong>Location: </strong><%=this.dtProductProfile.Rows[0]["Items_Location"].ToString().Replace(Environment.NewLine, "<br/>")%><br /><strong>Posted On: </strong><%=this.dtProductProfile.Rows[0]["InsertedOn"].ToString().Replace(Environment.NewLine, "<br/>")%><br /><!--strong>DeadLine: </strong>
                <%=this.dtProductProfile.Rows[0]["DeadLine"].ToString().Replace(Environment.NewLine, "<br/>")%>        
                //<br /--><strong>Category: </strong><%=this.dtProductProfile.Rows[0]["Subcategory"].ToString().Replace(Environment.NewLine, "<br/>")%><asp:Panel ID="pnlPrice" runat="server" Width="100%">
                <strong style="font-size: 12px; ">
                Price: </strong>
                <span class="price">
                 
                 <asp:Label ID="lblPricingOffer" runat="server"></asp:Label>     
                </span>
                </asp:Panel> <asp:Panel ID="pnlAlternatePriceOffer" runat="server" Width="100%" Visible="false">
                <strong>Alternate Offer: </strong>
                <%=this.dtProductProfile.Rows[0]["PricingOffer"]%>        
                </asp:Panel> <asp:Panel runat="server" ID="Panel3" Width="100%">

                <strong>Description: </strong>
                <div class="" style="overflow-x:auto; padding:10px">
                <p style="word-break:normal; word-wrap:normal; width:90%">
                <%=this.dtProductProfile.Rows[0]["ProductDescription"].ToString().Replace(Environment.NewLine, "<br/>")%>  
                </p>
                </div>
                </asp:Panel> </div></td></tr></table></td><td valign="top"><div class="set2_t" style="width:100%"><div class="set2_b"><div class="set2_l"><div class="set2_r"><div class="set2_bl"><div class="set2_br"><div class="set2_tl"><div class="set2_tr" style=" padding:10px;"><strong>&nbsp;</strong> <table border="0" align="center" cellpadding="0" cellspacing="0" class="notdborder"><tr><td colspan="2" style="width: 249px"><strong><u>CONTACT POSTER BY EMAIL</u></strong> <br /><br /></td></tr><tr><td colspan="2" style="width: 249px">Your Email <asp:RequiredFieldValidator 
                ID="rfvEmail" 
                runat="server" 
                ErrorMessage="Email field is blank !" 
                ControlToValidate="txtEmail" 
                Font-Bold="True" 
                SetFocusOnError="True">?</asp:RequiredFieldValidator> <asp:RegularExpressionValidator 
                ID="revEmail" 
                runat="server" 
                ControlToValidate="txtEmail"
                ErrorMessage="Invalid email address !" 
                Font-Bold="True" 
                SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">?</asp:RegularExpressionValidator> </td></tr><tr><td height="30" colspan="2" style="width: 249px"><asp:TextBox 
                ID="txtEmail" 
                runat="server" 
                CssClass="textbox" 
                MaxLength="100" 
                Width="240px" EnableViewState="False"></asp:TextBox> </td></tr><tr><td colspan="2" style="height: 14px; width: 249px;">Your Name <asp:RequiredFieldValidator 
                ID="rfvName" 
                runat="server" 
                ErrorMessage="Name field is blank !" 
                ControlToValidate="txtName" 
                Font-Bold="True" 
                SetFocusOnError="True">?</asp:RequiredFieldValidator> </td></tr><tr><td height="30" colspan="2" style="width: 249px"><asp:TextBox 
                ID="txtName" 
                runat="server" 
                CssClass="textbox" 
                MaxLength="200" 
                Width="240px" EnableViewState="False"></asp:TextBox> </td></tr><tr><td colspan="2" style="width: 249px">Message <asp:RequiredFieldValidator 
                ID="rfvMessage" 
                runat="server" 
                ErrorMessage="Message field is blank !" 
                ControlToValidate="txtMessage" 
                Font-Bold="True" 
                SetFocusOnError="True">?</asp:RequiredFieldValidator> </td></tr><tr><td height="30" colspan="2" style="width: 249px"><asp:TextBox 
                ID="txtMessage" 
                runat="server" 
                CssClass="textbox" 
                Height="50px" 
                MaxLength="300"
                TextMode="MultiLine" 
                Width="240px" EnableViewState="False"></asp:TextBox> </td></tr><tr><td colspan="2" style="width: 249px; height: 30px;">&nbsp;</td></tr><tr><td  align="center" colspan="2" style="width: 249px; height:30px"><asp:Button 
                ID="btnSend" 
                runat="server"  
                Text="Send" 
                Width="90px" 
                EnableViewState="False" OnClick="btnSend_Click"/> <asp:TextBox 
                ID="txtProductID" 
                runat="server" 
                Visible="False" 
                Width="17px">
            </asp:TextBox> </td></tr></table><div align="right">&nbsp;</div></div></div></div></div></div></div></div></div></td>&nbsp &nbsp; &nbsp &nbsp; &nbsp; &nbsp; &nbsp &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp </tr></table><br /><div class="set3_t" style="border-right: silver 0px solid; border-top: silver 0px solid;
            border-left: silver 0px solid; border-bottom: silver 0px solid"><div class="b"><div class="l"><div class="r"><div class="bl"><div class="br"><div class="set3_tl"><div class="set3_tr" style="padding-right: 10px; padding-left: 10px; padding-bottom: 10px;
                                        padding-top: 10px; text-align: justify"><div class="pageTitle colortitle" style="clear: both"><span style="font-size: 10pt"><strong>How to Buy this Product or Service:</strong></span></div><br />Thank you for your interest in this product / Service. If you are considering buying or taking this product or service here is the option you have. Please look for the <strong>“CONTACT POSTER BY EMAIL”</strong> box.<br /><br />After <strong>“CONTACT POSTER BY EMAIL” </strong>an automated email will send to the ad poster as notification. <br /><br />Furthermore You can also directly contact with the seller through phone or email.<br /><br />For more questions, please email us at <a href="mailto:order@apnerdeal.com"><span style="text-decoration: underline">order@apnerdeal.com</span></a></div></div></div></div></div></div></div></div><br /><br /><br /><table border="0" cellpadding="0" cellspacing="0" class="listing" width="100%"><tr><td align="left" colspan="2"><ContentTemplate>
                            <span style="font-size: 15pt; color: #898989; text-decoration: underline">Please Post your comment on this Product or Service</span>&nbsp;<br />
                            <br />
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <div style="background-color: #F5F5F5; padding-top: 5px; padding-bottom: 5px;">
                                <ul>
                                    <li><strong>
                                        <%# DataBinder.Eval(Container.DataItem, "CriticsName")%>
                                    </strong>&nbsp - says, on <span style="color: Red;">
                                        <%# DataBinder.Eval(Container.DataItem, "Posted")%>
                                    </span>
                                        <br />
                                        <br />
                                        <%# DataBinder.Eval(Container.DataItem, "Review")%>
                                    </li>
                                </ul>
                            </div>
                            <br />
                        </ItemTemplate>
                    </asp:Repeater>
                            <br />
                    Your Name:<asp:Label ID="lblCriticsName" runat="server" EnableViewState="False" ForeColor="Red"
                        Width="215px">
        </asp:Label><br />
                    <asp:TextBox ID="txtCriticsName" runat="server" CssClass="textbox" Width="270px">
        </asp:TextBox><br />
                    Your Comments:<asp:Label ID="lblComments" runat="server" EnableViewState="False" ForeColor="Red"
                        Width="215px">
        </asp:Label><br />
                    <asp:TextBox ID="txtComments" runat="server" CssClass="textbox" Height="176px" TextMode="MultiLine"
                        Width="270px">
        </asp:TextBox><br />
                    <asp:Button ID="btnPost" runat="server" BorderStyle="Groove" CausesValidation="False"
                        OnClick="btnPost_Click" Text="Post" Width="87px" />
                        </ContentTemplate>
                                            &nbsp;&nbsp;&nbsp &nbsp;&nbsp &nbsp;&nbsp &nbsp;&nbsp &nbsp;&nbsp </td></tr></table></td><!--END: CONTENT HOLDER (1st Column)--><!--BEGIN: GOOGLE ADS (2nd Column)-->
<td valign="top" style="width:17%; padding-left:10px;"><%--For google adsense--%>
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
<!--END: GOOGLE ADS (2nd Column)--></tr>
</table>
</asp:Content>

