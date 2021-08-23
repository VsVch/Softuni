
const { assert } = require('chai');
const pizzUni = require('../03. Pizza Place');

describe("Tests pizzUni", () => {

    describe("makeAnOrder", () => {

        it("Should return correct answer", () => {

            let obj = { orderedPizza: 'calcone' }
            assert.strictEqual(pizzUni.makeAnOrder(obj), `You just ordered calcone`)
        });

        it("Should return correct answer when ordered pizza and drink", () => {

            let obj = {
                orderedPizza: 'calcone',
                orderedDrink: 'beer'
            }
            assert.strictEqual(pizzUni.makeAnOrder(obj), `You just ordered ${obj.orderedPizza} and ${obj.orderedDrink}.`)
        });

        it("Should throw error when ordered whitout pizza", () => {

            let obj = {
                orderedPizza: undefined,
                orderedDrink: 'beer'
            }
            assert.throw(() => pizzUni.makeAnOrder(obj), Error)
            
        });

        it("Should throw error when object is empty", () => {

            let obj = {
               
            }
            assert.throw(() => pizzUni.makeAnOrder(obj), Error)
            
        });

    });

    describe("getRemainingWork", () => {

        it("Should return correct answer", () => {

            let add = [{ status: 'ready' }]
            assert.strictEqual(pizzUni.getRemainingWork(add), 'All orders are complete!')
        });  
        
        it("Should return correct message when some pizzes is not ready", () => {

            let add = [{pizzaName: 'capri', status: 'ready' }, {pizzaName: 'italy', status: 'notready' }, {pizzaName: 'roma', status: 'notready' }]
            assert.strictEqual(pizzUni.getRemainingWork(add), `The following pizzas are still preparing: italy, roma.`);
        });        


    });

    describe("orderType", () => {

        it("Should return total sum when all are delivery on time", () => {            
            assert.strictEqual(pizzUni.orderType(10,'Delivery'), 10)
        });  
        
        it("Should return total sum when all are delivery on time", () => {            
            assert.strictEqual(pizzUni.orderType(10,'Carry Out'), (10 * 0.9))
        });
    });
});
