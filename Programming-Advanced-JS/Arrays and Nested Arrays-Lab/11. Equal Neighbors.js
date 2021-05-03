function solve(matrix) {

    let equalCount = 0;
    for (let row = 0; row < matrix.length ; row++) {

        for (let col = 0; col < matrix[row].length; col++) {

            let firstPosition = matrix[row][col];        
            let secondPositionRow;            
            let secondPositionCol; 
            
            if(row < matrix.length -1){ 

                secondPositionRow =  matrix[row + 1][col];     
            }

            if(col < matrix[row].length -1){ 

                secondPositionCol =  matrix[row][col +1];     
            }

            if (firstPosition === secondPositionRow) {
                equalCount++;
            }

            if (firstPosition === secondPositionCol) {
                equalCount++;
            }
        }
    }
    return equalCount;
}

// console.log(solve([
//     ['2', '3', '4', '7', '0'],
//     ['4', '0', '5', '3', '4'],
//     ['2', '3', '5', '4', '2'],
//     ['9', '8', '7', '5', '4']]
// ));
// console.log(solve([
//     ['test', 'yes', 'yo', 'ho'],
//     ['well', 'done', 'yo', '6'],
//     ['not', 'done', 'yet', '5']]
// ));
console.log(solve([
    ['2', '2', '3', '7', '4'],
    ['4', '0', '5', '3', '4'],   
    ['2', '5', '5', '4', '2']]
));
