<%@ Page Language="C#" MasterPageFile="~/Corporate/MPCorporate2.master" AutoEventWireup="true" CodeFile="UserProfile_Edit.aspx.cs" Inherits="Corporate_UserProfile_Edit" Title="ApnerDeal.com–Edit Corporate User Profile." %>
<%@ Register Src="../UserControl/ImageResizeLink_Ctrl.ascx" TagName="ImageResizeLink_Ctrl"
    TagPrefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
<tr>
<td>
<span class="pageTitle">Corporate - Edit User Profile.</span>
<br /><br />
</td>
</tr>
   <tr>
   <td style="height: 23px">&nbsp;</td>
   <td align="right" style="height: 23px">Fields marked by <span class="mandatory">*</span> are mandatory</td>
   </tr>
   
   <tr>
   <td colspan="2" align="left" style="font-size:11px;">
   <asp:ValidationSummary 
        ID="ValidationSummary1" 
        runat="server" 
        Width="500px" 
        BackColor="#FFFFFF" 
        ForeColor="Black" 
        Font-Bold="False" 
        HeaderText="<table><tr><td style='padding-left:10px; padding-top:7px;'><img src='../images/icon_error.gif' width='42' height='40' alt='' /></td><td valign='middle' style='font-weight:bold; text-decoration:underline;color:#ED0000;'>Following error occured :</td></tr></table>" 
        BorderStyle="Dashed" 
        BorderWidth="1px"/>                 
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
<table width="100%" border="0" cellspacing="0" cellpadding="0" class="cptable" style="border-top:1px solid #EFEFE2;" id="TABLE1">
    <tr>
    <td align="left" colspan="2" style="height:37px; color:#365EBF; text-decoration:underline;"><strong>Login Information </strong></td>
    </tr>
    <tr>
    <td  align="center" style="width: 120px; padding-top:5px; padding-bottom:5px; height: 120px;">
        <div class="t" style="width:120px">
            <div class="b">
                <div class="l">
                    <div class="r">
                        <div class="bl">
                            <div class="br">
                                <div class="tl">
                                    <div class="tr" style="height: 120px;padding-top:5px;">
                                        <img src='../<%=ImagePathCorporate%>' onerror="javascript:this.src='../Classifieds_ProductImage/index.jpg';"
                                            style="height: 110px; width: 110px; border: none;" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </td>
    <td align="left" style="height: 25px">
        Change or
    Upload Company Logo<br />
    
            <asp:FileUpload 
                    ID="FileUpload1" 
                    runat="server" 
                    BorderStyle="Groove" />
                <asp:Button
                    ID="btnUpload" 
                    runat="server" 
                    CausesValidation="False" 
                    OnClick="btnUpload_Click"
                    Text="Upload" Font-Bold="True" Font-Underline="False" />
                <asp:Label 
                    ID="lblImageUploadMessage" 
                    runat="server" 
                    Font-Size="12px"
                    Font-Bold="true"
                    ForeColor="Red" 
                    Width="250px"></asp:Label><br />
                    <span class="gray11px" style="color:Coral"><strong><span style="color: red"><span
                        style="text-decoration: underline">Important: </span>Please Click on 'Upload' 
                        button
                        then click below 'Submit'
                        button. Other wise image will not save or update.</span></strong><br />
                        <br />
                        Image size must be less then 200 KB. Choose any format except .bmp.&nbsp;
                        Preferred width 200 px. and height 300 px. To resize your image before upload please click
                        on the below <strong>'Resize Picture'</strong> link.<br />
                        <br />
                        <img src="../Images/arrow_orange.gif" /><uc4:ImageResizeLink_Ctrl ID="ImageResizeLink_Ctrl1" runat="server" />
                    </span>
    </td>
    </tr>

    <tr>
    <td align="right" width="200" style="height: 25px">Email:<span class="mandatory">*</span></td>
    <td align="left" style="height: 25px">
    <asp:TextBox 
        ID="txtEmail1" 
        runat="server" 
        Width="180px" 
        Height="15px"                        
        MaxLength="100" CssClass="textbox">
    </asp:TextBox>
    &nbsp;&nbsp;&nbsp;&nbsp;    
    <asp:RequiredFieldValidator 
        ID="rfvEmail1" 
        runat="server" 
        ControlToValidate="txtEmail1" 
        ErrorMessage="Email address field is blank! Please type your Email address properly." 
        SetFocusOnError="true" 
        Font-Bold="True">?</asp:RequiredFieldValidator>
    &nbsp;    
    <asp:RegularExpressionValidator 
        ID="revEmail1" 
        runat="server" 
        ControlToValidate="txtEmail1" 
        ErrorMessage="Invalid Email address! Please type your valid Email address." 
        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
        Font-Bold="True">?</asp:RegularExpressionValidator>       
    <span class="gray11px">(this will be your Login ID.)</span>        
    </td>
    </tr>

    <tr>
    <td align="right">Re-enter Email:<span class="mandatory">*</span></td>
    <td align="left">
    <asp:TextBox 
        ID="txtEmail2" 
        runat="server"             
        Width="180px" 
        Height="15px" 
        MaxLength="100" CssClass="textbox">
    </asp:TextBox>
    &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:RequiredFieldValidator 
        ID="rfvEmail2" 
        runat="server" 
        ControlToValidate="txtEmail2" 
        ErrorMessage="Email confirmation field is blank! Please re-type your Email address properly." 
        SetFocusOnError="true" 
        Font-Bold="True">?</asp:RequiredFieldValidator>
    &nbsp;        
    <asp:RegularExpressionValidator 
        ID="revEmail2" 
        runat="server" 
        ControlToValidate="txtEmail2" 
        ErrorMessage="You re-type an invalid Email address! Please type your valid Email address." 
        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
        Font-Bold="True">?</asp:RegularExpressionValidator>
    <br />
    <asp:CompareValidator 
        ID="cmvEmail" 
        runat="server" 
        ControlToCompare="txtEmail1"
        ControlToValidate="txtEmail2" 
        ErrorMessage="Your re-typed Email address does not match!  Please type the same Email address in both fields." 
        Font-Size="11px">
    </asp:CompareValidator>        
    </td>
    </tr>
            
    <tr>
    <td align="left" colspan="2" style="height:37px; color:#365EBF; text-decoration:underline;"><strong>Corporate Details</strong></td>
    </tr>

    <tr>
    <td align="right" style="height: 25px">Company Name:<span class="mandatory">*</span></td>
    <td align="left" style="height: 25px">
    <asp:TextBox 
        ID="txtCompany" 
        runat="server"             
        Width="345px" 
        Height="15px" 
        MaxLength="250" 
        CssClass="textbox">
    </asp:TextBox>
    &nbsp;&nbsp;&nbsp;&nbsp;    
    <asp:RequiredFieldValidator 
        ID="rfvCompany" 
        runat="server"
        ControlToValidate="txtCompany"
        ErrorMessage="Company Name field is blank! Please type your Company Name properly." 
        SetFocusOnError="true" 
        Font-Bold="True">?</asp:RequiredFieldValidator>        
    </td>
    </tr>        

    <tr>
    <td align="right">Business Type:<span class="mandatory">*</span></td>
    <td align="left">
    <asp:DropDownList 
        ID="ddlBusinessType" 
        runat="server" 
        Width="258px" 
        AppendDataBoundItems="True">
        <asp:ListItem Text="Select" Value="-1"></asp:ListItem>
    </asp:DropDownList>
    &nbsp;&nbsp;&nbsp;&nbsp;    
    <asp:RequiredFieldValidator 
        ID="rfvBusinessType" 
        runat="server" 
        ControlToValidate="ddlBusinessType" 
        InitialValue="-1"
        ErrorMessage="Business Type field is not selected! Please select your Business Type properly."             
        SetFocusOnError="True" 
        Font-Bold="True">?</asp:RequiredFieldValidator>        
    </td>
    </tr>        

    <tr>
    <td align="right" valign="top" style="height: 25px">Location:<span class="mandatory">*</span></td>
    <td align="left" style="height: 25px">
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
<TABLE style="WIDTH: 100%" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="WIDTH: 10%; BORDER-BOTTOM: 0px">Country</TD><TD style="WIDTH: 90%; BORDER-BOTTOM: 0px"><asp:DropDownList id="ddlCountry" runat="server" Width="226px" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged">
                            <asp:ListItem Value="-1" Text="Select"></asp:ListItem>
                        </asp:DropDownList> &nbsp;&nbsp;&nbsp;&nbsp; <asp:RequiredFieldValidator id="rfvCountry" runat="server" Font-Bold="True" SetFocusOnError="True" ErrorMessage="Country field is not selected ! Please select your Country properly." ControlToValidate="ddlCountry" InitialValue="-1">?</asp:RequiredFieldValidator> </TD></TR><TR><TD style="WIDTH: 10%; BORDER-BOTTOM: 0px">Division</TD><TD style="WIDTH: 90%; BORDER-BOTTOM: 0px"><asp:DropDownList id="ddlState" runat="server" Width="226px" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="ddlState_SelectedIndexChanged">
                            <asp:ListItem Value="-1" Text="Select"></asp:ListItem>
                        </asp:DropDownList> &nbsp;&nbsp;&nbsp;&nbsp; <asp:RequiredFieldValidator id="rfvState" runat="server" Font-Bold="true" SetFocusOnError="true" ErrorMessage="State field is not selected ! Please select your state properly." ControlToValidate="ddlState" InitialValue="-1" Text="?"></asp:RequiredFieldValidator> </TD></TR><TR><TD style="WIDTH: 10%; BORDER-BOTTOM: 0px">District</TD><TD style="WIDTH: 90%; BORDER-BOTTOM: 0px"><asp:DropDownList id="ddlProvince" runat="server" Width="226px" AppendDataBoundItems="True">
                            <asp:ListItem Text="Select" Value="-1"></asp:ListItem>
                        </asp:DropDownList> &nbsp;&nbsp;&nbsp;&nbsp; <asp:RequiredFieldValidator id="rfvProvince" runat="server" Font-Bold="true" SetFocusOnError="true" ErrorMessage="Province field is not selected ! Please select your province properly." ControlToValidate="ddlProvince" InitialValue="-1" Text="?"></asp:RequiredFieldValidator> </TD></TR></TBODY></TABLE>
</ContentTemplate>
    </asp:UpdatePanel>    
                 
    </td>
    </tr>        

    <tr>
    <td align="right">Contact/Business Address:<span class="mandatory">*</span></td>
    <td align="left">
    <asp:TextBox 
        ID="txtAddress" 
        runat="server"             
        Width="345px" 
        Height="103px" 
        TextMode="MultiLine" 
        MaxLength="300" CssClass="textbox"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;&nbsp;    
    <asp:RequiredFieldValidator 
        ID="rfvAddress" 
        runat="server" 
        ErrorMessage="Business Address field is blank! Please type your Business Address properly." 
        ControlToValidate="txtAddress" Font-Bold="True">?</asp:RequiredFieldValidator>
    </td>
    </tr>

    <tr>
    <td align="right">Contact Phone:<span class="mandatory">*</span></td>
    <td align="left">
    <asp:TextBox 
        ID="txtPhone" 
        runat="server"             
        Width="180px" 
        Height="15px" 
        MaxLength="50" CssClass="textbox"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;&nbsp;    
    <asp:RequiredFieldValidator 
        ID="rfvPhone" 
        runat="server" 
        ControlToValidate="txtPhone"
        ErrorMessage="Contact Phone number field is blank! Please type Contact Phone number properly."
        SetFocusOnError="True" Font-Bold="True">?</asp:RequiredFieldValidator>        
    </td>
    </tr>                        

    <tr>
    <td align="right" style="height: 25px">Web Site Address (URL):</td>
    <td align="left" style="height: 25px">
    <asp:TextBox 
        ID="txtURL" 
        runat="server"             
        Width="300px" 
        Height="15px" 
        MaxLength="100" CssClass="textbox"></asp:TextBox>        
    </td>
    </tr>                        

    <tr>
    <td align="right">Billing Person:<span class="mandatory">*</span></td>
    <td align="left">
    <asp:TextBox 
        ID="txtBillingContact" 
        runat="server"             
        Width="345px" 
        Height="15px" 
        MaxLength="200" CssClass="textbox"></asp:TextBox>
    &nbsp;&nbsp;&nbsp;&nbsp;    
    <asp:RequiredFieldValidator 
        ID="rfvBillingContact" 
        runat="server" 
        ControlToValidate="txtBillingContact"
        ErrorMessage="Billing Person field is blank! Please type Billing Person’s name properly." 
        SetFocusOnError="true" Font-Bold="True">?</asp:RequiredFieldValidator>        
    </td>
    </tr>                        

    <tr>
    <td align="right">Inventory Manager:</td>
    <td align="left">
    <asp:TextBox 
        ID="txtInventoryManager" 
        runat="server" 
        Width="345px" 
        Height="15px" 
        MaxLength="200" CssClass="textbox">
    </asp:TextBox>
    </td>
    </tr>                        

    <tr>
    <td align="right">Company Profile:</td>
    <td align="left">
    <asp:TextBox 
        ID="txtProfile" 
        runat="server"             
        Width="345px" 
        Height="150px" 
        TextMode="MultiLine" 
        MaxLength="400" CssClass="textbox">
    </asp:TextBox>        
    </td>
    </tr>
    
     <tr>
    <td align="right">
    <br />
    </td>
    <td align="left">
   <span style="font-size:11px; padding-left:150px;">Our <a href="Default.aspx" style="text-decoration:underline;">Terms of Use</a> and <a href="Default.aspx" style="text-decoration:underline;">Privacy Policy</a>.</span><br /><br />     
   <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="image_btn" OnClick="btnSubmit_Click" />
    </td>
   </tr>
    
</table>
<div style="padding-left:150px;">
</div>
</asp:Content>

