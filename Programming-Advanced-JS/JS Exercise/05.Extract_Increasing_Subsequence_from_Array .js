function solve(arr) {
  let element = arr[0];
  const newArr  = new Array();
  
//   let newArr = arr.filter((x) => {
//     if (x >= element) {
//       element = x;
//       return x;
//     }    
//   });

    for (let i = 0; i < arr.length; i++) {
        const el = arr[i];

        if (el >= element) {
            element = el;
            newArr.push(el);
        }        
    }
  
  return newArr;
}

console.log(solve([1, 3, 8, 4, 10, 12, 3, 2, 24]));
console.log(solve([1, 2, 3, 4]));
console.log(solve([20, 3, 2, 15, 6, 1]));
