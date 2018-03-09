console.log("In FormSearch.js!");

$('#submit').click(start);

function start() {
    $('#feedbackNoInput').empty();

    console.log("Submit button clicked!");

    var schoolName = $('#schoolNameInput').val();
    var state = $('#stateInput').val();
    if (state == null) {
        $('#feedbackNoInput').html("Please select a State!");
    } else { 
    
        console.log("School Name: " + schoolName);
        console.log("State: " + state);

        //URL
        var APIKey = "nKOePpukW43MVyeCch1t7xAFZxR2g0EFS3sHNkQ4"; //API Key
        var fields = "school.name,school.state"; //Fields
        var source = "https://api.data.gov/ed/collegescorecard/v1/schools?school.name="; //Source

        var url = source + schoolName + "&school.state=" + state + "&api_key=" + APIKey + "&_fields=" + fields;
        console.log("URL: " + url);

        //Requesting JSon through Ajax
        $.ajax({
            type: "GET",
            dataType: "json",
            url: url,
            success: successSearch,
            error: errorOnAjax
        });

        //var url = "CollegeSearch?school.name=" + schoolName + "&school.state=" + state;
        //url = url.replace(/ /g, "%20"); //replace spaces with '%20'

        //console.log("URL: " + url);
        

        ////Requesting JSon through Ajax
        //$.ajax({
        //    type: "POST",
        //    dataType: "json",
        //    url: url,
        //    success: successSearch,
        //    error: errorOnAjax
        //});

    }
}


function successSearch(data) {
    console.log("Total Results: " + data.metadata.total);
}


function errorOnAjax() {
    console.log("error on Ajax");
    return false;
}