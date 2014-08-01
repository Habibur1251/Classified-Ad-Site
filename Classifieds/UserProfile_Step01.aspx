<%@ Page Language="C#" MasterPageFile="~/Classifieds/MPClassifieds1.master" AutoEventWireup="true" CodeFile="UserProfile_Step01.aspx.cs" Inherits="Classifieds_UserProfile_Step01" Title="www.apnerdeal.com – New User Registration." %>
<%@ Register Src="../UserControl/ImageResizeLink_Ctrl.ascx" TagName="ImageResizeLink_Ctrl"
    TagPrefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table width="1000" border="0px" align="center" cellpadding="0px" cellspacing="0px" style="height:auto">
    <tr>
    <td valign="top" style="padding-left:10px;padding-top:10px;padding-right:10px">
    <div align="right" class="top_secondary_link">&nbsp;</div>
    <span class="pageTitle">Classifieds – New User Registration.</span><br />
    <span class="gray11px" style="font-weight:normal; margin-top:7px;">ApnerDeal.com is absolutely <strong style="color:#EC2024;">FREE</strong> for posting classified Ads. It will not cost you anything.</span>
    <br />
    <br />
    <table width="100%" border="0px" cellspacing="0px" cellpadding="0px">
         <tr>
         <td>&nbsp;</td>
         <td align="right">Fields marked by <span class="mandatory">*</span> are mandatory</td>
         </tr>
         <tr>
         <td>&nbsp;</td>
         <td height="20px" align="right" valign="bottom"><div  class="step">Step 1 of 3</div></td>
         </tr>
         
         <tr>
         <td colspan="2">         
         <asp:ValidationSummary 
            runat="server" 
            ID="ValidationSummary1"
            Width="500px" 
            BackColor="#FFFFFF" 
            ForeColor="Black" 
            Font-Bold="False" 
            HeaderText="<table><tr><td style='padding-left:10px; padding-top:7px;'><img src='../images/icon_error.gif' width='42' height='40' alt='' /></td><td valign='middle' style='font-weight:bold; text-decoration:underline;color:#ED0000;'>Following error occured :</td></tr></table>" 
            BorderStyle="Dashed" 
            BorderWidth="1px" Font-Size="11px">
         </asp:ValidationSummary>
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
        <td colspan="2" style="height:37px; color:#365EBF; text-decoration:underline;"><strong>Login Information</strong></td>
        </tr>
        <tr>
        <td>
        </td>
        <td>
         <img src='<%=ImagePath%>' onerror="javascript:this.src='../Classifieds_ProductImage/index.jpg';"style="height: 100px; width: 100px; border: none;" /> 
         <asp:Label 
                    ID="lblImageUploadMessage" 
                    runat="server" 
                    Font-Size="12px"
                    Font-Bold="true"
                    ForeColor="Red" 
                    Width="250px"></asp:Label>
        </td>
        </tr>
        <tr>
        <td style="height: 25px; width: 218px;">Upload Profile Picture:</td>
        <td>   
        <asp:FileUpload 
                    ID="FileUpload1" 
                    runat="server" 
                    BorderStyle="Groove" />
                <asp:Button
                    ID="btnUpload" 
                    runat="server" 
                    CausesValidation="False" 
                    OnClick="btnUpload_Click"
                    Text="Upload" Font-Bold="True" Font-Underline="False" /><br />
                    <span class="gray11px" style="color:Coral">
                        Image size must be less then 200 KB. Choose any format except .bmp.Preferred width height ratio 200 by 300 px.
                        <br />
                        <uc4:ImageResizeLink_Ctrl ID="ImageResizeLink_Ctrl1" runat="server" />
                    </span>
        </td>
    </tr>

        <tr>
        <td style="width: 218px; height: 31px;">Email:<span class="mandatory">*</span></td>
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
        <span class="gray11px">(This will be your Login ID.)</span>
        </td>
        </tr>
        <tr>
        <td style="width: 218px">Re-enter Email:<span class="mandatory">*</span></td>
        <td>
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
            SetFocusOnError="True" 
            Font-Size="10px">
        </asp:CompareValidator>
        </td>
        </tr>
        
        <tr>
        <td style="width: 218px">Create a ApnerDeal Password:<span class="mandatory">*</span></td>
        <td>
        <asp:TextBox 
            ID="txtPassword1" 
            runat="server" 
            CssClass="textbox" 
            MaxLength="15" 
            Width="200px" 
            TextMode="Password">
        </asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:RequiredFieldValidator 
            ID="rfvPassword1" 
            runat="server"
            ErrorMessage="Password field is blank! Please type your Password properly." 
            ControlToValidate="txtPassword1" 
            Font-Bold="True" 
            SetFocusOnError="True">?</asp:RequiredFieldValidator>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <span class="gray11px">(5 to 15 characters long.)</span>                    
        <br />
        <asp:RegularExpressionValidator 
            ID="revPassword1" runat="server"
            ControlToValidate="txtPassword1" 
            ErrorMessage="Your password length is incorrect ! It should be minimum 5 to maximum 15 characters long."
            Font-Size="10px" 
            ValidationExpression="^.{5,15}$" 
            SetFocusOnError="True">
        </asp:RegularExpressionValidator>
        </td>
        </tr>
        
        <tr>
        <td style="height: 25px; width: 218px;">Confirm ApnerDeal Password:<span class="mandatory">*</span></td>
        <td style="height: 25px">
        <asp:TextBox 
            ID="txtPassword2" 
            runat="server" 
            CssClass="textbox" 
            MaxLength="15" 
            Width="200px" 
            TextMode="Password">
        </asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:RequiredFieldValidator 
            ID="rfvPassword2" 
            runat="server" 
            ErrorMessage="Password confirmation field is blank! Please re-type your Password properly." 
            ControlToValidate="txtPassword2" 
            Font-Bold="True" 
            SetFocusOnError="True">?</asp:RequiredFieldValidator>
        <br />    
        <asp:CompareValidator 
            ID="cmvPassword" 
            runat="server" 
            ErrorMessage="Your re-typed password does not match!  Please type the same Password in both fields." 
            ControlToCompare="txtPassword1" 
            ControlToValidate="txtPassword2" 
            Font-Size="10px" 
            SetFocusOnError="True"></asp:CompareValidator>      
        </td>        
        </tr>
        <!--END: LOGIN INFORMATION-->
        
        <!--BEGIN: USER DETAILS-->
        <tr>
        <td colspan="2" style="color:#365EBF; text-decoration:underline;"><strong>User Details</strong></td>
        </tr>
        
        <tr>
        <td style="height: 25px; width: 218px;">Name:<span class="mandatory">*</span></td>
        <td style="height: 25px">
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
        <tr>
        <td valign="middle" style="height: 27px; width: 218px;">Contact Address:</td>
        <td style="height: 27px">
        <asp:TextBox 
            ID="txtAddress" 
            runat="server" 
            CssClass="textbox" 
            Height="100px"
            TextMode="MultiLine" 
            Width="300px" 
            MaxLength="300"></asp:TextBox>
        </td>
        </tr>

        <tr>
        <td style="width: 218px">Mobile:<span class="mandatory">*</span></td>
        <td>
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
        <td style="height: 25px; width: 218px;" valign="top">Location:<span class="mandatory">*</span></td>
        <td style="height: 25px; width:auto">    
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
<TABLE style="WIDTH: 103%" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="WIDTH: 10%; BORDER-BOTTOM: 0px; HEIGHT: 25px">Country</TD><TD style="WIDTH: 90%; BORDER-BOTTOM: 0px; HEIGHT: 25px"><asp:DropDownList id="ddlCountry" runat="server" Width="226px" AutoPostBack="True" AppendDataBoundItems="True" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged">
                                <asp:ListItem Value="-1" Text="Select"></asp:ListItem>
                            </asp:DropDownList>&nbsp;<asp:RequiredFieldValidator id="rfvCountry" runat="server" Font-Bold="True" SetFocusOnError="True" ErrorMessage="Country field is not selected ! Please select your Country properly." ControlToValidate="ddlCountry" InitialValue="-1">?</asp:RequiredFieldValidator> </TD></TR><TR><TD style="WIDTH: 10%; BORDER-BOTTOM: 0px">Division</TD><TD style="WIDTH: 90%; BORDER-BOTTOM: 0px"><asp:DropDownList id="ddlState" runat="server" Width="226px" AutoPostBack="True" AppendDataBoundItems="True" OnSelectedIndexChanged="ddlState_SelectedIndexChanged">
                                <asp:ListItem Value="-1" Text="Select"></asp:ListItem>
                            </asp:DropDownList>&nbsp;<asp:RequiredFieldValidator id="rfvState" runat="server" Text="?" Font-Bold="true" SetFocusOnError="true" ErrorMessage="State field is not selected ! Please select your state properly." ControlToValidate="ddlState" InitialValue="-1"></asp:RequiredFieldValidator> </TD></TR><TR><TD style="WIDTH: 10%; BORDER-BOTTOM: 0px; HEIGHT: 25px">District</TD><TD style="WIDTH: 90%; BORDER-BOTTOM: 0px; HEIGHT: 25px"><asp:DropDownList id="ddlProvince" runat="server" Width="226px" AppendDataBoundItems="True">
                                <asp:ListItem Text="Select" Value="-1"></asp:ListItem>
                            </asp:DropDownList> <asp:RequiredFieldValidator id="rfvProvince" runat="server" Text="?" Font-Bold="true" SetFocusOnError="true" ErrorMessage="Province field is not selected ! Please select your province properly." ControlToValidate="ddlProvince" InitialValue="-1"></asp:RequiredFieldValidator> </TD></TR></TBODY></TABLE>
</ContentTemplate>
        </asp:UpdatePanel> &nbsp;
        
        </td>
        </tr>       
        <tr>
            <td style="height: 25px; width:218px;" valign="top">
                                            How did you know about ApnerDeal.com?:<span class="mandatory">*</span>
            </td>
            <td style="height: 25px">
            <asp:UpdatePanel ID="Updatepanel"  runat="server">
            <ContentTemplate>
<asp:DropDownList id="ddlSource" runat="server" Width="233px" AutoPostBack="True" OnSelectedIndexChanged="ddlSource_SelectedIndexChanged"><asp:ListItem>Friend</asp:ListItem>
<asp:ListItem>News Paper</asp:ListItem>
<asp:ListItem>Billboard</asp:ListItem>
<asp:ListItem>Email Campaign</asp:ListItem>
<asp:ListItem>Search Engine</asp:ListItem>
<asp:ListItem>Facebook</asp:ListItem>
<asp:ListItem>Others</asp:ListItem>
</asp:DropDownList> <BR /><asp:Panel id="pnlRefaralName" runat="server" Width="100%">
                    <asp:TextBox ID="txtReferalName" runat="server" MaxLength="50" CssClass="textbox"
                        Height="19px" Width="150px"></asp:TextBox> <span class="price"><asp:Label ID="lblSource" runat="server"></asp:Label></span>
                    <asp:RequiredFieldValidator ID="rfvReferalName" runat="server" ControlToValidate="txtReferalName"
                        Display="Dynamic" ErrorMessage="Please provide source name.">?</asp:RequiredFieldValidator>
                     <asp:RegularExpressionValidator 
                        ID="revFrndEmail" 
                        runat="server" 
                        ControlToValidate="txtReferalName"
                        ErrorMessage="You typed an invalid Email address! Please type valid Email address."
                        Font-Bold="True" 
                        SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic">?</asp:RegularExpressionValidator>
                    
                </asp:Panel> 
</ContentTemplate>
            </asp:UpdatePanel>
            </td>
        </tr>
         
    </table> 
    <!-- Start Add PDF File Terms of Use,Privacy Policy Link -->
    <span style="font-size:11px; padding-left:100px;">By clicking on "Register" below, you are agreeing to our <a href="../Document/ApnerDeal_Terms_Of_Use_&_Privacy_Policy.pdf" style="text-decoration:underline;">Terms of Use</a> and <a href="../Document/ApnerDeal_Terms_Of_Use_&_Privacy_Policy.pdf" style="text-decoration:underline;">Privacy Policy</a>.</span>    
    <!-- End Add PDF File Terms of Use,Privacy Policy Link  -->
    <div style="padding-left:280px;">
    <br /><br />      
    <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="image_btn" OnClick="btnRegister_Click" />
        <br />
    </div>
    </td>
    </tr>                
</table>
</asp:Content>

