
//Travel Search, using Walk Score API
//Gets a Location from the User and returns the rating of Walk, Bike & Transit

var addressInput;
var cityInput;
var stateInput;
var zipInput;
var latitude;
var longitude;
var url;

//Get Input From User
$("#submit").click(function () {
    addressInput = "";//$("#addressInput").val(); //Get address information from user.
    console.log(addressInput); //Verify we're getting back the data we expect.

    var collegeInput = $("#collegeInput").val(); // Get Zipcode, State; City Values
    console.log("College Input: " + collegeInput); // Console Check

    cityInput = collegeInput.slice(9,);//$("#cityInput").val(); //Get city information from user.
    console.log("City: " + cityInput); //Verify we're getting back the data we expect.

    stateInput = collegeInput.slice(6,8);//$("#stateInput").val().toUpperCase(); //Get state information from user.
    console.log("State: " + stateInput); //Verify we're getting back the data we expect.

    zipInput = collegeInput.slice(0,5);//$("#zipInput").val(); //Get zipcode information from user.
    console.log("Zipcode: " + zipInput); //Verify we're getting back the data we expect.
    
    console.log("URL before ajax: " + "https://maps.googleapis.com/maps/api/geocode/json?address=" + cityInput + "&components=postal_code:" + zipInput + "&sensor=false&key=AIzaSyCS8ZI4cCMMVdu1SWSSFJ1wnX4ZZniB8zU");

    $.ajax({ //Took off " + cityInput + " from URL 
        url: "https://maps.googleapis.com/maps/api/geocode/json?address=&components=postal_code:" + zipInput + "&sensor=false&key=AIzaSyCS8ZI4cCMMVdu1SWSSFJ1wnX4ZZniB8zU",
        method: "POST",
        success: getCoords,
        error: errorOnAjax
    });
});

//Gets the longitutde and latitude for API call
function getCoords(data) {
    latitude = data.results[0].geometry.location.lat;
    longitude = data.results[0].geometry.location.lng;
    console.log("Lat: " + latitude + "Long: " + longitude);
    url = "?zipInput=" + zipInput + "&addressInput=" + addressInput + "&cityInput=" + cityInput + "&stateInput=" + stateInput + "&longitude=" + longitude + "&latitude=" + latitude;
    url = url.replace(/ /g, '') // Remove White Space
    console.log(url);
    getURL(url);
}

//runs the AJAX call 
function getURL(url) {
    //Requesting JSon through AJAX
    $.ajax({
        type: "GET",
        dataType: "json",
        url: "./WalkScoreSearch" + url, //Name of the controller presenting the URL, the "./" helps ensure its the current controller
        success: displaySearch,
        error: errorOnAjax
    });
}

//If something goes wrong it throws this error for AJAX
function errorOnAjax() {
    console.log("error");
}

//Displays results in designed format
function displaySearch(results) {
    console.log(results);
    $(".travelResults").empty(); //Prevents Search Duplicates

    var searchContent = ""; //String to creates out View Results
    searchContent = '<div class="panel-group">';
    searchContent += '<div class="panel panel-info">';
    searchContent += '<div class="panel-heading">';
    searchContent += '<img class="img_small" src="' + results["logo_url"] + '" /> ';
    searchContent += '<span style="font-size: 18pt;color: coral;vertical-align: middle;">' + results["walkscore"] + '</span>';
    searchContent += '<a href="' + results["more_info_link"] + '">';
    searchContent += '<img class="img_small" src="' + results["more_info_icon"] + '"/>';
    searchContent += '</a>';
    searchContent += '</div>';
    searchContent += '<div class="panel-body">';
    searchContent += '<p style="font-size: 11pt;color: steelblue;vertical-align: middle;"> <strong>Description:</strong> ' + results["description"] + '</p>';
    searchContent += '</div>';
    searchContent += '<div class="panel-footer">';
    searchContent += '<a style="font-size:8pt;color:darkgray;" href="' + results["help_link"] + '">' + 'For How Walks Score Works!' + '</a>';
    searchContent += '</div>';
    $(".travelResults").append(searchContent);
}

//Takes any unpleasant results in the view and makes them "No Data Found"
function convertToNA(results) {
    if (typeof results === 'undefined' || results === null) {
        results = "No Data Found";
    }
    return results;
}

