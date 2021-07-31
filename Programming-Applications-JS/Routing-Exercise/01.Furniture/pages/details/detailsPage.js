import {datailsTemplate } from "./detailsTemplate.js";
import furnitureService from './../../services/furnitureService.js';
import authServece from "../../services/authServece.js";

async function deleteHandler(context, id, e) {
 console.log('hi')
    let deleteResult = await furnitureService.deleteItem(id);
    context.page.redirect('/dashboard');

}

async function getView(context) {

    let id = context.params.id;
    let boundDeleteHandler = deleteHandler.bind(null, context, id);
    
    let furniture = await furnitureService.get(id);
    let isOwner = authServece.getUserId() === furniture._ownerId;   
   
    let templateResult = datailsTemplate(furniture, boundDeleteHandler,isOwner);
    context.renderView(templateResult);
}

export default {
    getView,
}