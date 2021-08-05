import carService from '../../service/carService.js';
import { carsTemplate } from './carsTemplate.js';

async function getView(context) {

    let cars = await carService.getAll();    
    let resultTemplate = carsTemplate(cars);

    context.renderView(resultTemplate);
}

export default {
    getView,
}