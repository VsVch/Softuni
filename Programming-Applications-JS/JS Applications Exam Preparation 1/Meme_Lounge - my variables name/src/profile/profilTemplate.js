import { html } from './../../node_modules/lit-html/lit-html.js';

export let profilMeme = (meme) => html`
<div class="user-meme">
    <p class="user-meme-title">${meme.title}</p>
    <img class="userProfileImage" alt="meme-img" src="${meme.imageUrl}">
    <a class="button" href="/details/${meme._id}">Details</a>
</div>
`

export let profilTemplate = (person) => html`
<section id="user-profile-page" class="user-profile">
    <article class="user-info">
        <img id="user-avatar-url" alt="user-profile" src=${person.gender === 'female' ? "/images/female.png ":"/images/male.png" }>
        <div class="user-content">
            <p>${person.username}</p>
            <p>${person.email}</p>
            <p>My memes count: ${person.memes.length}</p>
        </div>
    </article>
    <h1 id="user-listings-title">User Memes</h1>
    <div class="user-meme-listings">
        ${person.memes.length > 0 
        ? person.memes.map(el => profilMeme(el))
        : html`<p class="no-memes">No memes in database.</p>`}            
    </div>
</section>
`