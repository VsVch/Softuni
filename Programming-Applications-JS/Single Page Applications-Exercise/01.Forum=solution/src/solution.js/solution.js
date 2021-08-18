const main = document.querySelector('main');

const topicNameInput = document.querySelector('#topicName');
const userNameInput = document.querySelector('#username');
const postTextInput = document.querySelector('#postText');

const postBtn = document.querySelector('.public');
postBtn.addEventListener('click', createNewPost);

const cancelBtn = document.querySelector('.cancel');
cancelBtn.addEventListener('click', clearInput);

async function createNewPost(event) {
    event.preventDefault();

    const topicName = topicNameInput.value;
    const userName = userNameInput.value;
    const postText = postTextInput.value;
    const time = new Date();

    if (topicName === '' || userName === '' || postText === '') {
        return alert('All fields are required!')
    }

    try {
        const response = await fetch('http://localhost:3030/jsonstore/collections/myboard/posts', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ topicName, userName, postText, time })
        })

        if (!response.ok) {
            throw new Error;
        }

        const data = await response.json();

        const newPost = e('div', { className: 'topic-title' },
            e('div', { className: 'topic-container' },
                e('div', { className: 'theme-content' },
                    e('div', { className: 'theme-title' },
                        e('div', { className: 'theme-name-wrapper' },
                            e('div', { className: 'theme-name' },
                                e('h2', {}, topicName)))),
                    e('div', { className: 'comment' },
                        e('p', {}, `Date: <time>${time.toISOString()}</time>`),
                        e('p', {}, `Username: <span>${userName}</span>`))),
                e('button', { className: 'toggle' }, 'Show more')));

        main.appendChild(newPost);

        newPost.setAttribute('id', data._id);

        newPost.querySelector('.toggle').addEventListener('click', showPost);

        topicNameInput.value = '';
        userNameInput.value = '';
        postTextInput.value = '';

    } catch (error) {
        alert(error.message)
    }
}

function clearInput(event) {
    event.preventDefault(); //??

    topicNameInput.value = '';
    userNameInput.value = '';
    postTextInput.value = '';
}

async function showPost(event) {
    event.preventDefault();

    const id = event.target.parentElement.parentElement.id;

    try {
        const response = await fetch(`http://localhost:3030/jsonstore/collections/myboard/posts/${id}`);

        if (!response.ok) {
            throw new Error;
        }

        const data = await response.json();

        const commentDiv = event.target.parentElement.querySelector('.comment');

        const fullPost = e('div', { className: 'header' },
            e('img', {
                src: './static/profile.png',
                alt: 'avatar'
            }),
            e('p', {}, `<span>${data.userName}</span> posted on <time>${data.time}</time>`),
            e('p', { className: 'post-content' }, `${data.postText}`));

        commentDiv.innerHTML = '';
        commentDiv.appendChild(fullPost);

        const commentSection = createCommentSection();
        commentDiv.parentElement.appendChild(commentSection);

        commentSection.querySelector('button').addEventListener('click', addNewComment);

        const showLessBtn = e('button', { id: 'close' }, 'Show less');
        showLessBtn.addEventListener('click', showLess);

        event.target.parentElement.appendChild(showLessBtn); //adds ShowLessBtn
        event.target.remove(); // removes ShowMoreBtn


    } catch (error) {
        alert(error.message);
    }

}

async function showLess(event) {
    event.preventDefault();

    const id = event.target.parentElement.parentElement.id;

    try {
        const response = await fetch(`http://localhost:3030/jsonstore/collections/myboard/posts/${id}`);

        if (!response.ok) {
            throw new Error;
        }

        const data = await response.json();

        const currTopicName = data.topicName;
        const currTime = data.time;
        const currUsername = data.userName;

        const currPost = e('div', { className: 'topic-title' },
            e('div', { className: 'topic-container' },
                e('div', { className: 'theme-content' },
                    e('div', { className: 'theme-title' },
                        e('div', { className: 'theme-name-wrapper' },
                            e('div', { className: 'theme-name' },
                                e('h2', {}, `${currTopicName}`)))),
                    e('div', { className: 'comment' },
                        e('p', {}, `Date: <time>${currTime}</time>`),
                        e('p', {}, `Username: <span>${currUsername}</span>`))),
                e('button', { className: 'toggle' }, 'Show more')));


        event.target.parentElement.parentElement.replaceWith(currPost);

        currPost.setAttribute('id', data._id);
        currPost.querySelector('.toggle').addEventListener('click', showPost);


    } catch (error) {
        alert(error.message);
    }
}


async function addNewComment(event) {
    event.preventDefault();

    const textareaInput = event.target.parentElement.querySelector('#comment');
    const currUsernameInput = event.target.parentElement.querySelector('input');
    const textarea = textareaInput.value;
    const currUsername = currUsernameInput.value;
    const currTime = new Date();

    try {
        const response = await fetch('http://localhost:3030/jsonstore/collections/myboard/posts', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ textarea, currUsername, currTime })
        })

        if (!response.ok) {
            throw new Error;
        }


        const newComment = e('div', { id: 'user-comment' },
            e('div', { className: 'topic-name-wrapper' },
                e('div', { className: 'topic-name' },
                    e('p', {}, `<strong>${currUsername}</strong> commented on <time>${currTime.toISOString()}</time>`),
                    e('div', { className: 'post-content' },
                        e('p', {}, `${textarea}`)))));



        event.target.parentElement.parentElement.parentElement.parentElement.querySelector('.comment').appendChild(newComment);

        event.target.parentElement.querySelector('#comment').value = '';
        event.target.parentElement.querySelector('input').value = '';


    } catch (error) {
        alert(error.message);
    }
}



function createCommentSection() {
    const result = e('div', { className: 'answer-comment' },
        e('p', {}, '<span>currentUser</span> comment:'),
        e('div', { className: 'answer' },
            e('form', {},
                e('textarea', { id: 'comment', name: 'postText', cols: 30, rows: 10 }, ''),
                e('div', {},
                    e('label', { for: 'username' }, 'Username <span class="red">*</span>'),
                    e('input', { id: 'username', type: 'text', name: 'username' }, '')),
                e('button', {}, 'Post'))));

    return result;
}

function e(type, attributes, ...content) {
    const result = document.createElement(type);

    for (let [attr, value] of Object.entries(attributes || {})) {
        result[attr] = value;
    }


    content = content.reduce((a, c) => a.concat(Array.isArray(c) ? c : [c]), []);

    content.forEach(e => {
        if (typeof e == 'string' || typeof e == 'number') {
            //const node = document.createTextNode(e);
            result.innerHTML = e;
        } else {
            result.appendChild(e);
        }
    });

    return result;
}