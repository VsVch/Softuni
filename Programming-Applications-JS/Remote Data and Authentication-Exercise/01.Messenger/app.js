function attachEvents() {
    let sendButton = document.getElementById('submit').addEventListener('click', sendMessage);
    let refrechButton = document.getElementById('refresh').addEventListener('click', refrechMessege)
}

async function sendMessage(e) {
    e.preventDefault();
    let sendURL = 'http://localhost:3030/jsonstore/messenger';

    let nameFild = document.getElementById('author');
    let contentFild = document.getElementById('content');

    let author = nameFild.value;
    let content = contentFild.value;

    nameFild.value = '';
    contentFild.value = '';

    let rawDate = {
        author: author,
        content: content
    };

    let responce = await fetch(sendURL, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(rawDate),
    });
    let date = await responce.json();
}

async function refrechMessege(e) {
    e.preventDefault();
    let sendURL = 'http://localhost:3030/jsonstore/messenger';

    let textArea = document.getElementById('messages');

    let result = [];

    let responce = await fetch(sendURL);
    let date = await responce.json();

    Object.values(date)            
        .forEach(el => {         
            result.push(`${el.author}: ${el.content}`)
        });

     textArea.textContent = result.join('\n') ;
}

attachEvents();