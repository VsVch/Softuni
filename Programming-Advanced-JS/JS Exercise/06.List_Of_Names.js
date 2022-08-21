function solve(arr) {
  let newArr = arr
    .sort((a, b) => a.localeCompare(b))
    .map((x, i) => `${i + 1}.${x}`);

  newArr.forEach((element) => {
    console.log(element);
  });
}

solve(["John", "Bob", "Christina", "Ema"]);
