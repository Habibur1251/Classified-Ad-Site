<%@ Page Language="C#" MasterPageFile="~/Classifieds/MPClassifieds2.master" AutoEventWireup="true" CodeFile="ProductProfileAE.aspx.cs" Inherits="Classifieds_ProductProfileAE" Title="www.apnerdeal.com – Classified Add/Edit Product Information." %>

<%@ Register Src="../UserControl/ImageResizeLink_Ctrl.ascx" TagName="ImageResizeLink_Ctrl"
    TagPrefix="uc4" %>

<%@ Register Src="../UserControl/SuccessMessageView.ascx" TagName="SuccessMessageView" TagPrefix="uc3" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="Ajax" %>
<%@ Register Src="../UserControl/TermsAndUseCondition_Ctrl.ascx" TagName="TermsAndUseCondition_Ctrl" TagPrefix="uc2" %>
<%@ Register Src="../UserControl/ProductInfo_Ctrl.ascx" TagName="ProductInfo_Ctrl" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript">
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

    <!-- Script courtesy of 
    function load() {
    var load = window.open('../CashDeposit.aspx','','scrollbars=no,menubar=no,height=650,width=600,resizable=no,toolbar=no,location=no,status=no,top=100,left=300');
    }
    // -->
    
    <!--
    function AtLeastOneCheckbox_ClientValidate(source, args)
    {
        // Requires that In Progress, Complete, and/or Cancelled is checked

        args.IsValid = 
            document.getElementById("<%=chkCod.ClientID %>").checked
          || document.getElementById("<%=chkPfs.ClientID %>").checked
          || document.getElementById("<%=chkCash.ClientID %>").checked;
    }
    //-->

    </script>

    <span class="pageTitle">Classified - Add/Edit Product Information.</span>
    <br />
    <br />
    <table width="100%" border="0px" cellspacing="0px" cellpadding="0px">
        <tr>
            <td>
                &nbsp;</td>
            <td align="right">
                Fields marked by <span class="mandatory">*</span> are mandatory</td>
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
            Font-Size="11px">
       </asp:Label> 
    </td>
    </tr>
    </table>
    
    <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
    <!------------------------------------------ Design For Default Input Starts From Here-------------------------------------------> 
    
    <asp:View ID="defaultView" runat="server">
    <asp:Panel ID="pnlProductYear" runat="server" Visible="false" Enabled="false" Width="955px">
    <table border="0" cellpadding="0" class="cptable" cellspacing="0" style="border-bottom: #efefe2 1px solid" width="100%">
        <tr>
            <td align="right" style="width: 200px; height: 25px">
                Product Year:<span class="mandatory">*</span>
            </td>
            <td align="left" style="height: 25px">
            <asp:TextBox 
                ID="txtProductYear" 
                CssClass="textbox" 
                MaxLength="4"
                onkeydown="return IsDigit(event);" 
                runat="Server">
            </asp:TextBox>
            </td>
        </tr>
    
    </table>
    
    </asp:Panel>
    <table border="0" cellpadding="0" cellspacing="0" class="cptable" style="border-bottom: #efefe2 1px solid" width="100%">
        
        <tr>
        <td align="right" style="width: 200px; height: 25px">
            Quantity:<span class="mandatory">*</span>
        </td>
        <td align="left" style="height: 25px">
            <asp:TextBox 
                ID="txtQuantity" 
                runat="server"
                CssClass="textbox" 
                MaxLength="10" 
                onkeydown="return IsDigit(event);"
                Width="300px">
                </asp:TextBox>
                <asp:RequiredFieldValidator 
                    ID="rfvQuantity" 
                    runat="server"
                    ControlToValidate="txtQuantity" 
                    ErrorMessage="Quantity field is blank" 
                    Font-Bold="True" Display="Dynamic">?</asp:RequiredFieldValidator>
            <asp:CustomValidator ID="csvQuantity" runat="server" ControlToValidate="txtQuantity"
                ErrorMessage="Quantity field is blank." Font-Bold="True" OnServerValidate="csvQuantity_ServerValidate" Display="Dynamic">?</asp:CustomValidator></td>
        </tr>
        <tr>
        <td align="right" style="width: 200px; height: 25px">
            Price:<span class="mandatory">*</span>
        </td>
        <td align="left" style="height: 25px">
            <asp:TextBox 
                ID="txtProductPrice" 
                runat="server" 
                CssClass="textbox" 
                MaxLength="10"
                onkeydown="return IsDigit(event);" 
                Width="300px">
            </asp:TextBox><asp:RequiredFieldValidator 
                ID="rfvProductPrice" 
                runat="server" 
                ControlToValidate="txtProductPrice"
                ErrorMessage="Product Price field is blank !" 
                Font-Bold="True" 
                SetFocusOnError="True" Display="Dynamic">?</asp:RequiredFieldValidator><asp:CustomValidator ID="csvProductPrice" runat="server" ControlToValidate="txtProductPrice"
                ErrorMessage="Price field is blank" Font-Bold="True" OnServerValidate="csvProductPrice_ServerValidate" Display="Dynamic">?</asp:CustomValidator>
            <asp:CheckBox ID="chkNegotiable" runat="server" AutoPostBack="True" OnCheckedChanged="chkNegotiable_CheckedChanged"
                Text="Negotiable" Visible="False" /></td>
        </tr>
        <tr>
        <td align="right" style="width: 200px; height: 25px">
            Currency:</td>
        <td align="left" style="height: 25px">
            <asp:DropDownList 
                ID="ddlCurrency" 
                runat="server" 
                Width="305px">
                <asp:ListItem Text="BDT" Value="BDT"></asp:ListItem>
                <asp:ListItem Text="USD" Value="USD"></asp:ListItem>
            </asp:DropDownList></td>
        </tr>
        
        
        
        <tr>
        <td align="right" style="width: 200px; height: 25px">
            Description:
        </td>
        <td align="left" style="font-size: 9px">
            <asp:TextBox ID="txtDescription" runat="server" CssClass="textbox" Height="50px"
                MaxLength="3000" TextMode="MultiLine" Width="300px"></asp:TextBox><br />
                 Type your description <span class="price"  > (Please don't type more than 3000 characters)</span></td>
        </tr>
        <tr>
        <td align="right" style="width: 200px; height: 33px">
            Condition:
        </td>
        <td align="left" style="height: 33px">
            <asp:DropDownList 
                ID="ddlCondition" 
                runat="server" 
                AppendDataBoundItems="true"
                Width="305px">
                <asp:ListItem Text="New" Value="New"></asp:ListItem>
                <asp:ListItem Text="Used" Value="Used"></asp:ListItem>
                <asp:ListItem Text="Refurbished" Value="Refurbished"></asp:ListItem>
            </asp:DropDownList>
            <asp:TextBox ID="txtCondition" runat="server" BorderStyle="Groove" Visible="False"></asp:TextBox>
        </td>
        </tr>
        <tr>
        <td align="right" style="width: 200px; height: 33px">
            Condition Note:
        </td>
        <td align="left" style="height: 33px">
            <asp:TextBox ID="txtConditionNote" runat="server" CssClass="textbox" Height="50px"
                MaxLength="300" TextMode="MultiLine" Width="300px"></asp:TextBox>
        </td>
        </tr>
        </table>
        
        <asp:Panel ID="pnlImageUpload" runat="server" Width="815px">
        <table class="cptable" cellpadding="0" cellspacing="0" style="width: 118%">
        <tr>
            <td align="right" style="width: 162px; height: 33px">
                <asp:Label ID="lblUpload" runat="server" Text="Upload image :" Width="106px"></asp:Label></td>
            <td align="left" style="height: 33px; width: 605px;">
                <asp:FileUpload 
                    ID="FileUpload1" 
                    runat="server" 
                    BorderStyle="Groove" />
                <asp:Button
                    ID="btnUpload" 
                    runat="server" 
                    BorderStyle="Groove" 
                    CausesValidation="False" 
                    OnClick="btnUpload_Click"
                    Text="Upload" />
                <asp:Label 
                    ID="lblImageUploadMessage" 
                    runat="server" 
                    Font-Size="12px"
                    Font-Bold="true"
                    ForeColor="Red" 
                    Width="250px"></asp:Label><br />
                    <span class="gray11px" style="color:Coral">
                        Image size must be less then 200 KB. Choose any format except .bmp.&nbsp;<br />
                        Preferred width height ratio 200 by 300 px.
                        <br />
                        <uc4:ImageResizeLink_Ctrl ID="ImageResizeLink_Ctrl1" runat="server" />
                    </span>
            </td>
        </tr>      
        </table>
        </asp:Panel>
        
        <table width="100%" class="cptable" cellpadding="0" cellspacing="0">
        <tr>
        <td align="center" style="height: 25px">
        
        <asp:CheckBox ID="chkPfs" runat="server" Text="Pick From Store" Visible="false"></asp:CheckBox>
        <asp:CheckBox ID="chkCod" runat="server" Text="Cash On Delivery" OnCheckedChanged="chkCod_CheckedChanged" AutoPostBack="True" Visible="false"></asp:CheckBox>
        <asp:CheckBox ID="chkCash" runat="server" Text="Cash Deposit" Visible="false"></asp:CheckBox>
        </td>
        </tr>
        </table>
        
        
        
    <asp:UpdatePanel id="Updatepanel1" runat="server" >
        <contenttemplate>
<asp:Panel id="panelDeliveryOption" runat="server" Width="951px" Enabled="false" Visible="false"><TABLE class="cptable" cellSpacing=0 cellPadding=0 width="100%" border=0><TBODY><TR><TD style="WIDTH: 194px" align=right>Delivery Area:<SPAN class="mandatory">*</SPAN> </TD><TD align=left><asp:DropDownList id="ddlDeliveryArea" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlDeliveryArea_SelectedIndexChanged">
                                <asp:ListItem Text="Inside of Dhaka" Value="Inside of Dhaka"></asp:ListItem>
                                <asp:ListItem Text="Outside of Dhaka" Value="Outside of Dhaka"></asp:ListItem>
                                <asp:ListItem Text="Outside of Bangladesh" Value="Outside of Bangladesh"></asp:ListItem>
                            </asp:DropDownList> </TD></TR></TBODY></TABLE><asp:Panel id="pnlForeignAddress" runat="server" Width="869px" Enabled="false" Visible="false"><TABLE style="WIDTH: 107%" class="cptable" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="WIDTH: 184px" align=right>Your foreign address:<SPAN class="mandatory">*</SPAN> </TD><TD align=left><asp:TextBox id="txtSellerForeignAddress" runat="server" Width="150px" MaxLength="100" CssClass="textbox">
                                </asp:TextBox> <asp:RequiredFieldValidator id="rfvSellerForeignAddress" runat="server" Font-Bold="True" Display="Dynamic" ErrorMessage="Foreign address field is blank." ControlToValidate="txtSellerForeignAddress">?</asp:RequiredFieldValidator> <asp:CustomValidator id="csvSellerForeignAddress" runat="server" Font-Bold="True" Display="Dynamic" ErrorMessage="Foreign address field is blank." ControlToValidate="txtSellerForeignAddress" OnServerValidate="csvSellerForeignAddress_ServerValidate">?</asp:CustomValidator></TD></TR></TBODY></TABLE></asp:Panel> </asp:Panel> 
</contenttemplate>
        <triggers>
<asp:AsyncPostBackTrigger ControlID="chkCod" EventName="CheckedChanged"></asp:AsyncPostBackTrigger>
</triggers>
        </asp:UpdatePanel>
        
        <asp:Panel ID="pnlSource" runat="server" Width="100%">
        <table class="cptable" cellspacing="0" cellpadding="0" width="100%" border="0">
            <tbody>
                <tr>
                    <td align="right" style="width: 200px; height: 25px" valign="top">
                        Source:<span class="mandatory">*</span></td>
                    <td align="left" style="height: 25px">
                        <asp:RadioButton ID="rblNewspaper" runat="server" Text="Newspaper" TextAlign="Left"
                            GroupName="source"></asp:RadioButton>
                        <asp:TextBox ID="txtNewspaper" runat="server" CssClass="textbox" MaxLength="50"></asp:TextBox>&nbsp;&nbsp;
                        OR&nbsp;
                        <asp:RadioButton ID="rblBoromela" runat="server" Text="ApnerDeal.com" GroupName="source"
                            Checked="True"></asp:RadioButton>
                        <asp:CustomValidator ID="csvSourceValidator" runat="server" Font-Bold="True" ErrorMessage="Please select a source."
                            OnServerValidate="csvSourceValidator_ServerValidate">?</asp:CustomValidator><br />
                    </td>
                </tr>
                <tr>
                    <td style="width: 200px; height: 25px" valign="top">
                        &nbsp;</td>
                    <td align="left" style="height: 25px">
                        &nbsp;<asp:CheckBox ID="chkIsDisplayAddress" runat="server"  Checked="false" Text="Dont Show my address.">
                </asp:CheckBox></td>
                </tr>
            </tbody>
        </table>
            
        </asp:Panel>
        
        <table width="100%" class="cptable" cellpadding="0" cellspacing="0">
        <tr>
        <td style="width: 200px; height: 25px">&nbsp;
        </td>
        <td align="left" style="height: 25px">
            <asp:Button 
                ID="btnNextPage" 
                runat="server" 
                BorderStyle="Groove" 
                CssClass="image_btn"
                Text="Next" 
                OnClick="btnNextPage_Click"/>
            
        </td>
        </tr>
        </table>
        
    </asp:View>
    <!------------------------------------------ Design For Default Input Ends Here-------------------------------------------> 
    
    
    
    <!------------------------------------------ Design For Book Starts Here------------------------------------------------->
    
    <asp:View ID="bookView" runat="server">
    
    <table cellspacing="0px" cellpadding="0px" border="0px" style="border-bottom: 1px solid rgb(213, 213, 213); width: 954px;">
    <tbody>
    <tr>
    <td width="3px" style="height: 30px">
    <img height="28" width="3" alt="" src="../Images/title_bar_left.gif"/>
    </td>
    <td width="400px" style="background-image: url(../Images/title_bar_bg.gif); background-repeat: repeat-x; padding-left: 5px; height: 30px;">
    <strong>Product General Information</strong></td>
    <td style="width: 3px; height: 30px;">
    <img height="28" width="3" alt="" src="../Images/title_bar_right.gif"/>
    </td>
    <td style="width: 172px">
    </td>
        <td style="width: 200px">
        
        </td>
    </tr>
    </tbody>
</table>

<table width="100%" border="0px" cellspacing="0px" cellpadding="0px" class="cptable" style=" background-color:#F8F8F8; border-top:1px solid #EFEFE2;" id="TABLE2">
   
  
   
    <tr>
    <td align="right" style="width: 210px; height: 25px">SKU:</td>
    <td align="left" style="height: 25px">
    <asp:Label ID="lblSku" runat="server"></asp:Label>
        &nbsp;&nbsp;
    </td>
    </tr>
   
    
    <tr>
    <td align="right" style="width: 210px; height: 25px">Category:</td>
    <td align="left" style="height: 25px">
    <asp:Label ID="lblCategory" runat="server" />&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;</td>
    </tr>
    
    
    <tr>
    <td align="right" style="width: 210px; height: 25px">Subcategory:</td>
    <td align="left" style="height: 25px">
    <asp:Label ID="lblSubcategory" runat="server" />&nbsp;
        </td>
    </tr>
    
    
    <tr>
    <td align="right" style="width: 210px; height: 25px">Second Subcategory:</td>
    <td align="left" style="height: 25px">
    <asp:Label ID="lblSecondSubcategory" runat="server" />&nbsp;&nbsp;
        </td>
    </tr>
    
        
    <tr>
    <td align="right" style="width: 210px; height: 9px">Product Title:</td>
    <td align="left" style="height: 25px">
    <asp:Label ID="lblProductTitle" runat="server" />&nbsp;
    </td>
    </tr>
    <tr>
    </tr>
    
    
</table> 
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="cptable" style=" border-top:1px solid #EFEFE2; margin-top:25px"> 
        <tr>
        <td align="right" style="width: 210px; height:25px">
            Paper Back:<span class="mandatory">*</span></td>
        <td align="left" style="height: 25px">
            <asp:TextBox ID="txtPaperBack" runat="server" CssClass="textbox" MaxLength="100" Width="150px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPaperBack"
                ErrorMessage="Paper back for book is empty" Font-Bold="True">?</asp:RequiredFieldValidator>
            <asp:CustomValidator ID="csvPaperBack" runat="server" ControlToValidate="txtPaperBack"
                ErrorMessage="Paper back field is blank." Font-Bold="True" OnServerValidate="csvPaperBack_ServerValidate">?</asp:CustomValidator></td>
        
        </tr>
         <tr>
             <td align="right" style="width: 210px; height: 25px">
                 Language:<span class="mandatory">*</span></td>
             <td align="left" style="height: 25px">
                 <asp:TextBox ID="txtLanguage" runat="server" CssClass="textbox" MaxLength="50" Width="150px"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="rfvLanguage" runat="server" ControlToValidate="txtLanguage"
                     ErrorMessage="Language field is blank." Font-Bold="True">?</asp:RequiredFieldValidator>
                 <asp:CustomValidator ID="csvLanguage" runat="server" ErrorMessage="Language field is blank."
                     Font-Bold="True" OnServerValidate="csvLanguage_ServerValidate">?</asp:CustomValidator></td>
         </tr>
         
         
       
        
        <tr>
        <td align="right"  style="width: 210px; height: 25px">
            Dimension of Book:</td>
        <td align="left" style="height: 25px">
            <asp:TextBox ID="txtDimensionForBook" runat="server" CssClass="textbox" MaxLength="100" Width="150px"></asp:TextBox></td>
        
        </tr>
        
        
        <tr>
        <td align="right" style="width: 210px; height: 25px">
            Shipping Weight:</td>
        <td align="left" style="height: 25px">
            <asp:TextBox ID="txtShippingWeight" runat="server" CssClass="textbox" MaxLength="100" Width="150px"></asp:TextBox></td>
        
        </tr>
        
        <tr>
        <td align="right" style="width: 210px; height: 25px">
            Edition:<span class="mandatory">*</span></td>
        <td align="left" style="height: 25px">
            <asp:TextBox ID="txtEdition" runat="server" CssClass="textbox" MaxLength="50" Width="150px">
        </asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtEdition"
                ErrorMessage="Edition is empty" Font-Bold="True">?</asp:RequiredFieldValidator>
            <asp:CustomValidator ID="csvEdition" runat="server" ControlToValidate="txtEdition"
                ErrorMessage="Edition field is blank." Font-Bold="True" OnServerValidate="csvEdition_ServerValidate">?</asp:CustomValidator>
            <asp:Label ID="lblEdition" runat="server" ForeColor="Green" Text="You cannot edit Edition" Visible="False"></asp:Label></td>
        </tr>
        
        <tr>
        <td align="right" style="width: 210px; height: 25px">
            ISBN:<span class="mandatory">*</span></td>
        <td align="left" style="height: 25px">
            <asp:TextBox 
                ID="txtISBN" 
                runat="server" 
                CssClass="textbox" 
                MaxLength="30" 
                Width="150px">
        </asp:TextBox>
            <asp:RequiredFieldValidator 
                ID="RequiredFieldValidator6" 
                runat="server" 
                ControlToValidate="txtISBN"
                ErrorMessage="ISBN is empty" Font-Bold="True">?</asp:RequiredFieldValidator>
            <asp:CustomValidator ID="csvIsbn" runat="server" ControlToValidate="txtISBN" ErrorMessage="ISBN field is blank."
                Font-Bold="True" OnServerValidate="csvIsbn_ServerValidate">?</asp:CustomValidator>
            <asp:Label ID="lblIsbn" runat="server" ForeColor="Green" Text="You cannot edit ISBN" Visible="False"></asp:Label></td>
        
        </tr>
        
        
        <tr>
        <td align="right" style="width: 210px; height: 25px">
            Author:<span class="mandatory">*</span></td>
        <td align="left" style="height: 25px">
            <asp:TextBox 
                ID="txtAuthor" 
                runat="server" 
                CssClass="textbox" 
                MaxLength="300" 
                Width="150px"></asp:TextBox>
            <asp:RequiredFieldValidator 
                ID="RequiredFieldValidator7" 
                runat="server" 
                ControlToValidate="txtAuthor"
                ErrorMessage="Author is empty" Font-Bold="True">?</asp:RequiredFieldValidator>
            <asp:CustomValidator ID="csvAuthor" runat="server" ControlToValidate="txtAuthor"
                ErrorMessage="Author field is blank." Font-Bold="True" OnServerValidate="csvAuthor_ServerValidate">?</asp:CustomValidator>
            <asp:Label ID="lblAuthor" runat="server" ForeColor="Green" Text="You cannot edit Author" Visible="False"></asp:Label></td>
        
        </tr>
        
        
        <tr>
        <td align="right" style="width: 210px; height: 25px">
            Publisher:<span class="mandatory">*</span></td>
        <td align="left" style="height: 25px">
            <asp:TextBox ID="txtPublisher" runat="server" CssClass="textbox" MaxLength="300"
                Width="150px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtPublisher"
                ErrorMessage="Publisher is empty" Font-Bold="True">?</asp:RequiredFieldValidator>
            <asp:CustomValidator ID="csvPublisher" runat="server" ControlToValidate="txtPublisher"
                ErrorMessage="Publisher field is blank." Font-Bold="True" OnServerValidate="csvPublisher_ServerValidate">?</asp:CustomValidator>
            <asp:Label ID="lblPublisher" runat="server" ForeColor="Green" Text="You cannot edit Publisher" Visible="False"></asp:Label></td>
        
        </tr>
    
        <tr>
        <td align="right" style="width: 200px; height: 25px">
        
        <asp:Button 
            ID="btnBackFromBook" 
            runat="server" 
            CssClass="image_btn_left"
            CausesValidation="false" 
            BorderStyle="Groove" 
            Text="Back" 
            OnClick="btnBackFromBook_Click" />
            
        </td>
        <td align="left" style="height: 25px">
    <asp:CheckBox 
        ID="chkBookIsActive" 
        runat="server" 
        Checked="True" 
        Text="Check this if you want to activate this product. Leave uncheck otherwise." />
       
        
        </td>
        </tr>
            <tr>
                
                <td align="left" colspan="2" style="height: 25px; padding-left:200px;">
                <span style="font-size:11px; "><uc2:TermsAndUseCondition_Ctrl ID="TermsAndUseCondition_Ctrl1" runat="server" /></span>
               
                </td>
            </tr>
            <tr>
            <td align="right" style="width:210px">
            <asp:LinkButton ID="lbtnBookPreview" runat="server" Font-Bold="true">
                Preview of this Product. <img src="../Images/preview-32x32.png" alt="" border="none" width="16px" height="16px" />
            </asp:LinkButton>
            </td>
            <td align="left">
            <asp:Button 
                ID="btnBookSubmit" 
                runat="server" 
                Text="Submit" 
                CssClass="image_btn" OnClick="btnBookSubmit_Click"  />
            </td>
            </tr>
        
    </table>
    </asp:View>
    
    
   <!------------------------------------------ Design For Book Ends Here------------------------------------------------->
    
    <asp:View ID="carView" runat="server">
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="cptable" style=" border-top:1px solid #EFEFE2; margin-top:25px" >
        <tr>
            <td colspan="2" style="height: 25px">
                <uc1:ProductInfo_Ctrl ID="prodInfoAutomobile_Ctrl" runat="server" />
            </td>
        </tr>
          
          <tr>
             <td align="right" style="width: 172px; height:25px">
                 &nbsp;Sub Model:<span class="mandatory">*</span></td>
             <td align="left" style="height: 25px">
                   <asp:TextBox ID="txtCarSubModel" runat="server" CssClass="textbox" MaxLength="100" Width="150px">
                   </asp:TextBox>
                 <asp:RequiredFieldValidator ID="rfvCarSubModel" runat="server" ControlToValidate="txtCarSubModel"
                     Display="Dynamic" ErrorMessage="Sub model field is blank." Font-Bold="True">?</asp:RequiredFieldValidator>
                 <asp:CustomValidator ID="csvCarSubModel" runat="server" ControlToValidate="txtCarSubModel"
                     ErrorMessage="Sub model field is blank." Font-Bold="True" OnServerValidate="csvCarSubModel_ServerValidate">?</asp:CustomValidator>
                   <asp:Label 
                        ID="lblCarSubModelInfoMessage" 
                        runat="server" 
                        ForeColor="Green" 
                        Text="You can not edit Sub Model."
                        Visible="False"></asp:Label>
             </td>      
          </tr>
          <tr>
             <td align="right" style="width: 172px; height: 25px">
                 &nbsp;
                   VIN(Vehicle Identification No.):</td>
             <td align="left" style="height: 25px">
                   <asp:TextBox ID="txtVIN" runat="server" CssClass="textbox" MaxLength="100" Width="150px"></asp:TextBox>
             </td>
          </tr>


          <tr>
             <td align="right" style="width: 172px; height: 25px">
                 &nbsp;
                 Mileage:</td>
             <td align="left" style="height: 25px">
                   <asp:TextBox ID="txtMileage" runat="server" CssClass="textbox" MaxLength="100" Width="150px"></asp:TextBox>
             </td>      
          </tr>
          <tr>
             <td align="right" style="width: 172px; height: 25px">
                 &nbsp;Registration Year:</td>
             <td align="left" style="height: 25px">
                   <asp:TextBox ID="txtVehicleRegYear" runat="server" CssClass="textbox" MaxLength="50" Width="150px"></asp:TextBox>
             </td>      
          </tr>
        <tr>
            <td align="right" style="width: 172px; height: 25px">
                &nbsp;<asp:Button 
            ID="btnBackFromAutomobile" 
            runat="server" 
            CssClass="image_btn_left"
            CausesValidation="false" 
            BorderStyle="Groove" 
            Text="Back" 
            OnClick="btnBackFromBook_Click" />
            </td>
            <td align="left" style="height: 25px">
                <asp:CheckBox 
            ID="chkAuto" 
            runat="server" 
            Checked="True" 
            Text="Check this if you want to activate this product. Leave uncheck otherwise." /></td>
        </tr>
        <tr>
            <td align="left" colspan="2" style="height: 25px; padding-left:200px">
                <uc2:TermsAndUseCondition_Ctrl ID="TermsAndUseCondition_Ctrl4" runat="server" />
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 172px; height: 25px">
                <asp:LinkButton ID="lbtnCarPreview" runat="server" Font-Bold="true" Font-Underline="true">
            Preview of this Product. 
            <img src="../Images/preview-32x32.png" alt="" border="none" width="16px" height="16px" />
            </asp:LinkButton></td>
            <td align="left" style="height: 25px"><asp:Button 
                ID="btnAutoSubmit" 
                runat="server" 
                Text="Submit" 
                CssClass="image_btn" OnClick="btnAutoSubmit_Click"  /></td>
        </tr>
          
          </table>
    </asp:View>
    
    
    
    
    <asp:View ID="computerView" runat="server">
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="cptable" style=" border-top:1px solid #EFEFE2; margin-top:25px" >
    <tr>
    <td>
        <uc1:ProductInfo_Ctrl ID="prodInfoComputer_Ctrl" runat="server" />
    </td>
    </tr>
    </table>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="cptable" style=" border-top:1px solid #EFEFE2; margin-top:25px" id="TABLE1">
          <tr>
             <td align="right" style="width: 210px; height: 25px">
                   Dedicated Video Memory:</td>
             <td align="left" style="height: 25px">
                   <asp:TextBox ID="txtDedicatedVideoMemory" runat="server" CssClass="textbox" MaxLength="100" Width="150px"></asp:TextBox>
             </td>      
          </tr>
          <tr>
             <td align="right" style="width: 210px; height: 25px">
                   Shared Video Memory:</td>
             <td align="left" style="height: 25px">
                   <asp:TextBox ID="txtSharedVideoMemory" runat="server" CssClass="textbox" MaxLength="100" Width="150px"></asp:TextBox>
             </td>      
          </tr>
          <tr>
             <td align="right" style="width: 210px; height: 25px">
                   Tv Tuner:</td>
             <td align="left" style="height: 25px">
                   <asp:TextBox ID="txtTvTuner" runat="server" CssClass="textbox" MaxLength="100" Width="150px"></asp:TextBox>
             </td>      
          </tr>
           <tr>
             <td align="right" style="width: 210px; height: 25px">
                   Video Memory:</td>
             <td align="left" style="height: 25px">
                   <asp:TextBox ID="txtVideoMemory" runat="server" CssClass="textbox" MaxLength="100" Width="150px"></asp:TextBox>
             </td>
           </tr>
          <tr>
             <td align="right" style="width: 210px; height: 25px">
                   HDCP Compliant:</td>
             <td align="left" style="height: 25px">
                   <asp:TextBox ID="txtHDCPCompliant" runat="server" CssClass="textbox" MaxLength="100" Width="150px"></asp:TextBox>
             </td>
                   
          </tr> 
          <tr>
             <td align="right" style="width: 210px; height: 25px">
                   Audio Output:</td>
             <td align="left" style="height: 25px">
                   <asp:TextBox ID="txtAudioOutput" runat="server" CssClass="textbox" MaxLength="100" Width="150px"></asp:TextBox>
              </td>
                   
          </tr> 
          <tr>
             <td align="right" style="width: 210px; height: 25px">
                   Digital Input:</td>
             <td align="left" style="height: 25px">
                   <asp:TextBox ID="txtDigitalInput" runat="server" CssClass="textbox" MaxLength="100" Width="150px"></asp:TextBox>
             </td>
                   
          </tr> 
          <tr>
             <td align="right" style="width: 210px; height: 25px">
                   Digital Output:</td>
             <td align="left" style="height: 25px">
                   <asp:TextBox ID="txtDigitalOutput" runat="server" CssClass="textbox" MaxLength="100" Width="150px"></asp:TextBox>
             </td>
                   
          </tr>
          <tr>
             <td align="right" style="width: 210px; height: 25px">
                   Integreted Microphone:</td>
             <td align="left" style="height: 25px">
                   <asp:TextBox ID="txtIntegretedMicrophone" runat="server" CssClass="textbox" MaxLength="100" Width="150px"></asp:TextBox>
             </td>
                   
          </tr>
          <tr>
             <td align="right" style="width: 210px; height: 25px">
                   Line Out:</td>
             <td align="left" style="height: 25px">
                   <asp:TextBox ID="txtLineOut" runat="server" CssClass="textbox" MaxLength="100" Width="150px"></asp:TextBox>
             </td>
                   
          </tr>
          <tr>
             <td align="right" style="width: 210px; height: 25px">
                   Line In Input:</td>
             <td align="left" style="height: 25px">
                   <asp:TextBox ID="txtLineInInput" runat="server" CssClass="textbox" MaxLength="100" Width="150px"></asp:TextBox>
             </td>      
               
          </tr>
          <tr>
             <td align="right" style="width: 210px; height: 25px">
                   Microphone Input:</td>
             <td align="left" style="height: 25px">
                   <asp:TextBox ID="txtMicrophoneInput" runat="server" CssClass="textbox" MaxLength="100" Width="150px"></asp:TextBox>
             </td>
                   
          </tr>
          <tr>
             <td align="right" style="width: 210px; height: 25px">
                   Sound Card:</td>
             <td align="left" style="height: 25px">
                   <asp:TextBox ID="txtSoundCard" runat="server" CssClass="textbox" MaxLength="100" Width="150px"></asp:TextBox>
              </td>     
          </tr>
          <tr>
             <td align="right" style="width: 210px; height: 25px">
                   Ethernet Port:</td>
             <td align="left" style="height: 25px">
                   <asp:TextBox ID="txtEthernetPort" runat="server" CssClass="textbox" MaxLength="100" Width="150px"></asp:TextBox>
              </td>     
          </tr>
           <tr>
             <td align="right" style="width: 210px; height: 25px">
                   Integreted Bluetooth:</td>
             <td align="left" style="height: 25px">
                   <asp:TextBox ID="txtIntegretedBluetooth" runat="server" CssClass="textbox" MaxLength="100" Width="150px"></asp:TextBox>
              </td>     
          </tr>
          <tr>
             <td align="right" style="width: 210px; height: 25px">
                   Integreted WiFi:</td>
             <td align="left" style="height: 25px">
                   <asp:TextBox ID="txtIntegretedWiFi" runat="server" CssClass="textbox" MaxLength="100" Width="150px"></asp:TextBox>
              </td>     
          </tr>
          <tr>
             <td align="right"style="width: 210px; height: 25px">
                   Card Reader:</td>
             <td align="left" style="height: 25px">
                   <asp:TextBox ID="txtCardReader" runat="server" CssClass="textbox" MaxLength="100" Width="150px"></asp:TextBox>
              </td>     
          </tr>
          <tr>
             <td align="right" style="width: 210px; height: 25px">
                   DVI Output:</td>
             <td align="left" style="height: 25px">
                   <asp:TextBox ID="txtDVIOutput" runat="server" CssClass="textbox" MaxLength="100" Width="150px"></asp:TextBox>
              </td>     
          </tr>
          <tr>
             <td align="right" style="width: 210px; height: 25px">
                   ESata:</td>
             <td align="left" style="height: 25px">
                   <asp:TextBox ID="txtESata" runat="server" CssClass="textbox" MaxLength="100" Width="150px"></asp:TextBox>
              </td>     
          </tr>
          <tr>
             <td align="right" style="width: 210px; height: 25px">
                   HDMI:</td>
             <td align="left" style="height: 25px">
                   <asp:TextBox ID="txtHDMI" runat="server" CssClass="textbox" MaxLength="100" Width="150px"></asp:TextBox>
              </td>     
          </tr>
          <tr>
             <td align="right" style="width: 210px; height: 25px">
                   USB2.0:</td>
             <td align="left"  style="height: 25px">
                   <asp:TextBox ID="txtUSB2" runat="server" CssClass="textbox" MaxLength="100" Width="150px"></asp:TextBox>
              </td>     
          </tr>
          <tr>
             <td align="right"  style="width: 210px; height: 25px">
                   VGA Output:</td>
             <td align="left"  style="height: 25px">
                   <asp:TextBox ID="txtVGAOutput" runat="server" CssClass="textbox" MaxLength="100" Width="150px"></asp:TextBox>
              </td>     
          </tr>
          <tr>
             <td align="right"  style="width: 210px; height: 25px">
                   Webcam:</td>
             <td align="left" style="height: 25px">
                   <asp:TextBox ID="txtWebcam" runat="server" CssClass="textbox" MaxLength="100" Width="150px"></asp:TextBox>
              </td>     
          </tr>
        <tr>
            <td align="right" style="width: 210px; height: 25px"><asp:Button 
            ID="btnBackFromComputer" 
            runat="server" 
            CssClass="image_btn_left"
            CausesValidation="false" 
            BorderStyle="Groove" 
            Text="Back" 
            OnClick="btnBackFromBook_Click" /></td>
            <td style="height: 25px"><asp:CheckBox 
            ID="chkComputer" 
            runat="server" 
            Checked="True" 
            Text="Check this if you want to activate this product. Leave uncheck otherwise." /></td>
        </tr>
        <tr>
            <td align="left" colspan="2" style="height: 25px; padding-left:200px">
                <uc2:TermsAndUseCondition_Ctrl id="TermsAndUseCondition_Ctrl3" runat="server">
                </uc2:TermsAndUseCondition_Ctrl></td>
        </tr>
        <tr>
            <td align="right" style="width: 210px; height: 25px">
                <asp:LinkButton ID="lbtnComputerPreview" runat="server" Font-Bold="true" Font-Underline="true">
            Preview of this Product. 
            <img src="../Images/preview-32x32.png" alt="" border="none" width="16px" height="16px" />
            </asp:LinkButton></td>
            <td align="left" style="height: 25px"><asp:Button 
                ID="btnComputerSubmit" 
                runat="server" 
                Text="Submit" 
                CssClass="image_btn" OnClick="btnComputerSubmit_Click"  /></td>
        </tr>
 
    </table>
    </asp:View>
    
    
    
    
    <asp:View id="mobileView" runat="server">
    
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="cptable" style=" border-top:1px solid #EFEFE2; margin-top:25px" >
    <tr>
    <td>
        <uc1:ProductInfo_Ctrl ID="prodInfoMobile_Ctrl" runat="server" />
    </td>
    </tr>
    </table>
    
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="cptable" style=" border-top:1px solid #EFEFE2; margin-top:25px" >
          
          
          <tr>
             <td align="right" style="width: 210px; height: 25px">
             <asp:Button 
            ID="Button2" 
            runat="server" 
            CssClass="image_btn_left"
            CausesValidation="false" 
            BorderStyle="Groove" 
            Text="Back" 
            OnClick="btnBackFromBook_Click" /></td>
             <td align="left" style="height: 25px">
                   Click Submit button to save your product.
             </td>     
          </tr>
        <tr>
            <td style="width: 100px; height: 25px">
            </td>
            <td align="left" style="height: 25px">
                <asp:CheckBox 
            ID="chkMobile" 
            runat="server" 
            Checked="True" 
            Text="Check this if you want to activate this product. Leave uncheck otherwise." /></td>
        </tr>
        <tr>
            <td align="left" colspan="2" style="height: 25px; padding-left:200px;">
                <uc2:TermsAndUseCondition_Ctrl id="TermsAndUseCondition_Ctrl2" runat="server">
                </uc2:TermsAndUseCondition_Ctrl></td>
        </tr>
        <tr>
            <td align="right" style="width: 210px; height: 25px">
                <asp:LinkButton ID="lbtnMobilePreview" runat="server" Font-Bold="true" Font-Underline="true">
            Preview of this Product. 
            <img src="../Images/preview-32x32.png" alt="" border="none" width="16px" height="16px" />
            </asp:LinkButton></td>
            <td align="left" style="height: 25px"><asp:Button 
                ID="btnMobileSubmit" 
                runat="server" 
                Text="Submit" 
                CssClass="image_btn" OnClick="btnMobileSubmit_Click"  /></td>
        </tr>
          
          </table>
    
    </asp:View>
    
     <!---------------------------------------------Electronics View Starts------------------------------------------------------------->
    
    <asp:View id="electronicsView" runat="server">
    
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="cptable" 
            style=" border-top:1px solid #EFEFE2; margin-top:25px" >
    <tr>
    <td>
        <uc1:ProductInfo_Ctrl ID="prodInfoElectronics_Ctrl" runat="server" />
    </td>
    </tr>
    </table>
    
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="cptable" 
            style=" border-top:1px solid #EFEFE2; margin-top:25px" >          
          
        <tr>
            <td align="right" style="width: 210px; height: 25px">
            <asp:Button 
            ID="btnBack" 
            runat="server" 
            CssClass="image_btn_left"
            CausesValidation="false" 
            BorderStyle="Groove" 
            Text="Back" 
            OnClick="btnBack_Click" /></td>
             <td align="left" style="height: 25px">
                   Click Submit button to save your product.
             </td>     
          </tr>
          
          
        <tr>
            <td style="width: 210px; height: 25px">&nbsp;
            </td>
            <td align="left" style="height: 25px">
                <asp:CheckBox 
            ID="chkElectronics" 
            runat="server" 
            Checked="True" 
            Text="Check this if you want to activate this product. Leave uncheck otherwise." /></td>
        </tr>
        <tr>
            <td align="left" colspan="2" style="height: 25px; padding-left:200px;">
                <uc2:TermsAndUseCondition_Ctrl id="TermsAndUseConditione_Ctrl2" runat="server">
                </uc2:TermsAndUseCondition_Ctrl></td>
        </tr>
        <tr>
            <td align="right" style="width: 210px; height: 25px">
                <asp:LinkButton ID="lbtnElectronicsPreview" runat="server" Font-Bold="true" Font-Underline="true">
            Preview of this Product. 
            <img src="../Images/preview-32x32.png" alt="" border="none" width="16px" height="16px" />
            </asp:LinkButton></td>
            <td align="left" style="height: 25px">
                <asp:Button 
                ID="btnElectronics" 
                runat="server" 
                Text="Submit" 
                CssClass="image_btn" OnClick="btnElectronicsSubmit_Click"  />
            </td>
        </tr>
          
          </table>
    
    </asp:View>
    
    <!---------------------------------------------Electronics View Ends------------------------------------------------------------->
    
    
    
    
    <!-----------------------------------Error View Starts---------------------------------------------------->
    <asp:View ID="errorView" runat="server">
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="cptable" style=" border-top:1px solid #EFEFE2; margin-top:25px" >
          
          
          <tr>
             <td style="width: 210px; height: 25px">
             &nbsp;</td>
             <td align="left" style="height: 25px">
                   There has been some error occured. Please contact ApnerDeal.com
             </td>     
          </tr>
        <tr>
            <td align="right" style="width: 210px; height: 25px"><asp:Button 
            ID="btnBackFromErrorPage" 
            runat="server" 
            CssClass="image_btn_left"
            CausesValidation="false" 
            BorderStyle="Groove" 
            Text="Back" 
            OnClick="btnBackFromBook_Click" /></td>
            <td style="height: 25px">
            </td>
        </tr>
          
          </table>
    </asp:View>
    <!-----------------------------------Error View Ends---------------------------------------------------->
    
    <!-----------------------------------Successful Updating/Inserting View Starts---------------------------------------------------->
    <asp:View ID="successView" runat="server">
        <uc3:SuccessMessageView ID="SuccessMessageView1" runat="server" />
        
    
    </asp:View>
    
    <!-----------------------------------Successful Updating/Inserting View Ends---------------------------------------------------->
    
    
    
    <!------------------------------------------ Design For MovieDvdGames Starts Here------------------------------------------------->
    
<asp:View ID="movieDvdGameView" runat="server">

<table cellspacing="0px" cellpadding="0px" border="0px" style="border-bottom: 1px solid rgb(213, 213, 213); width: 952px;">
    <tbody>
    <tr>
    <td width="3px" style="height: 30px">
    <img height="28" width="3" alt="" src="../Images/title_bar_left.gif"/>
    </td>
    <td width="400px" style="background-image: url(../Images/title_bar_bg.gif); background-repeat: repeat-x; padding-left: 5px; height: 30px;">
    <strong>Product General Information</strong></td>
    <td style="width: 3px; height: 30px;">
    <img height="28" width="3" alt="" src="../Images/title_bar_right.gif"/>
    </td>
    <td style="width: 10px">
    </td>
        <td style="width: 200px">
        
        </td>
    </tr>
    </tbody>
</table>
    
     <table width="100%" border="0px" cellspacing="0px" cellpadding="0px" 
        class="cptable" style=" background-color:#F8F8F8; border-top:1px solid #EFEFE2;" id="TABLE3">
   
    <tr>
    <td align="right" style="width: 210px; height: 25px">SKU:</td>
    <td align="left" style="height: 25px">
    <asp:Label ID="lblSkuMovie" runat="server"></asp:Label>
        &nbsp;&nbsp;
    </td>
    </tr>
   
    
    <tr>
    <td align="right" style="width: 210px; height: 25px">Category:</td>
    <td align="left" style="height: 25px">
    <asp:Label ID="lblCategoryMovie" runat="server" />&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;</td>
    </tr>
    
    
    <tr>
    <td align="right" style="width: 210px; height: 25px">Subcategory:</td>
    <td align="left" style="height: 25px">
    <asp:Label ID="lblSubcategoryMovie" runat="server" />&nbsp;
        </td>
    </tr>
    
    
    <tr>
    <td align="right" style="width: 210px; height: 25px">Second Subcategory:</td>
    <td align="left" style="height: 25px">
    <asp:Label ID="lblSecondSubCatMovie" runat="server" />&nbsp;&nbsp;
        </td>
    </tr>
    
        
    <tr>
    <td align="right" style="width: 210px; height: 9px">Product Title:</td>
    <td align="left" style="height: 25px">
    <asp:Label ID="lblProductTitleMovie" runat="server" />&nbsp;
    </td>
    </tr>
    <tr>
    </tr>
    
    
</table>
    
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="cptable" style=" border-top:1px solid #EFEFE2; margin-top:25px"> 
        <tr>
        <td align="right" style="width: 210px; height:25px">
            Type:<span class="mandatory">*</span></td>
        <td align="left" style="height: 25px">
            <asp:DropDownList ID="ddlType" runat="server" Width="151px">
                <asp:ListItem Selected="True" Value = "-1">Select</asp:ListItem>
                <asp:ListItem>DVD</asp:ListItem>
                <asp:ListItem>CD</asp:ListItem>
                <asp:ListItem>BlueRay</asp:ListItem>
            </asp:DropDownList>
            
            <asp:RequiredFieldValidator ID="rfvType" runat="server" ControlToValidate="ddlType"
                ErrorMessage="Type is empty" Font-Bold="True" Display="Dynamic" InitialValue="-1">?
            </asp:RequiredFieldValidator>
            <asp:CustomValidator ID="csvTypeValidator" runat="server" ControlToValidate="ddlType"
                ErrorMessage="Type field is blank." Font-Bold="True" OnServerValidate="csvTypeValidator_ServerValidate">?
            </asp:CustomValidator>
        </td>
        
        </tr>
        
         <tr>
         <td align="right" style="width: 210px; height: 25px">
                 Language:<span class="mandatory">*</span></td>
             <td align="left" style="height: 25px">
                 <asp:TextBox ID="txtLanguageMovie" runat="server" CssClass="textbox" MaxLength="50" Width="150px"></asp:TextBox>
                 
                 <asp:RequiredFieldValidator ID="rfvLanguageCheck" runat="server" ControlToValidate="txtLanguageMovie"
                     ErrorMessage="Language field is blank." Font-Bold="True">?
                 </asp:RequiredFieldValidator>
                 
                 <asp:CustomValidator ID="csvLanguageCheck" runat="server" ErrorMessage="Language field is blank."
                     Font-Bold="True" OnServerValidate="csvLanguageCheck_ServerValidate" ControlToValidate="txtLanguageMovie">?
                 </asp:CustomValidator>
                     
             </td>
         </tr>
       
        
        <tr>
        <td align="right"  style="width: 210px; height: 25px">
            Duration:<span class="mandatory">*</td>
        <td align="left" style="height: 25px">
            <asp:TextBox ID="txtDuration" runat="server" CssClass="textbox" MaxLength="100" Width="150px">            
           </asp:TextBox>
           <asp:RequiredFieldValidator ID="rfvDurationCheck" runat="server" ControlToValidate="txtDuration"
                     ErrorMessage="Duration field is blank." Font-Bold="True">?
           </asp:RequiredFieldValidator>
                 
           <asp:CustomValidator ID="csvDuration" runat="server" ErrorMessage="Duration field is blank."
                     Font-Bold="True" OnServerValidate="csvDuration_ServerValidate" ControlToValidate="txtDuration">?
           </asp:CustomValidator>
           
           
           
           </td>        
        </tr>
        
        
        <tr>
        <td align="right" style="width: 210px; height: 25px">
            Shipping Weight:<span class="mandatory">*</span></td>
        <td align="left" style="height: 25px">
            <asp:TextBox ID="txtShWeightMovie" runat="server" CssClass="textbox" MaxLength="100" Width="150px"></asp:TextBox>
            
            <asp:RequiredFieldValidator ID="rfvShippingWeight" runat="server" ControlToValidate="txtShWeightMovie"
                     ErrorMessage="Shipping Weight field is blank." Font-Bold="True">?
           </asp:RequiredFieldValidator>
                 
           <asp:CustomValidator ID="csvShippingWeight" runat="server" ErrorMessage="Shipping Weight field is blank."
                     Font-Bold="True" OnServerValidate="csvShippingWeight_ServerValidate" ControlToValidate="txtShWeightMovie">?
           </asp:CustomValidator>
            
        </td>        
        </tr>
        
        <tr>
        <td align="right" style="width: 210px; height: 25px">
            Edition/Version:<span class="mandatory">*</span></td>
        <td align="left" style="height: 25px">
            <asp:TextBox ID="txtEditionMovie" runat="server" CssClass="textbox" MaxLength="50" Width="150px">
        </asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvEdition" runat="server" ControlToValidate="txtEditionMovie"
                ErrorMessage="Edition is empty" Font-Bold="True">?
            </asp:RequiredFieldValidator>
            
            <asp:CustomValidator ID="csvEditionMovie" runat="server" ControlToValidate="txtEditionMovie"
                ErrorMessage="Edition field is blank." Font-Bold="True" OnServerValidate="csvEditionMovie_ServerValidate">?
            </asp:CustomValidator>
            
            <asp:Label ID="lblEditionMovie" runat="server" ForeColor="Green" Text="You cannot edit Edition" Visible="False"></asp:Label>
            
         </td>
        </tr>
        
        <tr>
        <td align="right" style="width: 210px; height: 25px">
            Director/Singer/Creator:<span class="mandatory">*</span></td>
        <td align="left" style="height: 25px">
            <asp:TextBox 
                ID="txtAuthorMovie" 
                runat="server" 
                CssClass="textbox" 
                MaxLength="300" 
                Width="150px">
            </asp:TextBox>
            
            <asp:RequiredFieldValidator 
                ID="rfvAuthorMovie" 
                runat="server" 
                ControlToValidate="txtAuthorMovie"
                ErrorMessage="Author is empty" Font-Bold="True">?
            </asp:RequiredFieldValidator>
            
            <asp:CustomValidator ID="csvAuthorMovie" runat="server" ControlToValidate="txtAuthorMovie"
                ErrorMessage="Author field is blank." Font-Bold="True" OnServerValidate="csvAuthorMovie_ServerValidate">?
            </asp:CustomValidator>
            
            <asp:Label ID="lblAuthorMovie" runat="server" ForeColor="Green" Text="You cannot edit Author" Visible="False"></asp:Label></td>
        
        </tr>
        
        
        <tr>
        <td align="right" style="width: 210px; height: 25px">
            Producer:<span class="mandatory">*</span></td>
        <td align="left" style="height: 25px">
            <asp:TextBox ID="txtPublisherMovie" 
                 runat="server" 
                 CssClass="textbox" 
                 MaxLength="300"
                 Width="150px">
            </asp:TextBox>
            
            <asp:RequiredFieldValidator ID="rfvPublisher" 
                 runat="server" 
                 ControlToValidate="txtPublisherMovie"
                 ErrorMessage="Publisher is empty" 
                 Font-Bold="True">?
            </asp:RequiredFieldValidator>
            
            <asp:CustomValidator ID="csvPublisherMovie" 
                 runat="server" 
                 ControlToValidate="txtPublisherMovie"
                 ErrorMessage="Publisher field is blank." 
                 Font-Bold="True" OnServerValidate="csvPublisherMovie_ServerValidate">?
            </asp:CustomValidator>
            
            <asp:Label ID="lblPublisherMovie" runat="server" ForeColor="Green" Text="You cannot edit Publisher" Visible="False"></asp:Label></td>
        
        </tr>
    
        <tr>
        <td align="right" style="width: 200px; height: 25px">
        
        <asp:Button 
            ID="btnBackFromMovie" 
            runat="server" 
            CssClass="image_btn_left"
            CausesValidation="false" 
            BorderStyle="Groove" 
            Text="Back" 
            OnClick="btnBackFromMovie_Click" />
            
        </td>
        <td align="left" style="height: 25px">
    <asp:CheckBox 
        ID="chkMovieDvdIsActive" 
        runat="server" 
        Checked="True" 
        Text="Check this if you want to activate this product. Leave uncheck otherwise." />
       
        
        </td>
        </tr>
            <tr>
                <td align="left" colspan="2" style="height: 25px; padding-left:200px;">
                <span style="font-size:11px; "><uc2:TermsAndUseCondition_Ctrl ID="TermsAndUseCondition_Ctrl5" runat="server" /></span>
               
                </td>
            </tr>
            <tr>
            <td align="right" style="width:210px; height: 25px;">
            <asp:LinkButton ID="lbtnMovieDvdGamePreview" runat="server" Font-Bold="true">
                Preview of this Product. <img src="../Images/preview-32x32.png" alt="" border="none" width="16px" height="16px" />
            </asp:LinkButton>
            </td>
            <td align="left" style="height: 25px">
            <asp:Button 
                ID="btnMovieSubmit" 
                runat="server" 
                Text="Submit" 
                CssClass="image_btn" OnClick="btnMovieSubmit_Click"  />
            </td>
            </tr>
        
    </table>
    </asp:View>
    
    
   <!------------------------------------------ Design For MovieDvdGames Ends Here------------------------------------------------->
    
    
    
    </asp:MultiView>
    <table>
    <tr>
    <td align="left" style="width: 954px">
    <asp:HiddenField ID="hfSku" runat="server" />
    <asp:HiddenField ID="hfProfileID" runat="server" />
    <asp:HiddenField ID="hfPageMode" runat="server" />
    <asp:HiddenField ID="hfCategoryID" runat="server" />
    <asp:HiddenField ID="hfSubcategoryID" runat="server" />
    <asp:HiddenField ID="hfSecondSubcatID" runat="server" />
    <asp:HiddenField ID="hfProductID" runat="server" />
    <asp:HiddenField ID="hfInsertType" runat="server" />
    <asp:HiddenField ID="hfProductTitle" runat="server" />
    <asp:HiddenField ID="hfCategory" runat="server" />
    <asp:HiddenField ID="hfSubcategory" runat="server" />
    <asp:HiddenField ID="hfSecondSubcategory" runat="server" />
    <asp:HiddenField ID="hfCanEdit" runat="server" />
    </td>
    </tr>
    </table>

    
</asp:Content>

