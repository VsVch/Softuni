function cityRecords(name, population, treasury) {

    const city = {
        name,
        population,
        treasury,
        taxRate: 10,
        collectTaxes() {
            this.treasury += this.population * this.taxRate;
        },
        applyGrowth(percentage) {
            this.population += Math.floor(this.population * percentage / 100);
        },
        applyRecession(percentage) {
            this.treasury -= Math.ceil(this.treasury * percentage / 100);
        }
    };

    return city;
}

const result = cityRecords('Tortuga', 7000, 15000);
//console.log(result);

result.collectTaxes();
result.applyGrowth(10);
result.applyRecession(5);

console.log(result);
