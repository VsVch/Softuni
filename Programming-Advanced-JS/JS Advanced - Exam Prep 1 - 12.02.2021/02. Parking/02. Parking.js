class Parking {

    constructor(capacity) {
        this.capacity = capacity;
        this.vehicles = [];
    }

    addCar(carModel, carNumber) {

        if (this.capacity - this.vehicles.length === 0) {
            throw new Error('Not enough parking space.');
        }

        this.vehicles.push({ carModel, carNumber, payed: false });

        return `The ${carModel}, with a registration number ${carNumber}, parked.`;
    }

    removeCar(carNumber) {

        let currCar = this.findCar(carNumber);

        if (!currCar) {
            throw new Error(`The car, you're looking for, is not found.`);
        }

        if (currCar.payed === false) {
            throw new Error(`${carNumber} needs to pay before leaving the parking lot.`)
        }

        this.vehicles.pop(currCar);

        return `${carNumber} left the parking lot.`;

    }

    pay(carNumber) {
        let currCar = this.findCar(carNumber);

        if (!currCar) {
            throw new Error(`${carNumber} is not in the parking lot.`);
        }

        if (currCar.payed === true) {
            throw new Error(`${carNumber}'s driver has already payed his ticket.`)
        }

        currCar.payed = true;

        return `${carNumber}'s driver successfully payed for his stay.`
    }

    getStatistics(carNumber) {

        if (carNumber) {

            let car = this.findCar(carNumber);
            return this.carInfo(car);

        } else if (carNumber === undefined) {
            let result = [];
            result.push(`The Parking Lot has ${this.capacity - this.vehicles.length} empty spots left.`);

            let sortedVehicles = this.vehicles.slice().sort((a, b) => a.carModel.localeCompare(b.carModel));

            for (const car in sortedVehicles) {
                result.push(this.carInfo(sortedVehicles[car]));
            }

            return result.join('\n');
        }
    }

    carInfo(car) {

        return `${car.carModel} == ${car.carNumber} - ${car.payed === true ? 'Has payed' : 'Not payed'}`;

    }

    findCar(carNumber) {
        let car = this.vehicles.find(x => x.carNumber === carNumber);
        return car;
    }
}


const parking = new Parking(12);
console.log(parking.addCar("Volvo t600", "TX3691CA"));
console.log(parking.getStatistics());

console.log(parking.pay("TX3691CA"));
console.log(parking.removeCar("TX3691CA"));

