import authService from "../service/authService.js";
import { navTemplate } from "./navTemplate.js";


async function getView(context, next) {

    let username = authService.getUserName();

    let navInfo = {
        username,
    }

    let templateResult = navTemplate(navInfo)
    context.renderNav(templateResult);
    next();
}

export default {
    getView,
}