import authService from "../../service/authService.js";
import { registerTemplate } from "./registerTemplate.js"

async function submitHandler(context, e){
    e.preventDefault();

    let formDate = new FormData(e.target);

    let username = formDate.get('username');
    let password = formDate.get('password');
    let repeatPass = formDate.get('repeatPass'); 

   
    if (username === '' || password === '' || repeatPass == '') {
        window.alert('All filds are required')
        return;
    }

    let user = {
        username,
        password
    }

    let registerRequest = await authService.register(user);
    context.page.redirect('/home') // should redirect in cars
    
}

async function getView(context) {

    let boundSubmitHandler = submitHandler.bind(null, context);

    let form = {
        submitHandler: boundSubmitHandler,
    }

    let templateResult = registerTemplate(form);
    context.renderView(templateResult)
}

export default {
    getView,
}