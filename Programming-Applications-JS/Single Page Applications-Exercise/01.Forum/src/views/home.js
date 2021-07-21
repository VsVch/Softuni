import { e } from '../utils.js';
import {getTopics, createTopic} from '../api/data.js';
import {showTopicDetails} from './topic.js';



let main;
let section;
let container;

export function setupHome(mainTarget, sectionTarget) {
    
    main = mainTarget;
    section = sectionTarget;
    container = section.querySelector('.topic-container');

    container.addEventListener('click', (event) => {
        if (event.target.tagName === "H2") {
            showTopicDetails(event.target.parentElement.id)
        }
    });

    section.querySelector('form').addEventListener('submit', create);
    section.querySelector('form .cancel').addEventListener('click', (ev) => {
        ev.preventDefault();
        ev.target.parentElement.parentElement.reset();
    });

   
}


export async function showHome() {
    container.innerHTML = 'Loading&hellip;';
    main.innerHTML = '';
    main.appendChild(section);

    const topics = await getTopics();
  
    const cards = Object.values(topics).map(createTopicPreview);

    const fragment = document.createDocumentFragment();
    cards.forEach(t => fragment.appendChild(t));

    container.innerHTML = '';
    container.appendChild(fragment);


}

async function create(ev) {
    ev.preventDefault();
    const formData = new FormData(ev.target);
    const topicName = formData.get('topicName');
    const username = formData.get('username');
    const postText = formData.get('postText');
    const d = new Date();
    const date = d.getDate()  + "-" + (d.getMonth()+1) + "-" + d.getFullYear() + " " +
    d.getHours() + ":" + d.getMinutes();

    if(!topicName || !username || !postText){
        return alert('All fields are required')
    }

    document.querySelector('form').reset();

   await createTopic({topicName, username, postText, date})

    showHome();
}


function createTopicPreview(topic) {
    const element = e('div', { classList: 'topic-name-wrapper' },
        e('div', { classList: 'topic-name' },
            e('a', { classList: 'normal', id: `${topic._id}`, href: 'javascript:void(0)' },
                e('h2', {}, `${topic.topicName}`)),
            e('div', { classList: 'columns' },
                e('div', {},
                    e('p', {}, 'Date: ',
                        e('time', {}, `${topic.date}`)),
                    e('div', { classList: 'nick-name' },
                        e('p', {} , 'Username:',
                            e('span', {}, `${topic.username}`)))))))

    return element;

}