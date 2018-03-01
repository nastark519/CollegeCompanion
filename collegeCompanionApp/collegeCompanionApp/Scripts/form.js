/**
 * Method checks what the values are in School Name and State Name are when called
 * If they are both empty (adding up to zero in length) it returns false
 * Else if returns true.
 */
function checkFields(form) {
    schoolName = document.getElementById("schoolNameInput").trim($(this).val());
    stateName = document.getElementById("stateInput").value().trim($(this).val());
    if (schoolName.length + stateName.length === 0) {
        return false;
    }
    return true;
}

/**
 * Method calls checkFields when the submit button is pressed
 * If checkFields returns false then it throws the user an error.
 */
$(function () {
    $('#errorHandler').on('submit', function () {
        var oneFilled = checkFields($(this));
        if (oneFilled == false) {
            document.getElementById("feedbackNoInput").innerHTML = 'Please fill in at least one search criteria.';
        };
    });
});​