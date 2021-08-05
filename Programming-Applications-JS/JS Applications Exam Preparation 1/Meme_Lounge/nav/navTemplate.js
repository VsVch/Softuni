import { html } from './../node_modules/lit-html/lit-html.js';

export let navTemplate = (nav) => html`
    <a href="/memes">All Memes</a>
    ${nav.isLoggedIn 
    ? userNav(nav)
    : guestNav()
    }  
`

let userNav = (nav) => html`
    <div id="user" class="user">
        <a href="/create">Create Meme</a>
        <div class="profile">
            <span>Welcome, ${nav.email}</span>
            <a href="/my-profil">My Profile</a>
            <a href="/logout" >Logout</a>
        </div>
    </div>`;


let guestNav = () => html`
    <div id="guest" class="guest">
        <div class="profile">
            <a href="/login">Login</a>
            <a href="/register">Register</a>
        </div>
            <a class="active" href="/welcome">Home Page</a>
    </div>`;

