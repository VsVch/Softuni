function sum (array, firstIndex, endIndex){
if (firstIndex < 0 ) {
    firstIndex = 0;
}

if (!Array.isArray(array)) {
    return NaN;
}

if (array.length === 0) {
    return 0;
}

let res = array.every(function(element) {return typeof element === 'number';});

if (res === false) {
    return NaN;
}

let result = array.slice(firstIndex, endIndex + 1).reduce((acc, a) => acc + a,0);
return  result
}

function testSubSum1(){
    let array = [10, 20, 30, 40, 50, 60];
    let startIndex = 3;
    let endIndex = 300;

    let expextetResult = 150;

    let ectualResult = sum(array,startIndex,endIndex);

    if(expextetResult === ectualResult){
        console.log('test pass!!');
    }else{
        console.log('test faild');
    }
}
testSubSum1();

function testSubSum2(){
    let array = [1.1, 2.2, 3.3, 4.4, 5.5];
    let startIndex = -3;
    let endIndex = 1;

    let expextetResult = 3.3;

    let ectualResult = (sum(array,startIndex,endIndex)).toFixed(1);

    if(expextetResult === Number(ectualResult)){
        console.log('test pass!!');
    }else{
        console.log('test faild');
    }
}
testSubSum2();

function testSubSum3(){
    let array = [10, 'twenty', 30, 40];
    let startIndex = 0;
    let endIndex = 2;

    let expextetResult = NaN;

    let ectualResult = sum(array,startIndex,endIndex);

    if(expextetResult.valueOf == ectualResult.valueOf){
        console.log('test pass!!');
    }else{
        console.log('test faild');
    }
}
testSubSum3();

function testSubSum4(){
    let array = [];
    let startIndex = 1;
    let endIndex = 2;

    let expextetResult = 0;

    let ectualResult = sum(array,startIndex,endIndex);

    if(expextetResult == ectualResult){
        console.log('test pass!!');
    }else{
        console.log('test faild');
    }
}
testSubSum4();

function testSubSum5(){
    let array = 'text';
    let startIndex = 0;
    let endIndex = 2;

    let expextetResult = NaN;

    let ectualResult = sum(array,startIndex,endIndex);

    if(expextetResult.valueOf == ectualResult.valueOf){
        console.log('test pass!!');
    }else{
        console.log('test faild');
    }
}
testSubSum5();
