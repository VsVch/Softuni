import alertPage from '../notifications/alertPage.js';
import memeService from './../../services/memeService.js';
import { editTemplate } from './editTemplate.js';

let _form = {};

async function submitHandler(context, id, e) {
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
        let templateResult = editTemplate(_form);
        let message = _form.errorMessages.join('\n')
        alertPage.createAlert(message);        
        return context.renderView(templateResult);      
    }

    let meme = {
        title,
        description,
        imageUrl,
    }


    await memeService.update(meme, id);
    context.page.redirect(`/details/${id}`);

    } catch (error) {
        alert(error)
    }
    
}

async function getView(context) {

    let id = context.params.id;

    let meme = await memeService.get(id);

    let boundSubmitHeandler = submitHandler.bind(null, context, id);

    _form = {
        submitHandler: boundSubmitHeandler,
        values: {
            title: meme.title,
            description: meme.description,
            imageUrl: meme.imageUrl,
        }
    }

    let templateResult = editTemplate(_form);
    context.renderView(templateResult)
}

export default {
    getView,
}