import authServece from "../../services/authServece.js";
import { loginTemplate } from "./loginTemplate.js";

let _form = undefined;

async function submitHandler(context, e) {
    e.preventDefault();

    try {
        _form.messegErrors = [];

        let formData = new FormData(e.target);

        let email = formData.get('email');
        if (email.trim() === '') {
            _form.messegErrors.push('Email is required')
        }

        let password = formData.get('password');
        if (password.trim() === '') {
            _form.messegErrors.push('Password is reqired')
        }
        console.log(password.length)
        
        if(password.length < 6) {
            _form.messegErrors.push('Password shoult be more than 5 symbols')
        }

        if (_form.messegErrors.length > 0) {
            let templateResult = loginTemplate(_form);
            alert(_form.messegErrors.join('\n'));
            return context.renderView(templateResult);
        }

        let user = {
            email,
            password,
        }

        await authServece.login(user);
        context.page.redirect('/home');

    } catch (error) {
        alert(error)
    }

}

async function getView(context) {
   
    let bondSubmitHandler = submitHandler.bind(null, context);

    _form = {
        submitHandler: bondSubmitHandler,
        messegErrors: [],
    }

    let templateResult = loginTemplate(_form);
    context.renderView(templateResult);
}

export default {
    getView,
}