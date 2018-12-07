sabio.ui.timespan = sabio.ui.timespan || {};

sabio.ui.timespan.timeMinuteByDataFormat = function (value) {
    /*
     Assumes entered value is date format of timespan HH:MM:SS to return the the count of minutes in a day ranging from 0 to 1399 
     So a value of 14:44:00  would return 884.
     */

    if (value.length == 8) {
        var numHour = parseInt(value.slice(0, 2));
        var numMin = parseInt(value.slice(3, 5));
        var numTotalMinutes = Math.floor( (numHour * 60) + numMin );
        value = numTotalMinutes;
    }

    return value;
};

sabio.ui.timespan.timeFormatByDataFormat = function (value) {
    /*
     Assumes entered value is date format of timespan HH:MM:SS to return the the count of minutes in a day ranging from 0 to 1399 
     So a value of 14:44:00  would equal 884 and references another function to return 2:44 PM
     */

    if (value.length == 8) {
        var numHour = parseInt(value.slice(0, 2));
        var numMin = parseInt(value.slice(3, 5));
        var numTotalMinutes = Math.floor((numHour * 60) + numMin);
        value = sabio.ui.timespan.timeFormatByMinute(numTotalMinutes);
    }

    return value;
};

sabio.ui.timespan.timeDataFormatByMinute = function (value) {
    /*
     Assumes entered value is the count of minutes in a day ranging from 0 to 1399 
     An ideal outcome would return a 24 hour format. So a value of 884 would return 14:44:00 .
     */

    if (0 <= value < 1400) {

        var strHour = Math.floor(value/60);
        var strMin = Math.floor(value - (strHour * 60));

        if (strHour < 10) {
            strHour = '0' + strHour;
        }

        if (strMin < 10) {
            strMin = '0' + strMin;
        }
  
        value = strHour + ":" + strMin + ":" + "00";
    }

    return value;
};

sabio.ui.timespan.timeFormatByMinute = function (value) {
    /*
     Assumes entered value is the count of minutes in a day ranging from 0 to 1399 
     An ideal outcome would return a 12 hour format. So a value of 884 would return 2:44 PM.
    */

    if (0 <= value < 1400) {

        var strHour = Math.floor(value / 60);
        var strMin = Math.floor(value - (strHour * 60));

        var strMeridian = "AM";

        if (strHour >= 12) {
            strMeridian = "PM";
        }

        if (strHour > 12) {
            strHour -= 12;
        }

        if (strMin > 0) {
            if (strMin < 10) {
                strMin = '0' + strMin;
            }
            value = strHour + ":" + strMin + " " + strMeridian;
        } else {
            value = strHour + " " + strMeridian;
        }
    }

    return value;
};

sabio.ui.timespan.timeDurationByMinuteRange = function (start, end) {
    /*
     Assumes entered start and end values are the count of minutes in a day ranging from 0 to 1399 and translates the difference in time to and english expression
     An ideal outcome would return a disription of hous and minutes; thus, a range from 840 to 975 would return 2 hours and 15 minutes.
    */

    var value = "The range of numbers in minutes should be between 0 and 1399. Also, the parameters need to be in the correct order."

    if ((0 <= start < 1400) && (0 <= end < 1400) && (start < end)) {

        value = end - start;
        var strHour = Math.floor(value / 60);
        var strMin = Math.floor(value - (strHour * 60));

        if (strHour == 0) {
            value = "";
        } else if (strHour == 1) {
            value = strHour + " hour";
        } else {
            value = strHour + " hours";
        }

        if (value.length && strMin > 0) {
            value = value + " and ";
        }

        if (strMin == 1) {
            value = value + strMin + " minute";
        } else if (strMin > 1) {
            value = value + strMin + " minutes";
        } else {
            // returns value because of 0 minutes
        }
    }

    return value;
};