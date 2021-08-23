
import authServece from '../services/authServece.js';
import { navTemplate } from './navTemplate.js';


async function currentView(context, next) {

    let email = authServece.getEmail();
    let isLoggedIn = authServece.isLoggedIn();    

    let userChek = {
        email,
        isLoggedIn,        
    }
       
    let template = navTemplate(userChek);
    context.getNavView(template)
    next();
}

export default {
    currentView,
}