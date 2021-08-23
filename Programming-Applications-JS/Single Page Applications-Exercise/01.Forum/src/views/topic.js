import { e } from '../utils.js';
import { getTopicById, getUserComments } from '../api/data.js';


let main;
let section;
let topicTitleDiv;
let commentDiv;

export function setupTopic(mainTarget, sectionTarget) {

    main = mainTarget;
    section = sectionTarget;
    topicTitleDiv = section.querySelector('.theme-title');
    commentDiv = section.querySelector('.comment');

    section.querySelector('form').addEventListener('submit', createUserComment);

}

export async function showTopicDetails(id) {

    topicTitleDiv.innerHTML = 'Loading&hellip;';
    main.innerHTML = '';
    main.appendChild(section);

    const topic = await getTopicById(id);
    const topicTitleWrapperDiv = createTopicTitle(topic);

    topicTitleDiv.innerHTML = '';
    topicTitleDiv.appendChild(topicTitleWrapperDiv);

    const comment = createComment(topic);
    commentDiv.innerHTML = '';
    commentDiv.appendChild(comment);

    const userComments = Object.values(await getUserComments(id)).filter(c => c.commentId == id);
    if (userComments.length != 0) {
        const cards = userComments.map(createUserCommentCard);
        const fragment = document.createDocumentFragment();
        cards.forEach(c => fragment.appendChild(c));

        const divId = document.createElement('div');
        divId.setAttribute('id', 'user-comment');
        divId.appendChild(fragment);
        commentDiv.appendChild(divId);
    }

}

function createUserCommentCard(comment){

    const result = e('div', {classList: 'topic-name-wrapper'},
                           e('div', {classList: 'topic-name'},
                                    e('p', {},
                                         e('strong', {}, `${comment.username}`),
                                         ' commented on ',
                                         e('time', {}, `${comment.date}`)),
                                    e('div', {classList: 'post-content'},
                                          e('p', {}, `${comment.postText}`))));

    return result;

}

function createTopicTitle(topic) {

    const result = e('div', { classList: 'theme-name-wrapper' },
        e('div', { classList: 'theme-name' },
            e('h2', {}, `${topic.topicName}`)));

    return result;
}

function createComment(topic) {
    const result = e('div', { classList: 'header' },
        e('input', { type: 'hidden', id: `${topic._id}` }),
        e('img', { src: './static/profile.png', alt: 'avatar' }),
        e('p', {},
            e('span', {}, `${topic.username}`),
            ' posted on ',
            e('time', {}, `${topic.date}`)),
        e('p', {}, `${topic.postText}`));


    return result;
}

async function createUserComment(ev) {
    ev.preventDefault();
    const commentId = commentDiv.querySelector('input').getAttribute('id');
    const formData = new FormData(ev.target);
    const postText = formData.get('postText');
    const username = formData.get('username');
    const d = new Date();
    const date = d.getDate() + "-" + (d.getMonth() + 1) + "-" + d.getFullYear() + " " +
        d.getHours() + ":" + d.getMinutes();

        if(!postText || !username){
            return alert('All fiels are required')
        }

    section.querySelector('form').reset();

    const result = await fetch('http://localhost:3030/jsonstore/collections/myboard/comments',
        {
            method: 'post',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ commentId, username, postText, date })
        });

    showTopicDetails(commentId);


}

