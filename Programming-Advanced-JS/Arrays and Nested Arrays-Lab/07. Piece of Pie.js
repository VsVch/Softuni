function solve (array, strinOne, stringTwo) {

    let firstIndex = array.indexOf(strinOne,0);
    let secondIndex = array.indexOf(stringTwo, 0);

   let newArray = array.slice(firstIndex, secondIndex + 1);

   return newArray

}

// console.log(solve(['Pumpkin Pie','Key Lime Pie','Cherry Pie','Lemon Meringue Pie','Sugar Cream Pie'],
// 'Key Lime Pie',
// 'Lemon Meringue Pie'
// ));
console.log(solve(['Apple Crisp','Mississippi Mud Pie','Pot Pie','Steak and Cheese Pie','Butter Chicken Pie','Smoked Fish Pie']
,'Pot Pie',
'Smoked Fish Pie'
));