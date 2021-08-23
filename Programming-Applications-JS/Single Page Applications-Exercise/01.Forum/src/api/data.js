import * as api from './api.js'

const host = 'http://localhost:3030';


export async function getTopics() {
     return await api.get(host + '/jsonstore/collections/myboard/posts');

};

export async function getTopicById(id) {
    return api.get(host + '/jsonstore/collections/myboard/posts/' + id);
  
};

export async function createTopic(body) {
    return api.post(host + '/jsonstore/collections/myboard/posts', body);
  
};

export async function getUserComments(){
    return api.get(host + '/jsonstore/collections/myboard/comments');
    
}