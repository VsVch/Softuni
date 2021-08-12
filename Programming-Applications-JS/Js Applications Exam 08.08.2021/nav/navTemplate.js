import { html } from '../node_modules/lit-html/lit-html.js'


export let navTemplate = (navInfo) => html`
<nav class="navbar">
    <section class="navbar-dashboard">
        <a href="/dashboard">Dashboard</a>
        ${navInfo.isLoggedIn ? userTemplate(navInfo) : guestTemplate()}
        <!-- Guest users -->

        <!-- Logged-in users -->

    </section>
</nav>`

export let userTemplate = (navInfo) => html`
    <div id="user">
        <span>Welcome, ${navInfo.email}</span>
        <a class="button" href="/myBooks">My Books</a>
        <a class="button" href="/create">Add Book</a>
        <a class="button" href="/logout">Logout</a>
    </div>
`

export let guestTemplate = () => html`
    <div id="guest">
        <a class="button" href="/login">Login</a>
        <a class="button" href="/register">Register</a>
    </div>
`
