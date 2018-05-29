QUnit.test("Yelp - Create URL Test", function (assert) {
    //Arrange
    var location = '97128';
    var term = 'Delivery';
    var isOpen = 'Closed';
    //Act
    var expected = "YelpSearch?location=97128&term=Delivery&isOpen=Closed";
    var result = createYelpURL(location, term, isOpen);
    //Assert
    assert.equal(result, expected, "Expected to be the same, but was " + result);
});

