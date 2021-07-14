function attachEvents() {
    let loadBtn = document.getElementById('btnLoad').addEventListener('click', loadPhoneBook);
    let createBtn = document.getElementById('btnCreate').addEventListener('click', createPhoneBook);
}

async function createPhoneBook(e) {
    e.preventDefault();

    let createUrl = `http://localhost:3030/jsonstore/phonebook`

    let personFild = document.getElementById('person');
    let personName = personFild.value;
    personFild.value = '';

    let phoneFild = document.getElementById('phone');
    let phoneNumber = phoneFild.value;
    phoneFild.value = '';

    let date = {
        person: personName,
        phone: phoneNumber,
    }

    let createResponce = await fetch(createUrl, {
        method: 'POST',
        headers: { 'Content-Type': 'applicatin/json' },
        body: JSON.stringify(date),
    });
    let rawDate = await createResponce.json();
}

async function loadPhoneBook(e) {
    e.preventDefault();

    let ulElement = document.getElementById('phonebook');

    let loadURL = `http://localhost:3030/jsonstore/phonebook`;

    let ulChildren = Array.from(ulElement.querySelectorAll('li'));
    ulChildren.forEach(el => el.remove());

    let loadResponce = await fetch(loadURL);
    let rawDate = await loadResponce.json();

    console.log(rawDate)

    Object.values(rawDate)
        .forEach(el => {
            let li = document.createElement('li');
            li.textContent = `<${el.person}>:<${el.phone}>`

            let delBtn = document.createElement('button');
            delBtn.textContent = 'Delete';
            delBtn.addEventListener('click', delSection);
            delBtn.setAttribute('id', el._id)

            li.appendChild(delBtn);
            ulElement.appendChild(li);
        });
}

async function delSection(e) {
    id = e.target.id;
    let element = e.target.parentElement;

    let delResponce = await fetch(`http://localhost:3030/jsonstore/phonebook/` + id, {
        method: 'DELETE',
        'X-Authorization': localStorage.getItem(id)
    });
    element.remove();
}


attachEvents();
