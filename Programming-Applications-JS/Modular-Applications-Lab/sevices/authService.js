import * as request from './requester.js';
import * as api from './api.js';

function saveDate({ _id, email, accessToken }) {

    localStorage.setItem('_id', _id);
    localStorage.setItem('email', email);
    localStorage.setItem('accessToken', accessToken);
}

export function login(email, password) {
    request.post(api.login, { email, password })
        .then(data => {
            saveDate(data);
        });
}

export function isAuthenticated() {
    let token = localStorage.getItem('accessToken');

    return Boolean(token);
}

export function getData() {
    let _id = localStorage.getItem('_id');
    let email = localStorage.getItem('email');
    let accessToken = localStorage.getItem('accessToken');

    console.log(_id)
    console.log(email)
    console.log(accessToken)

    return {
        _id,
        email,
        accessToken
    }
}