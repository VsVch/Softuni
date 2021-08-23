import { jsonRequest } from '../helpers/jsonRequest.js';

let baseUrl = `http://localhost:3030`;

async function getAllBooks() {

    let books = await jsonRequest(baseUrl + `/jsonstore/collections/books`);
    return books;
}
async function getBook(id) {

    let book = await jsonRequest(baseUrl + `/jsonstore/collections/books/` + id);
    return book;
}

async function createBook(book) {

    let createdBook = await jsonRequest(baseUrl + `/jsonstore/collections/books`, 'Post', book);
    return createdBook;
}

async function editBook(id,book) {

    let editBook = await jsonRequest(baseUrl + `/jsonstore/collections/books/` + id, 'Put', book);
    return editBook;
}

async function deleteBook(id) {

    let deleteBook = await jsonRequest(baseUrl + `/jsonstore/collections/books/` + id, 'Delete');
    return deleteBook;
}



let booksService = {
    getAllBooks,
    getBook,
    createBook,
    editBook,
    deleteBook,
}



export default booksService;