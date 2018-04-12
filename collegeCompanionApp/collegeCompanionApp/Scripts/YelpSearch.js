console.log("You're in the YelpSearch.js script");

$("#Location").keypress(function (e) {
    //If 'Enter' Key Pressed
    if (e.keyCode === 13) {
        start();
        e.preventDefault;
    }
});


$("#Search").click(start);

function start() {
    //Empty Everything for New Request
    $("#SearchResults").empty();
    $("#NoResults").empty();
    $("#Error").empty();

    //Get Location
    var location = $('#Location').val();
    //Term Selected
    var term = $("input[name='Term']:checked").val();
    //Console Output
    console.log("Location: " + location);
    console.log("Term: " + term);

    if (location == "") {
        console.log("No Location Entered");
        //No location entered
        $("#NoResults").text("Please Set A Location");
        return false;
    }

    //Create URL
    var fields = "location=" + location + "&term=" + term;
    var url = "YelpSearch?" + fields;
    url = url.replace(/ /g, "%20"); //replace spaces with '%20'
    console.log("URL: " + url);

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
    //Businesses Data
    var business = data.businesses;

    var x = 0;
    //Number of Businessess
    while (x < data.total) {
        if (business[x] == null) {
            break;
        } else {
            x++;
        }
    }

    //Number of Businessess
    var totalResults = x;
    console.log("Total Businessess: " + totalResults);

    if (totalResults > 0) { //Results Found

        $("#Results").css("display", "Block"); //Enable Display 

        for (i = 0; i < totalResults; i++) {

            //Get Data
            var name = business[i].name;
            var city = business[i].location.city;
            var address = business[i].location.address1;
            var rating = business[i].rating;
            var url = business[i].url;

            //Display Data onto Table
            $("#SearchResults").append("<tr><td>" + name
                + "</td><td>" + city
                + "</td><td>" + address
                + "</td><td>" + rating
                + "</td><td>" + "<a href=" + url + "style='display:block';>" + name + " Page</a></td></tr>");
            
        }

    } else { //No Results Found
        $("#NoResults").text("No Results Found!");
    }

}


// Ajax Error 
function errorOnAjax(e) {
    console.log("Error on Ajax: " + e.error);
    $("#Error").text("Could not execute search, try specifying a more exact location.");
    return false;
}
