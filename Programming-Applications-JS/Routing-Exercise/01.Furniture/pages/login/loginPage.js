import authServece from '../../services/authServece.js';
import {loginTemplate} from './loginTemplate.js';


async function submitHeandler(context, e) {
    e.preventDefault();

    let formDate = new FormData(e.target);

    let user = {
        email: formDate.get('email'),
        password: formDate.get('password'),
    }

    let loginResult = await authServece.login(user);
    
    console.log(loginResult);
    context.page.redirect('/dashboard');
}

async function getView(context) {

    let boundSubmitHeandler = submitHeandler.bind(null, context);

    let form = {
        submitHeandler: boundSubmitHeandler,
    }

    let templateResult = loginTemplate(form);
    context.renderView(templateResult)
}

export default {
    getView,
}