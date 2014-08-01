<%@ Page Language="C#" MasterPageFile="~/Classifieds/MPClassifieds2.master" AutoEventWireup="true" CodeFile="UserProfile_Edit.aspx.cs" Inherits="Classifieds_UserProfile_Edit" Title="www.apnerdeal.com – Edit Classified User Profile." %>
<%@ Register Src="../UserControl/ImageResizeLink_Ctrl.ascx" TagName="ImageResizeLink_Ctrl"
    TagPrefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<!--
<div align="right" class="top_secondary_link">
   <a href="#">I want to signup as a General User</a> |
   <a href="#">Switch to General User Control Panel</a> |
   <a href="#">Sign out</a>  
</div>
-->
<span class="pageTitle">Classifieds - Edit User Profile.</span><br />
<span class="gray11px" style="font-weight:normal; margin-top:7px;">ApnerDeal.com is absolutely <strong style="color:#EC2024;">FREE</strong> for posting classified Ads. It will not cost you anything.</span>
<br /><br />

<table width="100%" border="0px" cellspacing="0px" cellpadding="0px">
   <tr>
   <td>&nbsp;</td>
   <td align="right">Fields marked by <span class="mandatory">*</span> are mandatory</td>
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
        BorderWidth="1px" Font-Size="11px"/>                 
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
<table width="100%" border="0px" cellspacing="0px" cellpadding="0px" class="cptable" style="border-top:1px solid #EFEFE2;">
    <!--BEGIN: LOGIN INFORMATION-->
    <tr>
    <td align="left" colspan="2" style="height:37px; color:#365EBF; text-decoration:underline;"><strong>Login Information</strong></td>
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
                                        <img src='<%=ClassifiedImagePath%>' onerror="javascript:this.src='../Classifieds_ProductImage/index.jpg';"
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
    Upload New Picture<br />
    
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
                    <span class="gray11px" style="color:Coral">
                        Image size must be less then 200 KB. Choose any format except .bmp.&nbsp;<br />
                        Preferred width height ratio 200 by 300 px.
                        <br />
                        <uc4:ImageResizeLink_Ctrl ID="ImageResizeLink_Ctrl1" runat="server" />
                    </span>
    </td>
    </tr>
    <tr>
    <td>
    </td>
    <td>
    </td>
    </tr>
    <tr>
    <td align="right" style="width: 136px">Email:<span class="mandatory">*</span></td>
    <td align="left">
    <asp:TextBox 
        ID="txtEmail1" 
        runat="server" 
        CssClass="textbox" 
        MaxLength="100" 
        Width="200px">
    </asp:TextBox>
    &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:RequiredFieldValidator 
        ID="rfvEmail1" 
        runat="server" 
        ControlToValidate="txtEmail1"
        ErrorMessage="Email address field is blank! Please type your Email address properly."
        Font-Bold="True" 
        SetFocusOnError="True">?</asp:RequiredFieldValidator>
    &nbsp;
    <asp:RegularExpressionValidator 
        ID="revEmail1" 
        runat="server" 
        ControlToValidate="txtEmail1"
        ErrorMessage="Invalid Email address! Please type your valid Email address." 
        Font-Bold="True"
        SetFocusOnError="True" 
        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">?</asp:RegularExpressionValidator>
    &nbsp;&nbsp;
    <span class="gray11px">(this will be your Login ID.)</span>
    </td>
    </tr>
    
    <tr>
    <td align="right"style="width: 136px">Re-enter Email:<span class="mandatory">*</span></td>
    <td align="left">
    <asp:TextBox 
        ID="txtEmail2" 
        runat="server" 
        CssClass="textbox" 
        MaxLength="100" 
        Width="200px">
    </asp:TextBox>
    &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:RequiredFieldValidator 
        ID="rfvEmail2" 
        runat="server" 
        ControlToValidate="txtEmail2"
        ErrorMessage="Email confirmation field is blank! Please re-type your Email address properly."
        Font-Bold="True" 
        SetFocusOnError="True">?</asp:RequiredFieldValidator>
    &nbsp;      
    <asp:RegularExpressionValidator 
        ID="revEmail2" 
        runat="server" 
        ControlToValidate="txtEmail2"
        ErrorMessage="You re-type an invalid Email address! Please type your valid Email address."
        Font-Bold="True" 
        SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">?</asp:RegularExpressionValidator>
    <br />    
    <asp:CompareValidator 
        ID="cmvEmail" 
        runat="server" 
        ControlToCompare="txtEmail1" 
        ControlToValidate="txtEmail2"
        ErrorMessage="Your re-typed Email address does not match!  Please type the same Email address in both fields."
        SetFocusOnError="True" Font-Size="10px"></asp:CompareValidator>
    </td>
    </tr>
    
    <tr>
    <td style="width: 136px">&nbsp;</td>
    <td align="left"><a href="UserProfile_ChangeLoginInfo.aspx">Change Login Password</a></td>
    </tr>                
    <!--END: LOGIN INFORMATION-->
    
    <!--BEGIN: USER DETAILS-->
    <tr>
    <td align="left" colspan="2" style="color:#365EBF; text-decoration:underline;"><strong>User Details</strong></td>
    </tr>
    
    <tr>
    <td align="right" style="height: 25px; width: 136px;">Name:<span class="mandatory">*</span></td>
    <td align="left" style="height: 25px">
    <asp:TextBox 
        ID="txtName" 
        runat="server" 
        CssClass="textbox" 
        MaxLength="200"
        Width="300px">
    </asp:TextBox>
    &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:RequiredFieldValidator 
        ID="rfvName" 
        runat="server" 
        ControlToValidate="txtName"
        ErrorMessage="Name field is blank ! Please type your name properly." 
        Font-Bold="True"
        SetFocusOnError="True">?</asp:RequiredFieldValidator>
    </td>
    </tr>
   <%-- <tr>
    <td align="right" style="width: 136px">  
    Profile Image
    </td>
    <td align="left">
    <img src='<%=ClassifiedImagePath%>' onerror="javascript:this.src='../Classifieds_ProductImage/default.png';"style="height: 110px; width: 110px; border: none;" />
    </td>
    </tr>--%>
    
    <tr>
    <td align="right" valign="middle" style="height: 27px; width: 136px;">Contact Address:</td>
    <td align="left" style="height: 27px">
    <asp:TextBox 
        ID="txtAddress" 
        runat="server" 
        CssClass="textbox" 
        Height="100px"
        TextMode="MultiLine" 
        Width="334px" 
        MaxLength="300"></asp:TextBox>
    </td>
    </tr>

    <tr>
    <td align="right" style="width: 136px">Mobile:<span class="mandatory">*</span></td>
    <td align="left">
    <asp:TextBox 
        ID="txtCellPhoe" 
        runat="server" 
        CssClass="textbox" 
        MaxLength="20" 
        Width="200px">
    </asp:TextBox>
    &nbsp;&nbsp;&nbsp;&nbsp;    
    <asp:RequiredFieldValidator 
        ID="rfvMobile" 
        runat="server" 
        ControlToValidate="txtCellPhoe"
        ErrorMessage="Mobile number field is blank ! Please type your Mobile number properly."
        Font-Bold="True" SetFocusOnError="True">?</asp:RequiredFieldValidator>            
    </td>
    </tr>
    
    <tr>
    <td align="right" style="height: 25px; width: 136px;" valign="top"></td>
    <td align="left" style="height: 25px;">
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
<TABLE style="WIDTH: 110%" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="WIDTH: 10%; BORDER-BOTTOM: 0px"></TD><TD style="WIDTH: 90%; BORDER-BOTTOM: 0px"><asp:DropDownList id="ddlCountry" runat="server" Width="226px" AutoPostBack="True" AppendDataBoundItems="True" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged" Visible="False"><asp:ListItem Text="Select" Value="-1"></asp:ListItem>
</asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </TD></TR><TR><TD style="WIDTH: 10%; BORDER-BOTTOM: 0px"></TD><TD style="WIDTH: 90%; BORDER-BOTTOM: 0px"><asp:DropDownList id="ddlState" runat="server" Width="226px" AutoPostBack="True" AppendDataBoundItems="True" OnSelectedIndexChanged="ddlState_SelectedIndexChanged" Visible="False"><asp:ListItem Text="Select" Value="-1"></asp:ListItem>
</asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </TD></TR><TR><TD style="WIDTH: 10%; BORDER-BOTTOM: 0px"></TD><TD style="WIDTH: 90%; BORDER-BOTTOM: 0px"><asp:DropDownList id="ddlProvince" runat="server" Width="226px" AppendDataBoundItems="True" Visible="False"><asp:ListItem Text="Select" Value="-1"></asp:ListItem>
</asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </TD></TR></TBODY></TABLE>
</ContentTemplate>
    </asp:UpdatePanel>
    </td>
    </tr>    
</table>
<br />
<span style="font-size:11px; padding-left:150px;">Our <a href="../Document/ApnerDeal_Terms_Of_Use_&_Privacy_Policy.pdf" style="text-decoration:underline;">Terms of Use</a> and <a href="../Document/ApnerDeal_Terms_Of_Use_&_Privacy_Policy.pdf" style="text-decoration:underline;">Privacy Policy</a>.</span>

<br /><br />

<div style="padding-left:190px;">
<asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="image_btn" OnClick="btnSubmit_Click"/>
</div>
<br />
</asp:Content>

