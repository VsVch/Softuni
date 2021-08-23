function lockedProfile() {
    let profils = document.querySelectorAll('#main .profile');
    let buttons = document.querySelectorAll('#main .profile button')

    for (let i = 0; i < buttons.length; i++) {

        buttons[i].addEventListener('click', () => {

            let radioButtonName = `user${i+1}Locked`;

            let radioButton = document.querySelector(`input[name="user${i + 1}Locked"]:checked`);

            if (radioButton.value === 'unlock') {

                let hidenFildElement = document.getElementById(`user${i + 1}HiddenFields`);

                hidenFildElement.style.display = hidenFildElement.style.display === 'block' ? 'none' : 'block';

                buttons[i].textContent = buttons[i].textContent === 'Show more' ? 'Hide it' : 'Show more';
            }

        })

    }
}

