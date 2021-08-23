function solve(charCard, charType) {

    try {
        let cardIndex = {
            '2': '2',
            '3': '3',
            '4': '4',
            '5': '5',
            '6': '6',
            '7': '7',
            '8': '8',
            '9': '9',
            '10': '10',
            'J': 'J',
            'Q': 'Q',
            'K': 'K',
            'A': 'A',
        }

        let cartType = {
            'S': '\u2660',
            'H': '\u2665',
            'D': '\u2666',
            'C': '\u2663',
        }

        let cart = cardIndex[charCard] + cartType[charType];

        if (cardIndex[charCard] === undefined || cartType[charType] === undefined) {
            throw new Error('Error');
        } else {
            return cart;
        }

    } catch (error) {
        console.log(error);
    }
}

//console.log(solve('A', 'S'))
//console.log(solve('1', 'C'))