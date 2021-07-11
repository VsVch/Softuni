let formBtn = document.getElementById('submit').addEventListener('click', createStudent);
let url = 'http://localhost:3030/jsonstore/collections/students';

async function createStudent(e) {
    e.preventDefault();

    let firstNameFild = document.getElementById('firstName');
    let firstName = firstNameFild.value;
    firstNameFild.value = '';

    let lastNameFild = document.getElementById('lastName');
    let lastName = lastNameFild.value;
    lastNameFild.value = '';

    let numberFild = document.getElementById('number');
    let number = numberFild.value;
    numberFild.value = '';

    let greadFild = document.getElementById('grade');
    let grade = greadFild.value;
    greadFild.value = '';

    if (firstName === '' || lastName === '' || number === '' || grade === '') {
        return;
    }

    let student = {
        firstName: firstName,
        lastName: lastName,
        facultyNumber: number,
        grade: grade
    }

    let responce = await fetch(url, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(student)
    })
    let rawDate = responce.json();

    incertStudent();
}

async function incertStudent() {

    let callResponce = await fetch(url);
    let date = await callResponce.json();

    let tabe = document.querySelector('#results tbody')

    Object.values(date)
        .forEach(el => {


            let tr = document.createElement('tr');

            let thFirstName = document.createElement('th');
            thFirstName.textContent = el.firstName;

            let thLastName = document.createElement('th');
            thLastName.textContent = el.lastName;

            let thFacultyNumber = document.createElement('th');
            thFacultyNumber.textContent = el.facultyNumber;

            let thGrade = document.createElement('th');
            thGrade.textContent = el.grade;

            tr.appendChild(thFirstName);
            tr.appendChild(thLastName);
            tr.appendChild(thFacultyNumber);
            tr.appendChild(thGrade);

            tabe.appendChild(tr);
    })

}

