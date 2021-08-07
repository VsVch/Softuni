import { jsonRequest } from "../helpers/jsonRequest.js";

let baseUrl = 'http://localhost:3030/users'

function getAuthToken() {
    return localStorage.getItem('authToken');
}

// function getUserName() {
//     return localStorage.getItem('username');
// }

function getEmail() {
    return localStorage.getItem('email');
}

// function getGender() {
//     return localStorage.getItem('gender');
// }

function getUserId() {
    return localStorage.getItem('userId');
}

function isLoggedIn() {
    return localStorage.getItem('authToken') !== null;
}

async function login(user) {

    let result = await jsonRequest(`${baseUrl}/login`, 'Post', user);

    localStorage.setItem('authToken', result.accessToken);
    localStorage.setItem('email', result.email);
    //localStorage.setItem('username', result.username);
    localStorage.setItem('userId', result._id);
    //localStorage.setItem('gender', result.gender)

    return result;
}

async function register(user) {

    let result = await jsonRequest(`${baseUrl}/register`, 'Post', user);
    localStorage.setItem('authToken', result.accessToken);
    localStorage.setItem('email', result.email);
    //localStorage.setItem('username', result.username);
    localStorage.setItem('userId', result._id);
    //localStorage.setItem('gender', result.gender);

}


async function logout() {

    await jsonRequest(`${baseUrl}/logout`, 'Get', undefined, true, true);
    localStorage.clear();
}


export default {
    getAuthToken,
    //getUserName,
    getUserId,
    isLoggedIn,
    login,
    register,
    logout,
    getEmail,
    //getGender
}