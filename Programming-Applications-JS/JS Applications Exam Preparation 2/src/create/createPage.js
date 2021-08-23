
import carService from "../../service/carService.js";
import { createTemplate } from "./createTemplate.js";

let form = undefined;

async function submitHandler(context, e){
    e.preventDefault();

    let formDate = new FormData(e.target);

    let brand = formDate.get('brand');
    let model = formDate.get('model');   
    let description = formDate.get('description');   
    let year = Number(formDate.get('year'));   
    let imageUrl = formDate.get('imageUrl');   
    let price = Number(formDate.get('price'));   
      
    if (brand === '' || model === '' || description === '' || year === '' || imageUrl === '' || price === '') {
        window.alert('All filds are required')
        return;
    } 
    
    let newCar = {        
        brand,
        model,
        description,
        year,
        imageUrl,
        price
    }

    let createRequest = await carService.create(newCar);   
    context.page.redirect('/cars') // should redirect in cars    
}

async function getView(context) {

    let boundSubmitHandler = submitHandler.bind(null, context);

   let form = {
        submitHandler: boundSubmitHandler,      
    }
    console.log(form)

    let templateResult = createTemplate(form);
    context.renderView(templateResult)
}

export default {
    getView,
}