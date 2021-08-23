function focused() {
    let divElements = document.querySelectorAll('div input');

    for (const divElement of divElements) {

        divElement.addEventListener('focus', (e)=>{
            e.target.parentNode.className = 'focused';            
        })

        divElement.addEventListener('blur', (e)=>{
            e.target.parentNode.className = '';            
        })
        
        
    }
}