const { assert } = require('chai');
const dealership = require('../03. Dealership');

describe("Tests dealership", function () {

    describe("newCarCost", () => {

        it("Should return price whit discount when old card is return ", function () {

            assert.strictEqual(dealership.newCarCost('Audi A4 B8', 30000), 15000);
        });

        it("Should return price whitout discount", function () {

            assert.strictEqual(dealership.newCarCost('Audi A4 100', 30000), 30000);
        });
    });

    describe("carEquipment", () => {

        it("Should return right amount of extras articules", function () {

            assert.deepEqual(dealership.carEquipment(['a', 'b', 'c', 'd', 'e'], [0, 3, 4]), ['a', 'd', 'e']);
            //assert.deepEqual(dealership.carEquipment(['a', 'b', 'c', 'd', 'e'], [0, 3, 5]), ['a', 'd',]);
        });

        // it("Should return price whitout discount", function() {

        //     assert.strictEqual(dealership.newCarCost('Audi A4 100', 30000), 30000);
        // });
    });

    describe("euroCategory", () => {

        it("Should return discount messege when evro category is under 4", function () {
            
            let totalPrice = 14250;

            assert.strictEqual(dealership.euroCategory(4), `We have added 5% discount to the final price: ${totalPrice}.`);
            assert.strictEqual(dealership.euroCategory(5), `We have added 5% discount to the final price: ${totalPrice}.`);

        });

        it("Should return messege whitout discount", function() {

            assert.strictEqual(dealership.euroCategory(3), 'Your euro category is low, so there is no discount from the final price!');
            assert.strictEqual(dealership.euroCategory(2), 'Your euro category is low, so there is no discount from the final price!');
        });
    });
});
