export const Book = (props) => {
    return (
        <article>
            <h2>Book Title: {props.title}</h2>
            <div>Book Description: {props.description}</div>
            <div>Book Author: {props.author}</div>
        </article>       
    );
};