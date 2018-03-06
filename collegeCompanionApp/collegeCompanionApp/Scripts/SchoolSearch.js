console.log("You're in the SchoolSearch.js script");
$("#UserSchoolInput").keypress(function (e) {
    //If 'Enter' Key Pressed
    if (e.keyCode === 13)
    {
        start();
        e.preventDefault;
    }
});

//When "Search" button clicked
$("#Search").click(start);

var oldSchoolName; //Previous School Name
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
    var schoolName = $("#UserSchoolInput").val(); //Get User Input
    if (schoolName != oldSchoolName) {
        page = 0; //Reset Page
    }
    schoolName = schoolName.replace(/ /g, "%20"); //replace spaces with '%20'
    oldSchoolName = schoolName;

    console.log("School Name: " + schoolName);


    //URL
    var APIKey = "nKOePpukW43MVyeCch1t7xAFZxR2g0EFS3sHNkQ4"; //API Key
    var fields = "school.name,school.state,school.city,school.accreditor,school.ownership"; //Fields
    var source = "https://api.data.gov/ed/collegescorecard/v1/schools?school.name="; //Source

    var url = source + schoolName + "&api_key=" + APIKey + "&_fields=" + fields + "&per_page=10&page=" + page;
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
    if (schools % 10 == 0) {
        pages = (schools / 10) - 1;
    } else {
        pages = Math.floor(schools / 10);
    }
    console.log("Pages: " + pages);

    //Empty Everything
    $("#SearchResults").empty();
    $("#NotFound").empty();
    $("#Results").css("display", "None"); //Enable Display 
    
    if (schools > 0)
    {
        $("#Results").css("display", "Block"); //Enable Display 

        for (i = 0; i <= schools; i++)
        {
            if (data.results[i]) {

                var accreditor = data.results[i]["school.accreditor"];
                var ownership = data.results[i]["school.ownership"];

                if (accreditor == null){
                    accreditor = "N/A";
                }

                if (ownership == 1){
                    ownership = "Public";
                } else if (ownership == 2){
                    ownership = "Private Non-Profit";
                } else {
                    ownership = "Private For-Profit";
                }

                $("#SearchResults").append("<tr><td>" + data.results[i]["school.name"]
                    + "</td><td>" + accreditor
                    + "</td><td>" + data.results[i]["school.state"]
                    + "</td><td>" + data.results[i]["school.city"]
                    + "</td><td>" + ownership + "</td></tr>");                
            }
        }
    }else{ //School Not found
        $("#NotFound").text("No Schools Found!");
    }
}


function errorOnAjax() {
    console.log("error");
}