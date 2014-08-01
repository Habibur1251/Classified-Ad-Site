<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DZ_TOPFive_ViewedDiscount.ascx.cs" Inherits="UserControl_DZ_TOPFive_ViewedDiscount" %>
<asp:Label ID="lblSystemMessage" runat="server">
</asp:Label>
<div style="width:200px;" class="set3_t">
    <div class="b">
        <div class="l">
            <div class="r">
                <div class="bl">
                    <div class="br">
                        <div class="set3_tl">
                            <div style="padding: 10px; " class="set3_tr">
                            <strong class="colortitle">Most viewed discount</strong>
                    
<asp:GridView ID="grvTopFiveDiscount" runat="server" Width="100%" AllowPaging="false" GridLines="None"
    AutoGenerateColumns="false" OnRowDataBound="grvTopFiveDiscount_RowDataBound">
    <Columns>
        <asp:TemplateField>
            
            <ItemTemplate>
                <table cellpadding="0px" cellspacing="3px" border="0px" width="100%">
                    <tr style="padding: 0px 0px 0px 0px">
                        <td style="width: 80px; height: 70px; vertical-align: top; padding: 0px 0px 0px 0px">
                       <img src='<%#Eval("ImagePath")%>' onerror="javascript:this.src='Images/CompanyDefaultImage.png';"style="height: 70px; width: 80px; border: none;" />
                     </td>
                        <td style="vertical-align: top; padding: 5px 0px 0px 5px">
                        <asp:PlaceHolder ID="phCouponLink" runat="server">
                         </asp:PlaceHolder>

                         </a>
                    </td>
                    </tr>
                    <tr>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
                        </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
