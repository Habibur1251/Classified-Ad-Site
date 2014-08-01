<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReportDiscount.aspx.cs" Inherits="ReportDiscount" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>ApnerDeal.com</title>
    <link href="CSS/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    
    
    <div align="center">
        <table width="600px" border="0" style="margin-top: 20px" align="center" cellpadding="0"
            cellspacing="0">
            <tr>
                <td>
                    <img src="images/apnerdeal_logo.png" width="260" height="91" alt="" />
                </td>
            </tr>
            <tr>
            <td>
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
    <asp:MultiView ID="multiview" runat="server" ActiveViewIndex="0" >
    <asp:View ID="View1" runat="server">
   
    <table width="600px" border="0" style="margin-top: 20px" align="center" cellpadding="0"cellspacing="0">
            <tr>
                <td colspan="3" style="background-color: #3B5998; font-weight: bold; color: White;
                    height: 25px; font-size: 14px">
                    Welcome to ApnerDeal reporting service
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <p style="word-break: normal; word-wrap: normal; padding: 5px" class="gray11px">
                        Welcome to repoting service of ApnerDeal.com. You can reprt about
                        a discount using this service.ApnerDeal.com will be notified about the
                        discount.To use this service you are required to provide the
                        following information:
                    </p>
                </td>
            </tr>
        </table>
        <table border="0" style="margin-top: 20px; width: 600px;" align="center" cellpadding="0"
            cellspacing="0">
            <tr>
                <td width="3px">
                    <img src="../images/title_bar_left.gif" alt="" width="3" height="28" /></td>
                <td width="600px" style="font-size: 14px; font-weight: bold; background-image: url(../images/title_bar_bg.gif);
                    background-repeat: repeat-x; padding-left: 5px;">
                    Report this discount to a ApnerDeal.com.
                </td>
                <td width="3px">
                    <img src="../images/title_bar_right.gif" alt="" width="3" height="28" /></td>
            </tr>
        </table>
        <br />
        <div  style="width:580px; vertical-align:top;background-color:#FFFFFF; padding:1px;border-top:solid 1px #FFAA0D; border-bottom:solid 1px #FFAA0D; border-left:solid 1px #FFAA0D;border-right:solid 1px #FFAA0D ">
        <table align="center" class="cptable" border="0" style="margin-top: 20px; border-top: 1px solid rgb(213, 213, 213); width: 575px;"
   cellpadding="0" cellspacing="0">
            <tr>
                <td align="right" style="width: 130px; height: 25px">
                    Your Email Address:<span class="mandatory"></span></td>
                <td align="left" style="height: 25px">
                    <asp:TextBox ID="txtEmailAddress" runat="server" CssClass="textbox" MaxLength="100"
                        Width="206px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvEmailAddress" runat="server" ControlToValidate="txtEmailAddress"
                        ErrorMessage="Please type your Email Address.">?</asp:RequiredFieldValidator>
               </td>         
            </tr>
            <tr>
                <td align="right" style="width: 130px; height: 25px">
                    Name:<span class="mandatory"></span></td>
                <td align="left" style="height: 25px">
                    <asp:TextBox ID="txtName" runat="server" CssClass="textbox" MaxLength="100"
                        Width="206px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName"
                        ErrorMessage="Please type your Name.">?</asp:RequiredFieldValidator>
               </td>         
            </tr>
             <tr>
                <td align="right" style="width: 130px; height: 25px">
                    Subject:<span class="mandatory"></span></td>
                <td align="left" style="height: 25px">
                    <asp:TextBox ID="txtSubject" runat="server" CssClass="textbox" MaxLength="100"
                        Width="208px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="subjectRequiredFieldValidator" runat="server" ControlToValidate="txtSubject"
                        ErrorMessage="Please type your report subject.">?</asp:RequiredFieldValidator>
              </td>          
            </tr>
            <tr>
                <td align="right" valign="top" style="width: 130px; height: 25px">
                    Report:<span class="mandatory"></span></td>
                <td align="left" style="height: 25px">
                    <asp:TextBox ID="txtReport" runat="server" CssClass="textbox"  MaxLength="4000"
                        Width="262px" Height="101px" TextMode="MultiLine"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvSenderName" runat="server" ControlToValidate="txtReport"
                        ErrorMessage="Please enter your report.">?</asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="csvReq" runat="server" ErrorMessage="CustomValidator" OnServerValidate="csvReq_ServerValidate"></asp:CustomValidator>
                    
                </td>    
            </tr>
            <tr>
                <td align="left" style="width: 130px; height: 25px">
                    &nbsp;
                 </td>   
                <td style="height: 25px">
                    <asp:Button 
                        ID="btnSendEmail" 
                        runat="Server" 
                        Text="Submit" 
                        CssClass="image_btn"
                        BorderStyle="Groove" 
                        OnClick="btnAdd_Click" />
              </td>
            </tr>
        </table>
        </div>
        <table width="400px" border="0" style="margin-top: 20px" align="center" cellpadding="0"
            cellspacing="0">
            <tr>
                <td>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                        ShowSummary="False" />
                </td>
            </tr>
            
        </table>
    </asp:View>
    
    
    <asp:View ID="View2" runat="server">
    <table width="600" border="0" style="margin-top: 20px" align="center" cellpadding="0"cellspacing="0">
            <tr>
                <td colspan="3" style="background-color: #3B5998; font-weight: bold; color: White;
                    height: 25px; font-size: 14px; width: 600px;">
                    ApnerDeal.com report a discount service
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <span style="text-align:center;" class="gray11px">
                        Your report has been added.<br />
                        Thank you for using our service.            
                    </span>
                </td>
            </tr>
            <tr>
            <td colspan="2" style="text-align:center;padding-top:30px; ">
                <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
                <a href="#" style="vertical-align:middle;font-weight:bold; text-decoration:underline;" onclick="self.close();">Close this window</a>
            </td>
            </tr>
        </table>
    </asp:View>
    
    <asp:View ID="View3" runat="server">
      <table width="600" border="0" style="margin-top: 20px" align="center" cellpadding="0"cellspacing="0">
            <tr>
                <td colspan="3" style="background-color: #3B5998; font-weight: bold; color: White;
                    height: 25px; font-size: 14px">
                    ApnerDeal.com reporting  service
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <p style="word-break: normal; word-wrap: normal; padding: 5px" class="gray11px">
                        There has been some problem add your reports. Please try after some time.
                    </p>
                </td>
            </tr>
             <tr>
                <td colspan="2" style="height: 8px; padding-top:50px">
                    <asp:Button 
                        ID="btnPrev" 
                        runat="server"  
                        BorderStyle="Groove" 
                        OnClick="btnPrev_Click" 
                        CssClass="image_btn_left"
                        Text="Try Again" />
                </td>
            </tr>
        </table>
    
    </asp:View>
    </asp:MultiView>
    </div>
    
    
    </form>
</body>
</html>
