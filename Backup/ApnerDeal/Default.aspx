<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/New.master" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<asp:Content ContentPlaceHolderID="content" runat="server">
    <%@ Register Src="UserControl/ClassifiedCounter.ascx" TagName="ClassifiedCounter"
    TagPrefix="uc1" %>
<%@ Register Src="UserControl/HP_LatestClassifiedsAds.ascx" TagName="HP_LatestClassifiedsAds"
    TagPrefix="uc2" %>
 <%@ Register Src="~/UserControl/CountDiscountByCategory.ascx" TagName="HPDL_CountDiscountByCategory_Ctrl"
    TagPrefix="uc5" %>
<%@ Register Src="~/UserControl/SearchCtrlDiscount.ascx" TagName="Search_Inner_Ctrl"
    TagPrefix="uc4" %>
 <%@ Register Src="~/UserControl/FeaturedStoresInDiscountZone.ascx" TagName="HPDL_FeaturedStores_Ctrl"
    TagPrefix="uc3" %>
 <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
     <title>www.ApnerDeal.com: Deals and discounts site of Bangladesh</title>
    <meta name="description" content="Discounts, Coupons, Deals, Price Reduction news, Classified ads all in one place"/>
    <meta name="keywords" content="Best deals on travel,Classified free ads,Bangladesh news,online free advertisement,hotels for cheap,Dhaka Deals Discounts,Bangladeshi Deals Discounts, apnerdeal.com"/>
    <meta name="GOOGLEBOT" content="INDEX, FOLLOW"/>
    <meta name="ROBOTS" content="INDEX, FOLLOW"/>
    <meta name="REVISIT-AFTER" content="6 days"/>
    <meta name="google-site-verification" content="Q_TOQf3gNBZaJjv-XNQZQMuJNDnBnBRoPicmN5nkUlk" />
    <link href="css/templatemo_style.css" rel="stylesheet" type="text/css" />
    <link href="css/style.css" rel="stylesheet" type="text/css" /> 
    <link href="css/Calender.css" rel="stylesheet" type="text/css" />
    <link href="CSS/styleDiscount.css" rel="stylesheet" type="text/css" />       
     <script type="text/javascript" src="Script/jquery-1.3.2.min.js">
    </script>
    <script src="Script/DateValidation.js" type="text/javascript"></script>
     <script type="text/javascript">
    function genericPopup(href,width,height,scrollbars,resizable,top,left,toolbar,status,directories,menubar){var param="width="+width+", height="+height+", scrollbars="+scrollbars+", resizable="+resizable+",top="+top+",left="+left+",toolbar="+toolbar+",status="+status+",directories="+directories+",menubar="+menubar+"";return window.open(href,"",param);}
    </script>
     <style type="text/css">
         .style1
         {
             width: 434px;
         }
         .style2
         {
          width: 428px;
         }
         .style3
         {
             height: auto;
             width: 428px;
         }
     </style>

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


</head>
<body>

<div id="fb-root"></div>

<script>(function(d, s, id) {
  var js, fjs = d.getElementsByTagName(s)[0];
  if (d.getElementById(id)) return;
  js = d.createElement(s); js.id = id;
  js.src = "//connect.facebook.net/en_US/all.js#xfbml=1";
  fjs.parentNode.insertBefore(js, fjs);
}(document, 'script', 'facebook-jssdk'));</script>

    <form id="form1">
     <asp:ScriptManager ID="sm" runat="server" EnablePartialRendering="true">
    <Scripts>
    <asp:ScriptReference Path="~/JavaScript/thickbox-compressed.js" />
    <asp:ScriptReference Path="~/JavaScript/jquery.blockUI.js" />
    </Scripts>
    </asp:ScriptManager>
    
               
            <div class="scroller">
			<ul class="lp_frontpage">
				<marquee>
				<li><a href="#"><img width="200" height="100" src="images/templatemo_image_01.jpg" alt="Image 01" /></a></li>
				<li><a href="#"><img width="200" height="100" src="images/templatemo_image_02.jpg" alt="Image 02" /></a></li>
				<li><a href="#"><img width="200" height="100" src="images/templatemo_image_03.jpg" alt="Image 03" /></a></li>
				<li><a href="#"><img width="200" height="100" src="images/templatemo_image_04.jpg" alt="Image 04" /></a></li>
				<li><a href="#"><img width="200" height="100" src="images/templatemo_image_01.jpg" alt="Image 01" /></a></li>
				<li><a href="#"><img width="200" height="100" src="images/templatemo_image_02.jpg" alt="Image 02" /></a></li>
				<li><a href="#"><img width="200" height="100" src="images/templatemo_image_03.jpg" alt="Image 03" /></a></li>
				<li><a href="#"><img width="200" height="100" src="images/templatemo_image_04.jpg" alt="Image 04" /></a></li>
				<li><a href="#"><img width="200" height="100" src="images/templatemo_image_01.jpg" alt="Image 01" /></a></li>
				<li><a href="#"><img width="200" height="100" src="images/templatemo_image_02.jpg" alt="Image 02" /></a></li>
				<li><a href="#"><img width="200" height="100" src="images/templatemo_image_03.jpg" alt="Image 03" /></a></li>
				<li><a href="#"><img width="200" height="100" src="images/templatemo_image_04.jpg" alt="Image 04" /></a></li></marquee>
			</ul>
			</div>
			<div class="col_w900 hr_divider">
			
              	<div class="col_allw280 frontpage_box">
                    <img src="images/templatemo_bc_blue.png" alt="Image" />
                    <h2>Welcome ApnerDeal</h2>
                    <span class="tagline">Best Deals and Discounts Service</span>
                    <p>ApnerDeal.com is an online marketplace where customers will get all news of Bangladeshi discounts. Customer always wants to buy good things in reasonable price and seller always wants to sell good things in good price. ApnerDeal.com make this wish happen for both of them.</p>
                </div>
				<div class="col_allw560 frontpage_box">
					
					<div class="col_allw280 frontpage_box">
						<img src="images/templatemo_bc_orange.png" alt="Image" />
						<h2>Discount Service</h2>
						<span class="tagline">Best Deals and Discounts Service</span>
						<p>ApnerDeal.com is an online marketplace where customers will get all news of Bangladeshi discounts. Customer always wants to buy good things in reasonable price and seller always wants to sell good things in good price. ApnerDeal.com make this wish happen for both of them.</p>
					</div>
					
					<div class="col_allw280 frontpage_box col_last">     
						<img src="images/templatemo_bc_orange.png" alt="Image" />
						<h2>Classidied Ads</h2>
						<span class="tagline">Best Deals and Discounts Service</span>
						<p>ApnerDeal.com is an online marketplace where customers will get all news of Bangladeshi discounts. Customer always wants to buy good things in reasonable price and seller always wants to sell good things in good price. ApnerDeal.com make this wish happen for both of them.</p>
					</div>
				</div>
                <div class="cleaner"></div>
            </div>
        
    <div class="col_w900 hr_divider">    
        <div class="col_w520 lp_box float_l">          
 
               <asp:GridView 
                    ID="grvListDiscountLeftpannel"
                    runat="server" 
                    Width="700px"
                    GridLines="None"
                    AutoGenerateColumns="False" FooterStyle-BorderStyle="Solid"  PagerStyle-CssClass="paging" OnRowDataBound="grvListDiscountLeftpannel_RowDataBound" BackColor="White">
               
                     <PagerSettings Position="TopAndBottom"></PagerSettings>
                     <FooterStyle BackColor="white" Height="1px" ForeColor="white" Font-Size="10px" Font-Names="Verdana" BorderStyle="Solid" />
                    <PagerStyle BackColor="white" BorderStyle="None" BorderColor="white" ForeColor="white"></PagerStyle>
                    <HeaderStyle BackColor="white" Height="1px" ForeColor="white" Font-Size="10px" Font-Names="Verdana" Font-Bold="True"></HeaderStyle>
                   <AlternatingRowStyle BackColor="white" />
               
               <Columns>
               <asp:TemplateField>
               <HeaderTemplate>
                <table class="table" cellspacing="0"> 
                <tbody>
                            <tr>
								<th>Store</th>
								<th>Discount Details</th> 
							     <th>Coupon code</th> 
							</tr> <!-- Table Header --><!-- Table Row --> 
               </tbody>
               </table>
               </HeaderTemplate>
               <ItemTemplate>
               <table class="table" cellspacing="0"> 
                <tbody>
              <!-- <table width="100%" cellpadding="5" cellspacing="1" border="0">-->
               <tr>

               <td>
                <a target="_self" style="" class="onHoverTitleLinkDiscount title" href="DiscountList.aspx?mode=0&PI=<%#Eval("ProfileID") %>&CN=<%#Eval("CompanyName") %>">
               <img src='<%#Eval("ImagePath")%>' onerror="javascript:this.src='Images/CompanyDefaultImage.png';"
               style="width: 80px; border: none;"  alt="" height="75">
                 </a>
             &nbsp;&nbsp;</td>

             <!--  <td class="DiscountContent" valign="top"  style="width:300px; height:auto">--->
             <td>
                <asp:PlaceHolder ID="phCouponLink" runat="server">
                </asp:PlaceHolder>

                 <p>
                 <span style=" color:Black; width:100px;"><%#Eval("CouponDescription")%></span>
                 </p>
                    
                 <p class="info">                
                   <span class="expire">
                  *This Coupon Expires:</span>
                   <%#Eval("CouponExpirydate")%><br />
                   
                   <span class="start">
                   *This Coupon Starts On:</span>
                    <%#Eval("CouponEffectiveDate")%><br /><br/>
                     
                     <span class="seeall">*See All: </span>
                        <a target="_blank" style="" class="onHoverRedLink colortitle" href="DiscountList.aspx?mode=0&PI=<%#Eval("ProfileID") %>&CN=<%#Eval("CompanyName") %>"><u><%#Eval("CompanyName")%>(<%#Eval("NoOfDiscount")%>)</u></a>
                  </p>
               </td>
               <td>
                <span style="font-size:9px;"><%#Eval("CouponCode")%></span>
               </td>

               </tr>
               </tbody>
               </table>
        <!---       <hr size="1" style="color:#5C9EBF;" />--->
               </ItemTemplate>
               </asp:TemplateField>
               </Columns>
               </asp:GridView>
               <br />
            
              <a target="_blank" class="onHoverBlue price smallfont" href="ShowAllPrintableDiscount.aspx">View All Discount</a>
        </div>

        <div class="col_w360 float_r">
        
            <uc1:ClassifiedCounter ID="ClassifiedCounter1" runat="server" />
                <br />
            <uc2:HP_LatestClassifiedsAds ID="HP_LatestClassifiedsAds2" runat="server" />
                <br />
            <uc5:HPDL_CountDiscountByCategory_Ctrl ID="HPDL_CountDiscountByCategory_Ctrl1" runat="server" />
                <br />
        </div>
         <div class="col_w360 float_r">
                         <br />
          <uc3:HPDL_FeaturedStores_Ctrl ID="HPDL_FeaturedStores_Ctrl1" runat="server" IsInRoot="false" /><br />
         </div>

 <div class="cleaner"></div>
 </div>   
     
<!---
<table>
<tr>
<td style="width: 440px">
<div style="padding-bottom:0px; padding-top:0px; padding-left:0px;">
    <span style="color: #ffffff">.</span><fb:like-box href="http://www.facebook.com/ApnerDeal" width="425" show_faces="true" stream="false" header="true">
</fb:like-box></div>

</td>

</tr>

<tr>
<td style="width: 440px">
<div style="padding-bottom:0px; padding-top:0px; padding-left:0px;">
    <span style="color: #ffffff">.</span>
    
    <div class="fb-comments" data-href="http://ApnerDeal.com" data-num-posts="2" data-width="425"></div>

</div>

</td>

</tr>


    <tr>
        <td style="width: 440px">
            <span style="color: #ffffff">.</span></td>
    </tr>
    <tr>
        <td style="width: 440px; text-align: center">
            <span style="font-size: 7pt; color: #ff9966">Advertisement</span></td>
    </tr>
    <tr>
        <td style="width: 440px">
            <span style="color: #ffffff">.</span></td>
    </tr>
    <tr>
        <td style="border-right: #ff9933 thin solid; border-top: #ff9933 thin solid; border-left: #ff9933 thin solid;
            width: 440px; border-bottom: #ff9933 thin solid; text-align: center">
            <a target="_blank" href="http://www.banglarestora.com">
                <img src="Images/BanglaRestoraAD.jpg" alt="" style="border-right: white thin solid; border-top: white thin solid; border-left: white thin solid; border-bottom: white thin solid" /></a>
        </td>
    </tr>
    
        <tr>
        <td style="border-right: #ff9933 thin solid; border-top: #ff9933 thin solid; border-left: #ff9933 thin solid;
            width: 440px; border-bottom: #ff9933 thin solid; text-align: center">
            <a target="_blank" href="http://www.channelitv.net/">
                <img src="Images/Channeli.jpg" alt="" style="border-right: white thin solid; border-top: white thin solid; border-left: white thin solid; border-bottom: white thin solid" /></a>
        </td>
        
    </tr>
    
    <tr>
        <td style="border-right: #ff9933 thin solid; border-top: #ff9933 thin solid; border-left: #ff9933 thin solid;
            width: 440px; border-bottom: #ff9933 thin solid; text-align: center">
            <a target="_blank" href="https://www.ekushey.com.bd/">
                <img src="Images/ekushey.GIF" alt="" style="border-right: white thin solid; border-top: white thin solid; border-left: white thin solid; border-bottom: white thin solid" /></a>
        </td>
        
    </tr>
    

</table>
--->


                <asp:Panel ID="pnlProgress" runat="server" Style="background-color: #ffffff; width: 300px">
                    <div style="padding: 5px">
                        <table border="0" cellpadding="5px" cellspacing="0" style="width: 100%">
                            <tbody>
                                <tr>
                                    <td style="width: 50%">
                                    </td>
                                    <td style="text-align: left">
                                        <img alt="" src="images/indicator-big.gif" />
                                    </td>
                                    <td style="text-align: left; white-space: nowrap">
                                        <span style="color: #990000; font-size: 20px; font-weight: bold; font-family: Vrinda;">
                                            Loading Please Wait..</span>
                                    </td>
                                    <td style="width: 50%">
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </asp:Panel>
              
                <cc1:modalpopupextender ID="mpeProgress" runat="server" TargetControlID="pnlProgress"
                    PopupControlID="pnlProgress" 
         BackgroundCssClass="modalBackground" DropShadow="true" />
            </td>
        </tr>
    <asp:Label ID="lblLocation" Font-Underline="true" ForeColor="#990000" runat="server"
        Width="100px" Visible="false" ToolTip="Change Country"> </asp:Label>
    </form>
    <script type="text/javascript">

        Sys.Net.WebRequestManager.add_invokingRequest(onInvoke);
        Sys.Net.WebRequestManager.add_completedRequest(onComplete);

        function onInvoke(sender, args)
        {
            $find('<%= mpeProgress.ClientID %>').show();
        }

        function onComplete(sender, args)
        {
            $find('<%= mpeProgress.ClientID %>').hide();
        }
        function pageUnload()
        {
            Sys.Net.WebRequestManager.remove_invokingRequest(onInvoke);
            Sys.Net.WebRequestManager.remove_completedRequest(onComplete);
        }

    </script>

</body>
</html>
</asp:Content>