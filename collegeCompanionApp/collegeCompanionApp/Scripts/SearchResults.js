console.log("You're in the SearchResults.js script");

// Load start() when page starts
window.onload = start;

// Global Variables
var degree;
var degreeType;

// An array that holds the divs on the school information.
var pages = [];

var indexPage = 0;

function start() {

    // Gets the Current URL
    var currentURL = window.location.href;
    // Console Check URL
    console.log("Current URL: " + currentURL);

    // Get vaules from current URL
    var schoolName = getAllUrlParams(currentURL).schoolName;
    var state = getAllUrlParams(currentURL).state;
    var city = getAllUrlParams(currentURL).city;
    var accreditor = getAllUrlParams(currentURL).accreditor;
    var ownership = getAllUrlParams(currentURL).ownership;
    var cost = getAllUrlParams(currentURL).cost;
    var upperBound = getAllUrlParams(currentURL).upperBound;
    var lowerBound = getAllUrlParams(currentURL).lowerBound;
    var acceptRate = getAllUrlParams(currentURL).acceptanceRate;
    degree = getAllUrlParams(currentURL).degree;
    degreeType = getAllUrlParams(currentURL).degreeType;
    // Add lower and upper bound to school tuition
    var schoolTuition = lowerBound + ".." + upperBound;

    // Console Check
    console.log("School Name: " + schoolName);
    console.log("State: " + state);
    console.log("City: " + city);
    console.log("Ownership: " + ownership);
    console.log("LowerBound: " + lowerBound);
    console.log("UpperBound: " + upperBound);
    console.log("School Tuition: " + schoolTuition);
    console.log("Acceptance Rate:" + acceptRate);
    console.log("Degree: " + degree);
    console.log("Degree Type: " + degreeType);

    // Set vaules for JSON request
    var values = "school.name=" + schoolName + "&school.state=" + state + "&school.city=" + city
        + "&school.accreditor=" + accreditor + "&school.ownership=" + ownership
        + "&school.tuition=" + schoolTuition + "&school.admission_rate=" + acceptRate
        + "&school.degree=" + degree + "&school.degreeType=" + degreeType;

    // Search in HomeController
    var url = "Search?" + values;
    // Console Check Ajax Call URL
    console.log("Ajax URL: " + url);


    // Requesting JSon through Ajax
    $.ajax({
        type: "GET",
        dataType: "json",
        url: url,
        success: successSearch,
        error: errorOnAjax
    });
}

//On success of AJAX call
function successSearch(data) {
    var i = 0;
    var xi = 0;
    var schools = data.metadata.total; // Total number of schools found

    // since we are only doing 100 schools set to 100 if total returns > 100 school
    // we are doing this because otherwise we would need to do another api call.
    if (schools > 100) {
        schools = 100;
    }

    console.log("Total Results: " + schools); // Display Total Results
    var j = 0;
    // add an action listener that will hear a onclick here for the paganation.

    if (schools > 0) { // If Schools Found...
        // Clear Error message & Past Results
        $("#NotFound").empty();
        $("#Results").empty();

        
        
        var schoolDegreeType = "2015.academics.program." + degreeType + "." + degree; // Degree to look for

        while (12 < (schools - (i * 12))) {

            var page = [];

            for (j = 0; j < 12; j++) { // replaced schools with the number 5 to test paganation.

            if (data.results[xi]) {
                // Get data into variables
                var accreditor = data.results[xi]["school.accreditor"];
                var ownership = data.results[xi]["school.ownership"];
                var tuition = data.results[xi]["school.tuition_revenue_per_fte"];
                tuition = tuition.toLocaleString(); // Convert Object to String
                var acceptRate = data.results[xi]["2015.admissions.admission_rate.overall"];
                var schoolDegree = data.results[xi][schoolDegreeType];
                var schoolURL = data.results[xi]["school.school_url"];
                var collegeName = data.results[xi]["school.name"];
                var state = data.results[xi]["school.state"];
                var city = data.results[xi]["school.city"];
                var zipCode = data.results[xi]["school.zip"];

                if (accreditor === null) { // If accreditor is NULL than display 'N/A'
                    accreditor = "None";
                }

                if (acceptRate === null) { // If acceptance rate is NULL than display 'N/A'
                    acceptRate = "None";
                } else { // Else get acceptance rate percentage
                    acceptRate = (acceptRate * 100).toFixed(2); // Round to second decimal place
                }

                var ownershipStr;

                if (ownership === 1) { // If ownership is 1, it's public
                    ownershipStr = "Public";
                } else if (ownership === 2) { // If ownership is 2, it's Private Non-Profit
                    ownershipStr = "Private Non-Profit";
                } else { // Else it's Private For-Profit
                    ownershipStr = "Private For-Profit";
                }

                if (schoolDegree === 2) { // If School Degree is 2, Program Offered with exclusibely education
                    schoolDegree = "Program Offered through an Exclusively Distance-Education Program";
                } else if (schoolDegree === 1) { // If School Degree is 1, Program Offered
                    schoolDegree = "Program Offered!";
                } else { // User did not select a Degree
                    schoolDegree = "No Degree Selected";
                }

                if (schoolURL[0] === 'w') { // If School URL starts with 'w' for 'www'
                    schoolURL = "https://" + schoolURL; // Add 'https://' to the School URL
                }
                if (schoolURL.endsWith("/")) {
                    schoolURL = schoolURL.slice(0, schoolURL.length - 1);
                }

                if (zipCode.length > 5) {
                    zipCode = zipCode.slice(0, 5);
                }

                //var zipCode = 97128;
                //http://localhost:30375/Home/SaveData?userID=2&name=blah&stateName=blah&city=blah&zipCode=92000&accreditor=blah&degree=blah&degreeType=blah&ownership=1&cost=10000

                //The resulting view and its designed formatting
                var resultString = '<div style="float:left; width:20em;margin-right:2em;">' +
                    '<div class="panel panel-info">' +
                    '<div class="panel-heading text-center panel-height">' +
                    '<div class="row">' +
                    '<div class="col-sm-1">' +
                    '<h2>' + //Name,StateName,City,Accreditor,Ownership,Cost
                    '<a class="fa fa-heart-o" href="/Home/SaveData'
                    + '?userID='
                    + companionID
                    + '&name='
                    + collegeName
                    + '&stateName='
                    + state
                    + '&city='
                    + city
                    + '&zipCode='
                    + zipCode
                    //Accreditor causes save errors, need to figure out what's going on here.
                    + '&accreditor='
                    + 'None'
                    + '&degree='
                    + schoolDegree
                    + '&degreeType='
                    //Degree Type unreachable, need to combine our horrible moshpit of appended code.
                    + degreeType
                    + '&ownership='
                    + ownership
                    + '&cost='
                    + tuition
                    + '"></a>' +      // This this a starting point fot sp4 for fav.
                    '</h2>' +
                    '</div>' +
                    '<div class="col-sm-offset-0"></div>' +
                    '<div class="col-sm-9">' + // College Name
                    '<div class="spaceLeft">' +
                    //So the math function below takes the line height, divides it by the number of characters and presents the centered characters
                    //within the height of the panel header.
                    '<h5 class="ccPanelHeader" style="line-height:' + 45 / (Math.ceil(collegeName.length / 30)) + 'px;"' + ">" +
                    collegeName +
                    '</h5>' +
                    '</div>' +
                    '</div>' +
                    '</div>' +
                    '</div>' +
                    '<div class="panel-body text-primary ccPanelBody">' +
                    '<div class="row">' +
                    '<h4 class="text-center">' +
                    '$' + tuition + '/year' +
                    '</h4>' +
                    '<div class="row" style="margin-top:5%;">' +
                    '<div class="col-sm-6">' + // State
                    '&emsp; <b> State</b>: ' + state +
                                '</div>' +
                    '<div class="col-sm-6">' + // City
                    '<b>City</b>: ' + city +
                                '</div>' +
                                    '</div>' +
                                '</div>' +
                                '<div class="row">' + // Degree Selected?
                                    '&emsp; <b>Degree Selected</b>: ' + schoolDegree +
                        '</div>' +
                                '<div class="row">' + // Ownership
                    '&emsp; <b>Ownership</b>: ' + ownershipStr +
                        //'</div>' +
                        //        '<div class="row">' +
                        //            '&emsp; Accreditor: ' + accreditor +
                        //'</div>' +
                        '</div>' +
                                '<div class="row">' + // Acceptance Rate
                                    '&emsp; <b>Acceptance Rate</b>: ' + acceptRate + "%" +
                    '</div>' +
                    '</div>' +
                    '<div class="panel-footer" style="text-align:center">' + // School URL
                    '<a href=' + schoolURL + '><u>' + schoolURL + '</u></a>' +
                    '</div>' +
                        '</div>' +
                    '</div>'
                );
                xi++;
            }
        }
            pages[i++] = page;
        }

        $("#Results").append(pages[0]);
    }
    else { //School Not found
        $("#NotFound").text("No Schools Found!");
    }
}

// This function is for pagenation.
function pageNum(numb) {
    // Clear Error message & Past Results
    $("#NotFound").empty();
    $("#Results").empty();

    if (pages[numb]) {
        $("#Results").append(pages[numb]);
    }
    else { //School Not found
        $("#NotFound").text("No Other Schools Found.");
    }
    
}

//Error on AJAX
function errorOnAjax() {
    console.log("error on Ajax");
    $("#NotFound").text("Error on Ajax!"); // Display Error if ajax error
    return false;
}


//Get data from Current URL
//Credit: https://www.sitepoint.com/get-url-parameters-with-javascript/
function getAllUrlParams(url) {

    // get query string from url (optional) or window
    var queryString = url ? url.split('?')[1] : window.location.search.slice(1);

    // we'll store the parameters here
    var obj = {};

    // if query string exists
    if (queryString) {

        // stuff after # is not part of query string, so get rid of it
        queryString = queryString.split('#')[0];

        // split our query string into its component parts
        var arr = queryString.split('&');

        for (var i = 0; i < arr.length; i++) {
            // separate the keys and the values
            var a = arr[i].split('=');

            // in case params look like: list[]=thing1&list[]=thing2
            var paramNum = undefined;
            var paramName = a[0].replace(/\[\d*\]/, function (v) {
                paramNum = v.slice(1, -1);
                return '';
            });

            // set parameter value (use 'true' if empty)
            var paramValue = typeof (a[1]) === 'undefined' ? true : a[1];

            //// (optional) keep case consistent
            //paramName = paramName.toLowerCase();
            //paramValue = paramValue.toLowerCase();

            // if parameter name already exists
            if (obj[paramName]) {
                // convert value to array (if still string)
                if (typeof obj[paramName] === 'string') {
                    obj[paramName] = [obj[paramName]];
                }
                // if no array index number specified...
                if (typeof paramNum === 'undefined') {
                    // put the value on the end of the array
                    obj[paramName].push(paramValue);
                }
                // if array index number specified...
                else {
                    // put the value at that index number
                    obj[paramName][paramNum] = paramValue;
                }
            }
            // if param name doesn't exist yet, set it
            else {
                obj[paramName] = paramValue;
            }
        }
    }

    return obj;
}
