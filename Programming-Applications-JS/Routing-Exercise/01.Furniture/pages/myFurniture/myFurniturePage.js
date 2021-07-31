import { myFurnitureTemplate } from "./myFurnitureTemplate.js";
import furnitureService from './../../services/furnitureService.js';
import authServece from "../../services/authServece.js";


async function getView(context) {

    let userId = authServece.getUserId()
    let myFurniture = await furnitureService.getMy(userId);
  
    let templateResult = myFurnitureTemplate(myFurniture);
    context.renderView(templateResult);

}

export default {
    getView,
}