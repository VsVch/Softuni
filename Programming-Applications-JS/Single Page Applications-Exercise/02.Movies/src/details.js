import { e } from './dom.js';
import { showHome } from './home.js';


async function getLikseByMovieId(id) {

    let responce = await fetch(`http://localhost:3030/data/likes?where=movieId%3D%22${id}%22&amp;distinct=_ownerId&amp;count`);
    let date = await responce.json();

    return date.length;
}

async function getOwnLikesByMovieId(id) {

    const userId = sessionStorage.getItem('userId');
    let responce = await fetch(`http://localhost:3030/data/likes?where=movieId%3D%22${id}%22%20and%20_ownerId%3D%22${userId}%22`);
    let date = await responce.json();

    return date;
}

async function getMovieById(id) {
    const responce = await fetch('http://localhost:3030/data/movies/' + id);
    const date = await responce.json();

    return date;
}

async function onDelete(e, id) {
    e.preventDefault();

    const confurmed = confirm('Are you sure you want to delete this movie');

    if (confurmed) {

        const responce = await fetch('http://localhost:3030/data/movies/' + id, {
            method: 'DELETE',
            headers: { 'X-Authorization': sessionStorage.getItem('authToken') }
        });

        if (responce.ok) {
            alert('Movie deleted');              
            showHome();
        } else {
            const error = await responce.json();
            alert(error.messege);
        }        
    }
}

async function onEdit(e, id){
        
    console.log(e.target);

    const responce = await fetch('http://localhost:3030/data/movies/' + id, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
            'X-Authorization': sessionStorage.getItem('authToken')
        },
        body: JSON.stringify(movie)
    });
}



function createMovieCard(movie, likes, ownlike) {

    const controls = e('div', { className: 'col-md-4 text-center' },
        e('h3', { className: 'my-3' }, 'Movie Description'),
        e('p', {}, movie.description),
    );  
    
    const userId = sessionStorage.getItem('userId');

    if (userId != null) {
        if (userId == movie._ownerId) {
            controls.appendChild(e('a', { className: 'btn btn-danger', href: '#', onClick: (e) => onDelete(e, movie._id) }, 'Delete'));
            controls.appendChild(e('a', { className: 'btn btn-warning', href: '#', onClick: (e) => onEdit(e, movie._id) }, 'Edit'));

        } else if (ownlike.length == 0) {

            controls.appendChild(e('a', { className: 'btn btn-primary', href: '#', onclick: likeMovie }, 'Like 1'));
        }
    }

    let likesSpan = e('span', { className: 'enrolled-span' }, likes + ' like' + (likes == 1 ? '' : 's'))
    controls.appendChild(likesSpan);

    const element = document.createElement('div');
    element.className = 'container';
    element.appendChild(e('div', { className: 'row bg-light text-dark' },
        e('h1', {}, `Movie title: ${movie.title}`),
        e('div', { className: 'col-md-8' }, e('img', { className: 'img-thumbnail', src: movie.img })),
        controls
    ));

    return element;

    async function likeMovie(e) {
        const responce = await fetch(`http://localhost:3030/data/likes`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'X-Authorization': sessionStorage.getItem('authToken')
            },
            body: JSON.stringify({ movieId: movie._id })
        })
        if (responce.ok) {
            e.target.remove();

            likes++;
            likesSpan.textContent = likes + ' like' + (likes == 1 ? '' : 's');
        }
    }
}

let main;
let section;

export function setupDetails(mainTarget, sectionTarget) {
    main = mainTarget;
    section = sectionTarget;
}

export async function showDetails(id) {

    section.innerHTML = '';
    main.innerHTML = '';
    main.appendChild(section);

    const [movie, likes, ownlike] = await Promise.all([

        getMovieById(id),
        getLikseByMovieId(id),
        getOwnLikesByMovieId(id),
    ]);

    let card = createMovieCard(movie, likes, ownlike);
    section.appendChild(card);

}