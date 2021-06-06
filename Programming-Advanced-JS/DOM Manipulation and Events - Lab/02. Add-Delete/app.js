function addItem() {
    let itemsElement = document.getElementById('items');
    let textElement = document.getElementById('newItemText');

    let newLiItem = document.createElement('li');
    newLiItem.textContent = textElement.value;

    let deleteElement = document.createElement('a');
    deleteElement.textContent = '[Delete]';
    deleteElement.setAttribute('href','#')

    deleteElement.addEventListener('click', removeElement);
    function removeElement() {
        newLiItem.remove();
    }

    newLiItem.appendChild(deleteElement);
    itemsElement.appendChild(newLiItem);
    
    textElement.value = '';
    
}