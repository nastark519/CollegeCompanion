console.log("In the CollegeSearch.js!");

//Start function call once window is loaded
window.onload = start();

function start() {
    console.log("In Start()!");

    var schoolName = localStorage["schoolName"];
    var state = localStorage["state"];
    console.log("School Name: " + schoolName);
    console.log("State: " + state);

    //URL
    var APIKey = "nKOePpukW43MVyeCch1t7xAFZxR2g0EFS3sHNkQ4"; //API Key
    var fields = "school.name,school.state"; //Fields
    var source = "https://api.data.gov/ed/collegescorecard/v1/schools?"; //Source
    var values = "school.name=" + schoolName + "&school.state=" + state;
    var url = source + values + "&api_key=" + APIKey + "&_fields=" + fields;
    url = url.replace(/ /g, "%20"); //replace spaces with '%20'
    console.log("URL: " + url);

    //Requesting JSon through Ajax
    $.ajax({
        type: "GET",
        dataType: "json",
        url: url,
        success: displaySearch,
        error: errorOnAjax
    });
}

function displaySearch(data) {
    
    var schools = data.metadata.total;//Total number of schools
    console.log("Total Results: " + schools);

    //Pages
    //if (schools % 10 == 0) {
    //    pages = (schools / 10) - 1;
    //} else {
    //    pages = Math.floor(schools / 10);
    //}
    //console.log("Pages: " + pages);

    //Empty Everything
    $("#SearchResults").empty();
    $("#NotFound").empty();
    $("#Results").css("display", "None"); //Enable Display 

    if (schools > 0) {
        $("#Results").css("display", "Block"); //Enable Display 

        for (i = 0; i <= schools; i++) {
            if (data.results[i]) {

                //var accreditor = data.results[i]["school.accreditor"];
                //var ownership = data.results[i]["school.ownership"];

                //if (accreditor == null) {
                //    accreditor = "N/A";
                //}

                //if (ownership == 1) {
                //    ownership = "Public";
                //} else if (ownership == 2) {
                //    ownership = "Private Non-Profit";
                //} else {
                //    ownership = "Private For-Profit";
                //}

                //$("#SearchResults").append("<tr><td>" + data.results[i]["school.name"]
                //    + "</td><td>" + accreditor
                //    + "</td><td>" + data.results[i]["school.state"]
                //    + "</td><td>" + data.results[i]["school.city"]
                //    + "</td><td>" + ownership + "</td></tr>");

                $("#SearchResults").append("<tr><td>" + data.results[i]["school.name"]
                    + "</td><td>" + data.results[i]["school.state"] + "</td></tr>");
            }
        }
    } else { //School Not found
        $("#NotFound").text("No Schools Found!");
    }
}


function errorOnAjax() {
    console.log("error");
    $("#NotFound").text("No Schools Found!");
}