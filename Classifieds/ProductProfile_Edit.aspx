<%@ Page Language="C#" MasterPageFile="~/Classifieds/MPClassifieds2.master" AutoEventWireup="true"
    CodeFile="ProductProfile_Edit.aspx.cs" Inherits="Classifieds_ProductProfile_Edit"
    Title="www.apnerdeal.com - Post a new Ad." %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<asp:UpdatePanel ID="UpdatePanel" runat="server">
        <contenttemplate>
<SCRIPT type="text/javascript">
<!--
    function IsDigit(e)
    {
        var key;
        if (window.event)
        {
            key = window.event.keyCode;
        }
        else if (e)
        {
            key = e.which;
        }
        else
        {
            return true;
        }
        if ((key > 47 && key < 58) || (key > 95 && key < 106))
        {
            return true;
        }
        if ( key==null || key==0 || key==8 || key==9 || key==13 || key==27 || key ==37 || key ==39 || key == 46 || key == 35 || key == 36)
        {
            return true;
        }

        return false;
    } 
    //-->
    <!--       
    function isNumberKey(evt)      
    {         
        var charCode = (evt.which) ? evt.which : event.keyCode         
        if (charCode > 31 && (charCode < 48 || charCode > 57))            
            return true;         
        return false;      
    }
    //-->
    </SCRIPT>
<!--
<div align="right" class="top_secondary_link">
   <a href="#">I want to signup as a General User</a> |
   <a href="#">Switch to General User Control Panel</a> |
   <a href="#">Sign out</a>  
</div>
--><SPAN class="pageTitle">Classifieds - Post/Edit your Ad.</SPAN><BR /><SPAN style="MARGIN-TOP: 7px; FONT-WEIGHT: normal" class="gray11px">ApnerDeal.com is absolutely <STRONG style="COLOR: #ec2024">FREE</STRONG> for posting classified Ads. It will not cost you anything.</SPAN> <BR /><BR /><DIV style="WIDTH: 815px"><TABLE cellSpacing=0 cellPadding=0 width="100%" border=0><TBODY><TR><TD>&nbsp;</TD><TD align=right>Fields marked by <SPAN class="mandatory">*</SPAN> are mandatory</TD></TR><TR><TD style="FONT-SIZE: 11px" align=left colSpan=2><asp:ValidationSummary id="ValidationSummary1" runat="server" BackColor="#FFFFFF" ForeColor="Black" Font-Bold="False" HeaderText="<table><tr><td style='padding-left:10px; padding-top:7px;'><img src='../images/icon_error.gif' width='42' height='40' alt='' /></td><td valign='middle' style='font-weight:bold; text-decoration:underline;color:#ED0000;'>Following error occured :</td></tr></table>" BorderStyle="Dashed" BorderWidth="1px" Font-Size="11px" Width="500px"></asp:ValidationSummary> <asp:Label id="lblSystemMessage" runat="server" ForeColor="Red" Font-Size="11px" Width="500px" EnableViewState="False">
                        </asp:Label> </TD></TR><TR><TD align=left colSpan=2></TD></TR></TBODY></TABLE><TABLE class="cptable" cellSpacing=0 cellPadding=0 width="100%" border=0><!--BEGIN: PRODUCT DETAILS--><TBODY><TR><TD style="COLOR: #365ebf; TEXT-DECORATION: underline" colSpan=2><STRONG><SPAN style="FONT-SIZE: 11pt">Product/Service Details</SPAN></STRONG></TD></TR><TR><TD style="HEIGHT: 54px" align=right>Location:<SPAN class="mandatory">*</SPAN></TD><TD style="HEIGHT: 27px" align=left><asp:RadioButtonList id="rblLocation" runat="server" Width="300px" AutoPostBack="True" RepeatDirection="Horizontal" OnSelectedIndexChanged="rblLocation_SelectedIndexChanged">
                            <asp:ListItem Text="Inside Dhaka" Value="InDhaka" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="Outside Dhaka" Value="OutDhaka"></asp:ListItem>
                        </asp:RadioButtonList> <asp:DropDownList id="ddlLocation" runat="server" Width="300px" AppendDataBoundItems="True">
                            <asp:ListItem Value="-1" Text="Select"></asp:ListItem>
                        </asp:DropDownList> <asp:RequiredFieldValidator id="rfvLocation" runat="server" Font-Bold="True" ControlToValidate="ddlLocation" ErrorMessage="Location is not selected ! Please select the Location properly." SetFocusOnError="True" InitialValue="-1">?</asp:RequiredFieldValidator> </TD></TR><TR><TD style="WIDTH: 160px; HEIGHT: 27px" vAlign=top align=right>Category:<SPAN class="mandatory">*</SPAN></TD><TD style="HEIGHT: 27px" align=left><asp:DropDownList id="ddlCategory" runat="server" Width="300px" AutoPostBack="True" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" AppendDataBoundItems="True">
                            <asp:ListItem Text="Select" Value="-1"></asp:ListItem>
                        </asp:DropDownList> <asp:RequiredFieldValidator id="rfvSubcategory" runat="server" Font-Bold="True" ControlToValidate="ddlSubcategory" ErrorMessage="Category is not selected ! Please select Category." SetFocusOnError="True" InitialValue="-1">?</asp:RequiredFieldValidator> </TD></TR><TR><TD style="BORDER-RIGHT: medium none; PADDING-RIGHT: 0px; BORDER-TOP: medium none; PADDING-LEFT: 0px; PADDING-BOTTOM: 0px; BORDER-LEFT: medium none; PADDING-TOP: 0px; BORDER-BOTTOM: medium none; HEIGHT: 0px" vAlign=top colSpan=2><asp:Panel id="pnlSubcategory" runat="server" Width="100%" Visible="False">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="cptable">
                                <tr>
                                    <td align="right" style="height: 27px; width: 160px">
                                        Subcategory:<span class="mandatory">*</span>
                                    </td>
                                    <td align="left" style="height: 27px">
                                        <asp:DropDownList ID="ddlSubcategory" runat="server" Width="300px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel> </TD></TR><TR><TD style="BORDER-RIGHT: medium none; BORDER-TOP: medium none; BORDER-LEFT: medium none; BORDER-BOTTOM: medium none; HEIGHT: 27px" vAlign=top align="middle" colSpan=2><asp:RadioButtonList id="rblAdvType" runat="server" Width="100%">
                            <asp:ListItem Selected="True" Text="I am offering - You are offering an item for sale/Service"
                                Value="Offer">
                            </asp:ListItem>
                            <asp:ListItem Text="I want - You want to buy an item/Service" Value="Want"></asp:ListItem>
                        </asp:RadioButtonList> </TD></TR></TBODY></TABLE><TABLE class="cptable" cellSpacing=0 cellPadding=0 width="100%" border=0><TBODY><TR><TD style="PADDING-RIGHT: 0px; PADDING-LEFT: 0px; PADDING-BOTTOM: 0px; PADDING-TOP: 0px; BORDER-BOTTOM: medium none; HEIGHT: 0px" colSpan=2><asp:Panel id="pnlPricing" runat="server" Width="100%" Visible="true">
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tbody>
                                    <tr>
                                        <td align="right" style="width: 160px; height: 27px">
                                            Transaction Mode:<span class="mandatory">*</span>
                                        </td>
                                        <td align="left" style="height: 27px">
                                            <asp:DropDownList ID="ddlAlternatePrice" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlAlternatePrice_SelectedIndexChaged"
                                                Width="118px">
                                                <asp:ListItem Text="Select" Value="-1"></asp:ListItem>
                                                <asp:ListItem Text="Best Offer" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="Please Contact" Value="2"></asp:ListItem>
                                                <asp:ListItem Text="Exchange" Value="3"></asp:ListItem>
                                                <asp:ListItem Text="Free" Value="4"></asp:ListItem>
                                                <asp:ListItem Text="Fixed" Value="5"></asp:ListItem>
                                                <asp:ListItem Text="Negotiable" Value="6"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfvAlternatePrice" runat="server" ControlToValidate="ddlAlternatePrice"
                                                ErrorMessage="Please select a transaction mode." Font-Bold="true" Text="?" InitialValue="-1">
                                            </asp:RequiredFieldValidator>
                                            <asp:CustomValidator ID="csvPricingOptions" runat="server" Font-Bold="True" ControlToValidate="ddlAlternatePrice"
                                                OnServerValidate="csvPricingOptions_ServerValidate">?</asp:CustomValidator>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tr>
                                    <td colspan="2">
                                        <asp:Panel ID="pnlPrice" runat="server" Visible="false" Enabled="false" Width="100%">
                                            <table class="" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                <tr>
                                                    <td align="right" style="width: 156px; height: 27px">
                                                        Price/Amount:<span class="mandatory">*</span>
                                                    </td>
                                                    <td align="left" style="height: 27px">
                                                        <asp:TextBox ID="txtPrice" runat="server" onkeydown="return IsDigit(event);" CssClass="textbox">
                                                        </asp:TextBox>
                                                        <asp:CustomValidator ID="csvPrice" runat="server" ControlToValidate="txtPrice" Display="Dynamic"
                                                            ErrorMessage="Price field is blank." Font-Bold="True" OnServerValidate="csvPrice_ServerValidate"
                                                            ValidateEmptyText="True">?</asp:CustomValidator>
                                                        <asp:RequiredFieldValidator ID="rfvPrice" runat="server" ControlToValidate="txtPrice"
                                                            Display="Dynamic" ErrorMessage="Price field is blank." Font-Bold="True">?</asp:RequiredFieldValidator>
                                                        <asp:DropDownList ID="ddlCurrency" runat="server" Width="65px" Enabled="False">
                                                            <asp:ListItem Text="BDT" Value="BDT"></asp:ListItem>
                                                            <asp:ListItem Text="USD" Value="USD"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel> </TD></TR><TR><TD style="HEIGHT: 27px" align=right>Product Service/Title:</TD><TD style="HEIGHT: 27px" align=left><asp:TextBox id="txtTitle" runat="server" Width="497px" CssClass="textbox">
                        </asp:TextBox> &nbsp;&nbsp; <asp:RequiredFieldValidator id="rfvTitle" runat="server" Font-Bold="True" ControlToValidate="txtTitle" ErrorMessage="Product/Service title is blank ! Please type your Product/Service Title properly.">?</asp:RequiredFieldValidator> </TD></TR><TR><TD style="HEIGHT: 20px" align=right>Description:<SPAN class="mandatory">*</SPAN></TD><TD style="HEIGHT: 20px" align=left><asp:TextBox id="txtDescription" runat="server" Width="497px" CssClass="textbox" Height="142px" MaxLength="3000" TextMode="MultiLine">
                        </asp:TextBox><BR />&nbsp;&nbsp; <asp:RequiredFieldValidator id="rfvDescription" runat="server" Font-Bold="True" ControlToValidate="txtDescription" ErrorMessage="Product Description is blank !  Please type your product description properly." SetFocusOnError="True">?</asp:RequiredFieldValidator> <SPAN style="COLOR: coral" class="gray11px">Type your description but not more than 3000 characters</SPAN><BR /></TD></TR><TR><TD style="HEIGHT: 27px" align=right>Ad Expiry date: </TD><TD style="VERTICAL-ALIGN: top; HEIGHT: 27px" align=left><cc1:CalendarExtender id="ceToDate" runat="server" CssClass="cal_Theme1" Format="dd-MMM-yyyy" PopupButtonID="ibtnToDate" PopupPosition="topLeft" TargetControlID="txtToDate"></cc1:CalendarExtender><BR /><SPAN style="FONT-SIZE: 7pt">DAY - MON - YEAR</SPAN><BR /><BR /><asp:TextBox id="txtToDate" runat="server" Width="145px" CssClass="textbox" Height="20px"></asp:TextBox><asp:ImageButton id="ibtnToDate" runat="server" CausesValidation="False" ImageUrl="~/Images/calendar.gif">
                                </asp:ImageButton>&nbsp;[Click on this to set Ad expiry date]<BR /><P class="formatParagraph"><SPAN style="COLOR: green" class="gray11px">The deadline indicates how long your posted Ad will remain for visitors.</SPAN></P></TD></TR></TBODY></TABLE><asp:Panel id="pnlAdSource" runat="server" Width="100%" Visible="false"><TABLE class="cptable" cellSpacing=0 cellPadding=0 width="100%" border=0><TBODY><TR><TD style="WIDTH: 166px; HEIGHT: 25px" vAlign=top align=right>Source:<SPAN class="mandatory">*</SPAN></TD><TD style="HEIGHT: 25px" align=left><asp:RadioButton id="rblNewspaper" runat="server" Text="Newspaper" TextAlign="Left" GroupName="source"></asp:RadioButton> <asp:TextBox id="txtNewspaper" runat="server" CssClass="textbox" MaxLength="50"></asp:TextBox>&nbsp;&nbsp; OR&nbsp; <asp:RadioButton id="rblBoromela" runat="server" Text="ApnerDeal.com" GroupName="source" Checked="True"></asp:RadioButton> <asp:CustomValidator id="csvSourceValidator" runat="server" Font-Bold="True" ErrorMessage="Please select a source." OnServerValidate="csvSourceValidator_ServerValidate">?</asp:CustomValidator><BR /></TD></TR><TR><TD style="WIDTH: 166px; HEIGHT: 25px" vAlign=top>&nbsp;</TD><TD style="HEIGHT: 25px" align=left><asp:CheckBox id="chkALternativeAddress" runat="server" AutoPostBack="True" Text="Check this if you want to provide separate address. Leave uncheck otherwise." OnCheckedChanged="chkALternativeAddress_CheckedChanged"></asp:CheckBox> </TD></TR></TBODY></TABLE></asp:Panel> <asp:Panel id="pnlAlternativeAddress" runat="server" Width="100%" Visible="false">
            <table class="cptable" cellspacing="0" cellpadding="0" width="100%" border="0">
                <tr>
                    <td align="right" style="height: 25px; width: 166px">
                        Division:<span class="mandatory">*</span></td>
                    <td align="left" style="height: 25px;">
                        <asp:DropDownList ID="ddlState" runat="Server" AppendDataBoundItems="True" AutoPostBack="True"
                            OnSelectedIndexChanged="ddlState_SelectedIndexChanged" Width="300px">
                            <asp:ListItem Text="Select" Value="-1"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvState" runat="server" ErrorMessage="Division is not selected ! Please select the Division properly."
                            Font-Bold="True" ControlToValidate="ddlState" InitialValue="-1">?</asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td align="right" style="height: 25px; width: 166px">
                        District:<span class="mandatory">*</span></td>
                    <td align="left" style="height: 25px;">
                        <asp:DropDownList ID="ddlProvince" runat="Server" Width="300px" AppendDataBoundItems="True">
                            <asp:ListItem Text="Select" Value="-1"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvProvince" runat="server" ErrorMessage="District is not selected ! Please select the District properly."
                            Font-Bold="True" ControlToValidate="ddlProvince" InitialValue="-1">?</asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td align="right" style="height: 25px; width: 166px">
                        Seller Name:<span class="mandatory">*</span></td>
                    <td align="left" style="height: 25px;">
                        <asp:TextBox ID="txtSellerName" runat="server" CssClass="textbox" MaxLength="200"
                            Width="280px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvSellerName" runat="server" ControlToValidate="txtSellerName"
                            ErrorMessage="Seller name field is blank." Font-Bold="True">?</asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td align="right" style="height: 25px; width: 166px">
                        Address:<span class="mandatory">*</span></td>
                    <td align="left" style="height: 25px;">
                        <asp:TextBox ID="txtAddress" runat="server" CssClass="textbox" MaxLength="500" Width="280px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvSellerAddress" runat="server" ControlToValidate="txtAddress"
                            ErrorMessage="Address field is blank." Font-Bold="True">?</asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td align="right" style="height: 25px; width: 166px">
                        Mobile:<span class="mandatory">*</span></td>
                    <td align="left" style="height: 25px;">
                        <asp:TextBox ID="txtMobile" runat="server" CssClass="textbox" MaxLength="20" Width="280px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvMobile" runat="server" ControlToValidate="txtMobile"
                            ErrorMessage="Please enter mobile no." Font-Bold="True">?</asp:RequiredFieldValidator></td>
                </tr>
            </table>
        </asp:Panel> <BR /><SPAN style="PADDING-LEFT: 75px; FONT-SIZE: 11px">By posting your Ad, you are agreeing to our <A style="TEXT-DECORATION: underline" href="#">Terms of Use</A> and <A style="TEXT-DECORATION: underline" href="#">Privacy Policy</A>.</SPAN> <BR /><BR /><DIV style="TEXT-ALIGN: center"><asp:Button id="btnSubmit" onclick="btnSubmit_Click" runat="server" CssClass="image_btn" Text="Submit"></asp:Button> </DIV><BR /></DIV>
</contenttemplate>
    </asp:UpdatePanel>
     
</asp:Content>
