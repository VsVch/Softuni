import { showHome } from './home.js'

let main;
let section;

async function onSubmit(e) {
    e.preventDefault();

    const formDate = new FormData(e.target);
    const email = formDate.get('email');
    const password = formDate.get('password');

    let responce = await fetch(`http://localhost:3030/users/login`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            email,
            password,
        })
    });

    if (responce.ok) {

        e.target.reset();
        let date = await responce.json();
        sessionStorage.setItem('authToken', date.accessToken);
        sessionStorage.setItem('userId', date._id);
        sessionStorage.setItem('email', date.email);
        
        document.getElementById('welcome-msg').textContent = `Welcome, ${email}`;

        [...document.querySelectorAll('nav .user')].forEach(l => l.style.display = 'block');
        [...document.querySelectorAll('nav .guest')].forEach(l => l.style.display = 'none');

        showHome();
    }else{
        const error = await responce.json();
        alert(error.message);
    }

}

export async function setupLogin(mainTarget, sectionTarget) {
    main = mainTarget;
    section = sectionTarget;

    const form = section.querySelector('form');
    form.addEventListener('submit', onSubmit);
}

export async function showLogin() {
    main.innerHTML = '';
    main.appendChild(section);
}