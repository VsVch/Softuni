class Bank {

    constructor(bankName) {
        this._bankName = bankName;
        this.allCustomers = [];       
    }

    newCustomer({ firstName, lastName, personalId }) {

        let currCustomer = this.findPerson(personalId);

        if (currCustomer) {
            throw new Error(`${firstName} ${lastName} is already our customer!`);
        }

        this.allCustomers.push({ firstName, lastName, personalId, totalMoney: 0, deposit: [] });

        return `{ firstName: '${firstName}', lastName: '${lastName}', personalId: ${personalId} }`;
    }

    depositMoney(personalId, amount) {

        let currCustomer = this.findPerson(personalId);
        this.personValidate(currCustomer);

        currCustomer.totalMoney += amount;
        currCustomer.deposit.push({ amount, transaction: true });

        return `${currCustomer.totalMoney}$`;
    }

    withdrawMoney(personalId, amount) {
        let currCustomer = this.findPerson(personalId);
        this.personValidate(currCustomer);

        if (currCustomer.totalMoney < amount) {
            throw new Error(`${currCustomer.firstName} ${currCustomer.lastName} does not have enough money to withdraw that amount!`);
        }

        currCustomer.totalMoney -= amount;
        currCustomer.deposit.push({ amount, transaction: false });

        return `${currCustomer.totalMoney}$`;
    }

    customerInfo(personalId) {

        let currCustomer = this.findPerson(personalId);
        this.personValidate(currCustomer);


        let result = [];
        result.push(`Bank name: ${this._bankName}`);
        result.push(`Customer name: ${currCustomer.firstName} ${currCustomer.lastName}`);
        result.push(`Customer ID: ${currCustomer.personalId}`);
        result.push(`Total Money: ${currCustomer.totalMoney}$`);
        result.push(`Transactions:`);

        let depositReverced = currCustomer.deposit.reverse();
        let counter = depositReverced.length;

        for (const deposit of depositReverced) {

            result.push(`${counter}. ${currCustomer.firstName} ${currCustomer.lastName} ${deposit.transaction === true ? 'made deposit of' : 'withdrew'} ${deposit.amount}$!`);
            counter--;
        }

        return result.join('\n');

    }

    personValidate(person) {

        if (person === undefined) {
            throw new Error(`We have no customer with this ID!`);
        }
    }

    findPerson(personalId) {

        let person = this.allCustomers.find(x => x.personalId === personalId);
        return person;
    }
}

let bank = new Bank('SoftUni Bank');

console.log(bank.newCustomer({firstName: 'Svetlin', lastName: 'Nakov', personalId: 6233267}));
console.log(bank.newCustomer({firstName: 'Mihaela', lastName: 'Mileva', personalId: 4151596}));

bank.depositMoney(6233267, 250);
console.log(bank.depositMoney(6233267, 250));
bank.depositMoney(4151596,555);

console.log(bank.withdrawMoney(6233267, 125));

console.log(bank.customerInfo(6233267));


