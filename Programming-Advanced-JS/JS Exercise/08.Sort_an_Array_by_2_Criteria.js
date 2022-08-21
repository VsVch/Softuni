function solve(arr) {
  arr.sort(
    (a, b) =>
      a.length - b.length || a.toLowerCase().localeCompare(b.toLowerCase())
  );

  for (const item of arr) {
    console.log(item);
  }
}

solve(["alpha", "beta", "gamma"]);
solve(["Isacc", "Theodor", "Jack", "Harrison", "George"]);
solve(["test", "Deny", "omen", "Default"]);
