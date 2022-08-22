function solve(obj) {

    let weelsSizeArray = new Array(4);    

    let car = { model: obj.model,
        engine: sellectEngine(obj.power),        
        carriage: sellectCarrirage (obj.carriage, obj.color),
        wheels: [...weelsSizeArray].map(x => obj.wheelsize % 2 == 0 ? obj.wheelsize - 1 : obj.wheelsize), 
    }

      return car;

      function sellectCarrirage(carriageType, color){
        let carCarriage = {
            type: carriageType,
            color
        }
        return carCarriage;
    }
    
    function sellectEngine (currPower) {
    
        let engine = {
            power: '',
            volume: ''
        }
    
        if (currPower <= 90) {
            engine.power = 90,
            engine.volume = 1800
        }else if (currPower > 90 && currPower <= 120) {
            engine.power = 120,
            engine.volume = 2400
        }else {
            engine.power = 200,
            engine.volume = 3500
        }
    
        return engine;
    }
    
}

console.log(solve({ model: 'VW Golf II',
power: 90,
color: 'blue',
carriage: 'hatchback',
wheelsize: 14 }
));

console.log(solve({ model: 'Opel Vectra',
power: 110,
color: 'grey',
carriage: 'coupe',
wheelsize: 17 }
));