console.log("In FormSearch.js!");

$('#submit').click(start);

//Global Variables
var lowerBound;
var upperBound;

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

    // Console Check
    console.log("School Name: " + schoolName);
    console.log("State: " + state);
    console.log("City: " + city);
    console.log("Ownership: " + ownership);
    console.log("FinLimit: " + finLimit);
    console.log("Acceptance Rate:" + acceptRate);
    console.log("Degree: " + degree);
    console.log("Degree Type: " + degreeType);

    // Check for undefined
    if (accreditor === undefined) {
        accreditor = '';
    }
    if (cost === undefined) {
        cost = '';
    }

    //Get the Financial Limits from the SearchForm
    //Parse the data into an upper and lower limit for searching
    getBounds(finLimit);

    // Get the acceptance rate percentage
    acceptRate = getAcceptRate(acceptRate);

    // Error Message if no State selected or Degree with Degree Type is selected
    if (checkStateDegree(state, degree, degreeType) === false) {
        return false;
    } else {
        // If any Ownership
        if (ownership === 'Any') {
            console.log("Any Ownership!");
            ownership = "1,2,3";
        }
        // If Any School Name
        if (schoolName === 'Any') {
            schoolName = '';
        }
        // If degree is NULL
        if (degree === null) {
            degree = '';
            degreeType = '';
        }

        // Add all values into fields
        var fields = "&schoolName=" + schoolName + "&state=" + state + "&city=" + city +
            "&accreditor=" + accreditor + "&ownership=" + ownership + "&lowerBound=" + lowerBound + "&upperBound=" + upperBound
            + "&cost=" + cost + "&acceptanceRate=" + acceptRate + "&degree=" + degree + "&degreeType=" + degreeType;

        // url to Search Results 
        var url = "SearchResults?" + fields;
        url = url.replace(/ /g, "%20"); //replace spaces with '%20'

        console.log("URL: " + url);

        // Returns the URL of the next page
        window.location.href = url;
    }
}

function getBounds(finLimit) {
    if (finLimit !== null) { // If finLimit not null
        if (finLimit === 'Any') { // Chose any range 
            lowerBound = '0';
            upperBound = '';
        } else if (finLimit === '<1000') { // Finance under $1,000
            lowerBound = '';
            upperBound = '1000';
        } else if (finLimit === '>60000') { // Finance over $60,000
            lowerBound = '60000';
            upperBound = '';
        } else { // Finance User Range
            finBounds = finLimit.split(" ");
            lowerBound = finBounds[0];
            upperBound = finBounds[1];
        }
        // Console Check FinLimit Lower & Upper Bound
        console.log("FinLimit LowerBound-UpperBound:" + lowerBound + ".." + upperBound);
    }
}

function getAcceptRate(acceptRate) {
    if (acceptRate === 'Any') { // Any Acceptance Rate
        acceptRate = '0..';
    } else if (acceptRate === '10') { // Acceptance Rate under 10%
        acceptRate = '..0.1';
    } else { // User selection Acceptance Rate 
        var num = parseInt(acceptRate); // Converts string into int
        num = num / 100; // Get percentage of Acceptance Rate
        var aRate = num.toString(); // Convert int into string
        acceptRate = aRate + '..'; // Acceptance Rate and Greater
    }
    return acceptRate;
}

function checkStateDegree(state, degree, degreeType) {
    if (state === 'Any' && degree === null) {
        if (degreeType !== null) {
            $('#feedbackNoInput').html("Please select a Degree!");
            return false;
        } else {
            $('#feedbackNoInput').html("Please select a State or select a Degree!");
            return false;
        }
    } else if (degree !== null && degreeType === null || state !== 'Any' && degree === null && degreeType !== null) {
        $('#feedbackNoInput').html("Please select a Degree Type!");
        return false;
    } else {
        return true;
    }
}


