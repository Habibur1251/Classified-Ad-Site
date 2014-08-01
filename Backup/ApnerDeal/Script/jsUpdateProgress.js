// JScript File
Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(beginReq); 

Sys.WebForms.PageRequestManager.getInstance().add_endRequest(endReq);    

function beginReq(sender, args){ 

    // shows the Popup 

    $find(ModalProgress).show();        

} 

function endReq(sender, args) { 

    //  shows the Popup 

    $find(ModalProgress).hide(); 

} 
