console.log("You're in the SearchResults.js script");

window.onload = start;

function start() {

    var currentURL = window.location.href;
    console.log("URL: " + currentURL);

    var schoolName = getAllUrlParams(currentURL).schoolName;
    var state = getAllUrlParams(currentURL).state;
    var city = getAllUrlParams(currentURL).city;
    var accreditor = getAllUrlParams(currentURL).accreditor;
    var ownership = getAllUrlParams(currentURL).ownership;
    var cost = getAllUrlParams(currentURL).cost;
    var upperBound = getAllUrlParams(currentURL).upperBound;
    var lowerBound = getAllUrlParams(currentURL).lowerBound;
    var acceptRate = getAllUrlParams(currentURL).acceptanceRate;
    var schoolTuition = "";

    console.log("School Name: " + schoolName);
    console.log("State Name: " + state);
    console.log("City: " + city);
    console.log("Accreditor: " + accreditor);
    console.log("Ownership: " + ownership);

    if (cost !== null && upperBound === "") {
        schoolTuition = "&school.tuition_revenue_per_fte=" + cost;
        console.log("Cost: " + cost);
    }

    if (upperBound !== "" && cost === null || cost === "") {
        schoolTuition = "&school.tuition_revenue_per_fte=" + lowerBound + ".." + upperBound;
        console.log("UpperBound: " + upperBound);
        console.log("LowerBound: " + lowerBound);
    }

    if (acceptRate === null || acceptRate === "undefined" || acceptRate === "") {
        console.log("Acceptance Rate is Empty!");
        acceptRate = "1";
        console.log("Acceptance Rate: " + acceptRate);
    } else {
        acceptRate = acceptRate / 100;
        console.log("Acceptance Rate: " + acceptRate);
    }

    //var fields = "&_fields=school.name,school.state,school.city";
    var values = "school.name=" + schoolName + "&school.state=" + state + "&school.city=" + city
        + "&school.accreditor=" + accreditor + "&school.ownership=" + ownership + schoolTuition
        + "&2015.admissions.admission_rate.overall__range=0.1.." + acceptRate;
    var url = "Search?" + values;

    console.log("URL is " + url);

    //Requesting JSon through Ajax
    $.ajax({
        type: "GET",
        dataType: "json",
        url: url,
        success: successSearch,
        error: errorOnAjax
    });
}

function successSearch(data) {
    var schools = data.metadata.total;//Total number of schools
    console.log("Total Results: " + schools);

    if (schools > 0) {

        $("#NotFound").empty();
        $("#Results").empty();

        for (i = 0; i <= schools; i++) {
            if (data.results[i]) {

                var accreditor = data.results[i]["school.accreditor"];
                var ownership = data.results[i]["school.ownership"];
                var tuition = data.results[i]["school.tuition_revenue_per_fte"];
                var acceptRate = data.results[i]["2015.admissions.admission_rate.overall"];

                //setting up these next two vars for my zillow call.
                var state = data.results[i]["school.state"];
                var city = data.results[i]["school.city"];

                var collegeName = data.results[i]["school.name"];


                if (accreditor === null) {

                    accreditor = "N/A";
                }

                if (acceptRate === null) {
                    acceptRate = "N/A";
                }

                if (ownership === 1) {
                    ownership = "Public";
                } else if (ownership === 2) {
                    ownership = "Private Non-Profit";
                } else {
                    ownership = "Private For-Profit";
                }

                tuition = tuition.toLocaleString();

                console.log("Tuition: " + tuition);

                $("#Results").append(
                    '<div class="col-sm-5">' +
                        '<div class="panel panel-info">' +
                            '<div class="panel-heading text-center">' +
                                '<div class="row">' +
                                    '<div class="col-sm-1">' +
                                        '<h2>' + //Name,StateName,City,Accreditor,Ownership,Cost
                    '<a class="fa fa-heart-o" href="@Url.Action("SaveData", "Home", new {Name=' + collegeName + ',StateName=' + state + ',City=' + City +
                    ',Accreditor' + accreditor + ',Ownership=' + ownership + ',Cost=' + tuition + '})"></a>' +      // This this a starting point fot sp4 for fav.
                                '</h2>' +
                                    '</div>' +
                                    '<div class="col-sm-offset-0"></div>' +
                                    '<div class="col-sm-9">' +
                                        '<div class="spaceLeft">' +
                                            '<h5 class="ccheader">' +
                                                collegeName +
                                    '</h5>' +
                                        '</div>' +
                                    '</div>' +
                                    '<div class="col-sm-pull-1">' +
                                        '<h2>' +
                                            '<i class="fa fa-sticky-note-o"></i> ' +     // Needs to be for saving.
                                '</h2>' +
                                    '</div>' +
                                '</div>' +
                            '</div>' +
                            '<div class="panel-body text-primary" style="margin-top:-5%;">' +
                                '<div class="row">' +
                                    '<h4 class="text-center">' +
                                        '<i class="glyphicon glyphicon-usd"></i>' +
                                        tuition +
                                '/year' +
                            '</h4>' +
                                    '<div class="row" style="margin-top:5%;">' +
                    '<div class="col-sm-6">' +
                    '&emsp; State: ' + state +
                                '</div>' +
                    '<div class="col-sm-6">' +
                    'City: ' + city +
                                '</div>' +
                                    '</div>' +
                                '</div>' +
                                '<div class="row">' +
                                    '&emsp; Degree Being Saught' +
                        '</div>' +
                                '<div class="row">' +
                                    '&emsp; Ownership: ' + ownership +
                        '</div>' +
                                '<div class="row">' +
                                    '&emsp; Accreditor: ' + accreditor +
                        '</div>' +
                            '</div>' +
                        '</div>' +
                    '</div>'
                );              

                //$("#SearchResults").append("<tr><td>" + data.results[i]["school.name"]
                //    + "</td><td>" + accreditor
                //    + "</td><td>" + data.results[i]["school.state"]
                //    + "</td><td>" + data.results[i]["school.city"]
                //    + "</td><td>" + ownership + "</td></tr>");

                //I have put this at the end so I can just append to the div I want to.
                // a url for the zillow calls.
                //var theZillowApiUrl =
                    //"http://www.zillow.com/webservice/GetRegionChildren.htm?zws-id={APIKeyHere}&state=" + state + "&city=" + city;

                //var collegeRentsUrl = "CollegeRentsInArea?school.state=" + state + "&school.city=" + city;
                //Adding in an ajax call to zillow to get city and state added
                //as data comes into successSearch function
                //$.ajax({
                    //type: "GET",
                    //url: CollegeRentsUrl,
                    //dataType: "xml",
                    //success: rentCallCalc
                //});

                //function rentCallCalc(xml) {
                    //var zdex = 0;
                    //the number of zindexes are returned.
                    //var j = $(xml).find("zindex").length;
                    //$(xml).find("region").each(function () {
                        //var nextZdex = parseInt($(this).find("zindex"));
                        //zdex = zdex + nextZdex;
                    //});
                    //var rent = (zdex / j) * (12 / 1889);

                    //$(".panel-body text-primary").append(
                        //'<div class="row">' +
                        //'&emsp; Rent: ' + rent +
                        //' is the approximate median rent + an average of $200 for a metro area and - $200 for a more rural area.' +
                        //'</div>'
                    //);
                //}
=======
                    '<div class="panel panel-info">' +
                    '<div class="panel-heading text-center">' +
                    '<div class="row">' +
                    '<div class="col-sm-1">' +
                    '<h2>' +
                    '<i class="fa fa-heart-o"></i>' +
                    '</h2>' +
                    '</div>' +
                    '<div class="col-sm-offset-0"></div>' +
                    '<div class="col-sm-9">' +
                    '<div class="spaceLeft">' +
                    '<h5 class="ccheader">' +
                    data.results[i]["school.name"] +
                    '</h5>' +
                    '</div>' +
                    '</div>' +
                    '<div class="col-sm-pull-1">' +
                    '<h2>' +
                    '<i class="fa fa-sticky-note-o"></i> ' +
                    '</h2>' +
                    '</div>' +
                    '</div>' +
                    '</div>' +
                    '<div class="panel-body text-primary" style="margin-top:-5%;">' +
                    '<div class="row">' +
                    '<h4 class="text-center">' +
                    '<i class="glyphicon glyphicon-usd"></i>' +
                    tuition +
                    '/year' +
                    '</h4>' +
                    '<div class="row" style="margin-top:5%;">' +
                    '<div class="col-sm-6">' +
                    '&emsp; State: ' + data.results[i]["school.state"] +
                    '</div>' +
                    '<div class="col-sm-6">' +
                    'City: ' + data.results[i]["school.city"] +
                    '</div>' +
                    '</div>' +
                    '</div>' +
                    '<div class="row">' +
                    '&emsp; Degree Being Saught' +
                    '</div>' +
                    '<div class="row">' +
                    '&emsp; Ownership: ' + ownership +
                    '</div>' +
                    '<div class="row">' +
                    '&emsp; Accreditor: ' + accreditor +
                    '</div>' +
                    '<div class="row">' +
                    '&emsp; Acceptance Rate: ' + (acceptRate * 100) + "%" +
                    '</div>' +
                    '</div>' +
                    '</div>' +
                    '</div>' +
                    '</div>'
                );
>>>>>>> 6b9f2b9b12803a379651dbbdb993504fb9057e00
            }
        }
    } else { //School Not found
        $("#NotFound").text("No Schools Found!");
    }

}


function errorOnAjax() {
    console.log("error on Ajax");
    return false;
}


//Get data from URL
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
