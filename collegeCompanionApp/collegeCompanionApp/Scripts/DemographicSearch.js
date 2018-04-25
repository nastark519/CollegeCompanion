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

function start() {
    //Empty Everything for New Request
    $("#Results").css("display", "none");
    $("#SearchResults").empty();
    $("#NoResults").empty();
    $("#Error").empty();

    //Get User Input Zipcode
    var zipcode = $('#Zipcode').val();
    //Console Output
    console.log("Zipcode: " + zipcode);
    console.log("Zip Length: " + zipcode.length);

    //Check to see if Zipcode is a 5-digit zipcode
    if (zipcode.length != 5) {
        console.log("Zipcode length is not 5-digit long");
        //Not a 5-digit zipcode
        $("#NoResults").text("Please Enter a 5-digit Zipcode");
        return false;
    }

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
        success: getSecondAges,
        error: errorOnAjax
    });
}


function getSecondAges(data) {

    //Create First URL
    var fields = "latitude=" + latitude + "&longitude=" + longitude;
    var variables = "&variables=spop0_4,spop5_9,spop10_14,spop15_19,spop20_24,spop25_29,spop30_34,spop35_39,spop40_44,spop45_49"
    var url = "DemographicSearch?" + fields + variables;
    url = url.replace(/ /g, "%20"); //replace spaces with '%20'
    //Max of 10 variables per call
    //Second Ajax Call
    secondAjaxCall(url);

}

function successSearch(data) {

    console.log("Successful Search!"); 

    if (data.success == true) { //Results Found

        //Properties Data
        var prop = data.properties;

        //Sets Address Header
        $("#Address").text(address);

        $("#Results").css("display", "Block"); //Enable Display 

        console.log("Projection Population: " + prop.pstotpop);

        //Display Data onto List
        $("#SearchResults").append('<li class="list-group-item"><b>Total Population</b>: ' + prop.pstotpop + '</li>' +
            '<li class="list-group-item"><b>Median Age</b>: ' + prop.psmedage + '</li>' +
            '<li class="list-group-item">Third item</li>');


    } else { //No Results Found
        $("#NoResults").text("No Results Found!");
    }

}


// Ajax Error 
function errorOnAjax(e) {
    console.log("Error on Ajax: " + e.error);
    $("#Error").text("Could not execute Search");
    return false;
}
