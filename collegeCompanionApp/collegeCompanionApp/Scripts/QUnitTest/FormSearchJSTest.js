QUnit.test("Accept Rate Test", function (assert) { 
    var acceptRate = '70';
    var anyRate = 'Any';
    var underTen = '10';
    var result = getAcceptRate(acceptRate);
    var result2 = getAcceptRate(anyRate);
    var result3 = getAcceptRate(underTen);
    assert.equal(result, "0.7..", "Expected to be '0.7..', but was " + result);
    assert.equal(result2, "0..", "Expected to be '0..', but was " + result2);
    assert.equal(result3, "..0.1", "Expected to be '..0.1', but was " + result3);
});

QUnit.test("Check State & Degree Test", function (assert) {
    var state = 'OR';
    var degree = 'Computer';
    var degreeType = 'Bachelors';
    var result = checkStateDegree(state,degree,degreeType);
    assert.equal(result, true, "Expected to be true, but was " + result);
});