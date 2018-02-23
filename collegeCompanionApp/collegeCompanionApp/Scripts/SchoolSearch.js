console.log("You're in the SchoolSearch.js script");
$("#UserSchoolInput").keypress(function (e) {
    //If 'Enter' Key Pressed
    if (e.keyCode === 13) {
        start();
        e.preventDefault;
    }
});

//When "Search" button clicked
$("#Search").click(start);

function start() {
    var schoolName = $("#UserSchoolInput").val(); //Get User Input

    console.log("School Search: " + schoolName);
    var source = "Home/Search?school.name=" + schoolName; //This is where the RouteConfig.cs is not kicking in
    console.log("Source: " + source);

    //Requesting JSon through Ajax
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
    //if (data.metadata.total > 0) {
    //    for (i = 0; i < 4; i++) {
    //        var school = "#School-" + i; //School
    //        if (data.results[i]) {
    //            console.log("data.results[i]: " + data.results[i]["school.name"]);//Result
    //            $(school).text(data.results[i]["school.name"]);//Add to user view
    //        }
    //    }
    //}
    var schools = data.metadata.total;//Total number of schools
    if (schools > 0) {
        for (i = 0; i <= schools; i++) {
            if (data.results[i]) {
                //Lays out the school names in a table
                $("#SchoolTable").append("<tr><td>" + data.results[i]["school.name"] + "</td></tr>");
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