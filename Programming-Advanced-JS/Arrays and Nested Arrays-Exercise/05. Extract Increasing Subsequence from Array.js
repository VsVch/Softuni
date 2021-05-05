function solve(arr) {   

   return arr.reduce(function(result, currentValue, index, initialArray)
    {
        if(currentValue >= result[result.length - 1] || result.length === 0){
            
            result.push(currentValue);           
        }
        return result;
    },[]);

    // let refNum = 0;
    // const array = [];

    // for(let i = 0; i<arr.length; i++){
        
    //     if(refNum <= arr[i]){
    //         refNum = arr[i];
    //         array.push(arr[i]);
    //     }
    // }
    //return array;
    
}

console.log(solve(
    [20, 
        3, 
        2, 
        15,
        6, 
        1]     
));