function solve(arr, rotation) {
    let element;
    for (let i = 0; i < rotation; i++) {

        element = arr.pop();
        arr.unshift(element);

    }
    return arr.join(' ');
}
console.log(solve(
    ['Banana',
    'Orange',
    'Coconut',
    'Apple'],
    15
));
//console.log(solve());