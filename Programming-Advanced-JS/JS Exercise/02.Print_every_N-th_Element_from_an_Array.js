function solve(arr, step) {
  return arr.filter((x, i) => i % step == 0 && x);
}

console.log(solve(["5", "20", "31", "4", "20"], 2));

console.log(solve(["dsa", "asd", "test", "tset"], 2));

console.log(solve(["1", "2", "3", "4", "5"], 6));
