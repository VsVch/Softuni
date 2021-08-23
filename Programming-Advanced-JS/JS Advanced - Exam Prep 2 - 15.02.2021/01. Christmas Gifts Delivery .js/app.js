function solution() {
    let [add, list, send, discard] = document.querySelectorAll('.card');

    let listUl = list.querySelector('ul');
    let sendUl = send.querySelector('ul');
    let discardUl = discard.querySelector('ul');

    let textElement = add.querySelector('div input');
    let addButtonElement = add.querySelector('div button');


    addButtonElement.addEventListener('click', addGift);
    function addGift() {

        let textContent = textElement.value;
        textElement.value = '';

        let liElement = createTag('li', textContent, 'gift');

        let sendButton = createTag('button', 'Send');
        sendButton.setAttribute('id', 'sendButton');
        let discardButton = createTag('button', 'Discard');
        discardButton.setAttribute('id', 'discardButton');

        liElement.appendChild(sendButton);
        liElement.appendChild(discardButton);        

        listUl.appendChild(liElement); 
            
        Array.from(listUl.children)
        .sort((a,b) => a.textContent.localeCompare(b.textContent))
        .forEach(g =>listUl.appendChild(g));

        sendButton.addEventListener('click', () => sendGift(textContent, liElement));
        discardButton.addEventListener('click', () => discardGift(textContent, liElement));


        function sendGift(textContent, liElement) {

            liElement.remove();
            let liSendElement = createTag('li', textContent);

            sendUl.appendChild(liSendElement);
        }

        function discardGift(textContent, liElement) {
            liElement.remove();
            let liDiscardElement = createTag('li', textContent);
            discardUl.appendChild(liDiscardElement);
        }
    }

    function createTag(type, content, className) {
        let element = document.createElement(type);
        if (content !== undefined) {
            element.textContent = content;
        }

        if (className !== undefined) {
            element.className = className;
        }
        return element;
    }
}