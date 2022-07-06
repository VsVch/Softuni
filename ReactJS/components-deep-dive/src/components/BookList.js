import { useEffect } from 'react';
import {Book} from './Book.js'

export const BookList = (props) => {
  //First Aproach
  //   const bookElements = [];

  //   for (const book of props.books) {
  //     bookElements.push(
  //       <li>
  //         <header>{book.title}</header>
  //         <div>{book.description}</div>
  //         <footer>{book.author}</footer>
  //       </li>
  //     );
  //   }

  //   return <ul>{bookElements}</ul>;



  const bookElements = props.books.map((book, i) => (
    <Book key={i} book={book}/>
  ));

  return <ul>{bookElements}</ul>;
};
