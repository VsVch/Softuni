import authServece from "../../services/authServece.js";
import { registerTemplate } from "./registerTemplate.js";

let _form = undefined;

async function submitHandler(context, e) {
    e.preventDefault();

    try {

        _form.errorMessage = [];

        let formData = new FormData(e.target);

        let email = formData.get('email');
        if (email.trim() === '') {
            _form.errorMessage.push('Email is required')
        }

        let password = formData.get('password');
        if (password.trim() === '') {
            _form.errorMessage.push('Password is reqired')
        }

        if (password.length < 6) {
            _form.errorMessage.push('Password shoul be more than 5 symbols')
        }

        let repeatPassword = formData.get('repeatPassword');
        
        if (repeatPassword !== password) {
            _form.errorMessage.push('Repeat password and password should much')
        }

        if (_form.errorMessage.length > 0) {
            let templateResult = registerTemplate(_form);
            alert(_form.errorMessage.join('\n'));
            return context.renderView(templateResult);
        }

        let user = {
            email,
            password,
        }

        await authServece.register(user)
        context.page.redirect('/home')

    } catch (error) {
        alert(error);
    }

}

async function getView(context) {

    let boundSubmitHandler = submitHandler.bind(null, context);

    _form = {
        submitHandler: boundSubmitHandler,
        errorMessage: [],
    }

    let templateResult = registerTemplate(_form);
    context.renderView(templateResult);
}

export default {
    getView,
}