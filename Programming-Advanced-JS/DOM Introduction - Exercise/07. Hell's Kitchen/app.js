function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);
   let input = document.querySelector('#inputs>textarea');
   const bestResturantP = document.querySelector('#bestRestaurant>p');
   const workersP = document.querySelector('#workers>p');

   function onClick() {
      const arr = JSON.parse(input.value);

      let restaurants = {}

      arr.forEach((line) => {
         const tokens = line.split(' - ');
         const name = tokens[0];
         const workersArr = tokens[1].split(', ');
         let workers = [];


         for (let worker of workersArr) {
            const workersToken = worker.split(' ');
            const salary = Number(workersToken[1]);
            workers.push({
               name: workersToken[0], salary
            })
         }
         if (restaurants[name]) {
            workers = workers.concat(restaurants[name].workers);
         }
         workers.sort((w1, w2) => w2.salary - w1.salary);

         const bestSalary = workers[0].salary;
         const averageSalary = workers
         .reduce((sum, worker) => sum + worker.salary, 0) / workers.length;

         restaurants[name] = {
            workers,
            averageSalary,
            bestSalary
         }
      })

     let best = undefined;
     let bestRestaurantSalary = 0;

     for(const name in restaurants){

      if(restaurants[name].averageSalary > bestRestaurantSalary){
         best = {
            name, 
            workers: restaurants[name].workers,
            bestSalary: restaurants[name].bestSalary,
            averageSalary: restaurants[name].averageSalary,
         };

         bestRestaurantSalary = restaurants[name].averageSalary;
      }
     }
     bestResturantP.textContent = `Name: ${best.name} Average Salary: ${best.averageSalary.toFixed(2)} Best Salary: ${best.bestSalary.toFixed(2)}`;

      let workersResult = [];

      best.workers.forEach(worker => {
         workersResult.push(`Name: ${worker.name} With Salary: ${worker.salary}`);
      })

      workersP.textContent = workersResult.join(" ");
   }
}