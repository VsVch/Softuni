const { assert } = require('chai');
const lookupChar = require('../03. Char Lookup');

// describe('test lookupChar function', () => {
//     it('Wrong format value should return undefined', () => {

//         assert.strictEqual(undefined, lookupChar('string', 'string'));
//         assert.strictEqual(undefined, lookupChar('string', false));
//         assert.strictEqual(undefined, lookupChar('string', {}));
//         assert.strictEqual(undefined, lookupChar('string', []));
//         assert.strictEqual(undefined, lookupChar('string', NaN));
//         assert.strictEqual(undefined, lookupChar(10, 10));
//         assert.strictEqual(undefined, lookupChar({}, 10));
//         assert.strictEqual(undefined, lookupChar([], 10));
//         assert.strictEqual(undefined, lookupChar(false, 10));
//     });

//     it('Wrong format value should return undefined', () => {

//         assert.strictEqual(undefined, lookupChar('string', 'string'));
//         assert.strictEqual(undefined, lookupChar('string', false));
//         assert.strictEqual(undefined, lookupChar('string', {}));
//         assert.strictEqual(undefined, lookupChar('string', []));
//         assert.strictEqual(undefined, lookupChar('string', NaN));
//         assert.strictEqual(undefined, lookupChar(10, 10));
//         assert.strictEqual(undefined, lookupChar({}, 10));
//         assert.strictEqual(undefined, lookupChar([], 10));
//         assert.strictEqual(undefined, lookupChar(false, 10));
//     });

//     it('Wrong length of string input3 should return Incorrect index', () => {
//         let expectetResult = 'Incorrect index';       

//         assert.strictEqual(expectetResult,lookupChar('string', 6));
//         assert.strictEqual(expectetResult,lookupChar('string', 8));
//     });

//     it('index less than zero should return Incorrect index', () => {
//         let expectetResult = 'Incorrect index';       

//         assert.strictEqual(expectetResult,lookupChar('string', -1));
//         assert.strictEqual(expectetResult,lookupChar('string', -8));
//     });

//     it('corect inputs should return correct result', () => {
//         let expectetResult = 'i';      
//         assert.strictEqual(expectetResult,lookupChar('string', 3));

//         expectetResult = 's'; 
//         assert.strictEqual(expectetResult,lookupChar('string', 0));

//         expectetResult = 'g'; 
//         assert.strictEqual(expectetResult,lookupChar('string', 5));
//     });
// })