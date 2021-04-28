function solve(num) {
    //    let matrix = [];
    //    let currNumber = num;
    let row = num;
    let col = num;
    let symbol = '* ';

    if (currNumber = ' ') {
        row = 5;
        col = 5;

        function Matrix(row, col, symbol) {
            var mat = Array.apply(null, new Array(row)).map(
                Array.prototype.valueOf,
                Array.apply(null, new Array(col)).map(
                    function () {
                        return symbol;
                    }
                )
            );
            return mat;
        }

    } else {

        function Matrix(row, col, symbol) {
            var mat = Array.apply(null, new Array(row)).map(
                Array.prototype.valueOf,
                Array.apply(null, new Array(col)).map(
                    function () {
                        return symbol;
                    }
                )
            );
            return mat;
        }
        //console.table(matrix);
    }
}
    console.log(solve(1));
    console.log(solve(2));
    console.log(solve(5));
    console.log(solve(' '));