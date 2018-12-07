sabio.ui.date = sabio.ui.date || {};

sabio.ui.date.dateFormatDatePicker = function (dateString) {
    /*
     Assumes entered value of date format used for datepicker plugin since c# does not have a Date data type
    */
    
    var dtDate = new Date(dateString);

    var strYear = dtDate.getFullYear();
    var strMonth = dtDate.getMonth() + 1;
    var strDay = dtDate.getUTCDate();

    if (strMonth < 10) {
        strMonth = "0" + strMonth;
    }

    if (strDay < 10) {
        strDay = "0" + strDay;
    }
    
    var dateFormat = strYear + "-" + strMonth + "-" + strDay;

    return dateFormat;
};

sabio.ui.date.dateFormatLongAbbreviate = function (dateString) {
    /*
     Assumes entered value of date format used for stringifying a descriptive date thus 2017-01-14 would return Sat, Jan 14, 2017
    */


    var dtDate = new Date(dateString);
    var arrAbbrevDays = ['Sun', 'Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat'];
    var arrAbbrevMonths = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'];

    var numDayofWeek = dtDate.getUTCDay();

    var strYear = dtDate.getFullYear();
    var strMonth = dtDate.getMonth();
    var strDay = dtDate.getUTCDate();

 
    var dateFormat = arrAbbrevDays[numDayofWeek] + ", " + arrAbbrevMonths[strMonth] + " " + strDay + ", " + strYear;

    return dateFormat;
};