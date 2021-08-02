import { html } from './../node_modules/lit-html/lit-html.js'
import * as movieService from './../sevices/movieService.js'

const movieDitailsTemplate = (movie) => html`
<div class="movie details" style="width: 18rem;">
    <img src=${movie.img} class="card-img-top" alt=${movie.title}>
    <div class="card-body">
        <h5 class="card-title">${movie.title}</h5>
        <p class="card-text">${movie.description}</p>
    </div>
</div>
`

export function moviesDetailsPage(ctx) {

    movieService.getOne(ctx.params.movieId)
    .then(movieData => {
        ctx.render(movieDitailsTemplate(movieData));
    })

}