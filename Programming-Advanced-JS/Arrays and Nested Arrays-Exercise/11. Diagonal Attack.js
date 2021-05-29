function solve(matrixRows) {

    let matrix = matrixRows.map(
        row => row.split(' ').map(Number));

    let mainDiagonal = 0;
    let secondDiagonal = 0;


    for (let row = 0; row < matrix.length; row++) {
        mainDiagonal += matrix[row][row];
        
    }

    for (let row = 0; row < matrix.length; row++) {
        
        secondDiagonal += matrix[row][matrix.length - 1 - row]
    }

    if (mainDiagonal === secondDiagonal) {

        for (let row = 0; row < matrix.length; row++) {

            for (let col = 0; col < matrix.length; col++) {

                if (row !== col && matrix[row][col] !== matrix[row][matrix.length - 1 - row]) {
                    matrix[row][col] = mainDiagonal;
                }
            }

        }  
                  
    } 
    for (let row = 0; row < matrix.length; row++) {
    
        console.log(matrix[row].join(' '));
    }    
   
}


console.log(solve(
    ['5 3 12 3 1',
        '11 4 23 2 5',
        '101 12 3 21 10',
        '1 4 5 2 2',
        '5 22 33 11 1']

))

// console.log(solve(
//     ['1 1',
//      '1 1'
//     ]

// ))

// console.log(solve(
//     ['1 1 1',
//     '1 1 1',
//     '1 1 0']
    
    

// ))