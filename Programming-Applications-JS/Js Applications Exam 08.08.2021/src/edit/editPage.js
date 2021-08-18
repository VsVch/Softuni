import booksService from "../../service/booksService.js";
import { editTemplate } from "./editTemplate.js";


let _formTemplate = {};

async function submitHandler(context, id, e) {
    e.preventDefault();

    try {
        _formTemplate.errorMessages = [];

    let formDate = new FormData(e.target);

    let title = formDate.get('title');
    if (title.trim() === '') {
        _formTemplate.errorMessages.push('Title of book is required');
    }

    let description = formDate.get('description');
    if (description.trim() === '') {
        _formTemplate.errorMessages.push('Description of book is required');
    }

    let imageUrl = formDate.get('imageUrl');

    if (imageUrl.trim() === '') {
        _formTemplate.errorMessages.push('Imige of book is required');
    }

    let type = formDate.get('type');

    if (type.trim() === '') {
        _formTemplate.errorMessages.push('Type of book is required');
    }

    if (_formTemplate.errorMessages.length > 0) {
        let templateResult = editTemplate(_formTemplate);
        alert(_formTemplate.errorMessages.join('\n'))     
        return context.getCurrentView(templateResult);      
    }

    let book = {
        title,
        description,
        imageUrl,
        type,
    }


    await booksService.update(book, id);
    context.page.redirect(`/details/${id}`);

    } catch (error) {
        alert(error)
    }
    
}

async function currentView(context) {

    let id = context.params.id;
    let book = await booksService.get(id);    

    let boundSubmitHeandler = submitHandler.bind(null, context, id);

    _formTemplate = {
        submitHandler: boundSubmitHeandler,
        values: {
            title: book.title,
            description: book.description,
            imageUrl: book.imageUrl,
            type: book.type
        }
    }

    let templateResult = editTemplate(_formTemplate);
    context.getCurrentView(templateResult)
}

export default {
    currentView,
}