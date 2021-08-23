import {showDetails} from './details.js'

let main;
let section;

async function onSubmit(e) {
    e.preventDefault();
    const formDate = new FormData(e.target);
    const movie = {
        title: formDate.get('title'),
        description: formDate.get('description'),
        img: formDate.get('imageUrl'),
    }

    if (movie.tite == '' || movie.description == '' || movie.img == '') {
        return alert('Are filds are required!')
    }

    const responce = await fetch(`http://localhost:3030/data/movies`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'X-Authorization': sessionStorage.getItem('authToken')
        },
        body: JSON.stringify(movie)
    });

    if (responce.ok) {
        const movie = await responce.json();
        showDetails(movie._id);
    }else{
        const error =await responce.json();
        alert(error.messege);
    }
}

export function setupCreate(mainTarget, sectionTarget) {
    main = mainTarget;
    section = sectionTarget;

    const form = section.querySelector('form');
    form.addEventListener('submit', onSubmit)
}

export async function showCreate() {
    main.innerHTML = '';
    main.appendChild(section);
}