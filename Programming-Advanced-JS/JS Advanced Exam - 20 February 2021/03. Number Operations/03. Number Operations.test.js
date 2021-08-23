const { assert } = require('chai');
const numberOperations = require('../03. Number Operations');

describe('numberOperations', () => {

    describe('powNumber function', () => {
        it('Should return correct value', () => {

            let expected = 4;
            assert.strictEqual(expected, numberOperations.powNumber(2));
            assert.strictEqual(0, numberOperations.powNumber(0));
        });


    });

    describe('numberChecker', () => {
        it('Should throw exeption when value is not a number', () => {

            assert.throw(() => { numberOperations.numberChecker('3string') }, Error);            
        });

        it('Should return input is lower than 100 when add lower value', () => {  

            assert.strictEqual(numberOperations.numberChecker(99), 'The number is lower than 100!');
            assert.strictEqual(numberOperations.numberChecker(80), 'The number is lower than 100!');
            assert.strictEqual(numberOperations.numberChecker(-1), 'The number is lower than 100!');
            
        });

        it('Should return input is more than 100 when add higer value', () => {  

            assert.strictEqual(numberOperations.numberChecker(101),'The number is greater or equal to 100!');
            assert.strictEqual(numberOperations.numberChecker(120),'The number is greater or equal to 100!');           
            assert.strictEqual(numberOperations.numberChecker(100),'The number is greater or equal to 100!');           
            
        });
    });

    describe('sumArrays', () => {

        it('Shoud return longer array from two arrays', () => {

            let arr1 = [1,2,3,4,5];
            let arr2 = [1,2,3,4,5,6];           
            let arr3 = [1,2,3,4,5];           

            assert.deepEqual(numberOperations.sumArrays(arr1,arr2), [2, 4, 6, 8, 10, 6]);
            assert.deepEqual(numberOperations.sumArrays(arr1,arr3), [2, 4, 6, 8, 10]);
        });    
     });
});