async function lockedProfile() {

    let divProfil = document.getElementById('container');

    let defautProfile = document.querySelector('.profile');
    defautProfile.remove();

    let url = `http://localhost:3030/jsonstore/advanced/profiles`;

    let responce = await fetch(url);
    let date = await responce.json();

    Object.keys(date).forEach((el, i) => {

        let userName = date[el].username;
        let userNameAge = date[el].age;
        let userNameEmail = date[el].email;

        let main = createTags('main');

        let mainDiv = createTags('div', undefined, 'profile');

        let img = createTags('img', undefined, 'userIcon');
        img.src = './iconProfile2.png';

        let labelLock = createTags('label', 'Lock');

        let lockInput = createTags('input');
        lockInput.type = 'radio';
        lockInput.name = `user${i + 1}Locked`;
        lockInput.value = `lock`;
        lockInput.checked = true;

        let labelUnlock = createTags('label', 'Unlock');

        let unlockInput = createTags('input');
        unlockInput.type = 'radio';
        unlockInput.name = `user${i + 1}Locked`;
        unlockInput.value = `unlock`;

        let br = createTags('br');
        let hr1 = createTags('hr');

        let labelUsername = createTags('lable', 'Username');

        let usernameInput = createTags('input');
        usernameInput.type = 'text';
        usernameInput.name = `user${i + 1}Locked`;
        usernameInput.value = userName;
        usernameInput.readOnly = true;
        usernameInput.disabled = true;

        let hiddenDiv = createTags('div');
        hiddenDiv.id = `user${i + 1}HiddenFields`;

        let hr2 = createTags('hr');

        let labelEmail = createTags('lable', 'Email:');

        let inputEmail = createTags('input');
        inputEmail.type = 'email';
        inputEmail.name = `user${i + 1}Email`;
        inputEmail.value = userNameEmail;
        inputEmail.readOnly = true;
        inputEmail.disabled = true;

        let labelAge = createTags('lable', 'Age');

        let inputAge = createTags('input');
        inputAge.type = 'email';
        inputAge.name = `user${i + 1}Age`;
        inputAge.value = userNameAge;
        inputAge.readOnly = true;
        inputAge.disabled = true;

        let button = createTags('button', 'Show more');

        button.addEventListener('click', reviewOptions)

        hiddenDiv.appendChild(hr2);
        hiddenDiv.appendChild(labelEmail);
        hiddenDiv.appendChild(inputEmail);
        hiddenDiv.appendChild(labelAge);
        hiddenDiv.appendChild(inputAge);

        mainDiv.appendChild(img);
        mainDiv.appendChild(labelLock);
        mainDiv.appendChild(lockInput);
        mainDiv.appendChild(labelUnlock);
        mainDiv.appendChild(unlockInput);
        mainDiv.appendChild(br);
        mainDiv.appendChild(hr1);
        mainDiv.appendChild(labelUsername);
        mainDiv.appendChild(usernameInput);
        mainDiv.appendChild(hiddenDiv);
        mainDiv.appendChild(button);

        main.appendChild(mainDiv);
        divProfil.appendChild(main);

    });
}

function reviewOptions(e) {

    let currProfile = e.target.parentElement;
    let hiddenFildDev = e.target.previousElementSibling;
    let button = e.target;
    let radioButton = currProfile.querySelector('input[type="radio"]:checked')

    if (radioButton.value !== 'unlock') {
        return;
    }

    button.textContent = button.textContent === 'Show more' ? 'Hide it' : 'Show more';

    hiddenFildDev.style.display = hiddenFildDev.style.display === 'block' ? 'none' : 'block';

}


function createTags(type, content, nameOfClass) {

    let element = document.createElement(type);

    if (content !== undefined) {
        element.textContent = content;
    }

    if (nameOfClass !== undefined) {
        element.className = nameOfClass;
    }

    return element;

}