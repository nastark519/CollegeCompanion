﻿console.log("You're in the SearchResults.js script");

// Load start() when page starts
window.onload = start;

// Global Variables
var degree;
var degreeType;

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

function successSearch(data) {
    var schools = data.metadata.total; // Total number of schools found
    console.log("Total Results: " + schools); // Display Total Results

    if (schools > 0) { // If Schools Found...
        // Clear Error message & Past Results
        $("#NotFound").empty();
        $("#Results").empty();

        var schoolDegreeType = "2015.academics.program." + degreeType + "." + degree; // Degree to look for

        for (i = 0; i <= schools; i++) {
            if (data.results[i]) {
                // Get data into variables
                var accreditor = data.results[i]["school.accreditor"];
                var ownership = data.results[i]["school.ownership"];
                var tuition = data.results[i]["school.tuition_revenue_per_fte"];
                tuition = tuition.toLocaleString(); // Convert Object to String
                var acceptRate = data.results[i]["2015.admissions.admission_rate.overall"];
                var schoolDegree = data.results[i][schoolDegreeType];
                var schoolURL = data.results[i]["school.school_url"];
                var collegeName = data.results[i]["school.name"];
                //setting up these next two vars for my zillow call.
                var state = data.results[i]["school.state"];
                var city = data.results[i]["school.city"];

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

                var zipCode = 97128;
                //http://localhost:30375/Home/SaveData?userID=2&name=blah&stateName=blah&city=blah&zipCode=92000&accreditor=blah&degree=blah&degreeType=blah&ownership=1&cost=10000

                //This view is KING
                $("#Results").append(
                    '<div style="float:left; width:20em;margin-right:2em;">' +
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
            }
        }
    } else { //School Not found
        $("#NotFound").text("No Schools Found!");
    }

}


function getResultString(collegeName, state, city, accreditor, ownership, tuition, schoolDegree, schoolDegreeType, acceptRate, schoolURL) {

    return '<div style="float:left; width:20em;margin-right:2em;">' +
        '<div class="panel panel-info">' +
        '<div class="panel-heading text-center panel-height">' +
        '<div class="row">' +
        '<div class="col-sm-1">' +
        '<h2>' + //Name,StateName,City,Accreditor,Ownership,Cost
        '<a class="fa fa-heart-o" href="@Url.Action("SaveData", "Home", new {Name=' + collegeName + '&StateName=' + state + '&City=' + city +
            '&Accreditor=' + accreditor + '&Ownership=' + ownership + '&Cost=' + tuition + '&ZipCode=' + zipCode +
        '&Degree=' + schoolDegree + '&DegreeType=' + schoolDegreeType + '&AcceptanceRate=' + acceptRate + '&UserID=' + companionID +  '})"></a>' +      // This this a starting point fot sp4 for fav.
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
        '&emsp; State: ' + state +
        '</div>' +
        '<div class="col-sm-6">' + // City
        'City: ' + city +
        '</div>' +
        '</div>' +
        '</div>' +
        '<div class="row">' + // Degree Selected
        '&emsp; Degree Selected: ' + schoolDegree +
        '</div>' +
        '<div class="row">' + // Ownership
        '&emsp; Ownership: ' + ownership +
        //'</div>' +
        //        '<div class="row">' +
        //            '&emsp; Accreditor: ' + accreditor +
        //'</div>' +
        '</div>' +
        '<div class="row">' + // Acceptance Rate
        '&emsp; Acceptance Rate: ' + acceptRate + "%" +
        '</div>' +
        '<div class="row">' + // School URL
        '&emsp; College Website: ' + '<a href=' + schoolURL + '><u>' + schoolURL + '</u></a>' +
        '</div>' +
        '</div>' +
        '</div>' +
        '</div>';
}


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
