import { requesterFactory } from "../helpers/requesterFactory.js";

let baseUrl = 'http://localhost:3030/users'

function getAuthToken() {
    return localStorage.getItem('authToken');
}

function getEmail() {
    return localStorage.getItem('email');
}

function getUserId() {
    return localStorage.getItem('userId');
}

function isLoggedIn() {
    return localStorage.getItem('authToken') !== null;
}

async function login(user) {

    let result = await requesterFactory(`${baseUrl}/login`, 'Post', user);

    localStorage.setItem('authToken', result.accessToken);
    localStorage.setItem('email', result.email);    
    localStorage.setItem('userId', result._id);
    

    return result;
}

async function register(user) {

    let result = await requesterFactory(`${baseUrl}/register`, 'Post', user);
    localStorage.setItem('authToken', result.accessToken);
    localStorage.setItem('email', result.email);    
    localStorage.setItem('userId', result._id);
}


async function logout() {

    await requesterFactory(`${baseUrl}/logout`, 'Get', undefined, true, true);
    localStorage.clear();
}


export default {
    getAuthToken,    
    getUserId,
    isLoggedIn,
    login,
    register,
    logout,
    getEmail,   
}