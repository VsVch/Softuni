const { assert } = require('chai');
const mathEnforcer = require('../04. Math Enforcer');

describe('test mathEnforcer object', () => {

    describe('addFive function', () => {
        it('When input is incorect should return undefind', () => {
            assert.strictEqual(undefined, mathEnforcer.addFive(null));
            assert.strictEqual(undefined, mathEnforcer.addFive('string'));
            assert.strictEqual(undefined, mathEnforcer.addFive(false));
            assert.strictEqual(undefined, mathEnforcer.addFive([]));
            assert.strictEqual(undefined, mathEnforcer.addFive({}));
            assert.strictEqual(undefined, mathEnforcer.addFive(''));            
        });

        it('When input is correct should return correct answer', () => {

            let expectedResult = 10;
            assert.strictEqual(expectedResult, mathEnforcer.addFive(5));

            expectedResult = 5;
            assert.strictEqual(expectedResult, mathEnforcer.addFive(0));

            assert.closeTo(mathEnforcer.addFive(2.5), 7.5, 0.01)
            assert.closeTo(mathEnforcer.addFive(-2.5), 2.5, 0.01)

            assert.strictEqual(0, mathEnforcer.addFive(-5));
        });
    });

    describe('subtractTen function', () => {
        it('When input is incorect SubtractTen function should return undefind', () => {
            assert.strictEqual(undefined, mathEnforcer.subtractTen(null));
            assert.strictEqual(undefined, mathEnforcer.subtractTen('string'));
            assert.strictEqual(undefined, mathEnforcer.subtractTen(false));
            assert.strictEqual(undefined, mathEnforcer.subtractTen([]));
            assert.strictEqual(undefined, mathEnforcer.subtractTen({}));
            assert.strictEqual(undefined, mathEnforcer.subtractTen(''));
        });

        it('When input is correct subtractTen function should return correct answer', () => {

            let expectedResult = 5;
            assert.strictEqual(expectedResult, mathEnforcer.subtractTen(15));

            expectedResult = 0;
            assert.strictEqual(expectedResult, mathEnforcer.subtractTen(10));

            expectedResult = -5;
            assert.strictEqual(expectedResult, mathEnforcer.subtractTen(5));

            assert.strictEqual(-15, mathEnforcer.subtractTen(-5));
            assert.strictEqual(-10, mathEnforcer.subtractTen(0));

            assert.closeTo(mathEnforcer.subtractTen(12.5), 2.5, 0.01)
            assert.closeTo(mathEnforcer.subtractTen(-2.5), -12.5, 0.01)

        });
    });

    describe('sum function', () => {

        it('When first num is incorect sum function should return undefind', () => {
            assert.strictEqual(undefined, mathEnforcer.sum(null), 0);
            assert.strictEqual(undefined, mathEnforcer.sum('string'), 1);
            assert.strictEqual(undefined, mathEnforcer.sum(false), 2);
            assert.strictEqual(undefined, mathEnforcer.sum([]), 3);
            assert.strictEqual(undefined, mathEnforcer.sum({}), 4);
            assert.strictEqual(undefined, mathEnforcer.sum(''), 5);            
        });

        it('When second num is incorect sum function should return undefind', () => {

            assert.strictEqual(undefined, mathEnforcer.sum(0, null));
            assert.strictEqual(undefined, mathEnforcer.sum(1, 'string'));
            assert.strictEqual(undefined, mathEnforcer.sum(2, false));
            assert.strictEqual(undefined, mathEnforcer.sum(3, []));
            assert.strictEqual(undefined, mathEnforcer.sum(4, {}));
            assert.strictEqual(undefined, mathEnforcer.sum(5, ''));
        });

        it('When inputs is correct sum function should return correct answer', () => {


            assert.strictEqual(5, mathEnforcer.sum(5, 0));
            assert.strictEqual(5, mathEnforcer.sum(0, 5));
            assert.strictEqual(10, mathEnforcer.sum(5, 5));
            assert.strictEqual(0, mathEnforcer.sum(-5, 5));
            assert.strictEqual(-5, mathEnforcer.sum(-10, 5));
            assert.strictEqual(-15, mathEnforcer.sum(-10, -5));
            assert.strictEqual(5, mathEnforcer.sum(10, -5));

            assert.closeTo(mathEnforcer.sum(2.5, 2.5), 5.0, 0.01)
            assert.closeTo(mathEnforcer.sum(-2.5, -2.5), -5.0, 0.01)

        });
    });
});