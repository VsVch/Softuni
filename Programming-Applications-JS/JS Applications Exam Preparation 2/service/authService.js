import { jsonRequest } from "./../helpers/jsonRequest.js";

let baseUrl = 'http://localhost:3030/users'

function getAuthToken() {
    return localStorage.getItem('authToken');
}

function getUserName() {
    return localStorage.getItem('username');
}

function getUserId() {
    return localStorage.getItem('userId');
}

function isLoggedIn() {
    return localStorage.getItem('authToken') !== null;
}

async function login(user) {

    let result = await jsonRequest(`http://localhost:3030/users/login`, 'Post', user); 
   
    localStorage.setItem('authToken', result.accessToken);
    localStorage.setItem('userId', result._id);
    localStorage.setItem('username', result.username);    

    return result;
}

async function register(user) {

    let result = await jsonRequest(`http://localhost:3030/users/register`, 'Post', user);
    localStorage.setItem('authToken', result.accessToken);
    localStorage.setItem('userId', result._id);
    localStorage.setItem('username', result.username);    
}


async function logout() {

   await jsonRequest('http://localhost:3030/users/logout', 'Get', undefined, true, true);
    localStorage.clear();    
}


export default {
    getAuthToken,
    getUserName,
    getUserId,
    isLoggedIn,
    login,
    register,
    logout,   
}