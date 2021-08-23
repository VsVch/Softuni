function solve(array) {

    const sortedArray = [];

    for (let i = 0; i < array.length ; i ++) {

        if(array[i] < 0){
            sortedArray.unshift(array[i]);
        }else{
            sortedArray.push(array[i]);
        }
    }
    return sortedArray.join('\n');
}

console.log(solve([7, -2, 8, 9]));
console.log(solve([3, -2, 0, -1]));