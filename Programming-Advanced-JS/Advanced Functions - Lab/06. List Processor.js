function solve(array) {

    let result = [];

    for (let i = 0; i < array.length; i++) {

        let commands = array[i].split(' ');
        let command = commands[0];
        let value = commands[1];1
       
        let add = function (value) {
            result.push(value);
        }

        let remove = function (value) {
           result = result.filter(x => x !== value);        

        }

        let print = function () {
            console.log(result.join(','));
        }

        if (command === 'add') {
            add(value);
        } else if (command === 'remove') {
            remove(value);
        } else if (command === 'print' && value === undefined) {
            print(result);
        }

    }
}
console.log(solve(['add hello', 'add again', 'remove hello', 'add again', 'print']));