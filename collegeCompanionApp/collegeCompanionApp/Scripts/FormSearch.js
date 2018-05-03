console.log("In FormSearch.js!");

$('#submit').click(start);

function start() {
    //Clear Message
    $('#feedbackNoInput').empty();

    console.log("Submit button clicked!");

    // Get User College Search Input
    var schoolName = $('#schoolNameInput').val();
    var state = $('#stateInput').val();
    var city = $('#cityInput').val();
    var accreditor = $('#accreditorInput').val();
    var ownership = $('#ownershipInput').val();
    var cost = $('#costInput').val();
    var finLimit = $('#finLimitInput').val();
    var acceptRate = $('#acceptRateInput').val();
    var degree = $('#degreeInput').val();
    var degreeType = $('#degreeType').val();

    if (accreditor === undefined) {
        accreditor = '';
    }
    if (cost === undefined) {
        cost = '';
    }

    //Get the Financial Limits from the SearchForm
    //Parse the data into an upper and lower limit for searching
    var finBounds;
    var lowerBound;
    var upperBound;
    if (finLimit !== null) {
        finBounds = finLimit.split(" ");
        lowerBound = finBounds[0];
        upperBound = finBounds[1];
        console.log("FinLimit Given, UpperBound:" + upperBound);
    }


    // Error Message if no state selected
    if (state === null) {
        $('#feedbackNoInput').html("Please select a State!");
    } else {

        // If no ownership selected, defualt all options
        if (ownership === null) {
            console.log("Ownership is Empty!");
            ownership = "1,2,3";
        }

        // If finlimit null, default output 
        if (finLimit === null) {
            console.log("Null FinLimit:" + finLimit);
            finLimit = "";
            upperBound = "";
            lowerBound = "";
        }

        if (upperBound !== "" && cost !== null) {
            $('#feedbackNoInput').html("Please enter your cost per year or select it, not both.");
        }

        // Console Check
        console.log("School Name: " + schoolName);
        console.log("Ownership: " + ownership);
        console.log("City: " + city);
        console.log("Accreditor: " + accreditor);
        console.log("Ownership: " + ownership);
        console.log("Cost:" + cost);
        console.log("Acceptance Rate:" + acceptRate);

        // Add all values into fields
        var fields = "&schoolName=" + schoolName + "&state=" + state + "&city=" + city +
            "&accreditor=" + accreditor + "&ownership=" + ownership + "&lowerBound=" + lowerBound + "&upperBound=" + upperBound + "&cost=" + cost
            + "&acceptanceRate=" + acceptRate;

        // url to Search Results 
        var url = "SearchResults?" + fields;
        url = url.replace(/ /g, "%20"); //replace spaces with '%20'

        console.log("URL: " + url);

        // Returns the URL of the current page
        //window.location.href = url;

    }
}


