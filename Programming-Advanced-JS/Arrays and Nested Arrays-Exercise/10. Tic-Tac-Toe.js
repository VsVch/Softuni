function solve(commands) {

    let board = [['false', 'false', 'false'],
    ['false', 'false', 'false'],
    ['false', 'false', 'false']];


    let isPlayerX = true

    for (let i = 0; i < commands.length; i++) {

        let command = commands[i].split(' ').map(x => Number(x));

        row = command[0];
        col = command[1];

        if (board[row][col] !== 'false') {
            console.log(`This place is already taken. Please choose another!`);
           
            continue;
        }
        board[row][col] = isPlayerX ? 'X' : 'O';
        let gameEnded = hasGameEnded(board);
        isPlayerX = !isPlayerX;
        if (gameEnded) {
            break;
        }
    }

    for (let row = 0; row < board.length; row++) {
        console.log(board[row].join('\t'));

    }

    function hasGameEnded(board) {
        for (let row = 0; row < board.length; row++) {
            let isSameX = board[row].every(x => x === 'X');
            let isSameO = board[row].every(x => x === 'O');

            if (isSameX || isSameO) {
                console.log(`Player ${isSameX ? 'X' : 'O'} wins!`);
                return true;
            }
        }

        for (let col = 0; col < board.length; col++) {
            if (board[0][col] === board[1][col] &&
                board[1][col] === board[2][col] &&
                board[0][col] !== 'false') {
                console.log(`Player ${board[0][col]} wins!`);
                return true;
            }
        }

        if (board[0][0] === board[1][1] &&
            board[1][1] === board[2][2] &&
            board[0][0] !== 'false') {
            console.log(`Player ${board[0][0]} wins!`);
            return true;
        }

        if (board[2][0] === board[1][1] &&
            board[1][1] === board[0][2] &&
            board[2][0] !== 'false') {
            console.log(`Player ${board[2][0]} wins!`);
            return true;
        }

        if (board[0].every(x => x !== 'false') &&
            board[1].every(x => x !== 'false') &&
            board[2].every(x => x !== 'false')) {
            console.log(`The game ended! Nobody wins :(`);
            return true;
        }
    }
}

console.log(solve(
    ["0 2",
        "1 0",
        "1 1",
        "0 0",
        "2 0",
        ]



));