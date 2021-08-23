function solve(num){
   let stringNum = num.toString();
   let isValid = true;
   let sumNums = 0;
   let firstNum = 0;

   for(let i = 0; i < stringNum.length; i ++)
   {
       let currentNum = Number(stringNum[i]);
       firstNum = Number(stringNum[0]);
       if(firstNum !== currentNum){
           isValid = false;           
       }
       sumNums += currentNum;
   }

   return `${isValid}\n${sumNums}`;
}
console.log(solve(2222222));
console.log(solve(1234));