function solve(arr, rotarion) {
    let cycle = rotarion;

    if (rotarion > arr.length) {
        cycle = Math.round(rotarion % arr.length)
    }

    for (let i = 0; i < cycle; i++) {
        const element = arr.pop(arr[arr.length -1]);
        arr.unshift(element)        
    }

    return arr.join(' ');
}

console.log(solve(
    ['1', 
'2', 
'3', 
'4'], 
2
))

console.log(solve(
    ['Banana', 
    'Orange', 
    'Coconut', 
    'Apple'], 
    15
    
))