import authService from "../../service/authService.js";
import carService from "../../service/carService.js"
import { detailsTemplate } from "./detailsTemplate.js";

async function deleteHandler(context, id, e) {
    
       let deleteResult = await carService.deleteItem(id);
       context.page.redirect('/cars');   
   }
   

async function getView(context) {

    let id = context.params.id
    let boundDeleteHandler = deleteHandler.bind(null, context, id);
    let car = await carService.get(id);

    let creatorId = car._ownerId;
    let userId = authService.getUserId();    

    let isCreator = undefined;
    if (creatorId === userId) {
        isCreator = true;
    }

    let resultTemplate = detailsTemplate(car, isCreator, boundDeleteHandler);
    context.renderView(resultTemplate);
}

export default {
    getView,
}