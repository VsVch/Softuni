import authServece from '../../services/authServece.js';
import { loginTemplate } from './loginTemplate.js';
import alertPage from '../notifications/alertPage.js';

let _form = undefined;

async function submitHandler(context, e) {
    e.preventDefault();
    try {
        _form.errorMessages = [];

        let formDate = new FormData(e.target);

        let email = formDate.get('email');
        if (email.trim() === '') {
            _form.errorMessages.push('Email is required');
        }

        let password = formDate.get('password');
        if (password.trim() === '') {
            _form.errorMessages.push('Password is required');
        }

        if (_form.errorMessages.length > 0) {
            let templateResult = loginTemplate(_form);
            let message = _form.errorMessages.join('\n')
            alertPage.createAlert(message);
            //alert(_form.errorMessages.join('\n'))
           return context.renderView(templateResult);
        }

        let user = {
            email,
            password,
        }

        let loginResult = await authServece.login(user);
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

    let templateResult = loginTemplate(_form);
    context.renderView(templateResult)
}

export default {
    getView,
}