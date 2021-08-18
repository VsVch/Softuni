import booksService from "../../service/booksService.js";
import { createTemplate } from "./createTemplate.js";

let _formTemplate = undefined

async function submitHandler(context, e) {

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
            let templateResult = createTemplate(_formTemplate);            
            alert(_formTemplate.errorMessages.join('\n'));
            return context.getCurrentView(templateResult);
        }

        let newBook = {
            title,
            description,
            imageUrl,
            type,
        }
        await booksService.create(newBook);
        context.page.redirect('/dashboard');

    } catch (error) {
        alert(error)
    }
}

async function currentView(context) {

    let boundSubmitHeandler = submitHandler.bind(null, context);

    _formTemplate = {
        submitHandler: boundSubmitHeandler,
        errorMessages: [],
    }

    let templateResult = createTemplate(_formTemplate);
    context.getCurrentView(templateResult)
}

export default {
    currentView,
}