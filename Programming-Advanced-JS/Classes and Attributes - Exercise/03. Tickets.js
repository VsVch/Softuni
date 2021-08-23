function solve(array, criteria) {

    let tikets = [];

    class Ticket {

        constructor(destination, price, status) {
            this.destination = destination;
            this.price = price;
            this.status = status;
        }
    }

    for (const element of array) {
        let [destination, price, status] = element.split('|');
        price = Number(price);

        let tiket = new Ticket(destination, price, status);
        tikets.push(tiket);
    }

    if (criteria === 'price') {
        tikets.sort((a, b) => a - b);
    } else if(criteria === 'status') {        
        tikets.sort((a, b) => (a.status).localeCompare(b.status));
    }else if(criteria === 'destination'){
        tikets.sort((a, b) => (a.destination).localeCompare(b.destination));
    }    

    return tikets;
}

console.log(solve(['Philadelphia|94.20|available',
    'New York City|95.99|available',
    'New York City|95.99|sold',
    'Boston|126.20|departed'],
    'destination'
))