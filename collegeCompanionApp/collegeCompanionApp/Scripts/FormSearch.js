console.log("In FormSearch.js!");

$('#submit').click(start);

//Global Variables
var lowerBound;
var upperBound;

function start() {
    //Clear Message
    $('#feedbackNoInput').empty();
    $('#NotFound').empty();

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

    state = stateInputFormatting(state);

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

function stateInputFormatting(state) {
    if (state == "Alabama" || state == "AL") {
        state = "Alabama AL";
    } else if (state == "Alaska" || state == "AK") {
        state = "Alaska AK";
    } else if (state == "American Samoa" || state == "AS") {
        state = "American Samoa AS";
    } else if (state == "Arizona" || state == "AZ") {
        state = "Arizona AZ";
    } else if (state == "Arkansas" || state == "AR") {
        state = "Arkansas AR";
    } else if (state == "California" || state == "CA") {
        state = "California CA";
    } else if (state == "Colorado" || state == "CO") {
        state = "Colorado CO";
    } else if (state == "Connecticut" || state == "CT") {
        state = "Connecticut CT";
    } else if (state == "Delware" || state == "DE") {
        state = "Delaware DE";
    } else if (state == "District of Columbia" || state == "DC") {
        state = "District of Columbia DC";
    } else if (state == "Federated States of Micronesia" || state == "FM") {
        state = "Federated States of Micronesia FM";
    } else if (state == "Florida" || state == "FL") {
        state = "Florida FL";
    } else if (state == "Georgia" || state == "GA") {
        state = "Georgia GA";
    } else if (state == "Guam" || state == "GU") {
        state = "Guam GU";
    } else if (state == "Hawaii" || state == "HI") {
        state = "Hawaii HI";
    } else if (state == "Idaho" || state == "ID") {
        state = "Idaho ID";
    } else if (state == "Illinois" || state == "IL") {
        state = "Illinois IL";
    } else if (state == "Indiana" || state == "IN") {
        state = "Indiana IN";
    } else if (state == "Iowa" || state == "IA") {
        state = "Iowa IA";
    } else if (state == "Kansas" || state == "KS") {
        state = "Kansas KS";
    } else if (state == "Kentucky" || state == "KY") {
        state = "Kentucky KY";
    } else if (state == "Louisiana" || state == "LA") {
        state = "Louisiana LA";
    } else if (state == "Maine" || state == "ME") {
        state = "Maine ME";
    } else if (state == "Maryland" || state == "MD") {
        state = "Maryland MD";
    } else if (state == "Massachusetts" || state == "MA") {
        state = "Massachusetts MA";
    } else if (state == "Michigan" || state == "MI") {
        state = "Michigan MI";
    } else if (state == "Minnesota" || state == "MN") {
        state = "Minnesota MN";
    } else if (state == "Mississippi" || state == "MS") {
        state = "Mississippi MS";
    } else if (state == "Missouri" || state == "MO") {
        state = "Missouri MO";
    } else if (state == "Montana" || state == "MT") {
        state = "Montana MT";
    } else if (state == "Nebraska" || state == "NE") {
        state = "Nebraska NE";
    } else if (state == "Nevada" || state == "NV") {
        state = "Nevada NV";
    } else if (state == "New Hampshire" || state == "NH") {
        state = "New Hampshire NH";
    } else if (state == "New Jersey" || state == "NJ") {
        state = "New Jersey NJ";
    } else if (state == "New Mexico" || state == "NM") {
        state = "New Mexico NM";
    } else if (state == "New York" || state == "NY") {
        state = "New York NY";
    } else if (state == "North Carolina" || state == "NC") {
        state = "North Carolina NC";
    } else if (state == "North Dakota" || state == "ND") {
        state = "North Dakota ND";
    } else if (state == "Marshall Islands" || state == "MH") {
        state = "Marshall Islands MH";
    } else if (state == "Northern Mariana Islands" || state == "MP") {
        state = "Northern Mariana Islands MP";
    } else if (state == "Ohio" || state == "OH") {
        state = "Ohio OH";
    } else if (state == "Oklahoma" || state == "OK") {
        state = "Oklahoma OK";
    } else if (state == "Oregon" || state == "OR") {
        state = "Oregon OR";
    } else if (state == "Palau" || state == "PW") {
        state = "Palau PW";
    } else if (state == "Pennsylvania" || state == "PA") {
        state = "Pennsylvania PA";
    } else if (state == "Puerto Rico" || state == "PR") {
        state = "Puerto Rico PR";
    } else if (state == "Rhode Island" || state == "RI") {
        state = "Rhode Island RI";
    } else if (state == "South Carolina" || state == "SC") {
        state = "South Carolina SC";
    } else if (state == "South Dakota" || state == "SD") {
        state = "South Dakota SD";
    } else if (state == "Tennessee" || state == "TN") {
        state = "Tennessee TN";
    } else if (state == "Texas" || state == "TX") {
        state = "Texas TX";
    } else if (state == "Utah" || state == "UT") {
        state = "Utah UT";
    } else if (state == "Vermont" || state == "VT") {
        state = "Vermont VT";
    } else if (state == "Virgin Islands" || state == "VI") {
        state = "Virgin Islands VI";
    } else if (state == "Virginia" || state == "VA") {
        state = "Virginia VA";
    } else if (state == "Washington" || state == "WA") {
        state = "Washington WA";
    } else if (state == "West Virginia" || state == "WV") {
        state = "West Virginia WV";
    } else if (state == "Wisconsin" || state == "WI") {
        state = "Wisconsin WI";
    } else if (state == "Wyoming" || state == "WY") {
        state = "Wyoming WY";
    } else {
        $("#NotFound").text("Please enter a valid US State.");
    }
    return state;
}
