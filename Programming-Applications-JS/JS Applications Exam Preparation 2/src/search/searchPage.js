import carService from "../../service/carService.js";
import { searchTemplate } from "./searchTemplate.js";

let cars = undefined;
let curSearch = undefined;

async function getView(context) {

    let onSearchChange = (e) => {
        curSearch = e.target.value;
    };

    async function onSearchClick() {
    
        let year = Number(curSearch);
        cars = await carService.getByYear(year);
    
        let templateResult = searchTemplate(onSearchChange, onSearchClick, cars);
        context.renderView(templateResult);
        cars = [];
    }
    
    let templateResult = searchTemplate(onSearchChange, onSearchClick, cars);
    context.renderView(templateResult);
}

export default {
    getView,
}