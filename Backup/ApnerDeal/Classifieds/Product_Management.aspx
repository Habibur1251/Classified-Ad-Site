<%@ Page Language="C#" MasterPageFile="~/Classifieds/MPClassifieds2.master" AutoEventWireup="true"
    CodeFile="Product_Management.aspx.cs" Inherits="Classifieds_Product_Management"
    Title="www.apnerdeal.com – Classified User Product Management." %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript">
 <!-- Script courtesy of 
    function load() {
    var load = window.open('../HowToSellProduct.aspx','','scrollbars=no,menubar=no,height=500,width=600,resizable=no,toolbar=no,location=no,status=no,top=100,left=300');
    }
    // -->
    </script>
  
 
 <asp:UpdatePanel ID="updatePanel" runat="server">
   <ContentTemplate>
<DIV style="PADDING-RIGHT: 0px; PADDING-LEFT: 0px; PADDING-BOTTOM: 0px; MARGIN: 0px; WIDTH: 815px; PADDING-TOP: 0px"><TABLE style="BORDER-TOP: #efefe2 1px solid; COLOR: #000000" class="cptable" cellSpacing=0 cellPadding=0 width="100%" border=0><TBODY><TR><TD style="FONT-SIZE: 11px" align=left colSpan=2><asp:ValidationSummary id="ValidationSummary1" runat="server" Width="500px" ValidationGroup="Title" Font-Size="11px" BorderWidth="1px" BorderStyle="Dashed" HeaderText="<table><tr><td style='padding-left:10px; padding-top:7px;'><img src='../images/icon_error.gif' width='42' height='40' alt='' /></td><td valign='middle' style='font-weight:bold; text-decoration:underline;color:#ED0000;'>Following error occured :</td></tr></table>" Font-Bold="False" ForeColor="Black" BackColor="#FFFFFF"></asp:ValidationSummary> <asp:Label id="lblSystemMessage" runat="server" Width="500px" Font-Size="11px" ForeColor="Red" EnableViewState="False">
                        </asp:Label> </TD></TR><TR><TD colSpan=2><SPAN class="pageTitle">List Single Items for Sale </SPAN></TD></TR><TR><TD vAlign=middle><A style="FONT-WEIGHT: bold; VERTICAL-ALIGN: middle; TEXT-DECORATION: underline" href="javascript:load()">How to sell product? <IMG alt="" src="../Images/question.jpg" border=0 /> </A></TD><TD align=right>Fields marked by <SPAN class="mandatory">*</SPAN> are mandatory </TD></TR><TR><TD style="WIDTH: 200px; HEIGHT: 25px" align=right>SKU (Stock Keeping Unit): </TD><TD style="HEIGHT: 25px" align=left><asp:Label id="lblSku" runat="server"> 
                        </asp:Label> <asp:TextBox id="txtTemp" runat="server" Width="40px" Visible="False" BorderStyle="Groove">
                        </asp:TextBox> </TD></TR><TR><TD style="VERTICAL-ALIGN: top; WIDTH: 200px; HEIGHT: 25px" align=right>Category:<SPAN class="mandatory">*</SPAN> </TD><TD style="VERTICAL-ALIGN: top; HEIGHT: 25px" align=left><asp:DropDownList id="ddlCategory" runat="server" Width="350px" DataTextField="Category" DataValueField="CategoryID" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" AppendDataBoundItems="True" AutoPostBack="True">
                            <asp:ListItem Text="Select Category" Value="-1"></asp:ListItem>
                        </asp:DropDownList> <asp:RequiredFieldValidator id="rfvCategory" runat="server" ValidationGroup="Title" Font-Bold="True" SetFocusOnError="True" InitialValue="-1" ErrorMessage="Select Category" ControlToValidate="ddlCategory">?</asp:RequiredFieldValidator> <asp:LinkButton id="btnChangeCategory" onclick="btnChangeCategory_Click" runat="server" Font-Underline="true" Visible="False" Font-Size="12px" Font-Names="verdana,arial,helvetica,sans-serif">Refine Search</asp:LinkButton> </TD></TR><TR><TD style="VERTICAL-ALIGN: top; WIDTH: 200px; HEIGHT: 25px" align=right>Subcategory:<SPAN class="mandatory">*</SPAN> </TD><TD style="VERTICAL-ALIGN: top; HEIGHT: 25px" align=left><asp:DropDownList id="ddlSubcategory" runat="server" Width="350px" DataTextField="Subcategory" DataValueField="SubcategoryID" OnSelectedIndexChanged="ddlSubcategory_SelectedIndexChanged" AppendDataBoundItems="True" AutoPostBack="True">
                            <asp:ListItem Text="Select Subcategory" Value="-1"></asp:ListItem>
                        </asp:DropDownList> <asp:RequiredFieldValidator id="rfvSubcategory" runat="server" ValidationGroup="Title" Font-Bold="True" SetFocusOnError="True" InitialValue="-1" ErrorMessage="Select Subcategory" ControlToValidate="ddlSubcategory">?</asp:RequiredFieldValidator> </TD></TR><TR><TD style="VERTICAL-ALIGN: top; WIDTH: 200px; HEIGHT: 25px" align=right>Secondary Subcategory: <SPAN class="mandatory">*</SPAN> </TD><TD style="VERTICAL-ALIGN: top; HEIGHT: 25px" align=left><asp:DropDownList id="ddl2ndSubCategory" runat="server" Width="350px" DataTextField="SecondSubcategory" DataValueField="SecBookSubcategoryID" OnSelectedIndexChanged="ddl2ndSubCategory_SelectedIndexChanged" AppendDataBoundItems="True" AutoPostBack="True">
                            <asp:ListItem Text="Select Second Subcategory" Value="-1"></asp:ListItem>
                        </asp:DropDownList> <asp:RequiredFieldValidator id="rfvSecondSucategory" runat="server" ValidationGroup="Title" Font-Bold="True" SetFocusOnError="True" InitialValue="-1" ErrorMessage="Select Second subcategory" ControlToValidate="ddl2ndSubCategory">?</asp:RequiredFieldValidator> <asp:Label id="lblMessage" runat="server" ForeColor="Red"></asp:Label></TD></TR></TBODY></TABLE><asp:Panel id="pnlModel" runat="server" Width="100%" Visible="false" Enabled="false"><TABLE style="COLOR: #000000" class="cptable" cellSpacing=0 cellPadding=0 width="100%" border=0><TBODY><TR><TD style="VERTICAL-ALIGN: top; WIDTH: 200px; HEIGHT: 25px" align=right><asp:Label id="lblModel" runat="server" Text="Model:">
                        </asp:Label><SPAN class="mandatory">*</SPAN> </TD><TD style="VERTICAL-ALIGN: top; HEIGHT: 25px" align=left><asp:DropDownList id="ddlModel" runat="server" Width="350px" DataTextField="Model" DataValueField="ModelID" OnSelectedIndexChanged="ddlModel_SelectedIndexChanged" AppendDataBoundItems="True" AutoPostBack="True">
                            <asp:ListItem Text="Select Model" Value="-1"></asp:ListItem>
                        </asp:DropDownList> <asp:RequiredFieldValidator id="rfvProductModel" runat="server" ValidationGroup="Title" Font-Bold="True" InitialValue="-1" ErrorMessage="Select Model" ControlToValidate="ddlModel" Display="Dynamic">?</asp:RequiredFieldValidator> <asp:LinkButton id="addModel1" onclick="addModel1_Click" runat="server" Font-Underline="true" Visible="True" Font-Size="12px" Font-Names="verdana,arial,helvetica,sans-serif">Add Model</asp:LinkButton> </TD></TR>
                        
                        </TBODY></TABLE>
                            <asp:UpdatePanel id="updatePanel3" runat="server">
                                <contenttemplate>
<asp:Panel id="modelPanel" runat="server" Width="800px" Visible="false" Enabled="false"><TABLE style="WIDTH: 100%; BORDER-BOTTOM: #efefe2 1px solid" class="cptable" cellSpacing=0 cellPadding=5 border=0><TBODY><TR><TD style="WIDTH: 194px; HEIGHT: 87px" align=right>Model Name:<SPAN class="mandatory">*</SPAN> </TD><TD style="HEIGHT: 87px" align=left><TABLE><TBODY><TR><TD><asp:TextBox id="txtProductModel" runat="server" Width="233px"></asp:TextBox> </TD><TD style="WIDTH: 11px"></TD></TR><TR><TD><asp:Button id="submitButton" onclick="submitButton_Click" runat="server" Text="Submit"></asp:Button> <asp:Button id="close" onclick="close_Click" runat="server" Text="Cancel"></asp:Button></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE></asp:Panel> 
</contenttemplate>
                            </asp:UpdatePanel>
                        </asp:Panel> 

<TABLE style="BORDER-TOP: #efefe2 1px solid; COLOR: #000000" class="cptable" cellSpacing=0 cellPadding=0 width="100%" border=0><TBODY><TR><TD style="VERTICAL-ALIGN: top; WIDTH: 200px; HEIGHT: 25px">  </TD><TD style="VERTICAL-ALIGN: top; HEIGHT: 25px"><asp:Label id="lblTitleMessage" runat="server" Width="100%" Font-Size="11px" ForeColor="DarkGreen" EnableViewState="False"></asp:Label></TD></TR><TR><TD style="VERTICAL-ALIGN: top; WIDTH: 200px; HEIGHT: 25px" align=right>Product Title:<SPAN class="mandatory">*</SPAN> </TD><TD style="VERTICAL-ALIGN: top; HEIGHT: 25px" align=left><asp:TextBox id="txtTitle" runat="server" Width="350px" MaxLength="250" CssClass="textbox"></asp:TextBox> <asp:RequiredFieldValidator id="rfvTitle" runat="server" ValidationGroup="Title" Font-Bold="True" ErrorMessage="Product Title field is blank !" ControlToValidate="txtTitle">?</asp:RequiredFieldValidator> <asp:LinkButton id="btnCheckDuplicacy" onclick="btnCheckDuplicacy_Click" runat="server" Font-Underline="true" Visible="False" Font-Size="12px" Font-Names="verdana,arial,helvetica,sans-serif">Check For Duplicacy
                    </asp:LinkButton> </TD></TR><TR style="BORDER-BOTTOM: medium none"><TD style="VERTICAL-ALIGN: top; WIDTH: 200px; HEIGHT: 25px"> </TD><TD style="VERTICAL-ALIGN: top; HEIGHT: 25px" align=left><asp:Button id="btnSearch" onclick="btnSearch_Click" runat="server" ValidationGroup="Title" BorderStyle="Groove" CssClass="image_btn" Text="Search"></asp:Button>  <asp:Button id="btnRejectTitle" runat="server" Visible="False" BorderStyle="Groove" CssClass="image_btn" Text="Reject" CausesValidation="False"></asp:Button> </TD></TR></TBODY></TABLE><asp:GridView id="grvProduct" runat="server" Width="100%" Font-Size="11px" Font-Names="Verdana" OnRowCommand="grvProduct_RowCommand" AutoGenerateColumns="False" RowStyle-BackColor="#FFFFFF" DataKeyNames="ProductID, ProductTitle, SecondSubcatID" GridLines="None" AllowPaging="True" PageSize="10" OnPageIndexChanging="grvProduct_PageIndexChanging" PagerSettings-Position="TopAndBottom">
            <HeaderStyle Height="25px" BackColor="#FFFFFF" />
            <AlternatingRowStyle BackColor="#F5F5F7" />
            <Columns>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <table style="width: 100%; background-color: #FFFFFF;" cellspacing="0px" cellpadding="0px"
                            border="0px">
                            <tr>
                                <td style="height: 25px; text-align: left; font-size: 13px; width: 600px; padding-left: 10px;
                                    font-weight: normal;">
                                    <%= ddlCategory.SelectedItem.Text %>
                                    : <span class="title">"<%=txtTitle.Text %>"</span>
                                </td>
                                <td style="padding-right: 10px; text-align: right">
                                    <asp:Button ID="btnReject" runat="server" Text="Reject" CssClass="image_btn" OnClick="btnReject_Click" />
                                </td>
                            </tr>
                        </table>
                        <table style="width: 100%;" cellspacing="0px" cellpadding="0px" border="0px">
                            <tr style="text-align: left; background-color: #EFEFE2;">
                                <td style="width: 100%; height: 25px; padding-left: 10px">
                                    Displaying 1-<%=this.SearchResult > 10 ? 10 : this.SearchResult %>
                                    of
                                    <%=this.SearchResult %>
                                    Results. You can either select any one item from the list or you can create your
                                    own item page.
                                </td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <table style="width: 100%; color: #CCCCCC;" cellspacing="0px" border="0px" cellpadding="0px">
                            <tr style="vertical-align: top; height: 115px">
                                <td class="columnheader" style="width: 100px; padding: 10px 0px 10px 10px">
                                    <asp:Image ID="productImage" runat="server" ImageUrl='<%#Eval("ProductImage") %>'
                                        Width="95px" Height="95px" />
                                </td>
                                <td style="width: 570px; text-align: left; color: Black; padding: 10px 0px 10px 15px">
                                    <div>
                                        <span class="title">
                                            <%#Eval("ProductTitle")%>
                                        </span>
                                    </div>
                                    by <strong>
                                        <%# Eval("Author")%>
                                    </strong>
                                </td>
                                <td class="columnheader" style="padding: 10px 10px 0px 0px; vertical-align: middle;
                                    text-align: left; vertical-align: top">
                                    <asp:ImageButton ID="btnSelectProduct" CommandArgument='<%#grvProduct.Rows.Count.ToString() %>'
                                        CommandName="SelectProduct" runat="server" ImageUrl="~/Images/btn_sell_here.gif" />
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                <table style="width: 100%; color: Black;" cellspacing="0px" cellpadding="0px" border="0px">
                    <tr style="text-align: left">
                        <td class="columnheader" style="width: 200px;">
                        </td>
                </table>
            </EmptyDataTemplate>
        </asp:GridView> <DIV style="WIDTH: 100%; TEXT-ALIGN: right"><asp:Button id="btnNext" onclick="btnNext_Click" runat="server" Visible="False" BorderStyle="Groove" CssClass="image_btn" Text="Next"></asp:Button> </DIV></DIV>
</ContentTemplate>
    </asp:UpdatePanel>
    
    <asp:HiddenField ID="hfCategoryID" runat="server" Visible="False"></asp:HiddenField>
    <asp:HiddenField ID="hfProductID" runat="server"></asp:HiddenField>
    <asp:HiddenField ID="hfSubcategoryID" runat="server" Visible="False"></asp:HiddenField>
    <asp:HiddenField ID="hfSecondSubcatID" runat="server" Visible="False"></asp:HiddenField>
    <asp:HiddenField ID="hfProfileID" runat="server"></asp:HiddenField>
    <asp:HiddenField ID="hfProductTitle" runat="server"></asp:HiddenField>
</asp:Content>
