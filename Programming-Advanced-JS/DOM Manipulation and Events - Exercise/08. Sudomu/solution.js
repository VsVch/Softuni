function solve() {

    let buttons = document.querySelectorAll('#exercise tfoot button');
    let checkButton = buttons[0];
    let clearButton = buttons[1];

    checkButton.addEventListener('click', checkBoard)

    function checkBoard() {
        let board = Array
            .from(document.querySelectorAll('#exercise tbody tr'))
            .map(row => Array.from(row.querySelectorAll('input'))
                .map(x => Number(x.value)));

        let isValid = isValidSudoku(board);
        let checkParagraph = document.querySelector('#check p');
        let table = document.querySelector('#exercise table');

        table.style.border = isValid ? '2px solid green' : '2px solid red'
        checkParagraph.textContent = isValid ? 
        'You solve it! Congratulations!' : 
        'NOP! You are not done yet...';
        checkParagraph.style.color = isValid ? 'green' : 'red';

        clearButton.addEventListener('click', clear);      
        
    }
    
    
    function isValidSudoku(board) {
        for (let row = 0; row < board.length; row++) {
            let rowObj = {1: 0, 2: 0, 3: 0};
            let colObj = {1: 0, 2: 0, 3: 0};

            for (let col = 0; col < board[row].length; col++) {
                let curRowCell = board[row][col];
                let curColCell = board[col][row];

                rowObj[curRowCell]++;
                colObj[curColCell]++;
            }
            let rowValues = Object.values(rowObj);
            let colValues = Object.values(colObj);

            if(rowValues.length > board.length || rowValues.some(x => x !== 1)
            || colValues.length > board.length || colValues.some(x => x !== 1)){
                return false;
            }

        }
        return true;
    }

    function clear(){
        let checkParagraph = document.querySelector('#check p');
        let table = document.querySelector('#exercise table');
        let board = Array.from(document.querySelectorAll('#exercise tbody tr'))
        .map(row => Array.from(row.querySelectorAll('input')));
        
        checkParagraph.textContent = '';
        table.style.border = '';
        board = forEach(x => x.value = '');
    }       
}