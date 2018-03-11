console.log("In FormSearch.js!");

$('#submit').click(start);

function start() {
    $('#feedbackNoInput').empty();

    console.log("Submit button clicked!");

    var schoolName = $('#schoolNameInput').val();
    var state = $('#stateInput').val();
    var city = $('#cityInput').val();
    var accreditor = $('#accreditorInput').val();
    var ownership = $('#ownershipInput').val();

    //console.log("City Name: " + city);

    if (state == null) {
        $('#feedbackNoInput').html("Please select a State!");
    } else { 

        var fields = "&schoolName=" + schoolName + "&state=" + state + "&city=" + city +
            "&accreditor=" + accreditor + "&ownership=" + ownership;
        var url = "SearchResults?" + fields;
        url = url.replace(/ /g, "%20"); //replace spaces with '%20'
        
        console.log("URL: " + url);

        window.location.href = url;

    }
}


