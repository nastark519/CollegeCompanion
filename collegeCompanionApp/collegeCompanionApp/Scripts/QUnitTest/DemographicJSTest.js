QUnit.test("Zipcode Test", function (assert) {
    var zip = checkZipcode("97361");
    //var badZip = checkZipcode("123");
    assert.equal(zip, true, "Expected to be true, but was " + zip);
    //assert.equal(badZip, false, "Expected to be False");
});

QUnit.test("Box Checked Test", function (assert) {
    var race = 'aa';
    var gender = 'm';
    var ageRanges = [];
    ageRanges.push("10_14", "20_24");
    var result = boxCheck(race, gender, ageRanges);
    assert.equal(result, true, "Expected to be true, but was " + result);
});

QUnit.test("Create URL Test", function (assert) {
    latitude = '64.93492';
    longitude = '-123.97833';
    var variables = "&variables=10_14,20_24";
    var result = createURL(variables);
    var expected = "DemographicSearch?latitude=64.93492&longitude=-123.97833&variables=10_14,20_24";
    assert.equal(result, expected, "Expected to be the same, but was " + result);
});