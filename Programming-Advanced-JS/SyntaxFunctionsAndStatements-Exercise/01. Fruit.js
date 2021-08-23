function solve(fruit, weightInGrams, pricePerCilogram){

    let weight = weightInGrams / 1000;
    let money = weight * pricePerCilogram;

    return `I need $${money.toFixed(2)} to buy ${weight.toFixed(2)} kilograms ${fruit}.`
}

console.log(solve('orange', 2500, 1.80));
console.log(solve('apple', 1563, 2.35));