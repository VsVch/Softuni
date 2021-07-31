import authServece from "../services/authServece.js"
import { navTemplate } from "./navTemplate.js"


function getView(context, next) {     
    
    let navInfo = {
        isLoggedIn: authServece.isLoggedIn(),
        currentPage: context.pathname,
    }
    let templateResult = navTemplate(navInfo);
    context.renderNav(templateResult);
    next();
}

export default {
    getView,
}