
import { welcomeTemplate } from './welcomeTemplate.js';

async function getView(context, next) {
   
    let template = welcomeTemplate();
    context.renderView(template);
    next();
}

export default {
    getView,
}