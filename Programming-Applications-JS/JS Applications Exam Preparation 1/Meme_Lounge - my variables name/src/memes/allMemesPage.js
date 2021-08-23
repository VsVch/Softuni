import memeService from "../../services/memeService.js";
import { allMemesTemplate } from "./allMemesTemplate.js";

async function currentView(context){

    let date = await memeService.getAll();   

    let templateResult = allMemesTemplate(date);
    context.getCurrentView(templateResult)
}

export default{
    currentView
}