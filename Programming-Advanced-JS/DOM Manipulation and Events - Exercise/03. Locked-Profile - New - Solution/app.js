
function lockedProfile() {
    //let profils = document.querySelectorAll('#main .profile');
    let buttons = Array.from(document.querySelectorAll('#main .profile button'));

    buttons.forEach(e => {
        e.addEventListener('click', toggleButton)
    });

    function toggleButton(e) {
        let button = e.target;
        let profile = button.parentelement;
        let radioButton = profile.querySelector(`input:checked`);

        if (radioButton.value === 'unlock') {

            //let hidenFildElement = profil.querySelector('div');
            let hidenFildElement = button.previousElementSibling;

            hidenFildElement.style.display = hidenFildElement.style.display === 'block' ? 'none' : 'block';

            button.textContent = button.textContent === 'Show more' ? 'Hide it' : 'Show more';
        }
    }
}