<%@ Page Language="C#" MasterPageFile="~/Corporate/MPCorporate1.master" AutoEventWireup="true" CodeFile="UserProfile_Step01.aspx.cs" Inherits="Corporate_UserProfile_Step01" Title="ApnerDeal.com:User Registration." %>
<%@ Register Src="../UserControl/ImageResizeLink_Ctrl.ascx" TagName="ImageResizeLink_Ctrl"
    TagPrefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="1040px" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
        <td valign="top" style="padding-left:10px; padding-top:10px; padding-right:10px;">
        <div align="left" class="top_secondary_link"><center><span style="font-size: 20px; color: #898989; font-family: verdana">Free User Registration</span></center></div>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
             <tr>
             <td>&nbsp;</td>
             <td align="right">Fields marked by <span class="mandatory">*</span> are mandatory</td>
             </tr>

             <tr>
             <td>&nbsp;</td>
             <td height="20" align="right" valign="bottom"><div  class="step">Step 1 of 2</div></td>
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
        <table width="100%" border="0" cellspacing="0" cellpadding="10px" class="cptable" style="border-top:1px solid #EFEFE2;" id="TABLE1">
            <tr>
            <td colspan="2" style="height:37px; color:#365EBF; text-decoration:underline;"><strong>Login Information </strong></td>
            </tr>
            <tr>
            <td style="width: 203px">
            </td>
            <td>
             <img src='../<%=ImagePath%>' alt="" onerror="javascript:this.src='../Classifieds_ProductImage/index.jpg';"style="height: 110px; width: 110px; border:none;" />
             <asp:Label ID="lblImageUploadMessage" runat="server" Font-Size="12px" Font-Bold="True"
                        ForeColor="Red" Width="167px"></asp:Label>
            </td>
            </tr>  
            <tr>
                <td align="right" style="width: 203px">
                    Upload Company Logo:
                </td>
                <td style="width: 569px">
                     <asp:FileUpload ID="FileUpload1" runat="server" BorderStyle="Groove" />
                    <asp:Button ID="btnUpload" runat="server" CausesValidation="False" OnClick="btnUpload_Click"
                        Text="Upload" Font-Bold="True" Font-Underline="False" />
                       <br />
                    <span class="gray25px" style="color: Coral"><strong><span style="color: red"><span
                        style="text-decoration: underline">Important: </span>Please Click on 'Upload'
                        button then click below 'Register' button. Other wise image will not save or update.</span></strong><br />
                        <br />
                        Image size must be less then 200 KB. Choose any format except .bmp.&nbsp;
                        Preferred width 200 px. and height 300 px. To resize your image before upload please click
                        on the below <strong>'Resize Picture'</strong> link.<br />
                        
                        <br />
                        <uc4:ImageResizeLink_Ctrl ID="ImageResizeLink_Ctrl1" runat="server" />
                    </span>
                </td>
            </tr>    
            <tr>
            <td align="right" style="height: 25px; width: 203px;">Email:<span class="mandatory">*</span></td>
            <td style="height: 25px; width: 569px;">
            <asp:TextBox 
                ID="txtEmail1" 
                runat="server" 
                Width="180px" 
                Height="15px"                        
                MaxLength="100" 
                CssClass="textbox">
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
                SetFocusOnError="True"
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                Font-Bold="True">?</asp:RegularExpressionValidator>       
            &nbsp;&nbsp;            
            <span class="gray11px">(this will be your Login ID.)</span>        
            </td>
            </tr>
        
            <tr>
            <td align="right" style="width: 203px">Re-enter Email:<span class="mandatory">*</span></td>
            <td style="width: 569px">
            <asp:TextBox 
                ID="txtEmail2" 
                runat="server"             
                Width="180px" 
                Height="15px" 
                MaxLength="100" 
                CssClass="textbox">
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
                SetFocusOnError="true"
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                Font-Bold="True">?</asp:RegularExpressionValidator>
            <br />
            <asp:CompareValidator 
                ID="cmvEmail" 
                runat="server" 
                ControlToCompare="txtEmail1"
                ControlToValidate="txtEmail2" 
                ErrorMessage="Your re-typed Email address does not match!  Please type the same Email address in both fields." 
                SetFocusOnError="True" 
                Font-Size="10px">
            </asp:CompareValidator>        
            </td>
            </tr>
        
            <tr>
            <td align="right" style="height: 25px; width: 203px;">
            Create a ApnerDeal Password:<span class="mandatory">*</span></td>
            <td style="height: 25px; width: 569px;">
            <asp:TextBox 
                ID="txtPassword1"
                runat="server"
                Width="180px" 
                Height="15px"
                MaxLength="15"
                TextMode="Password" 
                CssClass="textbox">
            </asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;        
            <asp:RequiredFieldValidator
                ID="rfvPassword1" 
                runat="server"
                ControlToValidate="txtPassword1"            
                ErrorMessage="Password field is blank! Please type your Password properly." 
                SetFocusOnError="true" 
                Font-Bold="True">?</asp:RequiredFieldValidator>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <span class="gray11px">(5 to 15 characters long.)</span>
            <br />
            <asp:RegularExpressionValidator 
                ID="revPassword1" 
                runat="server"
                ControlToValidate="txtPassword1" 
                ErrorMessage="Your password length is incorrect ! It should be minimum 5 to maximum 15 characters long."
                Font-Size="10px" 
                ValidationExpression="^.{5,15}$" 
                SetFocusOnError="True">
            </asp:RegularExpressionValidator>        
            </td>
            </tr>
        
            <tr>
            <td align="right" style="width: 203px; height: 25px">Confirm ApnerDeal Password:<span class="mandatory">*</span></td>
            <td style="width: 569px; height: 25px">
            <asp:TextBox 
                ID="txtPassword2" 
                runat="server" 
                Width="180px" 
                Height="15px" 
                MaxLength="15" 
                TextMode="Password" 
                CssClass="textbox">
            </asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:RequiredFieldValidator
                ID="rfvPassword2" 
                runat="server"
                ControlToValidate="txtPassword2"            
                ErrorMessage="Password confirmation field is blank! Please re-type your Password properly." 
                SetFocusOnError="true" 
                Font-Bold="True">?</asp:RequiredFieldValidator>
            <br />    
            <asp:CompareValidator 
                ID="cmvPassword" 
                runat="server" 
                ControlToCompare="txtPassword1"
                ControlToValidate="txtPassword2"             
                ErrorMessage="Your re-typed password does not match!  Please type the same Password in both fields."
                SetFocusOnError="True" 
                Font-Size="10px">
            </asp:CompareValidator>        
            </td>
            </tr>
            
            <tr>
            <td colspan="2" style="height:37px; color:#365EBF; text-decoration:underline;"><strong>Basic Information</strong></td>
            </tr>

            <tr>
            <td align="right" style="height:9px; width: 203px;">Company Name:<span class="mandatory">*</span></td>
            <td style="height:9px; width: 569px;">
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
            <td align="right" style="height: 25px; width: 203px;">Business Type:<span class="mandatory">*</span></td>
            <td style="height: 25px; width: 569px;">
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
            <td align="right" style="width: 203px">Contact/Business Address:<span class="mandatory">*</span></td>
            <td style="width: 569px">
            <asp:TextBox 
                ID="txtAddress" 
                runat="server"             
                Width="345px" 
                Height="60px" 
                TextMode="MultiLine" 
                MaxLength="300" 
                CssClass="textbox">
            </asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:RequiredFieldValidator 
                ID="rfvAddress" 
                runat="server" 
                ErrorMessage="Business Address field is blank! Please type your Business Address properly." 
                ControlToValidate="txtAddress" 
                Font-Bold="True">?</asp:RequiredFieldValidator>        
            </td>
            </tr>
            
            <tr>
            <td align="right" style="width: 203px">Contact Phone:<span class="mandatory">*</span></td>
            <td style="width: 569px">
            <asp:TextBox 
                ID="txtPhone" 
                runat="server"             
                Width="180px" 
                Height="15px" 
                MaxLength="50"
                CssClass="textbox">
            </asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:RequiredFieldValidator 
                ID="rfvPhone" 
                runat="server" 
                ControlToValidate="txtPhone"
                ErrorMessage="Phone number field is blank! Please type Phone number properly."
                SetFocusOnError="True" 
                Font-Bold="True">?</asp:RequiredFieldValidator>        
            </td>
            </tr>                        

            <tr>
            <td align="right" style="height: 25px; width: 203px;">Web Site Address (URL):</td>
            <td style="height: 25px; width: 569px;">
            <asp:TextBox 
                ID="txtURL" 
                runat="server"             
                Width="300px" 
                Height="15px" 
                MaxLength="100"
                CssClass="textbox">
            </asp:TextBox>        
            </td>
            </tr>                        
        
            <tr>
            <td align="right" style="width: 203px">Billing Person:<span class="mandatory">*</span></td>
            <td style="width: 569px">
            <asp:TextBox 
                ID="txtBillingContact" 
                runat="server"             
                Width="345px" 
                Height="15px" 
                MaxLength="200" 
                CssClass="textbox">
            </asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:RequiredFieldValidator 
                ID="rfvBillingPerson" 
                runat="server" 
                ControlToValidate="txtBillingContact"
                ErrorMessage="Billing Person field is blank! Please type Billing Person’s name properly." 
                SetFocusOnError="true" 
                Font-Bold="True">?</asp:RequiredFieldValidator>        
            </td>
            </tr>                        

            <tr>
            <td align="right" style="width: 203px">Inventory Manager:</td>
            <td style="width: 569px">
            <asp:TextBox 
                ID="txtInventoryManager" 
                runat="server" 
                Width="345px" 
                Height="15px" 
                MaxLength="200" 
                CssClass="textbox">
            </asp:TextBox>
            </td>
            </tr>                        
        
            <tr>
            <td align="right" style="width: 203px">Company Profile:</td>
            <td style="width: 569px">
            <asp:TextBox 
                ID="txtProfile" 
                runat="server"             
                Width="345px" 
                Height="150px" 
                TextMode="MultiLine" 
                MaxLength="400" 
                CssClass="textbox">
            </asp:TextBox>        
            </td>
            </tr>

        
        </table>
        <br />
        
         <!-- Start Add PDF  File Terms of Use,Privacy Policy Link Sabbir Ahmed 28-03-20210 -->
        <span style="font-size:11px; padding-left:80px;">By clicking on "Register" below, you are agreeing to our <a href="../Document/ApnerDeal_Terms_Of_Use_&_Privacy_Policy.pdf" style="text-decoration:underline;">Terms of Use</a> and <a href="../Document/ApnerDeal_Terms_Of_Use_&_Privacy_Policy.pdf" style="text-decoration:underline;">Privacy Policy</a>.</span>
        <!-- End Add PDF File Terms of Use,Privacy Policy Link Sabbir Ahmed 28-03-20210 -->
        
        <div style="padding-left:250px;">
        <br /><br />    
        <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="image_btn" OnClick="btnRegister_Click" />
        </div>
        <br />
        </td>
        </tr>
    </table>
</asp:Content>

