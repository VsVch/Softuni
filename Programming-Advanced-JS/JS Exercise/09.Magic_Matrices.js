function solve(arr) {
  let isMagic = true; 
  let sum = 0;
  arr[0].forEach(item => {
    sum += item;
  });

  for (let row = 0; row < arr.length; row++) {
    let rowSum = 0;
    let colSum = 0;

    for (let col = 0; col < arr.length; col++) {
      rowSum += arr[row][col];
      colSum += arr[col][row];
    }

    if (rowSum !== colSum || sum !== rowSum || sum !== colSum) {
      isMagic = false;
      break;
    }
  }
 
  return isMagic;
}

console.log(
  solve([
    [4, 5, 6],
    [6, 5, 4],
    [5, 5, 5],
  ])
);

console.log(
  solve([
    [11, 32, 45],
    [21, 0, 1],
    [21, 1, 1],
  ])
);

console.log(
  solve([
    [1, 0, 0],
    [0, 0, 1],
    [0, 1, 0],
  ])
);
