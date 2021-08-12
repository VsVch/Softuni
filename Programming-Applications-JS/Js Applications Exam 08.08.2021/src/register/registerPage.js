import authService from "../../service/authService.js";
import { registerTemplate } from "./registerTemplate.js";


let _formTemplate = undefined;

async function submitHandler(context, e) {
    e.preventDefault();
    try {

        _formTemplate.errorMessages = [];
        let formDate = new FormData(e.target);        

        let email = formDate.get('email');
        if (email.trim() === '') {
            _formTemplate.errorMessages.push('Email is required');
        }
               
        let password = formDate.get('password');
        if (password.trim() === '') {
            _formTemplate.errorMessages.push('Password is required');
        }

        let repeatPass = formDate.get('confirm-pass');
        if (repeatPass.trim() === '') {
            _formTemplate.errorMessages.push('Repeat password is required');
        }        
        
        if (_formTemplate.errorMessages.length > 0) {
            let templateResult = registerTemplate(_formTemplate);            
            alert(_formTemplate.errorMessages.join('\n'))
           return context.getCurrentView(templateResult);
        }

        let user = {            
            email,
            password,           
        }

        await authService.register(user);
        context.page.redirect('/dashboard');

    } catch (error) {
        alert(error)
    }

}

async function currentView(context) {

    let boundSubmitHeandler = submitHandler.bind(null, context);

    _formTemplate = {
        submitHandler: boundSubmitHeandler,
        errorMessages: [],
    }

    let templateResult = registerTemplate(_formTemplate);
    context.getCurrentView(templateResult)
}

export default {
    currentView,
}