
const { assert } = require('chai');
const sum = require('../04. Sum of Numbers');

it('Should add positive numbers', () => {

    let arr = [1, 2, 3, 4, 5];

    let expectedResult = 15;

    let actualResult = sum(arr);    

    assert.strictEqual(actualResult, expectedResult);
})

