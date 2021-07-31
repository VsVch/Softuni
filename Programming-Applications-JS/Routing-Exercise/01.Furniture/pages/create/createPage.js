import furnitureService from '../../services/furnitureService.js';
import { createTemplate } from './createTemplate.js'

let form = undefined;

async function submitHeandler(context, e) {
    e.preventDefault();

    let formDate = new FormData(e.target);

    form.invalidFields = {};

    let make = formDate.get('make');
    if (make.length < 4) {
        form.invalidFields.make = true;
    }

    let model = formDate.get('model');
    if (model.length < 4) {
        form.invalidFields.model = true;
    }

    let year = Number(formDate.get('year'));
    if (!(year >= 1950 || year <= 2050)) {
        form.invalidFields.year = true;
    }

    let description = formDate.get('description');
    if (description.length <= 10) {
        form.invalidFields.description = true;
    }

    let price = Number(formDate.get('price'));
    if (!(price > 0)) {
        form.invalidFields.price = true;
    }

    let img = formDate.get('img');
    if (img.trim() === '') {
        form.invalidFields.img = true;
    }

    if (Object.keys(form.invalidFields).length > 0) {
        let templateResult = createTemplate(form);
        return context.renderView(templateResult);
    }

    let material = formDate.get('material');

   let newFurniture = {
        make,
        model,
        year,
        description,
        price,
        img,
        material,
    }

    let createResult = await furnitureService.create(newFurniture);
    context.page.redirect('/dashboard');
}

async function getView(context) {

    let boundSubmitHeandler = submitHeandler.bind(null, context);

    form = {
        submitHandler: boundSubmitHeandler,
        invalidFields: {
            make: true,
            model: true,
            year: true,
            description: true,
            price: true,
            img: true,
        }
    }

    let templateResult = createTemplate(form);
    context.renderView(templateResult)
}

export default {
    getView,
}