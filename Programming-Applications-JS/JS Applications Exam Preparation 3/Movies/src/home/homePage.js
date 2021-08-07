
import moviesService from "../../services/moviesService.js";
import { homeTemplate } from "./homeTemplate.js"

async function getView(context) {   

    let movies = await moviesService.getAll(); 
       
    let templateResult = homeTemplate(movies);
    context.renderView(templateResult);   
}

export default {
    getView,
}