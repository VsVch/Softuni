function solve(arr, criteria) {
    let array = JSON.parse(arr);
    let [key, value] = criteria.split('-');
    
    let colection = [];  
    let counter = 0;
    for (const el in array){ 

        //console.log(array[el][key]);

        if (array[el][key] === value) {
            colection.push(`${counter++}. ${array[el]['first_name']} ${array[el]['last_name']} - ${array[el]['email']}`); 
                     
        }   
       
    }

   return colection.join('\n').trimEnd();
}