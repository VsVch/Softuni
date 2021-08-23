import { showHome } from './home.js'

let main;
let section;

async function onSubmit(e) {
    e.preventDefault();

    const formDate = new FormData(e.target);
    const email = formDate.get('email');
    const password = formDate.get('password');
    const rePassword = formDate.get('repeatPassword');

    if (email =='' || password == '') {
        return alert('All fild are required!');
    }else if(password !== rePassword){
        return alert('Password dont match!');
    }

    let responce = await fetch(`http://localhost:3030/users/register`, {
        method: 'post',
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


export function setupRegister(mainTarget, sectionTarget) {
    main = mainTarget;
    section = sectionTarget;

    const form = section.querySelector('form');
    form.addEventListener('submit', onSubmit);
}

export async function showRegister() {
    main.innerHTML = '';
    main.appendChild(section);
}