function solve(numOne, numTwo) {
    
    let index = numOne * numTwo;
    let matrix = Array(numOne).fill().map(()=>Array(numTwo).fill(0));

    let startPosition = 'Right';
    let currRow = 0;
    let currCol = 0;

    for (let i = 1; i <= index; i++) {        

        if (startPosition === 'Right') {

            matrix[currRow][currCol] = i;
            currCol++;

            if(matrix[currRow][currCol] != 0){
                startPosition = 'Up'
                currCol --;
                currRow ++;

            }else if (currCol == numOne - 1) {
                startPosition = 'Up'
               
            }else if(matrix[currRow][currCol] != 0 && numOne - 1){
                currCol --;
            }

        }else if(startPosition === 'Up' ){
            matrix[currRow][currCol] = i;
            currRow ++;

            if (matrix[currRow][currCol] != 0) {
                startPosition = 'Left'
                currRow --;
                currCol --;

            }else if (currRow == numTwo - 1 ) {
                startPosition = 'Left'
               
            }else if(matrix[currRow + 1][currCol] != 0 && currRow == numTwo - 1 ){
                currRow --;
            }

        }else if(startPosition === 'Left'){
            matrix[currRow][currCol] = i;
            currCol--;

            if (matrix[currRow][currCol] != 0) {
                startPosition = 'Down';
                currRow --;
                currCol ++;
            }else if (currCol == 0) {
                startPosition = 'Down';
                
            }else if(matrix[currRow][currCol - 1] != 0 && currRow == 0){
                currCol ++;
            }

        }else if(startPosition === 'Down'){
            matrix[currRow][currCol] = i;
            currRow --;

            if(matrix[currRow][currCol] != 0){
                startPosition = 'Right';
                currRow ++;
                currCol ++;

            }else if (currRow == 0) {
                startPosition = 'Right'
                      
            }else if(matrix[currRow][currCol] != 0 && currRow == 0){
                currRow ++;
            }
        }     
    }

    for (let row = 0; row < matrix.length; row++) {
    
        console.log(matrix[row].join(' '));
    }       

}

console.log(solve(5, 5))