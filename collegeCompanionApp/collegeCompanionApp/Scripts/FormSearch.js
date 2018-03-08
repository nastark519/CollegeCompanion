console.log("In FormSearch.js!");

$('#submit').click(start);

function start() {
    console.log("Submit button clicked!");

    var schoolName = $('#schoolNameInput').val();
    var state = $('#stateInput').val();
    if (state == null) {
        $('#feedbackNoInput').html("Please select a State!");
        //return false;
    }

    console.log("School Name: " + schoolName);
    console.log("State: " + state);


    //URL
    //var source = "https://api.data.gov/ed/collegescorecard/v1/schools?"; //Source
    //var values = "school.name=" + schoolName + "&school.state=" + state;
    //var APIKey = "&api_key=nKOePpukW43MVyeCch1t7xAFZxR2g0EFS3sHNkQ4"; //API Key
    //var fields = "&_fields=school.name,school.state"; //Fields 

    //var url = source + values + APIKey + fields;
    var url = "Search?school.name=" + schoolName + "&school.state=" + state;
    url = url.replace(/ /g, "%20"); //replace spaces with '%20'

    console.log("URL: " + url);


    //Requesting JSon through Ajax
    $.ajax({
        type: "GET",
        dataType: "json",
        url: url,
        //data: {
        //    schoolName: schoolName,
        //    state: state
        //},
        success: successSearch,
        error: errorOnAjax
    });
}


function successSearch(data) {
    console.log("Total Results: " + data.metadata.total);
}


function errorOnAjax() {
    console.log("error on Ajax");
    return false;
}