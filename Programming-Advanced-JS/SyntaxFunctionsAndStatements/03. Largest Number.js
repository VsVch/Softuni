function largestnumber(a, b, c){

    let num;
    if(a >b && a>c){
        num =a;

    }  else if(b > a && b > c){
        num = b;
    }else{
        num =c;
    }
    console.log('The largest number is ' + num +'.');
}

largestnumber(5, -3, 16);
largestnumber(-3, -5, -22.5);