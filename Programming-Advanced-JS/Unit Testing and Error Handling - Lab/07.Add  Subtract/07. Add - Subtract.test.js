const { assert } = require('chai');
const createCalculator = require('../07. Add - Subtract');

describe('createCalculator tests', () => {

    let calc = createCalculator();

    it('Null value should return null ', () => {
        let expectedResult = 0;     
        let actualResult = calc.get();

        assert.strictEqual(expectedResult, actualResult);        
    });

    it('Add should return corect value ', () => {
        let expectedResult = 5;
        calc.add(5);
        let actualResult = calc.get();

        assert.strictEqual(expectedResult, actualResult);  

    });

    it('Add whit string value should return corect result ', () => {
        let calc = createCalculator();
        calc.add('5');

        let expectedResult = 5;        
        let actualResult = calc.get();        
        assert.strictEqual(expectedResult, actualResult);
    });

    it('Add should return undefined wehn input is not a number', () => {
        let expectedResult = undefined;


        assert.strictEqual(expectedResult, calc.add(''));
        assert.strictEqual(expectedResult, calc.add(true));
        assert.strictEqual(expectedResult, calc.add({}));
        assert.strictEqual(expectedResult, calc.add([]));
    });  

    it('Substract should return undefined wehn input is not a number', () => {
        let expectedResult = undefined;

        assert.strictEqual(expectedResult, calc.subtract(''));
        assert.strictEqual(expectedResult, calc.subtract(true));
        assert.strictEqual(expectedResult, calc.subtract({}));
        assert.strictEqual(expectedResult, calc.subtract([]));
    });

    it('Substract should return corect value', () => {

        let cal = createCalculator();
        cal.add(10);
        cal.subtract(3);

        let expectedResult = 7;
        let actualResult = cal.get();     
        
        assert.strictEqual(expectedResult,actualResult);
    });

    it('Substract whit string valeue should return corect result', () => {

        let cal = createCalculator();
        
        cal.add(10);
        cal.subtract('3');

        let expectedResult = 7;
        let actualResult = cal.get();     
        
        assert.strictEqual(expectedResult,actualResult);      
    });

    it('Add whit floating number should return corect result', () => {

        let cal = createCalculator();
        
        cal.add(5.5);
        let expectedResult = 5.5;        
        let actualResult = cal.get();     
        
        assert.equal(expectedResult,actualResult);  
               
    });

    it('Substract whit floating number should return corect result', () => {

        let cal = createCalculator();
        
        cal.add(5.5);
        cal.subtract(2.1)
        let expectedResult = 3.4;        
        let actualResult = cal.get();     
        
        assert.equal(expectedResult,actualResult);  
               
    });
});

