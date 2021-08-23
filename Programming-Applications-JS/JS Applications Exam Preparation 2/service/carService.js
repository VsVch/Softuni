import { jsonRequest } from './../helpers/jsonRequest.js';

let baseUrl = 'http://localhost:3030';

async function getAll() {
    let result = await jsonRequest(`${baseUrl}/data/cars?sortBy=_createdOn%20desc`);  
    return result;
}

async function get(id) {
    let result = await jsonRequest(`${baseUrl}/data/cars/${id}`);
    return result;
}

async function create(item) {
    let result = await jsonRequest(`${baseUrl}/data/cars`, 'Post', item, true);
    return result;
}

async function update(item, id) {
    let result = await jsonRequest(`${baseUrl}/data/cars/${id}`, 'Put', item, true);
    return result;
}

async function deleteItem(id) {
    let result = await jsonRequest(`${baseUrl}/data/cars/${id}`, 'Delete', undefined, true);
    return result;
}

async function getMy(userId) {
    
    let result = await jsonRequest(`http://localhost:3030/data/cars?where=_ownerId%3D%22${userId}%22&amp;sortBy=_createdOn%20desc`);
    return result;
}

async function getByYear(year) {
    
    let result = await jsonRequest(`${baseUrl}/data/cars?where=year%3D${year}`);
    return result;
}



export default {
    getAll,
    get,
    create,
    update,
    deleteItem,
    getMy,
    getByYear
};