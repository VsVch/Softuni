function solve(num) {

    let matrix = [];
    let string = '';

    if (!num) {
        num = 5;
    }   
    
    for (var i = 0; i < num; i++) {
        matrix[i] = new Array(num).fill('*').join(' ');
            string += `${matrix[i]}\n`;
    }

    return string;

}
console.log(solve(1));
console.log(solve(2));
console.log(solve(5));
console.log(solve(''));