import { requesterFactory } from "../helpers/requesterFactory.js";

let baseUrl = 'http://localhost:3030/data/books';

async function get(id) {
    let result = await requesterFactory(`http://localhost:3030/data/books/${id}`);
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

    let result = await requesterFactory(`http://localhost:3030/data/books?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`);
                                                                      ///?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc
    return result;                        
}

async function getLikes(bookId) {

    let result = await requesterFactory(`http://localhost:3030/data/likes?where=bookId%3D%22${bookId}%22&distinct=_ownerId&count`);
                                                            ///data/likes?where=bookId%3D%22${bookId}%22&distinct=_ownerId&count
    return result;                        
}

async function getMyLike(bookId, userId) {

    let result = await requesterFactory(`http://localhost:3030/data/likes?where=bookId%3D%22${bookId}%22%20and%20_ownerId%3D%22${userId}%22&count`);
                                                           ////data/likes?where=bookId%3D%22${bookId}%22%20and%20_ownerId%3D%22${userId}%22&count
    return result;                        
}

async function postLike(item) {
    let result = await requesterFactory(`http://localhost:3030/data/likes`, 'Post', item, true)
    return result;

}


export default {
    getAll,
    get,
    create,
    update,
    deleteItem,
    getMy,  
    getLikes, 
    getMyLike,
    postLike
};