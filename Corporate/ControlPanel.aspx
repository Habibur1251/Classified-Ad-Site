<%@ Page Language="C#" MasterPageFile="~/Corporate/MPCorporate2.master" validateRequest="false" AutoEventWireup="true" CodeFile="ControlPanel.aspx.cs" Inherits="Corporate_ControlPanel" Title="ApnerDeal.com – Corporate Control Panel." %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="cc" Namespace="TinyMceEditor" %>
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
<table width="850px" cellpadding="5px" cellspacing="0px" border="0px">
<tr>
<td align="left" >

<span class="pageTitle">
    Business – Posted Ads.</span><br />
<span class="gray11px" style="font-weight:normal; margin-top:7px;">ApnerDeal.com is absolutely <strong style="color:#EC2024;">FREE</strong> for posting classified Ads. It will not cost you anything.</span>

</td>
<%--<td align="right" style="text-align:right; width:200px;">

<a href="SelectCategory.aspx">
&nbsp;</a></td>--%>
</tr>
</table>

<table align="center" width="100%" border="0" cellspacing="0" cellpadding="3px">
<tr>
<td align="left">
<b>Current Tab:</b>
<asp:Label runat="server" ID="CurrentTab" CssClass="price" /><br />
 <asp:Label runat="server" ID="Messages" CssClass="price" />
</td>
</tr>
<tr>
<td align="left">
    <asp:Label ID="lblSystemMessage" runat="server" EnableViewState="False" 
        Font-Size="11px" ForeColor="Red" Width="500px"> </asp:Label>
    </td>
</tr>
<tr>
<td align="left" valign="top" style="height:auto; width:865px;">
<cc1:TabContainer runat="server" ID="Tabs" Height="900px" 
        OnClientActiveTabChanged="ActiveTabChanged" ActiveTabIndex="0" Width="865px">
    <cc1:TabPanel runat="server" ID="Panel1" HeaderText="My Posted Discount">
    <ContentTemplate>


 <asp:UpdatePanel ID="updatePanel100" runat="server">
     <contenttemplate>
<table><tbody><tr><td><div style="BORDER-RIGHT: #ffaa0d 1px solid; PADDING-RIGHT: 2px; BORDER-TOP: #ffaa0d 1px solid; PADDING-LEFT: 2px; PADDING-BOTTOM: 2px; VERTICAL-ALIGN: top; BORDER-LEFT: #ffaa0d 1px solid; WIDTH: 830px; PADDING-TOP: 2px; BORDER-BOTTOM: #ffaa0d 1px solid; HEIGHT: 20px; BACKGROUND-COLOR: #fff2d9" class="floatleft"><span style="FONT-SIZE: 16px" class="price mediumfont">List of your posted Discount.</span></div></td></tr><tr><td><div style="BORDER-RIGHT: #ffaa0d 1px solid; BORDER-TOP: #ffaa0d 1px solid; PADDING-LEFT: 5px; PADDING-BOTTOM: 2px; VERTICAL-ALIGN: top; BORDER-LEFT: #ffaa0d 1px solid; WIDTH: 830px; PADDING-TOP: 5px; BORDER-BOTTOM: #ffaa0d 1px solid; HEIGHT: auto; BACKGROUND-COLOR: #fff2d9" align="center"><TABLE style="WIDTH: 452px" align=center><TBODY><TR><TD style="WIDTH: 325px" align=right>Company Name: </TD><TD style="WIDTH: 469px" align=left><asp:DropDownList id="ddlCompanyName" runat="server" Width="180px" DataValueField="CategoryID" DataTextField="Category" AppendDataBoundItems="True" OnSelectedIndexChanged="ddlCompanyName_SelectedIndexChanged" AutoPostBack="True" __designer:wfdid="w212">
                                        <asp:ListItem Text="Select Company Name" Value="-1"></asp:ListItem>
                                    </asp:DropDownList> <asp:RequiredFieldValidator id="rfvCompany" runat="server" Font-Bold="True" ErrorMessage="Select Company" ControlToValidate="ddlCompanyName" InitialValue="-1" __designer:wfdid="w213">?</asp:RequiredFieldValidator> <asp:LinkButton id="btnChangeCategory" onclick="btnChangeCategory_Click" runat="server" Visible="False" Font-Underline="true" Font-Size="12px" Font-Names="verdana,arial,helvetica,sans-serif" __designer:wfdid="w214">Refine Search</asp:LinkButton> </TD></TR></TBODY></TABLE></DIV></TD></TR><TR><TD style="WIDTH: 850px; HEIGHT: auto" vAlign=top align=left><DIV style="BORDER-RIGHT: #ffaa0d 1px solid; PADDING-RIGHT: 2px; BORDER-TOP: #ffaa0d 1px solid; PADDING-LEFT: 2px; PADDING-BOTTOM: 2px; VERTICAL-ALIGN: top; BORDER-LEFT: #ffaa0d 1px solid; WIDTH: 840px; PADDING-TOP: 2px; BORDER-BOTTOM: #ffaa0d 1px solid; BACKGROUND-COLOR: #ffffff" class="floatleft"><asp:Label id="lblSystemMessageDiscount" runat="server" Width="500px" ForeColor="Red" Font-Size="11px" EnableViewState="False" __designer:wfdid="w215">
    </asp:Label> <asp:GridView id="GridView2" runat="server" Width="840px" Font-Size="9px" Font-Names="Verdana" OnRowCommand="GridView11_RowCommand" PageSize="20" AllowPaging="true" GridLines="None" DataKeyNames="CouponID,CouponCode,ProfileID" AutoGenerateColumns="false" FooterStyle-BorderStyle="Solid" PagerStyle-CssClass="paging" __designer:wfdid="w216">
<PagerSettings Position="TopAndBottom"></PagerSettings>

<FooterStyle BorderStyle="Solid">
</FooterStyle>
<Columns>
<asp:TemplateField>
<HeaderTemplate>
<table align=Right>
<tr>
<td style="text-align: left; font-size:10px; padding-left:0px;font-family:Verdana;font-weight:bold;">
  Page
    <%=GridView2.PageIndex + 1%>
</td>
<td width="50px">
</td>
<td style="text-align: center;font-family:Verdana; font-size:10px; font-weight:bold;">
Displaying
    <%=  (GridView2.PageIndex * GridView2.PageSize) + 1%>
   -
    <%= GridView2.Rows.Count < GridView2.PageSize ? Total_RecordDiscount : (GridView2.PageIndex + 1) * 20%>
</td>
<td width="20px">
</td>
<td style="text-align: right; padding-right: 20px; font-size:10px; font-family:Verdana;font-weight:bold;">
Total :
<%=Total_RecordDiscount%>
discount found
</td>
<td width="100px">
</td>
<td>
 <asp:Button ID="resetvaluesButtonDiscount" OnClick="resetvaluesButtonDiscount_Click" runat="server" Font-Bold=
 true ForeColor="#FFFFFF" BorderColor="#339966" BorderWidth="1px" BorderStyle="Outset" BackColor="#339966" Text="Reset values" />
</td>
<td>
 <asp:Button ID="saveChangeInnerButtonDiscount" OnClick="saveChangeInnerDiscount" runat="server"  Font-Bold="true" BorderColor="#ffcc00" BorderWidth="1px" BorderStyle="Outset" BackColor="#ff9900" Text="Save changes" />
</td>
</tr>
</table>
<br />
<br />
<br />
  <table cellpadding="0px" height="25px"  cellspacing="0px" border="1px"  width="100%" style="text-align:center;border-collapse:collapse; border:1px solid #98bf21;font-size:10px; font-weight:bold; font-family:Verdana;">

            <tr style="text-align:center;border:1px; border-collapse:collapse; border-bottom-style:solid; border-color:#98bf21" >
            <td style="width:115px;border:1px; border-collapse:collapse; border-bottom-style:solid; border-color:#98bf21">Posted Date</td>
            <td style="width:85px;border:1px;border-collapse:collapse; border-bottom-style:solid; border-color:#98bf21">Coupon Code</td>
            <td style="width:170px;border:1px;border-collapse:collapse; border-bottom-style:solid; border-color:#98bf21">Title</td>
            <td style="width:80px;border:1px;border-collapse:collapse; border-bottom-style:solid; border-color:#98bf21">Starts Date</td>
            <td style="width:80px;border:1px;border-collapse:collapse; border-bottom-style:solid; border-color:#98bf21">Expires Date</td>
            <td style="width:68px;border:1px;border-collapse:collapse; border-bottom-style:solid; border-color:#98bf21">Viewed</td>
            <td style="width:120px;border:1px;border-collapse:collapse; border-bottom-style:solid; border-color:#98bf21">Active/Inactive</td>
            <td style="width:70px;border:1px;border-collapse:collapse; border-bottom-style:solid; border-color:#98bf21">Edit</td>
            </tr>
</table>
          
</HeaderTemplate>
<ItemTemplate>
        <table cellpadding="0px" cellspacing="0px" border="1em" width="100%" style="text-align:center;border-collapse:collapse;border:1px solid #98bf21;">
        <tr>
         <td style="width:115px;border:1px; border-bottom-style:solid; border-color:#98bf21"><%#Eval("DiscountInsertedOn")%></td>
        <td style="width:85px; border:1px; border-bottom-style:solid; border-color:#98bf21">
        <%#Eval("CouponCode")%></td>
         <td style="width:170px;border:1px; border-bottom-style:solid; border-color:#98bf21">
         <b><%#Eval("CouponTitle")%></b>
        </td>
        <td align="center" style="width:80px;border:1px; border-bottom-style:solid; border-color:#98bf21">
        <asp:TextBox ID="effectiveDateTextBox" style="text-align:center;" Width="75px" BorderColor="#98bf21" BorderStyle="Solid" BorderWidth="1px"  Text=<%#Eval("CouponEffectiveDate")%> runat="server"></asp:TextBox>   
        <cc1:CalendarExtender ID="CalendarExtender1" CssClass="cal_Theme1" Format="dd/MM/yyyy" TargetControlID="effectiveDateTextBox" runat="server">
                </cc1:CalendarExtender>
        </td>        
        <td style="width:80px;border:1px; border-bottom-style:solid; border-color:#98bf21">
        <asp:TextBox ID="expirydateTextBox" style="text-align:center;" Width="75px" BorderColor="#98bf21" BorderStyle="Solid" BorderWidth="1px"  Text=<%#Eval("CouponExpirydate")%> runat="server"></asp:TextBox>
         <cc1:CalendarExtender ID="CalendarExtender2" CssClass="cal_Theme1" Format="dd/MM/yyyy" TargetControlID="expirydateTextBox" runat="server">
                </cc1:CalendarExtender>
               
         </td>
        <td style="width:68px;border:1px; border-bottom-style:solid; border-color:#98bf21">
       <%#Eval("HitCounter")%>
        </td>
        <td style="width:120px;border:1px; border-bottom-style:solid; border-color:#98bf21">
        <asp:LinkButton Font-Bold="true" ForeColor="#FFFFFF" Font-Size="12px" ToolTip="Click here to active Or inactive your discount" BorderStyle="Solid" BackColor="DimGray" ID="lbtnChangeDiscount" runat="server" OnClick="ActiveInactiveDiscount_Click" CommandName="Change" CommandArgument='<%#Eval("CouponID") + ";" +Eval("ProfileID") + ";" +Eval("CouponCode")%>'> <%# Eval("IsActive")%> </asp:LinkButton>
        </td>
        <td style="text-align:center;width:70px;border:1px; border-bottom-style:solid; border-color:#98bf21">
        <a href="DiscountProfileEdit.aspx?PI=<%#Eval("ProfileID")%>&CI=<%#Eval("CouponID")%>&CC=<%#Eval("CouponCode")%>">
        Edit&nbsp;<img src="../Images/UniversalEditButton.png" border="0" width="15px" height="15px" />
        </a>
        </td>
        </tr>
        </table>
               
</ItemTemplate>
</asp:TemplateField>
</Columns>

<FooterStyle BackColor="#2E4D7B" Height="20px" ForeColor="White" Font-Size="10px" Font-Names="Verdana" Font-Bold="True" />
<PagerStyle BackColor="Gainsboro" BorderStyle="None" CssClass="paging" BorderColor="Linen"></PagerStyle>

<HeaderStyle BackColor="#FFF2D9" Height="20px" ForeColor="Black" Font-Size="10px" Font-Names="Verdana" Font-Bold="True"></HeaderStyle>

<alternatingrowstyle backcolor="#d3deef"></alternatingrowstyle>
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
