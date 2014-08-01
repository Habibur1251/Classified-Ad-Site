/* Designer: Raihan A.K. raihan@rakplanet.com */
qmad.slide = new Object();
qmad.bvis += "qm_slide_a(b.cdiv);";
qmad.bhide += "qm_slide_a(a,1);";
qmad.br_navigator = navigator.userAgent.indexOf("Netscape") + 1;
qmad.br_version = parseFloat(navigator.vendorSub);
qmad.br_oldnav = qmad.br_navigator && qmad.br_version < 7.1;
qmad.br_ie = window.showHelp;
qmad.br_mac = navigator.userAgent.indexOf("Mac") + 1;
qmad.br_old_safari = navigator.userAgent.indexOf("afari") + 1 &&
    !window.XMLHttpRequest;
qmad.slide_off = qmad.br_oldnav || (qmad.br_mac && qmad.br_ie) ||
    qmad.br_old_safari;
;
function qm_slide_a(a, hide)
{
    if ((a.style.visibility == "inherit" && !hide) || (qmad.slide_off))
        return ;
    var ss;
    if (!a.settingsid)
    {
        var v = a;
        while ((v = v.parentNode))
        {
            if (v.className.indexOf("qmmc") + 1)
            {
                a.settingsid = v.id;
                break;
            }
        }
    }
    ss = qmad[a.settingsid];
    if (!ss)
        return ;
    if (!ss.slide_animation_frames)
        return ;
    var steps = ss.slide_animation_frames;
    var b = new Object();
    b.obj = a;
    b.offy = ss.slide_offy;
    b.offx = ss.slide_offx;
    b.left_right = ss.slide_left_right;
    b.sub_subs_left_right = ss.slide_sub_subs_left_right;
    b.drop_subs = ss.slide_drop_subs;
    if (b.sub_subs_left_right && a.parentNode.className.indexOf("qmmc") ==  - 1)
        b.left_right = true;
    if (b.left_right)
        b.drop_subs = false;
    b.drop_subs_height = ss.slide_drop_subs_height;
    b.drop_subs_disappear = ss.slide_drop_subs_disappear;
    b.accelerator = ss.slide_accelerator;
    if (b.drop_subs && !b.accelerator)
        b.accelerator = 1;
    b.tb = "top";
    b.wh = "Height";
    if (b.left_right)
    {
        b.tb = "left";
        b.wh = "Width";
    }
    b.stepy = a["offset" + b.wh] / steps;
    b.top = parseInt(a.style[b.tb]);
    if (!hide)
        a.style[b.tb] = (b.top - a["offset" + b.wh]) + "px";
    else
    {
        b.stepy =  - b.stepy;
        x5("qmfv", a, 1);
    }
    a.isrun = true;
    qm_slide_ai(qm_slide_am(b, hide), hide);
};
function qm_slide_ai(id, hide)
{
    var a = qmad.slide["_" + id];
    if (!a)
        return ;
    var cy = parseInt(a.obj.style[a.tb]);
    if (a.drop_subs)
        a.stepy += a.accelerator;
    else
    {
        if (hide)
            a.stepy -= a.accelerator;
        else
            a.stepy += a.accelerator;
    }
    if ((!hide && cy + a.stepy < a.top) || (hide && cy + a.stepy > a.top -
        a.obj["offset" + a.wh] && cy < a.drop_subs_height))
    {
        var bc = 2000;
        if (hide && a.drop_subs && !a.drop_subs_disappear && cy + a.stepy +
            a.obj["offset" + a.wh] > a.drop_subs_height)
            bc = a.drop_subs_height - cy + a.stepy;
        var tc = Math.round(a.top - (cy + a.stepy) + a.offy);
        if (a.left_right)
            a.obj.style.clip = "rect(auto 2000px 2000px " + tc + "px)";
        else
            a.obj.style.clip = "rect(" + tc + "px 2000px " + bc + "px auto)";
        a.obj.style[a.tb] = Math.round(cy + a.stepy) + "px";
        a.timer = setTimeout("qm_slide_ai(" + id + "," + hide + ")", 10);
    }
    else
    {
        a.obj.style[a.tb] = a.top + "px";
        a.obj.style.clip = "rect(0 auto auto auto)";
        if (a.obj.style.removeAttribute)
            a.obj.style.removeAttribute("clip");
        else
            a.obj.style.clip = "auto";
        if (!window.showHelp)
            a.obj.style.clip = "";
        if (hide)
            x5("qmfv", a.obj);
        qmad.slide["_" + id] = null;
        a.obj.isrun = false;
    }
};
function qm_slide_am(obj, hide)
{
    var k;
    for (k in qmad.slide)
    {
        if (qmad.slide[k] && obj.obj == qmad.slide[k].obj)
        {
            if (qmad.slide[k].timer)
            {
                clearTimeout(qmad.slide[k].timer);
                qmad.slide[k].timer = null;
            }
            obj.top = qmad.slide[k].top;
            qmad.slide[k].obj.isrun = false;
            qmad.slide[k] = null;
        }
    }
    var i = 0;
    while (qmad.slide["_" + i])
        i++;
    qmad.slide["_" + i] = obj;
    return i;
}
