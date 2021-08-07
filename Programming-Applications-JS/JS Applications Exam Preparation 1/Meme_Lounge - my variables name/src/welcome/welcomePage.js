
import { welcomeTemplate } from './welcomeTemplate.js';

async function currentView(context, next) {
   
    let template = welcomeTemplate();
    context.getCurrentView(template);
    next();
}

export default {
    currentView,
}