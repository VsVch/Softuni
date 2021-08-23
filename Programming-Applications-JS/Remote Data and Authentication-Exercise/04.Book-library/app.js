let loadBtn = document.getElementById('loadBooks');
loadBtn.addEventListener('click', getBooks);

let loadUrl = `http://localhost:3030/jsonstore/collections/books`;

let booksTable = document.querySelector('#books-table tbody');
booksTable.querySelectorAll('tr').forEach(el => el.remove());

let bookForm = document.getElementById('book-form');
bookForm.addEventListener('submit', handleFormSubmit);

async function createBook(formDate) {

    let newBook = {
        title: formDate.get('title'),
        author: formDate.get('author'),
    }

    let createResponce = await fetch(loadUrl, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(newBook),
    });
    let bookRowDate = await createResponce.json();
    let creatHtmlBook = createHtmlBook(bookRowDate, bookRowDate._id);
    booksTable.appendChild(creatHtmlBook)

}

async function editBook(formDate, id) {

    let editBook = {
        title: formDate.get('title'),
        author: formDate.get('author'),
    }

    let editResponce = await fetch(`http://localhost:3030/jsonstore/collections/books/${id}`, {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(editBook),
    });
    let bookRowDate = await editResponce.json();
    let editedBook = booksTable.querySelector(`tr.book[data-id="${id}"]`)

    let editHtmlBook = createHtmlBook(bookRowDate, bookRowDate._id);
    editedBook.replaceWith(editHtmlBook);
}

async function getBooks() {    

    let laodResponce = await fetch(loadUrl);
    let rowDate = await laodResponce.json();

    booksTable.querySelectorAll('tr').forEach(el => el.remove());

    Object.keys(rowDate)
        .forEach(el => {
            let htmlBook = createHtmlBook(rowDate[el], el);
            booksTable.appendChild(htmlBook);
        })
}

function handleEdit(e) {
    let currentBook = e.target.closest('.book')
    let currenTitle = currentBook.querySelector('.title');
    let currentAuthor = currentBook.querySelector('.author');
    let formHeading = bookForm.querySelector('h3');
    formHeading.textContent = 'Edit Form';
    bookForm.dataset.entryId = currentBook.dataset.id;
    bookForm.dataset.isEdit = true

    let titleInput = bookForm.querySelector('input[name="title"]');
    titleInput.value = currenTitle.textContent

    let authorInput = bookForm.querySelector('input[name="author"]');
    authorInput.value = currentAuthor.textContent;

}

async function handleFormSubmit(e) {
    e.preventDefault()
    let form = e.currentTarget;
    let formDate = new FormData(form);

    if (form.dataset.isEdit !== undefined) {
        let id = form.dataset.entryId;
        editBook(formDate, id)
    } else {
        createBook(formDate);
    }
}

function createHtmlBook(book, id) {

    let titleTd = tagCreator('td', { class: 'title' }, book.title);
    let authoirTd = tagCreator('td', { class: 'author' }, book.author);
    let editBtn = tagCreator('button', undefined, 'Edit');
    editBtn.addEventListener('click', handleEdit);
    let deleteBtn = tagCreator('button', undefined, 'Delete');
    deleteBtn.addEventListener('click', deleteBook);
    let buttonsTd = tagCreator('td', undefined, editBtn, deleteBtn);
    let tr = tagCreator('tr', { class: 'book' }, titleTd, authoirTd, buttonsTd);
    tr.dataset.id = id;
    return tr;
}

async function deleteBook(e) {
    let bookToDelete = e.target.closest('.book');
    let id = bookToDelete.dataset.id;
    let url = `http://localhost:3030/jsonstore/collections/books/${id}`;

    let deleteResponce = await fetch(url, {
        method: 'DELETE',
    });

    if (deleteResponce.status === 200) {
        bookToDelete.remove();
    }

}

function tagCreator(tag, attributes, ...params) {

    let element = document.createElement(tag);
    let firstValue = params[0];

    if (params.length === 1 && typeof (firstValue) !== 'object') {
        if (['input', 'textarea'].includes(tag)) {
            element.value = firstValue;
        } else {
            element.textContent = firstValue;
        }
    } else {
        element.append(...params)
    }

    if (attributes !== undefined) {
        Object.keys(attributes).forEach(key => {
            element.setAttribute(key, attributes[key])
        });
    }

    return element;
}