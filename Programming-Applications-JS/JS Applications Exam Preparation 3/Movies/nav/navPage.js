import authServece from "../services/authServece.js"
import { navTemplate } from "./navTemplate.js"


async function getView(context, next) {
    
    let isLoggedIn = authServece.isLoggedIn();
    let email = authServece.getEmail();

    let navInfo = {
        isLoggedIn,
        email,
    }

    let templateResult = navTemplate(navInfo)
    context.renderNav(templateResult);
    next();
}

export default {
    getView,
}