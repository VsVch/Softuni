
let main;
let section;

let editTitleElement = document.getElementById('edit-title');
let editDescriptionElement = document.getElementById('edit-description');
let editImgElement = document.getElementById('edit-img');

export function setupEdit(mainTarget, sectionTarget) {
    main = mainTarget;
    section = sectionTarget;
}

export async function showEdit() {
    main.innerHTML = '';
    main.appendChild(section);
}

export async function onEdit(e, id) {

    showEdit();

    const responce = await fetch('http://localhost:3030/data/movies/' + id);

    if (!responce.ok) {
        const error = await responce.json();
        alert(error.messege);
        return;
    }
    let date = await responce.json();
    console.log(date);
    editTitleElement.value = date.title;
    editDescriptionElement.textContent = date.description;
    editImgElement.value = date.img;

    document.getElementById('submit-edit').addEventListener('click', () => submitedit(e, id))

}

async function submitedit(e, id) {
    e.preventDefault();
    console.log(id)

    let editMovie = {
        title: editTitleElement.value,
        description: editDescriptionElement.textContent,
        img: editImgElement.value,
    }

    console.log(editMovie.title);
    console.log(editMovie.description);
    console.log(editMovie.img);

    const responce = await fetch('http://localhost:3030/data/movies/' + id, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
            'X-Authorization': sessionStorage.getItem('authToken')
        },

        body: JSON.stringify(editMovie)
    });

    if (responce.ok) {
        let date = await responce.json();
        console.log(date);
    } else {
        const error = await responce.json();
        alert(error.messege);
    }

}