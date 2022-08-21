function solve (arr ){

    const newArr = new Array();
    for (let i = 0; i < arr.length; i++) {
        
        if (arr[i] =='add') {
            newArr.push(i + 1);
        }else{
            newArr.pop(arr[i - 1]);
        }        
    }

    if (newArr.length == 0) {
        console.log('Empty');
    }else{
        for (const num of newArr) {
            console.log(num);
        }
    }
}

solve (
    ['add', 
'add', 
'add', 
'add'])

solve (
    ['add', 
    'add', 
    'remove', 
    'add', 
    'add']
    )

solve (
    ['remove', 
'remove', 
'remove']

)