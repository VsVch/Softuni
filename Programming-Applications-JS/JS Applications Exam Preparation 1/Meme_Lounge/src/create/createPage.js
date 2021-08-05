import alertPage from '../notifications/alertPage.js';
import memeService from './../../services/memeService.js';
import { createTemplate } from './createTemplate.js';

let _form = undefined

async function submitHandler(context, e) {
    e.preventDefault();

    try {

        _form.errorMessages = [];

        let formDate = new FormData(e.target);

        let title = formDate.get('title');
        if (title.trim() === '') {
            _form.errorMessages.push('Title is required');
        }

        let description = formDate.get('description');

        if (description.trim() === '') {
            _form.errorMessages.push('Description is required');
        }

        let imageUrl = formDate.get('imageUrl');

        if (imageUrl.trim() === '') {
            _form.errorMessages.push('Imige is required');
        }

        if (_form.errorMessages.length > 0) {
            let templateResult = createTemplate(_form);
            let message = _form.errorMessages.join('\n')
            alertPage.createAlert(message);
            //alert(_form.errorMessages.join('\n'));
            return context.renderView(templateResult);
        }

        let newMeme = {
            title,
            description,
            imageUrl,
        }
        let createResult = await memeService.create(newMeme);
        context.page.redirect('/memes');

    } catch (error) {
        alert(error)
    }
}

async function getView(context) {

    let boundSubmitHeandler = submitHandler.bind(null, context);

    _form = {
        submitHandler: boundSubmitHeandler,
        errorMessages: [],
    }

    let templateResult = createTemplate(_form);
    context.renderView(templateResult)
}

export default {
    getView,
}