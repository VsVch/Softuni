function solve() {    

    let arriveButton = document.getElementById('arrive');
    let departButton = document.getElementById('depart');

    let banner =  document.querySelector('#info span');
    
    let stop = {
        next: 'depot'
    }

    async function depart() {   
       
        try {
            let url = `http://localhost:3030/jsonstore/bus/schedule/${stop.next}`;

            let responce = await fetch(url);
            let date = await responce.json();            

            departButton.disabled = true;
            arriveButton.disabled = false;         
          
            stop = date; 
            banner.textContent = `Next stop ${stop.name}`

        } catch (error) {
            banner.textContent = 'Error';
        }
    }

    function arrive() {
        
        banner.textContent = `Arriving at ${stop.name}`;

        arriveButton.disabled = true;
        departButton.disabled = false;        
    }

    return {
        depart,
        arrive
    };
}

let result = solve();