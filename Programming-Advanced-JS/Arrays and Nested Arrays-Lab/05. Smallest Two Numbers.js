function solve(array){

    array.sort((a, b) => a - b);

    firstNum = array[0];
    secondNum = array[1];

    return `${firstNum} ${secondNum}`;
}

console.log(solve([30, 15, 50, 5]));
console.log(solve([3, 0, 10, 4, 7, 3]));