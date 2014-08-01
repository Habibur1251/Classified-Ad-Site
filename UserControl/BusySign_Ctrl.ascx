<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BusySign_Ctrl.ascx.cs" Inherits="UserControl_BusySign_Ctrl" %>
<asp:UpdateProgress ID="updateProgress" runat="server">
    <ProgressTemplate>
        <table width="200px" border="0px" cellspacing="0px" cellpadding="0px">
            <tr>
                <td style="height: 35px; width: 5px;">
                    <img alt="" src="../images/location_left.gif" width="5px" height="35px" />
                </td>
                <td class="location" align="center" valign="middle" style="height: 35px; text-align: center">
                    <img alt="" src="../Images/loading_gif.gif" />
                </td>
                <td class="location" align="center" valign="middle" style="height: 35px; font-weight: bold;
                    text-align: center; color: #990000">
                    Loading... Please Wait
                </td>
                <td width="5px" style="height: 35px">
                    <img alt="" src="../images/location_right.gif" width="5px" height="35px" />
                </td>
            </tr>
            <tr>
            </tr>
        </table>
    </ProgressTemplate>
</asp:UpdateProgress>
