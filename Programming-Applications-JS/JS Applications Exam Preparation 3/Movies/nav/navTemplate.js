import { html } from '../node_modules/lit-html/lit-html.js';

export let navTemplate = (navInfo) => html`
<nav class="navbar navbar-expand-lg navbar-dark bg-dark ">
    <a class="navbar-brand text-light" href="/home">Movies</a>
    <ul class="navbar-nav ml-auto ">
        ${navInfo.isLoggedIn ? userNav(navInfo) : guestNav()}
    </ul>
</nav>`;

let userNav = (navInfo) => html`
<li class="nav-item">
    <a class="nav-link">Welcome, ${navInfo.email}</a>
</li>
<li class="nav-item">
    <a class="nav-link" href="/logout">Logout</a>
</li>
`

let guestNav = () => html`
<li class="nav-item">
    <a class="nav-link" href="/login">Login</a>
</li>
<li class="nav-item">
    <a class="nav-link" href="/register">Register</a>
</li>
`