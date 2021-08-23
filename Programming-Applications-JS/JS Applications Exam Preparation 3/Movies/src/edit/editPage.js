import moviesService from "../../services/moviesService.js";
import { editTemplate } from "./editTemplate.js";

let _form = undefined;

async function submitHandler(context, movieId, e) {
    e.preventDefault();

    try {

        _form.errorMessege = [];
        
        let formDate = new FormData(e.target);

        let title = formDate.get('title');
        if (title.trim() === '') {
            _form.errorMessege.push('Title is required!');
        }

        let description = formDate.get('description');
        if (description.trim() === '') {
            _form.errorMessege.push('Description is required!');
        }

        let imageUrl = formDate.get('imageUrl');
        if (imageUrl.trim() === '') {
            _form.errorMessege.push('Image is required!');
        }

        if (_form.errorMessege.length > 0) {
            let templateResult = editTemplate(_form);
            alert(_form.errorMessege.join('\n'));
            return context.renderView(templateResult);
        }

        let updateMovie = {
            title,
            description,
            img: imageUrl,
        }

        await moviesService.update(updateMovie, movieId)
        context.page.redirect('/home');

    } catch (error) {
        alert(error)
    }
}

async function getView(context, id) {

    let movieId = context.params.id;
    let boundSubmitHandler = submitHandler.bind(null, context, movieId);

    let currMovie = await moviesService.get(movieId);

    _form = {
        submitHandler: boundSubmitHandler,
        errorMessege: [],
        movie: {
            title: currMovie.title,
            description: currMovie.description,
            img: currMovie.img,
        }
    }

    let templateResult = editTemplate(_form);
    context.renderView(templateResult);
}

export default {
    getView,
}

