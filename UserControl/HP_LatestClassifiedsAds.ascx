<%@ Control Language="C#" AutoEventWireup="true" CodeFile="HP_LatestClassifiedsAds.ascx.cs" Inherits="UserControl_HP_LatestClassifiedsAds" %>

<div style="width:425px;" class="set3_t">
    <div class="b">
        <div class="l">
            <div class="r">
                <div class="bl">
                    <div class="br">
                        <div class="set3_tl">
                            <div style="padding: 10px;" class="set3_tr">
                                <strong class="colortitle" style="color:#3382D6;">Most Recent Classified Ads.</strong>
                                <br />
                                <asp:Label ID="lblSystemMessage" runat="server" EnableViewState="False"></asp:Label>
                                <br />
                                <table cellspacing="0" cellpadding="3" style="font-size: 11px;" border="0" width="100%">
                                    <tr>
                                        <td class="keys" colspan="2">
                                            <asp:Repeater ID="repWant" runat="server">
                                                <ItemTemplate>
                                                    <span class="price" style="font-weight: normal; color:#3382D6"></span><a  style="color:#3382D6;" target="_blank" class="onHoverBlue"
                                                        href="ItemDetail_Classifieds.aspx?ItemKey=<%#Eval("ProductID")%>&ProfKey=<%#Eval("ProfileID")%>&CID=<%#Eval("CategoryID")%>&SCID=<%#Eval("SubcategoryID")%>&Location=<%#Eval("Country")%>&AdType=<%#Eval("AdvertisementType")%>">
                                                        <%#Eval("ProductTitle") %>
                                                        more </a>
                                                    <br />
                                                    <div style="text-align: right; width: 100%">
                                                        <span class="italic" style="font-style: italic; font-weight: bold">
                                                            <%#Eval("InsertTime") %>
                                                        </span>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" class="keys" style="padding: 3px;">
                                            <a target="_blank" class="onHoverBlue price smallfont" href="ItemList_Classifieds.aspx?PageMode=0&CID=12&Location=Bangladesh">
                                                View All Ads </a>&nbsp;|
                                            <a target="_blank" class="onHoverBlue price smallfont" href="Classifieds/Default.aspx">
                                                Post Classified Ads. </a>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
