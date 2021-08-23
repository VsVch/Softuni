function solve (arr, delimeter) {
    return arr.join(delimeter);
}
console.log(solve(
    ['One',
        'Two',
        'Three',
        'Four',
        'Five'],
    '-'
));
console.log(solve([
    'How about no?',
    'I',
    'will',
    'not',
    'do',
    'it!'],
    '_'
));