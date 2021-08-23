// Selecting DOM elements
let elem1 = document.getElementById('test');
document.querySelector('#test');
document.querySelectorAll('#test li');

// Get/Set content
elem1.value;
elem1.textContent;

// Traversing DOM
elem1.parentElement;
elem1.children;

// Create element
let createdElem = document.createElement('p');

// Adding to DOM
elem1.appendChild(createdElem);

// Delete from DOM
createdElem.remove();

// Events
elem1.addEventListener('click', someFunc);
e.target

// maybe
e.preventDefault(); //Buttons in Forms send the form when clicked, reloading the page
elem1.removeEventListener('click', someFunc);



function someFunc() { console.log(1)}