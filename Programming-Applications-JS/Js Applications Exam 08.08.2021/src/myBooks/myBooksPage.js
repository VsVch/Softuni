import authService from "../../service/authService.js";
import booksService from "../../service/booksService.js";
import { myBooksTemplate } from "./myBooksTemplate.js";


async function currentView(context) {

    let userId = authService.getUserId();
    
    if (userId === undefined) {
        window.alert('Login required');
        return;
    }  
        
    let book = await booksService.getMy(userId);
       
    let templateResult = myBooksTemplate(book);
    context.getCurrentView(templateResult)
}

export default {
    currentView,
}