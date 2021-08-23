function solve(a, b) {

  

  // array.reduce((acc, x, b, arr) => {
  //   return acc + b
  // }, 1)
  let arr = [1,];  

  for (let i = 0; i < a -1; i++) {
    
    let el = 0;

    for (let j = i - b + 1; j < arr.length; j++) {      

      let currEl = arr[j];
      if (currEl === undefined) {
        currEl = 0;
      }
      el += currEl;
    }

    arr.push(el);
  }
  return arr;
}

console.log(solve(6, 3));
console.log(solve(8, 2));