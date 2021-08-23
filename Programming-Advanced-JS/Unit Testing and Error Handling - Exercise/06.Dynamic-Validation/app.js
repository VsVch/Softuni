function validate() {
    let validateElement = document.getElementById('email');
    let regEx = /^[a-z]+@[a-z]+\.[a-z]+$/;

    validateElement.addEventListener('change', validateEmail)
    function validateEmail(){
        let inputFild = validateElement.value;

        if (regEx.test(inputFild)) {
            validateElement.classList.remove('error')
        } else {
            validateElement.classList.add('error')
        }
    }
}