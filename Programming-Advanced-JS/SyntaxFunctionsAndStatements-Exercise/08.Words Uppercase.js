function solve(text) {
   
    let formattedWords = [];
    let words = text.split(/\W+/g);

    for (const word of words) {
        
        if (word !== '') {
            formattedWords.push(word.toUpperCase());
        }
    }
    return formattedWords.join(', ');
}

console.log(solve('Hi, how are you?'));
console.log(solve('Hello'));