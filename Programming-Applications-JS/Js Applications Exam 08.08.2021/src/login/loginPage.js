import authService from "../../service/authService.js";
import { loginTemplate } from "./loginTemplate.js";

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

        if (_formTemplate.errorMessages.length > 0) {
            let templateResult = loginTemplate(_formTemplate);
            alert(_formTemplate.errorMessages.join('\n'))
            return context.getCurrentView(templateResult);
        }

        let user = {
            email,
            password,
        }

        await authService.login(user);
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

    let templateResult = loginTemplate(_formTemplate);
    context.getCurrentView(templateResult)
}

export default {
    currentView,
}
