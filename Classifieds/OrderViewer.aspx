<%@ Page Language="C#" MasterPageFile="~/Classifieds/MPClassifieds2.master" AutoEventWireup="true" CodeFile="OrderViewer.aspx.cs" Inherits="Classifieds_OrderViewer" Title="www.apnerdeal.com – Classified User Order Details." %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<span class="pageTitle">Classifieds – Order Details.</span><br />
<span class="gray11px" style="font-weight:normal; margin-top:7px;">ApnerDeal.com is absolutely <strong style="color:#EC2024;">FREE</strong> for posting classified Ads. It will not cost you anything.</span>
<br /><br />
<asp:Repeater ID="Repeater1" runat="server">
    <ItemTemplate>
    <ul>
        <li>
        <strong><%# DataBinder.Eval(Container.DataItem, "CustomerEmail")%></strong>&nbsp - says,
        <br /><br />
        <%# DataBinder.Eval(Container.DataItem, "CustomerMessage")%>
        </li>
    </ul>
    </ItemTemplate>
</asp:Repeater>
<br />
<div align="right">&nbsp;</div>
<br />
</asp:Content>

