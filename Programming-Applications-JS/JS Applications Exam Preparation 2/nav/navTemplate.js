import { html } from './../node_modules/lit-html/lit-html.js';


export let navTemplate = (navInfo) => html`
<nav>
    <a class="active" href="/home">Home</a>
    <a href="/cars">All Listings</a>
    <a href="/search">By Year</a>
    <!-- Guest users -->
    ${navInfo.username 
    ? html`<div id="profile">
        <a>Welcome ${navInfo.username}</a>
        <a href="/myCars">My Listings</a>
        <a href="/create">Create Listing</a>
        <a href="/logout">Logout</a>
    </div>`
    : html`<div id="guest">
        <a href="/login">Login</a>
        <a href="/register">Register</a>
    </div>`
    }
    
    <!-- Logged users -->
    
</nav>
`