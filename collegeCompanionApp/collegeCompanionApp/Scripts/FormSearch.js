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
    var cost = $('#costInput').val();
    var finLimit = $('#finLimitInput').val();
    var acceptRate = $('#acceptRateInput').val();

    console.log("FinLimit:" + finLimit);
    //Get the Financial Limits from the SearchForm
    //Parse the data into an upper and lower limit for searching
    var finBounds;
    var lowerBound;
    var upperBound;
    if (finLimit !== null) {
        finBounds = finLimit.split(" ");
        lowerBound = finBounds[0];
        upperBound = finBounds[1];
    }

    console.log("FinLimit Given, UpperBound:" + upperBound);

    if (state === null) {
        $('#feedbackNoInput').html("Please select a State!");
    } else { 

        if (ownership === null) {
            console.log("Ownership is Empty!")
            ownership = "1,2,3"
        }

        if (finLimit === null) {
            console.log("FinLimit:" + finLimit);
            finLimit = "";
            upperBound = "";
            console.log("Fin Limit Empty, UpperBound:" + upperBound);
            lowerBound = "";
        }

        if (upperBound !== "" && cost !== null) {
            $('#feedbackNoInput').html("Please enter your cost per year or select it, not both.");
        }

        console.log("School Name: " + schoolName);
        console.log("Ownership: " + ownership);
        console.log("City: " + city);
        console.log("Accreditor: " + accreditor);
        console.log("Ownership: " + ownership);
        console.log("Cost:" + cost);
        console.log("Acceptance Rate:" + acceptRate);

        var unicorns = 0;

        var fields = "&schoolName=" + schoolName + "&state=" + state + "&city=" + city +
            "&accreditor=" + accreditor + "&ownership=" + ownership + "&lowerBound=" + lowerBound + "&upperBound=" + upperBound + "&cost=" + cost
            + "&acceptanceRate=" + acceptRate;
        var url = "SearchResults?" + fields;
        url = url.replace(/ /g, "%20"); //replace spaces with '%20'

        
        console.log("URL: " + url);

       window.location.href = url;

    }
}


