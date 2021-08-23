import memeService from "../../services/memeService.js";
import { allMemesTemplate } from "./allMemesTemplate.js";

async function getView(context){

    let date = await memeService.getAll();   

    let templateResult = allMemesTemplate(date);
    context.renderView(templateResult)
}

export default{
    getView
}