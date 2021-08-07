import authServece from "../../services/authServece.js";
import moviesService from "../../services/moviesService.js";
import { detailsTemplate } from "./detailsTemplate.js";


async function likesHandler(context, id) {

    let newLike = {
        movieId: id,
    }
    await moviesService.postLike(newLike);
    context.page.redirect('/home');
}

async function deleteHandler(context, id) {

    await moviesService.deleteItem(id);
    context.page.redirect('/home');
}

async function getView(context) {

    let id = context.params.id;
    let boundDeleteHandler = deleteHandler.bind(null, context, id);
    let boundlikesHandler = likesHandler.bind(null, context, id);

    let currId = authServece.getUserId();
   
    let currMovie = await moviesService.get(id);
    let likes = await moviesService.getLikes(id);
    let getOwnLike = await moviesService.getMyLike(id, currId);

    let isCreator = false;
    let creatorId = currMovie._ownerId;

    if (creatorId === currId) {
        isCreator = true;
    }    

    let movieInfo = {
        isCreator,
        deleteHandler: boundDeleteHandler,
        likesHandler: boundlikesHandler,
        movieId: id,
        getOwnLike,
        likes,
    } 
  
    let templateResult = detailsTemplate(currMovie, movieInfo);
    context.renderView(templateResult);
}

export default {
    getView,
}