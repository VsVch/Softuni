function solve(arr) {

    let array = [];

    for(let row = 0; row < arr.length; row++){

        let sumRow = 0; 
        let sumCol = 0; 
        

        for(let col = 0; col < arr.length; col++){

            sumRow += arr[row][col];
            sumCol += arr[col][row];            
        }
        array.push(sumRow);
        array.push(sumCol);

    }
    return array.every((el, i , arr)=>el === arr[0]);
}

console.log(solve(
    [[4, 5, 6],
 [6, 5, 4],
 [5, 5, 5]]


));