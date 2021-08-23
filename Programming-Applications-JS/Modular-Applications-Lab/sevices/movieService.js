import * as request from './requester.js';
import * as api from './api.js';

export function getAll() {

    return request.get(api.movies)
      
}

export function getOne(id) {

    return request.get(`${api.movies}/${id}`);      
}