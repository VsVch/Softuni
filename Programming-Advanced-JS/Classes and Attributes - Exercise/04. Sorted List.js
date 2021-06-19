class List {

    constructor() {

        this.result = [];
        this.size = this.result.length;
    }

    add(element) {

        if (isNaN(element)) {
            throw new error('Element is not a number');
        }

        this.result.push(Number(element));
        this.result.sort((a, b) => a - b);
        this.size++;

        return this;
    };

    remove(index) {

        if (index < 0 || index >= this.size) {
            throw new error('Index is out of range');
        }
        this.result.splice(index, 1);
        this.result.sort((a, b) => a - b);
        this.size--;
    }

    get(index) {

        if (index < 0 || index >= this.size) {
            throw new error('Index is out of range');
        }

        return this.result[index];
    }
}

let list = new List();
list.add(5);
list.add(6);
list.add(7);
console.log(list.get(1));
list.remove(1);
console.log(list.get(1));

