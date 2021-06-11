function encodeAndDecodeMessages() {
    let textAreaElements = Array.from(document.querySelectorAll('#main textarea'));

    let buttonElements = Array.from(document.querySelectorAll('#main button'));

    buttonElements[0].addEventListener('click', codeInformation);

    function codeInformation() {
        let textToArray = Array.from(textAreaElements[0].value);

        let textToCode = textToArray.map(el => {
            let num = el.charCodeAt(0) + 1;
            let word = String.fromCharCode(num);
            return word;
        }).join('');

        textAreaElements[1].textContent = textToCode;
        textAreaElements[0].value = '';
    }

    buttonElements[1].addEventListener('click', decodeInformation);

    function decodeInformation() {
        let textToArray = Array.from(textAreaElements[1].textContent);

        let textToDecode = textToArray.map(el => {
            let num = el.charCodeAt(0) - 1;
            let word = String.fromCharCode(num);
            return word;
        }).join('');
        textAreaElements[1].textContent = '';
        textAreaElements[1].textContent = textToDecode;
    }
}