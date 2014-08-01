var dtCh = "/";
var minYear = 1700;
var maxYear = 2100;

function isInteger(s) {
    var i;
    for (i = 0; i < s.length; i++) {
        var c = s.charAt(i);
        if (((c < "0") || (c > "9")))
            return false;
    }

    return true;
}

function stripCharsInBag(s, bag) {
    var i;
    var returnString = "";
    for (i = 0; i < s.length; i++) {
        var c = s.charAt(i);
        if (bag.indexOf(c) == -1) returnString += c;
    }
    return returnString;
}

//    function daysInFebruary(year) 
//    {
//        return (((year % 4 == 0) && ((!(year % 100 == 0)) || (year % 400 == 0))) ? 29 : 28);
//        
//    }
function DaysArray(n) {
    for (var i = 1; i <= n; i++) {
        this[i] = 31
        if (i == 4 || i == 6 || i == 9 || i == 11) {
            this[i] = 30
        }
        //            if (i == 2) 
        //            {
        //                this[i] = 29
        //            }
    }
    return this
}

function isDate(dtStr) {
    var daysInMonth = DaysArray(12)
    var pos1 = dtStr.indexOf(dtCh)
    var pos2 = dtStr.indexOf(dtCh, pos1 + 1)
    var strDay = dtStr.substring(0, pos1)
    var strMonth = dtStr.substring(pos1 + 1, pos2)
    var strYear = dtStr.substring(pos2 + 1)
    strYr = strYear
    if (strDay.charAt(0) == "0" && strDay.length > 1) strDay = strDay.substring(1)
    if (strMonth.charAt(0) == "0" && strMonth.length > 1) strMonth = strMonth.substring(1)
    for (var i = 1; i <= 3; i++) {
        if (strYr.charAt(0) == "0" && strYr.length > 1) strYr = strYr.substring(1)
    }
    month = parseInt(strMonth)
    day = parseInt(strDay)
    year = parseInt(strYr)
    if (pos1 == -1 || pos2 == -1) {
        alert("The date format should be : dd/mm/yyyy")
        return false
    }
    if (strMonth.length < 1 || month < 1 || month > 12) {
        alert("Month must be in between 01 to 12.")
        return false
    }
    //        if (strMonth.length < 1 || day < 1 || day > 31 || (month == 2 && day > daysInFebruary(year))) 
    //        {
    //            alert("Please enter a valid day")
    //            return false
    //        }
    if (strMonth.length < 1 || day < 1 || day > 31) {
        alert("Please enter a valid day")
        return false
    }

    else if (day > daysInMonth[month]) {
        alert("Day must be in between 01 to 30.")
        return false
    }
    if (month == 2) {
        if (!(year % 4) == 0) {
            if (day > 28) {
                alert("Day must be in between 01 to 28.");
                return false;
            }
        }
        else if ((year % 400) == 0) {
            if (day > 29) {
                alert("Day must be in between 01 to 29.")
                return false;
            }
        }
        else if (year % 100 == 0) {
            if (day > 28) {
                alert("Day must be in between 01 to 28.")
                return false;
            }
        }
        else if ((year % 4) == 0) {
            if (day > 29) {
                alert("Day must be in between 01 to 29.");
                return false;
            }
        }
    }

    if (strYear.length != 4 || year == 0 || year < minYear || year > maxYear) {
        alert("Year must be 4 digit " + minYear + " and " + maxYear)
        return false
    }
    if (dtStr.indexOf(dtCh, pos2 + 1) != -1 || isInteger(stripCharsInBag(dtStr, dtCh)) == false) {
        alert("Please enter a valid date")
        return false
    }
    return true
}

//function ValidateForm() {
//    var dt = document.frmSample.txtDate
//    if (isDate(dt.value) == false) {
//        dt.focus()
//        return false
//    }
//    return true
//}
