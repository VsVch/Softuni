import { html } from './../node_modules/lit-html/lit-html.js'
import * as movieService from './../sevices/movieService.js'

const movieCardTemplate = (movie) => html`
<div class="card" style="width: 18rem;">
    <img src=${movie.img} class="card-img-top" alt="...">
    <div class="card-body">
        <h5 class="card-title">${movie.title}</h5>       
        <a href="/movies/${movie._id}" class="btn btn-primary">Detail</a>
    </div>
</div>
`

const moviesTemplate = (movies) => html`
<h2>Movie Page</h2>
<ul class="movie-list">
    ${movies.map(el => movieCardTemplate(el))};
</ul>
`

export function moviesPage(ctx) {

    let cards = movieService.getAll()
    .then(movies => {
        console.log(cards)
        ctx.render(moviesTemplate(movies))
    });   

}