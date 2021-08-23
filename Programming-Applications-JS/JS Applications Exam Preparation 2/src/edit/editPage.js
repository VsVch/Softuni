
import carService from "../../service/carService.js";
import { editTemplate } from "./editTemplate.js";

let form = undefined;

async function submitHandler(context,carId, e) {
    e.preventDefault();

    let formDate = new FormData(e.target);

    let brand = formDate.get('brand');
    let model = formDate.get('model');
    let description = formDate.get('description');
    let year = Number(formDate.get('year'));
    let imageUrl = formDate.get('imageUrl');
    let price = Number(formDate.get('price'));

    if (brand === '' || model === '' || description === '' || year === 0 || imageUrl === '' || price === 0) {
        window.alert('All filds are required')
        return;
    }
    console.log(model)

    let editCar = {
        brand,
        model,
        description,
        year,
        imageUrl,
        price
    }

    let editRequest = await carService.update(editCar, carId);
    context.page.redirect('/cars')  
}

async function getView(context) {
    let carId = context.params.id;
    let boundSubmitHandler = submitHandler.bind(null, context,carId);
   

    let curCar = await carService.get(carId); 
   
    let templateResult = editTemplate(curCar, boundSubmitHandler);
    context.renderView(templateResult)
}

export default {
    getView,
}