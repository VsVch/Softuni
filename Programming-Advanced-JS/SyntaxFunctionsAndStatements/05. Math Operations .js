function solve(num1, num2, func) {
    let result;

    switch (func) {
        case '+':
            result = num1 + num2;
            break;
        case '-':
            result = num1 - num2;
            break;
        case '*':
            result = num1 * num2;
            break;
        case '/':
            result = num1 / num2;
            break;
        case '%':
            result = num1 % num2;
            break;
        case '**':
            result = num1 ** num2;
            break;
    }
    return result;
}

console.log(solve(5, 6, '+'));
console.log(solve(3, 5.5, '*'));