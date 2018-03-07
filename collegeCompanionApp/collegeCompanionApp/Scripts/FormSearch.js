console.log("In FormSearch.js!");

$('#submit').click(start);

function start() {
    console.log("Submit button clicked!");

    var state = $('#stateInput').val();
    if (state == null) {
        $('#feedbackNoInput').html("Please select a State!");
        return false;
    }

    //var schoolName = $('#schoolNameInput').val();
    //console.log("School Name: " + schoolName);
    //console.log("State: " + state);


    //Save data to transfer to CollegeSearch.js
    localStorage["schoolName"] = $('#schoolNameInput').val();
    localStorage["state"] = state;

}