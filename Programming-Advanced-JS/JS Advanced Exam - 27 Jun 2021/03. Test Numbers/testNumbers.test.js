const { assert } = require('chai');
const testNumbers = require('../testNumbers');

describe("Tests testNumbers", () => {
    describe('sumNumbers', () => {
        it("Should return undefined", () => {

            assert.strictEqual(testNumbers.sumNumbers('string', 3), undefined);
            assert.strictEqual(testNumbers.sumNumbers(false, 3), undefined);
            assert.strictEqual(testNumbers.sumNumbers([], 3), undefined);
            assert.strictEqual(testNumbers.sumNumbers({}, 3), undefined);
            assert.strictEqual(testNumbers.sumNumbers(3, 'string'), undefined);
            assert.strictEqual(testNumbers.sumNumbers(3, true), undefined);
            assert.strictEqual(testNumbers.sumNumbers(3, []), undefined);
            assert.strictEqual(testNumbers.sumNumbers(3, {}), undefined);

        });

        it("Should return correct answer", () => {

            assert.strictEqual(testNumbers.sumNumbers(2, 2), (4).toFixed(2));
            assert.strictEqual(testNumbers.sumNumbers(0, 2), (2.00).toFixed(2));
            assert.strictEqual(testNumbers.sumNumbers(2, 3), (5.00).toFixed(2));
            assert.strictEqual(testNumbers.sumNumbers(-1, 3), (2.00).toFixed(2));
            assert.strictEqual(testNumbers.sumNumbers(2, -1), (1.00).toFixed(2));
        });
    });

    describe('numberChecker', () => {
        it("Should throw error", () => {

            assert.throw(()=>(testNumbers.numberChecker('string'),Error, 'The input is not a number!'));
            assert.throw(()=>(testNumbers.numberChecker(NaN),Error, 'The input is not a number!'));

        });

        it("Should return even number", () => {

            assert.strictEqual(testNumbers.numberChecker(2), 'The number is even!');
            assert.strictEqual(testNumbers.numberChecker(0), 'The number is even!');
            assert.strictEqual(testNumbers.numberChecker(-2), 'The number is even!');
            
        });

        it("Should return odd number", () => {

            assert.strictEqual(testNumbers.numberChecker(3), 'The number is odd!');
            assert.strictEqual(testNumbers.numberChecker(-1), 'The number is odd!');
            assert.strictEqual(testNumbers.numberChecker(1), 'The number is odd!');
            
        });
    });

    describe('averageSumArray', () => {        

        it("Should return average sum", () => {

            let arr = [1,2,3];
            assert.strictEqual(testNumbers.averageSumArray(arr), 6/3);          
            
        });       
    });
});
