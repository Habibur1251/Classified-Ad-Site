<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CL_SelectCategory_Ctrl.ascx.cs" Inherits="UserControl_CL_SelectCategory_Ctrl" %>

<asp:Label ID="lblSystemMessage" runat="server"></asp:Label>
<div class="topContent" style="width:100%">

           <div class="b">
              <div class="l">
                 <div class="r">
                    <div class="bl">
                       <div class="br">
                          <div class="tl">
                          
                             <div class="tr" style="height:auto; padding:10px; text-align: left;">
                              <strong class="pageTitle colortitle">   Select a category you want to sell or want to post ad</strong> 
                             </div>
                          </div>
                       </div>
                    </div>
                 </div>
              </div>
           </div>
        </div>
        
         <div class="topContent" style="width:100%;">
         
           <div class="b">
              <div class="l">
                 <div class="r">
                    <div class="bl">
                       <div class="br">
                          <div class="tl">
                          
                             <div class="tr" style="height:auto; padding:6px; padding-top:0px;">
                             <table style="width: 100%">
                             <tr>
                             
                             <td style="width: 91px; text-align: left;">
                             <asp:Panel ID="pnlClassifiedCategory" runat="server">
                            
                              <table cellpadding='5' cellspacing='5' border='0' style="width: 175px"> 
                             
                           
                             <tr>
                             <td style="height: 135px; width: 175px; text-align: left;">
                             
                           <strong class="colortitle">
                               Classified Category</strong>
                         
                             <asp:GridView 
                        
                                ID="grvClassifiedCategory"
                                runat="server"
                                AllowPaging="false"
                                AutoGenerateColumns="false"
                                GridLines="None" Font-Size="Medium">
                                <Columns>
                                
                                
                                <asp:TemplateField>
                                <ItemTemplate>
                                
                                
                                
                                <a class="onHoverBlue" 
                                    style="font-size:12px" 
                                    href="ProductProfile_Edit.aspx?PageMode=0&CID=<%# Eval("CategoryID")%>&Location=Bangladesh&PID=-1" >
                                        <%#Eval("Category") %>
                                </a>
                                 
                                </ItemTemplate>
                                </asp:TemplateField>
                                </Columns>   
                                
                             </asp:GridView>
                                 
                             
                             </td>
                             </tr>
                             </table>
                                 </asp:Panel>
                                 &nbsp; &nbsp;
                             
                             </td>
                                 <td align="right" style="width: 114px; text-align: right">
                                 <img src="../Images/apnerdeal_logo.png" /></td>
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
        
      
       
        
        
        
       
                        