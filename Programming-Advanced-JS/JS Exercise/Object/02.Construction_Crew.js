function solve(obj) {

    worker = {
        weight: obj.weight,
        experience: obj.experience,
        levelOfHydrated: obj.levelOfHydrated,
        dizziness: obj.dizziness,
    };

    if (obj.dizziness) {
        worker.levelOfHydrated += 0.1 * worker.experience * worker.weight;
        worker.dizziness = false;
    }

    return worker; 
}

console.log(solve({ weight: 80,
    experience: 1,
    levelOfHydrated: 0,
    dizziness: true }
  ));

  console.log(solve({ weight: 120,
    experience: 20,
    levelOfHydrated: 200,
    dizziness: true }  
  ));

  console.log(solve({ weight: 95,
    experience: 3,
    levelOfHydrated: 0,
    dizziness: false }    
  ));
