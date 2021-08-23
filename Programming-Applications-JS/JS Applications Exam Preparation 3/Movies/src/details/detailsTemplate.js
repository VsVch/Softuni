import {html} from '../../node_modules/lit-html/lit-html.js';

export let detailsTemplate = (movie, movieInfo) => html`
<div class="container">
    <div class="row bg-light text-dark">
        <h1>Movie title: ${movie.title}</h1>

        <div class="col-md-8">
            <img class="img-thumbnail" src=${movie.img} alt="Movie">
        </div>
        <div class="col-md-4 text-center">
            <h3 class="my-3 ">Movie Description</h3>
            <p>${movie.description}</p>

            ${movieInfo.isCreator 
               ? html`
                    <a @click="${movieInfo.deleteHandler}" class="btn btn-danger" >Delete</a>
                    <a class="btn btn-warning" href="/edit/${movieInfo.movieId}">Edit</a>`
               : ''}
            ${(movieInfo.getOwnLike.length === 0 && !(movieInfo.isCreator))                   
                    ? html`<a @click="${movieInfo.likesHandler}" class="btn btn-primary">Like</a>`
                    : html`<span class="enrolled-span">Liked ${movieInfo.likes.length}</span>`}                 
           
        </div>
    </div>
</div>
</section>`
