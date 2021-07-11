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

    Object.values(rawDate)
        .forEach(el => {
            let li = document.createElement('li');
            li.textContent = `<${el.person}>:<${el.phone}>`

            let delBtn = document.createElement('button');
            delBtn.textContent = 'Delete';
            delBtn.addEventListener('click', delSection);

            li.appendChild(delBtn);
            ulElement.appendChild(li);
        });
}

function delSection(e) {

    let element = e.target.parentElement;
    element.remove();
}


attachEvents();
