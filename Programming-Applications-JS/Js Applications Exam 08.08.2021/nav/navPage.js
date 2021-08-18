import authService from "../service/authService.js";
import { navTemplate } from "./navTemplate.js";


async function currentView(context, next) {

    let email = authService.getEmail();
    let isLoggedIn = authService.isLoggedIn();    

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