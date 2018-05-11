function directions() {
    $("#submit").click(function () {
        startInput = $("#startInput").val(); //Get starting location information from user.
        console.log(startInput); //Verify we're getting back the data we expect.

        endInput = $("#endInput").val(); //Get ending location information from user.
        console.log(endInput); //Verify we're getting back the data we expect.

        httpInput = GoogleAPIKey();

}

http://www.mapquestapi.com/directions/v2/route?key=KEY&from=Clarendon Blvd,Arlington,VA&to=2400+S+Glebe+Rd,+Arlington,+VA