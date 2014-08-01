<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AllCategoryMenu.ascx.cs" Inherits="Menu_AllCategoryMenu" %>
<script type="text/javascript" src="stmenu.js"></script>
<div>
<table>
<tr>
<td style="width:auto">
<script type="text/javascript">
<!--
stm_bm(["menu3ba5",900,"","blank.gif",0,"","",0,0,250,0,1000,1,0,0,"","",0,0,1,2,"default","hand","",1,25],this);
//stm_bp("p0",[0,4,0,0,0,5,0,0,100,"",-2,"",-2,50,0,0,"#999999","#E6EFF9","bg_02.gif",3,0,0,"#000000","",-1,-1,0,"#FFFFF7","",3,"bg_03.gif",37,3,0,"#FFFFF7","",3,"",-1,-1,0,"#FFFFF7","",3,"bg_01.gif",37,3,0,"#FFFFF7","",3,"","","","",20,20,20,20,20,20,20,20]);
stm_bp("p0",[0,4,0,0,0,5,0,0,100,"",-2,"",-2,50,0,0,"#999999","#E6EFF9","bg_00.png",3,0,0,"#000000","",-1,-1,0,"#FFFFF7","",3,"bg_00.png",37,3,0,"#FFFFF7","",3,"",-1,-1,0,"#FFFFF7","",3,"bg_00.png",37,3,0,"#FFFFF7","",3,"","","","",20,20,20,20,20,20,20,20]);
stm_ai("p0i0",[0,"    All Category    ","","",-1,-1,0,"","_self","","","","",0,0,0,"","",0,0,0,1,1,"#E6EFF9",1,"#E6EFF9",1,"bg_00.png","bg_20.png",3,3,0,0,"#E6EFF9","#000000","#FFFFFF","#E47911","bold 11pt Verdana","bold 11pt Verdana",0,0,"","","","",0,0,0],157,30);
stm_bp("p1",[1,4,-20,2,0,5,0,10,100,"",-2,"",-2,50,2,3,"#333333","#333333","",3,1,1,"#000000"]);
stm_aix("p1i0","p0i0",[0,"Shop All Department","","",-1,-1,0,"../ShopAll_Depertment.aspx","_blank","","","","",0,0,0,"","",0,0,0,0,1,"#E6EFF9",1,"#0000FF",1,"bg_04.png","bg_20.png",3,3,0,0,"#E6EFF9","#000000","#FFFFFF","#E47911","bold 8pt Verdana","bold 8pt Verdana"],165,0);
stm_aix("p1i1","p1i0",[0,"Books","","",-1,-1,0,"","_self","","","","",0,0,0,"arrowgrey-r.gif","arrowgrey-r.gif",10,5,0,0,1,"#E6EFF9",1,"#000000",0],165,20);
stm_bpx("p2","p1",[1,2,-20,2,0,5,0,0,80]);
stm_aix("p2i0","p1i0",[0,"General Books","","",-1,-1,0,"ItemList_Books.aspx?PageMode=0&CID=1&SCID=2&Location=Bangladesh","_blank","","","","",0,0,0,"","",0,0,0,0,1,"#E6EFF9",1,"#000000",1,"bg_00.png"],120,0);
stm_aix("p2i1","p1i0",[0,"Text Books","","",-1,-1,0,"ItemList_Books.aspx?PageMode=0&CID=1&SCID=1&Location=Bangladesh","_blank","","","","",0,0,0,"","",0,0,0,0,1,"#E6EFF9",1,"#FFFFFF"],120,0);
stm_ep();
stm_aix("p1i2","p2i1",[0,"Cars & MotorCycles","","",-1,-1,0,"","_self","","","","",0,0,0,"arrowgrey-r.gif","arrowgrey-r.gif",10,5],165,20);
stm_bpx("p3","p2",[]);
stm_aix("p3i0","p2i1",[0,"Cars","","",-1,-1,0,"ItemList_Automobile.aspx?PageMode=0&CID=3&SCID=79&Location=Bangladesh","_blank","","","","",0,0,0,"","",0,0,0,0,1,"#E6EFF9",1,"#000000",1,"bg_00.png"],120,0);
stm_aix("p3i1","p2i0",[0,"MotorCycles","","",-1,-1,0,"ItemList_Automobile.aspx?PageMode=0&CID=3&SCID=80&Location=Bangladesh","_blank","","","","",0,0,0,"","",0,0,0,0,1,"#E6EFF9",1,"#000000",1,"bg_00.png"],120,0);
stm_ep();
stm_aix("p1i3","p3i1",[0,"Computer, Laptop","","",-1,-1,0,"","_self","","","","",0,0,0,"arrowgrey-r.gif","arrowgrey-r.gif",10,5],165,20);
stm_bpx("p4","p2",[]);
stm_aix("p4i0","p3i1",[0,"Desktop Pc","","",-1,-1,0,"ItemList_Computer.aspx?PageMode=0&CID=4&SCID=81&Location=Bangladesh","_blank","","","","",0,0,0,"","",0,0,0,0,1,"#E6EFF9",1,"#000000",1,"bg_00.png"],125,0);
stm_aix("p4i1","p2i0",[0,"Laptop","","",-1,-1,0,"ItemList_Computer.aspx?PageMode=0&CID=4&SCID=82&Location=Bangladesh","_blank","","","","",0,0,0,"","",0,0,0,0,1,"#E6EFF9",1,"#000000",1,"bg_00.png"],125,0);
stm_aix("p4i2","p4i1",[0,"Computer Parts","","",-1,-1,0,"ItemList_Computer.aspx?PageMode=0&CID=4&SCID=83&Location=Bangladesh","_blank","","","","",0,0,0,"","",0,0,0,0,1,"#E6EFF9",1,"#000000",1,"bg_00.png"],125,0);
stm_aix("p4i3","p4i0",[0,"Software","","",-1,-1,0,"ItemList_Computer.aspx?PageMode=0&CID=4&SCID=102&Location=Bangladesh","_blank","","","","",0,0,0,"","",0,0,0,0,1,"#E6EFF9",1,"#000000",1,"bg_00.png"],125,0);
stm_ep();
stm_aix("p1i4","p2i0",[0,"Mobiles","","",-1,-1,0,"","_self","","","","",0,0,0,"arrowgrey-r.gif","arrowgrey-r.gif",10,5,0,0,1,"#E6EFF9",1,"#FFFFFF",0],165,20);
stm_bpx("p5","p2",[]);
stm_aix("p5i0","p4i0",[0,"Mobile Set","","",-1,-1,0,"ItemList_Mobile.aspx?PageMode=0&CID=2&SCID=76&Location=Bangladesh","_blank","","","","",0,0,0,"","",0,0,0,0,1,"#E6EFF9",1,"#000000",1,"bg_00.png"],125,0);
stm_aix("p5i1","p4i0",[0,"Connection","","",-1,-1,0,"ItemList_Mobile.aspx?PageMode=0&CID=2&SCID=77&Location=Bangladesh","_blank","","","","",0,0,0,"","",0,0,0,0,1,"#E6EFF9",1,"#000000",1,"bg_00.png"],125,0);
stm_aix("p5i2","p4i0",[0,"Pre-paid Card","","",-1,-1,0,"ItemList_Mobile.aspx?PageMode=0&CID=2&SCID=78&Location=Bangladesh","_blank","","","","",0,0,0,"","",0,0,0,0,1,"#E6EFF9",1,"#000000",1,"bg_00.png"],125,0);
stm_ep();
stm_aix("p1i5","p1i3",[0,"Movies,Music,Games"],165,20);
stm_bpx("p6","p2",[]);
stm_aix("p6i0","p4i0",[0,"Movies","","",-1,-1,0,"ItemList_MovieDvdGame.aspx?PageMode=0&CID=8&SCID=49&Location=Bangladesh","_blank","","","","",0,0,0,"","",0,0,0,0,1,"#E6EFF9",1,"#000000",1,"bg_00.png"],125,0);
stm_aix("p6i1","p4i0",[0,"Music","","",-1,-1,0,"ItemList_MovieDvdGame.aspx?PageMode=0&CID=8&SCID=50&Location=Bangladesh","_blank","","","","",0,0,0,"","",0,0,0,0,1,"#E6EFF9",1,"#000000",1,"bg_00.png"],125,0);
stm_aix("p6i2","p4i0",[0,"Games","","",-1,-1,0,"ItemList_MovieDvdGame.aspx?PageMode=0&CID=8&SCID=51&Location=Bangladesh","_blank","","","","",0,0,0,"","",0,0,0,0,1,"#E6EFF9",1,"#000000",1,"bg_00.png"],125,0);
stm_aix("p6i3","p4i0",[0,"Natok","","",-1,-1,0,"ItemList_MovieDvdGame.aspx?PageMode=0&CID=8&SCID=109&Location=Bangladesh","_blank","","","","",0,0,0,"","",0,0,0,0,1,"#E6EFF9",1,"#000000",1,"bg_00.png"],125,0);
stm_ep();
stm_aix("p1i6","p1i3",[0,"Electronics"],165,20);
stm_bpx("p7","p2",[]);
stm_aix("p7i0","p4i0",[0,"TV","","",-1,-1,0,"ItemList_Electronics.aspx?PageMode=0&CID=6&SCID=84&Location=Bangladesh","_blank","","","","",0,0,0,"","",0,0,0,0,1,"#E6EFF9",1,"#000000",1,"bg_00.png"],165,0);
stm_aix("p7i1","p4i0",[0,"MP3 Player/iPod/Audio","","",-1,-1,0,"ItemList_Electronics.aspx?PageMode=0&CID=6&SCID=85&Location=Bangladesh","_blank","","","","",0,0,0,"","",0,0,0,0,1,"#E6EFF9",1,"#000000",1,"bg_00.png"],165,0);
stm_aix("p7i2","p4i0",[0,"DVD Player","","",-1,-1,0,"ItemList_Electronics.aspx?PageMode=0&CID=6&SCID=86&Location=Bangladesh","_blank","","","","",0,0,0,"","",0,0,0,0,1,"#E6EFF9",1,"#000000",1,"bg_00.png"],165,0);
stm_aix("p7i3","p4i0",[0,"Camera/Camcorder","","",-1,-1,0,"ItemList_Electronics.aspx?PageMode=0&CID=6&SCID=87&Location=Bangladesh","_blank","","","","",0,0,0,"","",0,0,0,0,1,"#E6EFF9",1,"#000000",1,"bg_00.png"],165,0);
stm_ep();
stm_aix("p1i7","p1i3",[0,"Real Estate"],165,20);
stm_bpx("p8","p2",[]);
stm_aix("p8i0","p4i0",[0,"For Sale","","",-1,-1,0,"ItemList_RealEstate.aspx?PageMode=0&CID=7&SCID=54&Location=Bangladesh","_blank","","","","",0,0,0,"","",0,0,0,0,1,"#E6EFF9",1,"#000000",1,"bg_00.png"],110,0);
stm_aix("p8i1","p4i0",[0,"For Rent","","",-1,-1,0,"ItemList_RealEstate.aspx?PageMode=0&CID=7&SCID=55&Location=Bangladesh","_blank","","","","",0,0,0,"","",0,0,0,0,1,"#E6EFF9",1,"#000000",1,"bg_00.png"],110,0);
stm_ep();
stm_ep();
stm_ep();
stm_em();
//-->
</script>
</td>
</tr>
</table>
</div>