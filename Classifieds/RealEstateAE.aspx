<%@ Page Language="C#" MasterPageFile="~/Classifieds/MPClassifieds2.master" AutoEventWireup="true" CodeFile="RealEstateAE.aspx.cs" Inherits="Classifieds_RealEstateAE" Title="Real Estate" %>

<%@ Register Src="../UserControl/ImageResizeLink_Ctrl.ascx" TagName="ImageResizeLink_Ctrl"
    TagPrefix="uc1" %>
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
    </script>

    <!--
<div align="right" class="top_secondary_link">
   <a href="#">I want to signup as a General User</a> |
   <a href="#">Switch to General User Control Panel</a> |
   <a href="#">Sign out</a>  
</div>
-->
    <span class="pageTitle">Real Estate - Post/Edit your Ad.</span><br />
    <span class="gray11px" style="font-weight: normal; margin-top: 7px;">ApnerDeal.com is
        absolutely <strong style="color: #EC2024;">FREE</strong> for posting classified
        Ads. It will not cost you anything.</span>
    <br />
    <br />
 
   
   

   
 
    <div style="width: 815px">
    
    <asp:UpdatePanel ID="updatePanel1" runat="server">
    <ContentTemplate>
    
        <table cellspacing="0" cellpadding="0" width="100%" border="0">
            <tbody>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td align="right">
                        Fields marked by <span class="mandatory">*</span> are mandatory</td>
                </tr>
                <tr>
                    <td style="font-size: 11px" align="left" colspan="2">
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" Width="500px" BackColor="#FFFFFF"
                            ForeColor="Black" Font-Bold="False" HeaderText="<table><tr><td style='padding-left:10px; padding-top:7px;'><img src='../images/icon_error.gif' width='42' height='40' alt='' /></td><td valign='middle' style='font-weight:bold; text-decoration:underline;color:#ED0000;'>Following error occured :</td></tr></table>"
                            BorderStyle="Dashed" BorderWidth="1px" Font-Size="11px"></asp:ValidationSummary>
                        <asp:Label ID="lblSystemMessage" runat="server" Width="500px" ForeColor="Red" Font-Size="11px"
                            EnableViewState="False">
                        </asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="2">
                    </td>
                </tr>
            </tbody>
        </table>
        <table class="cptable" cellspacing="0" cellpadding="0" width="100%" border="0">
            <!--BEGIN: PRODUCT DETAILS-->
            <tbody>
                <tr>
                    <td style="color: #365ebf; text-decoration: underline" colspan="2">
                        <strong>
                            <span style="font-size: 11pt">Product/Service Details</span>
                        </strong>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 180px; height: 27px">
                        SKU:
                    </td>
                    <td align="left" style="width: auto">
                        <asp:Label ID="lblSku" runat="server">
                        </asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="height: 54px; width:180px;">
                        Location:<span class="mandatory">*</span>
                    </td>
                    <td align="left" style="width:auto;">
                        <asp:RadioButtonList ID="rblLocation" runat="server" Width="300px" AutoPostBack="True"
                            RepeatDirection="Horizontal" OnSelectedIndexChanged="rblLocation_SelectedIndexChanged">
                            <asp:ListItem Text="Inside Dhaka" Value="InDhaka" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="Outside Dhaka" Value="OutDhaka"></asp:ListItem>
                        </asp:RadioButtonList>
                        <asp:DropDownList ID="ddlLocation" runat="server" Width="300px" AppendDataBoundItems="True">
                            <asp:ListItem Value="-1" Text="Select"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator 
                            ID="rfvLocation" 
                            runat="server" 
                            Font-Bold="True" ControlToValidate="ddlLocation"
                            ErrorMessage="Location is not selected ! Please select the Location properly."
                            SetFocusOnError="True" InitialValue="-1">?</asp:RequiredFieldValidator>
                    </td>
                </tr>
                
                <tr>
                    <td style="border-right: medium none; padding-right: 0px; border-top: medium none;
                        padding-left: 0px; padding-bottom: 0px; border-left: medium none; padding-top: 0px;
                        border-bottom: medium none; height: 0px" valign="top" colspan="2">
                        <asp:Panel ID="pnlArea" runat="server" Width="100%" Visible="false" Enabled="false">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="cptable">
                                <tr>
                                    <td align="right" style="height: 27px; width:180px;">
                                        Area Name:<span class="mandatory">*</span>
                                    </td>
                                    <td align="left" style="height: 27px;">
                                        <asp:TextBox ID="txtArea" runat="server" MaxLength="50" CssClass="textbox" Height="19px" Width="294px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvArea" runat="server" ControlToValidate="txtArea"
                                            Display="Dynamic" ErrorMessage="Area field is blank. Please provide area.">?</asp:RequiredFieldValidator>
                                        <br />
                                        
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                
                <tr>
                    <td align="right" style=" height: 27px; width:180px;">
                        Address:<span class="mandatory">*</span>
                    </td>
                    
                    <td align="left" style="height: 27px">
                        <asp:TextBox ID="txtAddress" runat="server" MaxLength="300" CssClass="textbox" Height="89px" TextMode="MultiLine" Width="294px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvAddress" runat="server" Font-Bold="True" ControlToValidate="txtAddress"
                            ErrorMessage="Address field is blank! Please provide address." SetFocusOnError="True"
                            InitialValue="-1">?</asp:RequiredFieldValidator>
                            <br />
                            <span class="gray11px">Max 300 char</span>
                    </td>
                </tr>
                
                <tr>
                    <td align="right" style=" height: 27px; width:180px;" valign="top">
                        SubCategory:<span class="mandatory">*</span>
                    </td>
                    
                    <td align="left" style="height: 27px">
                        <asp:DropDownList 
                            ID="ddlSubcategory" 
                            runat="server" 
                            Width="300px" 
                            AutoPostBack="True" 
                            AppendDataBoundItems="True" OnSelectedIndexChanged="ddlSubcategory_SelectedIndexChanged">
                            <asp:ListItem Text="Select SubCategory" Value="-1"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvSubcategory" runat="server" Font-Bold="True" ControlToValidate="ddlSubcategory"
                            ErrorMessage="Category is not selected ! Please select Category." SetFocusOnError="True"
                            InitialValue="-1">?</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right" style=" height: 27px; width:180px;" valign="top">
                        Second Subcategory:<span class="mandatory">*</span>
                    </td>
                    <td align="left" style="height: 27px">
                        <asp:DropDownList ID="ddlSecondSubcategory" AppendDataBoundItems="true" runat="server" Width="300px" AutoPostBack="True" OnSelectedIndexChanged="ddlSecondSubcategory_SelectedIndexChanged">
                        <asp:ListItem Text="Select Second Subcategory" Value="-1"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvSecondSubcategory" runat="server" ControlToValidate="ddlSecondSubcategory"
                            Display="Dynamic" ErrorMessage="Please select second subcategory." InitialValue="-1"
                            SetFocusOnError="True">?</asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td align="right" style=" height: 27px; width:180px;" valign="top">
                        Seller Type:<span class="mandatory">*</span>
                    </td>
                    <td align="left" style="height: 27px">
                        <asp:DropDownList ID="ddlSellerType" runat="server" Width="300px" AppendDataBoundItems="True">
                        <asp:ListItem Text="Select Seller Type" Value="-1"></asp:ListItem>
                        </asp:DropDownList><asp:RequiredFieldValidator ID="rfvSellerType" runat="server"
                            ControlToValidate="ddlSellerType" Display="Dynamic" ErrorMessage="Please select seller type"
                            InitialValue="-1" SetFocusOnError="True">?</asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td align="right" style="width: 180px; height: 27px" valign="top">
                        Seller Name:<span class="mandatory">*</span>
                    </td>
                    <td align="left" style="height: 27px">
                                    <asp:TextBox ID="txtSellerName" runat="server" MaxLength="100" CssClass="textbox">
                                    </asp:TextBox><asp:RequiredFieldValidator ID="rfvSellerName" runat="server" ControlToValidate="txtSellerName"
                                        Display="Dynamic" ErrorMessage="Seller name field is blank! Please provide seller name.">?</asp:RequiredFieldValidator></td>
                </tr>
                
                
                <tr>
                    <td style="border-right: medium none; padding-right: 0px; border-top: medium none;
                        padding-left: 0px; padding-bottom: 0px; border-left: medium none; padding-top: 0px;
                        border-bottom: medium none; height: 0px" valign="top" colspan="2">
                        <asp:Panel ID="pnlProjectType" runat="server" Width="100%" Visible="false" Enabled="false">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="cptable">
                                <tr>
                                    <td align="right" style="height: 27px; width:180px;">
                                        Project Type:<span class="mandatory">*</span>
                                    </td>
                                    <td align="left" style="height: 27px;">
                                        <asp:DropDownList ID="ddlProjectType" runat="server" Width="300px" AppendDataBoundItems="true">
                                        <asp:ListItem Text="Select Project Type" Value="-1"></asp:ListItem>
                                        
                                        </asp:DropDownList><asp:RequiredFieldValidator ID="rfvProjectType" runat="server"
                                            ControlToValidate="ddlProjectType" Display="Dynamic" ErrorMessage="Please select projet type"
                                            InitialValue="-1" SetFocusOnError="True">?</asp:RequiredFieldValidator></td>
                                </tr>
                               
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td align="right" style=" height: 27px; width:180px;" valign="top">
                        Size:<span class="mandatory">*</span></td>
                    <td align="left" style="height: 27px">
                        <asp:TextBox ID="txtSize" runat="server" CssClass="textbox" onkeydown="return IsDigit(event);"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvSize" runat="server" ControlToValidate="txtSize"
                            ErrorMessage="Size field is blank. Please provide a size.">?</asp:RequiredFieldValidator>
                        <asp:Label ID="lblSizeUnit" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" style=" height: 27px; width:180px;" valign="top">
                        Price/Rent:<span class="mandatory">*</span>
                    </td>
                    <td align="left" style="height: 27px">
                        <asp:TextBox ID="txtPrice" runat="server" onkeydown="return IsDigit(event);" CssClass="textbox">
                        </asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvPrice" runat="server" ControlToValidate="txtPrice"
                            ErrorMessage="Price field is blank. Please provide a price.">?</asp:RequiredFieldValidator>
                        <asp:DropDownList ID="ddlCurrency"
                                    runat="server" Width="65px" Enabled="False">
                                    <asp:ListItem Text="BDT" Value="BDT"></asp:ListItem>
                                    <asp:ListItem Text="USD" Value="USD"></asp:ListItem>
                                </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 180px; height: 27px" valign="top">
                        Quantity:<span class="mandatory">*</span></td>
                    <td align="left" style="height: 27px">
                        <asp:TextBox ID="txtQuantity" runat="server" CssClass="textbox" MaxLength="10" onkeydown="return IsDigit(event);"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvQuantity" runat="server" ControlToValidate="txtQuantity"
                            ErrorMessage="Quantity field is blank. Please provide quantity.">?</asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <td style="border-right: medium none; padding-right: 0px; border-top: medium none;
                        padding-left: 0px; padding-bottom: 0px; border-left: medium none; padding-top: 0px;
                        border-bottom: medium none; height: 0px" valign="top" colspan="2">
                        <asp:Panel ID="pnlBedRooms" runat="server" Width="100%" Visible="false" Enabled="false">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="cptable">
                                <tr>
                                    <td align="right" style="height: 27px; width:180px;">
                                        Number of Bedrooms:<span class="mandatory">*</span>
                                    </td>
                                    <td align="left" style="height: 27px">
                                        <asp:TextBox 
                                            ID="txtBedRooms" 
                                            runat="server" 
                                            MaxLength="30"  
                                            onkeydown="return IsDigit(event);"
                                            CssClass="textbox">
                                        </asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtBedRooms"
                                            Display="Dynamic" ErrorMessage="Please provide number of bedrooms.">?</asp:RequiredFieldValidator></td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                
                <tr>
                    <td style="border-right: medium none; padding-right: 0px; border-top: medium none;
                        padding-left: 0px; padding-bottom: 0px; border-left: medium none; padding-top: 0px;
                        border-bottom: medium none; height: 0px" valign="top" colspan="2">
                        <asp:Panel ID="pnlWashRooms" runat="server" Width="100%" Visible="false" Enabled="false">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="cptable">
                                <tr>
                                    <td align="right" style="height: 27px; width:180px;">
                                        Number of Washrooms:<span class="mandatory">*</span>
                                    </td>
                                    <td align="left" style="height: 27px">
                                        <asp:TextBox
                                            ID="txtWashRooms" 
                                            runat="server" 
                                            onkeydown="return IsDigit(event);"
                                            CssClass="textbox">
                                        </asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtWashRooms"
                                            Display="Dynamic" ErrorMessage="Please provide number of washrooms.">?</asp:RequiredFieldValidator></td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                
                <tr>
                    <td style="border-right: medium none; padding-right: 0px; border-top: medium none;
                        padding-left: 0px; padding-bottom: 0px; border-left: medium none; padding-top: 0px;
                        border-bottom: medium none; height: 0px" valign="top" colspan="2">
                        <asp:Panel ID="pnlServiceCharge" runat="server" Width="100%" Visible="false" Enabled="false">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="cptable">
                                <tr>
                                    <td align="right" style="height: 27px; width:180px;">
                                        Service Charge:<span class="mandatory">*</span>
                                    </td>
                                    <td align="left" style="height: 27px">
                                        <asp:TextBox
                                            ID="txtServiceCharge" 
                                            runat="server" 
                                            onkeydown="return IsDigit(event);"
                                            CssClass="textbox"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvServiceCharge" runat="server" ControlToValidate="txtServiceCharge"
                                            Display="Dynamic" ErrorMessage="Please provide service charge.">?</asp:RequiredFieldValidator></td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                </tbody>
                </table>
                
                <table class="cptable" cellspacing="0" cellpadding="0" width="100%" border="0">
            <tbody>
                <tr>
                    <td style="padding-right: 0px; padding-left: 0px; padding-bottom: 0px; padding-top: 0px;
                        border-bottom: medium none; height: 0px" colspan="2">
                        <asp:Panel ID="pnlCarParking" runat="server" Width="100%" Visible="false">
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tbody>
                                    <tr>
                                        <td align="right" style="width: 180px; height: 27px">
                                              Car Parking:<span class="mandatory">*</span>
                                        </td>
                                        <td align="left" style="height: 27px">
                                            <asp:CheckBox id="chkIsCarParkingAvailable" runat="server" Text="Check this if Car parking is available, leave uncheck otherwise.">
                                        </asp:CheckBox>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                
               
                        </asp:Panel>
                    </td>
                </tr>
            </tbody>
        </table>
        
        <table class="cptable" cellspacing="0" cellpadding="0" width="100%" border="0">
            <tbody>
                <tr>
                    <td style="padding-right: 0px; padding-left: 0px; padding-bottom: 0px; padding-top: 0px;
                        border-bottom: medium none; height: 0px" colspan="2">
                        <asp:Panel ID="pnlLandNature" runat="server" Width="100%" Visible="false" Enabled="false">
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tbody>
                                    <tr>
                                        <td align="right" style="width: 180px; height: 27px">
                                              Land Nature:<span class="mandatory">*</span>
                                        </td>
                                        <td align="left" style="height: 27px">
                                            <asp:RadioButtonList ID="rblLandNature" runat="server" RepeatDirection="Horizontal">
                                                <asp:ListItem Value="Developed" Selected="True">Developed</asp:ListItem>
                                                <asp:ListItem Value="UnDeveloped">UnDeveloped</asp:ListItem>
                                            </asp:RadioButtonList></td>
                                    </tr>
                                </tbody>
                            </table>
                
               
                        </asp:Panel>
                    </td>
                </tr>
            </tbody>
        </table>
        
        <table class="cptable" cellspacing="0" cellpadding="0" width="100%" border="0">
            <tbody>
                
                <tr>
                    <td align="right" style="width: 180px; height: 27px">
                  Project Name:<span class="mandatory">*</span></td>
                    <td align="left" style="height: 27px">
                    
                        <asp:TextBox ID="txtProjectName" runat="server" CssClass="textbox" MaxLength="50" Width="400px">
                        </asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvProjectName" runat="server" ControlToValidate="txtProjectName"
                            Display="Dynamic" ErrorMessage="Please provide project name.">?</asp:RequiredFieldValidator>
                            
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 180px; height: 27px">
                       Description:<span class="mandatory" >*</span></td>
                    <td align="left" style="height: 20px">
                        <asp:TextBox ID="txtDescription" runat="server" Width="497px" CssClass="textbox"
                            Height="142px" MaxLength="3000" TextMode="MultiLine">
                        </asp:TextBox>
                        &nbsp;&nbsp;
                        <asp:RequiredFieldValidator ID="rfvDescription" runat="server" Font-Bold="True" ControlToValidate="txtDescription"
                            ErrorMessage="Product Description is blank !  Please type your product description properly."
                            SetFocusOnError="True">?</asp:RequiredFieldValidator>
                        <br />
                        <span class="gray11px" style="color:Coral">Type your description but not more than 3000 characters.</span>
                    </td>
                </tr>
              
                </table>
                
                
      </ContentTemplate>
    </asp:UpdatePanel>
              
                
                <table class="cptable" cellspacing="0" cellpadding="0" width="100%" border="0">
                <tbody>
                  <tr>
                    <td align="right" style="height: 27px; width:180px;">
                        Image:</td>
                    <td align="left" style="vertical-align: top; height: 27px">
                        <asp:FileUpload ID="FileUpload1" runat="server" CssClass="textbox" />
                        <asp:Button ID="btnUpload" runat="server" CausesValidation="False" CssClass="textbox"
                            OnClick="btnUpload_Click" Text="Upload" />
                        <asp:Label ID="lblImageUploadMessage" runat="server" ForeColor="Red"></asp:Label><br />
                    <span class="gray11px" style="color:Coral">
                        Image size must be less then 200 KB. Choose any format except .bmp.&nbsp;<br />
                        Preferred width height ratio 200 by 300 px.
                        <br />
                        <uc1:ImageResizeLink_Ctrl ID="ImageResizeLink_Ctrl1" runat="server" />
                    </span>
                    </td>
                </tr>
                <tr>
                    <td style="height: 27px">
                    &nbsp;
                    </td>
                    <td style="vertical-align: top; height: 27px">
                        <asp:CheckBox 
                            ID="chkIsActive" 
                            runat="server" 
                            Text="Check this if you want to activate this product. Leave uncheck otherwise." Checked="True" />
                    </td>
                </tr>
            </tbody>
        </table>
        
        <asp:Panel ID="pnlSource" runat="server" Width="100%">
        <table class="cptable" cellspacing="0" cellpadding="0" width="100%" border="0">
            <tbody>
                <tr>
                    <td align="right" style="width: 181px; height: 25px" valign="top">
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
                    <td style="width: 181px; height: 25px" valign="top">
                        &nbsp;</td>
                    <td style="height: 25px">
                        &nbsp;<asp:CheckBox ID="chkIsDisplayAddress" runat="server"  Checked="false" Text="Dont Show my address.">
                </asp:CheckBox></td>
                </tr>
            </tbody>
        </table>
            
        </asp:Panel>
        
        <br />
        <span style="padding-left: 100px; font-size: 11px">By posting your Ad, you are agreeing
            to our <a style="text-decoration: underline" href="#">Terms of Use</a> and <a style="text-decoration: underline"
                href="#">Privacy Policy</a>.</span>
        <br />
        <br />
        <div style="padding-left: 200px">
            <asp:Button ID="btnSubmit" runat="server" CssClass="image_btn"
                Text="Submit" OnClick="btnSubmit_Click"></asp:Button>
        </div>
        <br />
    </div>
    
    
</asp:Content>

