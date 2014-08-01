<%@ Page Language="C#" MasterPageFile="~/Corporate/MPCorporate2.master" AutoEventWireup="true" CodeFile="DiscountProfileAE.aspx.cs" Inherits="Corporate_DiscountProfileAE" Title="ApnerDeal.com" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../UserControl/ImageResizeLink_Ctrl.ascx" TagName="ImageResizeLink_Ctrl"
    TagPrefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

   <table width="100%" border="0px" cellspacing="0px" cellpadding="0px">
   <tr>
   <td align="left" style="height: 17px">
   <span class="pageTitle">Add/Edit Discount Information.</span>
   </td>
   <td style="height: 17px">
   </td>
   </tr>
   <tr>
   <td>
   </td>
   <td align="right">
    Fields marked by <span class="mandatory">*</span> are mandatory
   </td>
   </tr>
   </table>
    <table border="0px" cellpadding="0px" cellspacing="0px" class="cptable" width="100%">
    <tr>
    <td align="left" colspan="2" style="font-size: 11px">
        &nbsp;&nbsp;
        <asp:ValidationSummary 
            ID="ValidationSummary1" 
            runat="server" 
            BackColor="#FFFFFF"
            BorderStyle="Dashed" 
            BorderWidth="1px" 
            Font-Bold="False" 
            Font-Size="11px" 
            ForeColor="Black"
            HeaderText="<table><tr><td style='padding-left:10px; padding-top:7px;'><img src='../images/icon_error.gif' width='42' height='40' alt='' /></td><td valign='middle' style='font-weight:bold; text-decoration:underline;color:#ED0000;'>Following error occured :</td></tr></table>"
            Width="500px" />
        <asp:Label 
            ID="lblSystemMessage" 
            runat="server" 
            ForeColor="Red" 
            EnableViewState="False" 
            Width="500px" 
            Font-Size="14px">
       </asp:Label>
    </td>
    </tr>
    </table>
    <table border="0" cellpadding="5px" class="cptable" cellspacing="0" style="border-bottom: #efefe2 1px solid" width="100%">
    <tr>
    <td align="right" style="width: 240px; height:auto;">
     Discount Coupon Title:<span class="mandatory">*</span>
    </td>
     <td align="left" style="height:auto;">
     <br />
     <table>
     <tr>
     <td style="height: 25px">
      <asp:TextBox ID="couponTitleTextBox" runat="server"  Width="295px"></asp:TextBox><br />
      <span class="gray11px">(Maximum 200 characters long.)</span>
     </td>
     <td style="height: 25px">
     <asp:RequiredFieldValidator ID="couponTitleRequiredFieldValidator" runat="server" Font-Bold="True"
            ErrorMessage="Coupon Title field is blank." Text="?" ControlToValidate="couponTitleTextBox">?
        </asp:RequiredFieldValidator>
     </td>
     <td style="height: 25px">
     <span class="gray11px">e.g. 10 Taka off on any DVD purchase or 
20% on all purchase or 
50 Taka off on your purchase of 1000 Taka </span>
     </td>
     </tr>
     </table>
         <asp:RegularExpressionValidator 
                ID="RegularExpressionValidator1" 
                runat="server"
                ControlToValidate="couponTitleTextBox" 
                ErrorMessage="Your Coupon Title is incorrect ! It should be minimum 1 to maximum 200 characters long."
                Font-Size="10px" 
                ValidationExpression="^.{1,200}$" 
                SetFocusOnError="True">
       </asp:RegularExpressionValidator>
    </td>
    </tr>
    <tr>
    <td align="right" style="width: 240px; height:auto;">
        &nbsp;Description:<span class="mandatory">*</span>
    </td>
    <td valign="top" align="left" style="height:auto;">
    <table>
    <tr>
    <td>
    <asp:TextBox ID="couponDescriptionTextBox" runat="server" Height="83px" TextMode="MultiLine" Width="295px"></asp:TextBox><br />
          <span class="gray11px">(Maximum 600 characters long.)</span>
    </td>
    <td>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Font-Bold="True"
            ErrorMessage="Coupon Description is blank." Text="?" ControlToValidate="couponDescriptionTextBox">?
        </asp:RequiredFieldValidator>
    </td>
    <td>
    <span class="gray11px">e.g. Get a 10 Taka off on every DVD you buy. Please print this coupon and bring it to us to get your savings.</span>
    </td>
    </tr>
    </table>
        <%-- <asp:RegularExpressionValidator 
                ID="RegularExpressionValidator3" 
                runat="server"
                ControlToValidate="couponDescriptionTextBox" 
                ErrorMessage="Your Coupon Description is incorrect ! It should be minimum 1 to maximum 600 characters long."
                Font-Size="10px" 
                ValidationExpression="^.{1,600}$" 
                SetFocusOnError="True">
            </asp:RegularExpressionValidator>--%>
    </td>
    </tr>
    <tr>
    <td align="right"  style="width: 240px; height:auto;">
    Do you need the printed coupon from buyers to avail this offer? :<span class="mandatory">*</span>
    </td>
    <td align="left"  style="height:auto;">
    <table>
    <tr>
    <td>
       <asp:RadioButtonList ID="isPrintedCouponNeedRadioButtonList" runat="server" Width="112px" OnSelectedIndexChanged="DiscountType_SelectedIndexChanged" >
        <asp:ListItem Selected="True" Value="True">Yes</asp:ListItem>
        <asp:ListItem Value="False">No</asp:ListItem>
        </asp:RadioButtonList>
    </td>
    <td>
    <asp:RequiredFieldValidator id="RequiredFieldValidator5" runat="server" Font-Bold="True" ControlToValidate="isPrintedCouponNeedRadioButtonList" Text="?" ErrorMessage="printed coupon from buyers option is blank.">?
        </asp:RequiredFieldValidator>
    </td>
    <td style="width:auto;">
    <span class="gray11px">If need to print this coupon for discunt offer then you can select *Yes otherwise, please select *No.</span>
    </td>
    </tr>
    </table>
    </td>
    </tr>
    <tr>
    <td align="right" style="width: 240px; height:auto;">
        Effective from:<span class="mandatory">*</span>
    </td>
    <td align="left" style="height:auto;">
        <asp:TextBox ID="txtFromDate" runat="server" Width="128px" CssClass="textbox"></asp:TextBox>
        <asp:ImageButton ID="ibtnFromDate" runat="server" ImageUrl="~/Images/calendar.gif"
            CausesValidation="False"></asp:ImageButton>
        <asp:RequiredFieldValidator ID="rfvSaleStartDate" runat="server" Font-Bold="True"
            ErrorMessage="Sale start date field is blank." Text="?" ControlToValidate="txtFromDate">?
        </asp:RequiredFieldValidator>
        Choose from calender.
        <cc1:calendarextender id="ceFromDate" runat="server" cssclass="cal_Theme1" Format="MM/dd/yyyy" popupposition="TopRight"
            targetcontrolid="txtFromDate" popupbuttonid="ibtnFromDate">
                                </cc1:calendarextender>
        <span class="gray11px"></span>
        &nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="dateTimeLabel" runat="server" BackColor="Transparent" Font-Bold="True" ForeColor="Red"></asp:Label>
    </td>
    </tr>
    
    <tr>
    <td align="right" style="width: 240px; height:auto;">
     Expiry date:<span class="mandatory">*</span>
    </td>
    <td align="left" style="height:auto;">
    <asp:TextBox 
                                    ID="txtToDate" 
                                    runat="server" 
                                    Width="128px" 
                                    CssClass="textbox"></asp:TextBox>
                                <asp:ImageButton
                                    ID="ibtnToDate" 
                                    runat="server" 
                                    ImageUrl="~/Images/calendar.gif" 
                                    CausesValidation="False">
                                </asp:ImageButton>
                                <asp:RequiredFieldValidator 
                                    ID="RequiredFieldValidator2" 
                                    runat="server"
                                    Font-Bold="True" 
                                    ErrorMessage="Sale end date field is blank." 
                                    Text="?"
                                    ControlToValidate="txtToDate">?
                                 </asp:RequiredFieldValidator>Choose from calender.
                                 <cc1:CalendarExtender 
                                    Format="MM/dd/yyyy"
                                    ID="ceToDate" 
                                    runat="server" 
                                   CssClass="cal_Theme1"
                                    TargetControlID="txtToDate" 
                                    PopupPosition="topLeft"
                                    PopupButtonID="ibtnToDate">
                                </cc1:CalendarExtender>
    </td>
    </tr>
    
     <tr>
    <td align="right" style="width: 240px; height:auto">
    Coupon Type:<span class="mandatory">*</span>
    </td>
    <td align="left" style="height:auto">
        <asp:DropDownList 
                ID="ddlCouponType" 
                runat="server" 
                Width="113px">
                <asp:ListItem Text="In-Store" Value="In-Store"></asp:ListItem>
                <asp:ListItem Text="Online" Value="Online"></asp:ListItem>
            </asp:DropDownList>
    </td>
    </tr>
    
    <tr>
    <td align="right" style="width: 240px; height:auto;">
     Option coupon template:<span class="mandatory">*</span>
    </td>
    <td align="left" style="height:auto;">
    <table>
    <tr>
    <td>
    <asp:RadioButtonList ID="DiscountType" AutoPostBack="true" runat="server" Width="341px" OnSelectedIndexChanged="DiscountType_SelectedIndexChanged" Font-Size="X-Small" >
        <asp:ListItem Value="1">I want to use ApnerDeal Coupon Template</asp:ListItem>
        <asp:ListItem Value="2">I want to upload a Coupon image</asp:ListItem>
        <asp:ListItem Value="3">I want to link to an URL</asp:ListItem>
        </asp:RadioButtonList>
    </td>
    <td>
       <asp:RequiredFieldValidator ID="couponTemplateRequiredFieldValidator" runat="server" Font-Bold="True"
            ErrorMessage="Option template is blank." Text="?" ControlToValidate="DiscountType">?
        </asp:RequiredFieldValidator>
    </td>
    <td>
     <span class="gray11px">If you have an in-house designed coupon then select option two, if you want to link your offer to an web address then select option three otherwise select option one.
</span>
    </td>
    </tr>
    </table>
     </td>
    </tr>
    </table>
    
      <asp:UpdatePanel ID="updatePanel2" runat="server">
            <contenttemplate>
<asp:Panel id="userCouponUpload" runat="server" Width="850px" Visible="false" Enabled="false"><TABLE style="WIDTH: 100%; BORDER-BOTTOM: #efefe2 1px solid" class="cptable" cellSpacing=0 cellPadding=5 border=0><TBODY><TR>
            <TD style="WIDTH: 240px; HEIGHT: auto" align=right>Upload own offer as image:<SPAN class="mandatory">*</SPAN> </TD>
            <TD style="HEIGHT: auto" align=left>
                <asp:FileUpload id="FileUpload1" runat="server" BorderStyle="Groove"></asp:FileUpload> <asp:Button id="btnUpload" onclick="btnUpload_Click" runat="server" CausesValidation="False" Text="Upload"></asp:Button> <asp:Label id="lblImageUploadMessage" runat="server" Width="154px" ForeColor="Red" Font-Size="12px" Font-Bold="True"></asp:Label> <asp:Label id="couponLabel" runat="server" ForeColor="Red" Font-Bold="False"></asp:Label>
                <BR /><SPAN style="COLOR: coral" class="gray11px">Image size must be less then 200 KB.This is optional.PDF or image file.&nbsp; Preferred width height ratio 200 by 300px.<uc4:imageresizelink_ctrl id="ImageResizeLink_Ctrl1" runat="server"></uc4:imageresizelink_ctrl> </SPAN></TD></TR></TBODY></TABLE></asp:Panel> 
</contenttemplate>
            <triggers>
<asp:AsyncPostBackTrigger ControlID="DiscountType"  EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
<asp:PostBackTrigger ControlID="btnUpload"/>
</triggers>
        </asp:UpdatePanel>
 
<asp:UpdatePanel ID="updatePanel3" runat="server">
 <contenttemplate>
<asp:Panel id="urlPanel" runat="server" Width="850px" Enabled="false" Visible="false"><TABLE style="WIDTH: 100%; BORDER-BOTTOM: #efefe2 1px solid" class="cptable" cellSpacing=0 cellPadding=5 border=0><TBODY><TR><TD style="WIDTH: 240px; HEIGHT: auto" align=right>Write or copy the URL:<SPAN class="mandatory">*</SPAN> </TD><TD style="HEIGHT: auto" align=left><TABLE><TBODY><TR><TD><asp:TextBox id="urlTextBox" runat="server" Width="233px" Text="http://"></asp:TextBox> </TD><TD><asp:RequiredFieldValidator id="RequiredFieldValidator4" runat="server" Font-Bold="True" ControlToValidate="urlTextBox" Text="?" ErrorMessage=" Write or copy the URL option is blank.">?
        </asp:RequiredFieldValidator> </TD><TD><SPAN class="gray11px">e.g. http://www.ApnerDeal.com/</SPAN> </TD></TR></TBODY></TABLE><%--<asp:RegularExpressionValidator 
                ID="RegularExpressionValidator10" 
                runat="server"
                ControlToValidate="urlTextBox" 
                ErrorMessage="Your URL is incorrect syntax ! Please Enter correct URL."
                Font-Size="10px" 
                ValidationExpression="^(ht|f)tp(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&amp;%\$#_]*)?$" 
                SetFocusOnError="True">
       </asp:RegularExpressionValidator>--%></TD></TR></TBODY></TABLE></asp:Panel> 
</contenttemplate>
 <triggers>
<asp:AsyncPostBackTrigger ControlID="DiscountType"  EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
</triggers>
 </asp:UpdatePanel>
              
<table border="0px" cellpadding="5px" cellspacing="0px" class="cptable" width="100%">
<tr>
<td align="right" style="width: 234px">
Terms & Conditions<span class="mandatory">*</span>
</td>
<td align="left">
<table>
<tr>
<td>
<asp:TextBox id="termsConditionsTextBox" runat="server" Width="295px" TextMode="MultiLine" Height="80px"></asp:TextBox><br />
<span class="gray11px">(Maximum 350 characters long.)</span>
</td>
<td>
<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Font-Bold="True"
            ErrorMessage="Terms and condition field is blank." Text="?" ControlToValidate="termsConditionsTextBox">?
        </asp:RequiredFieldValidator>
</td>
<td>
<span class="gray11px">e.g.Management Reserve the right to cancel coupon without notice.Can not be combined with another offer special.No cash value and taxes are extra. or One copy of coupon will work for all the DVD purchases you make.</span>
</td>
</tr>
</table>
<%--<asp:RegularExpressionValidator 
                ID="RegularExpressionValidator2" 
                runat="server"
                ControlToValidate="termsConditionsTextBox" 
                ErrorMessage="Your Terms & Conditions is incorrect ! It should be minimum 1 to maximum 350 characters long."
                Font-Size="10px" 
                ValidationExpression="^.{1,350}$" 
                SetFocusOnError="True">
</asp:RegularExpressionValidator>--%>
</td>
</tr>
          <tr>
    <td align="right" style="width: 236px; height: 25px">
    </td>
    <td align="left">
    <asp:Button 
                ID="btnCouponSubmit" 
                runat="server" 
                Text="Submit" 
                CssClass="image_btn" OnClick="btnCouponSubmit_Click"  />
    </td>
    </tr>
    <tr>
    <td style="width: 236px">
    </td>
    <td>
    </td>
    </tr>
    </table>
</asp:Content>

