function solve(speed, area) {
     let speedLimit = 0;

     if(area === 'residential'){
        speedLimit = 20;
     }else if(area === 'city'){
        speedLimit = 50;
     }else if(area === 'interstate'){
        speedLimit = 90;
    }else if(area === 'motorway'){
        speedLimit = 130;
    }


    if (speedLimit < speed)
    {
        let deference = speed - speedLimit;
        let status = ' ';

        if(deference<= 20){
            status = 'speeding';
        }
        else if (deference<= 40){
            status = 'excessive speeding';
        }
        else{
            status = 'reckless driving';
        }

        return`The speed is ${speed - speedLimit} km/h faster than the allowed speed of ${speedLimit} - ${status}`;

    }
    else{
        return `Driving ${speed} km/h in a ${speedLimit} zone`;
    }    
}

console.log(solve(40, 'city'));
console.log(solve(21, 'residential'));
console.log(solve(120, 'interstate'));
console.log(solve(200, 'motorway'));