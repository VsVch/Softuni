import { render } from './../node_modules/lit-html/lit-html.js'
import { jsonRequest } from './helpers/jsonRequest.js';
import booksService from './services/booksService.js';
import { allBooksTemplate, allFormsTemplate, bookLibralyTemplate, formTemplate } from './templates/bookTemplate.js';


let body = document.body;

let addForm = {
    id: 'add-form',
    type: 'add',
    title: 'Add Book',
    submitText: 'Submit',
    submitHandler: createBook,
}

let editForm = {
    id: 'edit-form',
    type: 'edit',
    title: 'Edit Book',
    submitText: 'Seve',
    class: 'hidden',
    submitHandler: editBook,
    idValue: ' ',
    authorValue: ' ',
    titleValue: ' ',
}

let forms = [addForm, editForm];
let books = [];

render(bookLibralyTemplate([], forms, loadBooks, books, preperEdit), body);


async function loadBooks() {

    let booksContainer = document.querySelector('#books-container');
    let booksObj = await booksService.getAllBooks();

    books = Object.entries(booksObj).map(([key, val]) => {
        val.id = key;
        return val;
    });

    render(allBooksTemplate(books, preperEdit, deleteBook), booksContainer);
}

async function preperEdit(e) {
    let book = e.target.closest('.book');
    let id = book.dataset.id;

    let curBook = await booksService.getBook(id);
    console.log(curBook)

    editForm.class = undefined;
    editForm.idValue = id;
    editForm.titleValue = curBook.title;
    editForm.authorValue = curBook.author;

    render(bookLibralyTemplate(books, forms, loadBooks), body);
}

async function createBook(e) {
    e.preventDefault();
   
    let booksContainer = document.querySelector('#books-container');
    let form = e.target;
    let formDate = new FormData(form);

    let newBook = {
        author: formDate.get('author'),
        title: formDate.get('title'),
    }

    books.push(newBook);
    let createResult = await booksService.createBook(newBook);

    render(allBooksTemplate(books, preperEdit, deleteBook), booksContainer);
}

async function editBook(e) {
    e.preventDefault();

    let booksContainer = document.querySelector('#books-container');
    let form = e.target;
    let formDate = new FormData(form);
    let id = formDate.get('id');

    let newBook = {
        author: formDate.get('author'),
        title: formDate.get('title'),
    }


    let createResult = await booksService.editBook(id, newBook);
    books = books.filter(x => x._id !== id)
    books.push(createResult);
    render(allBooksTemplate(books, preperEdit, deleteBook), booksContainer);
}


async function deleteBook(e) {
   
   let element = e.target.closest('.book');
   let id = element.dataset.id;

   let deleteElement = await booksService.deleteBook(id);
   element.remove();   
}
