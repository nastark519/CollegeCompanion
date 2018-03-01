
//Javascript Document for the StateSearch functionality
//Corresponding View: StateSearch.cshtml
//Heavily adapted from Daniel Tapia's code on School Search, credit where it is due!
console.log("Hello, I'm in the system!");

$("#StateSearch").keypress(function (e) {

    //If 'Enter' Key Pressed

    if (e.keyCode === 13) {

        start();

        e.preventDefault;

    }

});

//When "Search" button clicked

$("#Search").click(start);
var oldState; //Previous State Name
var pages = 0; //Number of Pages
var page = 0; //Current Page

$("#Next").click(nextPage); //Next 10 results
$("#Previous").click(prevPage); //Previous 10 results

function nextPage() {
    if (page < pages) {
        page += 1;
        start();
    }
}

function prevPage() {
    if (page > 0) {
        page -= 1;
        start();
    }
}

function start() {

    var APIKey = "nKOePpukW43MVyeCch1t7xAFZxR2g0EFS3sHNkQ4";

    var fields = "school.name,school.state,school.city,school.accreditor,school.ownership";

    var state = $("#StateSearch").val(); //Get User Input

    oldState = state;
    if (state != oldState) {
        page = 0; //Reset Page
    }

    if (state == "Alabama" || state == "AL") {
        state = "Alabama AL";
    } else if (state == "Alaska" || state == "AK") {
        state = "Alaska AK";
    } else if (state == "American Samoa" || state == "AS") {
        state = "American Samoa AS";
    } else if (state == "Arizona" || state == "AZ") {
        state = "Arizona AZ";
    } else if (state == "Arkansas" || state == "AR") {
        state = "Arkansas AR";
    } else if (state == "California" || state == "CA") {
        state = "California CA";
    } else if (state == "Colorado" || state == "CO") {
        state = "Colorado CO";
    } else if (state == "Connecticut" || state == "CT") {
        state = "Connecticut CT";
    } else if (state == "Delware" || state == "DE") {
        state = "Delaware DE";
    } else if (state == "District of Columbia" || state == "DC") {
        state = "District of Columbia DC";
    } else if (state == "Federated States of Micronesia" || state == "FM") {
        state = "Federated States of Micronesia FM";
    } else if (state == "Florida" || state == "FL") {
        state = "Florida FL";
    } else if (state == "Georgia" || state == "GA") {
        state = "Georgia GA";
    } else if (state == "Guam" || state == "GU") {
        state = "Guam GU";
    } else if (state == "Hawaii" || state == "HI") {
        state = "Hawaii HI";
    } else if (state == "Idaho" || state == "ID") {
        state = "Idaho ID";
    } else if (state == "Illinois" || state == "IL") {
        state = "Illinois IL";
    } else if (state == "Indiana" || state == "IN") {
        state = "Indiana IN";
    } else if (state == "Iowa" || state == "IA") {
        state = "Iowa IA";
    } else if (state == "Kansas" || state == "KS") {
        state = "Kansas KS";
    } else if (state == "Kentucky" || state == "KY") {
        state = "Kentucky KY";
    } else if (state == "Louisiana" || state == "LA") {
        state = "Louisiana LA";
    } else if (state == "Maine" || state == "ME") {
        state = "Maine ME";
    } else if (state == "Maryland" || state == "MD") {
        state = "Maryland MD";
    } else if (state == "Massachusetts" || state == "MA") {
        state = "Massachusetts MA";
    } else if (state == "Michigan" || state == "MI") {
        state = "Michigan MI";
    } else if (state == "Minnesota" || state == "MN") {
        state = "Minnesota MN";
    } else if (state == "Mississippi" || state == "MS") {
        state = "Mississippi MS";
    } else if (state == "Missouri" || state == "MO") {
        state = "Missouri MO";
    } else if (state == "Montana" || state == "MT") {
        state = "Montana MT";
    } else if (state == "Nebraska" || state == "NE") {
        state = "Nebraska NE";
    } else if (state == "Nevada" || state == "NV") {
        state = "Nevada NV";
    } else if (state == "New Hampshire" || state == "NH") {
        state = "New Hampshire NH";
    } else if (state == "New Jersey" || state == "NJ") {
        state = "New Jersey NJ";
    } else if (state == "New Mexico" || state == "NM") {
        state = "New Mexico NM";
    } else if (state == "New York" || state == "NY") {
        state = "New York NY";
    } else if (state == "North Carolina" || state == "NC") {
        state = "North Carolina NC";
    } else if (state == "North Dakota" || state == "ND") {
        state = "North Dakota ND";
    } else if (state == "Marshall Islands" || state == "MH") {
        state = "Marshall Islands MH";
    } else if (state == "Northern Mariana Islands" || state == "MP") {
        state = "Northern Mariana Islands MP";
    } else if (state == "Ohio" || state == "OH") {
        state = "Ohio OH";
    } else if (state == "Oklahoma" || state == "OK") {
        state = "Oklahoma OK";
    } else if (state == "Oregon" || state == "OR") {
        state = "Oregon OR";
    } else if (state == "Palau" || state == "PW") {
        state = "Palau PW";
    } else if (state == "Pennsylvania" || state == "PA") {
        state = "Pennsylvania PA";
    } else if (state == "Puerto Rico" || state == "PR") {
        state = "Puerto Rico PR";
    } else if (state == "Rhode Island" || state == "RI") {
        state = "Rhode Island RI";
    } else if (state == "South Carolina" || state == "SC") {
        state = "South Carolina SC";
    } else if (state == "South Dakota" || state == "SD") {
        state = "South Dakota SD";
    } else if (state == "Tennessee" || state == "TN") {
        state = "Tennessee TN";
    } else if (state == "Texas" || state == "TX") {
        state = "Texas TX";
    } else if (state == "Utah" || state == "UT") {
        state = "Utah UT";
    } else if (state == "Vermont" || state == "VT") {
        state = "Vermont VT";
    } else if (state == "Virgin Islands" || state == "VI") {
        state = "Virgin Islands VI";
    } else if (state == "Virginia" || state == "VA") {
        state = "Virginia VA";
    } else if (state == "Washington" || state == "WA") {
        state = "Washington WA";
    } else if (state == "West Virginia" || state == "WV") {
        state = "West Virginia WV";
    } else if (state == "Wisconsin" || state == "WI") {
        state = "Wisconsin WI";
    } else if (state == "Wyoming" || state == "WY") {
        state = "Wyoming WY";
    } else {
        $("#NotFound").text("Please enter a valid US State.");
    }

    console.log("State: " + state);

    var source = "https://api.data.gov/ed/collegescorecard/v1/schools?api_key=" + APIKey + "&school.state=" + state + "&_fields=" + fields;

    console.log("Source: " + source);

    //Requesting JSON through AJAX

    $.ajax({

        type: "GET",

        dataType: "json",

        url: source,

        success: displaySearch,

        error: errorOnAjax

    });

}

function displaySearch(data) {

    console.log("Display Result:");

    $("#results").css("display", "Block"); //Enable Display 

    var schools = data.metadata.total;//Total number of schools

    //Pages
    if (schools % 10 == 0) {
        pages = (schools / 10) - 1;
    } else {
        pages = Math.floor(schools / 10);
    }
    console.log("Pages: " + pages);

    //Empty Everything
    $("#ResultsTable").empty();
    $("#NotFound").empty();
    $("#Results").css("display", "None"); //Enable Display 

    if (schools > 0) {

        $("#Results").css("display", "None"); //Enable Display 

        for (i = 0; i <= schools; i++) {

            if (data.results[i]) {
                var ownership = data.results[i]["school.ownership"];
                var accreditor = data.results[i]["school.accreditor"];

                if (ownership === 1) {
                    ownership = "Public";
                } else if (ownership === 2) {
                    ownership = "Private, Nosn-Profit";
                } else {
                    ownership = "Private, For-Profit";
                }

                if (accreditor == null) {
                    accreditor = "N/A";
                }

                //Lays out the school names in a table
                console.log("We found Schools!")

                $("#ResultsTable").append("<tr><td>" + data.results[i]["school.name"] + "</td><td>"

                    + data.results[i]["school.state"] + "</td><td>"

                    + data.results[i]["school.city"] + "</td><td>"

                    + accreditor + "</td><td>"

                    + ownership + "</td></tr>");

            }

        }

    }

    else { //School Not found

        $("#NotFound").text("No Schools Found!");

    }

}

function errorOnAjax() {

    console.log("error");

}