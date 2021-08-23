const { assert } = require('chai');
const isSymmetric = require('../05. Check for Symmetry ');

describe('Test isSimetric functionallity', () =>{

    it('Should return false when input is not correct', () => {
        
        let expectedResult = false;     
    
        assert.equal(isSymmetric(null),expectedResult);
        assert.equal(isSymmetric(' '),expectedResult);
        assert.equal(isSymmetric(0),expectedResult);
        assert.equal(isSymmetric({}),expectedResult);
        assert.equal(isSymmetric(true),expectedResult);
        assert.equal(isSymmetric(undefined),expectedResult);
    });
    
    it('Should return true when input is symmetric', () => {
        let arr = [1, 2, 3, 2, 1];
        let expectedResult = true;
        let actualResult = isSymmetric(arr);
    
        assert.equal(expectedResult,actualResult);
    });
    
    it('Should return false when input is not symmetric', () => {
        let arr = [1, 2, 3, 3, 1];
        let expectedResult = false;
        let actualResult = isSymmetric(arr);
    
        assert.equal(expectedResult,actualResult);
    });

    it('Should return false when some of the ement in array is not a number', () => {
        let arr = [1, '1'];
        let expectedResult = false;
        let actualResult = isSymmetric(arr);
    
        assert.equal(expectedResult,actualResult);
    });    

    it('Should pass when input is empty array', () => {
        let arr = [];
        let expectedResult = true;
        let actualResult = isSymmetric(arr);
    
        assert.equal(expectedResult,actualResult);
    });    
});
