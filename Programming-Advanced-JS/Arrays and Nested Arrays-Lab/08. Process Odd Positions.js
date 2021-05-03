function solve (array){

    const soretedArray = [];

    for(let i = 0; i < array.length ; i++){

        if (i % 2 != 0){

            let num = array[i] * 2;
            soretedArray.unshift(num);

        }
    }

    return soretedArray.join(' ');
}

console.log(solve([10, 15, 20, 25]));
console.log(solve([3, 0, 10, 4, 7, 3]));