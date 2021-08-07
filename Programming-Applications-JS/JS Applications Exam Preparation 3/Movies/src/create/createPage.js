
import moviesService from "../../services/moviesService.js";
import { createTemplate } from "./createTemplate.js";

let _form = undefined;

async function submitHandler(context, e) {
    e.preventDefault();
    try {

        _form.errorMesseage = [];

        let formData = new FormData(e.target);

        let title = formData.get('title');
        if (title.trim() === '') {
            _form.errorMesseage.push('Title is reguired');
        }

        let description = formData.get('description');
        if (description.trim() === '') {
            _form.errorMesseage.push('Description is reguired');
        }

        let imageUrl = formData.get('imageUrl');
        if (imageUrl.trim() === '') {
            _form.errorMesseage.push('Image is reguired');
        }

        if (_form.errorMesseage.length > 0) {
            let templateResult = createTemplate(_form);
            alert(_form.errorMesseage.join('\n'))
            return context.renderView(templateResult);
        }

        let newMovie = {
            title,
            description,
            imageUrl,
        }

        await moviesService.create(newMovie);
        context.page.redirect('/home');

    } catch (error) {
        alert(error);
    }

}

async function getView(context) {

    let boundSubmitHandler = submitHandler.bind(null, context);

    _form = {
        submitHandler: boundSubmitHandler,
        errorMesseage: [],
    }

    let templateResult = createTemplate(_form);
    context.renderView(templateResult);
}

export default {
    getView,
}