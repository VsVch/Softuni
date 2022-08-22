function solve(arr) {

    let obj = {};
    for (let i = 0; i < arr.length; i+=2) {
        let prop = arr[i];
        let val =Number(arr[i + 1]);
        
        obj[prop] = val;
    }
    return obj
}

console.log(solve(['Yoghurt', '48', 'Rise', '138', 'Apple', '52']));
console.log(solve(['Potato', '93', 'Skyr', '63', 'Cucumber', '18', 'Milk', '42']));