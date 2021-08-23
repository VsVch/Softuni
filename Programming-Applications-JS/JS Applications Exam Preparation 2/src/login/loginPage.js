import authService from "../../service/authService.js";
import { loginTemplate } from "./loginTemplate.js"

async function submitHandler(context, e){
    e.preventDefault();

    let formDate = new FormData(e.target);

    let username = formDate.get('username');
    let password = formDate.get('password');   
      
    if (username === '' || password === '') {
        window.alert('All filds are required')
        return;
    }

    let user = {
        username,
        password
    }

    let loginRequest = await authService.login(user);   
    context.page.redirect('/home') // should redirect in cars    
}

async function getView(context) {

    let boundSubmitHandler = submitHandler.bind(null, context);

    let form = {
        submitHandler: boundSubmitHandler,
    }

    let templateResult = loginTemplate(form);
    context.renderView(templateResult)
}

export default {
    getView,
}