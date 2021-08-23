
import authServece from '../../services/authServece.js';
import memeService from '../../services/memeService.js';
import { detailsTemplate } from './detailsTemplate.js';

async function deleteHandler(context, memeId) {

    try {
        let deleteResult = await memeService.deleteItem(memeId);
        context.page.redirect('/memes');

    } catch (error) {
        alert(erroc)
    }
}

async function getView(context) {

    let memeId = context.params.id;
    let boundDeleteHandler = deleteHandler.bind(null, context, memeId);

    let meme = await memeService.get(memeId);
    let userId = authServece.getUserId();

    meme.isOwner = false;
    if (meme._ownerId === userId) {
        meme.isOwner = true;
    }

    let templateResult = detailsTemplate(meme, boundDeleteHandler);
    context.renderView(templateResult)
}

export default {
    getView,
}