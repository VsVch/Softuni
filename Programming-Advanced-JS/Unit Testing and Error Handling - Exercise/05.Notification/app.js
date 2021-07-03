function notify(message) {

  let divElement = document.querySelector('#notification');
  
  divElement.textContent = message;

  divElement.style.display = 'block'

  divElement.addEventListener('click', exposeText);

  function exposeText() {

    let divElement = document.querySelector('#notification');
    divElement.style.display = 'none'; 
    
  }
}