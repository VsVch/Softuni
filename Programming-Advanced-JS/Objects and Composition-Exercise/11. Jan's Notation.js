function solve(array) {

    let numArray = [];

    let isNumber = true;

    function operators(operator, numOne, numTwo) {

        const obj = {
            '+': () => numOne + numTwo,
            '-': () => numOne - numTwo,
            '/': () => numOne / numTwo,
            '*': () => numOne * numTwo,
        }
        return obj[operator]();
    }

    for (let i = 0; i < array.length; i++) {

        if (!isNaN(array[i])) {

            numArray.push(array[i]);

        } else {
            let operator = array[i];
            let numTwo = numArray.pop();
            let numOne = numArray.pop();

            if (isNaN(numTwo) || isNaN(numOne)) {
                isNumber = false;
                break;
            }

            let result = operators(operator, numOne, numTwo);
            numArray.push(result);            
        }

    }

    if (isNumber === false) {
        console.log('Error: not enough operands!');
    }

    if(numArray.length > 1){
        console.log('Error: too many operands!');
    }else{
        return numArray.join();
    }

}
