console.log("You're in the Demographic Search JavaScript file");

$("#Zipcode").keypress(function (e) {
    //If 'Enter' Key Pressed
    if (e.keyCode === 13) {
        start();
        e.preventDefault;
    }
});


$("#Search").click(start);

//Global Variables
var latitude = '';
var longitude = '';
var address = '';
//Array of Ages
var ages = [];
//Array of Age Percentage
var agePercent = [];

function start() {
    //Empty Everything for New Request
    $("#Results").css("display", "none");
    $("#SearchResults").empty();
    $("#NoResults").empty();
    $("#Error").empty();
    ages = [];
    agePercent = [];

    //Get User Input Zipcode
    var zipcode = $('#Zipcode').val();
    //Console Output
    console.log("Zipcode: " + zipcode);
    console.log("Zip Length: " + zipcode.length);


    //Check to see if Zipcode is a 5-digit zipcode & Numeric
    if (zipcode.length != 5) {
        console.log("Zipcode Length is not 5-Digit long");
        //Not a 5-digit zipcode
        $("#Error").text("Please Enter a 5-Digit Zipcode");
        return false;
    } else if (Number.isInteger(parseInt(zipcode)) == false) { //Checks if Zipcode is Numeric
        console.log("Zipcode Not Numeric");
        //Not a numeric input
        $("#Error").text("Only enter a 5-Digit Zipcode");
        return false;
    }

    console.log("Good Zipcode!"); //Passed as a Good Zipcode

    //Credit: https://stackoverflow.com/questions/6100264/google-maps-get-latitude-and-longitude-from-zip-code
    //Get Latidude and Longitude 
    $.ajax({
        url: "https://maps.googleapis.com/maps/api/geocode/json?components=postal_code:" + zipcode + "&sensor=false",
        method: "GET",
        success: getCoordinates,
        error: errorOnAjax
    });
}

function getCoordinates(data) {
    //Get Latitude
    latitude = data.results[0].geometry.location.lat;
    //Get Longitude
    longitude = data.results[0].geometry.location.lng;
    //Get Formatted Address
    address = data.results[0].formatted_address;
    //Checks if Lat/long is found
    console.log("Latitude= " + latitude + " - Longitude= " + longitude);
    //Address Output
    console.log("Address: " + address);

    //Create First URL
    var fields = "latitude=" + latitude + "&longitude=" + longitude;
    var variables = "&variables=spop0_4,spop5_9,spop10_14,spop15_19,spop20_24,spop25_29,spop30_34,spop35_39,spop40_44,spop45_49"
    var url = "DemographicSearch?" + fields + variables;
    url = url.replace(/ /g, "%20"); //replace spaces with '%20'
    //Max of 10 variables per call
    //First Ajax Call
    firstAjaxCall(url);

    //Requesting JSon through Ajax
    //$.ajax({
    //    type: "GET",
    //    dataType: "json",
    //    url: url,
    //    success: successSearch,
    //    error: errorOnAjax
    //});
}

function firstAjaxCall(url) {
    console.log("First Ajax Call: " + url);

    //Requesting JSon through Ajax
    $.ajax({
        type: "GET",
        dataType: "json",
        url: url,
        success: getFirstAges,
        error: errorOnAjax
    });
}

function getFirstAges(data) {
    if (data.success == true) { //Results Found

        //Age Properties Data
        var age = data.properties;

        //Push Ages into Array
        ages.push(age.pspop0_4, age.pspop5_9, age.pspop10_14, age.pspop15_19, age.pspop20_24,
            age.pspop25_29, age.pspop30_34, age.pspop35_39, age.pspop40_44, age.pspop45_49);
        //Check First set of Ages
        console.log("First Set of Ages: " + ages);

        //Create Second URL
        var fields = "latitude=" + latitude + "&longitude=" + longitude;
        var variables = "&variables=spop50_54,spop55_59,spop60_64,spop65_69,spop70_74,spop75_79,spop80_84,spop85p,stotpop,smedage"
        var url = "DemographicSearch?" + fields + variables;
        url = url.replace(/ /g, "%20"); //replace spaces with '%20'
        //Max of 10 variables per call
        //Second Ajax Call
        secondAjaxCall(url);


    } else { //No Results Found
        $("#NoResults").text("No Results Found!");
    }

}


function secondAjaxCall(url) {
    console.log("Second Ajax Call: " + url);

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

    console.log("Successful Search!"); 

    if (data.success == true) { //Results Found

        //Properties Data
        var prop = data.properties;

        //Push Second Set Ages into Array
        ages.push(prop.pspop50_54, prop.pspop55_59, prop.pspop60_64, prop.pspop65_69,
            prop.pspop70_74, prop.pspop75_79, prop.pspop80_84, prop.pspop85p);

        //Find Percentage of Ages
        for (i = 0; i < ages.length; i++) {

            var num = ages[i] / prop.pstotpop;
            num = (num * 100).toFixed(2); //Round 
            agePercent.push(num);

        }


        //Check All Ages
        console.log("All Ages: " + ages);

        //Sets Address Header
        $("#Address").text(address);

        $("#Results").css("display", "Block"); //Enable Display 

        console.log("Projection Population: " + prop.pstotpop);

        //Display Data onto List
        $("#SearchResults").append('<li class="list-group-item"><b>Total Population</b>: ' + prop.pstotpop + '</li>' + //Total Population
            '<li class="list-group-item"><b>Median Age</b>: ' + prop.psmedage + '</li>'); //Median Age 

        setAges(); //Adds Ages & percentage to List

        console.log("Ages.Length: " + ages.length + ", agePercent.length: " + agePercent.length)


    } else { //No Results Found
        $("#NoResults").text("No Results Found!");
    }

}

function setAges() {
    var lowAge = 0; //Lower Bound Age
    var highAge = 4; //Upper Bound Age

    // Display Ages onto List with percentage
    for (i = 0; i < ages.length - 1; i++) {
        $("#SearchResults").append('<li class="list-group-item"><b>Ages ' + lowAge + '-' + highAge +
            '</b>: ' + ages[i] + ',  <i>' + agePercent[i] + '%</i></li>');
        lowAge += 5;
        highAge += 5;
    }

    //Age > 85 add to List
    $("#SearchResults").append('<li class="list-group-item"><b>Age > 85</b>: ' +
        ages[i] + ',  <i>' + agePercent[i] + '%</i></li>');
    
}


// Ajax Error 
function errorOnAjax(e) {
    console.log("Error on Ajax: " + e.error);
    $("#Error").text("Could not execute Search");
    return false;
}
