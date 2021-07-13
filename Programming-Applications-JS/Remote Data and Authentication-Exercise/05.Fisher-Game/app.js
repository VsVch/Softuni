// entry poin
let homeBtn = document.getElementById('home');
homeBtn.addEventListener('click', homeButton);
let divGuestElement = document.getElementById('guest');

// section reviwe in to displays one by one
// register section
let registerBtn = document.getElementById('register').addEventListener('click', reviweRegister);
// login section
let loginBtn = document.getElementById('login').addEventListener('click', logOptions);

let viewsSectionElement = document.getElementById('views');
let loginSectionElement = document.getElementById('login-view');
let registerSectionElement = document.getElementById('register-view');

// section register users
let registerForm = document.getElementById('register-view');
registerForm.addEventListener('submit', register);

// section login users
let loginForm = document.getElementById('login-view');
loginForm.addEventListener('submit', login)

//section home viwe
let homeViweSectionElement = document.getElementById('home-view');

//section load all catches
let loadCatchesBtn = document.getElementById('load-catch');
loadCatchesBtn.addEventListener('click', getCatches);

//add catches section
let catchesContainer = document.getElementById('catches');

//create new catch
let addBtn = document.querySelector('#addForm .add');
addBtn.disabled = localStorage.getItem('token') === null;
addBtn.addEventListener('click', createCatch);

//Header entry functions 
function homeButton(e) {
    divGuestElement.style.display = 'block';
    e.target.style.display = 'none';
}

function reviweRegister() {
    viewsSectionElement.style.display = 'block';
    loginSectionElement.style.display = 'none';
    registerSectionElement.style.display = 'block';
}

function logOptions(e) {

    if (e.target.textContent === 'Login') {
        viewsSectionElement.style.display = 'block';
        registerSectionElement.style.display = 'none';
        loginSectionElement.style.display = 'block';
    }else{  
        divGuestElement.style.display = 'none';
        viewsSectionElement.style.display = 'none';
        localStorage.clear();      
        homeBtn.style.display = 'block';  
      
    }
}

async function register(e) {
    e.preventDefault();

    let regesterUrl = `http://localhost:3030/users/register`;
    let form = new FormData(e.target);

    let userPassword = form.get('password');
    let userRePassword = form.get('rePass');

    if (userPassword !== userRePassword) {
        console.error('Wrong password !')
        return;
    }

    let newUser = {
        email: form.get('email'),
        password: userPassword,
    }

    let registerResponce = await fetch(regesterUrl, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(newUser)
    });

    let rawDate = await registerResponce.json();

    localStorage.setItem('token', rawDate.accessToken);
    localStorage.setItem('userId', rawDate._id);

    registerSectionElement.style.display = 'none';
    loginSectionElement.style.display = 'block';

}

async function login(e) {
    e.preventDefault();

    let loginBtn = document.getElementById('login');     
    loginBtn.textContent = 'Logout';  
    

    let loginUrl = `http://localhost:3030/users/login`;
    let form = new FormData(e.target);

    let loginUser = {
        email: form.get('email'),
        password: form.get('password'),
    }

    try {
        let loginResponce = await fetch(loginUrl, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(loginUser)
        });

        let rawDate = await loginResponce.json();

        localStorage.setItem('token', rawDate.accessToken);
        localStorage.setItem('userId', rawDate._id);

    } catch (error) {
        console.error('Wrong email or password !')
    }
    loginSectionElement.style.display = 'none';
    homeViweSectionElement.style.display = 'block';

    

}

//End entry functions

//CRUD functions
async function getCatches() {

    let feildSetElement = document.querySelector('#main');

    catchesContainer.querySelectorAll('div').forEach(el => el.remove());

    let loadCachesUrl = `http://localhost:3030/data/catches`;

    let allCatchesresponce = await fetch(loadCachesUrl);
    let catchesDate = await allCatchesresponce.json();

    catchesDate.forEach(el => {

        let element = createHtmlCatch(el);

        catchesContainer.appendChild(element);

    });
    feildSetElement.style.display = 'block';

}

async function createCatch(e) {
    e.preventDefault();

    let catchUrl = `http://localhost:3030/data/catches`;

    let angler = document.querySelector('#addForm .angler').value;
    let weight = document.querySelector('#addForm .weight').value;
    let species = document.querySelector('#addForm .species').value;
    let location = document.querySelector('#addForm .location').value;
    let bait = document.querySelector('#addForm .bait').value;
    let captureTime = document.querySelector('#addForm .captureTime').value;

    let newFish = {
        angler: angler,
        weight: Number(weight),
        species: species,
        location: location,
        bait: bait,
        captureTime: Number(captureTime),
    }

    let catchResponse = await fetch(catchUrl, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', 'X-Authorization': localStorage.getItem('token') },
        body: JSON.stringify(newFish),
    })
    let rawDate = await catchResponse.json();

    let createdCatch = createHtmlCatch(rawDate);
    catchesContainer.appendChild(createdCatch);
}

async function upDateCatch(e) {
    let currCatch = e.target.parentElement;

    let id = currCatch.dataset.id;
    let url = `http://localhost:3030/data/catches/${id}`;


    let angler = currCatch.querySelector('.angler').value;
    let weight = currCatch.querySelector('.weight').value;
    let species = currCatch.querySelector('.species').value;
    let location = currCatch.querySelector('.location').value;
    let bait = currCatch.querySelector('.bait').value;
    let captureTime = currCatch.querySelector('.captureTime').value;

    let updateFish = {
        angler: angler,
        weight: Number(weight),
        species: species,
        location: location,
        bait: bait,
        captureTime: Number(captureTime),
    }

    let updateResponce = await fetch(url, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
            'X-Authorization': localStorage.getItem('token')
        },
        body: JSON.stringify(updateFish)
    })

    let rawDate = await updateResponce.json();
}

async function deleteCatch(e) {
    let currCatch = e.target.parentElement;
    let id = currCatch.dataset.id;
    let url = `http://localhost:3030/data/catches/${id}`;

    let deleteResponce = await fetch(url, {
        method: 'DELETE',
        headers: {
            'X-Authorization': localStorage.getItem('token'),
        },
    })
    let rawDate = await deleteResponce.json();
    console.log(rawDate);

    if (deleteResponce.status === 200) {
        currCatch.remove();
    }
}
//End CRUD functions

//Help functions
function createHtmlCatch(currCatch) {

    let anglerLabe = createTags('label', undefined, 'Angler');
    let anglerInput = createTags('label', { type: 'text', class: 'angler' }, currCatch.angler);
    let hr1 = createTags('hr');
    let weightLabel = createTags('label', undefined, 'Weight');
    let weightInput = createTags('input', { type: 'number', class: 'weight' }, currCatch.weight);
    let hr2 = createTags('hr');
    let speciesLabel = createTags('label', undefined, 'Species');
    let speciesInput = createTags('input', { type: 'text', class: 'species' }, currCatch.species);
    let hr3 = createTags('hr');
    let locationLabel = createTags('label', undefined, 'Location');
    let locationInput = createTags('input', { type: 'text', class: 'location' }, currCatch.location);
    let hr4 = createTags('hr');
    let baitLabel = createTags('label', undefined, 'Bait');
    let baitInput = createTags('input', { type: 'text', class: 'bait' }, currCatch.bait);
    let hr5 = createTags('hr');
    let captureTimeLabel = createTags('label', undefined, 'Capture Time');
    let captureInput = createTags('input', { type: 'number', class: 'captureTime' }, currCatch.captureTime);
    let hr6 = createTags('hr');
    let updateBtn = createTags('button', { disabled: true, class: 'update' }, 'Update');
    updateBtn.addEventListener('click', upDateCatch);
    updateBtn.disabled = localStorage.getItem('userId') !== currCatch._ownerId;
    let deletBtn = createTags('button', { disabled: true, class: 'delete' }, 'Delete');
    deletBtn.addEventListener('click', deleteCatch);
    deletBtn.disabled = localStorage.getItem('userId') !== currCatch._ownerId;

    let catchDiv = createTags('div', { class: 'catch' },
        anglerLabe, anglerInput, hr1, weightLabel, weightInput, hr2, speciesLabel, speciesInput, hr3, locationLabel, locationInput, hr4,
        baitLabel, baitInput, hr5, captureTimeLabel, captureInput, hr6, updateBtn, deletBtn);
    catchDiv.dataset.id = currCatch._id;
    catchDiv.dataset.ownerId = currCatch._ownerId;
    return catchDiv;
}

function createTags(tag, attributes, ...params) {

    let element = document.createElement(tag);
    let firstValue = params[0];

    if (params.length === 1 && typeof (firstValue) !== 'object') {

        if (['input', 'textarea'].includes(tag)) {
            element.value = firstValue;
        } else {
            element.textContent = firstValue;
        }
    } else {
        element.append(...params);
    }

    if (attributes !== undefined) {
        Object.keys(attributes).forEach(key => {
            element.setAttribute(key, attributes[key]);
        })
    }

    return element;

}
//End help functions


