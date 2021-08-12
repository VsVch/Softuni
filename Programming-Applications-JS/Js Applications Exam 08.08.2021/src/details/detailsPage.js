import authService from "../../service/authService.js";
import booksService from "../../service/booksService.js";
import { detailsTemplate } from "./detailsTemplate.js";

async function likesHandler(context, bookId) {

    let newLike = {
        bookId: bookId,
    }
    await booksService.postLike(newLike);    
}

async function deleteHandler(context, bookId) {

    try {
        await booksService.deleteItem(bookId);
        context.page.redirect('/dashboard');

    } catch (error) {
        alert(erroc)
    }
}

async function currentView(context) {

    let bookId = context.params.id;
    let userId = authService.getUserId();
    let boundDeleteHandler = deleteHandler.bind(null, context, bookId);
    let boundlikesHandler = likesHandler.bind(null, context, bookId);

    let book = await booksService.get(bookId);
    let likes = await booksService.getLikes(bookId);
    let getOwnLike = await booksService.getMyLike(bookId, userId);
    
    let isOwner = false;   
    
    if (book._ownerId === userId) {
        isOwner = true;
    }

    let bookInfo = {
        deleteHandler: boundDeleteHandler,
        likesHandler: boundlikesHandler,
        isOwner,
        likes,
        getOwnLike,
        userId,
    }    
     
    let templateResult = detailsTemplate(book, bookInfo);
    context.getCurrentView(templateResult);
}

export default {
    currentView,
}