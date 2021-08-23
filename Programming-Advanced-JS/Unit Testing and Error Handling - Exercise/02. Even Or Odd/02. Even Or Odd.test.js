const { assert } = require('chai');
const isOddOrEven = require('../02. Even Or Odd');

// describe('isOddOrEven function tests', () => {

//     it('Diferent than string value argument should return undefined', () => {

//         assert.strictEqual(undefined, isOddOrEven(null));
//         assert.strictEqual(undefined, isOddOrEven(5));
//         assert.strictEqual(undefined, isOddOrEven({}));
//         assert.strictEqual(undefined, isOddOrEven([]));
//         assert.strictEqual(undefined, isOddOrEven(true));
//         assert.strictEqual(undefined, isOddOrEven(3.5));
//     });

//     it('Even string should return even result', () => {

//         let actualResult = isOddOrEven('Even');
//         let expectedResult = 'even';

//         assert.strictEqual(actualResult, expectedResult);
//     });

//     it('Odd string should return odd result', () => {

//         let actualResult = isOddOrEven('Odd');
//         let expectedResult = 'odd';

//         assert.strictEqual(actualResult, expectedResult);
//     });
// })