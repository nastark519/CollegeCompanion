console.log("Running form.js!");

// Method calls checkFields when the submit button is pressed
// If checkFields returns false then it throws the user an error.

function start() {
    console.log("Submit button clicked!");
    var oneFilled = checkFields($(this));
    console.log("oneFilled: " + oneFilled);
    if (oneFilled === false) {
        $('#feedbackNoInput').text('Please fill in at least one search criteria.');
        //var form = $("#feedbackNoInput"); function handleForm(event) { event.preventDefault(); }
        //form.addEventListener('submit', handleForm);
        return false;
    }
}


// Method checks what the values are in School Name and State Name are when called
// If they are both empty (adding up to zero in length) it returns false
// Else if returns true.


function checkFields(form) {
    console.log("Inside checkfields()!");
    var schoolName = $('#schoolNameInput').val();
    console.log("School Name: " + schoolName);
    var stateName = $('#stateInput').val();
    console.log("State Name: " + stateName);
    if (schoolName || stateName == null) {
        return false;
    }
    return true;
}