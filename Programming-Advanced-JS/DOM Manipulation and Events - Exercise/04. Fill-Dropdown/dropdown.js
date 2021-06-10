function addItem() {

    let parentElement = document.getElementById('menu');
    
    let textElemen = document.getElementById('newItemText');    

    let valueElement = document.getElementById('newItemValue');

    let optionElement = document.createElement('option');

    optionElement.textContent = textElemen.value;

    optionElement.value = valueElement.value;

    parentElement.appendChild(optionElement);

    textElemen.value = '';

    valueElement.value = '';

}