function isNumberOrString(input){
    let result = typeof(input);
    if(result === 'number'){
        let result = Math.pow(input, 2) * Math.PI;
        console.log(result.toFixed(2));
    }  else{
      
       console.log('We can not calculate the circle area, because we receive a ' + result + '.');
    }
}
isNumberOrString(5);
isNumberOrString('name');
