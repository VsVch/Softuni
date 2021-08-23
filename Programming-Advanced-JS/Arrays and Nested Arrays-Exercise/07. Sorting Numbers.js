function solve (arr){
const array = [];
arr.sort((a,b)=> a-b);

while(arr.length){   
    
    array.push(arr.shift());    
    array.push(arr.pop()); 
}
return array.filter(num => num !== undefined)
}

console.log(solve([1, 65, 3, 52, 48, 63, 31, -3, 18, 56, 5]));