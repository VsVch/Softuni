function solve(input) {
    let dictionary = {};

    while (input.length) {
        let [name, price] = input.shift().split(' : ');
        const firstLetter = name[0];

        if (!dictionary[firstLetter]) {
            dictionary[firstLetter] = [];
        }

        dictionary[firstLetter].push({ name, price: Number(price) });    

    }

    let result = [];

    Object.entries(dictionary).sort((a, b) => a[0].localeCompare(b[0]))
        .forEach(entry => {
            let value = entry[1]
                .sort((a, b) => (a.name).localeCompare(b.name))
                .map(p => `  ${p.name}: ${p.price}`)
                .join('\n');

            let string = `${entry[0]}\n${value}`;
            result.push(string);
        })

    return result.join('\n');    
}

console.log(solve(
    ['Appricot : 20.4',
        'Fridge : 1500',
        'TV : 1499',
        'Deodorant : 10',
        'Boiler : 300',
        'Apple : 1.25',
        'Anti-Bug Spray : 15',
        'T-Shirt : 10']
))
