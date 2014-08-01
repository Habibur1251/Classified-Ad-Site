<%@ Control Language="C#" AutoEventWireup="true" CodeFile="HP_LatestDiscount.ascx.cs" Inherits="UserControl_HP_LatestDiscount" %>
<asp:Label ID="lblSystemMessage" runat="server">
</asp:Label>
<div style="width:258px;" class="set3_t">
    <div class="b">
        <div class="l">
            <div class="r">
                <div class="bl">
                    <div class="br">
                        <div class="set3_tl">
                            <div style="padding: 11px; " class="set3_tr">
                            <strong class="colortitle">Recent offers at ApnerDealDiscount</strong>
                    
<asp:GridView ID="grvTopFiveDiscount" runat="server" Width="100%" AllowPaging="false" GridLines="None"
    OnRowDataBound="grvTopFiveDiscount_RowDataBound" AutoGenerateColumns="false">
    <Columns>
        <asp:TemplateField>
            <ItemTemplate>
                <table cellpadding="0px" cellspacing="3px" border="0px" width="100%">
                    <tr style="padding: 0px 0px 0px 0px">
                        <td style="vertical-align: top; padding: 0px 0px 0px 0px">
                         <asp:PlaceHolder ID="phCouponLink" runat="server">
                         </asp:PlaceHolder>
                        <div style="text-align:right; width:100%">
                         <span class="italic" style="font-style:italic; font-weight:bold">
                        <span style="font-size:10px; font-family:Verdana;"><%#Eval("DayRemain")%> Days Remaining</span>
                        </span>
                        </div>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
<br />
<a target="_blank" class="onHoverBlue price smallfont" href="../DefaultDiscount.aspx">
                                                 <span style="font-size:10px">View All Discount</span></a>&nbsp;
| &nbsp;<a target="_blank" class="onHoverBlue price smallfont" href="../Default.aspx"><span style="font-size:10px">Post Your Discount</span></a>
                        </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
