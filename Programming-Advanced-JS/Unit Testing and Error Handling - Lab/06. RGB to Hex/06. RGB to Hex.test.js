const { assert } = require('chai');
const rgbToHexColor = require('../06. RGB to Hex');

describe('Test rgbToHexColor function', () => {
   
    it('Should return undefine when first argument is not a number', () => {
        let numTwo = 2;
        let numThree = 3;
        let actualResult = undefined;
        
    
        assert.equal(rgbToHexColor('someInput', numTwo, numThree), actualResult);
        assert.equal(rgbToHexColor(' ', numTwo, numThree), actualResult);
        assert.equal(rgbToHexColor('    ', numTwo, numThree), actualResult);
        assert.equal(rgbToHexColor(NaN, numTwo, numThree), actualResult);
        assert.equal(rgbToHexColor({}, numTwo, numThree), actualResult);
        assert.equal(rgbToHexColor([], numTwo, numThree), actualResult);
        assert.equal(rgbToHexColor(true, numTwo, numThree), actualResult);
        assert.equal(rgbToHexColor(undefined, numTwo, numThree), actualResult);
        assert.equal(rgbToHexColor(null, numTwo, numThree), actualResult);
        assert.equal(rgbToHexColor(0.01, numTwo, numThree), actualResult);

    });

    it('Should return false when first argument is less than zero', () => {
        
        let numTwo = 2;
        let numThree = 3;
        let actualResult = undefined;        

        assert.equal(rgbToHexColor(-1, numTwo, numThree), actualResult);
        assert.equal(rgbToHexColor(-25, numTwo, numThree), actualResult);    
        
    });

    it('Should return false when first argument is above upper limit', () => {
        
        let numTwo = 2;
        let numThree = 3;
        let actualResult = undefined;

        assert.equal(rgbToHexColor(256, numTwo, numThree), actualResult);
        assert.equal(rgbToHexColor(280, numTwo, numThree), actualResult);    
        
    });

    it('Should return undefine when second argument is not a number', () => {

        let numOne = 1        
        let numThree = 3;
        let actualResult = undefined;        
    
        assert.equal(rgbToHexColor(numOne,'someInput', numThree), actualResult);
        assert.equal(rgbToHexColor(numOne, ' ', numThree), actualResult);
        assert.equal(rgbToHexColor(numOne, '    ', numThree), actualResult);
        assert.equal(rgbToHexColor(numOne, {}, numThree), actualResult);
        assert.equal(rgbToHexColor(numOne, [], numThree), actualResult);
        assert.equal(rgbToHexColor(numOne, NaN, numThree), actualResult);
        assert.equal(rgbToHexColor(numOne, true, numThree), actualResult);
        assert.equal(rgbToHexColor(numOne, undefined, numThree), actualResult);
        assert.equal(rgbToHexColor(numOne, null, numThree), actualResult);
        assert.equal(rgbToHexColor(numOne, 0.01, numThree), actualResult);
    });

    it('Should return false when second argument is less than zero', () => {
        
        let numOne = 1;
        let numThree = 3;
        let actualResult = undefined;        

        assert.equal(rgbToHexColor(numOne, -1, numThree), actualResult);
        assert.equal(rgbToHexColor(numOne, -20, numThree), actualResult);    
        
    });

    it('Should return false when second argument is above upper limit', () => {
        
        let numOne = 1;
        let numThree = 3;
        let actualResult = undefined;

        assert.equal(rgbToHexColor(numOne, 256, numThree), actualResult);
        assert.equal(rgbToHexColor(numOne, 280, numThree), actualResult);    
        
    });

    it('Should return undefine when third argument is not a number', () => {

        let numOne = 1        
        let numTwo = 3;
        let actualResult = undefined;        
    
        assert.equal(rgbToHexColor(numOne, numTwo, 'someInput'), actualResult);
        assert.equal(rgbToHexColor(numOne, numTwo, ' '), actualResult);
        assert.equal(rgbToHexColor(numOne, numTwo, '    '), actualResult);
        assert.equal(rgbToHexColor(numOne, numTwo, []), actualResult);
        assert.equal(rgbToHexColor(numOne, numTwo, {}), actualResult);
        assert.equal(rgbToHexColor(numOne, numTwo, NaN), actualResult);
        assert.equal(rgbToHexColor(numOne, numTwo, true), actualResult);
        assert.equal(rgbToHexColor(numOne, numTwo, undefined), actualResult);
        assert.equal(rgbToHexColor(numOne, numTwo, null), actualResult);
        assert.equal(rgbToHexColor(numOne, numTwo, 0.01), actualResult);
    });

    it('Should return false when third argument is less than zero', () => {
        
        let numOne = 1;
        let numTwo = 3;
        let actualResult = undefined;        

        assert.equal(rgbToHexColor(numOne, numTwo, -1), actualResult);
        assert.equal(rgbToHexColor(numOne, numTwo, -20), actualResult);    
        
    });

    it('Should return false when third argument is above upper limit', () => {
        
        let numOne = 1;
        let numTwo = 2;
        let actualResult = undefined;

        assert.equal(rgbToHexColor(numOne, numTwo, 256), actualResult);
        assert.equal(rgbToHexColor(numOne, numTwo, 280), actualResult);    
        
    });

    it('Should return corect value when all arguments is correct', () => {
        
        
        let actualResult1 = '#FFFFFF';
        let actualResult2 = '#000000';
        let actualResult3 = '#0C0D0E';

        let expectedResult1 = rgbToHexColor(255,255,255);
        let expectedResult2 = rgbToHexColor(0,0,0);
        let expectedResult3 = rgbToHexColor(12,13,14);

        assert.equal(expectedResult1, actualResult1);
        assert.equal(expectedResult2, actualResult2);
        assert.equal(expectedResult3, actualResult3);
                    
    });
    
    it('Should return false when all arguments is empty value', () => {
        
        let red = '';
        let green = '';
        let blue = '';
        
        let actualResult = undefined;     
        let expectedResult = rgbToHexColor(red,green,blue);        

        assert.equal(rgbToHexColor(expectedResult, actualResult));     
    });
});