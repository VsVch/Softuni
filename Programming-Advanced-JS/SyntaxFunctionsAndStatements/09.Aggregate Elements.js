function solve(arr){

    let sum = 0;
    let reverceNum = 0;
    let numString = '';

    for (let i = 0; i < arr.length; i++) {
        
        sum += arr[i];
        reverceNum +=1 / arr[i];
        numString += (arr[i]).toString();
        
    } 
    
    return `${sum}\n${reverceNum}\n${numString}`;

}
console.log(solve([1, 2, 3]))
console.log(solve([2, 4, 8, 16]))