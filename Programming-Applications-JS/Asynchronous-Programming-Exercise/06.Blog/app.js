function attachEvents() {
    document.getElementById('btnLoadPosts').addEventListener('click', getPosts);
    document.getElementById('btnViewPost').addEventListener('click', displayPost);
}

async function getPosts(e) {

    console.log(e.target);

    let responce = await fetch('http://localhost:3030/jsonstore/blog/posts');
    date = await responce.json();

    let select = document.getElementById('posts');
    Object.values(date).map(createOption).forEach(o => select.appendChild(o));
}

function createOption(post) {

    let option = document.createElement('option');
    option.value = post.id;
    option.textContent = post.title;

    return option;
}

function displayPost(e) {
    let postId = document.getElementById('posts').value;
    getComments(postId);
}

async function getComments(postId) {
    let commentsUl = document.getElementById('post-comments');
    commentsUl.textContent = '';

    const postUrl = 'http://localhost:3030/jsonstore/blog/posts/' + postId;
    const commentUrl = `http://localhost:3030/jsonstore/blog/comments`;

    const [postResponce, commentsResponce] = await Promise.all([
        fetch(postUrl),
        fetch(commentUrl)
    ]);

    const postDate = await postResponce.json();

    document.getElementById('post-title').textContent = postDate.title;
    document.getElementById('post-body').textContent = postDate.body;


    const commentsDate = await commentsResponce.json(commentUrl);
    let currComments = Object.values(commentsDate).filter(x => x.postId == postId);


    currComments.map(createComment).forEach(c => commentsUl.appendChild(c));
}

function createComment(comment) {
    const result = document.createElement('li');
    result.textContent = comment.text;
    result.value = comment.id

    return result;
}

attachEvents();