import authService from "../../service/authService.js";
import carService from "../../service/carService.js";
import { myCarsTemplate } from "./myCarsTemplate.js"


async function getView(context) {

    let id = authService.getUserId();
    let cars = await carService.getMy(id);

    let templateResult = myCarsTemplate(cars);
    context.renderView(templateResult);
}

export default {
    getView,
}