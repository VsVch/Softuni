import { requesterFactory } from "../helpers/requesterFactory.js";


let baseUrl = 'http://localhost:3030/data/memes';

async function get(id) {
    let result = await requesterFactory(`${baseUrl}/${id}`);
    return result;
}

async function create(item) {
    let result = await requesterFactory(`${baseUrl}`, 'Post', item, true);
    return result;
}

async function update(item, id) {
    let result = await requesterFactory(`${baseUrl}/${id}`, 'Put', item, true);
    return result;
}

async function getAll() {
    let result = await requesterFactory(`${baseUrl}?sortBy=_createdOn%20desc`);    
    return result;
}

async function deleteItem(id) {
    let result = await requesterFactory(`${baseUrl}/${id}`, 'Delete', undefined, true);
    return result;
}

async function getMy(userId) {

    let result = await requesterFactory(`${baseUrl}?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`);
    return result;                        
}

export default {
    getAll,
    get,
    create,
    update,
    deleteItem,
    getMy,   
};