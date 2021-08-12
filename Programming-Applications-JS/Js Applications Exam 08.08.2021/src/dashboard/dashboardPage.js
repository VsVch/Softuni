import booksService from "../../service/booksService.js";
import { allBooksTemplate } from "./dashboardTemplate.js";


async function currentView(context){

    let date = await booksService.getAll();   

    let template = allBooksTemplate(date);
    context.getCurrentView(template)
}

export default{
    currentView
}