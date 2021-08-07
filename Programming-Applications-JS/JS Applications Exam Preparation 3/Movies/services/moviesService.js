import { jsonRequest } from "../helpers/jsonRequest.js";


let baseUrl = 'http://localhost:3030/data/movies';

async function get(id) {
    let result = await jsonRequest(`${baseUrl}/${id}`);
    return result;
}

async function create(item) {
    let result = await jsonRequest(`${baseUrl}`, 'Post', item, true);
    return result;
}

async function update(item, id) {
    let result = await jsonRequest(`${baseUrl}/${id}`, 'Put', item, true);
    return result;
}

async function getAll() {
    let result = await jsonRequest(`${baseUrl}`);
    return result;
}

async function deleteItem(id) {
    let result = await jsonRequest(`${baseUrl}/${id}`, 'Delete', undefined, true);
    return result;
}

async function postLike(item) {
    let result = await jsonRequest(`http://localhost:3030/data/likes`, 'Post', item, true)
    return result;

}

async function getLikes(movieId) {
    let result = await jsonRequest(`http://localhost:3030/data/likes?where=movieId%3D%22${movieId}%22&amp;distinct=_ownerId&amp;count`);                                                    
    return result;
}

async function getMyLike(movieId, userId) {

    let result = await jsonRequest(`http://localhost:3030/data/likes?where=movieId%3D%22${movieId}%22%20and%20_ownerId%3D%22${userId}%22`);                                                        
    return result;
}

export default {
    getAll,
    get,
    create,
    update,
    deleteItem,
    postLike,
    getLikes,
    getMyLike,
};