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

    // Console Check
    console.log("School Name: " + schoolName);
    console.log("State: " + state);
    console.log("City: " + city);
    console.log("Ownership: " + ownership);
    console.log("FinLimit: " + finLimit);
    console.log("Acceptance Rate:" + acceptRate);
    console.log("Degree: " + degree);
    console.log("Degree Type: " + degreeType);
    
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
        if (finLimit === 'Any') {
            //console.log("Fin Limit Any! ");
            lowerBound = '0';
            upperBound = '';
        } else if (finLimit === '<1000') {
            //console.log("Fin Limit <1000 ");
            lowerBound = '';
            upperBound = '1000';
        } else if (finLimit == '>60000') {
            //console.log("Fin Limit >60000 ");
            lowerBound = '60000';
            upperBound = '';
        } else {
            //console.log("Fin Limit Selected!");
            finBounds = finLimit.split(" ");
            lowerBound = finBounds[0];
            upperBound = finBounds[1];
        }
        console.log("FinLimit LowerBound-UpperBound:" + lowerBound + ".." + upperBound);
    }

    // Error Message if no state selected
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
        // If any Ownership
        if (ownership === 'Any') {
            console.log("Any Ownership!");
            ownership = "1,2,3";
        }

        if (schoolName === 'Any') {
            schoolName = '';
        }

        if (degree === null) {
            degree = '';
            degreeType = '';
        }

        if (acceptRate == '') {
            console.log("no Rate");
        }


        // Add all values into fields
        var fields = "&schoolName=" + schoolName + "&state=" + state + "&city=" + city +
            "&accreditor=" + accreditor + "&ownership=" + ownership + "&lowerBound=" + lowerBound + "&upperBound=" + upperBound
            + "&cost=" + cost + "&acceptanceRate=" + acceptRate + "&degree=" + degree + "&degreeType=" + degreeType;

        // url to Search Results 
        var url = "SearchResults?" + fields;
        url = url.replace(/ /g, "%20"); //replace spaces with '%20'

        console.log("URL: " + url);

        // Returns the URL of the current page
        //window.location.href = url;

    }
}


