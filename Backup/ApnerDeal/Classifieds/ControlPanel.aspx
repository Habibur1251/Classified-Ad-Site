<%@ Page Language="C#" MasterPageFile="~/Classifieds/MPClassifieds2.master" AutoEventWireup="true" CodeFile="ControlPanel.aspx.cs" Inherits="Classifieds_ControlPanel" Title="www.apnerdeal.com – Classified User Control Panel." %>

<%@ Register Src="../UserControl/RealEstate_CP_Ctrl.ascx" TagName="RealEstate_CP_Ctrl"
    TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript">
        function PanelClick(sender, e) {
            var Messages = $get('<%=Messages.ClientID%>');
            Highlight(Messages);
        }

        function ActiveTabChanged(sender, e) {
            var CurrentTab = $get('<%=CurrentTab.ClientID%>');
            CurrentTab.innerHTML = sender.get_activeTab().get_headerText();
            Highlight(CurrentTab);
        }

        var HighlightAnimations = {};
        function Highlight(el) {
            if (HighlightAnimations[el.uniqueID] == null) {
                HighlightAnimations[el.uniqueID] = AjaxControlToolkit.Animation.createAnimation({
                    AnimationName : "color",
                    duration : 0.5,
                    property : "style",
                    propertyKey : "backgroundColor",
                    startValue : "#FFFF90",
                    endValue : "#FFFFFF"
                }, el);
            }
            HighlightAnimations[el.uniqueID].stop();
            HighlightAnimations[el.uniqueID].play();
        }
        
        function ToggleHidden(value) {
            $find('<%=Tabs.ClientID%>').get_tabs()[2].set_enabled(value);
        }
</script>
<table width="900px" cellpadding="0px" cellspacing="0px" border="0px">
<tr>
<td align="left" >
<span class="pageTitle">Classifieds – Posted Ads.</span><br />
<span class="gray11px" style="font-weight:normal; margin-top:7px;">ApnerDeal.com is absolutely <strong style="color:#EC2024;">FREE</strong> for posting classified Ads. It will not cost you anything.</span>

</td>
<td align="right" style="text-align:right; width:250px;">
<a href="ProductProfile_Edit.aspx?PageMode=0&CID=12&Location=Bangladesh&PID=-1">
<img src="../Images/sellbtn.gif" border="0" />
</a>
<br />
<asp:Repeater ID="rep" runat="server">
    <ItemTemplate>
    <a class="onHoverBlue price" href="Classifieds_ReviewInformation.aspx?PFI=<%#Eval("ProfileID") %>">
    Review Posted By You (<%#Eval("NoOfReview") %>).
    </a>
    </ItemTemplate>
    </asp:Repeater>
</td>
</tr>
    
</table>
<table cellpadding="0px" style="width: 875px">
<tr>
<td align="left">
<b>Current Tab:</b>
<asp:Label runat="server" ID="CurrentTab" CssClass="price" /><br />
 <asp:Label runat="server" ID="Messages" CssClass="price" />
</td>
</tr>
<tr>
<td align="left">
<cc1:TabContainer runat="server" ID="Tabs" Height="1100px" OnClientActiveTabChanged="ActiveTabChanged" ActiveTabIndex="0" Width="896px">
    
    <cc1:TabPanel runat="server" ID="TabPanel2" HeaderText="My Classified Ads.">
    <ContentTemplate>
      <asp:UpdatePanel ID="updatePanel1002" runat="server">
     <ContentTemplate>
<table><tbody>
    <tr><td>
        <div style="BORDER-RIGHT: #ffaa0d 1px solid; PADDING-RIGHT: 2px; BORDER-TOP: #ffaa0d 1px solid; PADDING-LEFT: 2px; PADDING-BOTTOM: 2px; VERTICAL-ALIGN: top; BORDER-LEFT: #ffaa0d 1px solid; WIDTH: 874px; PADDING-TOP: 2px; BORDER-BOTTOM: #ffaa0d 1px solid; HEIGHT: 20px; BACKGROUND-COLOR: #fff2d9" class="floatleft"><SPAN style="FONT-SIZE: 16px" class="price mediumfont">List of your Classified Ads.</SPAN></DIV></TD></TR>
    <tr><td>
        <div align="center" 
             style="BORDER-RIGHT: #ffaa0d 1px solid; PADDING-RIGHT: 5px; BORDER-TOP: #ffaa0d 1px solid; PADDING-LEFT: 5px; PADDING-BOTTOM: 5px; VERTICAL-ALIGN: top; BORDER-LEFT: #ffaa0d 1px solid; WIDTH: 868px; PADDING-TOP: 5px; BORDER-BOTTOM: #ffaa0d 1px solid; HEIGHT:auto; BACKGROUND-COLOR: #fff2d9">
            <cc1:Accordion 
             ID="Accordion1" runat="server" __designer:wfdid="w20" AutoSize="None" 
             ContentCssClass="accordionContent" FadeTransitions="false" FramesPerSecond="40" 
             HeaderCssClass="accordionHeader" 
             HeaderSelectedCssClass="accordionHeaderSelected" RequireOpenedPane="false" 
             SelectedIndex="0" SuppressHeaderPostbacks="true" TransitionDuration="250" 
             Width="790px">
             <panes>
                  <cc1:AccordionPane ID="AccordionPane2" runat="server">
               <header>
               <table align="center">
               <tr>
               <td>
                <a class="accordionLink" href="">
               <span style=" font-family:Verdana; font-size:15px; color:#FFFFFF; font-weight:bold">Search your Classified Ads by category.</span>
               </a>
               
               </td>
               </tr>
               </table>
               </header>
               <content>
               <table align="center">
               <tr>
               <td>
                 <span 
                       style=" font-family:Verdana; font-size:12px; color:#000000; font-weight:bold">Select Category:</span>
                   <asp:DropDownList ID="ddlClassifiedCategory" runat="server" 
                       AppendDataBoundItems="true" AutoPostBack="true" 
                       OnSelectedIndexChanged="ddlClassifiedCategory_SelectedIndexChanged">
                     <asp:ListItem Text="---Select Category---" Value="-1"></asp:ListItem>
                     <asp:ListItem Text="All" Value="190"></asp:ListItem>
                   </asp:DropDownList>
                   <br />
               </td>
               <td>
               <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Verdana" 
                       Font-Size="10px" ForeColor="#FF9933" Text=""></asp:Label>
               </td>
               </tr>
               </table>
              
               </content>
              </cc1:AccordionPane>
               <cc1:AccordionPane ID="AccordionPane1" runat="server">
               <header>
                 <table align="center">
             <tr>
             <td>
              <a class="accordionLink" href="">
              <span 
                     style=" font-family:Verdana; font-size:15px; color:#FFFFFF; font-weight:bold">Click here to search your products by date range.</span>
                </a>
             </td>
             </tr>
               </table>
               </header>
               <content>
               <table align="center" border="0" cellpadding="0" cellspacing="0" 
             class="cptable" style="margin-top:10px; margin-bottom:10px; width: 750px;">
        <tr>
            <td style="width: 80px; vertical-align: top">
                Start date:
            </td>
            <td style="vertical-align: top;">
                <asp:TextBox ID="txtFromDate" runat="server" CssClass="textbox" MaxLength="10" 
                    Width="110px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtFromDate" Display="Dynamic" 
                    ErrorMessage="Please specify start date" ValidationGroup="cldaterange"></asp:RequiredFieldValidator>
                <cc1:CalendarExtender ID="ceFromDate" runat="server" CssClass="cal_Theme1" 
                    TargetControlID="txtFromDate">
                </cc1:CalendarExtender>
            </td>
            <td style="width: 80px; vertical-align: top">
                End Date:
            </td>
            <td style="vertical-align: top">
                <asp:TextBox ID="txtToDate" runat="server" CssClass="textbox" MaxLength="10" 
                    Width="110px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtToDate" Display="Dynamic" 
                    ErrorMessage="Please specify end date" ValidationGroup="cldaterange"></asp:RequiredFieldValidator>
                <cc1:CalendarExtender ID="ceToDate" runat="server" CssClass="cal_Theme1" 
                    TargetControlID="txtToDate">
                </cc1:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <span class="gray11px">Click on the text box to select date<br />
                </span>
            </td>
            <td style="text-align: left; height: 26px;" colspan="1">
                <asp:Button ID="btnSearch" runat="server" BackColor="green" BorderColor="green" 
                    BorderStyle="Groove" ForeColor="White" OnClick="btnSearch_Click" Text="Search" 
                    ValidationGroup="cldaterange" Width="85px" />
            </td>
        </tr>
    </table>
               
               </content>
               </cc1:AccordionPane>
            </panes>
            </cc1:Accordion> </div></TD></TR><TR>
        <TD><asp:Label ID="lblClassifiedMessage" runat="server" __designer:wfdid="w21" 
             EnableViewState="False" Font-Size="11px" ForeColor="Red" Width="500px">
    </asp:Label> </TD></TR><TR><TD>
        <DIV style="BORDER-RIGHT: #ffaa0d 1px solid; PADDING-RIGHT: 0px; BORDER-TOP: #ffaa0d 1px solid; PADDING-LEFT: 0px; PADDING-BOTTOM: 0px; VERTICAL-ALIGN: top; BORDER-LEFT: #ffaa0d 1px solid; WIDTH: 875px; PADDING-TOP: 0px; BORDER-BOTTOM: #ffaa0d 1px solid; HEIGHT: auto; BACKGROUND-COLOR: #fff2d9" align=center><asp:GridView id="grvClassifiedProduct" runat="server" Width="880px" AutoGenerateColumns="false" DataKeyNames="CategoryID" GridLines="None" AllowPaging="true" PageSize="20" OnPageIndexChanging="grvClassifiedProduct_PageIndexChanging" __designer:wfdid="w22" OnRowDataBound="grvCorporateOrderList_RowDataBound">    
        <Columns>
            <asp:TemplateField>
            <HeaderTemplate>
            
            <table cellpadding="0px" height="25px"  cellspacing="0px" border="1px"  width="100%" style="text-align:center;border-collapse:collapse; border:1px solid #98bf21;font-size:10px; font-weight:bold; font-family:Verdana;">

            <tr style="text-align:center;" >
            <td style="width:150px;border:1px; border-bottom-style:solid; border-color:#98bf21">Product Title</td>
            <td style="width:110px;border:1px; border-bottom-style:solid; border-color:#98bf21">Category</td>
            <td style="width:110px;border:1px; border-bottom-style:solid; border-color:#98bf21">Ads Type</td>
            <td style="width:110px;border:1px; border-bottom-style:solid; border-color:#98bf21">Deadline</td>
            <td style="width:110px;border:1px; border-bottom-style:solid; border-color:#98bf21">InsertedOn</td>
            <td style="width:70px;border:1px; border-bottom-style:solid; border-color:#98bf21">Response</td>
            <td style="width:70px;border:1px; border-bottom-style:solid; border-color:#98bf21">Image</td>
            <td style="width:100px;border:1px; border-bottom-style:solid; border-color:#98bf21">Active/Inactive</td>
            <td style="width:70px;border:1px; border-bottom-style:solid; border-color:#98bf21">Edit</td>
            </tr>
            </table>
            
            </HeaderTemplate>
            <ItemTemplate>
             <table cellpadding="0px" cellspacing="0px" border="1em" width="100%" style="text-align:center;border-collapse:collapse;border:1px solid #98bf21;">
             <tr>
             <td align=left style="width:150px;border:1px; border-bottom-style:solid; border-color:#98bf21">
             <a style="font-weight:bold;  font-family:Verdana; font-size:10px; direction:ltr" target="_blank" href="../ItemDetail_Classifieds.aspx?ItemKey=<%#Eval("ProductID") %>&ProfKey=<%#Eval("ProfileID") %>&CID=<%#Eval("CategoryID") %>&SCID=<%#Eval("SubcategoryID") %>&Location=&AdType=">
            &nbsp;<%#Eval("ProductTitle") %></a></td>
             <td style="width:110px;border:1px; border-bottom-style:solid; border-color:#98bf21">
              <%#Eval("Subcategory")%>
             </td>
             <td style="width:110px;border:1px; border-bottom-style:solid; border-color:#98bf21">
              <%#Eval("AdvertisementType")%>
             </td>
             <td style="width:110px;border:1px; border-bottom-style:solid; border-color:#98bf21">
              <%#Eval("Deadline")%>
             </td>
             
             <td style="width:110px;border:1px; border-bottom-style:solid; border-color:#98bf21">
              <%#Eval("InsertedOn")%>
             </td>
             
              <td style="width:70px;border:1px; border-bottom-style:solid; border-color:#98bf21">
               <a style="font-weight:bold" target="_blank" href="OrderViewer.aspx?PID=<%#Eval("ProductID") %>">     
                <u><%#Eval("Response")%></u>
                 </a>
             </td>
             <td style="width:70px;border:1px; border-bottom-style:solid; border-color:#98bf21">
             <a href="ProductProfile_ImageUploader.aspx?PID=<%#Eval("ProductID") %>"><u>Upload</u></a>
             </td>
             <td style="width:100px;border:1px; border-bottom-style:solid; border-color:#98bf21"><asp:LinkButton Font-Bold="true" ForeColor="#FFFFFF" Font-Size="11px" ToolTip="Click Here To Active Or Inactive Your Ad" BorderStyle="Solid" OnClick="ActiveInactiveClasiified_Click" BackColor="DimGray" ID="lbtnChangeClassifeid" runat="server" CommandArgument='<%#Eval("ProductID") + ";" +Eval("ProductTitle") + ";" +Eval("CategoryID")%>'> <%#Eval("IsAbused")%> </asp:LinkButton></td>
              <td style="width:70px;border:1px; border-bottom-style:solid; border-color:#98bf21">
              <a href="ProductProfile_Edit.aspx?PageMode=1&PID=<%#Eval("ProductID") %>&Product=<%#Eval(" ProductTitle") %>&CID=<%#Eval("CategoryID") %>">
               Edit&nbsp;<img src="../Images/UniversalEditButton.png" border="0" width="15px" height="15px" />
               </a>
             </td>
             </tr>
             </table>
            
             </ItemTemplate>
            </asp:TemplateField>
                        
        </Columns>
        <PagerStyle BackColor="Gainsboro" BorderStyle="None" CssClass="paging" BorderColor="Linen"></PagerStyle>

<HeaderStyle BackColor="#507CD1" Height="20px" ForeColor="White" Font-Size="10px" Font-Names="Verdana" Font-Bold="True" HorizontalAlign="Left"></HeaderStyle>

<AlternatingRowStyle BackColor="#D3DEEF"></AlternatingRowStyle>
        <PagerSettings Position="TopAndBottom" />
    </asp:GridView> </DIV></TD></TR></TBODY></TABLE>
</ContentTemplate>
      </asp:UpdatePanel>
     </ContentTemplate>
     </cc1:TabPanel>
     
     <cc1:TabPanel runat="server" ID="TabPanel3" HeaderText="My Product Order History">
    <ContentTemplate>
       <asp:UpdatePanel ID="updatePanel1003" runat="server">
     <ContentTemplate>
<TABLE><TBODY><TR><TD><DIV style="BORDER-RIGHT: #ffaa0d 1px solid; PADDING-RIGHT: 2px; BORDER-TOP: #ffaa0d 1px solid; PADDING-LEFT: 2px; PADDING-BOTTOM: 2px; VERTICAL-ALIGN: top; BORDER-LEFT: #ffaa0d 1px solid; WIDTH: 860px; PADDING-TOP: 2px; BORDER-BOTTOM: #ffaa0d 1px solid; HEIGHT: 20px; BACKGROUND-COLOR: #fff2d9" class="floatleft"><SPAN style="FONT-SIZE: 16px" class="price mediumfont">My Product Order History.</SPAN></DIV></TD></TR><TR><TD></TD></TR><TR><TD><asp:Label id="lblCorporateOrderMessage" runat="server" Width="500px" Font-Size="11px" EnableViewState="False" ForeColor="Red" __designer:wfdid="w13">
    </asp:Label> </TD></TR><TR><TD><DIV style="BORDER-RIGHT: #ffaa0d 1px solid; PADDING-RIGHT: 0px; BORDER-TOP: #ffaa0d 1px solid; PADDING-LEFT: 0px; PADDING-BOTTOM: 0px; VERTICAL-ALIGN: top; BORDER-LEFT: #ffaa0d 1px solid; WIDTH: 875px; PADDING-TOP: 0px; BORDER-BOTTOM: #ffaa0d 1px solid; HEIGHT: auto; BACKGROUND-COLOR: #fff2d9" align=center><asp:GridView id="grvCorporateOrderList" runat="server" Width="875px" AutoGenerateColumns="false" DataKeyNames="OrderID, CategoryID" GridLines="None" AllowPaging="true" PageSize="15" OnPageIndexChanging="grvCorporateOrderList_PageIndexChanging" __designer:wfdid="w14" OnRowDataBound="grvCorporateOrderList_RowDataBound">    
        <Columns>
            <asp:TemplateField>
            <HeaderTemplate>
            
            <table cellpadding="0px" height="25px"  cellspacing="0px" border="1px"  width="100%" style="text-align:center;border-collapse:collapse; border:1px solid #98bf21;font-size:10px; font-weight:bold; font-family:Verdana;">

            <tr style="text-align:center;" >
            <td style="width:150px;border:1px; border-bottom-style:solid; border-color:#98bf21">Product Title</td>
            <td style="width:80px;border:1px; border-bottom-style:solid; border-color:#98bf21">Quantity</td>
            <td style="width:90px;border:1px; border-bottom-style:solid; border-color:#98bf21">Currency</td>
            <td style="width:90px;border:1px; border-bottom-style:solid; border-color:#98bf21">Unit Cost</td>
            <td style="width:70px;border:1px; border-bottom-style:solid; border-color:#98bf21">SubTotal</td>
            <td style="width:130px;border:1px; border-bottom-style:solid; border-color:#98bf21"> Order Date</td>
            <td style="width:150px;border:1px; border-bottom-style:solid; border-color:#98bf21">Payment Option</td>
            </tr>
            </table>
            
            </HeaderTemplate>
            <ItemTemplate>
            
             <table cellpadding="0px" cellspacing="0px" border="1em" width="100%" style="text-align:center;border-collapse:collapse;border:1px solid #98bf21;">
             <tr>
             <td align=left style="width:150px;;border:1px; border-bottom-style:solid; border-color:#98bf21">
             <a target="_blank" style="font-weight:bold;" href='../Common/<%#Eval("DetailPage") %>?PageMode=1&PSID=<%#Eval("ProductSellerDetailID") %>&PID=<%#Eval("ProductID") %>&CID=<%#Eval("CategoryID") %>&SCID=<%#Eval("SubcategoryID") %>&SSCID=<%#Eval("SecondSubcatID") %>&Location=<%#Eval("Country") %>'>
            &nbsp;<%#Eval("ProductTitle") %>
             </td>
             <td style="width:80px;border:1px; border-bottom-style:solid; border-color:#98bf21">
              <%#Eval("Quantity") %>
             </td>
             <td style="width:90px;border:1px; border-bottom-style:solid; border-color:#98bf21">
              <%#Eval("Currency")%>
             </td>
             <td style="width:90px;border:1px; border-bottom-style:solid; border-color:#98bf21">
             <%#Eval("UnitCost")%>
             </td>
             <td style="width:70px;border:1px; border-bottom-style:solid; border-color:#98bf21">
             <%#Eval("SubTotal")%>
             </td>
             <td style="width:130px;border:1px; border-bottom-style:solid; border-color:#98bf21">
             <%#Eval("CreationDate")%>
             </td>
             <td style="width:150px;border:1px; border-bottom-style:solid; border-color:#98bf21">
             <%#Eval("PaymentOption")%>
             </td>
             </tr>
             </table>
            
             </ItemTemplate>
            </asp:TemplateField>
                        
        </Columns>
        <PagerStyle BackColor="Gainsboro" BorderStyle="None" CssClass="paging" BorderColor="Linen"></PagerStyle>

<HeaderStyle BackColor="#507CD1" Height="20px" ForeColor="White" Font-Size="10px" Font-Names="Verdana" Font-Bold="True" HorizontalAlign="Left"></HeaderStyle>

<AlternatingRowStyle BackColor="#D3DEEF"></AlternatingRowStyle>
        <PagerSettings Position="TopAndBottom" />
    </asp:GridView> </DIV></TD></TR></TBODY></TABLE>
</ContentTemplate>
     </asp:UpdatePanel>
     </ContentTemplate>
     </cc1:TabPanel>
     
     
    </cc1:TabContainer>
</td>
</tr>
</table>
</asp:Content>

