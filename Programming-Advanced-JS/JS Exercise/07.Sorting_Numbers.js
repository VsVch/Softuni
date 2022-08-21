function solve(arr) {
    arr.sort((a, b) => a-b);
    let counter = arr.length - 1;

    let newArr = new Array();
    let oddEl;
    let forCycle = Math.floor(arr.length / 2);
   

    if(arr.length % 2 != 0){
        oddEl  = arr.slice(arr.length / 2,arr.length / 2 + 1 )               
    }

    for (let i = 0; i < forCycle; i++) {
        const beginingEl = arr[i];
        const endEl = arr[counter];
        newArr.push(beginingEl);
        newArr.push(endEl);

        counter --;       
    } 

    if (oddEl) {
        newArr.push(oddEl[0]);
    }

    return newArr;
}
  
  console.log(solve(
    [1, 65, 3, 52, 48, 63, 31, -3, 18, 56, 35]
    ));
  