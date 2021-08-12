import { html } from '../../node_modules/lit-html/lit-html.js'

export let detailsTemplate = (book, booksInfo) => html`
<section id="details-page" class="details">
    <div class="book-information">
        <h3>${book.title}</h3>
        <p class="type">Type: ${book.type}</p>
        <p class="img"><img src= ${book.imageUrl}></p>
        <div class="actions">
        ${booksInfo.isOwner 
            ? html`<a class="button" href="/edit/${book._id}">Edit</a>
                   <a @click="${booksInfo.deleteHandler}" class="button" href="javascript:void(0)">Delete</a>`
            : html ``}
            
        ${(booksInfo.getOwnLike === 0 && !(booksInfo.isOwner) && booksInfo.userId !== null)                    
            ? html`<a @click="${booksInfo.likesHandler}" class="button" href="javascript:void(0)">Like</a>`
            : ``}  
                    
            <div class="likes">
                <img class="hearts" src="/images/heart.png">
                <span id="total-likes">Likes: ${booksInfo.likes}</span>
            </div>                     
        </div>
    </div>
    <div class="book-description">
        <h3>Description:</h3>
        <p>${book.description}</p>
    </div>
</section>

`