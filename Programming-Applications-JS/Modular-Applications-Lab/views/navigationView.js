import {html} from '../node_modules/lit-html/lit-html.js'

let navigationTemplate = () => html`
<h1>My Movies</h1>
<nav class="navbar navbar-expand-lg navbar-light bg-light">
    <div class="container-fluid">
        <a class="navbar-brand" href="/">Movies</a>       
        <div class="collapse navbar-collapse" id="navbarNavAltMarkup">
            <div class="navbar-nav">
                <a class="nav-link" aria-current="page" href="/">Home</a>
                <a class="nav-link" href="/movies">Movies</a>
                <a class="nav-link" href="/login">Login</a>
            </div>
        </div>
        <span>
           
        </span>
    </div>
</nav>
`

export function renderNavigation(ctx){
   
  return navigationTemplate();
}