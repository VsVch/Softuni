import authServece from '../../services/authServece.js';
import {regesterTemplate} from './registerTemplate.js'



async function submitHeandler(context, e) {
    e.preventDefault();

    let formDate = new FormData(e.target);

    let user = {
        email: formDate.get('email'),
        password: formDate.get('password'),
        rePass: formDate.get('rePass'),
    }

    let registerResult = await authServece.register(user);
    
    console.log(registerResult);
    context.page.redirect('/dashboard');
}

async function getView(context) {

    let boundSubmitHeandler = submitHeandler.bind(null, context);

    let form = {
        submitHeandler: boundSubmitHeandler,
    }

    let templateResult = regesterTemplate(form);
    context.renderView(templateResult)
}

export default {
    getView,
}