function solve() {
    let textAreaElement = document.getElementById('input');

    let text = textAreaElement.value;

    let sentences = text.split('.').filter(x => x !== '').map(x => x + '.');

    let paragraphsRoof = Math.ceil(sentences.length / 3);

    let resuliDiv = document.getElementById('output');

    for (let i = 0; i < paragraphsRoof; i++) {
     resuliDiv.innerHTML += `<p>${sentences.splice(0,3).join('')}</p>`
      
    }    
}

