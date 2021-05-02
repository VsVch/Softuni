function solve(array){

    let firstElement = Number(array.shift());
    let secondElement = Number(array.pop());

    return firstElement + secondElement;
}

console.log(solve(['20', '30', '40']));
console.log(solve(['5', '10']));
