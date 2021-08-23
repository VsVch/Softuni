import authServece from '../../services/authServece.js';
import alertPage from '../notifications/alertPage.js';
import { registerTemplate } from './registerTemplate.js';

let _form = undefined;

async function submitHandler(context, e) {
    e.preventDefault();
    try {

        _form.errorMessages = [];

        let formDate = new FormData(e.target);

        let username = formDate.get('username');
        if (username.trim() === '') {
            _form.errorMessages.push('Username is required');
        }

        let email = formDate.get('email');
        if (email.trim() === '') {
            _form.errorMessages.push('Email is required');
        }
               
        let password = formDate.get('password');
        if (password.trim() === '') {
            _form.errorMessages.push('Password is required');
        }

        let repeatPass = formDate.get('repeatPass');
        if (repeatPass.trim() === '') {
            _form.errorMessages.push('Repeat password is required');
        }

        let gender = formDate.get('gender')
        if (gender.trim() === '') {
            _form.errorMessages.push('Gender is required');
        } 
        
        if (_form.errorMessages.length > 0) {
            let templateResult = registerTemplate(_form);
            let message = _form.errorMessages.join('\n')
            alertPage.createAlert(message);
            //alert(_form.errorMessages.join('\n'))
           return context.renderView(templateResult);
        }

        let user = {
            username,
            email,
            password,
            gender
        }

        await authServece.register(user);
        context.page.redirect('/memes');

    } catch (error) {
        alert(error)
    }

}

async function getView(context) {

    let boundSubmitHeandler = submitHandler.bind(null, context);

    _form = {
        submitHandler: boundSubmitHeandler,
        errorMessages: [],
    }

    let templateResult = registerTemplate(_form);
    context.renderView(templateResult)
}

export default {
    getView,
}